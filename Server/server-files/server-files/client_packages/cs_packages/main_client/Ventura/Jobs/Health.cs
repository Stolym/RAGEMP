using System;
using System.Collections.Generic;
using System.Text;
using RAGE;
using RAGE.Elements;
//using Newtonsoft.Json;

namespace main_client.LSDH
{
    /*class Health
    {
        class HeatlhGestion : Events.Script {

            public HeatlhGestion()
            {
                Events.OnEntityStreamIn += OnEntityStreamIn;
                Events.OnEntityStreamOut += OnEntityStreamOut;
                Events.OnPlayerQuit += OnPlayerQuit;
                Events.Add("HeatlhDataStreamEvent", HeatlhDataStreamEvent);
                Events.Tick += Tick;
            }

            private void HeatlhDataStreamEvent(object[] args)
            {
                ushort remoteID = Convert.ToUInt16(args[0]);
                HeatlhData result = JsonConvert.DeserializeObject<HeatlhData>(args[1].ToString());
                if (result == null)
                    return;
                result.StreamIn();
            }

            private void RagdollFalling() {
                foreach (RAGE.Elements.Player p in RAGE.Elements.Entities.Players.All) {
                    var jsonstring = p.GetSharedData("StreamInHealth");
                    if (jsonstring == null)
                        return;
                    HeatlhData data = JsonConvert.DeserializeObject<HeatlhData>(jsonstring.ToString());
                    if (data == null)
                        return;
                    if (!data.IsAlive)
                    {
                        p.SetCanRagdoll(true);
                        p.SetToRagdoll(10000, 10000, 1, false, false, false);
                    }
                }
            }


            private void Tick(List<Events.TickNametagData> nametags)
            {
                RAGE.Elements.Player target = Entities.Players.All.Find(x => x.RemoteId == RAGE.Elements.Player.LocalPlayer.RemoteId);
                RAGE.Game.Player.RestorePlayerStamina(1.0F);

                RagdollFalling();
                if (target == null)
                    return;
                var jsonstring = target.GetSharedData("StreamInHealth");
                if (jsonstring == null)
                    return;
                HeatlhData data = JsonConvert.DeserializeObject<HeatlhData>(jsonstring.ToString());
                if (data == null)
                    return;
                if (RAGE.Elements.Player.LocalPlayer.GetHealth() == 0 && data.IsAlive)
                {
                    Chat.Output("Salut B");
                    data.IsAlive = false;
                    Events.CallRemote("UpdateHealthData", JsonConvert.SerializeObject(data));
                }
                else if (RAGE.Game.Cam.IsScreenFadedOut() && !data.IsAlive)
                {
                    RAGE.Game.Cam.DoScreenFadeIn(1);
                }
            }

            private void OnPlayerQuit(RAGE.Elements.Player player)
            {
            }

            private void OnEntityStreamOut(Entity entity)
            {
            }

            private void OnEntityStreamIn(Entity entity)
            {
                if (entity.Type != RAGE.Elements.Type.Player)
                    return;
                var jsonstring = entity.GetSharedData("StreamInHealth");
                if (jsonstring == null)
                    return;
                HeatlhData data = JsonConvert.DeserializeObject<HeatlhData>(jsonstring.ToString());
                if (data == null)
                    return;
                data.StreamIn();
            }
        }


        public class HeatlhData
        {
            public ushort RemoteId { get; set; }
            public bool IsAlive { get; set; }
            public List<int> bone_break { get; set; }

            public HeatlhData() { }

            public void StreamIn()
            {
                RAGE.Elements.Player target = RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == RemoteId);
                if (!IsAlive)
                {
                    //Chat.Output("Ragdoll "+target.RemoteId+" "+RAGE.Elements.Player.LocalPlayer.RemoteId);
                    target.SetCanRagdoll(true);
                    target.SetToRagdoll(10000, 10000, 1, false, false, false);
                }
            }

        }
    }*/
}
