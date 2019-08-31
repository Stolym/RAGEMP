using System;
using System.Collections.Generic;
using System.Text;
using RAGE;
using EAPI = RAGE.Elements;
using GAPI = RAGE.Game;
using Newtonsoft.Json;
using main_client.Ventura.StreamObject.WorldData;

namespace main_client.Ventura.Engine
{
    class Interaction
    {
        class SyncInteraction : Events.Script
        {
            public delegate void InteractionEvent(EAPI.Entity entity);
            public List<InteractionEvent> list_function = new List<InteractionEvent>();

            public SyncInteraction()
            {
                list_function.Add(OpenInventory);
                /*list_function.Add(vehicle_lock_closest_key);
                list_function.Add(vehicle_boot_closest_key);
                list_function.Add(vehicle_lock_closest_key);
                list_function.Add(vehicle_boot_closest_key);*/
            }

            private void OpenInventory(EAPI.Entity entity)
            {
                Events.CallLocal("destroyBrowser", "InteractionForm");
                InteractPlayer.instance.BrowserOpen[0] = false;
                InteractPlayer.instance.BrowserOpen[1] = true;
                Events.CallLocal("createBrowser", "InventoryForm", "package://Inventory/index.html");
                Inventory.instance.CallInventory();
            }


            private void vehicle_lock_closest_key(EAPI.Entity entity)
            {
                if (entity.Type != EAPI.Type.Vehicle)
                    return;
                EAPI.Vehicle veh = (EAPI.Vehicle)entity;
                var jsonData = veh.GetSharedData("StreamInVehicle");
                
                if (jsonData == null)
                    return;
                //Vehicule.VehicleStreamSync.SyncVehicleData result = JsonConvert.DeserializeObject<Vehicule.VehicleStreamSync.SyncVehicleData>(jsonData.ToString());
                //result.IsLock = !result.IsLock;
                //Events.CallRemote("UpdateVehicleData", JsonConvert.SerializeObject(result), veh.RemoteId);
            }
            

            private void object_closest_key(EAPI.Entity entity)
            {
                //Chat.Output("Get object");
                Events.CallLocal("ActiveWorld", new object[] { true });
            }
        }


        [JsonObject]
        struct InteractionCEFCommandSender
        {
            public List<Constant.Constant.InteractionFlags> ListCommand { get; set; }
        }
        public class InteractPlayer : Events.Script
        {
            public static InteractPlayer instance = null;
            private long tick { get; set; }
            private int time { get; set; }
            private string data_name = main_client.Ventura.Constant.Constant.table_data_name[((int)main_client.Ventura.Constant.Constant.UpdateFlagsClient.WorldVehiculeData >> 2) - 1];

            float max = 5f;

            public List<bool> BrowserOpen = new List<bool>() { false, false };
            
            List<EAPI.Entity> StreamIn = new List<EAPI.Entity>();
            SyncInteraction sync = new SyncInteraction();
            private bool active = false;


            public void InteractionActive(object []args) {
                active = true;
            }


            public InteractPlayer()
            {
                instance = this;
                tick = 0;
                time = 200;
                Events.Tick += Tick;
                Events.Add("CallActionCEFtoClient", CallActionCEFtoClient);
                Events.Add("InteractionActive", InteractionActive);
                Events.OnEntityStreamIn += OnEntityStreamIn;
                Events.OnEntityStreamOut += OnEntityStreamOut;
            }
            
            private void CallActionCEFtoClient(object[] args)
            {
                Constant.Constant.InteractionFlags flag = (Constant.Constant.InteractionFlags)((int)args[0]);

                switch (flag)
                {
                    case Constant.Constant.InteractionFlags.OwnInventory:
                        break;
                    case Constant.Constant.InteractionFlags.OpenCar:
                    case Constant.Constant.InteractionFlags.CloseCar:
                        OpenCloseCar(GetClosestVehicle());
                        break;
                    case Constant.Constant.InteractionFlags.OnEngineCar:
                    case Constant.Constant.InteractionFlags.OffEngineCar:
                        OnOffEngineCar(GetClosestVehicle());
                        break;
                    case Constant.Constant.InteractionFlags.OpenDoorCar:
                    case Constant.Constant.InteractionFlags.CloseDoorCar:
                        OpenCloseClosestCarDoor(GetClosestVehicle());
                        break;
                }


            }

