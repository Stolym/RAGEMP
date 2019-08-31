using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using GTANetworkAPI;
using FAPI = main.Ventura.Database.Formatter.Formatter;

namespace main.Ventura.World
{
    class WorldPedManager : Script
    {
        public WorldPedManager() { }
        enum PedTypes
        {
            PED_TYPE_PLAYER_0,// michael  
            PED_TYPE_PLAYER_1,// franklin  
            PED_TYPE_NETWORK_PLAYER,    // mp character  
            PED_TYPE_PLAYER_2,// trevor  
            PED_TYPE_CIVMALE,
            PED_TYPE_CIVFEMALE,
            PED_TYPE_COP,
            PED_TYPE_GANG_ALBANIAN,
            PED_TYPE_GANG_BIKER_1,
            PED_TYPE_GANG_BIKER_2,
            PED_TYPE_GANG_ITALIAN,
            PED_TYPE_GANG_RUSSIAN,
            PED_TYPE_GANG_RUSSIAN_2,
            PED_TYPE_GANG_IRISH,
            PED_TYPE_GANG_JAMAICAN,
            PED_TYPE_GANG_AFRICAN_AMERICAN,
            PED_TYPE_GANG_KOREAN,
            PED_TYPE_GANG_CHINESE_JAPANESE,
            PED_TYPE_GANG_PUERTO_RICAN,
            PED_TYPE_DEALER,
            PED_TYPE_MEDIC,
            PED_TYPE_FIREMAN,
            PED_TYPE_CRIMINAL,
            PED_TYPE_BUM,
            PED_TYPE_PROSTITUTE,
            PED_TYPE_SPECIAL,
            PED_TYPE_MISSION,
            PED_TYPE_SWAT,
            PED_TYPE_ANIMAL,
            PED_TYPE_ARMY
        };

        public static List<Stream.StreamData.WorldPedData> worldPedDatas = new List<Stream.StreamData.WorldPedData>() {

            new Stream.StreamData.WorldPedData()
            {
                Handle = -1,
                Hashcode = 0,
                HashcodeModel = (uint)PedHash.AfriAmer01AMM,
                heading = 340.9791f,
                nx = 0,
                ny = 0,
                nz = 0,
                LocalId = 0,
                PedType = (int)PedTypes.PED_TYPE_CIVMALE,
                x = -424.5862f,
                y = 1124.962f,
                z = 326.8536f,
            }, new Stream.StreamData.WorldPedData()
            {
                Handle = -1,
                Hashcode = 1,
                HashcodeModel = (uint)PedHash.MilitaryBum,
                heading = 340.9791f,
                nx = 0,
                ny = 0,
                nz = 0,
                LocalId = 0,
                PedType = (int)PedTypes.PED_TYPE_CIVMALE,
                x = -424.5862f,
                y = 1124.962f,
                z = 326.8536f,
            },/* new Stream.StreamData.WorldPedData()
            {
                Handle = -1,
                Hashcode = 3,
                HashcodeModel = (uint)PedHash.ArmBoss01GMM,
                heading = 340.9791f,
                nx = 0,
                ny = 0,
                nz = 0,
                LocalId = 0,
                PedType = (int)PedTypes.PED_TYPE_CIVMALE,
                x = -424.5862f,
                y = 1124.962f,
                z = 326.8536f,
            }, new Stream.StreamData.WorldPedData()
            {
                Handle = -1,
                Hashcode = 1,
                HashcodeModel = (uint)PedHash.Armoured01,
                heading = 340.9791f,
                nx = 0,
                ny = 0,
                nz = 0,
                LocalId = 0,
                PedType = (int)PedTypes.PED_TYPE_CIVMALE,
                x = -424.5862f,
                y = 1124.962f,
                z = 326.8536f,
            }, new Stream.StreamData.WorldPedData()
            {
                Handle = -1,
                Hashcode = 2,
                HashcodeModel = (uint)PedHash.AfriAmer01AMM,
                heading = 340.9791f,
                nx = 0,
                ny = 0,
                nz = 0,
                LocalId = 0,
                PedType = (int)PedTypes.PED_TYPE_CIVMALE,
                x = -424.5862f,
                y = 1124.962f,
                z = 326.8536f,
            }, new Stream.StreamData.WorldPedData()
            {
                Handle = -1,
                Hashcode = 5,
                HashcodeModel = (uint)PedHash.FreemodeMale01,
                heading = 340.9791f,
                nx = 0,
                ny = 0,
                nz = 0,
                LocalId = 0,
                PedType = (int)PedTypes.PED_TYPE_CIVMALE,
                x = -424.5862f,
                y = 1124.962f,
                z = 326.8536f,
            },
            new Stream.StreamData.WorldPedData()
            {
                Handle = -1,
                Hashcode = 6,
                HashcodeModel = (uint)PedHash.Salton01AFM,
                heading = 340.9791f,
                nx = 0,
                ny = 0,
                nz = 0,
                LocalId = 0,
                PedType = (int)PedTypes.PED_TYPE_CIVMALE,
                x = -424.5862f,
                y = 1124.962f,
                z = 326.8536f,
            },
            new Stream.StreamData.WorldPedData()
            {
                Handle = -1,
                Hashcode = 7,
                HashcodeModel = (uint)PedHash.AfriAmer01AMM,
                heading = 340.9791f,
                nx = 0,
                ny = 0,
                nz = 0,
                LocalId = 0,
                PedType = (int)PedTypes.PED_TYPE_CIVMALE,
                x = -424.5862f,
                y = 1124.962f,
                z = 326.8536f,
            },
            new Stream.StreamData.WorldPedData()
            {
                Handle = -1,
                Hashcode = 8,
                HashcodeModel = (uint)PedHash.BikeHire01,
                heading = 340.9791f,
                nx = 0,
                ny = 0,
                nz = 0,
                LocalId = 0,
                PedType = (int)PedTypes.PED_TYPE_CIVMALE,
                x = -424.5862f,
                y = 1124.962f,
                z = 326.8536f,
            },
            new Stream.StreamData.WorldPedData()
            {
                Handle = -1,
                Hashcode = 9,
                HashcodeModel = (uint)PedHash.Beach01AFM,
                heading = 340.9791f,
                nx = 0,
                ny = 0,
                nz = 0,
                LocalId = 0,
                PedType = (int)PedTypes.PED_TYPE_CIVMALE,
                x = -424.5862f,
                y = 1124.962f,
                z = 326.8536f,
            },
            new Stream.StreamData.WorldPedData()
            {
                Handle = -1,
                Hashcode = 10,
                HashcodeModel = (uint)PedHash.Beach01AMY,
                heading = 340.9791f,
                nx = 0,
                ny = 0,
                nz = 0,
                LocalId = 0,
                PedType = (int)PedTypes.PED_TYPE_CIVMALE,
                x = -424.5862f,
                y = 1124.962f,
                z = 326.8536f,
            },*/
            


    };


        [RemoteEvent("StreamPedSharedData")]
        public void StreamPedSharedData(Client client, object[] args)
        {
            string json = args[0].ToString();
            //NAPI.Util.ConsoleOutput(json);
            worldPedDatas = JsonConvert.DeserializeObject<List<Stream.StreamData.WorldPedData>>(json);
            NAPI.ClientEvent.TriggerClientEventForAll("UpdatePedSharedData", FAPI.SerializeObjectJson<List<Stream.StreamData.WorldPedData>>(worldPedDatas));
        }

    }
}
