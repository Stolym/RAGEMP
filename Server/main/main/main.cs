using System;
using GTANetworkAPI;
using Newtonsoft.Json;

namespace main
{
    public class Main : Script
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.None,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,
                TypeNameHandling = TypeNameHandling.Auto,
            };
        }
    }

    /*public class Main : Script
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            
            NAPI.Server.SetAutoRespawnAfterDeath(false);
            
            //NAPI.Marker.CreateMarker(1, new Vector3(452.146f, -980.0009f, 30.6896f - 1.7f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), 1.25f, new Color(0, 0, 255, 20));
            //API.CreateMarker(1, new Vector3(452.146f, -980.0009f, 30.6896f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), 1, new Color(0, 0, 255));

            //NAPI.Util.ConsoleOutput("Starting server part");

        }

        
        [ServerEvent(Event.PlayerConnected)]
        public void test(Client player)
        {
            player.TriggerEvent("test_test_test_a");
            //test_test_test_a
            //player.NametagVisible = false;
            //player.Nametag = player.SocialClubName;
            //player.ResetSharedData();
            //player.NametagVisible = false;
            //player.Name = player.SocialClubName;
            //player.TriggerEvent("test_test_test_a");
            //player.NametagVisible = false;
            //player.ResetNametag();
            //API.SetEntitySharedData(player.Handle, "Level", 0);
        }
        

        [ServerEvent(Event.PlayerDamage)]
        public void damage_option(Client player, float h_l, float a_l)
        {
            NAPI.Chat.SendChatMessageToAll(player.SocialClubName + " heatlh " + h_l);
            player.Health -= (int)h_l * 5;
            player.Armor -= (int)a_l;
        }

        [ServerEvent(Event.Update)]
        public void update()
        {
            /*for (int i = 0; i < NAPI.Pools.GetAllPlayers().Count; i++)
            {
                NAPI.Pools.GetAllPlayers()[i].SetSharedData("peer_to_peer_client_position", null);
            }
            for (int i = 0; i < NAPI.Pools.GetAllVehicles().Count; i++)
            {
                NAPI.Pools.GetAllVehicles()[i].SetSharedData("peer_to_peer_client_position", null);
            }
        }

        [RemoteEvent("CheckIsVehiculeInAir")]
        public void CheckIsVehiculeInAir(Client player)
        {
            /*foreach (Vehicle v in NAPI.Pools.GetAllVehicles())
            {
                player.TriggerEvent("VehiculeClientIsAir", v);
            }
        }

        [RemoteEvent("CheckPlayer")]
        public void CheckPlayer(Client player)
        {
            /*foreach (Client p in NAPI.Pools.GetAllPlayers())
            {
                player.SetSharedData("SyncPlayerPed", null);
            }
        }


    }*/
}