            private void OpenCloseCar(EAPI.Vehicle vehicle)
            {
                if (vehicle == null)
                    return;
                if (vehicle.GetSharedData(data_name) == null)
                    return;
                Ventura.StreamObject.WorldData.WorldVehicleData data = JsonConvert.DeserializeObject<StreamObject.WorldData.WorldVehicleData>(vehicle.GetSharedData(data_name).ToString());
                if (data == null)
                    return;
                data.IsLock = !data.IsLock;
                Events.CallRemote("UpdateWorldVehicleData", vehicle.RemoteId, JsonConvert.SerializeObject(data));
            }

            private void OnOffEngineCar(EAPI.Vehicle vehicle)
            {
                if (vehicle == null)
                    return;
                if (vehicle.GetSharedData(data_name) == null)
                    return;
                Ventura.StreamObject.WorldData.WorldVehicleData data = JsonConvert.DeserializeObject<StreamObject.WorldData.WorldVehicleData>(vehicle.GetSharedData(data_name).ToString());
                if (data == null)
                    return;
                data.IsOn = !data.IsOn;
                Events.CallRemote("UpdateWorldVehicleData", vehicle.RemoteId, JsonConvert.SerializeObject(data));
            }

            private void OpenCloseClosestCarDoor(EAPI.Vehicle vehicle)
            {
                int index = 0;
                int ptr = -1;
                float max = 2f;
                Vector3 pos = null;

                if (vehicle == null)
                    return;
                if (vehicle.GetSharedData(data_name) == null)
                    return;
                Ventura.StreamObject.WorldData.WorldVehicleData data = JsonConvert.DeserializeObject<StreamObject.WorldData.WorldVehicleData>(vehicle.GetSharedData(data_name).ToString());
                if (data == null)
                    return;

                for (int i = 0; i < 7; i++)
                {
                    index = RAGE.Game.Entity.GetEntityBoneIndexByName(vehicle.Handle, Constant.Constant.VehicleDoorBone[i]);
                    if (RAGE.Game.Entity.GetWorldPositionOfEntityBone(vehicle.Handle, index).DistanceTo(RAGE.Elements.Player.LocalPlayer.Position) < max)
                    {
                        max = RAGE.Game.Entity.GetWorldPositionOfEntityBone(vehicle.Handle, index).DistanceTo(RAGE.Elements.Player.LocalPlayer.Position);
                        pos = RAGE.Game.Entity.GetWorldPositionOfEntityBone(vehicle.Handle, index);
                        ptr = i;
                    }
                }
                if (pos == null || ptr == -1)
                    return;
                RAGE.Game.Graphics.DrawBox(pos.X, pos.Y, pos.Z, pos.X + 0.1f, pos.Y + 0.1f, pos.Z + 0.1f, 0, 255, 80, 255);
                Chat.Output(data.DoorRatio[ptr] + " " + ptr);

                if (data.DoorRatio[ptr] > 0.5f && data.DoorRatio[ptr] <= 1f)
                    data.DoorRatio[ptr] = 0;
                else if (data.DoorRatio[ptr] >= 0f && data.DoorRatio[ptr] <= 0.5f && ptr < 4)
                    RAGE.Game.Ai.TaskOpenVehicleDoor(RAGE.Elements.Player.LocalPlayer.Handle, vehicle.Handle, 15000, ptr == 1 ? 2 : ptr == 3 ? 1 : ptr, 0.5f);
                else if (data.DoorRatio[ptr] >= 0f && data.DoorRatio[ptr] <= 0.5f && ptr >= 4 && ptr < 6)
                    data.DoorRatio[ptr] = 1;
                else if (data.DoorRatio[ptr] >= 0f && data.DoorRatio[ptr] <= 0.5f && ptr >= 6) {
                    data.DoorRatio[ptr] = 1;
                    data.DoorRatio[ptr + 1] = 1;
                }
                Events.CallRemote("UpdateWorldVehicleData", vehicle.RemoteId, JsonConvert.SerializeObject(data));
            }

            private RAGE.Elements.Vehicle GetClosestVehicle()
            {
                RAGE.Elements.Vehicle veh = null;
                float dist = 5f;

                for (int i = 0; i < RAGE.Elements.Entities.Vehicles.All.Count; i++)
                {
                    if (RAGE.Elements.Entities.Vehicles.All[i].Position.DistanceTo(RAGE.Elements.Player.LocalPlayer.Position) < dist)
                    {
                        dist = RAGE.Elements.Entities.Vehicles.All[i].Position.DistanceTo(RAGE.Elements.Player.LocalPlayer.Position);
                        veh = RAGE.Elements.Entities.Vehicles.All[i];
                    }
                }
                if (veh == null)
                    return null;
                return veh;
            }

