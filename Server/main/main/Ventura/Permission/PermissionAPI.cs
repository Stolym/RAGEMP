using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using CMAPI = main.Ventura.Gestion.CharacterGestion;

namespace main.Ventura.Permission
{
    /*class PermissionAPI : Script
    {
        /*
         * This script manage global and jobs permission
         * Character have :
         * Global : Permission
         * Jobs_Activity : Bool --> you can take your service if true
         * Jobs_Permission : Int --> Level Permission jobs
         * 
         * Script:
         * 
         * Set Global Permission
         * Set Jobs_Activity
         * Set Jobs_Permission 
         * { set get }
         * 
         * 

        public static int get_global_permission(Client player)
        {
            if (CMAPI.get_data_player(player) != null)
                return (CMAPI.get_data_player(player).user.permission);
            return (-1);
        }

        public static int get_jobs_permission(Client player)
        {
            if (CMAPI.get_data_player(player) != null)
                return (CMAPI.get_data_player(player).user.permission_jobs[CMAPI.get_data_player(player).user.jobs]);
            return (-1);
        }

        public static void set_global_permission(Client player, int perm)
        {
            if (CMAPI.get_data_player(player) != null)
                CMAPI.get_data_player(player).user.permission = perm;
        }

        public static void set_jobs_permission(Client player, string jobs, int perm)
        {
            if (CMAPI.get_data_player(player) != null)
                CMAPI.get_data_player(player).user.permission_jobs[jobs] = perm;
        }
    }*/
}
