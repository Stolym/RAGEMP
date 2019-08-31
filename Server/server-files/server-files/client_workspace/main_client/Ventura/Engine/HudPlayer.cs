using System;
using System.Collections.Generic;
using System.Text;
using RAGE;

namespace main_client.Ventura.Engine
{
    class HudPlayer : Events.Script
    {
        public static HudPlayer instance = null;
        private long tick = 0;
        public bool active = false;

        public HudPlayer()
        {
            if (instance == null)
                instance = this;
            Events.Add("ReceiveCommandHUDPlayer", ReceiveCommandHUDPlayer);
            Events.Tick += OnTick;
        }

        private void ReceiveCommandHUDPlayer(object[] args)
        {
            string json = (string)args[0];
            Events.CallLocal("executeFunction", "HUDForm", "set_values", json);
        }

        void SetClock(double ms)
        {
            if (tick == 0)
                tick = DateTime.Now.AddMilliseconds(ms).Ticks;
        }

        public void OpenHUD()
        {
            Events.CallLocal("createBrowser", "HUDForm", "package://HudPlayer/index.html");
        }


        public void CloseHUD()
        {
            Events.CallLocal("destroyBrowser", "HUDForm");
        }


        public void CheckAndSendSpeedometer()
        {
            int veh = RAGE.Game.Ped.GetVehiclePedIsIn(RAGE.Elements.Player.LocalPlayer.Handle, false);

            if (veh == 0)
                return;
            Events.CallLocal("executeFunction", "HUDForm", "set_vehicle_speed", (int)RAGE.Elements.Entities.Vehicles.All.Find(x => x.Handle == veh).GetSpeed());
        }

        public void CheckAndSendGazol()
        {
            int veh = RAGE.Game.Ped.GetVehiclePedIsIn(RAGE.Elements.Player.LocalPlayer.Handle, false);

            if (veh == 0)
                return;
            //Events.CallLocal("executeFunction", "HUDForm", "set_vehicle_gazol", (int)RAGE.Elements.Entities.Vehicles.All.Find(x => x.Handle == veh).GetSpeed());
        }

        private void OnTick(List<Events.TickNametagData> nametags)
        {
            SetClock(100);

            if (active) {
                CheckAndSendSpeedometer();
                CheckAndSendGazol();
            }

            /*if (Input.IsDown((int)ConsoleKey.LeftArrow) && DateTime.Now.Ticks > tick)
            {

                RAGE.Ui.Cursor.Visible = false;
                OpenHUD();
                tick = 0;
                active = true;
            }*/
        }
    }
}
