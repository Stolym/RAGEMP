using System;
using System.Collections.Generic;
using System.Text;

using main_client.Ventura.Jobs.JobsData;
using RAGE;

namespace main_client.Ventura.Jobs.ListJobs
{
    class EventFish : Events.Script
    {
        public static EventFish instance = null;
        private float distance = 10f;
        private byte state = 0x00;
        private long ticks = 0;

        public EventFish() { instance = this; }


        public void DebugDrawing(FishData data)
        {
            RAGE.Game.Graphics.DrawBox(data.Inside.X, data.Inside.Y, data.Inside.Z, data.Inside.X + 1, data.Inside.Y + 1, data.Inside.Z + 1, 0, 0, 255, 255);
            RAGE.Game.Graphics.DrawBox(data.Out.X, data.Out.Y, data.Out.Z, data.Out.X + 1, data.Out.Y + 1, data.Out.Z + 1, 0, 255, 0, 255);
            RAGE.Game.Graphics.DrawBox(data.CoffrePosition.X, data.CoffrePosition.Y, data.CoffrePosition.Z, data.CoffrePosition.X + 1, data.CoffrePosition.Y + 1, data.CoffrePosition.Z + 1, 0, 0, 255, 255);
            RAGE.Game.Graphics.DrawBox(data.ComputerPosition.X, data.ComputerPosition.Y, data.ComputerPosition.Z, data.ComputerPosition.X + 1, data.ComputerPosition.Y + 1, data.ComputerPosition.Z + 1, 0, 255, 0, 255);
            RAGE.Game.Graphics.DrawBox(data.GetService.X, data.GetService.Y, data.GetService.Z, data.GetService.X + 1, data.GetService.Y + 1, data.GetService.Z + 1, 0, 0, 255, 255);
            RAGE.Game.Graphics.DrawBox(data.ScriptPaintPosition.X, data.ScriptPaintPosition.Y, data.ScriptPaintPosition.Z, data.ScriptPaintPosition.X + 1, data.ScriptPaintPosition.Y + 1, data.ScriptPaintPosition.Z + 1, 0, 255, 0, 255);
            RAGE.Game.Graphics.DrawBox(data.ZonePaintPosition.X, data.ZonePaintPosition.Y, data.ZonePaintPosition.Z, data.ZonePaintPosition.X + 1, data.ZonePaintPosition.Y + 1, data.ZonePaintPosition.Z + 1, 0, 255, 0, 255);
        }

        public void ActiveEvent(FishData data)
        {
        }


        public void DesactiveEvent(FishData data)
        {
        }


        public void StartClock()
        {
            if (ticks == 0)
                ticks = DateTime.Now.AddMilliseconds(200).Ticks;
        }


        public void Draw(FishData obj = null)
        {
            StartClock();
            if (obj == null)
                return;
            if (Delta.JobsEvent.instance != null && Delta.JobsEvent.instance.Debug)
                DebugDrawing(obj);
            if (CheckIfBindKeyEvent(obj))
                KeyEvent(obj);
        }

        private bool CheckIfBindKeyEvent(FishData data)
        {
            if (RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(new Vector3(data.Out.X, data.Out.Y, data.Out.Z)) < distance)
                return true;
            else if (RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(new Vector3(data.Inside.X, data.Inside.Y, data.Inside.Z)) < distance)
                return true;
            else if (RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(new Vector3(data.GetService.X, data.GetService.Y, data.GetService.Z)) < distance)
                return true;
            else if (RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(new Vector3(data.ScriptPaintPosition.X, data.ScriptPaintPosition.Y, data.ScriptPaintPosition.Z)) < distance)
                return true;
            else if (RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(new Vector3(data.CoffrePosition.X, data.CoffrePosition.Y, data.CoffrePosition.Z)) < distance)
                return true;
            else if (RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(new Vector3(data.ComputerPosition.X, data.ComputerPosition.Y, data.ComputerPosition.Z)) < distance)
                return true;
            else if (RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(new Vector3(data.ZonePaintPosition.X, data.ZonePaintPosition.Y, data.ZonePaintPosition.Z)) < distance)
                return true;
            return false;
        }

        private void KeyEvent(FishData data)
        {
            if (RAGE.Input.IsDown((int)ConsoleKey.E) && DateTime.Now.Ticks > ticks)
            {
                SwitchTeleport(data);
                switch (state)
                {
                    case 0x00:
                        //ActiveEvent(data);
                        break;
                    case 0x01:
                        //DesactiveEvent(data);
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

        private void SwitchTeleport(FishData data)
        {
            if (RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(new Vector3(data.Inside.X, data.Inside.Y, data.Inside.Z)) < 5f)
                RAGE.Elements.Player.LocalPlayer.Position = new Vector3(data.Out.X, data.Out.Y, data.Out.Z);
            if (RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(new Vector3(data.Out.X, data.Out.Y, data.Out.Z)) < 5f)
                RAGE.Elements.Player.LocalPlayer.Position = new Vector3(data.Inside.X, data.Inside.Y, data.Inside.Z);
        }
    }
}
