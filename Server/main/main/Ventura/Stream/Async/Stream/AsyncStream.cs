using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GTANetworkAPI;
using main.Ventura.Constant;
using FAPI = main.Ventura.Database.Formatter.Formatter;
using CGAPI = main.Ventura.Gestion.CharacterGestion;
using DUSER = main.Ventura.Database.DataUser;
using main.Ventura.Stream;

namespace main.Ventura.Stream.Async.Stream
{
    class AsyncStream : Script
    {
        /*
         * I making function who she take good event call with async method
         * 
         * */
        public static AsyncStream instance { get; set; }
        /*
         * 
         * 
         * 
         * 
         * */
        public AsyncStream()
        {
            if (instance == null)
                instance = this;
        }


        void AllTriggerEvent(Entity entity, string ename, string dname, string data)
        {
            foreach (Client client in NAPI.Pools.GetAllPlayers())
            {
                try
                {
                    //NAPI.Util.ConsoleOutput("Event " + ename + " " + dname + " " + client.SocialClubName);
                    //NAPI.ClientEvent.TriggerClientEvent(client, ename, entity.Handle.Value, data);
                    client.TriggerEvent(ename, entity.Handle.Value, data);
                }
                catch (Exception ex)
                {
                    NAPI.Util.ConsoleOutput(ex.Message + " 1");
                }
            }
        }

        void RangeTriggerEvent(Entity entity, string ename, string dname, string data, int range)
        {
            foreach (Client client in NAPI.Pools.GetAllPlayers())
            {
                if (client.Position.DistanceTo(entity.Position) < range)
                {
                    try
                    {
                        client.TriggerEvent(ename, entity.Handle.Value, data);
                    }
                    catch (Exception ex)
                    {
                        NAPI.Util.ConsoleOutput(ex.Message + " 2");
                    }

                }
            }
        }

        void DimensionTriggerEvent(Entity entity, string ename, string dname, string data, uint dimension)
        {
            foreach (Client client in NAPI.Pools.GetAllPlayers())
            {
                if (client.Dimension == dimension)
                {
                    try
                    {
                        client.TriggerEvent(ename, entity.Handle.Value, data);
                    }
                    catch (Exception ex)
                    {
                        NAPI.Util.ConsoleOutput(ex.Message + " 3");
                    }
                }
            }
        }

        public void StreamIn(Entity entity, string ename, string dname, string data)
        {
            //if (entity.Type == EntityType.Player)
            //    NAPI.Util.ConsoleOutput("StreamIn " + entity.Type + " "+((Client)entity).SocialClubName);

            entity.SetSharedData(dname, data);
            AllTriggerEvent(entity, ename, dname, data);
        }

        void StreamOut(Entity entity, string ename, string dname)
        {
            entity.SetSharedData(dname, "null");
            AllTriggerEvent(entity, ename, dname, null);
        }

        void StreamAsyncIn(Entity entity, string ename, string dname, string data)
        {
            entity.SetSharedData(ename, data);
        }

        void StreamAsyncOut(Entity entity, string ename, string dname, string data)
        {
            entity.SetSharedData(ename, data);
        }

        void StreamDimensionsIn(Entity entity, string ename, string dname, string data, uint dimension)
        {
            entity.SetSharedData(dname, data);
            DimensionTriggerEvent(entity, ename, dname, data, dimension);
        }
        void StreamDimensionOut(Entity entity, string ename, string dname, uint dimension)
        {
            entity.SetSharedData(ename, "null");
            DimensionTriggerEvent(entity, ename, dname, null, dimension);
        }

        void StreamRangeIn(Entity entity, string ename, string dname, string data, int range)
        {
            entity.SetSharedData(ename, data);
            RangeTriggerEvent(entity, ename, dname, null, range);
        }
        void StreamRangeOut(Entity entity, string ename, string dname, int range)
        {
            entity.SetSharedData(ename, "null");
            RangeTriggerEvent(entity, ename, dname, null, range);
        }

