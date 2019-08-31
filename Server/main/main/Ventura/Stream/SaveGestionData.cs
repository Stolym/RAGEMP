using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using GTANetworkAPI;
using main.Ventura.Constant;
using DUSER = main.Ventura.Database.DataUser;
using LAPI = main.Ventura.Gestion.LogGestion;
using CGAPI = main.Ventura.Gestion.CharacterGestion;
using FAPI = main.Ventura.Database.Formatter.Formatter;
using DAPI = main.Ventura.Gestion.DimensionGestion;
using ASAPI = main.Ventura.Stream.Async.Event.AsyncEvent;

namespace main.Ventura.Stream
{
    class SaveGestionData : Script
    {

        /*
         *   public static List<string> table_data_name = new List<string>()
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
         * 
         * 
         * 
         * */

        private int GetIndex(string name) {
            int index = -1;
            for (int i = 0; i < Constants.table_data_name.Count; i++)
            {
                if (Constants.table_data_name[i] == name)
                    index = i;
            }
            return index;
        }

        [RemoteEvent("SaveData")]
        public void SaveData(Client client, string name)
        {
            string json = null;
            DUSER user = null;
            switch (GetIndex(name))
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    json = (string)client.GetSharedData(name);
                    user = CGAPI.GetDataPlayer(client);
                    if (json == null || user == null)
                        break;
                    var body = JsonConvert.DeserializeObject<StreamData.WorldBodyData>(json);
                    if (body == null)
                        return;
                    user.body.ShapeFirst = body.ShapeFirst;
                    user.body.ShapeSecond = body.ShapeSecond;
                    user.body.ShapeThird = body.ShapeThird;
                    user.body.ShapeMix = body.ShapeMix;
                    user.body.SkinFirst = body.SkinFirst;
                    user.body.SkinSecond = body.SkinSecond;
                    user.body.SkinThird = body.SkinThird;
                    user.body.SkinMix = body.skinMix;
                    user.body.skinMix = body.skinMix;
                    user.body.ThirdMix = body.ThirdMix;
                    user.body.firstHeadShape = body.firstHeadShape;
                    user.body.secondHeadShape = body.secondHeadShape;
                    user.body.firstSkinTone = body.firstSkinTone;
                    user.body.secondSkinTone = body.secondSkinTone;
                    user.body.headMix = body.headMix;
                    user.body.eyesColor = body.eyesColor;
                    user.body.facefeature = body.facefeature;
                    user.body.headOverlay = body.headOverlay;
                    user.id_card.sex = body.sex;
                    user.body.decoration = body.decoration;
                    user.body.facialDecoration = body.facialDecoration;
                    Synchronization.StreamGestionAsync.instance.UltimeAsync(client, FAPI.SerializeObjectJson<Stream.StreamData.WorldBodyData>(new Stream.StreamData.WorldBodyData()
                    {
                        Id = 0,
                        Name = "",
                        RemoteId = client.Handle.Value,
                        Dimensions = client.Dimension,
                        Type = Constant.Constants.UpdateFlags.WorldBodyData,
                        ShapeFirst = user.body.ShapeFirst,
                        ShapeSecond = user.body.ShapeSecond,
                        ShapeThird = user.body.ShapeThird,
                        ShapeMix = user.body.ShapeMix,
                        SkinFirst = user.body.SkinFirst,
                        SkinSecond = user.body.SkinSecond,
                        SkinThird = user.body.SkinThird,
                        SkinMix = user.body.skinMix,
                        firstHeadShape = user.body.firstHeadShape,
                        secondHeadShape = user.body.secondHeadShape,
                        firstSkinTone = user.body.firstSkinTone,
                        secondSkinTone = user.body.secondSkinTone,
                        ThirdMix = user.body.ThirdMix,
                        skinMix = user.body.skinMix,
                        headMix = user.body.headMix,
                        eyesColor = user.body.eyesColor,
                        facefeature = user.body.facefeature,
                        headOverlay = user.body.headOverlay,
                        sex = user.id_card.sex,
                        decoration = user.body.decoration,
                        facialDecoration = user.body.facialDecoration,
                    }), Constant.Constants.StreamFlags.StreamIn, Constant.Constants.UpdateFlags.WorldBodyData, 0, client.Dimension);
                    break;
                case 5:
                    json = client.GetSharedData(name);
                    user = CGAPI.GetDataPlayer(client);
                    if (json == null || user == null)
                        break;
                    var cloth = JsonConvert.DeserializeObject<StreamData.WorldClothData>(json);
                    if (cloth == null)
                        return;
                    user.cloth.body_cloth = cloth.cloth;
                    user.user.service = cloth.IsService;
                    Synchronization.StreamGestionAsync.instance.UltimeAsync(client, FAPI.SerializeObjectJson<Stream.StreamData.WorldClothData>(new Stream.StreamData.WorldClothData()
                    {
                        Id = 0,
                        Name = "",
                        LocalId = 0,
                        RemoteId = client.Handle.Value,
                        Type = Constants.UpdateFlags.WorldClothData,
                        Dimensions = client.Dimension,
                        cloth = user.cloth.body_cloth,
                        IsService = user.user.service,
                    }), Constant.Constants.StreamFlags.StreamIn, Constant.Constants.UpdateFlags.WorldClothData, 0, client.Dimension);
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    break;
                case 9:
                    break;
            }

        }


