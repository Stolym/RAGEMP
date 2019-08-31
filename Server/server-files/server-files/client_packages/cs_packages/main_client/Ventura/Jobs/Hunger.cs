using System;
using System.Collections.Generic;
using System.Text;
using RAGE;


namespace main_client.Other
{
    /*class Hunger : Events.Script
    {
        int[] clocks = new int[3] { 0, 0, 0 };
        
        public Hunger() {
            Events.Tick += hunger_gestion_tick;
        }

        private void hunger_gestion_tick(List<Events.TickNametagData> nametags)
        {
            if (clocks[2] > 20) {
                Events.CallRemote("UpdateInfoHunger");
                clocks[2]++;
            }
            if (clocks[0] > 500)
            {
                Events.CallRemote("UpdateInfoSelect", "rem", "food", 1);
                clocks[0] = 0;
            }
            if (clocks[1] > 750)
            {
                Events.CallRemote("UpdateInfoSelect", "rem", "water", 1);
                Events.CallRemote("UpdateInfoHunger");
                clocks[1] = 0;
            }
            for (int i = 0; i < 3; i++)
                clocks[i]++;
        }
    }*/
}