        // Stream Sync
        public void AllStreamManager(Entity entity)
        {
            Client player = (Client)entity;
            DUSER data = CGAPI.GetDataPlayer(player);

            if (data == null)
            {
                player.Kick();
                return;
            }
            /*AUltimeAsync(entity, main.Synchronization.StreamGestionAsync.instance.table[0], FAPI.SerializeObjectJson<StreamData.WorldAnimationData>(new StreamData.WorldAnimationData() {
                IsActive = data.anim.IsActive,
                Dict = data.anim.Dict,
                Anim = data.anim.Anim,
                Speed = data.anim.Speed,
                SpeedMultiplier = data.anim.SpeedMultiplier,
                ID = data.anim.ID,
                Name = data.anim.Name,
                RemoteId = player.Handle.Value,
                Dimensions = Convert.ToInt32(player.Dimension),
                Type = data.anim.Type,
                Flags = data.anim.Flags,
                Duration = data.anim.Duration,
                LockX = data.anim.LockX,
                LockY = data.anim.LockY,
                LockZ = data.anim.LockZ,
                Playback = data.anim.Playback,
            }), Constant.Constants.StreamFlags.StreamIn, 100, data.user.dimension).GetAwaiter();
            AUltimeAsync(entity, main.Synchronization.StreamGestionAsync.instance.table[1], FAPI.SerializeObjectJson<StreamData.WorldAttachData>(new StreamData.WorldAttachData()
            {
                Type = data.attach.Type,
                Bone = data.attach.Bone,
                IsNetwork = data.attach.IsNetwork,
                IsDynamic = data.attach.IsDynamic,
                Position = data.attach.Position,
                Rotation = data.attach.Rotation,
                P9 = data.attach.P9,
                UseSoftPinning = data.attach.UseSoftPinning,
                IsPed = data.attach.IsPed,
                Collision = data.attach.Collision,
                LockRotation = data.attach.LockRotation,
            }), Constant.Constants.StreamFlags.StreamIn, 100, data.user.dimension).GetAwaiter();

            AUltimeAsync(entity, main.Synchronization.StreamGestionAsync.instance.table[2], FAPI.SerializeObjectJson<StreamData.WorldClothData>(new StreamData.WorldClothData() {
                Id = 0,
                Name = "",
                LocalId = 0,
                RemoteId = player.Handle.Value,
                Type = Constants.UpdateFlags.WorldClothData,
                Dimensions = Convert.ToInt32(player.Dimension),
                cloth = data.cloth.body_cloth,
                IsService = data.user.service,
            }), Constant.Constants.StreamFlags.StreamIn, 100, data.user.dimension).GetAwaiter();
            AUltimeAsync(entity, main.Synchronization.StreamGestionAsync.instance.table[3], FAPI.SerializeObjectJson<StreamData.WorldSceneData>(new StreamData.WorldSceneData() {
                ID = 0,
                Name = "",
                LocalId = 0,
                RemoteId = data.scene.RemoteId,
                Type = Constants.UpdateFlags.WorldSceneData,
                Anim = data.scene.Anim,
                Dict = data.scene.Dict,
                IsActive = data.scene.IsActive,
                Duration = data.scene.Duration,
                Flags = data.scene.Flags,
                LockX = data.scene.LockX,
                LockY = data.scene.LockY,
                LockZ = data.scene.LockZ,
                SceneOrigin = new StreamData.ZFVector3(data.scene.SceneOrigin.x, data.scene.SceneOrigin.y, data.scene.SceneOrigin.z),
                SceneRotation = new StreamData.ZFVector3(data.scene.SceneRotation.x, data.scene.SceneRotation.y, data.scene.SceneRotation.z),
                Bone = data.scene.Bone,
                Playback = data.scene.Playback
            }), Constant.Constants.StreamFlags.StreamIn, 100, data.user.dimension).GetAwaiter();*/
            //AUltimeAsync(entity, main.Synchronization.StreamGestionAsync.instance.table[4], FAPI.SerializeObject<dynamic>(null), Constant.Constants.StreamFlags.StreamIn, 100, data.user.dimension).GetAwaiter();
            //AUltimeAsync(entity, main.Synchronization.StreamGestionAsync.instance.table[5], FAPI.SerializeObject<dynamic>(null), Constant.Constants.StreamFlags.StreamIn, 100, data.user.dimension).GetAwaiter();
            //AUltimeAsync(entity, main.Synchronization.StreamGestionAsync.instance.table[6], FAPI.SerializeObject<dynamic>(null), Constant.Constants.StreamFlags.StreamIn, 100, data.user.dimension).GetAwaiter();
            //AUltimeAsync(entity, main.Synchronization.StreamGestionAsync.instance.table[7], FAPI.SerializeObject<dynamic>(null), Constant.Constants.StreamFlags.StreamIn, 100, data.user.dimension).GetAwaiter();
            //AUltimeAsync(entity, main.Synchronization.StreamGestionAsync.instance.table[8], FAPI.SerializeObject<dynamic>(null), Constant.Constants.StreamFlags.StreamIn, 100, data.user.dimension).GetAwaiter();
            return;
        }



