using System;
using System.Collections.Generic;
using System.Text;
using RAGE;
using RAGE.NUI;

namespace main_client.Player.Cloth
{
    /*class Cloth : Events.Script
    {
        UIMenu menu = null;
        bool[] active = new bool[3] { false, false, false };
        int a, b, c;
        int time = 0;

        public Cloth() {
            Events.Add("enable_menu_cloth", enable_menu_cloth);
            Events.Tick += tick;
        }

        private void enable_menu_cloth(object[] args)
        {
            active[1] = (bool)args[0];
        }

        void make_menu() {
            a = 0;
            b = 0;
            c = 0;
            menu = new UIMenu("Cloth", "choose");
            //menu.AddItem(new UIMenuItem("Mineur"));
            menu.SetKey(UIMenu.MenuControls.Down, System.Windows.Forms.Keys.Down);
            menu.Visible = true;
            menu.OnItemSelect += item_select;
        }

        private void item_select(UIMenu sender, UIMenuItem selectedItem, int index)
        {
        }

        private void tick(List<Events.TickNametagData> nametags)
        {
            if (active[0] == false) {
                make_menu();
                active[0] = true;
            }
            if (time != 0)
                time++;
            if (time >= 100)
                time = 0;
            if (active[1] && time == 0)
            {
                if (RAGE.Input.IsDown((int)ConsoleKey.K))
                {
                    a++;
                    Events.CallRemote("change_cloth", a, b, c);
                }
                if (RAGE.Input.IsDown((int)ConsoleKey.J))
                {
                    a--;
                    Events.CallRemote("change_cloth", a, b, c);
                }
                if (RAGE.Input.IsDown((int)ConsoleKey.I))
                {
                    b++;
                    Events.CallRemote("change_cloth", a, b, c);
                }
                if (RAGE.Input.IsDown((int)ConsoleKey.U))
                {
                    b--;
                    Events.CallRemote("change_cloth", a, b, c);
                }
                if (RAGE.Input.IsDown((int)ConsoleKey.N))
                {
                    c++;
                    Events.CallRemote("change_cloth", a, b, c);
                }
                if (RAGE.Input.IsDown((int)ConsoleKey.B))
                {
                    c--;
                    Events.CallRemote("change_cloth", a, b, c);
                }
                time++;
            }
            
        }
    }*/
}
