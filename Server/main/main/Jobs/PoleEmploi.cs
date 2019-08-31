using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
//using CMAPI = main.Manager.CharacterManager;

namespace main.Jobs
{
    /*class PoleEmploi : Script
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            NAPI.Blip.CreateBlip(458, new Vector3(112.3239f, -752.4673f, 45.75479f), 1, 50, "Pole Emploi");
            NAPI.Blip.CreateBlip(198, new Vector3(-1105.615f, -2734.213f, -8.890509f), 1, 66, "Subway");
            NAPI.Blip.CreateBlip(198, new Vector3(112.9588f, -1721.979f, 28.62934f), 1, 66, "Subway");
            NAPI.Marker.CreateMarker(1, new Vector3(112.3239f, -752.4673f, 44.25479f), new Vector3(), new Vector3(), 1, new Color(255, 0, 0));
            NAPI.Marker.CreateMarker(1, new Vector3(-1105.615f, -2734.213f, -8.890509f), new Vector3(), new Vector3(), 2, new Color(255, 255, 255));
            NAPI.Marker.CreateMarker(1, new Vector3(112.9588f, -1721.979f, 28.62934f), new Vector3(), new Vector3(), 2, new Color(255, 255, 255));
        }

        public PoleEmploi() {

        }

        [RemoteEvent("update_jobs")]
        public void update_jobs(Client player, string jobs) {
            NAPI.Chat.SendChatMessageToPlayer(player, "Changed jobs " + jobs);
            CMAPI.get_data_player(player).user.jobs = jobs;
            if (jobs == "Electricien")
                player.TriggerEvent("electricien_active_sevice", 0, true);
        }

        [RemoteEvent("check_pole_pos")]
        public void enable_jobs_nui(Client player) {
            if (player.Position.DistanceTo(new Vector3(112.3239f, -752.4673f, 45.75479f)) < 10f)
            {
                player.TriggerEvent("enable_jobs_nui", true);
            } else
                player.TriggerEvent("enable_jobs_nui", false);
        }
    }*/
}
