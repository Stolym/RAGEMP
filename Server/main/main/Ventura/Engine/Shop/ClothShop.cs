using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using GTANetworkAPI;
using Newtonsoft.Json;
//using RWAPI = main.Database.ReaderWriter.ReaderWriter;

namespace main.Ventura.Engine.Shop
{
    /*class ClothShop : Script
    {

        [Command("create_cloth_shop")]
        public void create_cloth(Client client, int id, int state, float x, float y, float z, float _x, float _y, float _z) {
            RWAPI.write_line_in_file("./data/Blip/ClothData.txt", JsonConvert.SerializeObject(new Synchronization.ClothShop(id, new Vector3(x, y, z), new Vector3(_x, _y, _z), state)));
        }

        [Command("update_cloth_shop")]
        [RemoteEvent("update_cloth_shop")]
        public void update_cloth(Client client) {
            List<Synchronization.ClothShop> list = new List<Synchronization.ClothShop>();
            string[] lines;
            using (StreamReader sr = File.OpenText("./data/Blip/ClothData.txt"))
            {
                lines = File.ReadAllLines("./data/Blip/ClothData.txt");
                sr.Close();
            }
            foreach (string line in lines)
            {
                Synchronization.ClothShop tmp = JsonConvert.DeserializeObject<Synchronization.ClothShop>(line);
                list.Add(tmp);
            }
            if (list.Count > 0)
                client.TriggerEvent("UpdateListClothShop", JsonConvert.SerializeObject(list));
        }
    }*/
}
