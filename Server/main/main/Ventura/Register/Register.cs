using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GTANetworkAPI;
using main.Ventura.Stream;
using main.Ventura.Constant;
using DUSER = main.Ventura.Database.DataUser;
using LAPI = main.Ventura.Gestion.LogGestion;
using CGAPI = main.Ventura.Gestion.CharacterGestion;
using FAPI = main.Ventura.Database.Formatter.Formatter;
using DAPI = main.Ventura.Gestion.DimensionGestion;
using ASAPI = main.Ventura.Stream.Async.Event.AsyncEvent;


namespace main.Ventura.Register
{
    class Register : Script
    {
        //public static Register instance = null;
        private long tick_sync { get; set; }

        /*public Register() {
            if (instance == null)
                instance = this;
        }*/

        private void SetClock() {
            if (tick_sync == 0)
                tick_sync = DateTime.Now.AddMilliseconds(20).Ticks;
        }

        [ServerEvent(Event.Update)]
        public void update() {
            SetClock();

            if (DateTime.Now.Ticks > tick_sync) {
                for (int i = 0; i < NAPI.Pools.GetAllPlayers().Count; i++) {
                    DUSER data = CGAPI.GetDataPlayer(NAPI.Pools.GetAllPlayers()[i]);
                    if (data == null)
                        continue;
                    if (DateTime.Now.Ticks > data.user.ticks[8] && data.user.active[8])
                    {
                        data.user.ticks[8] = 0;
                        data.user.active[8] = false;
                        NAPI.ClientEvent.TriggerClientEvent(NAPI.Pools.GetAllPlayers()[i], "RegisterExecute");
                        UpdateCharacterEditorPlayer(NAPI.Pools.GetAllPlayers()[i], data);
                    }
                    if (DateTime.Now.Ticks > data.user.ticks[9] && data.user.active[9])
                    {
                        data.user.ticks[9] = 0;
                        data.user.active[9] = false;
                        NAPI.ClientEvent.TriggerClientEvent(NAPI.Pools.GetAllPlayers()[i], "DestroyRegisterForm");
                    }
                }
                tick_sync = 0;
            }



        }

        private void UpdateCharacterEditorPlayer(Client client, DUSER data)
        {
            Synchronization.StreamGestionAsync.instance.UltimeAsync(client, FAPI.SerializeObjectJson<List<Stream.StreamData.WorldAttachData>>(new List<Stream.StreamData.WorldAttachData>() { new Stream.StreamData.WorldAttachData()
            {
                Name = "prop_police_id_board",
                Type = data.attaches[0].Type,
                Bone = 28422,
                Dimensions = client.Dimension,
                RemoteId = client.Handle.Value,
                IsNetwork = data.attaches[0].IsNetwork,
                IsDynamic = data.attaches[0].IsDynamic,
                Position = data.attaches[0].Position,
                Rotation = data.attaches[0].Rotation,
                VertexIndex = 2,
                P9 = false,
                UseSoftPinning = false,
                IsPed = false,
                Collision = false,
                LockRotation = true,
                IsAttached = true,
            } }), Constant.Constants.StreamFlags.StreamIn, Constant.Constants.UpdateFlags.WorldAttachData, 0, client.Dimension);

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
                eyesColor = data.body.eyesColor,
                facefeature = data.body.facefeature,
                headOverlay = data.body.headOverlay,
                sex = data.id_card.sex,
                decoration = data.body.decoration,
                facialDecoration = data.body.facialDecoration,
            }), Constant.Constants.StreamFlags.StreamIn, Constant.Constants.UpdateFlags.WorldBodyData, 0, client.Dimension);
        }

        [RemoteEvent("SavePasswordPlayer")]
        public void save_password(Client client, object[] obj)
        {
            string password = obj[0].ToString();
            int Hashcode = (int)obj[1];
            DUSER data = CGAPI.GetDataPlayer(client);
            Random rand = new Random();
            string str = "      ";
            char[] ptr = null;

            if (data == null)
            {
                client.Kick();
                return;
            }

            for (int i = 0; i < str.Length; i++)
            {
                (ptr = str.ToCharArray())[i] = (char)rand.Next(49, 57);
                str = ptr.ToString();
            }

            data.user.social = client.SocialClubName;
            data.user.password = password;
            data.user.address = client.Address;
            data.user.ts_name = str.ToString();
            client.Name = client.SocialClubName;
           
            data.user.ticks[8] = DateTime.Now.AddSeconds(1).Ticks;
            data.user.ticks[9] = DateTime.Now.AddSeconds(4).Ticks;

            data.user.active[8] = true;
            data.user.active[9] = true;

            NAPI.ClientEvent.TriggerClientEvent(client, "OTickEventChangeState", Hashcode);
        }

        [RemoteEvent("register_close")]
        public void register_close(Client player, string from_to) {
            player.TriggerEvent("CharacterOut", from_to);
        }

        public static void register(Client player) {

            // Set Social Club and fake new data.

            DUSER data = new DUSER();
            data.user.social = player.SocialClubName;

            // Add this new player to PlayersListDUSER

            CGAPI.AddPlayerInList(player, ref data);
            DAPI.UpdateInstanceWithDataUser(player, data, player.SocialClubName);

            // Stream Player
            //main.Ventura.Stream.Async.Stream.AsyncStream.instance.AllStreamManager((Entity)player);
            if (!ASAPI.CallEvent(player, "RegisterForm", new object[] { }))
                player.Kick();
        }

    }
}
