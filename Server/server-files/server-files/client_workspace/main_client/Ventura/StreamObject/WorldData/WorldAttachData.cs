using System;
using System.Collections.Generic;
using System.Text;
using main_client.Ventura.StreamObject.DataModel;
//using ZeroFormatter;
using Newtonsoft.Json;

namespace main_client.Ventura.StreamObject.WorldData
{
    /*    [ZeroFormattable]
        public class WorldAttachData : IDataModel
        {
            [Index(0)]
            public virtual int ID { get; set; }
            [Index(1)]
            public virtual string Name { get; set; }
            [Index(2)]
            public virtual int LocalId { get; set; }
            [Index(3)]
            public virtual ushort RemoteId { get; set; }
            [Index(4)]
            public virtual int Dimensions { get; set; }
            [Index(5)]
            public virtual main_client.Ventura.Constant.Constant.UpdateFlagsClient Type { get; set; }
            [Index(6)]
            public virtual int Bone { get; set; }
            [Index(7)]
            public virtual bool IsDynamic { get; set; }
            [Index(8)]
            public virtual bool IsNetwork { get; set; }
            [Index(9)]
            public virtual ZFVector3 Position { get; set; }
            [Index(10)]
            public virtual ZFVector3 Rotation { get; set; }
            [Index(11)]
            public virtual bool P9 { get; set; }
            [Index(12)]
            public virtual bool UseSoftPinning { get; set; }
            [Index(13)]
            public virtual bool Collision { get; set; }
            [Index(14)]
            public virtual bool IsPed { get; set; }
            [Index(15)]
            public virtual int VertexIndex { get; set; }
            [Index(16)]
            public virtual bool LockRotation { get; set; }
            [Index(17)]
            public virtual uint Hashcode { get; set; }
            [Index(18)]
            public virtual bool IsFakeObject { get; set; }

            public WorldAttachData() { }
            public WorldAttachData(RAGE.Elements.Entity entity, string name, int bone, float x, float y, float z, float rx, float ry, float rz)
            {
                Name = name;
                Bone = bone;
                RemoteId = entity.RemoteId;
                Dimensions = Convert.ToInt32(entity.Dimension);
                Position = new ZFVector3(x, y, z);
                Rotation = new ZFVector3(rx, ry, rz);
                ID = 0;
                Name = "";
                LocalId = 0;
                IsDynamic = false;
                Type = Ventura.Constant.Constant.UpdateFlagsClient.WorldAttachData;
                IsDynamic = false;
                IsNetwork = true;
                P9 = false;
                UseSoftPinning = false;
                IsPed = false;
                Collision = false;
                LockRotation = false;
            }

            public void StreamIn()
            {
                RAGE.Elements.Player target = RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == RemoteId);

                if (target == null || target.Handle == 0)
                    return;

                /*
                 * Multiple Attach Object
                 * 
                 * 
                 * 

                LocalId = RAGE.Game.Object.CreateObject(RAGE.Game.Misc.GetHashKey(Name), Position.x, Position.y, Position.z, IsNetwork, false, IsDynamic);
                RAGE.Game.Entity.AttachEntityToEntity(LocalId, target.Handle, Bone, Position.x, Position.y, Position.z, Rotation.x, Rotation.y, Rotation.z, P9, UseSoftPinning, Collision, IsPed, VertexIndex, LockRotation);
            }

            public void StreamOut()
            {
                RAGE.Elements.Player target = RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == RemoteId);

                if (target == null || (target.Handle == 0 && LocalId == 0))
                    return;
                RAGE.Game.Entity.DetachEntity(target.Handle, true, true);
                int ptr = LocalId;
                RAGE.Game.Entity.DeleteEntity(ref ptr);
                LocalId = 0;
            }
        }*/
        
