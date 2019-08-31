using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
//using CMAPI = main.Manager.CharacterManager;

namespace main.Ventura.Engine.Bank
{
    /*
     * 
     * 
     * 
     * 
     * */


    /*class MoneyGestion : Script
    {
        public MoneyGestion() {

        }


        [RemoteEvent("give_money_to_player")]
        public void give_money_to_player(Client player, ushort RemoteId) {
            Client target = NAPI.Pools.GetAllPlayers().Find(x => x.Handle.Value == RemoteId);

            if (CMAPI.get_data_player(player) != null && target != null && CMAPI.get_data_player(target) != null)
            {
            }
        }

        [RemoteEvent("get_bank")]
        public void get_bank(Client player, float value)
        {
            if (CMAPI.get_data_player(player) != null)
            {
                if (CMAPI.get_data_player(player).info.legal_money - value < 0)
                {
                    NAPI.Chat.SendChatMessageToPlayer(player, "Salut :", "You don't have money in your bank.");
                    //Send Notification
                }
                else
                {
                    CMAPI.get_data_player(player).info.legal_money -= value;
                    CMAPI.get_data_player(player).info.legal_money += value;
                }
            }
        }


        [RemoteEvent("send_bank")]
        public void send_bank(Client player, float value)
        {
            if (CMAPI.get_data_player(player) != null)
            {
                if (CMAPI.get_data_player(player).info.legal_money - value < 0)
                {
                    NAPI.Chat.SendChatMessageToPlayer(player, "Salut :", "You don't have money to withdraw bank.");
                    //Send Notification
                }
                else
                {
                    CMAPI.get_data_player(player).info.legal_money -= value;
                    CMAPI.get_data_player(player).info.legal_money += value;
                }
            }
        }

        [RemoteEvent("change_money")]
        public static void change_money(Client player, float value) {
            if (CMAPI.get_data_player(player) != null)
                CMAPI.get_data_player(player).info.legal_money += value;
        }

    }*/
}
