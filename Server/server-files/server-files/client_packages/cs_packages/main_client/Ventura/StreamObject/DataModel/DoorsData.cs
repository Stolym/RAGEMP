using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace main_client.Ventura.StreamObject.DataModel
{
    [JsonObject]
    class DoorsData
    {
        public int Hashcode { get; set; }
        public string Name { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float State { get; set; }
        public bool IsLock { get; set; }
    }
}
