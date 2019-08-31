using System;
using System.Collections.Generic;
using System.Text;
using RAGE;
using EAPI = RAGE.Elements;
using GAPI = RAGE.Game;
using Newtonsoft.Json;
using CAPI = main_client.Ventura.Engine.Camera;
using AAPI = main_client.Ventura.Engine.Animation;
using PAPI = main_client.Ventura.Engine.Ped;

namespace main_client.Ventura.Engine
{
    class Card : Events.Script
    {
        public static Card instance = null;
        private long tick = 0;
        private string side = "";
        public bool update = false;
        private string data_name = main_client.Ventura.Constant.Constant.table_data_name[((int)main_client.Ventura.Constant.Constant.UpdateFlagsClient.WorldAttachData >> 2) - 1];

        public Card() {
            instance = this;
            Events.Add("setIDCharacter", setIDCharacter);
            Events.Add("setSelectIntroduction", setSelectIntroduction);
            Events.Tick += OnTick;
        }

        private void OnTick(List<Events.TickNametagData> nametags)
        {
            if (tick == 0)
                tick = DateTime.Now.AddMilliseconds(800).Ticks;
            if (DateTime.Now.Ticks > tick && update == true) {
                //Chat.Output("Open Open "+side);
                Events.CallRemote("IfPlayerCanEnter", side);
                tick = 0;
            }
        }

        private void setSelectIntroduction(object[] args)
        {
            Camera.ActiveMenuHud(true, true, true);
            update = true;
            side = args[0].ToString();
            Events.CallRemote("IfPlayerCanEnter", args[0].ToString());
            Events.CallLocal("destroyBrowser", "SelectIntro");
        }


        private void setIDCharacter(object[] args)
        {
            Events.CallLocal("destroyBrowser", "CardIdForm");

            Ventura.Utils.OTicks.instance.AddClockToInstance(new Utils.OClock(0, 0, 0, 100, () => {
                RAGE.Game.Cam.DoScreenFadeOut(100);
            }));
            Ventura.Utils.OTicks.instance.AddClockToInstance(new Utils.OClock(0, 0, 1, 0, () => {
                PAPI.PedGestion(1);
            }));
            Ventura.Utils.OTicks.instance.AddClockToInstance(new Utils.OClock(0, 0, 1, 800, () => {
                RAGE.Game.Cam.DoScreenFadeIn(100);
            }));
            var data = JsonConvert.DeserializeObject<List<StreamObject.WorldData.WorldAttachData>>((string)RAGE.Elements.Player.LocalPlayer.GetSharedData(data_name));

            if (data == null || data.Count == 0)
                return;
            data[0].IsAttached = false;
            Events.CallRemote("UpdateWorldAttachData", JsonConvert.SerializeObject(data));
            Utils.OTicks.instance.AddClockToInstance(new Utils.OClock(0, 0, 6, 0, () => {
                RAGE.Ui.Cursor.Visible = true;
                Events.CallLocal("createBrowser", "SelectIntro", "package://SelectIntro/index.html");
            }));
        }

        public void ActiveCardIdInput() {
            Events.CallLocal("createBrowser", "CardIdForm", "package://CardId/index.html");
            Events.CallLocal("executeFunction", "CardIdForm", "input");
            Constant.Constant.Notify("Ceci sera votre premiére ~p~carte d'identitée~w~");
            Constant.Constant.Notify("Pour comfirmer appuyer sur ~p~Valider~w~");
            Constant.Constant.Notify("~r~Attention :~w~");
            Constant.Constant.Notify("Une fois appuyer pas de comfirmation");
        }


    }
}
