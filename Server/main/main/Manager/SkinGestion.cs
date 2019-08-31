using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using GTANetworkAPI;

/*using SQLAPI = main.Database.MySqlGestion;
using CMAPI = main.Manager.CharacterManager;
using WAPI = main.Permission.WhiteListCommand;
using DUSER = main.Database.DataUser;
using UAPI = main.Manager.Update;
using DGAPI = main.Manager.DimensionGestion;*/

namespace main.Manager
{

    /*class SkinInfo
    {
        public int gender { get; set; }
        public int father { get; set; }
        public int mother { get; set; }
        public int heredity { get; set; }
        public int skin { get; set; }
        public int eye_colors { get; set; }
        public int hat { get; set; }
        public int haut { get; set; }
        public int hair { get; set; }
        public int torse { get; set; }
        public int mihaut { get; set; }
        public int bas { get; set; }
        public int shoes { get; set; }
        public float[] face_feature { get; set; }
        public int[] head_overlay_index { get; set; }
        public float[] head_overlay_opacity { get; set; }
        public int[] cloth { get; set; }
    }

    struct HeadOverJson
    {
        public int index { get; set; }
        public float opacity { get; set; }
    }

    class SkinGestion
    {

        public static int[] fathers = new int[24] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 42, 43, 44 };
        public static int[] mothers = new int[22] { 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 45 };

        public static void set_skin_to_player(Client client, string json) {
            if (CMAPI.get_data_player(client) != null) {
                SkinInfo info = JsonConvert.DeserializeObject<SkinInfo>(json);
                CMAPI.get_data_player(client).setIdCard.sex = info.gender;
                //CMAPI.get_data_player(client).setCharacter.lips = info.heredity;
                CMAPI.get_data_player(client).setCharacter.headMix = info.skin;
                CMAPI.get_data_player(client).setCharacter.eyesColor = info.eye_colors;
                CMAPI.get_data_player(client).setCharacter.ShapeFirst = (byte)mothers[info.mother];
                CMAPI.get_data_player(client).setCharacter.ShapeSecond = (byte)fathers[info.father];
                CMAPI.get_data_player(client).setCharacter.ShapeThird = 0;
                CMAPI.get_data_player(client).setCharacter.SkinFirst = (byte)mothers[info.mother];
                CMAPI.get_data_player(client).setCharacter.SkinSecond = (byte)fathers[info.father];
                CMAPI.get_data_player(client).setCharacter.SkinThird = 0;
                CMAPI.get_data_player(client).setCharacter.ShapeMix = (float)info.heredity * 0.01f;
                CMAPI.get_data_player(client).setCharacter.SkinMix = (float)info.skin * 0.01f;
                CMAPI.get_data_player(client).setCharacter.ThirdMix = 0;
                CMAPI.get_data_player(client).setCharacter.facefeature = new List<float>(info.face_feature);
                CMAPI.get_data_player(client).setCloth.body_cloth = new List<int>() { 0, 0, info.hair, info.torse, info.bas, 0, info.shoes, 0, info.mihaut, 0, 0, info.haut };
                Dictionary<int, string> tmp = new Dictionary<int, string>();
                for (int i = 0; i < 10; i++) {
                    tmp.Add(i, JsonConvert.SerializeObject(new HeadOverJson() { index = info.head_overlay_index[i], opacity = info.head_overlay_opacity[i] }));
                }
                CMAPI.get_data_player(client).setCharacter.headoverlay = tmp;

                //CMAPI.get_data_player(client).setCloth.a = info.hat;
                //CMAPI.get_data_player(client).setCloth.b = info.haut;
                //CMAPI.get_data_player(client).setCloth.c = info.bas;
                //CMAPI.get_data_player(client).setCloth.d = info.shoes;
                /*CMAPI.get_data_player(client).setIdCard.sex = info.father;
                CMAPI.get_data_player(client).setIdCard.sex = info.mother;
                CMAPI.get_data_player(client).setIdCard.sex = info.skin;
                CMAPI.get_data_player(client).setIdCard.sex = info.heredity;
                UAPI.update_skin(client);
            }
        } 


    }*/
}
