using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using System.Threading.Tasks;
using SQLAPI = main.Database.MySqlGestion;
using CGAPI = main.Ventura.Gestion.CharacterGestion;
using WAPI = main.Ventura.Permission.WhiteListCommand;
using DAPI = main.Ventura.Gestion.DimensionGestion;
using DUSER = main.Ventura.Database.DataUser;
//using UAPI = main.Manager.Update;
using LAPI = main.Ventura.Gestion.LogGestion;
using ASAPI = main.Ventura.Stream.Async.Event.AsyncEvent;


namespace main.Ventura.Connection
{
    class Connection : Script
    {


        [ServerEvent(Event.PlayerConnected)]
        public void Connect(Client player)
        {
            if (!WAPI.IfInPreWhiteList(player.SocialClubName))
            {
                player.Kick();
                return;
            }

            // Connection if player is in white list so we must to Create Instance time who he log or register on server.

            DAPI.CreateInstance(player.SocialClubName);

            // Now check if this player exist in DB
            // DB connection async

            if (!ASAPI.CheckIfPlayerIsRegister(player))
                main.Ventura.Register.Register.register(player);
            else if (ASAPI.CheckIfPlayerIsRegister(player)) {
                if (!ASAPI.AddClientInCharacterManager(player)) {
                    player.Kick();
                    return;
                }
                if (!WAPI.IfInWhiteList(player.SocialClubName))
                    player.Kick();
                DAPI.UpdateInstanceWithDataUser(player, CGAPI.GetDataPlayer(player), "World");
                //NAPI.ClientEvent.TriggerClientEvent(player, "InteractionActive");
                main.Ventura.Login.Login.login_form(player);
            }
        }
        

        [ServerEvent(Event.FirstChanceException)]
        public void ExceptionBeforeClose(Exception ex)
        {
            //LAPI.InsertLog(new Gestion.LogRequest() { social_name = "Server", action = Gestion.LogProcess.INSTANCE, description = ex.Message, RemoteId = 0x0, ToRemoteId = 0x0 });
        }
        
        [ServerEvent(Event.UnhandledException)]
        public void ExceptionUnHandle(Exception ex)
        {
            //LAPI.InsertLog(new Gestion.LogRequest() { social_name = "Server", action = Gestion.LogProcess.INSTANCE, description = ex.Message, RemoteId = 0x0, ToRemoteId = 0x0 });
        }

        [ServerEvent(Event.ResourceStop)]
        public void ExitServer() {

        }


        [ServerEvent(Event.PlayerDisconnected)]
        public void Disconnect(Client player, DisconnectionType type, string reason)
        {
            main.Ventura.Gestion.CharacterGestion.RemoveDataPlayer(player);
        }
        
    }
}
