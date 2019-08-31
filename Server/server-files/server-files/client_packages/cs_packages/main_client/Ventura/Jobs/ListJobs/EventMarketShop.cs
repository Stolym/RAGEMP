using System;
using System.Collections.Generic;
using System.Text;
using main_client.Ventura.Jobs.JobsData;
using RAGE;

namespace main_client.Ventura.Jobs.ListJobs
{
    public class EventMarketShop : Events.Script
    {
        public static EventMarketShop instance = null;
        private float distance = 10f;
        private byte state = 0x00;
        private long ticks = 0;


        public EventMarketShop() { instance = this; }


        public void DebugDrawing(MarketShopData data)
        {
            RAGE.Game.Graphics.DrawBox(data.From.X, data.From.Y, data.From.Z, data.From.X + 1, data.From.Y + 1, data.From.Z + 1, 0, 0, 255, 255);
            RAGE.Game.Graphics.DrawBox(data.To.X, data.To.Y, data.To.Z, data.To.X + 1, data.To.Y + 1, data.To.Z + 1, 0, 255, 0, 255);
        }

        public void ActiveEvent(MarketShopData data)
        {
            RAGE.Elements.Player.LocalPlayer.Position = new Vector3(data.To.X, data.To.Y, data.To.Z);
            RAGE.Elements.Player.LocalPlayer.FreezePosition(true);
        }


        public void DesactiveEvent(MarketShopData data)
        {
            RAGE.Elements.Player.LocalPlayer.Position = new Vector3(data.From.X, data.From.Y, data.From.Z);
            RAGE.Elements.Player.LocalPlayer.FreezePosition(false);
        }


        public void StartClock()
        {
            if (ticks == 0)
                ticks = DateTime.Now.AddMilliseconds(200).Ticks;
        }


        public void Draw(MarketShopData obj = null)
        {
            StartClock();
            if (obj == null)
                return;
            if (Delta.JobsEvent.instance != null && Delta.JobsEvent.instance.Debug)
                DebugDrawing(obj);
            if (CheckIfBindKeyEvent(obj))
                KeyEvent(obj);
        }

        private bool CheckIfBindKeyEvent(MarketShopData data)
        {
            if (RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(new Vector3(data.From.X, data.From.Y, data.From.Z)) < distance)
                return true;
            else if (RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(new Vector3(data.To.X, data.To.Y, data.To.Z)) < distance)
                return true;
            return false;
        }

        private void KeyEvent(MarketShopData data)
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
