using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using Newtonsoft.Json;
using System.IO;

namespace main.Ventura.World
{
    class WorldDoorsManager : Script
    {
        public static WorldDoorsManager instance { get; set; }
        public List<Stream.StreamData.WorldDoorsData> Stream { get; set; }

        public WorldDoorsManager()
        {
            instance = this;
            Stream = null;
        }

        [ServerEvent(Event.ResourceStart)]
        public void resourceStart()
        {
            string[] lines;
            List<Stream.StreamData.WorldDoorsData> ListStreamed = new List<Stream.StreamData.WorldDoorsData>();

            using (StreamReader sr = File.OpenText("./data/Doors/doors.txt"))
            {
                lines = File.ReadAllLines("./data/Doors/doors.txt");
                sr.Close();
            }
            foreach (string line in lines)
            {
                ListStreamed.Add(JsonConvert.DeserializeObject<Stream.StreamData.WorldDoorsData>(line));
            }
            Stream = ListStreamed;
        }



        [RemoteEvent("GetDoorsList")]
        public void GetDoorsList(Client client)
        {
            client.TriggerEvent("StreamDoorsData", JsonConvert.SerializeObject(Stream));
        }

        [RemoteEvent("UpdateDoorsList")]
        public void UpdateDoorsList(Client client, string json)
        {
            List<Stream.StreamData.WorldDoorsData> ListStreamed = JsonConvert.DeserializeObject<List<Stream.StreamData.WorldDoorsData>>(json);

            if (ListStreamed == null)
                return;
            Stream = ListStreamed;
            Database.ReaderWriter.ReaderWriter.ClearFilePath("./data/Doors/doors.txt");
            for (int i = 0; i < Stream.Count; i++)
                Database.ReaderWriter.ReaderWriter.WriteLineinPath("./data/Doors/doors.txt", JsonConvert.SerializeObject(Stream[i]));
            NAPI.ClientEvent.TriggerClientEventForAll("StreamDoorsData", json);
        }

    }
}
