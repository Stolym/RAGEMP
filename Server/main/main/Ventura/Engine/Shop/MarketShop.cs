using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using GTANetworkAPI;
using Newtonsoft.Json;
//using RWAPI = main.Database.ReaderWriter.ReaderWriter;

namespace main.Ventura.Engine.Shop
{
    /*class MarketShop : Script
    {
        [Command("create_market_shop")]
        public void create_market(Client client, int id, int state, float x, float y, float z, float _x, float _y, float _z)
        {
            RWAPI.write_line_in_file("./data/Blip/MarketData.txt", JsonConvert.SerializeObject(new Synchronization.MarketShopJson() { id = id, from =  new Vector3(x, y, z), to =  new Vector3(_x, _y, _z), state = state }));
        }

        [Command("update_market_shop")]
        [RemoteEvent("update_market_shop")]
        public void update_market(Client client)
        {
            List<Synchronization.MarketShopJson> list = new List<Synchronization.MarketShopJson>();
            string[] lines;
            using (StreamReader sr = File.OpenText("./data/Blip/MarketData.txt"))
            {
                lines = File.ReadAllLines("./data/Blip/MarketData.txt");
                sr.Close();
            }
            foreach (string line in lines)
            {
                NAPI.Util.ConsoleOutput(line);
                Synchronization.MarketShopJson tmp = JsonConvert.DeserializeObject<Synchronization.MarketShopJson>(line);
                list.Add(tmp);
            }
            if (list.Count > 0)
                client.TriggerEvent("UpdateListMarketShopJson", JsonConvert.SerializeObject(list));
        }
    }*/
}
