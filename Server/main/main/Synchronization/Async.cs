using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GTANetworkAPI;
using Newtonsoft.Json;
//using DGAPI = main.Manager.DimensionGestion;

namespace main.Synchronization
{
    /*class Async : Script
    {

        [Command("spawn_sync")]
        public void spawn_sync_object(Client client, string name) {
            client.TriggerEvent("AddObjectWorld", name, JsonConvert.SerializeObject(client.Position.Around(3)));
        }

        [RemoteEvent("UpdateWorldObject")]
        public void UpdateWorldObject(Client client, object[] args)
        {

            client.SetSharedData("WorldObjectStream", args[0].ToString());
            foreach (Client c in NAPI.Pools.GetAllPlayers())
            {
                c.TriggerEvent("WorldObjectStreamUpdate", client.Handle.Value, (string)args[0]);
            }
        }

        [RemoteEvent("UpdateHealthData")]
        public void UpdateHealthData(Client client, object[] args)
        {
            NAPI.Util.ConsoleOutput(args[0].ToString());
            client.SetSharedData("StreamInHealth", args[0].ToString());
            foreach (Client c in NAPI.Pools.GetAllPlayers())
            {
                c.TriggerEvent("HeatlhDataStreamEvent", client.Handle.Value, (string)args[0]);
            }
        }

        [RemoteEvent("UpdateIntroductionTask")]
        public void UpdateIntroductionTask(Client client, object[] args)
        {
            //uint RemoteID = Convert.ToUInt16(args[1]);
            //TaskSync data = JsonConvert.DeserializeObject<TaskSync>(args[0].ToString());
            //Vehicle veh = NAPI.Pools.GetAllVehicles().Find(x => x.Handle.Value == RemoteID);
            //data.vRemoteId = veh.Handle.Value;
            NAPI.Util.ConsoleOutput(args[0].ToString());
            foreach (Vehicle v in NAPI.Pools.GetAllVehicles())
            {
                NAPI.Util.ConsoleOutput(v.DisplayName + " " + v.Handle.Value + " " + v.Handle);
            }
            client.SetSharedData("IntroductionTaskStream", args[0].ToString());
            foreach (Client c in NAPI.Pools.GetAllPlayers())
            {
                c.TriggerEvent("IntroductionTaskStreamUpdate", client.Handle.Value, args[0].ToString());
            }
        }


        [RemoteEvent("UpdateWorldItemObject")]
        public void UpdateWorldItemObject(Client client, object[] args)
        {

            client.SetSharedData("WorldItemObjectStream", args[0].ToString());
            foreach (Client c in NAPI.Pools.GetAllPlayers())
            {
                c.TriggerEvent("WorldItemObjectStreamUpdate", client.Handle.Value, (string)args[0]);
            }
        }

        [RemoteEvent("UpdateVehicleData")]
        public void UpdateVehicleData(Client client, object[] args)
        {
            uint RemoteID = Convert.ToUInt16(args[1]);
            Vehicle veh = NAPI.Pools.GetAllVehicles().Find(x => x.Handle.Value == RemoteID);

            if (veh == null)
                return;
            //NAPI.Util.ConsoleOutput("Update "+args[0].ToString().Remove(40, args[0].ToString().Length - 1));
            veh.SetSharedData("StreamInVehicle", args[0].ToString());
            foreach (Client c in NAPI.Pools.GetAllPlayers())
            {
                c.TriggerEvent("VehicleDataStreamEvent", veh.Handle.Value, (string)args[0]);
            }
        }

        public async Task<GTANetworkAPI.Object> spawn_object(Client player, string hash)
        {
            GTANetworkAPI.Object board = NAPI.Object.CreateObject(NAPI.Util.GetHashKey(hash), new Vector3(402.9378f, -998.05f, -98.85f), new Vector3(), 255, DGAPI.get_instance(player.SocialClubName));
            return (board);
        }

        public GTANetworkAPI.Object AsyncObjectSpawn(Client player, string hash) {
            Task<GTANetworkAPI.Object> task = spawn_object(player, hash);
            task.GetAwaiter();
            return task.Result;
        }
    }*/
}
