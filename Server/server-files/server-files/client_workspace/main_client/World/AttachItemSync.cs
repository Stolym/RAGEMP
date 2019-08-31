using System;
using System.Collections.Generic;
using System.Text;
//using Newtonsoft.Json;
using RAGE;
namespace main_client.World
{
    /*class AttachItemSync
    {
       class SyncObject : Events.Script
        {

          

         
        }

        public class ObjectModelSync
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int LocalId { get; set; }
            public ushort RemoteId { get; set; }
            public int Dimensions { get; set; }
            public int Bone { get; set; }
            public bool isDynamic { get; set; }
            public bool isNetwork { get; set; }
            public float x { get; set; }
            public float y { get; set; }
            public float z { get; set; }
            public float rx { get; set; }
            public float ry { get; set; }
            public float rz { get; set; }

            public ObjectModelSync() { }
            public ObjectModelSync(RAGE.Elements.Player player, string name, int bone, float x, float y, float z, float rx, float ry, float rz)
            {
                this.Name = name;
                this.RemoteId = player.RemoteId;
                this.x = x;
                this.y = y;
                this.z = z;
                this.rx = rx;
                this.ry = ry;
                this.rz = rz;
                this.Dimensions = 0;
                LocalId = 0;
                Bone = bone;
                isDynamic = true;
                isNetwork = true;
            }

            public void StreamIn()
            {
                RAGE.Elements.Player target = RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == RemoteId);

                if (target == null)
                    return;
                LocalId = RAGE.Game.Object.CreateObject(RAGE.Game.Misc.GetHashKey(Name), (float)x, (float)y, (float)z, isNetwork, false, isDynamic);
                RAGE.Game.Entity.AttachEntityToEntity(LocalId, target.Handle, Bone, x, y, z, rx, ry, rz, false, true, true, true, 70, false);
            }

            public void StreamOut()
            {
                RAGE.Elements.Player target = RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == RemoteId);

                if (target == null)
                    return;
                RAGE.Game.Entity.DetachEntity(target.Handle, true, true);
            }
        }
    }*/
}
