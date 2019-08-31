using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTANetworkAPI;
//using PAPI = main.Permission.PermissionAPI;
//using RWAPI = main.Database.ReaderWriter.ReaderWriter;

namespace main.Ventura.Permission
{
    /*public class BanCommands : Script
    {
        private static string path = "./data/Ban/bans.txt";

        public BanCommands()
        {
        }
        
        [Command("/ban")]
        public void write_white_list(Client player, string social_club)
        {
            if (PAPI.get_global_permission(player) >= 2)
            {
                RWAPI.write_line_in_file(path, social_club);
                API.BanPlayer(player);
            }
        }

        [Command("/unban")]
        public void remove_white_list(Client player, string social_club)
        {
            if (PAPI.get_global_permission(player) >= 2)
            {
                RWAPI.remove_line_in_file(path, social_club);
                API.UnbanPlayer(social_club);
            }
        }
    }*/
}