    [JsonObject]
    public class WorldAttachData : DataModel.DataModel
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int LocalId { get; set; }
        public virtual int RemoteId { get; set; }
        public virtual uint Dimensions { get; set; }
        public virtual main_client.Ventura.Constant.Constant.UpdateFlagsClient Type { get; set; }
        public virtual int Bone { get; set; }
        public virtual bool IsAttached { get; set; }
        public virtual bool IsDynamic { get; set; }
        public virtual bool IsNetwork { get; set; }
        public virtual Vector3 Position { get; set; }
        public virtual Vector3 Rotation { get; set; }
        public virtual bool P9 { get; set; }
        public virtual bool UseSoftPinning { get; set; }
        public virtual bool Collision { get; set; }
        public virtual bool IsPed { get; set; }
        public virtual int VertexIndex { get; set; }
        public virtual bool LockRotation { get; set; }
        public virtual int Hashcode { get; set; }
        public virtual bool IsFakeObject { get; set; }

        [JsonIgnore]
        private string data_name = main_client.Ventura.Constant.Constant.table_data_name[((int)main_client.Ventura.Constant.Constant.UpdateFlagsClient.WorldAttachData >> 2) - 1];


        public WorldAttachData() { }
        public WorldAttachData(RAGE.Elements.Entity entity, string name, int bone, float x, float y, float z, float rx, float ry, float rz)
        {
            Name = name;
            Bone = bone;
            RemoteId = entity.RemoteId;
            Dimensions = entity.Dimension;
            Position = new Vector3(x, y, z);
            Rotation = new Vector3(rx, ry, rz);
            Id = 0;
            Name = "";
            LocalId = 0;
            IsDynamic = false;
            Type = Ventura.Constant.Constant.UpdateFlagsClient.WorldAttachData;
            IsDynamic = false;
            IsNetwork = true;
            P9 = false;
            UseSoftPinning = false;
            IsPed = false;
            Collision = false;
            LockRotation = false;
        }

        public void StreamIn()
        {
            RAGE.Elements.Player target = RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == RemoteId);


            //RAGE.Chat.Output("Passage target " + target.Name + " " + RemoteId + " " + RAGE.Elements.Player.LocalPlayer.Name + " " + RAGE.Elements.Player.LocalPlayer.RemoteId);

            if (target == null || target.Handle == 0)
                return;

            //RAGE.Chat.Output(target.Name + " " + Dimensions.ToString() + " " + LocalId + " !");
            if (!IsAttached && target.GetData<string>(data_name) != null) {
                var data = JsonConvert.DeserializeObject<List<WorldAttachData>>(target.GetData<string>(data_name));
                for (int i = 0; i < data.Count; i++) {
                    if (data[i].Id == Id && data[i].LocalId != 0 && data[i].IsAttached) {
                        data[i].StreamOut();
                    }
                }
            }
            else if (!IsAttached)
                return;

            if (LocalId == 0)
            {
                //RAGE.Chat.Output(target.Name + " " + Dimensions.ToString() + " " + LocalId + " !");
                LocalId = new RAGE.Elements.MapObject(RAGE.Game.Misc.GetHashKey(Name), target.Position, new RAGE.Vector3(), 255, Dimensions).Handle;
            }
            if (!RAGE.Game.Entity.IsEntityAttachedToEntity(LocalId, target.Handle))
                RAGE.Game.Entity.AttachEntityToEntity(LocalId, target.Handle, target.GetBoneIndex(Bone), Position.x, Position.y, Position.z, Rotation.x, Rotation.y, Rotation.z, P9, UseSoftPinning, Collision, IsPed, VertexIndex, LockRotation);
        }

        public void StreamOut()
        {
            RAGE.Elements.Player target = RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == RemoteId);

            if (target == null || (target.Handle == 0 && LocalId == 0))
                return;
            RAGE.Game.Entity.DetachEntity(target.Handle, true, true);
            int ptr = LocalId;
            RAGE.Game.Entity.DeleteEntity(ref ptr);
            LocalId = 0;
        }
    }
}
