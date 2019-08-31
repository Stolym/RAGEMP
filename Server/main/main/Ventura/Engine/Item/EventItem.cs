using System;
using System.Collections.Generic;
using System.Text;
using DUSER = main.Ventura.Database.DataUser;
using LAPI = main.Ventura.Gestion.LogGestion;
using CGAPI = main.Ventura.Gestion.CharacterGestion;
using FAPI = main.Ventura.Database.Formatter.Formatter;
using DAPI = main.Ventura.Gestion.DimensionGestion;
using ASAPI = main.Ventura.Stream.Async.Event.AsyncEvent;

using GTANetworkAPI;

namespace main.Ventura.Engine.Item
{

    /* Delegate Event */

    public delegate void Use(Iitem obj, DUSER user);
    public delegate void Drop(Iitem obj);
    public delegate void Give(dynamic obj, ushort RemoteId);
    
    class EventItem
    {
        public static void UseNormaly(Iitem obj, DUSER user)
        {

        }

        public static void DropNormaly(Iitem obj)
        {


        }

        public static void GiveNormaly(dynamic obj, ushort RemoteId)
        {

        }

        public static void UseBurger(Iitem obj, DUSER user)
        {
            Client client = NAPI.Pools.GetAllPlayers().Find(x => x.SocialClubName == user.user.social);

            if (client == null)
                return;



            Synchronization.StreamGestionAsync.instance.UltimeAsync(client, FAPI.SerializeObjectJson<List<Stream.StreamData.WorldAttachData>>(new List<Stream.StreamData.WorldAttachData>() { new Stream.StreamData.WorldAttachData()
            {
                Name = obj.ModelName,
                Type = user.attaches[0].Type,
                Bone = 60309,
                Dimensions = client.Dimension,
                RemoteId = client.Handle.Value,
                IsNetwork = user.attaches[0].IsNetwork,
                IsDynamic = user.attaches[0].IsDynamic,
                Position = user.attaches[0].Position,
                Rotation = user.attaches[0].Rotation,
                VertexIndex = 2,
                P9 = false,
                UseSoftPinning = false,
                IsPed = false,
                Collision = false,
                LockRotation = true,
                IsAttached = true,
            } }), Ventura.Constant.Constants.StreamFlags.StreamIn, Ventura.Constant.Constants.UpdateFlags.WorldAttachData, 0, client.Dimension);

            Synchronization.StreamGestionAsync.instance.UltimeAsync(client, FAPI.SerializeObjectJson<Stream.StreamData.WorldAnimationData>(new Stream.StreamData.WorldAnimationData()
            {
                IsActive = true,
                Dict = "mp_player_inteat@burger",
                Anim = "mp_player_int_eat_burger_enter",
                Speed = 1f,
                SpeedMultiplier = 4f,
                Id = 0,
                Name = "",
                RemoteId = client.Handle.Value,
                Dimensions = client.Dimension,
                Type = 0,
                Flags = (int)(Ventura.Constant.Constants.AnimationFlags.Loop | Ventura.Constant.Constants.AnimationFlags.AllowPlayerControl | Ventura.Constant.Constants.AnimationFlags.OnlyAnimateUpperBody),
                Duration = -1,
                LockX = false,
                LockY = false,
                LockZ = false,
                Playback = 0,
                tick = DateTime.Now.AddHours(1).AddMilliseconds(300).Ticks,
                next = new Stream.StreamData.WorldAnimationData()
                {
                    IsActive = true,
                    Dict = "mp_player_inteat@burger",
                    Anim = "mp_player_int_eat_burger",
                    Speed = 1f,
                    SpeedMultiplier = 4f,
                    Id = 1,
                    Name = "",
                    RemoteId = client.Handle.Value,
                    Dimensions = client.Dimension,
                    Type = 0,
                    Flags = (int)(Ventura.Constant.Constants.AnimationFlags.Loop | Ventura.Constant.Constants.AnimationFlags.AllowPlayerControl | Ventura.Constant.Constants.AnimationFlags.OnlyAnimateUpperBody),
                    Duration = -1,
                    LockX = false,
                    LockY = false,
                    LockZ = false,
                    Playback = 0,
                    tick = DateTime.Now.AddHours(1).AddSeconds(8).Ticks,
                    next = new Stream.StreamData.WorldAnimationData()
                    {
                        IsActive = true,
                        Dict = "mp_player_inteat@burger",
                        Anim = "mp_player_int_eat_exit_burger",
                        Speed = 1f,
                        SpeedMultiplier = 4f,
                        Id = 2,
                        Name = "",
                        RemoteId = client.Handle.Value,
                        Dimensions = client.Dimension,
                        Type = 0,
                        Flags = (int)(Ventura.Constant.Constants.AnimationFlags.Loop | Ventura.Constant.Constants.AnimationFlags.AllowPlayerControl | Ventura.Constant.Constants.AnimationFlags.OnlyAnimateUpperBody),
                        Duration = -1,
                        LockX = false,
                        LockY = false,
                        LockZ = false,
                        Playback = 0,
                        tick = DateTime.Now.AddHours(1).AddSeconds(8).AddMilliseconds(300).Ticks,
                        next = null,
                    },
                },
            }), Ventura.Constant.Constants.StreamFlags.StreamIn, Ventura.Constant.Constants.UpdateFlags.WorldAnimationData, 0, client.Dimension);

        }
        public static void UseWaterBottle(Iitem obj, DUSER user)
        {
            Client client = NAPI.Pools.GetAllPlayers().Find(x => x.SocialClubName == user.user.social);

            if (client == null)
                return;

            Synchronization.StreamGestionAsync.instance.UltimeAsync(client, FAPI.SerializeObjectJson<List<Stream.StreamData.WorldAttachData>>(new List<Stream.StreamData.WorldAttachData>() { new Stream.StreamData.WorldAttachData()
            {
                Name = obj.ModelName,
                Type = user.attaches[0].Type,
                Bone = 60309,
                Dimensions = client.Dimension,
                RemoteId = client.Handle.Value,
                IsNetwork = user.attaches[0].IsNetwork,
                IsDynamic = user.attaches[0].IsDynamic,
                Position = user.attaches[0].Position,
                Rotation = user.attaches[0].Rotation,
                VertexIndex = 2,
                P9 = false,
                UseSoftPinning = false,
                IsPed = false,
                Collision = false,
                LockRotation = true,
                IsAttached = true,
            } }), Ventura.Constant.Constants.StreamFlags.StreamIn, Ventura.Constant.Constants.UpdateFlags.WorldAttachData, 0, client.Dimension);

            Synchronization.StreamGestionAsync.instance.UltimeAsync(client, FAPI.SerializeObjectJson<Stream.StreamData.WorldAnimationData>(new Stream.StreamData.WorldAnimationData()
            {
                IsActive = true,
                Dict = "mp_player_intdrink",
                Anim = "intro_bottle",
                Speed = 1f,
                SpeedMultiplier = 4f,
                Id = 0,
                Name = "",
                RemoteId = client.Handle.Value,
                Dimensions = client.Dimension,
                Type = 0,
                Flags = (int)(Ventura.Constant.Constants.AnimationFlags.Loop | Ventura.Constant.Constants.AnimationFlags.AllowPlayerControl | Ventura.Constant.Constants.AnimationFlags.OnlyAnimateUpperBody),
                Duration = -1,
                LockX = false,
                LockY = false,
                LockZ = false,
                Playback = 0,
                tick = DateTime.Now.AddHours(1).AddMilliseconds(300).Ticks,
                next = new Stream.StreamData.WorldAnimationData()
                {
                    IsActive = true,
                    Dict = "mp_player_intdrink",
                    Anim = "loop_bottle_fp",
                    Speed = 1f,
                    SpeedMultiplier = 4f,
                    Id = 1,
                    Name = "",
                    RemoteId = client.Handle.Value,
                    Dimensions = client.Dimension,
                    Type = 0,
                    Flags = (int)(Ventura.Constant.Constants.AnimationFlags.Loop | Ventura.Constant.Constants.AnimationFlags.AllowPlayerControl | Ventura.Constant.Constants.AnimationFlags.OnlyAnimateUpperBody),
                    Duration = -1,
                    LockX = false,
                    LockY = false,
                    LockZ = false,
                    Playback = 0,
                    tick = DateTime.Now.AddHours(1).AddSeconds(8).Ticks,
                    next = new Stream.StreamData.WorldAnimationData() {
                        IsActive = true,
                        Dict = "mp_player_intdrink",
                        Anim = "outro_bottle_fp",
                        Speed = 1f,
                        SpeedMultiplier = 4f,
                        Id = 2,
                        Name = "",
                        RemoteId = client.Handle.Value,
                        Dimensions = client.Dimension,
                        Type = 0,
                        Flags = (int)(Ventura.Constant.Constants.AnimationFlags.Loop | Ventura.Constant.Constants.AnimationFlags.AllowPlayerControl | Ventura.Constant.Constants.AnimationFlags.OnlyAnimateUpperBody),
                        Duration = -1,
                        LockX = false,
                        LockY = false,
                        LockZ = false,
                        Playback = 0,
                        tick = DateTime.Now.AddHours(1).AddSeconds(8).AddMilliseconds(300).Ticks,
                        next = null,
                    },
                },
            }), Ventura.Constant.Constants.StreamFlags.StreamIn, Ventura.Constant.Constants.UpdateFlags.WorldAnimationData, 0, client.Dimension);

        }
    }
}
