using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RAGE;
using A = RAGE.Elements;
using main_client.Ventura.StreamObject.DataModel;
using main_client.Ventura.StreamObject.WorldData;

namespace main_client.Ventura.StreamObject.StreamData
{
    class StreamPedData : Events.Script
    {
        public static StreamPedData instance { get; set; }
        long tick = 0;
        public float max = 1f;
        public bool active = false;
        public static List<WorldPedData> PedSharedData = new List<WorldPedData>();
        public static List<WorldPedData> PedData = new List<WorldPedData>();


        public StreamPedData() {
            instance = this;
            Events.Add("UpdatePedSharedData", UpdatePedSharedData);
        }

        private void UpdatePedSharedData(object[] args)
        {
            PedSharedData = JsonConvert.DeserializeObject<List<WorldPedData>>((string)args[0]);
            active = true;
        }

        public void OnTick() {
            SetClock(3);
            if (DateTime.Now.Ticks > tick && active) {
                UpdatePedData();
                _StreamPedData();
                tick = 0;
            }
        }

        private void _StreamPedData()
        {
            foreach (var cped in PedData) {
                var ped = PedData.Find(x => x.Hashcode == cped.Hashcode);
                if (ped == null)
                    StreamPedDataOut(cped);
                else if (RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(new RAGE.Vector3(cped.x, cped.y, cped.z)) > 200f)
                    StreamPedDataOut(cped);
                else
                    cped.StreamIn(JsonConvert.SerializeObject(ped));
            }
        }

        private void StreamPedDataOut(WorldPedData cped)
        {
            cped.StreamOut();
            PedData.Remove(cped);
        }

        private void UpdatePedData()
        {
            foreach (var ped in PedSharedData)
            {
                var cped = PedData.Find(x => x.Hashcode == ped.Hashcode);
                if (cped == null && RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(new RAGE.Vector3(ped.x, ped.y, ped.z)) < 200f)
                {
                    cped = cped + ped;
                    cped.StreamIn(JsonConvert.SerializeObject(ped));
                    PedData.Add(cped);
                }
            }
        }

        private void SetClock(int v)
        {
            if (tick == 0)
                tick = DateTime.Now.AddSeconds(v).Ticks;
        }
    }
}
