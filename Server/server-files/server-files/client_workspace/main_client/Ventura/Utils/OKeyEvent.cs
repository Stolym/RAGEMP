using System;
using System.Collections.Generic;
using System.Text;
using RAGE;

namespace main_client.Ventura.Utils
{
    class OKeyEvent :  Events.Script
    {
        public static OKeyEvent instance { get; set; }
        private long tick { get; set; }
        private int time { get; set; }
        private int iterator { get; set; }
        private List<bool> BrowserActives { get; set;  }

        public OKeyEvent() {
            instance = this;
            tick = 0;
            time = 500;
            iterator = 0;
            BrowserActives = new List<bool>() { false };
        }

        public void OnTickKeyEvent() {
            StartClock();


            if (Input.IsDown((int)ConsoleKey.F7) && new DateTime(DateTime.Now.Ticks - tick).Millisecond > time)
            {
                for (int i = 0; i < 500; i++)
                {
                    RAGE.Game.Ped.SetPedConfigFlag(RAGE.Elements.Player.LocalPlayer.Handle, i, false);
                }
                for (int i = iterator * 10 + 200; i < iterator * 10 + 210; i++)
                {
                    RAGE.Game.Ped.SetPedConfigFlag(RAGE.Elements.Player.LocalPlayer.Handle, i, true);
                }
                iterator++;
                Ventura.Utils.OTicks.instance.AddClockToInstance(new OClock(0, 0, 0, 200, () =>
                {
                    RAGE.Elements.Player.LocalPlayer.SetCombatMovement(2);
                    RAGE.Elements.Player.LocalPlayer.SetCombatFloat(14, 1);
                    RAGE.Elements.Player.LocalPlayer.SetCombatRange(20);
                    //RAGE.Elements.Player.LocalPlayer.TaskPutDirectlyIntoMelee(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == 1).Handle, 0, -1, 0f, false);
                    //RAGE.Elements.Player.LocalPlayer.TaskCombat(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == 1).Handle, 1, 1);
                    //RAGE.Game.Ai.TaskCombatPed(RAGE.Elements.Player.LocalPlayer.Handle,RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == 1).Handle, 0, 16);

                }));
                Ventura.Utils.OTicks.instance.AddClockToInstance(new OClock(0, 0, 5, 0, () =>
                {
                }));
                tick = 0;
            }

            if (Input.IsDown((int)ConsoleKey.F8) && new DateTime(DateTime.Now.Ticks - tick).Millisecond > time)
            {
                if (BrowserActives[0])
                {
                    Browser.instance.delete_browser(new object[] { "DebugForm" });
                    RAGE.Ui.Cursor.Visible = false;
                    BrowserActives[0] = false;
                }
                else
                {
                    Browser.instance.create_browser(new object[] { "DebugForm", "package://Option/index.html" });
                    RAGE.Ui.Cursor.Visible = true;
                    BrowserActives[0] = true;
                }
                tick = 0;
            }

        }

        private void StartClock()
        {
            if (tick == 0)
                tick = DateTime.Now.AddMilliseconds(time).Ticks;
        }
    }
}
