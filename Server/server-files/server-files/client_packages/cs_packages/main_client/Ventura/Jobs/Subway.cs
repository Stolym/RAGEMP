using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RAGE;
using RAGE.Elements;

namespace main_client.Other
{
    /*class Subway : Events.Script
    {
        int time = 0;
        int times = 0;
        bool actives = false;

        public Subway() {
            Events.Tick += tick;
        }
        
        private void tick(List<Events.TickNametagData> nametags)
        {
            if (time > 100) {
                actives = false;
                time = 0; 
            }
            if (actives)
                time++;
            if (RAGE.Input.IsDown((int)ConsoleKey.A) && !actives) {
                if (RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(new Vector3(-1105.615f, -2734.213f, -7.890509f)) < 5f)
                {
                    Chat.Output("Position 1");
                    RAGE.Elements.Player.LocalPlayer.Position = new Vector3(112.9588f, -1721.979f, 29.62934f);
                } else if (RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(new Vector3(112.9588f, -1721.979f, 29.62934f)) < 5f)
                {
                    Chat.Output("Position 2");
                    RAGE.Elements.Player.LocalPlayer.Position = new Vector3(-1105.615f, -2734.213f, -7.890509f);
                }
                actives = true;
            }
        }
    }*/
}
