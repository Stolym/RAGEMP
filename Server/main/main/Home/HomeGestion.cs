using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using GTANetworkAPI;
using Newtonsoft.Json;
//using RWAPI = main.Database.ReaderWriter.ReaderWriter;


namespace main.Home
{
    /*class HomeGestion : Script
    {

        [Command("create_home")]
        public void create_barber(Client client, int id, string interior, float x, float y, float z, float _x, float _y, float _z)
        {
            RWAPI.write_line_in_file("./data/Blip/HomeData.txt", JsonConvert.SerializeObject(new Synchronization.HabitationSync() { id = id, from = new Vector3(x, y, z), to = new Vector3(_x, _y, _z), interior_name = interior, owner = client.SocialClubName}));
        }

        [Command("update_home")]
        [RemoteEvent("update_home")]
        public void update_barber(Client client)
        {
            List<Synchronization.HabitationSync> list = new List<Synchronization.HabitationSync>();
            string[] lines;
            using (StreamReader sr = File.OpenText("./data/Blip/HomeData.txt"))
            {
                lines = File.ReadAllLines("./data/Blip/HomeData.txt");
                sr.Close();
            }
            foreach (string line in lines)
            {
                Synchronization.HabitationSync tmp = JsonConvert.DeserializeObject<Synchronization.HabitationSync>(line);
                list.Add(tmp);
            }
            if (list.Count > 0)
                client.TriggerEvent("UpdateListHome", JsonConvert.SerializeObject(list));
        }
    }*/
}
