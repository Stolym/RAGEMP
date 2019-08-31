using System;
using System.Collections.Generic;
using System.Text;

using RAGE;
using RAGE.NUI;
//using Newtonsoft.Json;


namespace main_client.Other
{
    /*class BarberShop : Events.Script
    {
        bool load = false;
        bool active = false;
        int ret = 0;
        ListBarberShop list_cloth = null;
        MenuPool menu;
        UIMenu mainMenu;

        public BarberShop()
        {
            Events.Add("UpdateListBarberShopJson", UpdateListBarberShop);
            Events.Tick += Tick;
        }

        private void AddMenu()
        {
            menu = new MenuPool();
            mainMenu = new UIMenu("Native UI", "~b~NATIVEUI SHOWCASE");
            menu.Add(mainMenu);

            mainMenu.AddItem(new UIMenuItem("Water"));
            mainMenu.AddItem(new UIMenuItem("Burger"));
            mainMenu.AddItem(new UIMenuItem("Sim"));
            mainMenu.AddItem(new UIMenuItem("Phone"));
            mainMenu.AddItem(new UIMenuItem("Clope"));
            mainMenu.OnListChange += (sender, item, index) =>
            {
                Chat.Output(item.Description);
            };
            mainMenu.Visible = true;
            menu.RefreshIndex();
        }

        private void Tick(List<Events.TickNametagData> nametags)
        {
            if (list_cloth != null)
            {
                var b = list_cloth.Draw();
                if (b)
                {
                    active = !active;
                    if (active)
                        mainMenu.Visible = true;
                }
                if (active)
                {
                    menu.ProcessMenus();
                    menu.Draw();
                    RAGE.Elements.Player.LocalPlayer.FreezePosition(true);
                    ret = 0;
                }
                else if (!active && ret == 0)
                {
                    mainMenu.Visible = false;
                    RAGE.Elements.Player.LocalPlayer.FreezePosition(false);
                    ret++;
                }
            }

        }

        private void UpdateListBarberShop(object[] args)
        {
            string json = args[0].ToString();
            var list = JsonConvert.DeserializeObject<List<BarberShopJson>>(json);

            if (list == null)
                return;
            if (!load)
            {
                AddMenu();
                load = true;
            }
            foreach (var i in list)
            {
                Chat.Output(i.id.ToString());
            }

            list_cloth = new ListBarberShop() { list = list };
        }
    }

    public class ListBarberShop
    {
        int clock = 0;
        public List<BarberShopJson> list { get; set; }

        public ListBarberShop() { }

        public bool Draw()
        {
            foreach (var vshop in list)
            {
                //Chat.Output("vshop " + vshop.id + " "+ RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(new Vector3(vshop.from.X, vshop.from.Y, vshop.from.Z)));
                if (RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(new Vector3(vshop.from.X, vshop.from.Y, vshop.from.Z)) < 100f)
                {
                    RAGE.Game.Graphics.DrawMarker(1, vshop.from.X, vshop.from.Y, vshop.from.Z, 0, 0, 0, 0, 0, 0, 1, 1, 1, 23, 235, 2, 255, false, false, 0, false, "", "", false);
                    if (RAGE.Input.IsDown((int)ConsoleKey.E) && clock == 0 && (RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(new Vector3(vshop.from.X, vshop.from.Y, vshop.from.Z)) < 8f || RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(new Vector3(vshop.to.X, vshop.to.Y, vshop.to.Z)) < 8f))
                    {
                        RAGE.Elements.Player.LocalPlayer.Position = new Vector3(vshop.to.X, vshop.to.Y, vshop.to.Z);
                        clock++;
                        return (true);
                    }
                    else if (clock < 80)
                        clock++;
                    else if (clock >= 80)
                        clock = 0;
                    RAGE.Game.Graphics.DrawBox(vshop.from.X, vshop.from.Y, vshop.from.Z, vshop.from.X + 1, vshop.from.Y + 1, vshop.from.Z + 1, 0, 0, 255, 255);
                    RAGE.Game.Graphics.DrawBox(vshop.to.X, vshop.to.Y, vshop.to.Z, vshop.to.X + 1, vshop.to.Y + 1, vshop.to.Z + 1, 0, 0, 255, 255);
                }
            }
            return (false);
        }

    }

    public class BarberShopJson
    {
        public int id { get; set; }
        public int state { get; set; }
        public Vector3 from { get; set; }
        public Vector3 to { get; set; }

        public BarberShopJson() { }
    }*/
}
