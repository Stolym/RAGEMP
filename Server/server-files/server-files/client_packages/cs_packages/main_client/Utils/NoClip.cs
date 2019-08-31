using System;
using System.Collections.Generic;
using System.Text;
using RAGE;


namespace main_client.Utils
{
    /*class NoClip : Events.Script
    {
        bool active = false;
        float clock = 0;
        float speed = 20;


        public NoClip()
        {
            Events.Tick += Tick;
            Events.Add("ActiveNoclip", ActiveNoclip);
        }

        private void ActiveNoclip(object[] args)
        {
            int i = Convert.ToInt32(args[0]);
            active = i == 0 ? false : true;
        }

        private void Tick(List<Events.TickNametagData> nametags)
        {
            if (active)
            {
                RAGE.Elements.Player.LocalPlayer.SetCollision(false, false);
                //RAGE.Elements.Player.LocalPlayer.FreezePosition(true);
                RAGE.Elements.Player.LocalPlayer.SetGravity(false);

                if (RAGE.Input.IsDown((int)ConsoleKey.D1) && clock == 0)
                    speed = 10f;
                if (RAGE.Input.IsDown((int)ConsoleKey.D2) && clock == 0)
                    speed = 20f;
                if (RAGE.Input.IsDown((int)ConsoleKey.D3) && clock == 0)
                    speed = 5f;
                if (RAGE.Input.IsDown((int)ConsoleKey.D4) && clock == 0)
                    speed = 1f;


                if (RAGE.Input.IsDown((int)ConsoleKey.Z) && clock == 0)
                {
                    RAGE.Elements.Player.LocalPlayer.Position += new Vector3(0.1f * speed, 0, 0);
                    //clock++;
                }
                else if (RAGE.Input.IsDown((int)ConsoleKey.S) && clock == 0)
                {
                    RAGE.Elements.Player.LocalPlayer.Position += new Vector3(-0.1f * speed, 0, 0);
                    //clock++;
                }
                else if (RAGE.Input.IsDown((int)ConsoleKey.Q) && clock == 0)
                {
                    RAGE.Elements.Player.LocalPlayer.Position += new Vector3(0, 0.1f * speed, 0);
                    //clock++;
                }
                else if (RAGE.Input.IsDown((int)ConsoleKey.D) && clock == 0)
                {
                    RAGE.Elements.Player.LocalPlayer.Position += new Vector3(0, -0.1f * speed, 0);
                    //clock++;
                }
                else if (RAGE.Input.IsDown((int)ConsoleKey.E) && clock == 0)
                {
                    RAGE.Elements.Player.LocalPlayer.Position += new Vector3(0, 0, 0.1f * speed);
                    //clock++;
                }
                else if (RAGE.Input.IsDown((int)ConsoleKey.A) && clock == 0)
                {
                    RAGE.Elements.Player.LocalPlayer.Position += new Vector3(0, 0, -0.1f * speed);
                    //clock++;
                }
                else if (clock != 0 && clock <= 1)
                    clock++;
                else if (clock >= 1)
                    clock = 0;
            }
        }
    }*/
}
