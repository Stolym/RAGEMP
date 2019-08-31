using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using LAPI = main.Ventura.Gestion.LogGestion;
using DUser = main.Ventura.Database.DataUser;

namespace main.Ventura.Gestion
{
    class DimensionGestion : Script
    {
        /*
         *  Format : API
         *  Focus : Set Dimension Player & Vocal
         *  Description :
         *  Player Dimensions Space Gestion
         *  Vocal Dimensions --|
         *  --| Vocal Gameplay if player is closest or not if you can ear him
         *  --| Vocal Phone & Talkie Walkie --> create two dimension one where players can earing other players and talk with him
         *  --| Vocal Radio --> just listen radio --> other have sender
         * 
         * */

        public static uint iterator = 0xFF00ED00;
        public static Dictionary<string, uint> list_instance = new Dictionary<string, uint>();

        public static void CreateInstance(string name)
        {
            if (!list_instance.ContainsKey(name))
            {
                LAPI.InsertLog(new Gestion.LogRequest() { social_name = "Create Instance", action = Gestion.LogProcess.INSTANCE, description = "Instance created " + name, RemoteId = 0x0, ToRemoteId = 0x0 });
                list_instance.Add(name, iterator);
                while (iterator == NAPI.GlobalDimension || list_instance.ContainsValue(iterator))
                    iterator++;
                iterator++;
            }
        }

        public static void RemoveInstance(string name)
        {
            if (list_instance.ContainsKey(name))
            {
                LAPI.InsertLog(new Gestion.LogRequest() { social_name = "Remove Instance", action = Gestion.LogProcess.INSTANCE, description = "Instance removed " + name, RemoteId = 0x0, ToRemoteId = 0x0 });
                list_instance.Remove(name);
            }
        }
        
        public static uint GetInstance(string name)
        {
            if (list_instance.ContainsKey(name))
            {
                LAPI.InsertLog(new Gestion.LogRequest() { social_name = "Get Instance", action = Gestion.LogProcess.INSTANCE, description = "Instance getting " + name, RemoteId = 0x0, ToRemoteId = 0x0 });
                return list_instance[name];
            }
            return 0;
        }

        public static void UpdateInstanceWithDataUser(Client player, DUser data, string name)
        {
            if (list_instance.ContainsKey(name))
            {
                LAPI.InsertLog(new Gestion.LogRequest() { social_name = player.SocialClubName, action = Gestion.LogProcess.INSTANCE, description = player.Address + " go to " + name + " instance", RemoteId = player.Handle.Value, ToRemoteId = 0x0 });
                data.user.dimension = list_instance[name];
                player.Dimension = list_instance[name];
            }
            else
            {
                LAPI.InsertLog(new Gestion.LogRequest() { social_name = player.SocialClubName, action = Gestion.LogProcess.INSTANCE, description = player.Address + " go to global instance", RemoteId = player.Handle.Value, ToRemoteId = 0x0 });
                data.user.dimension = 0;
                player.Dimension = 0;
            }
        }


        public static void UpdateInstanceWithoutDataUser(Client player, string name)
        {
            if (list_instance.ContainsKey(name))
            {
                LAPI.InsertLog(new Gestion.LogRequest() { social_name = player.SocialClubName, action = Gestion.LogProcess.INSTANCE, description = player.Address + " go to " + name + " instance", RemoteId = player.Handle.Value, ToRemoteId = 0x0 });
                player.Dimension = list_instance[name];
            }
            else
            {
                LAPI.InsertLog(new Gestion.LogRequest() { social_name = player.SocialClubName, action = Gestion.LogProcess.INSTANCE, description = player.Address + " go to global instance", RemoteId = player.Handle.Value, ToRemoteId = 0x0 });
                player.Dimension = NAPI.GlobalDimension;
            }
        }
    }
}
