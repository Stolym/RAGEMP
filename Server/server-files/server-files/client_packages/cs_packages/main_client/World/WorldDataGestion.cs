using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RAGE;
//using Newtonsoft.Json;
//using A = RAGE.Elements;
//using main_client.StreamObject.DataModel;
//using main_client.StreamObject.WorldData;

namespace main_client.World
{
    /*class DataModelSync : Events.Script {

        private string event_name = Utils.Constant.table_event_name[(int)Utils.Constant.UpdateFlagsClient.WorldAttachData >> 2];
        private string data_name = Utils.Constant.table_data_name[(int)Utils.Constant.UpdateFlagsClient.WorldAttachData >> 2];
        private bool active_tick = false;
        private IDataModel model = null;

        public DataModelSync()
        {
            Events.Add(event_name, UpdateSharedData);
            Events.Tick += Tick;
        }

        private void Tick(List<Events.TickNametagData> nametags)
        {
            ProcessTick();
        }

        private void ProcessTick() {
            foreach (var client in A.Entities.Players.All) {
                if (client.GetSharedData(event_name) == null && client.GetData<string>(event_name) == null)
                    continue;
                else if (client.GetSharedData(event_name) != null)
                {

                }
                else if (client.GetData<string>(event_name) != null)
                {
                    
                }
            }
        }

        private void UpdateSharedData(object[] args)
        {
            A.Player target_player = A.Entities.Players.All.Find(x => x.RemoteId == Convert.ToUInt16(args[0]));
            A.Vehicle target_vehicule = A.Entities.Vehicles.All.Find(x => x.RemoteId == Convert.ToUInt16(args[0]));

            if (target_player == null && target_vehicule == null && Convert.ToInt32(args[1]) != (int)Utils.Constant.UpdateFlagsClient.Item)
            {
                Events.CallRemote("DataErrorEvent", event_name, Convert.ToUInt16(args[0]));
                return;
            }

            switch (Convert.ToInt32(args[1]))
            {
                case (int)Utils.Constant.UpdateFlagsClient.Player:
                    PlayerStreamIn(target_player, args[2].ToString());
                    break;
                case (int)Utils.Constant.UpdateFlagsClient.Vehicle:
                    VehicleStreamIn(target_vehicule, args[2].ToString());
                    break;
                case (int)Utils.Constant.UpdateFlagsClient.Item:
                    ItemStreamIn(args[2].ToString());
                    break;
            }
        }

        private void PlayerStreamIn(A.Player player, string json)
        {
            if (player == null)
            {
                Events.CallRemote("DataErrorEvent", event_name);
                return;
            }
            IDataModel tmp = JsonConvert.DeserializeObject<IDataModel>(json);
            if (tmp == null)
                return;
            model = JsonConvert.DeserializeObject<WorldAttachData>(json);
            player.SetData<string>(data_name, json);
            JsonConvert.DeserializeObject<WorldAttachData>(json).StreamIn();
            active_tick = true;
        }

        private void VehicleStreamIn(A.Vehicle vehicle, string json)
        {
            if (vehicle == null)
            {
                Events.CallRemote("DataErrorEvent", event_name);
                return;
            }
            IDataModel tmp = JsonConvert.DeserializeObject<IDataModel>(json);
            if (tmp == null)
                return;
            //model = JsonConvert.DeserializeObject<ObjectModelSync>(json);
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
    }*/
}
