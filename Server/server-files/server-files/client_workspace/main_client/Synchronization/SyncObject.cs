using System;
using System.Collections.Generic;
using System.Text;
//using Newtonsoft.Json;
using RAGE;
using RAGE.Elements;

namespace main_client.Synchronization
{
   /* 


    class SyncObject : Events.Script
    {
        public bool active = false;
        int timer = 0;
        string[] names = new string[2] { "v_club_officechair", "prop_off_chair_05" };

        public SyncObject() {
            Events.OnEntityStreamIn += OnEntityStreamIn;
            Events.OnEntityStreamOut += OnEntityStreamOut;
            Events.OnPlayerQuit += OnPlayerQuit;
            Events.Add("WorldObjectStreamUpdate", WorldObjectStreamUpdate);
            Events.Tick += Tick;
        }

        //RAGE.Game.Entity.AttachEntityToEntity(RAGE.Elements.Player.LocalPlayer.Handle, obj, 0, 0, 0, 0.4f, 0, 0, 0, false, true, false, true, 0, true);
        //RAGE.Game.Entity.FreezeEntityPosition(obj, true);
        //Events.CallRemote("StartBAnimation", "amb@prop_human_seat_chair_mp@male@generic@base", "base", 1f);

        public struct Test
        {
            public int id { get; set; }
        }

        private void Tick(List<Events.TickNametagData> nametags)
        {
            /*foreach (string name in names)
            {
                int obj = RAGE.Game.Object.GetClosestObjectOfType(RAGE.Elements.Player.LocalPlayer.Position.X, RAGE.Elements.Player.LocalPlayer.Position.Y, RAGE.Elements.Player.LocalPlayer.Position.Z, 2f, RAGE.Game.Misc.GetHashKey(name), false, false, false);
                if (obj != 0)
                {
                    RAGE.Game.Entity.FreezeEntityPosition(obj, true);
                    RAGE.Game.Graphics.DrawBox(RAGE.Game.Entity.GetEntityCoords(obj, true).X - 0.05f, RAGE.Game.Entity.GetEntityCoords(obj, true).Y - 0.05f, RAGE.Game.Entity.GetEntityCoords(obj, true).Z - 0.05f + 0.5f, RAGE.Game.Entity.GetEntityCoords(obj, true).X + 0.05f, RAGE.Game.Entity.GetEntityCoords(obj, true).Y + 0.05f, RAGE.Game.Entity.GetEntityCoords(obj, true).Z + 0.05f + 0.5f, 255, 255, 255, 100);
                    break;
                }
            }
            /*if (RAGE.Input.IsDown((int)ConsoleKey.J) && timer == 0)
            {
                if (active == false)
                    foreach (string name in names)
                    {
                        int obj = RAGE.Game.Object.GetClosestObjectOfType(RAGE.Elements.Player.LocalPlayer.Position.X, RAGE.Elements.Player.LocalPlayer.Position.Y, RAGE.Elements.Player.LocalPlayer.Position.Z, 2f, RAGE.Game.Misc.GetHashKey(name), false, false, false);
                        if (obj != 0)
                        {
                            ModelSync sync = new ModelSync(RAGE.Elements.Player.LocalPlayer);
                            ObjectModelSync objectSync = new ObjectModelSync() { seat = 1, RemoteID = RAGE.Elements.Player.LocalPlayer.RemoteId, LocalID = obj, x = RAGE.Game.Entity.GetEntityCoords(obj, true).X, y = RAGE.Game.Entity.GetEntityCoords(obj, true).Y, z = RAGE.Game.Entity.GetEntityCoords(obj, true).Z, rx = RAGE.Game.Entity.GetEntityRotation(obj, 1).X, ry = RAGE.Game.Entity.GetEntityRotation(obj, 1).Y, rz = RAGE.Game.Entity.GetEntityRotation(obj, 1).Z };
                            sync.SeatObject(objectSync);
                            Events.CallRemote("StartBAnimation", "amb@prop_human_seat_chair_mp@male@generic@base", "base", 1f);
                            active = true;
                            break;
                        }
                    }
                else if (active) {
                    foreach (string name in names)
                    {
                        int obj = RAGE.Game.Object.GetClosestObjectOfType(RAGE.Elements.Player.LocalPlayer.Position.X, RAGE.Elements.Player.LocalPlayer.Position.Y, RAGE.Elements.Player.LocalPlayer.Position.Z, 2f, RAGE.Game.Misc.GetHashKey(name), false, false, false);
                        if (obj != 0)
                        {
                            ModelSync sync = new ModelSync(RAGE.Elements.Player.LocalPlayer);
                            ObjectModelSync objectSync = new ObjectModelSync() { seat = 0, RemoteID = RAGE.Elements.Player.LocalPlayer.RemoteId, LocalID = obj, x = RAGE.Game.Entity.GetEntityCoords(obj, true).X, y = RAGE.Game.Entity.GetEntityCoords(obj, true).Y, z = RAGE.Game.Entity.GetEntityCoords(obj, true).Z, rx = RAGE.Game.Entity.GetEntityRotation(obj, 1).X, ry = RAGE.Game.Entity.GetEntityRotation(obj, 1).Y, rz = RAGE.Game.Entity.GetEntityRotation(obj, 1).Z };
                            Events.CallRemote("StartBAnimation", "amb@prop_human_seat_chair@male@generic@exit", "exit_forward", 0.5f);
                            sync.SeatObject(objectSync);
                            Utils.ThreadingTask.make_task_with_timeout(() => {
                                Events.CallRemote("StopAnimation");
                            }, 2000);
                            
                            active = false;
                            break;
                        }
                    }
                }
                timer++;
            }
            else if (RAGE.Input.IsDown((int)ConsoleKey.D0) && timer == 0)
            {
                RAGE.Elements.Player.LocalPlayer.Position = new Vector3(-31.46478f, -1112.632f, 26.42235f);
                timer++;
            }
            else if (timer != 0 && timer <= 300)
                timer++;
            else if (timer >= 300)
                timer = 0;
        }

        private void OnPlayerQuit(RAGE.Elements.Player player)
        {
            ObjectModelSync data = player.GetData<ObjectModelSync>("SeatObject");

            if (data == null)
                return;
        }

        private void WorldObjectStreamUpdate(object[] args)
        {
            ushort remoteID = Convert.ToUInt16(args[0]);
            RAGE.Elements.Player player = Entities.Players.GetAtRemote(remoteID);
            ModelSync data = player.GetData<ModelSync>("WorldObject");
            
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            ModelSync result = JsonConvert.DeserializeObject<ModelSync>(args[1].ToString(), settings);
            if (data == null)
            {
                //Chat.Output("Obj " + result.objects.Count.ToString());
                ModelSync sync = new ModelSync(player);
                sync.objects = result.objects;
                //Chat.Output("Obj " + result.objects.Count.ToString());
                foreach (var obj in sync.objects)
                {
                    Chat.Output("StreamIn " + obj.ToString());
                    obj.StreamIn();
                }
                return;
            }
            data.objects = result.objects;
            foreach (var obj in data.objects)
            {
                Chat.Output("StreamIn " + obj.ToString());
                obj.StreamIn();
            }
        }

        private void OnEntityStreamIn(Entity entity)
        {
            if (entity.Type != RAGE.Elements.Type.Player)
                return;

            var jsonData = entity.GetSharedData("WorldObjectStream");

            if (jsonData == null)
                return;

            Chat.Output("Passage  A");
            var result = JsonConvert.DeserializeObject<ModelSync>(jsonData.ToString());
            var entityData = entity.GetData<ModelSync>("WorldObject");
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
    
    public class ModelSync {

        public List<ObjectModelSync> objects = new List<ObjectModelSync>();

        public ModelSync() {}
        public ModelSync(RAGE.Elements.Player player)
        {
            player.SetData("WorldObject", this);
        }
        
        public void SeatObject(ObjectModelSync syncObject)
        {
            objects.Add(syncObject);
            UpdateData();
        }

        public void UnSeatObject(ObjectModelSync syncObject)
        {
            if (!objects.Contains(syncObject))
                return;
            objects.Remove(syncObject);
            UpdateData();
        }

        public void UpdateData()
        {
            Events.CallRemote("UpdateWorldObject", JsonConvert.SerializeObject(this));
        }
    }


    public class ObjectModelSync
    {
        public bool isLocal { get; set; }
        public bool isFreeze { get; set; }
        public int RemoteID { get; set; }
        public int LocalID { get; set; }
        public int Dimensions { get; set; }
        public int seat { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
        public double rx { get; set; }
        public double ry { get; set; }
        public double rz { get; set; }

        public ObjectModelSync() { }
        public ObjectModelSync(RAGE.Elements.Player player, int LocalID, float x, float y, float z, float rx, float ry, float rz, bool isLocal = true, bool isFreeze = true) {
            this.RemoteID = player.RemoteId;
            this.LocalID = LocalID;
            this.x = x;
            this.y = y;
            this.z = z;
            this.rx = rx;
            this.ry = ry;
            this.rz = rz;
            this.isFreeze = isFreeze;
            this.isLocal = isLocal;
            this.Dimensions = 0;
        }

        public void StreamIn()
        {
            RAGE.Elements.Player target = Entities.Players.All.Find(x => x.RemoteId == RemoteID);
            
            if (target == null)
                return;
            Chat.Output("Local " + LocalID);
            if (seat == 1)
            {
                if (new Vector3((float)x, (float)y, (float)z).DistanceTo(RAGE.Elements.Player.LocalPlayer.Position) < 20f)
                {
                    int new_obj = RAGE.Game.Object.GetClosestObjectOfType((float)x, (float)y, (float)z, 1, RAGE.Game.Misc.GetHashKey("prop_off_chair_05"), false, false, false);
                    RAGE.Game.Entity.FreezeEntityPosition(new_obj, isFreeze);
                    RAGE.Game.Entity.SetEntityCoords(new_obj, (float)x, (float)this.y, (float)this.z, false, false, false, false);
                    RAGE.Game.Entity.SetEntityRotation(new_obj, (float)rx, (float)ry, (float)rz, 1, false);
                    RAGE.Game.Entity.AttachEntityToEntity(target.Handle, new_obj, 0, 0, 0, 0.4f, 0, 0, RAGE.Game.Entity.GetEntityRotation(new_obj, 0).Z + 180, false, false, false, true, 0, false);
                }
            } else if (seat == 0) {
                RAGE.Game.Entity.DetachEntity(target.Handle, false, false);
                Vector3 a = RAGE.Game.Entity.GetEntityCoords(target.Handle, true);
                Vector3 b = a.Around(0.5f);
                RAGE.Game.Entity.SetEntityCoords(target.Handle, b.X, b.Y, b.Z, false, false, false, false);
            }
        }
        
    }*/

}
