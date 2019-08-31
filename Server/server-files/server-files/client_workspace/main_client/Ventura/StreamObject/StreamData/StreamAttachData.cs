using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RAGE;
using A = RAGE.Elements;
using main_client.Ventura.StreamObject.DataModel;
using main_client.Ventura.StreamObject.WorldData;

namespace main_client.Ventura.StreamObject.StreamData
{
    class StreamAttachData : Events.Script
    {
        private string event_name = main_client.Ventura.Constant.Constant.table_event_name[((int)main_client.Ventura.Constant.Constant.UpdateFlagsClient.WorldAttachData >> 2) - 1];
        private string data_name = main_client.Ventura.Constant.Constant.table_data_name[((int)main_client.Ventura.Constant.Constant.UpdateFlagsClient.WorldAttachData >> 2) - 1];
        private bool active_tick = false;
        private DataModel.DataModel model = null;
        private long tick = 0x0000000000000000;
        private int time = 800;

        public StreamAttachData()
        {
            Events.Add(event_name, UpdateSharedData);
            //Events.Tick += Tick;
        }

        private void Tick(List<Events.TickNametagData> nametags)
        {
            if (tick == 0)
                tick = DateTime.Now.AddMilliseconds(time).Ticks;
            ProcessTick();
        }

        private void ProcessTick()
        {
            /*if (ped == 0)
                ped = RAGE.Game.Ped.CreatePed(10, 1885233650, RAGE.Elements.Player.LocalPlayer.Position.X, RAGE.Elements.Player.LocalPlayer.Position.Y, RAGE.Elements.Player.LocalPlayer.Position.Z + 1, 0, false, false);
            else
            {

                if (RAGE.Game.Ped.IsPedDeadOrDying(ped, true)) {
                    Chat.Output("passage");
                    RAGE.Game.Ped.ReviveInjuredPed(ped);
                }
            130 Parade
            131 fight
            }*/

            if (DateTime.Now.Ticks < tick)
                return;
            foreach (var client in A.Entities.Players.All)
            {

                if (client.GetSharedData(data_name) == null && client.GetData<string>(data_name) == null)
                    continue;
                /*else if (client.GetSharedData(data_name) != null && client.GetData<string>(data_name) == null && DateTime.Now.Ticks > tick)
                {
                    var data = JsonConvert.DeserializeObject<List<StreamObject.WorldData.WorldAttachData>>((string)client.GetSharedData(data_name));
                    for (int i = 0; i < data.Count; i++)
                        data[i].StreamIn();
                    client.SetData<string>(data_name, JsonConvert.SerializeObject(data));
                    tick = 0;
                }*/
                else if (client.GetData<string>(data_name) != null && DateTime.Now.Ticks > tick)
                {
                    var data = JsonConvert.DeserializeObject<List<StreamObject.WorldData.WorldAttachData>>(client.GetData<string>(data_name));
                    for (int i = 0; i < data.Count; i++)
                        data[i].StreamIn();
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
                Chat.Output("Data Error");
                Events.CallRemote("DataErrorEvent", event_name, Convert.ToUInt16(args[0]));
                return;
            }
            Chat.Output("Attach Ultime B "+target_player.Name);

            PlayerStreamIn(target_player, args[1].ToString());
        }
        
        private void PlayerStreamIn(A.Player player, string json)
        {
            if (player == null)
            {
                Events.CallRemote("DataErrorEvent", event_name);
                return;
            }
            /*DataModel.DataModel tmp = JsonConvert.DeserializeObject<DataModel.DataModel>(json);
            if (tmp == null)
                return;*/
            var data = JsonConvert.DeserializeObject<List<StreamObject.WorldData.WorldAttachData>>(json);

            List<WorldData.WorldAttachData> instant = null;
            if (player.GetData<string>(data_name) != null)
                instant = JsonConvert.DeserializeObject<List<StreamObject.WorldData.WorldAttachData>>(json);
            if (instant != null)
                UpdateSyncLocalId(data, instant, player);
            else
                UpdateSyncWithoutLocalId(data, player);
        }

        private void UpdateSyncLocalId(List<WorldAttachData> data, List<WorldAttachData> instant, A.Player player)
        {
            bool streamOut = true;
            for (int i = 0; i < instant.Count; i++) {
                for (int j = 0; j < data.Count; i++) {
                    if (instant[i].Hashcode == data[i].Hashcode && instant[i].IsAttached == data[i].IsAttached)
                    {
                        streamOut = false;
                        data[i].LocalId = instant[i].LocalId;
                        break;
                    }
                    else if (instant[i].Hashcode == data[i].Hashcode && instant[i].IsAttached != data[i].IsAttached) {
                        instant[i].StreamOut();
                    }
                }
                if (streamOut)
                    instant[i].StreamOut();
            }
            for (int i = 0; i < data.Count; i++)
            {
                data[i].StreamIn();
                active_tick = true;
            }
            player.SetData<string>(data_name, JsonConvert.SerializeObject(data));
        }

        private void UpdateSyncWithoutLocalId(List<WorldAttachData> data, A.Player player)
        {
            for (int i = 0; i < data.Count; i++)
            {
                data[i].StreamIn();
                active_tick = true;
            }
            player.SetData<string>(data_name, JsonConvert.SerializeObject(data));
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
