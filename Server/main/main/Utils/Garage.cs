using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using System.IO;
using GTANetworkAPI;
using Newtonsoft.Json;
using RWAPI = main.Ventura.Database.ReaderWriter.ReaderWriter;

namespace main.Utils
{
    /*class Garage : Script
    {

        [Command("create_garage_shop")]
        public void create_barber(Client client, int id, int state, float x, float y, float z, float _x, float _y, float _z)
        {
            RWAPI.write_line_in_file("./data/Blip/GarageData.txt", JsonConvert.SerializeObject(new Synchronization.GarageJson() { id = id, from = new Vector3(x, y, z), to = new Vector3(_x, _y, _z), state = state }));
        }

        [Command("update_garage_shop")]
        [RemoteEvent("update_garage_shop")]
        public void update_barber(Client client)
        {
            List<Synchronization.GarageJson> list = new List<Synchronization.GarageJson>();
            string[] lines;
            using (StreamReader sr = File.OpenText("./data/Blip/GarageData.txt"))
            {
                lines = File.ReadAllLines("./data/Blip/GarageData.txt");
                sr.Close();
            }
            foreach (string line in lines)
            {
                Synchronization.GarageJson tmp = JsonConvert.DeserializeObject<Synchronization.GarageJson>(line);
                list.Add(tmp);
            }
            if (list.Count > 0)
                client.TriggerEvent("UpdateListGarageJson", JsonConvert.SerializeObject(list));
        }
    }*/
}
