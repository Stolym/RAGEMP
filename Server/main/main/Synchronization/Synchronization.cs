using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;

namespace main.Synchronization
{
    /*class Synchronization : Script
    {
        public Synchronization() {

        }

       
        /// <summary>
        /// 
        /// Comment get une valeur qui est sur le client
        /// Pour l'ajouter a tout les autres client
        /// Client Ped Local Send ça position au server resend la position de ce joueurs au autres
        /// Update ça position
        /// 
        /// 
        /// </summary>


        public enum AnimationFlags
        {
            Loop = 1 << 0,
            StopOnLastFrame = 1 << 1,
            OnlyAnimateUpperBody = 1 << 4,
            AllowPlayerControl = 1 << 5,
            Cancellable = 1 << 7
        };

        [ServerEvent(Event.EntityModelChange)]
        public void OnEntityModelChange(NetHandle entityHandle, uint oldModel)
        {
            switch (entityHandle.Type)
            {
                case EntityType.Player:
                    {
                        var player = entityHandle.Entity<Client>();
                        player.SendChatMessage($"Your model has changed from {oldModel} to {player.Model}!");
                        break;
                    }
            }
        }


        [RemoteEvent("update_player")]
        public void update_players(Client player, Client other) {
            foreach (Client client in NAPI.Pools.GetAllPlayers()) {
                if (other == client)
                {
                    bool value = other.GetData("IsAnim");
                    bool value_b = other.GetData("IsFreeze");
                    other.TriggerEvent("IsFreezeClient", value_b);
                    other.TriggerEvent("IsAnimClient", value);
                }
            }
        }

        [Command("freeze_player")]
        public void freeze_player(Client player) {
            //player.Freeze(true);
            // API.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "mp_arresting", "idle");
            //API.PlayPlayerScenario(player, "CODE_HUMAN_POLICE_CROWD_CONTROL");
            Vehicle veh = NAPI.Vehicle.CreateVehicle(1777363799, player.Position.Around(5), 0, 0, 0);

            Client tmp = null;
            foreach (Client client in NAPI.Pools.GetAllPlayers()) {
                if (Vector3.Distance(client.Position, player.Position) < 5f && player != client) {
                    tmp = client;
                }
            }


            if (tmp != null)
            {
                NAPI.Chat.SendChatMessageToAll("OK "+tmp.SocialClubName);
                try
                {
                    API.ClearPlayerTasks(player);

                    NAPI.ClientEvent.TriggerClientEventForAll("ArrestPlayer", player, veh);
                    //API.SendNativeToAllPlayers(Hash.FREEZE_ENTITY_POSITION, player.Handle, true);
                }
                catch (Exception ex) {
                    NAPI.Chat.SendChatMessageToAll(ex.Message);
                }
                //NAPI.ClientEvent.TriggerClientEventForAll("ArrestPlayer", player, veh);
                //API.SendNativeToPlayer(player, Hash.TASK_ARREST_PED, new object[] { (object)tmp.Handle });
            }
            else
                NAPI.Chat.SendChatMessageToAll("NULL");
            //player.SetData("IsAnim", true);
            //player.SetData("IsFreeze", false);
            //player.SetSharedData("test_sync_player", null);
            //player.SetSharedData("test_sync_player_position", null);
        }
    }*/
}
