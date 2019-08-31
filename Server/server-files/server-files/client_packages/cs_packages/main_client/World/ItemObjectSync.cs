using System;
using System.Collections.Generic;
using System.Text;
//using Newtonsoft.Json;
using RAGE;
using RAGE.Elements;


namespace main_client.World
{
    /*class ItemObjectSync
    {
        class SyncObject : Events.Script
        {

            public bool active = false;
            int timer = 0;
            public ModelSync sync = new ModelSync(RAGE.Elements.Player.LocalPlayer);

            public SyncObject()
            {
                Events.OnEntityStreamIn += OnEntityStreamIn;
                Events.OnEntityStreamOut += OnEntityStreamOut;
                Events.OnPlayerQuit += OnPlayerQuit;
                Events.Add("WorldItemObjectStreamUpdate", WorldItemObjectStreamUpdate);
                Events.Add("AddObjectWorld", AddObjectWorld);
                Events.Tick += Tick;
            }

            private void AddObjectWorld(object[] args)
            {
                string name = (string)args[0];
                Vector3 pos = JsonConvert.DeserializeObject<Vector3>((string)args[1]);
                sync.AddItemObject(new ObjectModelSync(RAGE.Elements.Player.LocalPlayer, name, pos.X, pos.Y, pos.Z, 0, 0, 0));
            }
            
            private void Tick(List<Events.TickNametagData> nametags)
            {
                
                /*if (RAGE.Input.IsDown((int)ConsoleKey.J) && timer == 0)
                {
                    AddObjectWorld(new object[] { "prop_police_id_board", JsonConvert.SerializeObject(RAGE.Elements.Player.LocalPlayer.Position) });
                    timer++;
                }
                else if (RAGE.Input.IsDown((int)ConsoleKey.D9) && timer == 0)
                {
                    RAGE.Elements.Player.LocalPlayer.Position = new Vector3(-315.8532f, -2743.785f, 5.857146f);
                    timer++;
                }
                else if (timer != 0 && timer <= 300)
                    timer++;
                else if (timer >= 300)
                    timer = 0;
            }

            private void OnPlayerQuit(RAGE.Elements.Player player)
            {
                ObjectModelSync data = player.GetData<ObjectModelSync>("WorldItemObject");

                if (data == null)
                    return;
            }

            private void WorldItemObjectStreamUpdate(object[] args)
            {
                ushort remoteID = Convert.ToUInt16(args[0]);
                RAGE.Elements.Player player = Entities.Players.GetAtRemote(remoteID);
                ModelSync data = player.GetData<ModelSync>("WorldItemObject");

                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                ModelSync result = JsonConvert.DeserializeObject<ModelSync>(args[1].ToString(), settings);
                if (data == null)
                {
                    ModelSync sync = new ModelSync(player);
                    sync.objects = result.objects;
                    foreach (var obj in sync.objects)
                    {
                        obj.StreamIn();
                    }
                    return;
                }
                data.objects = result.objects;
                foreach (var obj in data.objects)
                {
                    obj.StreamIn();
                }
            }

            private void OnEntityStreamIn(Entity entity)
            {
                //Chat.Output("Stream in " + entity.Type);
                if (entity.Type != RAGE.Elements.Type.Player)
                    return;

                var jsonData = entity.GetSharedData("WorldItemObjectStream");

                if (jsonData == null)
                    return;

                var result = JsonConvert.DeserializeObject<ModelSync>(jsonData.ToString());
                var entityData = entity.GetData<ModelSync>("WorldItemObject");
                if (entityData != null)
                {
                    entityData.objects = result.objects;
                }
                else
                {
                    ModelSync sync = new ModelSync(entity as RAGE.Elements.Player);
                    sync.objects = result.objects;
                }
                foreach (var obj in result.objects)
                    obj.StreamIn();
            }


            private void OnEntityStreamOut(Entity entity)
            {

            }

            private void CreateObjectDimensionsWorld(object[] args)
            {

            }
        }

        public class ModelSync
        {

            public List<ObjectModelSync> objects = new List<ObjectModelSync>();

            public ModelSync() { }
            public ModelSync(RAGE.Elements.Player player)
            {
                player.SetData("WorldItemObject", this);
            }

            public void AddItemObject(ObjectModelSync syncObject)
            {
                objects.Add(syncObject);
                UpdateData();
            }

            public void RemoveItemObject(ObjectModelSync syncObject)
            {
                if (!objects.Contains(syncObject))
                    return;
                objects.Remove(syncObject);
                UpdateData();
            }

            public void UpdateData()
            {
                Events.CallRemote("UpdateWorldItemObject", JsonConvert.SerializeObject(this));
            }
        }


        public class ObjectModelSync
        {
            public bool isLocal { get; set; }
            public bool isFreeze { get; set; }
            public int RemoteID { get; set; }
            public int LocalID { get; set; }
            public int Dimensions { get; set; }
            public double x { get; set; }
            public double y { get; set; }
            public double z { get; set; }
            public double rx { get; set; }
            public double ry { get; set; }
            public double rz { get; set; }
            public int id { get; set; }
            public int stock { get; set; }
            public string name { get; set; }

            public ObjectModelSync() { }
            public ObjectModelSync(RAGE.Elements.Player player, string name, float x, float y, float z, float rx, float ry, float rz, bool isLocal = true, bool isFreeze = true)
            {
                this.name = name;
                this.RemoteID = player.RemoteId;
                this.x = x;
                this.y = y;
                this.z = z;
                this.rx = rx;
                this.ry = ry;
                this.rz = rz;
                this.isFreeze = isFreeze;
                this.isLocal = isLocal;
                this.Dimensions = 0;
                LocalID = 0;
            }

            public void StreamIn()
            {
                RAGE.Elements.Player target = Entities.Players.All.Find(x => x.RemoteId == RemoteID);

                if (target == null)
                    return;
                LocalID = RAGE.Game.Object.CreateObject(RAGE.Game.Misc.GetHashKey(name), (float)x, (float)y, (float)z, false, false, true);
            }

        }
    }*/
}
