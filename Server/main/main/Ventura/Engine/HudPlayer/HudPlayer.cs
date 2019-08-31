using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using GTANetworkAPI;
using CGAPI = main.Ventura.Gestion.CharacterGestion;
using WAPI = main.Ventura.Permission.WhiteListCommand;
using DAPI = main.Ventura.Gestion.DimensionGestion;
using DUSER = main.Ventura.Database.DataUser;
using LAPI = main.Ventura.Gestion.LogGestion;
using ASAPI = main.Ventura.Stream.Async.Event.AsyncEvent;

namespace main.Ventura.Engine.HudPlayer
{
    class HudPlayer : Script
    {
        public static HudPlayer instance = null;
        
        public HudPlayer()
        {
            if (instance == null)
                instance = this;
        }
        
        private void SetClocks(ref DUSER data)
        {
            for (int i = 0; i < data.user.ticks.Count; i++)
            {
                if (data.user.ticks[i] == 0)
                {
                    switch (i)
                    {
                        case 0:
                            data.user.ticks[i] = DateTime.Now.AddSeconds(90).Ticks;
                            break;
                        case 1:
                            data.user.ticks[i] = DateTime.Now.AddSeconds(50).Ticks;
                            break;
                        case 2:
                            data.user.ticks[i] = DateTime.Now.AddSeconds(10).Ticks;
                            break;
                    }
                }
            }
        }

        private void UpdateClocks(Client client, ref DUSER data)
        {
            for (int i = 0; i < data.user.ticks.Count; i++)
            {
                if (DateTime.Now.Ticks >= data.user.ticks[i])
                {
                    switch (i) {
                        case 0:
                            data.information.Hunger -= 1 * (float)data.user.effect[i];
                            data.user.ticks[i] = 0;
                            SendCEFHUD(client, data);
                            break;
                        case 1:
                            data.information.Water -= 1 * (float)data.user.effect[i];
                            data.user.ticks[i] = 0;
                            SendCEFHUD(client, data);
                            break;
                        case 2:
                            data.information.Alcool -= 1 * (float)data.user.effect[i];
                            data.user.ticks[i] = 0;
                            SendCEFHUD(client, data);
                            break;
                    }
                }
            }
        }

        private void SendCEFHUD(Client client, DUSER data) {
            client.TriggerEvent("ReceiveCommandHUDPlayer", JsonConvert.SerializeObject(new CEFHUD() {
                Food = data.information.Hunger,
                Water = data.information.Water,
                Alcool = data.information.Alcool,
                Voice = data.user.range_vocal,
            }));
        }

        [ServerEvent(Event.Update)]
        public void UpdateClock() {

            DUSER data = null;
            for (int i = 0; i < NAPI.Pools.GetAllPlayers().Count; i++)
            {
                data = CGAPI.GetDataPlayer(NAPI.Pools.GetAllPlayers()[i]);

                if (data == null)
                    continue;

                SetClocks(ref data);
                UpdateClocks(NAPI.Pools.GetAllPlayers()[i], ref data);
            }

        }
    }

    [JsonObject]
    public class CEFHUD {

        public virtual float Food { get; set; }
        public virtual float Water { get; set; }
        public virtual float Alcool { get; set; }
        public virtual float Voice { get; set; }

        public CEFHUD() { }
    }
}
