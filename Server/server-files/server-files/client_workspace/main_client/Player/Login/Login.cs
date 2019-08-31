using System;
using System.Collections.Generic;
using System.Text;
using RAGE;

namespace main_client.Player.Login
{
    /*class Login : Events.Script
    {
        public Login() {
            Events.Add("login_form", login_form);
            Events.Add("login_event", login_event);
            Events.Add("login_execute", login_execute);
            Events.Add("destroy_login_form", destroy_login_form);
        }

        private void destroy_login_form(object[] args)
        {
            RAGE.Chat.Activate(true);
            RAGE.Chat.Show(true);
            RAGE.Ui.Cursor.Visible = false;
            Events.CallLocal("destroyBrowser", "log_form");
        }

        private void login_event(object[] args)
        {
            Events.CallRemote("save_password_player", (string)args[0]);
        }

        private void login_execute(object[] args)
        {
            int i = (int)args[0];
            Chat.Activate(true);
            Chat.Output("Debug");
            if (i == 0)
            {
                Events.CallLocal("executeFunction", "log_form", "AcceptLoginForm");

                Events.CallLocal("createBrowser", "UserInfo", "package://Life/index.html");
            } else
                Events.CallLocal("executeFunction", "log_form", "DeclineLoginForm");
        }

        private void login_form(object[] args)
        {
            Chat.Output("Created");
            Events.CallLocal("createBrowser", "log_form", "package://LoginPage/index.html");
            Chat.Activate(false);
            Chat.Show(false);
            RAGE.Ui.Cursor.Visible = true;
        }
    }*/
}
