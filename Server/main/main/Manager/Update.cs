using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using GTANetworkAPI;
//using CMAPI = main.Manager.CharacterManager;


namespace main.Manager
{
    /*class Update : Script
    {


        public Update() {

        }

        public static void update_dimensions(Client player) {
            if (CMAPI.get_data_player(player) != null)
            {
                player.Dimension = CMAPI.get_data_player(player).user.dimensions;
            }
        }

        [RemoteEvent("update_skin")]
        public static void update_skin(Client client) {
            if (CMAPI.get_data_player(client) != null)
            {
                HeadBlend hd = new HeadBlend();
                hd.ShapeFirst = CMAPI.get_data_player(client).setCharacter.ShapeFirst;
                hd.ShapeSecond = CMAPI.get_data_player(client).setCharacter.ShapeSecond;
                hd.ShapeThird = CMAPI.get_data_player(client).setCharacter.ShapeThird;
                hd.SkinFirst = CMAPI.get_data_player(client).setCharacter.SkinFirst;
                hd.SkinSecond = CMAPI.get_data_player(client).setCharacter.SkinSecond;
                hd.SkinThird = CMAPI.get_data_player(client).setCharacter.SkinThird;
                hd.ShapeMix = CMAPI.get_data_player(client).setCharacter.ShapeMix;
                hd.SkinMix = CMAPI.get_data_player(client).setCharacter.SkinMix;
                hd.ThirdMix = CMAPI.get_data_player(client).setCharacter.ThirdMix;
                Random rand = new Random();
                float[] face = new float[20];
                for (int i = 0; i < 20; i++) { face[i] = CMAPI.get_data_player(client).setCharacter.facefeature[i]; }
                Dictionary<int, HeadOverlay> headoverlays = new Dictionary<int, HeadOverlay>();
                for (int i = 0; i < 10; i++) {
                    HeadOverJson tmp = JsonConvert.DeserializeObject<HeadOverJson>(CMAPI.get_data_player(client).setCharacter.headoverlay[i]);
                    headoverlays.Add(i, new HeadOverlay() { Index = Convert.ToByte(tmp.index), Opacity = tmp.opacity });
                }
                Decoration[] deco = new Decoration[5];
                for (int i = 0; i < 5; i++)
                {
                    deco[i].Collection = Convert.ToUInt16(rand.Next(0, 10));
                    deco[i].Overlay = Convert.ToUInt16(rand.Next(0, 10));
                }
                //client.SetAccessories(0, rand.Next(0, 10), 0);
                client.SetClothes(2, rand.Next(0, 10), 0);

                //client.SetAccessories(0, CMAPI.get_data_player(client).setCloth.a, 0);
                //client.SetClothes(11, CMAPI.get_data_player(client).setCloth.b, 0);
                //client.SetClothes(4, CMAPI.get_data_player(client).setCloth.c, 0);
                //client.SetClothes(6, CMAPI.get_data_player(client).setCloth.d, 0);
                //client.SetClothes(1, rand.Next(0, 10), 0);
                client.SetCustomization(
                    CMAPI.get_data_player(client).setIdCard.sex == 0 ? true : false,
                   hd, 
                   Convert.ToByte(CMAPI.get_data_player(client).setCharacter.eyesColor),
                   Convert.ToByte(rand.Next(0, 10)),
                   Convert.ToByte(rand.Next(0, 10)),
                   face,
                   headoverlays,
                   deco
                   );
                for (int i = 0; i < 12; i++)
                    client.SetClothes(i, CMAPI.get_data_player(client).setCloth.body_cloth[i], 0);
                //client.SetFaceFeature(Convert.ToInt32(CMAPI.get_data_player(client).setCharacter.lips), 1);
                //Decoration deco = new Decoration();
                //deco.Collection = Convert.ToUInt16(CMAPI.get_data_player(client).setCharacter.lips);
                //deco.Overlay = Convert.ToUInt16(CMAPI.get_data_player(client).setCharacter.headMix);
                //client.SetDecoration(deco);
            }
        }


    }*/
}
