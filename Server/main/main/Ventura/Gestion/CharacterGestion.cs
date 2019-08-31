using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using DUSER = main.Ventura.Database.DataUser;
using LAPI = main.Ventura.Gestion.LogGestion;

namespace main.Ventura.Gestion
{
    class CharacterGestion : Script
    {
        /*
         * List Character Gestion
         * 
         * */
        public static Dictionary<Client, DUSER> players_list = new Dictionary<Client, DUSER>();

        public static void AddPlayerInList(Client player, ref DUSER data) {
            if (players_list.ContainsKey(player) == false)
                players_list.Add(player, data);
        }

        public static DUSER GetDataPlayer(Client player)
        {
            if (players_list.ContainsKey(player) == false)
                return (null);
            return (players_list[player]);
        }

        public static bool RemoveDataPlayer(Client player)
        {
            if (players_list.ContainsKey(player) == false)
                return (true);
            return (players_list.Remove(player));
        }

    }
}
