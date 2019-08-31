using System;
using System.Collections.Generic;
using System.Text;
using RAGE;
using Newtonsoft.Json;

namespace main_client.Vehicule
{

    /*class VehicleInteraction
    {
        class VehiculeShop : Events.Script
        {
            private int timer = 0;
            private bool service = false;
            private List<Vector3> spawn = new List<Vector3>() { new Vector3(-238.3402f, -1397.51f, 30.79437f) };
            private ListVehicleShop list_shops = null;
            
            public VehiculeShop()
            {
                Events.Add("UpdateListVehiculeShop", UpdateListVehiculeShop);
                Events.Tick += Tick;
            }

            private void UpdateListVehiculeShop(object[] args)
            {
                string json_string = args[0].ToString();
                var data = JsonConvert.DeserializeObject<ListVehicleShop>(json_string);

                if (data == null)
                    return;
                list_shops = data;
            }
            
            private void Tick(List<Events.TickNametagData> nametags)
            {
                RAGE.Game.Graphics.DrawBox(spawn[0].X, spawn[0].Y, spawn[0].Z, spawn[0].X + 1, spawn[0].Y + 1, spawn[0].Z + 1, 24, 234, 154, 255);

                if (RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(spawn[0]) < 5f && RAGE.Input.IsDown((int)ConsoleKey.E) && timer == 0)
                {
                    Events.CallRemote("SpawnNewVehicule", "Blista");
                    timer++;
                }
                else if (timer != 0 && timer < 40)
                    timer++;
                else if (timer >= 40)
                    timer = 0;
                if (list_shops != null) {
                    list_shops.Draw();
                }
            }
        }

        public class ListVehicleShop {
            public List<VehicleShop> list = new List<VehicleShop>();

            public void Draw() {
                foreach (var vshop in list) {
                    RAGE.Game.Graphics.DrawDebugSphere(vshop.marker_pos.X, vshop.marker_pos.Y, vshop.marker_pos.Z, 1, 0, 0, 255, 255);
                }
            }

        }

        public class VehicleShop
        {
            public int marker_id { get; set; }
            public Vector3 marker_pos { get; set; }

            public VehicleShop() { }
        }
    }*/
}
