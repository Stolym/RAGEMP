using System;
using System.Collections.Generic;
using System.Text;
using RAGE;

namespace main_client.Ventura.Engine
{
    class Vocal : Events.Script
    {
        public static Vocal instance = null;
        private bool active = false;

        private bool Browser = false;
        private static string tsname = "";
        private static List<string> playerNames = new List<string>();
        private static bool keyStatus;
        private static int lastcheck;

        public Vocal()
        {
            instance = this;
            Events.Tick += Tick;
            RAGE.Events.Add("ConnectTeamspeak", ConnectTeamspeak);
            //RAGE.Events.Add("DisconnectTeamspeak", DisconnectTeamspeak);
        }

        public void ConnectTeamspeak(object[] args)
        {
            active = true;
        }

        private void Tick(List<Events.TickNametagData> nametags)
        {
            if (active)
            {
                if (Browser == false)
                {
                    Events.CallLocal("createBrowser", "TeamspeakForm", $"http://localhost:15555/players/" + RAGE.Elements.Player.LocalPlayer.Name);
                    Browser = true;
                }
                else if (Browser)
                {
                    for (var i = 0; i < RAGE.Elements.Entities.Players.All.Count; i++)
                    {
                        if (RAGE.Elements.Entities.Players.All[i] != null && !RAGE.Elements.Entities.Players.All[i].Exists)
                            continue;
                        playerNames = new List<string>();

                        var streamedPlayerPos = RAGE.Elements.Entities.Players.All[i].Position;
                        var distance = RAGE.Elements.Player.LocalPlayer.Position.DistanceTo2D(streamedPlayerPos);
                        var range = 25;
                        var rotation = Math.PI / 180 * (RAGE.Elements.Player.LocalPlayer.GetRotation(0).Z * -1);

                        float volumeModifier = 0;

                        //if (RAGE.Elements.Entities.Players.All[i].GetSharedData("TsName") == null)
                        //    return;

                        if (distance > 5)
                            volumeModifier = (distance * -8 / 10);

                        if (volumeModifier > 0)
                            volumeModifier = 0;

                        if (distance < range)
                        {
                            var subPos = streamedPlayerPos.Subtract(RAGE.Elements.Player.LocalPlayer.Position);

                            var x = subPos.X * Math.Cos(rotation) - subPos.Y * Math.Sin(rotation);
                            var y = subPos.X * Math.Sin(rotation) + subPos.Y * Math.Cos(rotation);

                            x = x * 10 / range;
                            y = y * 10 / range;

                            playerNames.Add(RAGE.Elements.Entities.Players.All[i].Name.ToString() + "~" + (Math.Round(x * 1000) / 1000) + "~" + (Math.Round(y * 1000) / 1000) + "~0~" + (Math.Round(volumeModifier * 1000) / 1000));
                        }
                    }

                    Events.CallLocal("changeBrowser", "TeamspeakForm", $"http://localhost:15555/players/{tsname}/{string.Join(";", playerNames)}/");
                }
            }
        }


        private void Teamspeak_LipSync(object[] args)
        {
            RAGE.Elements.Player player = RAGE.Elements.Entities.Players.GetAtRemote(Convert.ToUInt16(args[0]));
            if (player != null)
            {
                bool speak = Convert.ToBoolean(args[1].ToString());

                if (speak)
                    player.PlayFacialAnim("mic_chatter", "mp_facial");
                else
                    player.PlayFacialAnim("mood_normal_1", "facials@gen_male@variations@normal");
            }
        }

        private static void OnTick(List<Events.TickNametagData> nametags)
        {
          
            /*if (RAGE.Game.Misc.GetGameTimer() - lastcheck < 500) return;

            var player = RAGE.Elements.Player.LocalPlayer;
            var rotation = Math.PI / 180 * (player.GetRotation(0).Z * -1);
            var streamedPlayers = RAGE.Elements.Entities.Players.All;
            var playerNames = new List<string>();

            if (player.GetSharedData("CALLING_PLAYER_NAME") != null && player.GetSharedData("CALL_IS_STARTED") != null && (bool)player.GetSharedData("CALL_IS_STARTED"))
            {
                var callingPlayerName = player.GetSharedData("CALLING_PLAYER_NAME").ToString();
                if (callingPlayerName != "")
                    playerNames.Add(callingPlayerName + "~10~0~0~3");
            }

            for (var i = 0; i < streamedPlayers.Count; i++)
            {
                if (streamedPlayers[i] != null && !streamedPlayers[i].Exists)
                    continue;

                if (streamedPlayers[i].GetSharedData("TsName") == null)
                    continue;

                var streamedPlayerPos = streamedPlayers[i].Position;
                var distance = player.Position.DistanceTo2D(streamedPlayerPos);

                var voiceRange = "Normal";
                if (streamedPlayers[i].GetSharedData("VOICE_RANGE") != null)
                    voiceRange = streamedPlayers[i].GetSharedData("VOICE_RANGE").ToString();

                float volumeModifier = 0;
                var range = 12;

                if (voiceRange == "Weit")
                    range = 50;

                else if (voiceRange == "Kurz")
                    range = 5;

                if (distance > 5)
                    volumeModifier = (distance * -8 / 10);

                if (volumeModifier > 0)
                    volumeModifier = 0;

                if (distance < range)
                {
                    var subPos = streamedPlayerPos.Subtract(player.Position);

                    var x = subPos.X * Math.Cos(rotation) - subPos.Y * Math.Sin(rotation);
                    var y = subPos.X * Math.Sin(rotation) + subPos.Y * Math.Cos(rotation);

                    x = x * 10 / range;
                    y = y * 10 / range;

                    playerNames.Add(streamedPlayers[i].GetSharedData("TsName").ToString() + "~" + (Math.Round(x * 1000) / 1000) + "~" + (Math.Round(y * 1000) / 1000) + "~0~" + (Math.Round(volumeModifier * 1000) / 1000));
                }
            }

            if (tsBrowser == null)
                tsBrowser = new HtmlWindow($"http://localhost:15555/players/{tsname}/{string.Join(";", playerNames)}/");
            else
                tsBrowser.Url = $"http://localhost:15555/players/{tsname}/{string.Join(";", playerNames)}/";

            playerNames.Clear();
            lastcheck = RAGE.Game.Misc.GetGameTimer();*/
        }
        
    }
}
