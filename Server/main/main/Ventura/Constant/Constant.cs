using System;
using System.Collections.Generic;
using System.Text;

namespace main.Ventura.Constant
{
    public static class Constants
    {
        public static List<string> list_jobs = new List<string>()
        {
            "Name_a",
            "Name_b",
            "Name_c",
            "Name_d",
            "Name_c",
            "Name_d",
            "Name_c",
            "Name_d",
            "Name_c",
            "Name_d",
        };

        public static List<string> table = new List<string>()
        {
            "WorldJobsActivityData",
            "WorldAnimationData",
            "WorldSceneData",
            "WorldSeatData",
            "WorldBodyData",
            "WorldClothData",
            "WorldVehicleData",
            "WorldObjectData",
            "WorldAttachData",
            "WorldFightData",
            "WorldIdentityData",
            "WorldUserData",
            "WorldTattooData",
            "WorldRigidBodyData",
        };



        public static List<string> table_data_name = new List<string>()
        {
            "StreamJobsActivityData",
            "StreamAnimationData",
            "StreamSceneData",
            "StreamSeatData",
            "StreamBodyData",
            "StreamClothData",
            "StreamVehicleData",
            "StreamObjectData",
            "StreamAttachData",
            "StreamFightData",
            "StreamIdentityData",
            "StreamUserData",
            "StreamTattooData",
            "StreamRigidBodyData",
            "StreamDoorData",
        };
        public enum AnimationFlags
        {
            Loop = 1 << 0,
            StopOnLastFrame = 1 << 1,
            OnlyAnimateUpperBody = 1 << 4,
            AllowPlayerControl = 1 << 5,
            Cancellable = 1 << 7
        };

        /*
         * 
         * Stream flags
         * 
         * 
         * */

        public enum StreamFlags
        {
            StreamIn = 0x00,
            StreamOut = 0x01,
            StreamAsyncIn = 0x02,
            StreamAsyncOut = 0x03,
            StreamDimensionsIn = 0x04,
            StreamDimensionOut = 0x05,
            StreamRangeIn = 0x06,
            StreamRangeOut = 0x07,
        }
        

        /*
         * 
         * StreamUpdateFlags
         * 
         * 
         * */

        public enum UpdateFlags
        {
            WorldJobsActivityData = 0x01,
            WorldAnimationData = 0x02,
            WorldSceneData = 0x03,
            WorldSeatData = 0x04,
            WorldBodyData = 0x05,
            WorldClothData = 0x06,
            WorldVehiculeData = 0x07,
            WorldObjectData = 0x08,
            WorldAttachData = 0x09,
            WorldFightData = 0x0A,
            WorldIdentityData = 0x0B,
            WorldUserData = 0x0C,
            WorldSeedData = 0x0D,
            WorldRigidBodyData = 0x0E,
        }
    }
}
