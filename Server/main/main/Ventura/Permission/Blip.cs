using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using GTANetworkAPI;
//using RWAPI = main.Database.ReaderWriter.ReaderWriter;

namespace main.Ventura.Permission
{
    class Blip : Script
    {
        public struct BlipJson
        {
            public uint id { get; set; }
            public byte color { get; set; }
            public string name { get; set; }
            public float x { get; set; }
            public float y { get; set; }
            public float z { get; set; }
            public float scale { get; set; }
        }

        public struct MarkerJson
        {
            public uint id { get; set; }
            public float x { get; set; }
            public float y { get; set; }
            public float z { get; set; }
            public float scale { get; set; }
            public int r { get; set; }
            public int g { get; set; }
            public int b { get; set; }
        }

        public List<BlipJson> list_blip = new List<BlipJson>();

        [ServerEvent(Event.ResourceStart)]
        public void resourceStart()
        {
            string[] lines;
            using (StreamReader sr = File.OpenText("./data/Blip/BlipData.txt"))
            {
                lines = File.ReadAllLines("./data/Blip/BlipData.txt");
                sr.Close();
            }
            foreach (string line in lines)
            {
                BlipJson blip = JsonConvert.DeserializeObject<BlipJson>(line);
                NAPI.Blip.CreateBlip(blip.id, new Vector3(blip.x, blip.y, blip.z), blip.scale, blip.color, blip.name);
            }
        }

        [ServerEvent(Event.ResourceStart)]
        public void resourcesStart()
        {
            string[] lines;
            using (StreamReader sr = File.OpenText("./data/Blip/MarkerData.txt"))
            {
                lines = File.ReadAllLines("./data/Blip/MarkerData.txt");
                sr.Close();
            }
            foreach (string line in lines)
            {
                MarkerJson blip = JsonConvert.DeserializeObject<MarkerJson>(line);
                NAPI.Marker.CreateMarker(blip.id, new Vector3(blip.x, blip.y, blip.z), new Vector3(), new Vector3(), blip.scale, new Color(blip.r, blip.g, blip.b));
            }
        }

        /*
        !/set_blip_size size
        !/set_blip_remove remove
        !/set_blip_color color
        !/set_blip_model model

        !/set_marker_model model
        !/set_marker_size size
        !/set_marker_color color
        !/set_marker_remove remove
        !/set_fonctionipl_enter
        !/set_fonctionipl_out
        

        [Command("set_blip_size")]
        public void set_blip_size(Client client, float scale)
        {
            foreach (GTANetworkAPI.Blip blip in NAPI.Pools.GetAllBlips())
            {
                if (blip.Position.DistanceTo(client.Position) < 10f)
                {
                    blip.Scale = scale;
                }
            }
        }

        [Command("set_blip_color")]
        public void set_blip_color(Client client, int color)
        {
            foreach (GTANetworkAPI.Blip blip in NAPI.Pools.GetAllBlips())
            {
                if (blip.Position.DistanceTo(client.Position) < 10f)
                {
                    blip.Color = color;
                }
            }
        }

        [Command("blip")]
        public void create_blip(Client client, uint id, byte color, float scale, string name)
        {
            NAPI.Blip.CreateBlip(id, new Vector3(client.Position.X, client.Position.Y, client.Position.Z), scale, color, name);
            RWAPI.write_line_in_file("./data/Blip/BlipData.txt", JsonConvert.SerializeObject(new BlipJson { id = id, color = color, name = name, x = client.Position.X, y = client.Position.Y, z = client.Position.Z, scale = scale }));
        }

        [Command("marker")]
        public void create_blip(Client client, uint id, float scale, int r, int g, int b)
        {
            NAPI.Marker.CreateMarker(id, client.Position, new Vector3(), new Vector3(), scale, new Color(r, g, b));
            RWAPI.write_line_in_file("./data/Blip/MarkerData.txt", JsonConvert.SerializeObject(new MarkerJson { id = id, x = client.Position.X, y = client.Position.Y, z = client.Position.Z, scale = scale, r = r, b = b, g = g }));
        }
    }*/
    }
}