            private void OnEntityStreamIn(EAPI.Entity entity)
            {
                Chat.Output("Stream IN " + entity.RemoteId);
                if (!StreamIn.Contains(entity))
                {
                    StreamIn.Add(entity);
                }
            }

            private void OnEntityStreamOut(EAPI.Entity entity)
            {

                Chat.Output("Stream Out " + entity.RemoteId);
                if (StreamIn.Contains(entity))
                    StreamIn.Remove(entity);
            }

            EAPI.Entity get_type_closest(EAPI.Type type)
            {
                EAPI.Entity tmp = null;
                foreach (EAPI.Entity entity in StreamIn)
                {
                    if (type == entity.Type && entity.Position.DistanceTo(EAPI.Player.LocalPlayer.Position) < max)
                    {
                        tmp = entity;
                        max = entity.Position.DistanceTo(EAPI.Player.LocalPlayer.Position);
                    }
                }
                max = 2f;
                return tmp;
            }

            /*main_client.World.WorldObjectSync get_object_closest()
            {
                main_client.World.WorldObjectSync tmp = null;
                foreach (var citem in main_client.World.WorldItemSync.current_world_object)
                {
                    if (RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(new Vector3(citem.x, citem.y, citem.z)) < max)
                    {
                        tmp = citem;
                        max = new Vector3(citem.x, citem.y, citem.z).DistanceTo(EAPI.Player.LocalPlayer.Position);
                    }
                }
                max = 1f;
                return tmp;
            }*/

            bool CheckAllBrowser() {
                for (int i = 1; i < BrowserOpen.Count; i++) {
                    if (BrowserOpen[i]) {
                        Events.CallLocal("destroyBrowser", Constant.Constant.BrowserList[i]);
                        RAGE.Ui.Cursor.Visible = false;
                        BrowserOpen[i] = false;
                        return true;
                    }
                }
                return false;
            }


            void open_menu()
            {
                if (Input.IsDown((int)ConsoleKey.UpArrow) && DateTime.Now.Ticks > tick && active)
                {
                    if (CheckAllBrowser())
                    {
                    }
                    else if (BrowserOpen[0])
                    {
                        Utils.Browser.instance.delete_browser(new object[] { "InteractionForm" });
                        RAGE.Ui.Cursor.Visible = false;
                        BrowserOpen[0] = false;
                    }
                    else if (!BrowserOpen[0])
                    {
                        Utils.Browser.instance.create_browser(new object[] { "InteractionForm", "package://Interaction/index.html" });
                        RAGE.Ui.Cursor.Visible = true;
                        BrowserOpen[0] = true;
                    }
                    tick = 0;
                }
                if (Input.IsDown((int)ConsoleKey.DownArrow) && DateTime.Now.Ticks > tick && active)
                {
                    Inventory.instance.ClearInventory();
                    tick = 0;
                }
            }
            private void Tick(List<Events.TickNametagData> nametags)
            {
                if (tick == 0)
                    tick = DateTime.Now.AddMilliseconds(time).Ticks;
                open_menu();
                current_menu();
            }

            private void current_menu()
            {
                if (BrowserOpen[0] && DateTime.Now.Ticks > tick)
                {
                    Utils.Browser.instance.execute_browser(new object[] { "InteractionForm", "UpdateButtonAction", JsonConvert.SerializeObject(GetActionPossible()) });
                    tick = 0;
                }
            }

            private object GetActionPossible()
            {
                InteractionCEFCommandSender request = new InteractionCEFCommandSender() { ListCommand = new List<Constant.Constant.InteractionFlags>() { Constant.Constant.InteractionFlags.OwnInventory } };
                SetVehicleClosest(ref request);
                //SetPlayerClosest(ref request);
                //SetObjectClosest(ref request);
                return request;
            }

            private void SetObjectClosest(ref InteractionCEFCommandSender request)
            {
                return;
            }

            private void SetPlayerClosest(ref InteractionCEFCommandSender request)
            {
                RAGE.Elements.Player player = null;
                float dist = 5f;

                for (int i = 0; i < RAGE.Elements.Entities.Players.Streamed.Count; i++)
                {
                    if (RAGE.Elements.Entities.Players.Streamed[i].Position.DistanceTo(RAGE.Elements.Player.LocalPlayer.Position) < dist && RAGE.Elements.Player.LocalPlayer.RemoteId != RAGE.Elements.Entities.Players.Streamed[i].RemoteId)
                    {
                        dist = RAGE.Elements.Entities.Players.Streamed[i].Position.DistanceTo(RAGE.Elements.Player.LocalPlayer.Position);
                        player = RAGE.Elements.Entities.Players.Streamed[i];
                    }
                }
                if (player == null)
                    return;
                request.ListCommand.Add(Constant.Constant.InteractionFlags.CheckClosestPlayer);
            }

