using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using GTANetworkAPI;
using Newtonsoft.Json;
//using RWAPI = main.Database.ReaderWriter.ReaderWriter;

namespace main.Ventura.Engine.Shop
{
    /*class BarberShop : Script
    {

        [Command("create_barber_shop")]
        public void create_barber(Client client, int id, int state, float x, float y, float z, float _x, float _y, float _z)
        {
            RWAPI.write_line_in_file("./data/Blip/BarberData.txt", JsonConvert.SerializeObject(new Synchronization.BarberShopJson() { id = id, from = new Vector3(x, y, z), to = new Vector3(_x, _y, _z), state = state }));
        }

        [Command("update_barber_shop")]
        [RemoteEvent("update_barber_shop")]
        public void update_barber(Client client)
        {
            List<Synchronization.BarberShopJson> list = new List<Synchronization.BarberShopJson>();
            string[] lines;
            using (StreamReader sr = File.OpenText("./data/Blip/BarberData.txt"))
            {
                lines = File.ReadAllLines("./data/Blip/BarberData.txt");
                sr.Close();
            }
            foreach (string line in lines)
            {
                Synchronization.BarberShopJson tmp = JsonConvert.DeserializeObject<Synchronization.BarberShopJson>(line);
                list.Add(tmp);
            }
            if (list.Count > 0)
                client.TriggerEvent("UpdateListBarberShopJson", JsonConvert.SerializeObject(list));
        }
    }*/
}