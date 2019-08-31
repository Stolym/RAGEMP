using System;
using System.Collections.Generic;
using System.Text;
using main_client.Ventura.Jobs.JobsData;
using RAGE;

namespace main_client.Ventura.Jobs.ListJobs
{
    public class EventConcessAutomatic : Events.Script
    {
        public static EventConcessAutomatic instance = null;
        private float distance = 10f;
        private byte state = 0x00;
        private long ticks = 0;


        public EventConcessAutomatic() { instance = this; }


        public void DebugDrawing(ConcessShopData data)
        {
            RAGE.Game.Graphics.DrawBox(data.UI.X, data.UI.Y, data.UI.Z, data.UI.X + 1, data.UI.Y + 1, data.UI.Z + 1, 0, 0, 255, 255);
            RAGE.Game.Graphics.DrawBox(data.Spawn.X, data.Spawn.Y, data.Spawn.Z, data.Spawn.X + 1, data.Spawn.Y + 1, data.Spawn.Z + 1, 0, 0, 255, 255);
            //RAGE.Game.Graphics.DrawBox(data.To.X, data.To.Y, data.To.Z, data.To.X + 1, data.To.Y + 1, data.To.Z + 1, 0, 255, 0, 255);
        }

        public void ActiveEvent(ConcessShopData data)
        {
            Utils.Browser.instance.create_browser(new object[] { "ConcessAutomaticForm", "package://ConcessAutomatic/index.html" });
            RAGE.Elements.Player.LocalPlayer.FreezePosition(true);
        }


        public void DesactiveEvent(ConcessShopData data)
        {
            Utils.Browser.instance.delete_browser(new object[] { "ConcessAutomaticForm" });
            RAGE.Elements.Player.LocalPlayer.FreezePosition(false);
        }


        public void StartClock()
        {
            if (ticks == 0)
                ticks = DateTime.Now.AddMilliseconds(200).Ticks;
        }


        public void Draw(ConcessShopData obj = null)
        {
            StartClock();
            if (obj == null)
                return;
            if (Delta.JobsEvent.instance != null && Delta.JobsEvent.instance.Debug)
                DebugDrawing(obj);
            if (CheckIfBindKeyEvent(obj))
                KeyEvent(obj);
        }

        private bool CheckIfBindKeyEvent(ConcessShopData data)
        {
            if (RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(new Vector3(data.UI.X, data.UI.Y, data.UI.Z)) < distance)
                return true;
            return false;
        }

        private void KeyEvent(ConcessShopData data)
        {
            if (RAGE.Input.IsDown((int)ConsoleKey.E) && DateTime.Now.Ticks > ticks)
            {
                switch (state)
                {
                    case 0x00:
                        ActiveEvent(data);
                        state++;
                        break;
                    case 0x01:
                        DesactiveEvent(data);
                        state = 0x00;
                        break;
                    case 0x02:
                        break;
                    case 0x03:
                        break;
                    case 0x04:
                        break;
                }
                ticks = 0;
            }
        }
    }
}
