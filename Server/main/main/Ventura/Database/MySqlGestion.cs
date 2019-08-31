using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using GTANetworkAPI;
using System.IO;
using System.IO.Compression;
using MySql.Data.MySqlClient;
using FAPI = main.Ventura.Database.Formatter.Formatter;
using DUser = main.Ventura.Database.DataUser;


namespace main.Database
{

    class MySqlGestion : Script
    {
        public static MySqlConnection connection { get; set; }
        private string server { get => "127.0.0.1"; }
        private string database { get => "ventura"; }
        private string uid { get => "root"; }
        private string password { get => "StolZaez1!"; }
        private string connectionString { get; set; }


        public MySqlGestion() {

        }

        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + "; SSLMODE=none;";
            connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
            }
            catch (MySqlException e) {
                NAPI.Util.ConsoleOutput(e.ToString());
            }
        }

        public static bool PlayerExist(Client player) {
            try
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM `account` WHERE `social_club`='" + player.SocialClubName + "'", connection);
                System.Data.Common.DbDataReader rdr = command.ExecuteReader();
                while (rdr.Read())
                {
                    if (rdr.GetString(0) == player.SocialClubName)
                    {
                        if (rdr != null)
                            rdr.Close();
                        return (true);
                    }
                }
                if (rdr != null)
                    rdr.Close();
            }
            catch (Exception ex) {
                NAPI.Util.ConsoleOutput(ex.Message);
            }
            return (false);
        }

        public static void RegisterDataPlayer(Client player, DUser data)
        {
            if (data == null)
                return;
            try
            {
                MySqlCommand comInsert = new MySqlCommand("INSERT Into account(social_club, user_data) VALUES(@social, @data)", connection);
                comInsert.Parameters.AddWithValue("@social", player.SocialClubName);
                comInsert.Parameters.AddWithValue("@data", FAPI.SerializeObjectJson<DUser>(data));
                comInsert.Prepare();
                comInsert.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                NAPI.Util.ConsoleOutput(ex.Message);
            }
        }

        public static void RegisterDataPlayerWithPosition(Client player, DUser data, Vector3 pos)
        {
            data.information.Position = new Ventura.Database.Vector3(pos.X, pos.Y, pos.Z);
            if (data == null)
                return;
            try
            {
                MySqlCommand comInsert = new MySqlCommand("INSERT Into account(social_club, user_data) VALUES(@social, @data)", connection);
                comInsert.Parameters.AddWithValue("@social", player.SocialClubName);
                comInsert.Parameters.AddWithValue("@data", FAPI.SerializeObjectJson<DUser>(data));
                comInsert.Prepare();
                comInsert.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                NAPI.Util.ConsoleOutput("Debug");
                NAPI.Util.ConsoleOutput(ex.Message);
            }
        }


        public static DUser GetDataPlayer(Client player)
        {
            int row = 1;
            bool active = false;
            int size = 1024 * 1024 * 1024;
            int index_size = 0;
            byte[] buffer = new byte[size];
            string json = "";
            DUser data = null;
            MySqlCommand command = new MySqlCommand("SELECT * FROM `account` WHERE `social_club`='" + player.SocialClubName + "'", connection);
            System.Data.Common.DbDataReader rdr = command.ExecuteReader();
            try
            {
                while (rdr.Read())
                {
                    if (rdr.GetString(0) == player.SocialClubName)
                    {
                        json = rdr.GetString(1);
                        active = true;
                        /*index_size = (int)rdr.GetBytes(0, 0, buffer, 0, size);
                        using (FileStream fs = new FileStream("./stream.dat", FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            fs.Write(buffer, 0, index_size);
                        }*/
                        break;
                    }
                    row++;
                }
            }
            finally
            {
                if (rdr != null)
                    rdr.Close();
                if (active == true)
                {
                    data = FAPI.DeserializeObjectJson<DUser>(json);
                }
            }
            return (data);
        }


        public static void UpdateDataPlayer(Client player, DUser save)
        {
            try
            {
                MySqlCommand commInsert = new MySqlCommand("UPDATE account SET user_data = @data WHERE social_club = @id", connection);
                commInsert.Parameters.AddWithValue("@data", FAPI.SerializeObject<DUser>(save));
                commInsert.Parameters.AddWithValue("@id", player.SocialClubName);
                commInsert.Prepare();
                commInsert.ExecuteNonQuery();
            }
            catch (Exception ex) {
                NAPI.Util.ConsoleOutput(ex.Message);
            }
        }

    }
}
