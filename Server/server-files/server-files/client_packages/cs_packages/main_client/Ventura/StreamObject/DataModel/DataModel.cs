using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
//using ZeroFormatter;
using main_client.Ventura.Constant;


using main_client.StreamObject.WorldData;
using main_client.Ventura.Jobs.ListJobs;


namespace main_client.Ventura.StreamObject.DataModel
{
    /*   
   [Union(subTypes: new[] {
       typeof(WorldJobsActivityData),
       typeof(WorldAnimationData),
       typeof(WorldSceneData),
       typeof(WorldBodyData),
       typeof(WorldClothData),
       typeof(WorldVehicleData),
       typeof(WorldObjectData),
       typeof(WorldAttachData),
       typeof(WorldIdentityData),
       typeof(WorldUserData),
       typeof(WorldTattooData),
   })]
   public interface IDataModel
   {
       [Index(0)]
       int ID { get; set; }
       [Index(1)]
       string Name { get; set; }
       [Index(2)]
       int LocalId { get; set; }
       [Index(3)]
       ushort RemoteId { get; set; }
       [Index(4)]
       int Dimensions { get; set; }
       [Index(5)]
       bool IsActive { get; set; }
       [UnionKey]
       [Index(6)]
       Constant.UpdateFlagsClient Type { get; set; }
   }


   [ZeroFormattable]
   public class ZFVector3
   {

       [Index(0)]
       public float x { get; set; }

       [Index(1)]
       public float y { get; set; }

       [Index(2)]
       public float z { get; set; }

       public ZFVector3()
       {
           x = 0;
           y = 0;
           z = 0;
       }

       public ZFVector3(float x, float y, float z)
       {
           this.x = x;
           this.y = y;
           this.z = z;
       }
   }*/

    public class Vector3
    {
        
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }

        public Vector3()
        {
            x = 0;
            y = 0;
            z = 0;
        }

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }

    [JsonObject]
    public class DataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LocalId { get; set; }
        public int RemoteId { get; set; }
        public uint Dimensions { get; set; }
        public Constant.Constant.UpdateFlagsClient Type { get; set; }

        public DataModel() { }
    }
}
