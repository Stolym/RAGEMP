﻿using System;
using System.Collections.Generic;
using System.Text;

using GTANetworkAPI;
using Newtonsoft.Json;
//using CGAPI = main.Manager.CharacterManager;

namespace main.Engine.IdCard
{
    /*class IdCard : Script
    {
        [RemoteEvent("AddIdCard")]
        public void AddIdCard(Client client, object[] args) {
            Synchronization.PasswordSync data = JsonConvert.DeserializeObject<Synchronization.PasswordSync>(args[0].ToString());
            if (CGAPI.get_data_player(client) != null && data != null)
            {
                CGAPI.get_data_player(client).inventory.add_matrix_item_in_stack_with_params(new Item.Passport() {
                    name = data.name,
                    last_name = data.lastname,
                    birthday = data.birth,
                    nationality = data.nat,
                    place_of_birth = data.from_birth,
                    sex = data.sex,
                    date_expiration = data.exp,
                    date_issue = data.del,
                    height = data.height,
                });
            }
        }

        [RemoteEvent("GiveIdCard")]
        public void GiveIdCard(Client client, object[] args) {
            uint remoteId = Convert.ToUInt16(args[0]);
            Client other = NAPI.Pools.GetAllPlayers().Find(x => x.Handle.Value == remoteId);
            Database.DataUser dataOther = CGAPI.get_data_player(client);
            

            if (other == null || dataOther == null)
                return;
            
            Item.Passport passport = (Item.Passport)CGAPI.get_data_player(client).inventory.get_matrix_item_in_stack(0);
            other.TriggerEvent("DisplayIdCard", JsonConvert.SerializeObject(new Synchronization.PasswordSync
            {
                name = passport.name,
                lastname = passport.last_name,
                birth = passport.birthday,
                exp = passport.date_expiration,
                del = passport.date_issue,
                from_birth = passport.place_of_birth,
                sex = passport.sex,
                height = passport.height,
                nat = passport.nationality,
            }));
        }
        
    }*/
}