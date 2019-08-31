using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using main.Ventura.Constant;

namespace main.Ventura.Stream
{
    class UpdateGestionData : Script
    {
        public UpdateGestionData() { }



        [RemoteEvent("UpdateWorldVehicleData")]
        public void UpdateWorldVehicleData(Client client, uint vremote, string json)
        {
            Vehicle veh = NAPI.Pools.GetAllVehicles().Find(x => x.Handle.Value == vremote);

            if (veh == null)
                return;
            Synchronization.StreamGestionAsync.instance.UltimeAsync(veh, json, Constants.StreamFlags.StreamIn, Constants.UpdateFlags.WorldVehiculeData, 0, client.Dimension);
        }

        [RemoteEvent("UpdateWorldClothData")]
        public void UpdateWorldClothData(Client client, string json)
        {
            if (client == null)
                return;
            Synchronization.StreamGestionAsync.instance.UltimeAsync(client, json, Constants.StreamFlags.StreamIn, Constants.UpdateFlags.WorldClothData, 0, client.Dimension);
        }


        [RemoteEvent("UpdateWorldAnimationData")]
        public void UpdateWorldAnimationData(Client client, string json)
        {
            if (client == null)
                return;
            Synchronization.StreamGestionAsync.instance.UltimeAsync(client, json, Constants.StreamFlags.StreamIn, Constants.UpdateFlags.WorldAnimationData, 0, client.Dimension);
        }



        [RemoteEvent("UpdateWorldBodyData")]
        public void UpdateWorldBodyData(Client client, string json)
        {
            if (client == null)
                return;
            Synchronization.StreamGestionAsync.instance.UltimeAsync(client, json, Constants.StreamFlags.StreamIn, Constants.UpdateFlags.WorldBodyData, 0, client.Dimension);
        }

        [RemoteEvent("UpdateFightData")]
        public void UpdateFightData(Client client, string json)
        {
            if (client == null)
                return;
            Synchronization.StreamGestionAsync.instance.UltimeAsync(client, json, Constants.StreamFlags.StreamIn, Constants.UpdateFlags.WorldFightData, 0, client.Dimension);
        }


        [RemoteEvent("UpdateWorldAttachData")]
        public void UpdateWorldAttachData(Client client, string json)
        {
            if (client == null)
                return;
            Synchronization.StreamGestionAsync.instance.UltimeAsync(client, json, Constants.StreamFlags.StreamIn, Constants.UpdateFlags.WorldAttachData, 0, client.Dimension);
        }

        [RemoteEvent("UpdateIntroductionTask")]
        public void UpdateIntroductionTask(Client client, object[] args)
        {
            if (args == null)
                client.SetSharedData("IntroductionTaskStream", null);
            else
                client.SetSharedData("IntroductionTaskStream", args[0].ToString());

            foreach (Client c in NAPI.Pools.GetAllPlayers())
            {

                if (args == null)
                    c.TriggerEvent("IntroductionTaskStreamUpdate", client.Handle.Value, null);
                else
                    c.TriggerEvent("IntroductionTaskStreamUpdate", client.Handle.Value, args[0].ToString());
            }
        }

    }
}
