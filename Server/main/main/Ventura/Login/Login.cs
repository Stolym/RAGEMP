using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using Newtonsoft.Json;
using main.Ventura.Stream;
using main.Ventura.Constant;
using DUSER = main.Ventura.Database.DataUser;
using LAPI = main.Ventura.Gestion.LogGestion;
using CGAPI = main.Ventura.Gestion.CharacterGestion;
using FAPI = main.Ventura.Database.Formatter.Formatter;
using DAPI = main.Ventura.Gestion.DimensionGestion;
using ASAPI = main.Ventura.Stream.Async.Event.AsyncEvent;
//using CGAPI = main.Manager.CharacterManager;
//using UAPI = main.Manager.Update;
//using DAPI = main.Manager.DimensionGestion;


namespace main.Ventura.Login
{
    class Login : Script
    {
        [RemoteEvent("CheckPassword")]
        public void check_password(Client client, object[] args) {
            DUSER data = CGAPI.GetDataPlayer(client);
            string password = args[0].ToString();
            int Hashcode = (int)args[1];
            if (data.user.password == password)
            {
                Synchronization.StreamGestionAsync.instance.UltimeAsync(client, FAPI.SerializeObjectJson<Stream.StreamData.WorldClothData>(new Stream.StreamData.WorldClothData()
                {
                    Id = 0,
                    Name = "",
                    LocalId = 0,
                    RemoteId = client.Handle.Value,
                    Type = Constants.UpdateFlags.WorldClothData,
                    Dimensions = client.Dimension,
                    cloth = data.cloth.body_cloth,
                    IsService = data.user.service,
                }), Constant.Constants.StreamFlags.StreamIn, Constant.Constants.UpdateFlags.WorldClothData, 0, client.Dimension);

                Synchronization.StreamGestionAsync.instance.UltimeAsync(client, FAPI.SerializeObjectJson<Stream.StreamData.WorldBodyData>(new Stream.StreamData.WorldBodyData()
                {
                    Id = 0,
                    Name = "",
                    RemoteId = client.Handle.Value,
                    Dimensions = client.Dimension,
                    Type = Constant.Constants.UpdateFlags.WorldBodyData,
                    ShapeFirst = data.body.ShapeFirst,
                    ShapeSecond = data.body.ShapeSecond,
                    ShapeThird = data.body.ShapeThird,
                    ShapeMix = data.body.ShapeMix,
                    SkinFirst = data.body.SkinFirst,
                    SkinSecond = data.body.SkinSecond,
                    SkinThird = data.body.SkinThird,
                    SkinMix = data.body.skinMix,
                    firstHeadShape = data.body.firstHeadShape,
                    secondHeadShape = data.body.secondHeadShape,
                    firstSkinTone = data.body.firstSkinTone,
                    secondSkinTone = data.body.secondSkinTone,
                    headMix = data.body.headMix,
                    skinMix = data.body.skinMix,
                    ThirdMix = data.body.ThirdMix,
                    eyesColor = data.body.eyesColor,
                    facefeature = data.body.facefeature,
                    headOverlay = data.body.headOverlay,
                    sex = data.id_card.sex,
                    decoration = data.body.decoration,
                    facialDecoration = data.body.facialDecoration,
                }), Constant.Constants.StreamFlags.StreamIn, Constant.Constants.UpdateFlags.WorldBodyData, 0, client.Dimension);

                Synchronization.StreamGestionAsync.instance.UltimeAsync(client, FAPI.SerializeObjectJson<Stream.StreamData.WorldFightData>(new Stream.StreamData.WorldFightData()
                {
                    Id = 0,
                    Name = "",
                    RemoteId = client.Handle.Value,
                    Dimensions = client.Dimension,
                    FlagActives = new List<int>(),
                    TaskActives = new List<int>(),
                    LocalId = 0,
                    TargetRemoteId = 0,
                }), Constant.Constants.StreamFlags.StreamIn, Constant.Constants.UpdateFlags.WorldFightData, 0, client.Dimension);
                client.TriggerEvent("LoginExecute", 0);
            }
            else
                client.TriggerEvent("LoginExecute", 1);
            client.TriggerEvent("OTickEventChangeState", Hashcode);
        }

        public static void login_form(Client player)
        {

            /*
            * id
            * Heatlh
            * RigidBody
            * Cloth
            * Body
            * Tattoo
            * Bank
            * item
            * Jobs Permission
            * 
            * Vehicle if not exist in instance server(out after 2 hour)
             * Habitation sender
             * Cloth sender
             * Market sender
             * Object sender
             * Seed sender
             * Door sender
             * Attach Object Sender
             * Animation sender
             * Seat sender
             * State sender
             * 
             * */
            //player.SetSharedData("StreamFight", JsonConvert.SerializeObject(new Synchronization.HeatlhData() { bone_break = new List<int>(), IsAlive = true, RemoteId = player.Handle.Value }));
            /*player.SetSharedData("StreamHealth", JsonConvert.SerializeObject(new Synchronization.HeatlhData() { bone_break = new List<int>(), IsAlive = true, RemoteId = player.Handle.Value }));
               player.SetSharedData("StreamUsers", JsonConvert.SerializeObject(new Synchronization.HeatlhData() { bone_break = new List<int>(), IsAlive = true, RemoteId = player.Handle.Value }));
               player.SetSharedData("StreamVoice", JsonConvert.SerializeObject(new Synchronization.HeatlhData() { bone_break = new List<int>(), IsAlive = true, RemoteId = player.Handle.Value }));
               player.SetSharedData("StreamCloth", JsonConvert.SerializeObject(new Synchronization.HeatlhData() { bone_break = new List<int>(), IsAlive = true, RemoteId = player.Handle.Value }));
               player.SetSharedData("StreamTattoo", JsonConvert.SerializeObject(new Synchronization.HeatlhData() { bone_break = new List<int>(), IsAlive = true, RemoteId = player.Handle.Value }));
               player.SetSharedData("StreamHabitation", JsonConvert.SerializeObject(new Synchronization.HeatlhData() { bone_break = new List<int>(), IsAlive = true, RemoteId = player.Handle.Value }));
               player.SetSharedData("StreamJobs", JsonConvert.SerializeObject(new Synchronization.HeatlhData() { bone_break = new List<int>(), IsAlive = true, RemoteId = player.Handle.Value }));
               player.SetSharedData("StreamAnim", JsonConvert.SerializeObject(new Synchronization.HeatlhData() { bone_break = new List<int>(), IsAlive = true, RemoteId = player.Handle.Value }));
               player.SetSharedData("StreamSceneObject", JsonConvert.SerializeObject(new Synchronization.HeatlhData() { bone_break = new List<int>(), IsAlive = true, RemoteId = player.Handle.Value }));
               player.SetSharedData("StreamAttachObject", JsonConvert.SerializeObject(new Synchronization.HeatlhData() { bone_break = new List<int>(), IsAlive = true, RemoteId = player.Handle.Value }));*/
            //UAPI.update_skin(player);
            player.TriggerEvent("LoginForm");
            //player.TriggerEvent("OnPlayerJoin");
        }

    }
}
