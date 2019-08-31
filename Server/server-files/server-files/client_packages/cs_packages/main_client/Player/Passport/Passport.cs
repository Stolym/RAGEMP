using System;
using System.Collections.Generic;
using System.Text;
using RAGE;

namespace main_client.Player.Passport
{
    /*class Passport : Events.Script
    {
        bool active = false;
        int clock = 0;

        public Passport()
        {
            Events.Add("DisplayIdCard", DisplayIdCard);
            Events.Tick += Tick;
        }

        private void Tick(List<Events.TickNametagData> nametags)
        {
            if (RAGE.Input.IsDown((int)ConsoleKey.Backspace) && clock == 0) {

                Events.CallLocal("destroyBrowser", "card_id", "package://IdCard/index.html");
                clock++;
            }
            else if (clock != 0 && clock <= 80)
                clock++;
            else if (clock >= 80)
                clock = 0;
        }

        private void DisplayIdCard(object[] args)
        {
            Chat.Output("Salut");
            Events.CallLocal("createBrowser", "card_id", "package://IdCard/index.html");
            Events.CallLocal("executeFunction", "card_id", "display", args[0].ToString());
        }
    }*/
}
