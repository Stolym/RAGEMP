using System;
using System.Collections.Generic;
using System.Text;
using RAGE;
using RAGE.NUI;

namespace main_client.Jobs.PoleEmploi
{
    /*class PoleEmploi : Events.Script
    {
        bool[] active = new bool[3] { false, false, false };

        UIMenu menu = null;


        public PoleEmploi() {
            Events.Add("enable_jobs_nui", jobs_nui);
            Events.Tick += jobs_tick;
        }

        private void jobs_nui(object[] args)
        {
            active[1] = (bool)args[0];
            active[2] = false;
        }

        void load_menu() {
            Chat.Output("Init");
            menu = new UIMenu("Pole Emplois", "Jobs", new System.Drawing.Point(50, 50));
            menu.AddItem(new UIMenuItem("Vitreur"));
            menu.AddItem(new UIMenuItem("Electricien"));
            //menu.AddItem(new UIMenuItem("Mineur"));
            menu.SetKey(UIMenu.MenuControls.Down, System.Windows.Forms.Keys.Down);
            menu.Visible = true;
            menu.OnItemSelect += item_select;
        }

        private void item_select(UIMenu sender, UIMenuItem selectedItem, int index)
        {
            Chat.Output(selectedItem.Text);
            Events.CallRemote("update_jobs", selectedItem.Text);
        }

        private void jobs_tick(List<Events.TickNametagData> nametags)
        {
            /*if (active[0] == false) {
                load_menu();
                active[0] = !active[0];
            }
            if (RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(new Vector3(112.3239f, -752.4673f, 45.75479f)) > 10f && active[2] == true)
                Events.CallRemote("check_pole_pos");
            if (RAGE.Input.IsDown((int)ConsoleKey.M) && active[2] == false) {
                Events.CallRemote("check_pole_pos");
                active[2] = !active[2];
            }
            if (active[1] == true)
            {
                menu.Draw();
                menu.ProcessKey(System.Windows.Forms.Keys.Down);
            }
        }
    }*/
}
