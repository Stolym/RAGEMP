using System;
using System.Collections.Generic;
using RAGE;
using System.Text;

namespace main_client.Ventura.Engine
{
    class Login : Events.Script
    {
        public Login()
        {
            Events.Add("LoginForm", login_form);
            Events.Add("LoginEvent", login_event);
            Events.Add("LoginExecute", login_execute);
            //Events.Add("DestroyLoginForm", destroy_Login_form);
        }



        private void destroy_Login_form(object[] args)
        {
            RAGE.Chat.Activate(true);
            RAGE.Chat.Show(true);
            RAGE.Ui.Cursor.Visible = false;
            Ventura.Utils.Browser.instance.delete_browser(new object[] { "LoginForm" });
        }

        private void login_execute(object[] args)
        {
            int i = (int)args[0];

            if (i == 0)
            {
                Ventura.Utils.OTicks.instance.AddClockToInstance(new Utils.OClock(0, 0, 0, 100, () => {
                    Ventura.Utils.Browser.instance.execute_browser(new object[] { "LoginForm", "AcceptLoginForm" });
                }));
                Ventura.Utils.OTicks.instance.AddClockToInstance(new Utils.OClock(0, 0, 2, 0, () => {
                    Ventura.Engine.Vocal.instance.ConnectTeamspeak(new object[] { RAGE.Elements.Player.LocalPlayer.RemoteId.ToString() });
                    Ventura.Engine.Interaction.InteractPlayer.instance.InteractionActive(null);
                    destroy_Login_form(null);
                    RAGE.Game.Cam.DoScreenFadeIn(3000);
                    Constant.Constant.Notify("You are connected to the server :) Enjoy yourself !");
                }));
            }
            else
            {
                Ventura.Utils.OTicks.instance.AddClockToInstance(new Utils.OClock(0, 0, 0, 100, () => {
                    Ventura.Utils.Browser.instance.execute_browser(new object[] { "LoginForm", "DeclineLoginForm" });
                }));
            }
        }

        private void login_event(object[] args)
        {
            Utils.OClockEvent clockEvent = new Utils.OClockEvent(200);
            clockEvent = clockEvent + new List<object> { args[0].ToString() };
            clockEvent = clockEvent + "CheckPassword";
            clockEvent.Done();
            Ventura.Utils.OTicks.instance.AddClockEventToInstance(clockEvent);
        }

        private void login_form(object[] args)
        {
            Chat.Activate(false);
            Chat.Show(false);
            RAGE.Ui.Cursor.Visible = true;
            Ventura.Utils.Browser.instance.create_browser(new object[] { "LoginForm", "package://LoginPage/index.html" });
            RAGE.Game.Cam.DoScreenFadeOut(1);
        }
    }
}
