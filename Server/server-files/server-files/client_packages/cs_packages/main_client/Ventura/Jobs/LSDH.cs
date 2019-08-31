using System;
using System.Collections.Generic;
using System.Text;

using RAGE;

namespace main_client.LSDH
{
    /*class LSDH : Events.Script
    {
        private bool service = false;
        private List<Vector3> spawn = new List<Vector3>() { new Vector3(-491.5811f, -335.3956f, 33.92181f), new Vector3(-452.5724f, -339.2004f, 33.91407f) };
        private int timer = 0;

        public LSDH()
        {
            Events.Tick += Tick;
        }

        private void Tick(List<Events.TickNametagData> nametags)
        {

            RAGE.Game.Graphics.DrawBox(spawn[1].X, spawn[1].Y, spawn[1].Z, spawn[1].X + 1, spawn[1].Y + 1, spawn[1].Z + 1, 24, 234, 154, 255);
            RAGE.Game.Graphics.DrawBox(spawn[0].X, spawn[0].Y, spawn[0].Z, spawn[0].X + 1, spawn[0].Y + 1, spawn[0].Z + 1, 24, 234, 154, 255);

            if (RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(spawn[0]) < 5f && RAGE.Input.IsDown((int)ConsoleKey.E) && timer == 0)
            {
                /*RAGE.Game.Ped.SetPedComponentVariation(RAGE.Elements.Player.LocalPlayer.Handle, 0, 0, 0, 2);
                RAGE.Game.Ped.SetPedComponentVariation(RAGE.Elements.Player.LocalPlayer.Handle, 1, 0, 0, 2);
                RAGE.Game.Ped.SetPedComponentVariation(RAGE.Elements.Player.LocalPlayer.Handle, 2, 31, 0, 2);
                RAGE.Game.Ped.SetPedComponentVariation(RAGE.Elements.Player.LocalPlayer.Handle, 3, 0, 0, 2);
                RAGE.Game.Ped.SetPedComponentVariation(RAGE.Elements.Player.LocalPlayer.Handle, 4, 35, 0, 2);
                RAGE.Game.Ped.SetPedComponentVariation(RAGE.Elements.Player.LocalPlayer.Handle, 5, 0, 0, 2);
                RAGE.Game.Ped.SetPedComponentVariation(RAGE.Elements.Player.LocalPlayer.Handle, 6, 24, 0, 2);
                RAGE.Game.Ped.SetPedComponentVariation(RAGE.Elements.Player.LocalPlayer.Handle, 7, 0, 0, 2);
                RAGE.Game.Ped.SetPedComponentVariation(RAGE.Elements.Player.LocalPlayer.Handle, 8, 58, 0, 2);
                RAGE.Game.Ped.SetPedComponentVariation(RAGE.Elements.Player.LocalPlayer.Handle, 9, 4, 0, 2);
                RAGE.Game.Ped.SetPedComponentVariation(RAGE.Elements.Player.LocalPlayer.Handle, 10, 8, 3, 2);
                RAGE.Game.Ped.SetPedComponentVariation(RAGE.Elements.Player.LocalPlayer.Handle, 11, 55, 0, 2);
                RAGE.Game.Ped.SetPedPropIndex(RAGE.Elements.Player.LocalPlayer.Handle, 0, 46, 0, true);
                RAGE.Game.Ped.SetPedRandomComponentVariation(RAGE.Elements.Player.LocalPlayer.Handle, false);
                RAGE.Game.Ped.SetPedComponentVariation(RAGE.Elements.Player.LocalPlayer.Handle, 1, 0, 0, 2);

                //RAGE.Game.Weapon.AddAmmoToPed(RAGE.Elements.Player.LocalPlayer.Handle, Convert.ToUInt16(-1716589765), 100);
                service = !service;
                Chat.Output(service.ToString());
                timer++;
            }
            else if (RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(spawn[1]) < 5f && RAGE.Input.IsDown((int)ConsoleKey.E) && service && timer == 0)
            {
                Chat.Output("Spawn");
                Events.CallRemote("SpawnNewVehicule", "Ambulance");
                timer++;
            }
            else if (timer != 0 && timer < 20)
                timer++;
            else if (timer >= 20)
                timer = 0;
        }
    }*/
}
