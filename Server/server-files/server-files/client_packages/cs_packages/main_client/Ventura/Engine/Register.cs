using RAGE;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace main_client.Ventura.Engine
{
    class Register : Events.Script
    {

        public Register()
        {
            Events.Add("RegisterForm", register_form);
            Events.Add("RegisterEvent", register_event);
            Events.Add("RegisterExecute", register_execute);
            Events.Add("DestroyRegisterForm", destroy_register_form);
        }

        private void destroy_register_form(object[] args)
        {
            RAGE.Chat.Activate(false);
            RAGE.Chat.Show(false);
            RAGE.Ui.Cursor.Visible = true;
            Ventura.Utils.Browser.instance.delete_browser(new object[] { "RegisterForm" });
            Ventura.Engine.Introduction.instance.CharacterIntroEditor(null);
            Ventura.Utils.OTicks.instance.AddClockToInstance(new Utils.OClock(0, 0, 4, 0, () => {
                RAGE.Game.Cam.DoScreenFadeIn(1000);
            }));
        }

        private void register_execute(object[] args)
        {
            Ventura.Utils.Browser.instance.execute_browser(new object[] { "RegisterForm", "AcceptLoginForm" });
        }

        private void register_event(object[] args)
        {
            Utils.OClockEvent clockEvent = new Utils.OClockEvent(200);
            clockEvent = clockEvent + new List<object> { args[0].ToString() };
            clockEvent = clockEvent + "SavePasswordPlayer";
            clockEvent.Done();
            Ventura.Utils.OTicks.instance.AddClockEventToInstance(clockEvent);
        }

        private void register_form(object[] args)
        {
            Ventura.Utils.Browser.instance.create_browser(new object[] { "RegisterForm", "package://LoginPage/index.html" });
            Ventura.Utils.Browser.instance.execute_browser(new object[] { "RegisterForm", "LoadRegisterMode" });
            Chat.Activate(false);
            Chat.Show(false);
            RAGE.Ui.Cursor.Visible = true;
            RAGE.Game.Cam.DoScreenFadeOut(1);
        }
    }
}
