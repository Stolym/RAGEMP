using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RAGE;

namespace main_client.Ventura.StreamObject.WorldData
{
    [JsonObject]
    class WorldPedData : Events.Script
    {
        public int Handle { get; set; }
        public int Hashcode { get; set; }
        public int PedType { get; set; }

        public uint HashcodeModel { get; set; }
        public int LocalId { get; set; }

        public float nx { get; set; }
        public float ny { get; set; }
        public float nz { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
        public float heading { get; set; }

        [JsonIgnore]
        int Refresh { get; set; }

        [JsonIgnore]
        Vector3 TaskNav { get; set; }
        [JsonIgnore]
        Vector3 SyncTaskNav { get; set; }


        public static WorldPedData operator + (WorldPedData obj, WorldPedData n) {

            if (obj == null)
                obj = new WorldPedData();
            obj.Handle = n.Handle;
            obj.Hashcode = n.Hashcode;
            obj.x = n.x;
            obj.y = n.y;
            obj.z = n.z;
            obj.nx = n.nx;
            obj.ny = n.ny;
            obj.nz = n.nz;
            obj.HashcodeModel = n.HashcodeModel;
            obj.heading = n.heading;
            obj.PedType = n.PedType;
            obj.LocalId = 0;
            return obj;
        }

        public void StreamIn(string SharedDataJson)
        {
            WorldPedData Stream = JsonConvert.DeserializeObject<WorldPedData>(SharedDataJson);

            PreConfiguration();
            if (Stream == null)
                return;
            if (LocalId == 0)
                CreateNewPed();
            PostConfiguration(Stream);
            Synchronization(Stream);
            SetRandomTask();
            OnTick();
        }

        private void OnTick()
        {
            if (LocalId != 0)
            {
                Vector3 Coords = RAGE.Game.Entity.GetEntityCoords(LocalId, true);
                heading = RAGE.Game.Entity.GetEntityHeading(LocalId);
                x = Coords.X;
                y = Coords.Y;
                z = Coords.Z;
                if (RAGE.Game.Entity.GetEntitySpeed(LocalId) == 0)
                {
                    Refresh++;
                    RAGE.Game.Ai.TaskGoToCoordAnyMeans(LocalId, nx, ny, z, .7f, 0, true, 786603, 0xbf800000);
                }
                if (Coords.DistanceTo(new Vector3(nx, ny, nz)) < 10f || Refresh == 5)
                {
                    nx = 0;
                    ny = 0;
                    nz = 0;
                    Refresh = 0;
                    RAGE.Game.Ai.ClearPedSecondaryTask(LocalId);

                }
                /*int ray = RAGE.Game.Shapetest.StartShapeTestRay(x, y, z, x + 2, y + 2, z, 1, 0, 1);
                int hit = 0;
                int a = 0;
                RAGE.Game.Shapetest.GetShapeTestResult(ray, ref a, new Vector3(), new Vector3(), ref hit);
                if (hit != 0)
                {
                    RAGE.Game.Graphics.DrawLine(x, y, z, x + 2, y + 2, z, 0, 0, 255, 255);
                    nx = 0;
                    ny = 0;
                    nz = 0;
                    RAGE.Game.Ai.ClearPedSecondaryTask(LocalId);
                }
                else
                    RAGE.Game.Graphics.DrawLine(x, y, z, x + 2, y + 2, z, 255, 0, 0, 255);

                ray = RAGE.Game.Shapetest.StartShapeTestRay(x, y, z, x - 2, y - 2, z, 1, 0, 1);
                RAGE.Game.Shapetest.GetShapeTestResult(ray, ref a, new Vector3(), new Vector3(), ref hit);
                if (hit != 0)
                {
                    RAGE.Game.Graphics.DrawLine(x, y, z, x - 2, y - 2, z, 0, 0, 255, 255);
                    nx = 0;
                    ny = 0;
                    nz = 0;
                    RAGE.Game.Ai.ClearPedSecondaryTask(LocalId);
                }
                else
                    RAGE.Game.Graphics.DrawLine(x, y, z, x - 2, y - 2, z, 255, 0, 0, 255);

                ray = RAGE.Game.Shapetest.StartShapeTestRay(x, y, z, x, y - 2, z, 1, 0, 1);
                RAGE.Game.Shapetest.GetShapeTestResult(ray, ref a, new Vector3(), new Vector3(), ref hit);
                if (hit != 0)
                {
                    RAGE.Game.Graphics.DrawLine(x, y, z, x, y - 2, z, 0, 0, 255, 255);
                    nx = 0;
                    ny = 0;
                    nz = 0;
                    RAGE.Game.Ai.ClearPedSecondaryTask(LocalId);
                }
                else
                    RAGE.Game.Graphics.DrawLine(x, y, z, x, y - 2, z, 255, 0, 0, 255);


                ray = RAGE.Game.Shapetest.StartShapeTestRay(x, y, z, x - 2, y, z, 1, 0, 1);
                RAGE.Game.Shapetest.GetShapeTestResult(ray, ref a, new Vector3(), new Vector3(), ref hit);
                if (hit != 0)
                {
                    RAGE.Game.Graphics.DrawLine(x, y, z, x - 2, y, z, 0, 0, 255, 255);

                    nx = 0;
                    ny = 0;
                    nz = 0;
                    RAGE.Game.Ai.ClearPedSecondaryTask(LocalId);
                }
                else
                    RAGE.Game.Graphics.DrawLine(x, y, z, x - 2, y, z, 255, 0, 0, 255);


                ray = RAGE.Game.Shapetest.StartShapeTestRay(x, y, z, x + 2, y, z, 1, 0, 1);
                RAGE.Game.Shapetest.GetShapeTestResult(ray, ref a, new Vector3(), new Vector3(), ref hit);
                if (hit != 0)
                {
                    RAGE.Game.Graphics.DrawLine(x, y, z, x + 2, y, z, 0, 0, 255, 255);

                    nx = 0;
                    ny = 0;
                    nz = 0;
                    RAGE.Game.Ai.ClearPedSecondaryTask(LocalId);
                }
                else
                    RAGE.Game.Graphics.DrawLine(x, y, z, x + 2, y, z, 255, 0, 0, 255);

                ray = RAGE.Game.Shapetest.StartShapeTestRay(x, y, z, x, y + 2, z, 1, 0, 1);
                RAGE.Game.Shapetest.GetShapeTestResult(ray, ref a, new Vector3(), new Vector3(), ref hit);
                if (hit != 0)
                {
                    RAGE.Game.Graphics.DrawLine(x, y, z, x, y + 2, z, 0, 0, 255, 255);

                    nx = 0;
                    ny = 0;
                    nz = 0;
                    RAGE.Game.Ai.ClearPedSecondaryTask(LocalId);

                }
                else
                    RAGE.Game.Graphics.DrawLine(x, y, z, x, y + 2, z, 255, 0, 0, 255);*/
                UpdateSharedData();

            }
        }

        public void StreamOut() {
            int shared = LocalId;

            if (Handle == RAGE.Elements.Player.LocalPlayer.Handle)
            {
                Handle = -1;
                WorldPedData ptr = null;
                ptr = ptr + this;
                StreamData.StreamPedData.PedSharedData[StreamData.StreamPedData.PedSharedData.FindIndex(x => x.Hashcode == ptr.Hashcode)] = ptr;
                Events.CallRemote("StreamPedSharedData", JsonConvert.SerializeObject(StreamData.StreamPedData.PedSharedData));
            }
            if (shared != 0) {
                RAGE.Game.Entity.SetEntityCoords(shared, 0, 0, 0, false, false, false, true);
                RAGE.Game.Ped.DeletePed(ref shared);

                //RAGE.Game.Entity.DeleteEntity(ref shared);
                LocalId = 0;
            }


        }

        private void PostConfiguration(WorldPedData stream)
        {
            TaskNav.X = nx;
            TaskNav.Y = ny;
            TaskNav.Z = nz;
            SyncTaskNav.X = stream.nx;
            SyncTaskNav.Y = stream.ny;
            SyncTaskNav.Z = stream.nz;
        }

        private void PreConfiguration()
        {
            if (TaskNav == null)
                TaskNav = new Vector3(0, 0, 0);
            if (SyncTaskNav == null)
                SyncTaskNav = new Vector3(0, 0, 0);
            
        }

        private void Synchronization(WorldPedData stream)
        {

            RAGE.Game.Entity.SetEntityHealth(LocalId, 100);

            Chat.Output("Syncronisation " + stream.x + " " + stream.y + " " + stream.z + " ");
            Chat.Output("FF " + RAGE.Game.Entity.GetEntityCoords(LocalId, true));
            Chat.Output("PED " + new Vector3(x, y, z));
            if (new Vector3(stream.x, stream.y, stream.z).DistanceTo(new Vector3(x, y, z)) > 2f) //!RAGE.Game.Entity.IsEntityAtCoord(LocalId, stream.x, stream.y, stream.z, 2, 2, 2, false, true, 0))
            {
                x = stream.x;
                y = stream.y;
                z = stream.z;
                RAGE.Game.Ai.ClearPedSecondaryTask(LocalId);
                //Chat.Output(LocalId.ToString());
                RAGE.Game.Entity.SetEntityCoords(LocalId, stream.x, stream.y, stream.z, false, false, false, true);
            }
            else if (TaskNav.DistanceTo(SyncTaskNav) > 1f)
            {
                nx = stream.nx;
                ny = stream.ny;
                nz = stream.nz;
                RAGE.Game.Ai.ClearPedSecondaryTask(LocalId);
            }
            else if (heading - stream.heading > 5f ||
                heading - stream.heading < -5f) {
                heading = stream.heading;
                RAGE.Game.Ai.ClearPedSecondaryTask(LocalId);
            }
        }


        private void SetRandomTask()
        {
            if (nx == 0 && ny == 0 && nz == 0)
            {
                Vector3 vect = new RAGE.Vector3(x, y, z).Around(100f);
                nx = vect.X;
                ny = vect.Y;
                nz = vect.Z;
                RAGE.Game.Ai.ClearPedSecondaryTask(LocalId);
                //Chat.Output("Task Set " + nx + " " + ny + " " + nz + " ");
                UpdateSharedData();
            }
        }

        private void UpdateSharedData()
        {
            if (Handle == RAGE.Elements.Player.LocalPlayer.Handle)
            {
                Chat.Output("Sender");
                WorldPedData ptr = null;
                ptr = ptr + this;
                ptr.Handle = StreamData.StreamPedData.PedSharedData[StreamData.StreamPedData.PedSharedData.FindIndex(x => x.Hashcode == ptr.Hashcode)].Handle;
                StreamData.StreamPedData.PedSharedData[StreamData.StreamPedData.PedSharedData.FindIndex(x => x.Hashcode == ptr.Hashcode)] = ptr;
                Events.CallRemote("StreamPedSharedData", JsonConvert.SerializeObject(StreamData.StreamPedData.PedSharedData));
            } if (Handle == -1)
            {
                Handle = RAGE.Elements.Player.LocalPlayer.Handle;
                WorldPedData ptr = null;
                ptr = ptr + this;
                StreamData.StreamPedData.PedSharedData[StreamData.StreamPedData.PedSharedData.FindIndex(x => x.Hashcode == ptr.Hashcode)] = ptr;
                Events.CallRemote("StreamPedSharedData", JsonConvert.SerializeObject(StreamData.StreamPedData.PedSharedData));
            }
        }

        private void CreateNewPed()
        {
            LocalId = RAGE.Game.Ped.CreatePed(PedType, HashcodeModel, x, y, z, heading, false, false);
            if (LocalId == 0)
            {
                LocalId = new RAGE.Elements.Ped(HashcodeModel, new Vector3(x, y, z), heading).Handle;
                int test = LocalId;
                RAGE.Game.Entity.SetEntityCoords(test, 0, 0, 0, true, true, true, true);
                RAGE.Game.Ped.DeletePed(ref test);
                LocalId = 0;
            }

            //Chat.Output("LocalId " + LocalId + " "+ PedType + " "+HashcodeModel+ " "+x+" "+y+" "+heading);
        }
    }
}
