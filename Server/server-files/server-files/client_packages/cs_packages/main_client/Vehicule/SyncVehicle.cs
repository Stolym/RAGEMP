using System;
using System.Collections.Generic;
using System.Text;
//using Newtonsoft.Json;
using RAGE;
using RAGE.Elements;


namespace main_client.Vehicule
{
   
    /*class VehicleStreamSync
    {
        class SyncVehicle : Events.Script
        {
            int timer = 0;

            public SyncVehicle()
            {
                Events.OnEntityStreamIn += OnEntityStreamIn;
                Events.OnEntityStreamOut += OnEntityStreamOut;
                Events.OnPlayerQuit += OnPlayerQuit;
                Events.Add("VehicleDataStreamEvent", VehicleDataStreamEvent);
                Events.Tick += Tick;
            }

            private void OnPlayerQuit(RAGE.Elements.Player player)
            {
            }

            private void VehicleDataStreamEvent(object[] args)
            {
                ushort remoteID = Convert.ToUInt16(args[0]);
                RAGE.Elements.Vehicle target = Entities.Vehicles.GetAtRemote(remoteID);
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                SyncVehicleData result = JsonConvert.DeserializeObject<SyncVehicleData>(args[1].ToString(), settings);
                
                result.StreamIn();
            }

            private void OnEntityStreamIn(Entity entity)
            {
                if (entity.Type != RAGE.Elements.Type.Vehicle)
                    return;
                var jsonData = entity.GetSharedData("StreamInVehicle");

                if (jsonData == null)
                    return;
                var result = JsonConvert.DeserializeObject<SyncVehicleData>(jsonData.ToString());
                result.StreamIn();
            }

            private void OnEntityStreamOut(Entity entity)
            {
            
            }

            private void update_by_remote(SyncVehicleData data,  uint remoteid) {
                Events.CallRemote("UpdateVehicleData", JsonConvert.SerializeObject(new SyncVehicleData()
                {
                    Name = data.Name,
                    Id = data.Id,
                    RemoteId = data.RemoteId,
                    NumberPlate = data.NumberPlate,
                    IsDrivable = data.IsDrivable,
                    IsBoost = data.IsBoost,
                    IsLock = data.IsLock,
                    IsBootOpen = data.IsBootOpen,
                    IsOn = data.IsOn,
                    NeonLight = data.NeonLight,
                    InteriorLight = data.InteriorLight,
                    AllowNoPassengers = data.AllowNoPassengers,
                    BodyHealth = data.BodyHealth,
                    EngineHealth = data.EngineHealth,
                    DirtLevel = data.DirtLevel,
                    WheelType = data.WheelType,
                    WheelColor = data.WheelColor,
                    NumberPlateIndex = data.NumberPlateIndex,
                    LightState = data.LightState,
                    ColourCombination = data.ColourCombination,
                    InteriorColor = data.InteriorColor,
                    Colour1 = data.Colour1,
                    Pcolour1 = data.Pcolour1,
                    Colour2 = data.Colour2,
                    Pcolour2 = data.Pcolour2,
                    Dcolour = data.Dcolour,
                    WindowTint = data.WindowTint,
                    PearlescentColor = data.PearlescentColor,
                    IndicatorLight = data.IndicatorLight,
                    RollWindow = data.RollWindow,
                    SmashWindow = data.SmashWindow,
                    SmashDoor = data.SmashDoor,
                    ModelDamage = data.ModelDamage,
                }), remoteid);
            }

            private void Tick(List<Events.TickNametagData> nametags)
            {
                if (RAGE.Game.Ped.IsPedInAnyVehicle(RAGE.Elements.Player.LocalPlayer.Handle, true) && timer == 0)
                {
                    int veh = RAGE.Game.Ped.GetVehiclePedIsUsing(RAGE.Elements.Player.LocalPlayer.Handle);

                    RAGE.Elements.Vehicle target = Entities.Vehicles.All.Find(x => x.Handle == veh);
                    var jsonstring = target.GetSharedData("StreamInVehicle");
                    if (jsonstring == null)
                        return;
                    SyncVehicleData data = JsonConvert.DeserializeObject<SyncVehicleData>(jsonstring.ToString());
                    if (data == null)
                        return;
                    bool update = false;
                    for (int i = 0; i < 20 * 20; i++)
                    {
                        Vector3 diff = RAGE.Game.Vehicle.GetVehicleDeformationAtPos(target.Handle, -1f + ((i % 20) * 0.1f), -1f + ((i / 20) * 0.1f), 0);
                        if (diff.DistanceTo(Vector3.Zero) > 0.01f && new Vector3(data.ModelDamage[i].x, data.ModelDamage[i].y, data.ModelDamage[i].z).DistanceTo(Vector3.Zero) == 0f || new Vector3(data.ModelDamage[i].x, data.ModelDamage[i].y, data.ModelDamage[i].z).DistanceTo(diff) > 0.1f) {
                            data.ModelDamage[i].x = diff.X;
                            data.ModelDamage[i].y = diff.Y;
                            data.ModelDamage[i].z = diff.Z;
                            update = true;
                            break;
                        }
                    }

                    Vector3 pos = RAGE.Game.Ui.GetBlipCoords(8);
                    if (pos.X != data.wx || pos.Y != data.wy) {
                        data.wx = pos.X;
                        data.wy = pos.Y;
                        update = true;
                    }

                    for (int i = 0; i < 8 && data.SmashWindow != null; i++)
                    {
                        if (!RAGE.Game.Vehicle.IsVehicleWindowIntact(veh, i) && data.SmashWindow[i] != 1)
                        {
                            data.SmashWindow[i] = 1;
                            update = true;
                        }
                    }

                    for (int i = 0; i < 8 && data.SmashDoor != null; i++)
                    {
                        if (RAGE.Game.Vehicle.IsVehicleDoorDamaged(veh, i) && data.SmashDoor[i] != 1)
                        {
                            data.SmashDoor[i] = 1;
                            update = true;
                        }
                    }

                    /*if (RAGE.Game.Vehicle.GetVehicleDirtLevel(target.Handle) != data.DirtLevel) {
                        data.DirtLevel = RAGE.Game.Vehicle.GetVehicleDirtLevel(target.Handle);
                        update = true;
                    }

                    if (update)
                        update_by_remote(data, target.RemoteId);

                    timer++;
                }
                else if (timer != 0 && timer <= 10)
                    timer++;
                else if (timer >= 10)
                    timer = 0;
            }
        }


        public class Vector3Json
        {
            public float x { get; set; }
            public float y { get; set; }
            public float z { get; set; }

            public Vector3Json()
            {
                x = 0;
                y = 0;
                z = 0;
            }
        }

        public class SyncVehicleData
        {
            public string Name { get; set; }
            public float Heading { get; set; }
            public int Id { get; set; }
            public uint RemoteId { get; set; }
            public string NumberPlate { get; set; }
            public bool IsDrivable { get; set; }
            public bool IsBoost { get; set; }
            public bool IsLock { get; set; }
            public bool IsBootOpen { get; set; }
            public bool IsOn { get; set; }
            public bool NeonLight { get; set; }
            public bool InteriorLight { get; set; }
            public bool AllowNoPassengers { get; set; }
            public float BodyHealth { get; set; }
            public float EngineHealth { get; set; }
            public float DirtLevel { get; set; }
            public int WheelType { get; set; }
            public int WheelColor { get; set; }
            public int NumberPlateIndex { get; set; }
            public int LightState { get; set; }
            public int ColourCombination { get; set; }
            public int InteriorColor { get; set; }
            public int Colour1 { get; set; }
            public int Pcolour1 { get; set; }
            public int Colour2 { get; set; }
            public int Pcolour2 { get; set; }
            public int Dcolour { get; set; }
            public int WindowTint { get; set; }
            public int PearlescentColor { get; set; }
            public int IndicatorLight { get; set; }
            public float x { get; set; }
            public float y { get; set; }
            public float z { get; set; }
            public float wx { get; set; }
            public float wy { get; set; }
            public List<int> RollWindow { get; set; }
            public List<int> SmashWindow { get; set; }
            public List<int> SmashDoor { get; set; }
            public List<int> DoorControl { get; set; }
            public List<int> ModIndex { get; set; }
            public bool[] ModCustom { get; set; }
            public List<int> ModPaintType1 { get; set; }
            public List<int> ModColor1 { get; set; }
            public List<int> ModPaintType2 { get; set; }
            public List<int> ModColor2 { get; set; }
            public List<int> NeonLightsColor { get; set; }
            public bool[] Extra { get; set; }
            public List<Vector3Json> ModelDamage { get; set; }
            

            public SyncVehicleData()
            {
            }

            public SyncVehicleData(RAGE.Elements.Vehicle vehicle)
            {
                this.RemoteId = vehicle.RemoteId;
            }
            
            public void StreamIn()
            {
                RAGE.Elements.Vehicle target = Entities.Vehicles.All.Find(x => x.RemoteId == RemoteId);

                if (target == null)
                    return;
                target.SetDoorsLocked(IsLock == true ? 2 : 1);
                if (IsBootOpen)
                    target.SetDoorOpen(4, false, true);
                else if (!IsBootOpen)
                    target.SetDoorShut(4, true);
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
                
                if (RAGE.Game.Ped.IsPedInVehicle(RAGE.Elements.Player.LocalPlayer.Handle, target.Handle, true) && wx != 0 && wy != 0)
                {
                    RAGE.Game.Invoker.Invoke(RAGE.Game.Natives.SetNewWaypoint, wx, wy);
                    RAGE.Game.Invoker.Invoke(RAGE.Game.Natives.RefreshWaypoint);
                }
                RAGE.Game.Vehicle.SetVehicleNumberPlateText(target.Handle, NumberPlate);
                RAGE.Game.Vehicle.SetVehicleNumberPlateTextIndex(target.Handle, NumberPlateIndex);
                RAGE.Game.Vehicle.SetVehicleWheelType(target.Handle, WheelType);
                RAGE.Game.Vehicle.SetVehicleWindowTint(target.Handle, WindowTint);
                RAGE.Game.Vehicle.SetVehicleColours(target.Handle, Colour1, Colour2);
                RAGE.Game.Vehicle.SetVehicleDirtLevel(target.Handle, DirtLevel);
                for (int i = 0; i < SmashWindow.Count; i++)
                {
                    if (SmashWindow[i] == 1)
                        RAGE.Game.Vehicle.SmashVehicleWindow(target.Handle, i);
                }
                for (int i = 0; i < RollWindow.Count; i++) {
                    if (RollWindow[i] == 0)
                        RAGE.Game.Vehicle.RollUpWindow(target.Handle, i);
                    else
                        RAGE.Game.Vehicle.RollDownWindow(target.Handle, i);
                }

                for (int i = 0; i < SmashDoor.Count; i++)
                {
                    if (SmashDoor[i] == 1)
                        RAGE.Game.Vehicle.SetVehicleDoorBroken(target.Handle, i, true);
                }
                //RAGE.Game.Vehicle.SetVehicleFixed(target.Handle);

                for (int i = 0; i < 20 * 20; i++)
                {
                    if (new Vector3(ModelDamage[i].x, ModelDamage[i].y, ModelDamage[i].z).DistanceTo(Vector3.Zero) > 0.01f)
                    {
                        RAGE.Game.Vehicle.SetVehicleCanBeVisiblyDamaged(target.Handle, true);
                        RAGE.Game.Vehicle.SetVehicleDamage(target.Handle, -1f + (i % 20) * 0.1f, -1, 0, 2500, 500, true);
                        RAGE.Game.Vehicle.SetVehicleDamage(target.Handle, -1f + (i % 20) * 0.1f, 1, 0, 2500, 500, true);
                        RAGE.Game.Vehicle.SetVehicleDamage(target.Handle, -1f + (i % 20) * 0.1f, 0.5f, 0, 2500, 500, true);
                        RAGE.Game.Vehicle.SetVehicleDamage(target.Handle, -1f + (i % 20) * 0.1f, -0.5f, 0, 2500, 500, true);
                        RAGE.Game.Entity.ForceEntityAiAndAnimationUpdate(target.Handle);
                        //ForceEntityAiAndAnimationUpdate(vehicle)
                    }
                }
            }
        }
    }*/
}

