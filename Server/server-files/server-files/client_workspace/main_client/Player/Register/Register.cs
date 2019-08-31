using RAGE;
using System;
using System.Collections.Generic;
using System.Text;

namespace main_client.Player.Register
{
    /*class Register : Events.Script
    {
        public Register()
        {
            Events.Add("register_form", register_form);
            Events.Add("register_event", register_event);
            Events.Add("register_execute", register_execute);
            Events.Add("destroy_register_form", destroy_register_form);
        }

        private void destroy_register_form(object[] args)
        {
            RAGE.Chat.Activate(true);
            RAGE.Chat.Show(true);
            RAGE.Ui.Cursor.Visible = true;
            Events.CallLocal("destroyBrowser", "register_form");
        }

        private void register_execute(object[] args)
        {
            Events.CallLocal("executeFunction", "register_form", "AcceptLoginForm");

        }

        private void register_event(object[] args)
        {
            Chat.Output("Debug Password " + (string)args[0]);
            Events.CallRemote("save_password_player", (string)args[0]);
            Events.CallLocal("CharacterIntro");
        }

        private void register_form(object[] args)
        {
            Events.CallLocal("createBrowser", "register_form", "package://LoginPage/index.html");
            Events.CallLocal("executeFunction", "register_form", "LoadRegisterMode");
            Chat.Activate(false);
            Chat.Show(false);
            RAGE.Ui.Cursor.Visible = true;
        }
    }*/
}