            private void SetVehicleClosest(ref InteractionCEFCommandSender request)
            {
                try { 
                    RAGE.Elements.Vehicle veh = null;
                    float dist = 5f;

                    for (int i = 0; i < RAGE.Elements.Entities.Vehicles.All.Count; i++)
                    {
                        if (RAGE.Elements.Entities.Vehicles.All[i].Position.DistanceTo(RAGE.Elements.Player.LocalPlayer.Position) < dist)
                        {
                            dist = RAGE.Elements.Entities.Vehicles.All[i].Position.DistanceTo(RAGE.Elements.Player.LocalPlayer.Position);
                            veh = RAGE.Elements.Entities.Vehicles.All[i];
                        }
                    }
                    if (veh == null || veh.Handle == 0)
                        return;
                    if (veh.GetSharedData(data_name) == null)
                        return;

                    Ventura.StreamObject.WorldData.WorldVehicleData data = JsonConvert.DeserializeObject<StreamObject.WorldData.WorldVehicleData>(veh.GetSharedData(data_name).ToString());
                    if (data == null)
                        return;

                    CheckIfCanOpenCloseDoor(veh, data, request);
                    CheckIfVehicleIsOn(data, request);
                    CheckIfVehicleIsLock(data, request);
                }
                catch (Exception ex) {
                    Chat.Output("A "+ex.Message);
                }

                //request.ListCommand.Add(Constant.Constant.InteractionFlags.CloseCar);
                //request.ListCommand.Add(Constant.Constant.InteractionFlags.OpenCar);
                //request.ListCommand.Add(Constant.Constant.InteractionFlags.ClosestCarInventory);
            }

            private void CheckIfCanOpenCloseDoor(EAPI.Vehicle veh, WorldVehicleData data, InteractionCEFCommandSender request)
            {
                try
                {
                    int index = 0;
                    int ptr = -1;
                    float max = 5f;
                    Vector3 pos = null;

                    for (int i = 0; i < 7; i++)
                    {
                        index = RAGE.Game.Entity.GetEntityBoneIndexByName(veh.Handle, Constant.Constant.VehicleDoorBone[i]);
                        if (RAGE.Game.Entity.GetWorldPositionOfEntityBone(veh.Handle, index).DistanceTo(RAGE.Elements.Player.LocalPlayer.Position) < max)
                        {
                            max = RAGE.Game.Entity.GetWorldPositionOfEntityBone(veh.Handle, index).DistanceTo(RAGE.Elements.Player.LocalPlayer.Position);
                            pos = RAGE.Game.Entity.GetWorldPositionOfEntityBone(veh.Handle, index);
                            ptr = i;
                        }
                    }
                    if (pos == null || ptr == -1)
                        return;
                    RAGE.Game.Graphics.DrawBox(pos.X, pos.Y, pos.Z, pos.X + 0.1f, pos.Y + 0.1f, pos.Z + 0.1f, 0, 255, 80, 255);
                    if (data.DoorRatio[ptr] > 0.5f && data.DoorRatio[ptr] <= 1f)
                        request.ListCommand.Add(Constant.Constant.InteractionFlags.CloseDoorCar);
                    else if (data.DoorRatio[ptr] >= 0f && data.DoorRatio[ptr] <= 0.5f)
                        request.ListCommand.Add(Constant.Constant.InteractionFlags.OpenDoorCar);
                }
                catch (Exception ex) {
                    Chat.Output("B "+ex.Message);
                }
            }

            private void CheckIfVehicleIsLock(StreamObject.WorldData.WorldVehicleData data, InteractionCEFCommandSender request)
            {
                if (data.IsLock == true)
                    request.ListCommand.Add(Constant.Constant.InteractionFlags.OpenCar);
                else
                    request.ListCommand.Add(Constant.Constant.InteractionFlags.CloseCar);
            }

            private void CheckIfVehicleIsOn(StreamObject.WorldData.WorldVehicleData data, InteractionCEFCommandSender request)
            {
                if (data.IsOn == false)
                    request.ListCommand.Add(Constant.Constant.InteractionFlags.OnEngineCar);
                else
                    request.ListCommand.Add(Constant.Constant.InteractionFlags.OffEngineCar);
            }

        }
    }
}