//Player


/*
RAGE.Game.Ped.SetPedDecoration
RAGE.Game.Ped.SetPedFacialDecoration
RAGE.Game.Ped.SetPedHairColor
RAGE.Game.Ped.SetPedDesiredHeading
RAGE.Game.Ped.SetPedHeadBlendData
RAGE.Game.Ped.SetPedHeadOverlay
RAGE.Game.Ped.SetPedHeadOverlayColor
RAGE.Game.Ped.SetPedComponentVariation
RAGE.Game.Ped.SetPedConfigFlag
RAGE.Game.Ped.SetPedEyeColor
RAGE.Game.Ped.SetPedFaceFeature
RAGE.Game.Ped.SetPedHelmet
RAGE.Game.Ped.SetPedHelmetFlag
RAGE.Game.Ped.SetPedHelmetPropIndex
RAGE.Game.Ped.SetPedHelmetTextureIndex
RAGE.Game.Ped.SetPedMotionBlur
RAGE.Game.Ped.SetPedMovementClipset
RAGE.Game.Ped.SetPedPropIndex
RAGE.Game.Ped.SetPedRagdollBlockingFlags
RAGE.Game.Ped.CreateSynchronizedScene
*/


//Vehicle

/*
RAGE.Game.Vehicle.SetVehicleAllowNoPassengersLockon
RAGE.Game.Vehicle.SetVehicleBodyHealth
RAGE.Game.Vehicle.SetVehicleColourCombination
RAGE.Game.Vehicle.SetVehicleColours
RAGE.Game.Vehicle.SetVehicleCustomPrimaryColour
RAGE.Game.Vehicle.SetVehicleCustomSecondaryColour
RAGE.Game.Vehicle.SetVehicleDashboardColour
RAGE.Game.Vehicle.SetVehicleDirtLevel
RAGE.Game.Vehicle.SetVehicleDoorControl
RAGE.Game.Vehicle.SetVehicleEngineHealth
RAGE.Game.Vehicle.SetVehicleEngineOn
RAGE.Game.Vehicle.SetVehicleExtra
RAGE.Game.Vehicle.SetVehicleExtraColours
RAGE.Game.Vehicle.SetVehicleIndicatorLights
RAGE.Game.Vehicle.SetVehicleInteriorColour
RAGE.Game.Vehicle.SetVehicleInteriorlight
RAGE.Game.Vehicle.SetVehicleLights
RAGE.Game.Vehicle.SetVehicleMod
RAGE.Game.Vehicle.SetVehicleModColor1
RAGE.Game.Vehicle.SetVehicleModColor2
RAGE.Game.Vehicle.SetVehicleNeonLightEnabled
RAGE.Game.Vehicle.SetVehicleNeonLightsColour
RAGE.Game.Vehicle.SetVehicleNumberPlateText
RAGE.Game.Vehicle.SetVehicleNumberPlateTextIndex
RAGE.Game.Vehicle.SetVehicleRocketBoostActive
RAGE.Game.Vehicle.SetVehicleRocketBoostPercentage
RAGE.Game.Vehicle.SetVehicleRocketBoostRefillTime
RAGE.Game.Vehicle.SetVehicleSiren
RAGE.Game.Vehicle.SetVehicleSirenSound
RAGE.Game.Vehicle.SetVehicleUndriveable
RAGE.Game.Vehicle.SetVehicleWheelType
RAGE.Game.Vehicle.SetVehicleWindowTint
RAGE.Game.Vehicle.SmashVehicleWindow
RAGE.Game.Vehicle.RollUpWindow
RAGE.Game.Vehicle.RollDownWindow
*/
