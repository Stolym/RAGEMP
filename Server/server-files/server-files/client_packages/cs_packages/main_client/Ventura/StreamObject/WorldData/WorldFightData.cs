using System;
using System.Collections.Generic;
using System.Text;
using RAGE;
using main_client.Ventura.StreamObject.DataModel;
using Newtonsoft.Json;

namespace main_client.Ventura.StreamObject.WorldData
{
    [JsonObject]
    class WorldFightData : DataModel.DataModel
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int LocalId { get; set; }
        public virtual int RemoteId { get; set; }
        public virtual uint Dimensions { get; set; }
        public virtual int TargetRemoteId { get; set; }
        public virtual List<int> TaskActives { get; set; }
        public virtual List<int> FlagActives { get; set; }

        private void LocalTaskFlagGestion() {
            RAGE.Elements.Player Local = RAGE.Elements.Player.LocalPlayer;
            bool update = false;

            for (int i = 0; i < 600; i++)
            {
                if ((RAGE.Game.Ped.GetPedConfigFlag(Local.Handle, i, true) && !FlagActives.Contains(i)) && (update = true))
                    FlagActives.Add(i);
                else if (!RAGE.Game.Ped.GetPedConfigFlag(Local.Handle, i, true) && FlagActives.Contains(i) && (update = true))
                    FlagActives.Remove(i);
            }
            for (int i = 0; i < 500; i++)
            {
                if (RAGE.Game.Ai.GetIsTaskActive(Local.Handle, i) && !TaskActives.Contains(i) && (update = true))
                    TaskActives.Add(i);
                else if (!RAGE.Game.Ai.GetIsTaskActive(Local.Handle, i) && TaskActives.Contains(i) && (update = true))
                    TaskActives.Remove(i);
            }
            if ((RAGE.Game.Ped.IsPedInMeleeCombat(Local.Handle) && TargetRemoteId == -1) && (update = true)) {
                int nhandle = RAGE.Game.Ped.GetMeleeTargetForPed(Local.Handle);
                if (RAGE.Elements.Entities.Players.All.Find(x => x.Handle == nhandle) == null)
                    return;
                TargetRemoteId = RAGE.Elements.Entities.Players.All.Find(x => x.Handle == nhandle).RemoteId;
            } else if ((!RAGE.Game.Ped.IsPedInMeleeCombat(Local.Handle) && TargetRemoteId != -1) && (update = true))
                TargetRemoteId = -1;
            if (update)
                Events.CallRemote("UpdateFightData", JsonConvert.SerializeObject(this));
        }

        private void TaskGestion(RAGE.Elements.Player target)
        {
            for (int i = 0; i < TaskActives.Count; i++) {
                switch (TaskActives[i])
                {
                    case 128:
                        if (TargetRemoteId == -1)
                            return;
                        RAGE.Game.Ai.TaskPutPedDirectlyIntoMelee(target.Handle, RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == TargetRemoteId).Handle, 0, 0, 0, false);
                        break;
                    case 129:
                        if (TargetRemoteId == -1)
                            return;
                        RAGE.Game.Ai.TaskCombatPed(target.Handle, RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == TargetRemoteId).Handle, 0, 16);
                        break;
                }
            }
        }

        private void FlagGestion(RAGE.Elements.Player target)
        {
            for (int i = 0; i < 600; i++)
            {
                if (FlagActives.Contains(i))
                    RAGE.Game.Ped.SetPedConfigFlag(target.Handle, i, true);
                else
                    RAGE.Game.Ped.SetPedConfigFlag(target.Handle, i, false);
            }
        }

        public void StreamIn()
        {
            RAGE.Elements.Player target = RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == RemoteId);

            if (target == null || target.Handle == 0)
                return;
            if (target.RemoteId == RAGE.Elements.Player.LocalPlayer.RemoteId)
                LocalTaskFlagGestion();
            else
            {
                TaskGestion(target);
                FlagGestion(target);
            }
        }

        public void StreamOut()
        {
            RAGE.Elements.Player target = RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == RemoteId);

            if (target == null || (target.Handle == 0 && LocalId == 0))
                return;
        }
    }
}
