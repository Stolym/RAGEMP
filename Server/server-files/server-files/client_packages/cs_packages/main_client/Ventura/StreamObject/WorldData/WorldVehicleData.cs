using System;
using System.Collections.Generic;
using System.Text;
using main_client.Ventura.StreamObject.DataModel;
using Newtonsoft.Json;
using RAGE.Elements;

namespace main_client.Ventura.StreamObject.WorldData
{
    [JsonObject]
    class WorldVehicleData : DataModel.DataModel
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int LocalId { get; set; }
        public virtual int RemoteId { get; set; }
        public virtual uint Dimensions { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual Constant.Constant.UpdateFlagsClient Type { get; set; }
        public virtual string NumberPlate { get; set; }
        public virtual bool IsDrivable { get; set; }
        public virtual bool IsBoost { get; set; }
        public virtual bool IsLock { get; set; }
        public virtual bool IsOn { get; set; }
        public virtual bool NeonLight { get; set; }
        public virtual bool InteriorLight { get; set; }
        public virtual bool AllowNoPassengers { get; set; }
        public virtual float BodyHealth { get; set; }
        public virtual float EngineHealth { get; set; }
        public virtual float DirtLevel { get; set; }
        public virtual int WheelType { get; set; }
        public virtual int WheelColor { get; set; }
        public virtual int NumberPlateIndex { get; set; }
        public virtual int LightState { get; set; }
        public virtual int ColourCombination { get; set; }
        public virtual int InteriorColor { get; set; }
        public virtual int Colour1 { get; set; }
        public virtual int Pcolour1 { get; set; }
        public virtual int Colour2 { get; set; }
        public virtual int Pcolour2 { get; set; }
        public virtual int Dcolour { get; set; }
        public virtual int WindowTint { get; set; }
        public virtual int PearlescentColor { get; set; }
        public virtual int IndicatorLight { get; set; }
        public virtual float x { get; set; }
        public virtual float y { get; set; }
        public virtual float z { get; set; }
        public virtual bool IsGpsActive { get; set; }
        public virtual float wx { get; set; }
        public virtual float wy { get; set; }
        public virtual bool Xenon { get; set; }
        public virtual bool TireSmoke { get; set; }
        public virtual List<bool> Indicators { get; set; }
        public virtual List<bool> RollWindow { get; set; }
        public virtual List<bool> DoorControl { get; set; }
        public virtual List<float> DoorRatio { get; set; }
        public virtual List<bool> SmashWindow { get; set; }
        public virtual List<bool> SmashDoor { get; set; }
        public virtual List<int> ModIndex { get; set; }
        public virtual List<bool> ModCustom { get; set; }
        public virtual List<int> ModPaintType1 { get; set; }
        public virtual List<int> ModColor1 { get; set; }
        public virtual List<int> ModPaintType2 { get; set; }
        public virtual List<int> ModColor2 { get; set; }
        public virtual List<int> NeonLightsColor { get; set; }
        public virtual List<int> TireSmokeColor { get; set; }
        public virtual List<bool> ModelDamaged { get; set; }
        public virtual List<bool> Extra { get; set; }
        public virtual float Heading { get; set; }
        public virtual float Gazol { get; set; }

        [JsonIgnore]
        private bool FreezeLag = false;
        [JsonIgnore]
        private long tick = 0;

        public WorldVehicleData() { }
        public WorldVehicleData(RAGE.Elements.Player player)
        {
            this.RemoteId = player.RemoteId;
        }

        public void StreamIn()
        {
            RAGE.Elements.Vehicle target = RAGE.Elements.Entities.Vehicles.All.Find(x => x.RemoteId == RemoteId);
            
            if (target == null || target.Handle == 0)
                return;
            //LightGestion(target);
            //EngineGestion(target);
            //FuelGestion(target);
            //DoorGestion(target);
            //SmashGestion(target);
            target.SetDoorsLocked(IsLock == true ? 2 : 1);

            for (int i = 0; i < ModIndex.Count; i++)
                RAGE.Game.Vehicle.SetVehicleMod(target.Handle, i, ModIndex[i], false);
            //DoorGestion(target);
            /*RAGE.Game.Vehicle.SetVehicleAllowNoPassengersLockon(target.Handle, AllowNoPassengers);
            RAGE.Game.Vehicle.SetVehicleBodyHealth(target.Handle, BodyHealth);
            RAGE.Game.Vehicle.SetVehicleEngineHealth(target.Handle, EngineHealth);
            RAGE.Game.Vehicle.SetVehicleEngineOn(target.Handle, IsOn, true, false);
            RAGE.Game.Vehicle.SetVehicleNumberPlateText(target.Handle, NumberPlate);
            RAGE.Game.Vehicle.SetVehicleNumberPlateTextIndex(target.Handle, NumberPlateIndex);
            RAGE.Game.Vehicle.SetVehicleWheelType(target.Handle, WheelType);*/
            RAGE.Game.Vehicle.SetVehicleWindowTint(target.Handle, WindowTint);
            RAGE.Game.Vehicle.SetVehicleColours(target.Handle, Colour1, Colour2);
            //SmashGestion(target);
            
            if (RAGE.Game.Ped.IsPedInVehicle(RAGE.Elements.Player.LocalPlayer.Handle, target.Handle, false) && IsGpsActive)
            {
                RAGE.Game.Invoker.Invoke(RAGE.Game.Natives.SetNewWaypoint, wx, wy);
                RAGE.Game.Invoker.Invoke(RAGE.Game.Natives.RefreshWaypoint);
            }
            /*
            RAGE.Game.Vehicle.SetVehicleAllowNoPassengersLockon(target.Handle, AllowNoPassengers);
            RAGE.Game.Vehicle.SetVehicleBodyHealth(target.Handle, BodyHealth);
            RAGE.Game.Vehicle.SetVehicleColourCombination(target.Handle, ColourCombination);
            RAGE.Game.Vehicle.SetVehicleColours(target.Handle, Colour1, Colour2);
            RAGE.Game.Vehicle.SetVehicleCustomPrimaryColour(target.Handle, Pcolour1, Pcolour1, Pcolour1);
            RAGE.Game.Vehicle.SetVehicleCustomSecondaryColour(target.Handle, Pcolour2, Pcolour2, Pcolour2);
            RAGE.Game.Vehicle.SetVehicleDashboardColour(target.Handle, Dcolour);
            RAGE.Game.Vehicle.SetVehicleDirtLevel(target.Handle, DirtLevel);
            RAGE.Game.Vehicle.SetVehicleEngineHealth(target.Handle, EngineHealth);
            RAGE.Game.Vehicle.SetVehicleEngineOn(target.Handle, IsOn, true, false);
            for (int i = 0; i < Extra.Length; i++) 
                RAGE.Game.Vehicle.SetVehicleExtra(target.Handle, i, Extra[i]);
            RAGE.Game.Vehicle.SetVehicleExtraColours(target.Handle, PearlescentColor, WheelColor);
            RAGE.Game.Vehicle.SetVehicleIndicatorLights(target.Handle, 0, true);
            RAGE.Game.Vehicle.SetVehicleInteriorColour(target.Handle, InteriorColor);
            RAGE.Game.Vehicle.SetVehicleInteriorlight(target.Handle, InteriorLight);
            RAGE.Game.Vehicle.SetVehicleLights(target.Handle, LightState);
            for (int i = 0; i < ModIndex.Length; i++)
                RAGE.Game.Vehicle.SetVehicleMod(target.Handle, i, ModIndex[i], true);
            RAGE.Game.Vehicle.SetVehicleModColor1(target.Handle, ModPaintType1[0], ModPaintType1[1], 0);
            RAGE.Game.Vehicle.SetVehicleModColor2(target.Handle, ModPaintType2[0], 0);
            for (int i = 0; i < 3; i++)
                RAGE.Game.Vehicle.SetVehicleNeonLightEnabled(target.Handle, i, NeonLight);
            RAGE.Game.Vehicle.SetVehicleNeonLightsColour(target.Handle, NeonLightsColor[0], NeonLightsColor[1], NeonLightsColor[2]);
            RAGE.Game.Vehicle.SetVehicleNumberPlateText(target.Handle, NumberPlate);
            RAGE.Game.Vehicle.SetVehicleNumberPlateTextIndex(target.Handle, NumberPlateIndex);
            RAGE.Game.Vehicle.SetVehicleRocketBoostActive(target.Handle, IsBoost);
            RAGE.Game.Vehicle.SetVehicleUndriveable(target.Handle, IsDrivable);
            RAGE.Game.Vehicle.SetVehicleWheelType(target.Handle, WheelType);
            RAGE.Game.Vehicle.SetVehicleWindowTint(target.Handle, WindowTint);
            

            //RAGE.Game.Vehicle.SetVehicleFixed(target.Handle);
            */

            //LocalGestionVehicle(target);
        }

        private void FuelGestion(Vehicle target)
        {
            return;
        }

        private void EngineGestion(Vehicle target)
        {
            RAGE.Game.Vehicle.SetVehicleEngineOn(target.Handle, IsOn, true, true);
            RAGE.Game.Vehicle.SetVehicleEngineHealth(target.Handle, EngineHealth);
            RAGE.Game.Vehicle.SetForceHdVehicle(target.Handle, false);
            RAGE.Game.Vehicle.SetFarDrawVehicles(false);
            RAGE.Game.Vehicle.SetVehicleBodyHealth(target.Handle, BodyHealth);
            RAGE.Game.Vehicle.SetVehicleDirtLevel(target.Handle, DirtLevel);
            if (BodyHealth == 0 || EngineHealth == 0)
                RAGE.Game.Vehicle.ExplodeVehicle(target.Handle, true, false);
            return;
        }

        private void LightGestion(Vehicle target)
        {
            RAGE.Game.Vehicle.SetVehicleIndicatorLights(target.Handle, 0, Indicators[0]);
            RAGE.Game.Vehicle.SetVehicleIndicatorLights(target.Handle, 1, Indicators[1]);
            RAGE.Game.Vehicle.SetVehicleLights(target.Handle, LightState);
            RAGE.Game.Vehicle.SetVehicleLightsMode(target.Handle, 0);
            RAGE.Game.Vehicle.ToggleVehicleMod(target.Handle, 20, TireSmoke);
            if (TireSmoke)
                RAGE.Game.Vehicle.SetVehicleTyreSmokeColor(target.Handle, TireSmokeColor[0], TireSmokeColor[1], TireSmokeColor[2]);
            RAGE.Game.Vehicle.ToggleVehicleMod(target.Handle, 22, Xenon);
            for (int i = 0; i < 4; i++)
                RAGE.Game.Vehicle.SetVehicleNeonLightEnabled(target.Handle, i, NeonLight);
            if (NeonLight)
                RAGE.Game.Vehicle.SetVehicleNeonLightsColour(target.Handle, NeonLightsColor[0], NeonLightsColor[1], NeonLightsColor[2]);
            RAGE.Game.Vehicle.SetVehicleLightMultiplier(target.Handle, 1);
            return;
        }

        private void LocalGestionVehicle(Vehicle target)
        {
            bool update = false;

            if (target.Position.DistanceTo(RAGE.Elements.Player.LocalPlayer.Position) > 5f)
                return;

            update = update == true ? true : LocalSmashGestion(target);
            update = update == true ? true : LocalGestionDoor(target);
            update = update == true ? true : LocalGestionDirt(target);
            if (update)
                RAGE.Events.CallRemote("UpdateWorldVehicleData", target.RemoteId, JsonConvert.SerializeObject(this));
        }

        private bool LocalGestionDirt(Vehicle target)
        {
            if (RAGE.Game.Vehicle.GetVehicleDirtLevel(target.Handle) != DirtLevel)
            {
                DirtLevel = RAGE.Game.Vehicle.GetVehicleDirtLevel(target.Handle);
                return true;
            }
            return false;
        }

        private bool LocalSmashGestion(Vehicle target)
        {
            bool update = false;

            if (RAGE.Game.Vehicle.GetPedInVehicleSeat(target.Handle, -1, 0) == RAGE.Elements.Player.LocalPlayer.Handle) {
                if (BodyHealth != RAGE.Game.Vehicle.GetVehicleBodyHealth(target.Handle) && (update = true))
                    BodyHealth = RAGE.Game.Vehicle.GetVehicleBodyHealth(target.Handle);
                if (EngineHealth != RAGE.Game.Vehicle.GetVehicleEngineHealth(target.Handle) && (update = true))
                    EngineHealth = RAGE.Game.Vehicle.GetVehicleEngineHealth(target.Handle);
            }
            return update;
        }

        private bool LocalGestionDoor(Vehicle target)
        {
            bool update = false;

            for (int i = 0; i < 8; i++)
            {
                if (DoorRatio[i] != RAGE.Game.Vehicle.GetVehicleDoorAngleRatio(target.Handle, i) && (update = true))
                    DoorRatio[i] = RAGE.Game.Vehicle.GetVehicleDoorAngleRatio(target.Handle, i);
            }
            return update;
        }


        public void DoorGestion(RAGE.Elements.Vehicle target)
        {
            for (int i = 0; i < 8; i++)
            {
                if (DoorRatio[i] == 0 && RAGE.Game.Vehicle.GetVehicleDoorAngleRatio(target.Handle, i) > 0.5f)
                    RAGE.Game.Vehicle.SetVehicleDoorShut(target.Handle, i, true);
                else if (DoorRatio[i] == 1 && RAGE.Game.Vehicle.GetVehicleDoorAngleRatio(target.Handle, i) < 0.5f)
                    RAGE.Game.Vehicle.SetVehicleDoorOpen(target.Handle, i, false, true);
                else if (DoorRatio[i] != RAGE.Game.Vehicle.GetVehicleDoorAngleRatio(target.Handle, i))
                    RAGE.Game.Vehicle.SetVehicleDoorControl(target.Handle, i, 5, DoorRatio[i]);
            }
        }

        public void SmashGestion(RAGE.Elements.Vehicle target)
        {
            for (int i = 0; i < SmashWindow.Count; i++)
            {
                if (SmashWindow[i])
                    RAGE.Game.Vehicle.SmashVehicleWindow(target.Handle, i);
            }
            for (int i = 0; i < RollWindow.Count; i++)
            {
                if (RollWindow[i])
                    RAGE.Game.Vehicle.RollUpWindow(target.Handle, i);
                else
                    RAGE.Game.Vehicle.RollDownWindow(target.Handle, i);
            }

            for (int i = 0; i < SmashDoor.Count; i++)
            {
                if (SmashDoor[i])
                    RAGE.Game.Vehicle.SetVehicleDoorBroken(target.Handle, i, true);
            }
            for (int i = 0; i < ModelDamaged.Count; i++)
            {
                if (ModelDamaged[i])
                {
                    RAGE.Game.Vehicle.SetVehicleCanBeVisiblyDamaged(target.Handle, true);
                    RAGE.Game.Vehicle.SetVehicleDamage(target.Handle, -1f + (i % 20) * 0.1f, -1, 0, 2500, 500, true);
                    RAGE.Game.Vehicle.SetVehicleDamage(target.Handle, -1f + (i % 20) * 0.1f, 1, 0, 2500, 500, true);
                    RAGE.Game.Vehicle.SetVehicleDamage(target.Handle, -1f + (i % 20) * 0.1f, 0.5f, 0, 2500, 500, true);
                    RAGE.Game.Vehicle.SetVehicleDamage(target.Handle, -1f + (i % 20) * 0.1f, -0.5f, 0, 2500, 500, true);
                    RAGE.Game.Entity.ForceEntityAiAndAnimationUpdate(target.Handle);
                }
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
