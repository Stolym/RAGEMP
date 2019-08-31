using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTANetworkAPI;
//using PAPI = main.Ventura.Permission.PermissionAPI;
using RWAPI = main.Ventura.Database.ReaderWriter.ReaderWriter;

namespace main.Ventura.Permission
{
    public class WhiteListCommand : Script
    {
        /*
         * Its API, with this you can white-list and unwhite_list every body
         * 
         * Pre White List --> Zone Limiter --> North & South
         * White List --> Can do everything
         * 
         * */
         
        private static string[] path = new string[2] { "./data/White_List/whitelist.txt", "./data/White_List/prewhitelist.txt" };

        public WhiteListCommand()
        {
          
        }

        public static bool IfInWhiteList(string social_club)
        {
            return (RWAPI.IfLineExistInFile(path[0], social_club));
        }


        public static bool IfInPreWhiteList(string social_club)
        {
            return (RWAPI.IfLineExistInFile(path[1], social_club));
        }

        [Command("/white")]
        public void WriteWhiteList(Client player, string social_club)
        {
            //if (PAPI.get_global_permission(player) >= 2)
            //{
                RWAPI.IfLineExistInFile(path[0], social_club);
            //}
        }

        [Command("/prewhite")]
        public void WritePreWhiteList(Client player, string social_club)
        {
            //if (PAPI.get_global_permission(player) >= 2)
            //{
                RWAPI.IfLineExistInFile(path[1], social_club);
            //}
        }

        [Command("/unwhite")]
        public void RemoveWhiteList(Client player, string social_club)
        {
            //if (PAPI.get_global_permission(player) >= 2)
            //{
                RWAPI.IfLineExistInFile(path[0], social_club);
            //}
        }


        [Command("/unprewhite")]
        public void RemovePreWhiteList(Client player, string social_club)
        {
            //if (PAPI.get_global_permission(player) >= 2)
            //{
                RWAPI.IfLineExistInFile(path[1], social_club);
            //}
        }
    }
}