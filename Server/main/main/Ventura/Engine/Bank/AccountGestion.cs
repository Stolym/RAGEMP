using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using GTANetworkAPI;
using Newtonsoft.Json;
using CGAPI = main.Ventura.Gestion.CharacterGestion;
using WAPI = main.Ventura.Permission.WhiteListCommand;
using DAPI = main.Ventura.Gestion.DimensionGestion;
using DUSER = main.Ventura.Database.DataUser;
using LAPI = main.Ventura.Gestion.LogGestion;
using ASAPI = main.Ventura.Stream.Async.Event.AsyncEvent;
using RWAPI = main.Ventura.Database.ReaderWriter.ReaderWriter;

namespace main.Ventura.Engine.Bank
{
    /*
     * Account create
     * Bank Online
     * 
     * */

    


    [JsonObject]
    public class AccountData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Money { get; set; }
        public string Password { get; set; }
        public List<string> CardLink { get; set; }
        public List<string> Action { get; set; }
    }

    class AccountGestion : Script 
    {
        public static AccountGestion instance = null;
        private List<AccountData> list_account = new List<AccountData>();
        private string path = "./data/Bank/account.txt";

        public AccountGestion() {
            if (instance == null)
                instance = this;
        }

        public void TransfertAccountToAccount() {

        }

        [Command("save_bank")]
        public void SaveAllAccountBank(Client client) {
            RWAPI.ClearFilePath(path);
            for (int i = 0; i < list_account.Count; i++)
                RWAPI.WriteLineinPath(path, JsonConvert.SerializeObject(list_account[i]));
        }

        public void AddNewAccountToBank(Client client, string json)
        {
            AccountData data = JsonConvert.DeserializeObject<AccountData>(json);

            if (!list_account.Contains(data))
                list_account.Add(data);
        }

        public void TransfertAccountToPlayer(Client client, int account_id, float amount) {
            DUSER data = CGAPI.GetDataPlayer(client);
            AccountData account = list_account.Find(x => x.Id == account_id);

            if (data == null || account == null)
                return;
            if (account.Money - amount < 0)
            {
                client.SendNotification("You don't have found for this");
                return;
            }
            account.Money -= amount;
            data.information.ActualMoney += amount;
        }


        [Command("create_account_bank")]
        public void create_account_bank(Client client, string name, float money)
        {
            list_account.Add(new AccountData()
            {
                Id = 0,
                Action = new List<string>(),
                CardLink = new List<string>(),
                Money = money,
                Name = name,
            });
        }
        
    }
}
