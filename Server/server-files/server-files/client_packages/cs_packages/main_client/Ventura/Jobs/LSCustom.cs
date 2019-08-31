using System;
using System.Collections.Generic;
using System.Text;
using RAGE;
using RAGE.NUI;
//using Newtonsoft.Json;

namespace main_client.Other
{
    /*class LSCustom : Events.Script
    {
        bool load = false;
        bool active = false;
        int ret = 0;
        int timer = 0;
        MenuPool menu;
        UIMenu mainMenu;

        List<string> name = new List<string>() {
              "Component",
            "Index",
            "WheelType",
            "Color1",
            "Color2",
            "WindowTint",
            "PColor10",
            "PColor11",
            "PColor12",
            "PColor20",
            "PColor21",
            "PColor22",
            "DColor",
            "ModPaintType10",
            "ModPaintType11",
            "ModPaintType2",
            "InteriorColor",
            "PearlescentColor",
            "WheelColor",
        };
        Dictionary<string, int> self = new Dictionary<string, int>() {
            { "Component", 0 },
            { "Index", 0 },
            { "WheelType", 0 },
            { "Color1", 0 },
            { "Color2", 0 },
            { "WindowTint", 0 },
            { "PColor10", 0 },
            { "PColor11", 0 },
            { "PColor12", 0 },
            { "PColor20", 0 },
            { "PColor21", 0 },
            { "PColor22", 0 },
            { "DColor", 0 },
            { "ModPaintType10", 0 },
            { "ModPaintType11", 0 },
            { "ModPaintType2", 0 },
            { "InteriorColor", 0 },
            { "PearlescentColor", 0 },
            { "WheelColor", 0 },
        };

        public LSCustom()
        {
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
            for (int i = 0; i < name.Count; i++)
            {
                var newitem = new UIMenuListItem(name[i], data, 0);
                mainMenu.AddItem(newitem);
            }
            mainMenu.OnListChange += (sender, item, index) =>
            {
                int veh = RAGE.Game.Vehicle.GetClosestVehicle(RAGE.Elements.Player.LocalPlayer.Position.X, RAGE.Elements.Player.LocalPlayer.Position.Y, RAGE.Elements.Player.LocalPlayer.Position.Z, 10, 0, 70);
                self[item.Text] = index;
                if (veh != 0) {

                    for (int i = 0; i < 9; i++)
                        RAGE.Game.Vehicle.SetVehicleExtra(veh, i, true);

                    RAGE.Game.Vehicle.SetVehicleColours(veh, self["Color1"], self["Color2"]);
                    RAGE.Game.Vehicle.SetVehicleMod(veh, self["Component"], self["Index"], true);

                    RAGE.Game.Vehicle.SetVehicleIndicatorLights(veh, 1, true);
                    RAGE.Game.Vehicle.SetVehicleInteriorlight(veh, true);

                    //RAGE.Game.Vehicle.SetVehicleInteriorColour(veh, self["InteriorColor"]);
                    //RAGE.Game.Invoker.Invoke(0xb7635e80a5c31bff, self["InteriorColor"]);
                    RAGE.Game.Invoker.Invoke(0x2036F561ADD12E33, self["PearlescentColor"], self["WheelColor"]); // extra color

                    RAGE.Game.Vehicle.SetVehicleCustomPrimaryColour(veh, self["PColor10"], self["PColor11"], self["PColor12"]);
                    RAGE.Game.Vehicle.SetVehicleCustomSecondaryColour(veh, self["PColor20"], self["PColor21"], self["PColor22"]);
                    //RAGE.Game.Vehicle.SetVehicleDashboardColour(veh, self["DColor"]);
                    RAGE.Game.Vehicle.SetVehicleModColor1(veh, self["ModPaintType10"], self["ModPaintType11"], 0);
                    RAGE.Game.Vehicle.SetVehicleModColor2(veh, self["ModPaintType2"], 0);

                    RAGE.Game.Vehicle.SetVehicleWheelType(veh, self["WheelType"]);
                    RAGE.Game.Vehicle.SetVehicleWindowTint(veh, self["WindowTint"]);
                }
            }; 
            mainMenu.Visible = true;
            menu.RefreshIndex();
        }

        private void OnItemSelect(UIMenu sender, UIMenuItem selectedItem, int index)
        {
            Events.CallRemote("AddItemUser", selectedItem.Text);
        }


        private void Tick(List<Events.TickNametagData> nametags)
        {
            if (RAGE.Input.IsDown((int)ConsoleKey.NumPad0) && timer == 0)
            {
                active = !active;
                timer++;
            }
            else if (timer != 0 && timer < 40)
                timer++;
            else if (timer >= 40)
                timer = 0;
            if (!load)
            {
                AddMenu();
                load = true;
            }
            if (active)
            {
                if (mainMenu.Visible == false)
                    mainMenu.Visible = true;
                menu.ProcessMenus();
                menu.Draw();
            }
        }
        
    }*/
}
