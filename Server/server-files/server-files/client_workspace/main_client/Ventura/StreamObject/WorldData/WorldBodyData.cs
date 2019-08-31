using System;
using System.Collections.Generic;
using System.Text;
using main_client.Ventura.StreamObject.DataModel;
using RAGE;

namespace main_client.Ventura.StreamObject.WorldData
{
    struct HeadBlend
    {
        int shapeFirst, shapeSecond, shapeThird;
        int skinFirst, skinSecond, skinThird;
        float shapeMix, skinMix, thirdMix;
    };

    class WorldBodyData : DataModel.DataModel
    {

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int LocalId { get; set; }
        public virtual int RemoteId { get; set; }
        public virtual uint Dimensions { get; set; }
        public bool IsActive { get; set; }
        public virtual Constant.Constant.UpdateFlagsClient Type { get; set; }
        public virtual int ShapeFirst { get; set; }
        public virtual int ShapeSecond { get; set; }
        public virtual int ShapeThird { get; set; }
        public virtual int SkinFirst { get; set; }
        public virtual int SkinSecond { get; set; }
        public virtual int SkinThird { get; set; }
        public virtual float ShapeMix { get; set; }
        public virtual float SkinMix { get; set; }
        public virtual float ThirdMix { get; set; }
        public virtual int firstHeadShape { get; set; }
        public virtual int secondHeadShape { get; set; }
        public virtual int firstSkinTone { get; set; }
        public virtual int secondSkinTone { get; set; }
        public virtual float headMix { get; set; }
        public virtual float skinMix { get; set; }
        public virtual int eyesColor { get; set; }
        public virtual int sex { get; set; }
        public virtual int overlayHair { get; set; }
        //public virtual List<int[]> tattoo { get; set; }
        public virtual List<float> facefeature { get; set; }
        public virtual List<List<float>> headOverlay { get; set; }
        public virtual List<int> decoration { get; set; }
        public virtual List<int> facialDecoration { get; set; }

        public int headBlend = 0;
        public HeadBlend actual; 

        public WorldBodyData() { }
        public WorldBodyData(RAGE.Elements.Player player)
        {
            this.RemoteId = player.RemoteId;
        }


        public void StreamIn()
        {
            int[] array = new int[] { 2, 1, 10, 0, 3, 5, 6, 11, 4, 5 };
            RAGE.Elements.Player target = RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == RemoteId);

            if (target == null || target.Handle == 0)
                return;
            if (!RAGE.Game.Ped.HasPedHeadBlendFinished(target.Handle))
                return;
            if (sex == 0 && target.Model != 1885233650)
                target.Model = 1885233650;
            else if (sex == 1 && target.Model != 2627665880)
                target.Model = 2627665880;

            RAGE.Game.Ped.ClearAllPedProps(target.Handle);
            RAGE.Game.Ped.ClearPedFacialDecorations(target.Handle);
            RAGE.Game.Ped.ClearPedDecorations(target.Handle);
            RAGE.Game.Ped.SetPedMinMoveBlendRatio(target.Handle, -2f);
            RAGE.Game.Ped.SetPedMaxMoveBlendRatio(target.Handle, 2f);
            RAGE.Game.Ped.SetPedHeadBlendData(target.Handle, ShapeFirst, ShapeSecond, ShapeThird, ShapeFirst, ShapeSecond, ShapeThird, ShapeMix, skinMix, ThirdMix, false);
            RAGE.Game.Ped.SetPedHairColor(target.Handle, firstHeadShape, 0);
            RAGE.Game.Ped.SetPedEyeColor(target.Handle, eyesColor);
            for (int i = 0; i < headOverlay.Count; i++)
            {
                if (headOverlay[i][0] != 0)
                    RAGE.Game.Ped.SetPedHeadOverlay(target.Handle, array[i], Convert.ToInt32(headOverlay[i][0]), 1);
                else
                    RAGE.Game.Ped.SetPedHeadOverlay(target.Handle, array[i], 0, 0);
            }
            for (int i = 0; i < headOverlay.Count; i++) {
                if (headOverlay[i][1] != 0)
                    RAGE.Game.Ped.SetPedHeadOverlayColor(target.Handle, array[i], array[i] == 0 || array[i] == 1 || array[i] == 2 || array[i] == 10 ? 1 : array[i] == 4 || array[i] == 5 ? 2 : 0, Convert.ToInt32(headOverlay[i][1]), Convert.ToInt32(headOverlay[i][1]));
                else
                    RAGE.Game.Ped.SetPedHeadOverlayColor(target.Handle, array[i], array[i] == 0 || array[i] == 1 || array[i] == 2 || array[i] == 10 ? 1 : array[i] == 4 || array[i] == 5 ? 2 : 0, 0, 0);
            }
            if (facefeature.Count < 1)
                return;
            for (int i = 0; i < facefeature.Count; i++)
                RAGE.Game.Ped.SetPedFaceFeature(target.Handle, i, facefeature[i]);
            for (int i = 0; i < decoration.Count; i++)
            {
                if (decoration[i] != 0)
                    RAGE.Game.Ped.SetPedDecoration(target.Handle, RAGE.Game.Misc.GetHashKey(Constant.Constant.overlayHair[decoration[i]].Item1), RAGE.Game.Misc.GetHashKey(Constant.Constant.overlayHair[decoration[i]].Item2));
            }
        }

        public void StreamOut()
        {
            RAGE.Elements.Player target = RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == RemoteId);

            if (target == null || (target.Handle == 0 && LocalId == 0))
                return;
        }
    }
    /*   class WorldBodyData : IDataModel
       {
           public int Id { get; set; }
           public string Name { get; set; }
           public int LocalId { get; set; }
           public ushort RemoteId { get; set; }
           public int Dimensions { get; set; }
           public Utils.Constant.UpdateFlagsClient Type { get; set; }
           public List<bool> bone_broken { get; set; }
           public bool IsAlive { get; set; }

           public WorldBodyData() { }
           public WorldBodyData(RAGE.Elements.Player player)
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
            * 
               if (!IsAlive) {
                   target.SetCanRagdoll(true);
                   target.SetToRagdoll(10000, 10000, 1, false, false, false);
                   RAGE.Game.Entity.ApplyForceToEntity(target.Handle, 1, 0, 0, 0, 0, 0, -1, 0, false, false, true, false, false);
               } else if (bone_broken[0]) {
                   if (!target.IsDead(0))
                       Events.CallRemote("PlayerCheckDeath", target.RemoteId);
                   target.SetHealth(0);
               } else if (bone_broken[9] || bone_broken[10]) {
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

               if (IsAlive) {
                   target.SetHealth(100);
               }
           }
       }*/
}
