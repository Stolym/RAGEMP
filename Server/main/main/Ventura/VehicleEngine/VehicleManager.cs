using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using Newtonsoft.Json;
using System.IO;
//using CMAPI = main.Manager.CharacterManager;
//using DGAPI = main.Manager.DimensionGestion;
//using DUser = main.Database.DataUser;

namespace main.Ventura.Engine.VehicleManager
{
    /*
     * If vehicule not garage == Save
     * World List
     * 
     * 
     * 
     * */
     
    
    /*class VehicleManager : Script {
        
        public VehicleManager() {

        }

        [ServerEvent(Event.ResourceStart)]
        public void resourceStart()
        {
            string[] lines;
            using (StreamReader sr = File.OpenText("./data/Vehicle/vehicleData.txt"))
            {
                lines = File.ReadAllLines("./data/Vehicle/vehicleData.txt");
                sr.Close();
            }
            foreach (string line in lines)
            {

                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                Synchronization.SyncVehicleData vehicle = null;
                if (line.Contains(@"\"))
                {
                    string json = line.Replace(@"\", "").Remove(0, 1);
                    //NAPI.Util.ConsoleOutput(json.Remove(json.Length - 1, 1));
                    vehicle = JsonConvert.DeserializeObject<Synchronization.SyncVehicleData>(json.Remove(json.Length - 1, 1), settings);
                }
                else {
                    vehicle = JsonConvert.DeserializeObject<Synchronization.SyncVehicleData>(line, settings);
                }
                SpawnVehicleInStreamWorld(vehicle);
            }
        }

        [RemoteEvent("CreateNewVehicle")]
        public void CreateNewVehicle(Client client, string data) {
            var tmp = JsonConvert.DeserializeObject<Synchronization.SyncVehicleData>(data);

            if (tmp == null)
                return;
            SpawnVehicleInStreamWorld(tmp);
        }

        public static void UpdateVehicleDataStreamIn(Vehicle veh, Synchronization.SyncVehicleData data) {
            if (veh == null)
                return;
            foreach (Client c in NAPI.Pools.GetAllPlayers())
            {
                c.TriggerEvent("VehicleDataStreamEvent", veh.Handle.Value, JsonConvert.SerializeObject(data));
            }
        }

        public static void SpawnVehicleInStreamWorld(Synchronization.SyncVehicleData data) {
            Vehicle veh = NAPI.Vehicle.CreateVehicle(NAPI.Util.GetHashKey(data.Name), new Vector3(data.x, data.y, data.z), data.Heading, data.Colour1, data.Colour2, data.NumberPlate);
            data.RemoteId = veh.Handle.Value;
            veh.SetSharedData("StreamInVehicle", JsonConvert.SerializeObject(data));
            UpdateVehicleDataStreamIn(veh, data);
        }

        public void UpdateVehicleDataClient(Client client) {
            Database.DataUser user = CMAPI.get_data_player(client);
            Synchronization.VehiclesDatas data = null;

            if (user == null)
                return;
            data = user.vehiculesDatas;
            if (data == null)
                return;
            data.UpdateStreamInClientLogin();
        }

    }*/
}
