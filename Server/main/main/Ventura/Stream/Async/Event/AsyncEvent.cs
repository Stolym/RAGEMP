using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GTANetworkAPI;
using SQLAPI = main.Database.MySqlGestion;
using CGAPI = main.Ventura.Gestion.CharacterGestion;

namespace main.Ventura.Stream.Async.Event
{
    class AsyncEvent : Script
    {
        //public static AsyncEvent instance = null;
        /*
         * 
         * 
         * 
         * 
         * */
        /*public AsyncEvent()
        {
            if (instance == null)
                instance = this;
        }*/

        public async Task<bool> ACallEvent(Client client, string ename, object[] args)
        {
            bool ret = true;
            try
            {
                client.TriggerEvent(ename, args);
            }
            catch (Exception exp)
            {
                NAPI.Util.ConsoleOutput(exp.Message);
                ret = false;
            }
            return ret;
        }


        public static bool CallEvent(Client client, string ename, object[] args)
        {
            bool ret = true;
            try
            {
                client.TriggerEvent(ename, args);
            }
            catch (Exception exp)
            {
                NAPI.Util.ConsoleOutput(exp.Message);
                ret = false;
            }
            return ret;
        }

        public async Task<bool> RemovePlayer(Client client)
        {
            bool save = true;
            try
            {
                SQLAPI.UpdateDataPlayer(client, CGAPI.GetDataPlayer(client));
                CGAPI.RemoveDataPlayer(client);
            }
            catch (Exception exp)
            {
                NAPI.Util.ConsoleOutput(exp.Message);
                save = false;
            }
            return save;
        }

        public async Task<bool> ACheckIfPlayerIsRegister(Client client)
        {
            bool login = false;
            try
            {
                login = SQLAPI.PlayerExist(client);
            }
            catch (Exception exp)
            {
                NAPI.Util.ConsoleOutput(exp.Message);
            }
            return login;
        }

        public static bool CheckIfPlayerIsRegister(Client client)
        {
            bool login = false;
            try
            {
                login = SQLAPI.PlayerExist(client);
            }
            catch (Exception exp)
            {
                NAPI.Util.ConsoleOutput(exp.Message);
            }
            return login;
        }

        public async Task<bool> AAddClientInCharacterManager(Client client)
        {
            bool ret = true;
            try
            {
                Database.DataUser data = SQLAPI.GetDataPlayer(client);
                CGAPI.AddPlayerInList(client, ref data);
            }
            catch (Exception exp)
            {
                NAPI.Util.ConsoleOutput(exp.Message);
                ret = false;
            }
            return ret;
        }

        public static bool AddClientInCharacterManager(Client client)
        {
            bool ret = true;
            try
            {
                Database.DataUser data = SQLAPI.GetDataPlayer(client);
                CGAPI.AddPlayerInList(client, ref data);
            }
            catch (Exception exp)
            {
                NAPI.Util.ConsoleOutput(exp.Message);
                ret = false;
            }
            return ret;
        }

    }
}
