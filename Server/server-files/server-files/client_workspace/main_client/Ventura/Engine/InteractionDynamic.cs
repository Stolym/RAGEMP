using System;
using System.Collections.Generic;
using System.Text;
using RAGE;

namespace main_client.Ventura.Engine
{
    class InteractionDynamic : Events.Script
    {
        public static InteractionDynamic instance { get; set; }
        private long tick { get; set; }
        private int time { get; set; }
        private bool active { get; set; }
        private InteractionDynamicFlags flag { get; set; }
        private bool InteractChoose { get; set; }
        public enum InteractionDynamicFlags
        {
            PutPlayerInVehicle,
            OpenCloseClosestCarDoor,
            OpenCloseClosestDoor,
            ArrestFreeOtherPlayer,
            OnOffJobsAction,
            CheckOtherPlayer,
            None = -1,
        }

        public InteractionDynamic() {
            tick = 0;
            time = 5;
            flag = InteractionDynamicFlags.None;
            active = true;
            InteractChoose = false;
            instance = this;
        }

        public void OnTick() {
            StartClock();
            if (DateTime.Now.Ticks > tick && active)
            {
                CheckFlagActivity();
                DrawFlagActivity();
                tick = 0;
            }
        }


        public void KeyEvent() {
            if (DateTime.Now.Ticks > tick && active && RAGE.Input.IsDown((int)ConsoleKey.DownArrow))
            {
                active = !active;
                tick = 0;
            }
        }

        private void DrawFlagActivity()
        {
            if ((int)flag == -1)
                return;
            switch (flag)
            {
                case InteractionDynamicFlags.ArrestFreeOtherPlayer:
                    break;
                case InteractionDynamicFlags.CheckOtherPlayer:
                    break;
                case InteractionDynamicFlags.OnOffJobsAction:
                    break;
                case InteractionDynamicFlags.OpenCloseClosestCarDoor:
                    DrawClosestCarDoor();
                    break;
                case InteractionDynamicFlags.OpenCloseClosestDoor:
                    break;
                case InteractionDynamicFlags.PutPlayerInVehicle:
                    break;
            }
        }

        private void DrawClosestCarDoor()
        {
            float delta = 0.5f;
            int resolutionX = 0;
            int resolutionY = 0;

            RAGE.Game.Graphics.GetScreenResolution(ref resolutionX, ref resolutionY);
            if (InteractChoose)
                RAGE.Game.UIText.Draw("Ouvrir " + GetBoneOnPointer() + " du vehicle", new System.Drawing.Point((int)(resolutionX * delta), (int)(resolutionY * delta)), 0.05f, System.Drawing.Color.Azure, RAGE.Game.Font.Pricedown, true);
            else
                RAGE.Game.UIText.Draw("Fermer " + GetBoneOnPointer() + " du vehicle", new System.Drawing.Point((int)(resolutionX * delta), (int)(resolutionY * delta)), 0.05f, System.Drawing.Color.Azure, RAGE.Game.Font.Pricedown, true);

        }

        private string GetBoneOnPointer()
        {
            RAGE.Game.Shapetest.StartShapeTestRay(0, 0, 0, 0, 0, 0, 2, 2, 0);
            return "boot";
        }

        private void StartClock()
        {
            if (tick == 0)
                tick = DateTime.Now.AddMilliseconds(time).Ticks;
        }
        private void CheckFlagActivity()
        {

        }
    }

}