        [RemoteEvent("ResetData")]
        public void ResetData(Client client, string name)
        {
            string json = null;
            DUSER user = null;
            switch (GetIndex(name))
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    json = (string)client.GetSharedData(name);
                    user = CGAPI.GetDataPlayer(client);
                    if (json == null || user == null)
                        break;
                    var body = JsonConvert.DeserializeObject<StreamData.WorldBodyData>(json);
                    if (body == null)
                        return;
                    user.body.ShapeFirst = 0;
                    user.body.ShapeSecond = 0;
                    user.body.ShapeThird = 0;
                    user.body.ShapeMix = 0;
                    user.body.SkinFirst = 0;
                    user.body.SkinSecond = 0;
                    user.body.SkinThird = 0;
                    user.body.SkinMix = 0;
                    user.body.firstHeadShape = 0;
                    user.body.secondHeadShape = 0;
                    user.body.firstSkinTone = 0;
                    user.body.secondSkinTone = 0;
                    user.body.headMix = 0;
                    user.body.eyesColor = 0;
                    user.body.facefeature = new List<float>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    user.body.headOverlay = new List<List<float>>() {
                        new List<float>() { 0, 0 },
                        new List<float>() { 0, 0 },
                        new List<float>() { 0, 0 },
                        new List<float>() { 0, 0 },
                        new List<float>() { 0, 0 },
                        new List<float>() { 0, 0 },
                        new List<float>() { 0, 0 },
                        new List<float>() { 0, 0 },
                        new List<float>() { 0, 0 },
                    };
                    user.id_card.sex = body.sex;
                    user.body.decoration = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    user.body.facialDecoration = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    Synchronization.StreamGestionAsync.instance.UltimeAsync(client, FAPI.SerializeObjectJson<Stream.StreamData.WorldBodyData>(new Stream.StreamData.WorldBodyData()
                    {
                        Id = 0,
                        Name = "",
                        RemoteId = client.Handle.Value,
                        Dimensions = client.Dimension,
                        Type = Constant.Constants.UpdateFlags.WorldBodyData,
                        ShapeFirst = user.body.ShapeFirst,
                        ShapeSecond = user.body.ShapeSecond,
                        ShapeThird = user.body.ShapeThird,
                        ShapeMix = user.body.ShapeMix,
                        SkinFirst = user.body.SkinFirst,
                        SkinSecond = user.body.SkinSecond,
                        SkinThird = user.body.SkinThird,
                        SkinMix = user.body.skinMix,
                        firstHeadShape = user.body.firstHeadShape,
                        secondHeadShape = user.body.secondHeadShape,
                        firstSkinTone = user.body.firstSkinTone,
                        secondSkinTone = user.body.secondSkinTone,
                        headMix = user.body.headMix,
                        eyesColor = user.body.eyesColor,
                        facefeature = user.body.facefeature,
                        headOverlay = user.body.headOverlay,
                        sex = user.id_card.sex,
                        decoration = user.body.decoration,
                        facialDecoration = user.body.facialDecoration,
                    }), Constant.Constants.StreamFlags.StreamIn, Constant.Constants.UpdateFlags.WorldBodyData, 0, client.Dimension);
                    break;
                case 5:
                    json = client.GetSharedData(name);
                    user = CGAPI.GetDataPlayer(client);
                    if (json == null || user == null)
                        break;
                    var cloth = JsonConvert.DeserializeObject<StreamData.WorldClothData>(json);
                    if (cloth == null)
                        return;
                    List<List<int>> body_cloth = new List<List<int>>();
                    if (user.id_card.sex == 1)
                    {
                        body_cloth.Add(new List<int>() { 0, 0 });
                        body_cloth.Add(new List<int>() { 0, 0 });
                        body_cloth.Add(new List<int>() { 0, 0 });
                        body_cloth.Add(new List<int>() { 32, 0 });
                        body_cloth.Add(new List<int>() { 62, 0 });
                        body_cloth.Add(new List<int>() { 0, 0 });
                        body_cloth.Add(new List<int>() { 35, 0 });
                        body_cloth.Add(new List<int>() { 0, 0 });
                        body_cloth.Add(new List<int>() { 160, 0 });
                        body_cloth.Add(new List<int>() { 0, 0 });
                        body_cloth.Add(new List<int>() { 0, 0 });
                        body_cloth.Add(new List<int>() { 279, 0 });
                        body_cloth.Add(new List<int>() { 120, 0 });
                        body_cloth.Add(new List<int>() { 12, 0 });
                        body_cloth.Add(new List<int>() { 12, 0 });
                        body_cloth.Add(new List<int>() { 1, 0 });
                        body_cloth.Add(new List<int>() { 15, 0 });
                    }
                    else if (user.id_card.sex == 0)
                    {
                        body_cloth.Add(new List<int>() { 0, 0 });
                        body_cloth.Add(new List<int>() { 0, 0 });
                        body_cloth.Add(new List<int>() { 0, 0 });
                        body_cloth.Add(new List<int>() { 15, 0 });
                        body_cloth.Add(new List<int>() { 61, 0 });
                        body_cloth.Add(new List<int>() { 0, 0 });
                        body_cloth.Add(new List<int>() { 34, 0 });
                        body_cloth.Add(new List<int>() { 0, 0 });
                        body_cloth.Add(new List<int>() { 130, 0 });
                        body_cloth.Add(new List<int>() { 0, 0 });
                        body_cloth.Add(new List<int>() { 0, 0 });
                        body_cloth.Add(new List<int>() { 252, 0 });
                        body_cloth.Add(new List<int>() { 8, 0 });
                        body_cloth.Add(new List<int>() { 0, 0 });
                        body_cloth.Add(new List<int>() { 33, 0 });
                        body_cloth.Add(new List<int>() { 2, 0 });
                        body_cloth.Add(new List<int>() { 0, 0 });
                    }

                    user.cloth.body_cloth = body_cloth;
                    user.user.service = cloth.IsService;
                    Synchronization.StreamGestionAsync.instance.UltimeAsync(client, FAPI.SerializeObjectJson<Stream.StreamData.WorldClothData>(new Stream.StreamData.WorldClothData()
                    {
                        Id = 0,
                        Name = "",
                        LocalId = 0,
                        RemoteId = client.Handle.Value,
                        Type = Constants.UpdateFlags.WorldClothData,
                        Dimensions = client.Dimension,
                        cloth = user.cloth.body_cloth,
                        IsService = user.user.service,
                    }), Constant.Constants.StreamFlags.StreamIn, Constant.Constants.UpdateFlags.WorldClothData, 0, client.Dimension);
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    break;
                case 9:
                    break;
            }

        }

    }
}
