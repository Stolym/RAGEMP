using System;
using System.Collections.Generic;
using System.Text;
using main_client.Ventura.StreamObject.DataModel;
using RAGE;

namespace main_client.Ventura.StreamObject.WorldData
{
    class WorldRigidBodyData : DataModel.DataModel
    {
        
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int LocalId { get; set; }
        public virtual uint RemoteId { get; set; }
        public virtual int Dimensions { get; set; }
        public bool IsActive { get; set; }
        public virtual Constant.Constant.UpdateFlagsClient Type { get; set; }
        public virtual List<bool> IsBreak { get; set; }
        public virtual bool IsAlive { get; set; }


        public WorldRigidBodyData() { }
        public WorldRigidBodyData(RAGE.Elements.Player player)
        {
            this.RemoteId = player.RemoteId;
        }

        public void StreamIn()
        {
            RAGE.Elements.Player target = RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == RemoteId);

            if (target == null || target.Handle == 0)
                return;
            /*
         * index
         * 0 head
         * 1 chest
         * 2 Back
         * 3 left shoulder
         * 4 right shoulder
         * 5 left arm
         * 6 right arm
         * 7 left forarm
         * 8 right forarm
         * 9 left thigh
         * 10 right thigh
         * 11 left shins
         * 12 right shins
         * 13 left foot
         * 14 right foot
         * 
                int entityRagdoll = RAGE.Game.Ped.GetPedBoneIndex(player.Handle, list[i]);
                if (RAGE.Game.Ped.GetPedLastDamageBone(player.Handle, ref entityRagdoll))
                {
                    Chat.Output("Life Skell id " + list[i] + " life entity " + entityRagdoll);
                }
         */
            if (!IsAlive)
            {
                target.SetCanRagdoll(true);
                target.SetToRagdoll(10000, 10000, 1, false, false, false);
                RAGE.Game.Entity.ApplyForceToEntity(target.Handle, 1, 0, 0, 0, 0, 0, -1, 0, false, false, true, false, false);
            }
            else if (IsBreak[0])
            {
                if (!target.IsDead(0))
                    Events.CallRemote("PlayerCheckDeath", target.RemoteId);
                target.SetHealth(0);
            }
            else if (IsBreak[9] || IsBreak[10])
            {
                RAGE.Game.Streaming.RequestAnimDict("");
                while (!RAGE.Game.Streaming.HasAnimDictLoaded("")) { RAGE.Game.Invoker.Wait(0); }
                RAGE.Game.Ped.SetPedAlternateWalkAnim(target.Handle, "", "", 0, true);
            }
        }

        public void StreamOut()
        {
            RAGE.Elements.Player target = RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == RemoteId);

            if (target == null || (target.Handle == 0 && LocalId == 0))
                return;

            if (IsAlive)
            {
                target.SetHealth(100);
            }
        }
    }
}
