using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using Newtonsoft.Json;
using System.IO;

namespace main.Ventura.World
{
    class WorldVehicleManager : Script
    {
        public static WorldVehicleManager instance { get; set; }

        public WorldVehicleManager() {
            instance = this;
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

            }
        }

        [RemoteEvent("CreateNewVehicle")]
        public void CreateNewVehicle(Client client, string data)
        {
            var tmp = JsonConvert.DeserializeObject<main.Ventura.Stream.StreamData.WorldVehicleData>(data);

            if (tmp == null)
                return;
            SpawnVehicleInStreamWorld(tmp);
        }


        public void SpawnVehicleInStreamWorld(main.Ventura.Stream.StreamData.WorldVehicleData data)
        {
            Vehicle veh = NAPI.Vehicle.CreateVehicle(NAPI.Util.GetHashKey(data.Name), new Vector3(data.x, data.y, data.z), data.Heading, data.Colour1, data.Colour2, data.NumberPlate);
            data.RemoteId = veh.Handle.Value;
            veh.SetSharedData("StreamInVehicle", JsonConvert.SerializeObject(data));
            UpdateVehicleDataStreamIn(veh, data);
        }


        public void UpdateVehicleDataStreamIn(Vehicle veh, main.Ventura.Stream.StreamData.WorldVehicleData data)
        {
            if (veh == null)
                return;
            foreach (Client c in NAPI.Pools.GetAllPlayers())
            {
                c.TriggerEvent("VehicleDataStreamEvent", veh.Handle.Value, JsonConvert.SerializeObject(data));
            }
        }


        public void UpdateVehicleDataClient(Client client)
        {
            /*Database.DataUser user = CMAPI.get_data_player(client);
            Synchronization.VehiclesDatas data = null;

            if (user == null)
                return;
            data = user.vehiculesDatas;
            if (data == null)
                return;
            data.UpdateStreamInClientLogin();*/
        }
    }
}
