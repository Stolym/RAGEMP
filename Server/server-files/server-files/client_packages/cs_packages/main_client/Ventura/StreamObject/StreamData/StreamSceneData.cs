using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RAGE;
using A = RAGE.Elements;
using main_client.Ventura.StreamObject.DataModel;


namespace main_client.Ventura.StreamObject.StreamData
{
    class StreamSceneData : Events.Script
    {
        private string event_name = main_client.Ventura.Constant.Constant.table_event_name[((int)main_client.Ventura.Constant.Constant.UpdateFlagsClient.WorldSceneData >> 2) - 1];
        private string data_name = main_client.Ventura.Constant.Constant.table_data_name[((int)main_client.Ventura.Constant.Constant.UpdateFlagsClient.WorldSceneData >> 2) - 1];
        private bool active_tick = false;
        private DataModel.DataModel model = null;
        private long tick = 0x0000000000000000;
        private int time = 500;


        public StreamSceneData()
        {
            Events.Add(event_name, UpdateSharedData);
            //Events.Tick += Tick;
        }

        private void Tick(List<Events.TickNametagData> nametags)
        {
            if (tick == 0)
                tick = DateTime.Now.Ticks;
            ProcessTick();
        }

        private void ProcessTick()
        {
            foreach (var client in A.Entities.Players.All)
            {
                if (client.GetSharedData(event_name) == null && client.GetData<string>(event_name) == null)
                    continue;
                else if (client.GetSharedData(event_name) != null && new DateTime(DateTime.Now.Ticks - tick).Millisecond > time)
                {
                    JsonConvert.DeserializeObject<StreamObject.WorldData.WorldSceneData>((string)client.GetSharedData(event_name)).StreamIn();
                    tick = 0;
                }
                else if (client.GetData<string>(event_name) != null && new DateTime(DateTime.Now.Ticks - tick).Millisecond > time)
                {
                    JsonConvert.DeserializeObject<StreamObject.WorldData.WorldRigidBodyData>((string)client.GetSharedData(event_name)).StreamIn();
                    tick = 0;
                }
            }
        }

        private void UpdateSharedData(object[] args)
        {
            Chat.Output("Ultim Async Scene");
            A.Player target_player = A.Entities.Players.All.Find(x => x.RemoteId == Convert.ToUInt16(args[0]));
            A.Vehicle target_vehicule = A.Entities.Vehicles.All.Find(x => x.RemoteId == Convert.ToUInt16(args[0]));

            if (target_player == null && target_vehicule == null && Convert.ToInt32(args[1]) != (int)main_client.Ventura.Constant.Constant.UpdateFlagsClient.Item)
            {
                Events.CallRemote("DataErrorEvent", event_name, Convert.ToUInt16(args[0]));
                return;
            }
            PlayerStreamIn(target_player, args[1].ToString());

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
            JsonConvert.DeserializeObject<StreamObject.WorldData.WorldSceneData>(json).StreamIn();
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
