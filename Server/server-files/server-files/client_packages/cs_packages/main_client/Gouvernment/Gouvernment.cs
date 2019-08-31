using System;
using System.Collections.Generic;
using System.Text;
using RAGE;
using RAGE.NUI;
//using Newtonsoft.Json;
using System.Threading.Tasks;
//using AAPI = main_client.Animation.Animation;
//using CAPI = main_client.Camera.Camera;
//using PAPI = main_client.Ped.Ped;
using RAGE.Elements;


namespace main_client.Gouvernment
{
    /*class Gouvernment : Events.Script
    {
        private bool service = false;
        private List<Vector3> spawn = new List<Vector3>() { new Vector3(-429.4399f, 1109.614f, 327.0161f), new Vector3(-414.3734f, 1060.537f, 323.2384f), new Vector3(2154.968f, 2920.931f, -62.52974f) };
        private int timer = 0;

        public Gouvernment()
        {
            Events.Tick += Tick;
        }

        private void Tick(List<Events.TickNametagData> nametags)
        {

            RAGE.Game.Graphics.DrawBox(spawn[1].X, spawn[1].Y, spawn[1].Z, spawn[1].X + 1, spawn[1].Y + 1, spawn[1].Z + 1, 24, 234, 154, 255);
            RAGE.Game.Graphics.DrawBox(spawn[0].X, spawn[0].Y, spawn[0].Z, spawn[0].X + 1, spawn[0].Y + 1, spawn[0].Z + 1, 24, 234, 154, 255);
            RAGE.Game.Graphics.DrawBox(spawn[2].X, spawn[2].Y, spawn[2].Z, spawn[2].X + 1, spawn[2].Y + 1, spawn[2].Z + 1, 24, 234, 154, 255);

            if (RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(spawn[0]) < 5f && RAGE.Input.IsDown((int)ConsoleKey.E) && timer == 0)
            {
                RAGE.Elements.Player.LocalPlayer.Position = spawn[2];
                timer++;
            }
            else if (RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(spawn[2]) < 5f && RAGE.Input.IsDown((int)ConsoleKey.E) && timer == 0)
            {
                RAGE.Elements.Player.LocalPlayer.Position = spawn[0];
                timer++;
            }
            else if (RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(spawn[1]) < 5f && RAGE.Input.IsDown((int)ConsoleKey.E) && timer == 0)
            {
                Chat.Output("Spawn");
                Events.CallRemote("SpawnNewVehicule", "Police");
                timer++;
            }
            else if (timer != 0 && timer < 20)
                timer++;
            else if (timer >= 20)
                timer = 0;
        }
    }*/
}
