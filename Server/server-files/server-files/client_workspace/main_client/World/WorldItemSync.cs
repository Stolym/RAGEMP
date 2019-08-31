using System;
using System.Collections.Generic;
using System.Text;
//using Newtonsoft.Json;
using RAGE;

namespace main_client.World
{
    /*class WorldItemSync : Events.Script
    {
        int timer = 0;
        public float max = 1f;
        public bool active = false;
        public static List<WorldObjectSync> list_world_object = new List<WorldObjectSync>();
        public static List<WorldObjectSync> current_world_object = new List<WorldObjectSync>();
        
        public WorldItemSync() {
            Events.Add("ActiveWorld", ActiveWorld);
            Events.Add("UpdateListWorldItem", UpdateListWorldItem);
            Events.Tick += Tick;
        }

        private void ActiveWorld(object[] args)
        {
            Chat.Output("Boolean " + (bool)args[0]);
           active = (bool)args[0];
        }

        private void UpdateListWorldItem(object[] args)
        {
            if (args.Length == 1)
            {
                string json = args[0].ToString();
                try
                {
                    var data = JsonConvert.DeserializeObject<List<WorldObjectSync>>(json);
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
            Chat.Output("List ");
            foreach (var item in list_world_object)
            {
                Chat.Output("Output " + item.name);
            }
        }

        private void StreamInItemObject(WorldObjectSync item) {
            int local = RAGE.Game.Object.CreateObject(RAGE.Game.Misc.GetHashKey(item.name), item.x, item.y, item.z, true, true, true);
            RAGE.Game.Entity.FreezeEntityPosition(local, false);
            RAGE.Game.Entity.SetEntityHasGravity(local, true);
            RAGE.Game.Entity.SetEntityCollision(local, true, false);
            RAGE.Game.Entity.SetEntityDynamic(local, true);
            RAGE.Game.Entity.SetEntityLoadCollisionFlag(local, true, 0);
            //RAGE.Game.Object.SetObjectPhysicsParams(local, 10, 0, -9.81f, 0, 0, 0, 0, 0, 0, 0, 0);
            item.LocalId = local;
            current_world_object.Add(item);
        }

        public static void StreamOutGetItemObject(WorldObjectSync item)
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

        private void StreamOutItemObject(WorldObjectSync item)
        {
            int obj = item.LocalId;
            RAGE.Game.Entity.SetEntityCoords(obj, 0, 0, 0, false, false, false, false);
            RAGE.Game.Entity.DeleteEntity(ref obj);
            RAGE.Game.Object.DeleteObject(ref obj);
            current_world_object.Remove(item);
        }

        WorldObjectSync get_object_closest()
        {
            WorldObjectSync tmp = null;
            foreach (var citem in current_world_object)
            {
                if (RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(new Vector3(citem.x, citem.y, citem.z)) < max)
                {
                    tmp = citem;
                    max = new Vector3(citem.x, citem.y, citem.z).DistanceTo(RAGE.Elements.Player.LocalPlayer.Position);
                }
            }
            max = 1f;
            return tmp;
        }

        private void Tick(List<Events.TickNametagData> nametags)
        {
            if (list_world_object.Count != 0) {
                foreach (var item in list_world_object)
                {
                    var citem = current_world_object.Find(x => x.Id == item.Id);
                    if (citem == null && RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(new Vector3(item.x, item.y, item.z)) < 20f)
                        StreamInItemObject(item);
                }
            }
            WorldObjectSync delete = null;
            foreach (var citem in current_world_object)
            {
                var tmp = list_world_object.Find(x => x.Id == citem.Id);
                if (tmp == null)
                    StreamOutItemObject(citem);
                if (citem.LocalId != 0 && RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(new Vector3(citem.x, citem.y, citem.z)) < 20f)
                {
                    Vector3 pos = RAGE.Game.Entity.GetEntityCoords(citem.LocalId, true);
                    //RAGE.Game.Graphics.DrawBox(pos.X, pos.Y, pos.Z, pos.X + 0.2f, pos.Y + 0.2f, pos.Z + 0.2f, 0, 0, 0, 255);
                }
                else if (citem.LocalId != 0 && RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(new Vector3(citem.x, citem.y, citem.z)) > 20f)
                {
                    delete = citem;
                }
            }
            if (delete != null)
                StreamOutItemObject(delete);

            if (active && timer == 0)
            {
                var tmp = get_object_closest();
                if (tmp == null)
                    return;
                StreamOutGetItemObject(tmp);
                active = false;
                timer++;
            }
            if (timer != 0 && timer <= 20)
                timer++;
            if (timer == 20)
                timer = 0;
        }
    }

    public class WorldObjectSync
    {
        public string name { get; set; }
        public int Id { get; set; }
        public int LocalId { get; set; }
        public int Dimensions { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
        public float rx { get; set; }
        public float ry { get; set; }
        public float rz { get; set; }
    }*/
}
