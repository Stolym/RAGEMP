using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RAGE;
using A = RAGE.Elements;
using main_client.Ventura.StreamObject.DataModel;

namespace main_client.Ventura.StreamObject.StreamData
{
    class StreamVehicleData : Events.Script
    {
        private string event_name = main_client.Ventura.Constant.Constant.table_event_name[((int)main_client.Ventura.Constant.Constant.UpdateFlagsClient.WorldVehiculeData >> 2) - 1];
        private string data_name = main_client.Ventura.Constant.Constant.table_data_name[((int)main_client.Ventura.Constant.Constant.UpdateFlagsClient.WorldVehiculeData >> 2) - 1];
        private bool active_tick = false;
        private DataModel.DataModel model = null;
        private long tick = 0x0000000000000000;
        private long ftick = 0x0000000000000000;
        private int time = 800;


        public StreamVehicleData()
        {
            Events.Add(event_name, UpdateSharedData);
            //Events.Tick += Tick;
        }

        private void Tick(List<Events.TickNametagData> nametags)
        {
            if (tick == 0)
                tick = DateTime.Now.AddMilliseconds(40).Ticks;
            if (ftick == 0)
                ftick = DateTime.Now.AddSeconds(1).Ticks;
            ProcessTick();
        }
        
        private void ProcessTick()
        {
            foreach (var veh in A.Entities.Vehicles.All)
            {
                /*if (client.GetSharedData(event_name) == null && client.GetData<string>(event_name) == null)
                    continue;
                else if (client.GetSharedData(event_name) != null && new DateTime(DateTime.Now.Ticks - tick).Millisecond > time)
                {
                    JsonConvert.DeserializeObject<StreamObject.WorldData.WorldSceneData>((string)client.GetSharedData(event_name)).StreamIn();
                    tick = 0;
                }*/
                /*if (veh.GetData<string>(data_name) != null && new DateTime(DateTime.Now.Ticks - tick).Millisecond > time)
                {
                    JsonConvert.DeserializeObject<StreamObject.WorldData.WorldVehicleData>(veh.GetData<string>(data_name)).StreamIn();
                    tick = 0;
                }*/
                if (veh.GetSharedData(data_name) != null && DateTime.Now.Ticks > tick)
                {
                    JsonConvert.DeserializeObject<StreamObject.WorldData.WorldVehicleData>((string)veh.GetSharedData(data_name)).StreamIn();
                    if (RAGE.Game.Vehicle.GetPedInVehicleSeat(veh.Handle, -1, 0) == RAGE.Elements.Player.LocalPlayer.Handle && DateTime.Now.Ticks > ftick)
                    {
                        //var data = JsonConvert.DeserializeObject<StreamObject.WorldData.WorldVehicleData>((string)veh.GetSharedData(data_name));
                        //data.Gazol--;
                        //Events.CallLocal("executeFunction", "HUDForm", "set_gazol", (int)data.Gazol);
                        //Events.CallRemote("UpdateWorldvehicleData", veh.RemoteId, JsonConvert.SerializeObject(data));
                        ftick = 0;
                    }

                    tick = 0;
                }
            }
        }

        private void UpdateSharedData(object[] args)
        {
            A.Player target_player = A.Entities.Players.All.Find(x => x.RemoteId == Convert.ToUInt16(args[0]));
            A.Vehicle target_vehicule = A.Entities.Vehicles.All.Find(x => x.RemoteId == Convert.ToUInt16(args[0]));

            if (target_player == null && target_vehicule == null && Convert.ToInt32(args[1]) != (int)main_client.Ventura.Constant.Constant.UpdateFlagsClient.Item)
            {
                Events.CallRemote("DataErrorEvent", event_name, Convert.ToUInt16(args[0]));
                return;
            }
            VehicleStreamIn(target_vehicule, args[1].ToString());

            /*
            switch (Convert.ToInt32(args[1]))
            {
                case (int)main_client.Ventura.Constant.Constant.UpdateFlagsClient.Player:
                    PlayerStreamIn(target_player, args[2].ToString());
                    break;
                case (int)main_client.Ventura.Constant.Constant.UpdateFlagsClient.Vehicle:
                    VehicleStreamIn(target_vehicule, args[2].ToString());
                    break;
                case (int)main_client.Ventura.Constant.Constant.UpdateFlagsClient.Item:
                    ItemStreamIn(args[2].ToString());
                    break;
            }*/
        }

        private void PlayerStreamIn(A.Player player, string json)
        {
            if (player == null)
            {
                Events.CallRemote("DataErrorEvent", event_name);
                return;
            }
            DataModel.DataModel tmp = JsonConvert.DeserializeObject<DataModel.DataModel>(json);
            if (tmp == null)
                return;
            player.SetData<string>(data_name, json);
            JsonConvert.DeserializeObject<StreamObject.WorldData.WorldVehicleData>(json).StreamIn();
            active_tick = true;
        }

        private void VehicleStreamIn(A.Vehicle vehicle, string json)
        {
            if (vehicle == null)
            {
                Events.CallRemote("DataErrorEvent", event_name);
                return;
            }
            DataModel.DataModel tmp = JsonConvert.DeserializeObject<DataModel.DataModel>(json);
            if (tmp == null)
                return;
            vehicle.SetData<string>(data_name, json);
            JsonConvert.DeserializeObject<StreamObject.WorldData.WorldVehicleData>(json).StreamIn();
            active_tick = true;
        }

        private void ItemStreamIn(string json)
        {

        }

        private void PlayerStreamOut(A.Player player)
        {
            if (player == null)
            {
                Events.CallRemote("DataErrorEvent", event_name);
                return;
            }
        }

        private void VehicleStreamOut(A.Vehicle vehicle)
        {
            if (vehicle == null)
            {
                Events.CallRemote("DataErrorEvent", event_name);
                return;
            }
        }
    }
}
