using System;
using System.Collections.Generic;
using System.Text;
//using Newtonsoft.Json;
using RAGE;

namespace main_client.Player.Inventory
{
    /*class Inventory : Events.Script
    {
        int clock = 0;
        bool open = false;

        public Inventory() {
            Events.Add("ChangeOpenInventory", ChangeOpenInventory);
            Events.Add("CallActionCEFtoClientInventory", CallActionCEFtoClientInventory);
            Events.Tick += Tick;
        }

        private void CallActionCEFtoClientInventory(object[] args)
        {
            Chat.Output(args[0].ToString() +" "+Convert.ToInt32(args[1]).ToString());
        }

        private void ChangeOpenInventory(object[] args)
        {
            open = (bool)args[0];
        }

        void open_menu()
        {
            if (Input.IsDown((int)ConsoleKey.DownArrow) && clock == 0)
            {
                if (open)
                {
                    Events.CallLocal("destroyBrowser", "inventory_form");
                    RAGE.Ui.Cursor.Visible = false;
                    open = false;
                }
                clock++;
            }
            else if (clock != 0 && clock <= 80)
                clock++;
            else if (clock >= 80)
                clock = 0;
        }



        private void Tick(List<Events.TickNametagData> nametags)
        {
            if (open) {
                open_menu();
            }
        }
    }*/
}
