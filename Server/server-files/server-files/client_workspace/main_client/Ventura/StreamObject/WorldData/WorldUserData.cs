using System;
using System.Collections.Generic;
using System.Text;
using main_client.Ventura.StreamObject.DataModel;

namespace main_client.StreamObject.WorldData
{
    /*class WorldUserData : IDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LocalId { get; set; }
        public ushort RemoteId { get; set; }
        public int Dimensions { get; set; }
        public Utils.Constant.UpdateFlagsClient Type { get; set; }
        public bool sex { get; set; }
        public byte ShapeFirst { get; set; }
        public byte ShapeSecond { get; set; }
        public byte ShapeThird { get; set; }
        public byte SkinFirst { get; set; }
        public byte SkinSecond { get; set; }
        public byte SkinThird { get; set; }
        public float ShapeMix { get; set; }
        public float SkinMix { get; set; }
        public float ThirdMix { get; set; }
        public int firstHeadShape { get; set; }
        public int secondHeadShape { get; set; }
        public int firstSkinTone { get; set; }
        public int secondSkinTone { get; set; }
        public float headMix { get; set; }
        public float skinMix { get; set; }
        public int eyesColor { get; set; }
        public List<float> FaceFeature { get; set; }
        public Dictionary<int, object[]> HeadOverlay { get; set; }
        public Dictionary<int, object[]> HeadOverlayColor { get; set; }
        public Dictionary<int, object[]> Decoration { get; set; }
        public Dictionary<int, object[]> FacialDecoration { get; set; }

        public WorldUserData() { }
        public WorldUserData(RAGE.Elements.Player player)
        {
            this.RemoteId = player.RemoteId;
        }

        public void StreamIn()
        {
            RAGE.Elements.Player target = RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == RemoteId);

            if (target == null || target.Handle == 0)
                return;
            if (sex)
                target.Model = 0x9C9EFFD8;
            else if (!sex)
                target.Model = Convert.ToUInt32(1885233650);
            RAGE.Game.Ped.SetPedBlendFromParents(target.Handle, firstHeadShape, secondHeadShape, headMix, skinMix);
            for (int i = 0; i < Decoration.Count; i++)
            {
                RAGE.Game.Ped.SetPedDecoration(RAGE.Elements.Player.LocalPlayer.Handle, RAGE.Game.Misc.GetHashKey(Decoration[i][0].ToString()), Convert.ToUInt32((int)Decoration[i][1]));
            }
            for (int i = 0; i < FacialDecoration.Count; i++)
            {
                RAGE.Game.Ped.SetPedFacialDecoration(RAGE.Elements.Player.LocalPlayer.Handle, Convert.ToUInt32(FacialDecoration[i][0]), Convert.ToUInt32(FacialDecoration[i][1]));
            }
            for (int i = 0; i < FaceFeature.Count; i++)
            {
                RAGE.Game.Ped.SetPedFaceFeature(RAGE.Elements.Player.LocalPlayer.Handle, i, FaceFeature[i]);
            }
            for (int i = 0; i < HeadOverlay.Count; i++)
            {
                RAGE.Game.Ped.SetPedHeadOverlay(RAGE.Elements.Player.LocalPlayer.Handle, i, Convert.ToInt32(HeadOverlay[i][0]), (float)Convert.ToDouble(HeadOverlay[i][1]));
                if (i == 2)
                    RAGE.Game.Ped.SetPedHeadOverlayColor(RAGE.Elements.Player.LocalPlayer.Handle, Convert.ToInt32(HeadOverlay[i][0]), 1, Convert.ToInt32(HeadOverlayColor[i][0]), Convert.ToInt32(HeadOverlayColor[i][1]));
                else if (i == 5 || i == 8)
                    RAGE.Game.Ped.SetPedHeadOverlayColor(RAGE.Elements.Player.LocalPlayer.Handle, Convert.ToInt32(HeadOverlay[i][0]), 2, Convert.ToInt32(HeadOverlayColor[i][0]), Convert.ToInt32(HeadOverlayColor[i][1]));
                else
                    RAGE.Game.Ped.SetPedHeadOverlayColor(RAGE.Elements.Player.LocalPlayer.Handle, Convert.ToInt32(HeadOverlay[i][0]), 0, Convert.ToInt32(HeadOverlayColor[i][0]), Convert.ToInt32(HeadOverlayColor[i][1]));
            }
            //RAGE.Game.Ped.SetPedBlendFromParents(RAGE.Elements.Player.LocalPlayer.Handle, rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
            RAGE.Game.Ped.SetPedHeadBlendData(RAGE.Elements.Player.LocalPlayer.Handle, ShapeFirst, ShapeSecond, ShapeThird, SkinFirst, SkinSecond, SkinThird, ShapeMix, SkinMix, ThirdMix, false);
            //RAGE.Game.Ped.SetPedHairColor(RAGE.Elements.Player.LocalPlayer.Handle, , variable[20]);
            RAGE.Game.Ped.SetPedEyeColor(RAGE.Elements.Player.LocalPlayer.Handle, eyesColor);
        }

        public void StreamOut()
        {
            RAGE.Elements.Player target = RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == RemoteId);

            if (target == null || (target.Handle == 0 && LocalId == 0))
                return;
        }
    }*/
}