        public async Task<bool> AUltimeAsync(Entity entity, string ename, string dname, string data, Constant.Constants.StreamFlags stream, int range = 0, uint dimension = 0)
        {
            bool ret = true;
            try
            {
                switch (stream)
                {
                    case Constant.Constants.StreamFlags.StreamIn:
                        StreamIn(entity, ename, dname, data);
                        break;
                    case Constant.Constants.StreamFlags.StreamOut:
                        StreamOut(entity, ename, dname);
                        break;
                    case Constant.Constants.StreamFlags.StreamRangeIn:
                        StreamRangeIn(entity, ename, dname, data, range);
                        break;
                    case Constant.Constants.StreamFlags.StreamRangeOut:
                        StreamRangeOut(entity, ename, dname, range);
                        break;
                    case Constant.Constants.StreamFlags.StreamDimensionsIn:
                        StreamDimensionsIn(entity, ename, dname, data, dimension);
                        break;
                    case Constant.Constants.StreamFlags.StreamDimensionOut:
                        StreamDimensionOut(entity, ename, dname, dimension);
                        break;
                }
            }
            catch (Exception exp)
            {
                NAPI.Util.ConsoleOutput(exp.Message);
                ret = false;
            }
            return ret;
        }

        public bool ASUltimeAsync(Entity entity, string ename, string dname, string data, Constant.Constants.StreamFlags stream, int range = 0, uint dimension = 0)
        {
            bool ret = true;
            try
            {
                switch (stream)
                {
                    case Constant.Constants.StreamFlags.StreamIn:
                        StreamIn(entity, ename, dname, data);
                        break;
                    case Constant.Constants.StreamFlags.StreamOut:
                        StreamOut(entity, ename, dname);
                        break;
                    case Constant.Constants.StreamFlags.StreamRangeIn:
                        StreamRangeIn(entity, ename, dname, data, range);
                        break;
                    case Constant.Constants.StreamFlags.StreamRangeOut:
                        StreamRangeOut(entity, ename, dname, range);
                        break;
                    case Constant.Constants.StreamFlags.StreamDimensionsIn:
                        StreamDimensionsIn(entity, ename, dname, data, dimension);
                        break;
                    case Constant.Constants.StreamFlags.StreamDimensionOut:
                        StreamDimensionOut(entity, ename, dname, dimension);
                        break;
                }
            }
            catch (Exception exp)
            {
                NAPI.Util.ConsoleOutput(exp.Message);
                ret = false;
            }
            return ret;
        }


    }
}
