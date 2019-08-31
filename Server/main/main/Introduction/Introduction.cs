using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using Newtonsoft.Json;


using SQLAPI = main.Database.MySqlGestion;
using CGAPI = main.Ventura.Gestion.CharacterGestion;
using WAPI = main.Ventura.Permission.WhiteListCommand;
using DAPI = main.Ventura.Gestion.DimensionGestion;
using DUSER = main.Ventura.Database.DataUser;
using LAPI = main.Ventura.Gestion.LogGestion;
using ASAPI = main.Ventura.Stream.Async.Event.AsyncEvent;
//using CGAPI = main.Manager.CharacterManager;
//using WAPI = main.Permission.WhiteListCommand;
//using DUSER = main.Database.DataUser;
//using UAPI = main.Manager.Update;
//using DGAPI = main.Manager.DimensionGestion;
//using SGAPI = main.Manager.SkinGestion;

namespace main.Introduction
{
    class Introduction : Script
    {
        private List<Vehicle> vehicule_list = new List<Vehicle>();
        private int limit_client = 10;
        private long tick = 0;

        [RemoteEvent("delete_introduction_id")]
        public void delete_veh(Client client, uint remoteId) {
            if (vehicule_list.Find(x => x.Handle.Value == remoteId) != null)
            {
                vehicule_list.Find(x => x.Handle.Value == remoteId).Delete();
                vehicule_list.Remove(vehicule_list.Find(x => x.Handle.Value == remoteId));
            }
        }


        [ServerEvent(Event.Update)]
        public void clock_maker() {
            if (tick == 0)
                tick = DateTime.Now.AddSeconds(10).Ticks;
        }


        [RemoteEvent("IfPlayerCanEnter")]
        public void if_player_can_enter(Client client, string side) {
            if (DateTime.Now.Ticks > tick && tick != 0 && vehicule_list.Count < limit_client)
            {
                tick = 0;
                SQLAPI.RegisterDataPlayerWithPosition(client, CGAPI.GetDataPlayer(client), new Vector3(-1219.258f, -3017.728f, 14.1612f));
                switch (side)
                {
                    case "North":
                        north(client);
                        break;
                    case "South":
                        south(client);
                        break;
                }
            }
        }


        public void north(Client client)
        {
            if (vehicule_list.Count < limit_client)
            {
                DAPI.RemoveInstance(client.SocialClubName);
                DAPI.UpdateInstanceWithDataUser(client, CGAPI.GetDataPlayer(client), "World");
                Vehicle veh = null;
                Random rand = new Random();
                veh = NAPI.Vehicle.CreateVehicle(VehicleHash.Cuban800, new Vector3(257.2935f, 2849.016f, 271.5917f), 165, rand.Next(0, 10), rand.Next(0, 3));
                vehicule_list.Add(veh);
                client.TriggerEvent("IntroductionSelect", veh.Handle.Value, "North");
            }
        }

        public void south(Client client) {
            if (vehicule_list.Count < limit_client)
            {
                DAPI.RemoveInstance(client.SocialClubName);
                DAPI.UpdateInstanceWithDataUser(client, CGAPI.GetDataPlayer(client), "World");
                Vehicle veh = null;
                Random rand = new Random();
                veh = NAPI.Vehicle.CreateVehicle(VehicleHash.Velum, new Vector3(-2521.391f, -2264.896f, 127f), 225, rand.Next(0, 10), rand.Next(0, 3));
                vehicule_list.Add(veh);
                client.TriggerEvent("IntroductionSelect", veh.Handle.Value, "South");
            }
        }

    }
}
