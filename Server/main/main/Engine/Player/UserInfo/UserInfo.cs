using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
//using CMAPI = main.Manager.CharacterManager;


namespace main.Engine.Player.UserInfo
{
    /*class UserInfo : Script
    {
        [RemoteEvent("UpdateInfoHunger")]
        public void update_info_hunger(Client player)
        {
            player.TriggerEvent("executeFunction", "UserInfo", "hunger", CMAPI.get_data_player(player).info.hunger);
            player.TriggerEvent("executeFunction", "UserInfo", "water", CMAPI.get_data_player(player).info.water);
            player.TriggerEvent("executeFunction", "UserInfo", "health", player.Health);
        }


        [RemoteEvent("UpdateInfoSelect")]
        public void update_info_select(Client player, string select, string info, int value)
        {
            switch (select) {
                case "add":
                    switch (info)
                    {
                        case "food":
                            CMAPI.get_data_player(player).info.hunger += value;
                            break;
                        case "water":
                            CMAPI.get_data_player(player).info.water += value;
                            break;
                        case "money":
                            CMAPI.get_data_player(player).info.legal_money += value;
                            break;
                    }
                    break;
                case "rem":
                    switch (info)
                    {
                        case "food":
                            CMAPI.get_data_player(player).info.hunger -= value;
                            break;
                        case "water":
                            CMAPI.get_data_player(player).info.water -= value;
                            break;
                        case "money":
                            CMAPI.get_data_player(player).info.legal_money -= value;
                            break;
                    }
                    break;
            }
            if (CMAPI.get_data_player(player).info.hunger <= 0 && CMAPI.get_data_player(player).info.water <= 0)
            {
                player.Health = player.Health - 20 < 0 ? 0 : player.Health - 20;
                CMAPI.get_data_player(player).info.hunger = 0;
                CMAPI.get_data_player(player).info.water = 0;
            }
        }
    }*/
}
