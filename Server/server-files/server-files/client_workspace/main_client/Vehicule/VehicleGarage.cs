using System;
using System.Collections.Generic;
using System.Text;
using RAGE;
//using Newtonsoft.Json;
using RAGE.NUI;


namespace main_client.Vehicule
{
    /*class VehicleGarage : Events.Script
    {
        bool load = false;
        bool active = false;
        int ret = 0;
        ListGarage list_garage = null;
        MenuPool menu;
        UIMenu mainMenu;

        public VehicleGarage()
        {
            Events.Add("UpdateListGarageJson", UpdateListClothShop);
            Events.Tick += Tick;
        }

        private void AddMenu()
        {
            menu = new MenuPool();
            mainMenu = new UIMenu("Native UI", "~b~NATIVEUI SHOWCASE");
            menu.Add(mainMenu);
            var data = new List<object>();
            for (int i = 0; i < 200; i++)
            {
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
            if (list_garage != null)
            {
                var b = list_garage.Draw();
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

        private void UpdateListClothShop(object[] args)
        {
            string json = args[0].ToString();
            var list = JsonConvert.DeserializeObject<List<GarageJson>>(json);

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

            list_garage = new ListGarage() { list = list };
        }

        public class ListGarage
        {
            int clock = 0;
            public List<GarageJson> list { get; set; }

            public ListGarage() { }

            public bool Draw()
            {
                foreach (var vshop in list)
                {
                    //Chat.Output("vshop " + vshop.id + " "+ RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(new Vector3(vshop.from.X, vshop.from.Y, vshop.from.Z)));
                    if (RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(new Vector3(vshop.from.X, vshop.from.Y, vshop.from.Z)) < 100f)
                    {
                        if (RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(new Vector3(vshop.to.X, vshop.to.Y, vshop.to.Z)) < 8f && RAGE.Elements.Player.LocalPlayer.IsInAnyVehicle(true)) {
                            Events.CallRemote("StorageVehicleRemoteId", RAGE.Elements.Entities.Vehicles.All.Find(x => x.Handle == RAGE.Elements.Player.LocalPlayer.GetVehicleIsUsing()).RemoteId);
                        }
                        if (RAGE.Input.IsDown((int)ConsoleKey.E) && clock == 0 && (RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(new Vector3(vshop.from.X, vshop.from.Y, vshop.from.Z)) < 8f))
                        {
                            //RAGE.Elements.Player.LocalPlayer.Position = new Vector3(vshop.to.X, vshop.to.Y, vshop.to.Z);
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

        public class GarageJson
        {
            public int id { get; set; }
            public int state { get; set; }
            public Vector3 from { get; set; }
            public Vector3 to { get; set; }

            public GarageJson() { }
        }
    }*/
}
