using System;
using System.Collections.Generic;
using System.Text;
using main_client.Ventura.StreamObject.DataModel;
using Newtonsoft.Json;
using RAGE;

namespace main_client.StreamObject.WorldData
{
    class WorldItemSync : Events.Script
    {
        long tick = 0;
        public float max = 1f;
        public bool active = false;
        public static List<WorldObjectData> list_world_object = new List<WorldObjectData>();
        public static List<WorldObjectData> current_world_object = new List<WorldObjectData>();

        public WorldItemSync()
        {
            Events.Add("ActiveWorld", ActiveWorld);
            Events.Add("UpdateListObjectWorld", UpdateListObjectWorld);
            Events.Tick += Tick;
        }

        private void ActiveWorld(object[] args)
        {
            Chat.Output("Boolean " + (bool)args[0]);
            active = (bool)args[0];
        }

        private void UpdateListObjectWorld(object[] args)
        {
            if (args.Length == 1)
            {
                string json = args[0].ToString();
                try
                {
                    var data = JsonConvert.DeserializeObject<List<WorldObjectData>>(json);
                    if (data == null)
                        return;
                    list_world_object = data;
                }
                catch (Exception ex)
                {
                    Chat.Output("Error StreamIn Object World");
                    Events.CallRemote("Error", 29, "this client cannot deserialize list object error :" + ex.Message);
                }
            }
        }

        private void StreamInItemObject(WorldObjectData item)
        {
            int local = RAGE.Game.Object.CreateObject(RAGE.Game.Misc.GetHashKey(item.Name), item.Position.x, item.Position.y, item.Position.z, true, true, true);
            RAGE.Game.Entity.FreezeEntityPosition(local, false);
            RAGE.Game.Entity.SetEntityHasGravity(local, true);
            RAGE.Game.Entity.SetEntityCollision(local, true, false);
            RAGE.Game.Entity.SetEntityDynamic(local, true);
            RAGE.Game.Entity.SetEntityLoadCollisionFlag(local, true, 0);
            //RAGE.Game.Object.SetObjectPhysicsParams(local, 10, 0, -9.81f, 0, 0, 0, 0, 0, 0, 0, 0);
            item.LocalId = local;
            current_world_object.Add(item);
        }

        public static void StreamOutGetItemObject(WorldObjectData item)
        {
            int obj = item.LocalId;
            RAGE.Game.Entity.SetEntityCoords(obj, 0, 0, 0, false, false, false, false);
            RAGE.Game.Entity.DeleteEntity(ref obj);
            RAGE.Game.Object.DeleteObject(ref obj);
            string json = null;
            try
            {
                json = JsonConvert.SerializeObject(item);
            }
            catch (Exception ex)
            {
                Events.CallRemote("Error", 30, "this client cannot deserialize list object error :" + ex.Message);
            }
            if (json == null)
                return;
            Events.CallRemote("GetWorldObject", json);
            list_world_object.Remove(item);
            current_world_object.Remove(item);
        }

        private void StreamOutItemObject(WorldObjectData item)
        {
            int obj = item.LocalId;
            RAGE.Game.Entity.SetEntityCoords(obj, 0, 0, 0, false, false, false, false);
            RAGE.Game.Entity.DeleteEntity(ref obj);
            RAGE.Game.Object.DeleteObject(ref obj);
            current_world_object.Remove(item);
        }

        WorldObjectData get_object_closest()
        {
            WorldObjectData tmp = null;
            foreach (var citem in current_world_object)
            {
                if (RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(new RAGE.Vector3(citem.Position.x, citem.Position.y, citem.Position.z)) < max)
                {
                    tmp = citem;
                    max = new RAGE.Vector3(citem.Position.x, citem.Position.y, citem.Position.z).DistanceTo(RAGE.Elements.Player.LocalPlayer.Position);
                }
            }
            max = 1f;
            return tmp;
        }

        void SetClock(double ms) {
            if (tick == 0)
                tick = DateTime.Now.AddMilliseconds(ms).Ticks;
        }


        private void Tick(List<Events.TickNametagData> nametags)
        {
            SetClock(300);
            if (list_world_object.Count != 0)
            {
                foreach (var item in list_world_object)
                {
                    var citem = current_world_object.Find(x => x.HashCode == item.HashCode);
                    if (citem == null && RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(new RAGE.Vector3(item.Position.x, item.Position.y, item.Position.z)) < 20f)
                        StreamInItemObject(item);
                }
            }
            WorldObjectData delete = null;
            foreach (var citem in current_world_object)
            {
                var tmp = list_world_object.Find(x => x.HashCode == citem.HashCode);
                if (tmp == null)
                    StreamOutItemObject(citem);
                if (citem.LocalId != 0 && RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(new RAGE.Vector3(citem.Position.x, citem.Position.y, citem.Position.z)) < 20f)
                {
                    RAGE.Vector3 pos = RAGE.Game.Entity.GetEntityCoords(citem.LocalId, true);
                    //RAGE.Game.Graphics.DrawBox(pos.X, pos.Y, pos.Z, pos.X + 0.2f, pos.Y + 0.2f, pos.Z + 0.2f, 0, 0, 0, 255);
                }
                else if (citem.LocalId != 0 && RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(new RAGE.Vector3(citem.Position.x, citem.Position.y, citem.Position.z)) > 20f)
                {
                    delete = citem;
                }
            }
            if (delete != null)
                StreamOutItemObject(delete);

            if (active && DateTime.Now.Ticks > tick)
            {
                var tmp = get_object_closest();
                if (tmp == null)
                    return;
                StreamOutGetItemObject(tmp);
                active = false;
                tick = 0;
            }
        }
    }


    class WorldObjectData
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int LocalId { get; set; }
        public virtual ushort RemoteId { get; set; }
        public virtual int Dimensions { get; set; }
        public bool IsActive { get; set; }
        public virtual main_client.Ventura.Constant.Constant.UpdateFlagsClient Type { get; set; }
        public virtual int ObjectType { get; set; }
        public virtual uint HashCode { get; set; }
        public virtual Ventura.StreamObject.DataModel.Vector3 Position { get; set; }
    }


        /*class WorldObjectData
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int LocalId { get; set; }
            public ushort RemoteId { get; set; }
            public int Dimensions { get; set; }
            public Utils.Constant.UpdateFlagsClient Type { get; set; }

            public WorldObjectData() { }
            public WorldObjectData(RAGE.Elements.Player player)
            {
                this.RemoteId = player.RemoteId;
            }

            public void StreamIn()
            {
                RAGE.Elements.Player target = RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == RemoteId);

                if (target == null || target.Handle == 0)
                    return;
            }

            public void StreamOut()
            {
                RAGE.Elements.Player target = RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == RemoteId);

                if (target == null || (target.Handle == 0 && LocalId == 0))
                    return;
            }
        }*/
    }
