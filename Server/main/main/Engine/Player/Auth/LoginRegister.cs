using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;

namespace main.Engine.Player.Auth
{
    class LoginRegister : Script
    {
        public static string test_connection = "root";

        [ServerEvent(Event.PlayerConnected)]
        public void ExecutionPlayer(Client player)
        {
            /*NAPI.Util.ConsoleOutput(player.SocialClubName);
            Database.DataUser tmp = null;
            if (!main.Database.MySqlGestion.player_exist(player))
            {
                tmp = new Database.DataUser(player.SocialClubName, "");
                tmp.setInfo.pos = new Database.Vector3 { x = player.Position.X, y = player.Position.Y, z = player.Position.Z };
                NAPI.ClientEvent.TriggerClientEvent(player, "register_form", tmp.social);
                //player.Position = new Vector3(406.0395f, -997.3383f, -99.00404f);
            }

            else
            {
                tmp = main.Database.MySqlGestion.register_loading(player, "");
                NAPI.ClientEvent.TriggerClientEvent(player, "login_form", tmp.social);
            }
            all_players_data.Add(tmp.social, tmp);
            all_players_client.Add(tmp.social, player);*/
        }
        

        [Command("save_player")]
        public void save_player(Client player)
        {
            /*NAPI.Util.ConsoleOutput(player.SocialClubName);
            all_players_data[player.SocialClubName].setInfo.pos = new Database.Vector3 { x = player.Position.X, y = player.Position.Y, z = player.Position.Z };
            Database.MySqlGestion.save_character(player, all_players_data[player.SocialClubName]);*/
        }


        [RemoteEvent("LoginAttempt")]
        public void LoginAttempt(Client player, object[] args)
        {
            /*NAPI.Util.ConsoleOutput("login");
            player = all_players_client[(string)args[1]];
            if ((string)args[0] == all_players_data[(string)args[1]].password)
            {
                all_players_client[(string)args[1]].Position = new Vector3(all_players_data[(string)args[1]].setInfo.pos.x, all_players_data[(string)args[1]].setInfo.pos.y, all_players_data[(string)args[1]].setInfo.pos.z);
                player.TriggerEvent("login_form_d", 0);
            }
            else
            {
                player.TriggerEvent("login_form_d", 1);
            }*/
        }

        [RemoteEvent("RegisterClientGestion")]
        public void RegisterClientGestion(Client player, object[] args) {
            /*NAPI.Task.Run(() =>
            {
                player.TriggerEvent("TakePhotoSave", "register_pictures_"+player.SocialClubName+".png");
                player.TriggerEvent("CharacterSetActive", 0, false);
            }, 2000);*/
        }


        [RemoteEvent("RegisterAttempt")]
        public void RegisterAttempt(Client player, object[] args)
        {
            /*NAPI.Util.ConsoleOutput("register");
            player = all_players_client[(string)args[1]];
            all_players_data[(string)args[1]].password = (string)args[0];
            main.Database.MySqlGestion.register_loading(player, (string)args[0]);

            player.TriggerEvent("login_form_d", 0);
            player.TriggerEvent("id_card_set_event", 0, true);*/

            /*
            player.TriggerEvent("login_form_d", 0);
            //all_players_client[(string)args[1]].Position = new Vector3(406.0395f, -997.3383f, -99.00404f);
            //all_players_client[(string)args[1]].Rotation = new Vector3(0f, 0f, 88f);
            //all_players_client[(string)args[1]].FreezePosition = false;

            //player.Position = new Vector3(406.0395f, -997.3383f, -99.00404f);
            //API.TriggerClientEvent(player, "PedPlate", "mp_character_creation@lineup@female_b", "intro", "Azkaban", " ", " ", " ", -1, 7000);

            player.TriggerEvent("PlayerPlate", "mp_character_creation@customise@male_a", "intro", "Azkaban", "Con", "jordan", "pute", 15, 7500);
            player.TriggerEvent("CharacterUpdate");
            player.TriggerEvent("PlayerPlate", "mp_character_creation@customise@male_a", "intro", "Azkaban", "Con", "jordan", "pute", -1, 7500);
            //player.TriggerEvent( "PlayerPlate", "mp_character_creation@customise@male_a", "intro", "Azkaban", "Con", "jordan", "pute", -1, 7500);
            player.TriggerEvent("MoveCam", 0);*/

        }

    }
}
