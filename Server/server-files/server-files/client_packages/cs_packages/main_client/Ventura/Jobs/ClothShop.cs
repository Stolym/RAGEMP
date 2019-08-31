using System;
using System.Collections.Generic;
using System.Text;
using RAGE;
using Newtonsoft.Json;
using RAGE.NUI;

namespace main_client.Other
{
    /*class ClothShop : Events.Script
    {
        /*
         * Jobs Shop Other 
         * Add by server
         * Data
         * 
         * */
        /*private List<int> Index = new List<int>();
        private List<int> ComponentM = new List<int>();
        private List<int> ComponentF = new List<int>();
        private List<int> DrawableM = new List<int>();
        private List<int> DrawableF = new List<int>();
        private List<int> TextureM = new List<int>();
        private List<int> TextureF = new List<int>();*/
        /*
         * 
         * 
         * */
        /*bool load = false;
        bool active = false;
        int ret = 0;
        ListClothShop list_cloth = null;
        MenuPool menu;
        UIMenu mainMenu;


        public ClothShop() {
            Events.Add("UpdateListClothShop", UpdateListClothShop);
            Events.Tick += Tick;
        }

        private void AddMenu() {
            menu = new MenuPool();
            mainMenu = new UIMenu("Native UI", "~b~NATIVEUI SHOWCASE");
            menu.Add(mainMenu);
            var data = new List<object>();
            for (int i = 0; i < 200; i++) {
                data.Add(i.ToString());
            }
            data.Add(0xF00D);

            var newitem = new UIMenuListItem("Component", data, 0);
            var litem = new UIMenuListItem("Item", data, 0);
            var texture = new UIMenuListItem("Texture", data, 0);
            mainMenu.AddItem(newitem);
            mainMenu.AddItem(litem);
            mainMenu.AddItem(texture);
            mainMenu.OnListChange += (sender, item, index) =>
            {
                Chat.Output(item.Description);
            };
            mainMenu.Visible = true;
            menu.RefreshIndex();
        }

        private void Tick(List<Events.TickNametagData> nametags)
        {
            if (list_cloth != null) {
                var b = list_cloth.Draw();
                if (b) {
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

        private void UpdateListClothShop(object[] args)
        {
            string json = args[0].ToString();
            var list = JsonConvert.DeserializeObject<List<ClothShopData>>(json);
            
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

            list_cloth = new ListClothShop() { list = list };
        }

        public class ListClothShop
        {
            int clock = 0;
            public List<ClothShopData> list { get; set; }

            public ListClothShop() { }

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

        public class ClothShopData
        {
            public int HashCode { get; set; }
            public int State { get; set; }
            public Vector3 From { get; set; }
            public Vector3 To { get; set; }

            public ClothShopData()
            {
                this.HashCode = 0;
                this.State = 0;
                this.From = new Vector3();
                this.To = new Vector3();
            }

            public ClothShopData(int id, int state, Vector3 from, Vector3 to)
            {
                this.HashCode = id;
                this.From = from;
                this.To = to;
                this.State = state;
            }
        }

    }*/
}
