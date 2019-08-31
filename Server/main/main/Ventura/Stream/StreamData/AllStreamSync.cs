using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using ZeroFormatter;
using GTANetworkAPI;

namespace main.Ventura.Stream.StreamData
{

    [JsonObject]
    public class ZFVector3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }

        public ZFVector3()
        {
            x = 0;
            y = 0;
            z = 0;
        }
        
        public ZFVector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }


    [JsonObject]
    public class WorldAnimationData
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int LocalId { get; set; }
        public virtual ushort RemoteId { get; set; }
        public virtual uint Dimensions { get; set; }
        public virtual main.Ventura.Constant.Constants.UpdateFlags Type { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual string Dict { get; set; }
        public virtual string Anim { get; set; }
        public virtual float Speed { get; set; }
        public virtual int Flags { get; set; }
        public virtual float SpeedMultiplier { get; set; }
        public virtual int Duration { get; set; }
        public virtual bool LockX { get; set; }
        public virtual bool LockY { get; set; }
        public virtual bool LockZ { get; set; }
        public virtual float Playback { get; set; }
        public virtual long tick { get; set; }

        public virtual WorldAnimationData next { get; set; }

        public WorldAnimationData() { }
    }


    [ZeroFormattable]
    public class WorldSceneData
    {
        [Index(0)]
        public virtual int ID { get; set; }

        [Index(1)]
        public virtual string Name { get; set; }

        [Index(2)]
        public virtual int LocalId { get; set; }

        [Index(3)]
        public virtual List<uint> RemoteId { get; set; }

        [Index(4)]
        public virtual uint Dimensions { get; set; }

        [Index(5)]
        public virtual main.Ventura.Constant.Constants.UpdateFlags Type { get; set; }

        [Index(6)]
        public virtual bool IsActive { get; set; }

        [Index(7)]
        public virtual List<string> Dict { get; set; }

        [Index(8)]
        public virtual List<string> Anim { get; set; }

        [Index(9)]
        public virtual List<float> Speed { get; set; }

        [Index(10)]
        public virtual List<int> Flags { get; set; }

        [Index(11)]
        public virtual List<float> SpeedMultiplier { get; set; }

        [Index(12)]
        public virtual List<int> Duration { get; set; }

        [Index(13)]
        public virtual List<bool> LockX { get; set; }

        [Index(14)]
        public virtual List<bool> LockY { get; set; }

        [Index(15)]
        public virtual List<bool> LockZ { get; set; }

        [Index(16)]
        public virtual ZFVector3 SceneOrigin { get; set; }

        [Index(17)]
        public virtual ZFVector3 SceneRotation { get; set; }

        [Index(18)]
        public virtual List<int> Bone { get; set; }

        [Index(19)]
        public virtual List<float> Playback { get; set; }

        [Index(20)]
        public virtual bool IsObject { get; set; }


        public WorldSceneData() { }
    }

    [JsonObject]
    class WorldPedData
    {
        public int Handle { get; set; }
        public int Hashcode { get; set; }
        public int PedType { get; set; }

        public uint HashcodeModel { get; set; }
        public int LocalId { get; set; }

        public float nx { get; set; }
        public float ny { get; set; }
        public float nz { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
        public float heading { get; set; }
    }

        [JsonObject]
    public class WorldClothData
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int LocalId { get; set; }
        public virtual int RemoteId { get; set; }
        public virtual main.Ventura.Constant.Constants.UpdateFlags Type { get; set; }
        public virtual uint Dimensions { get; set; }
        public virtual List<List<int>> cloth { get; set; }
        public virtual bool IsService { get; set; }
        
        public WorldClothData() { }
    }


    class WorldJobsActivityData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LocalId { get; set; }
        public ushort RemoteId { get; set; }
        public uint Dimensions { get; set; }
        public main.Ventura.Constant.Constants.UpdateFlags Type { get; set; }
        public bool IsActive { get; set; }
        public string Dict { set; get; }
        public string Anim { get; set; }
        public float speed { get; set; }
        public int flags { get; set; }

        public WorldJobsActivityData() { }

    }


    class WorldSeatData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LocalId { get; set; }
        public ushort RemoteId { get; set; }
        public int Dimensions { get; set; }
        public main.Ventura.Constant.Constants.UpdateFlags Type { get; set; }
        public bool IsActive { get; set; }
        public string Dict { set; get; }
        public string Anim { get; set; }
        public float speed { get; set; }
        public int flags { get; set; }

        public WorldSeatData() { }

    }

    public class WorldBodyData
    {
        public WorldBodyData() { }

        public void SetDefault()
        {
            ShapeFirst = 0;
            ShapeSecond = 0;
            ShapeThird = 0;
            ShapeMix = 0;
            SkinFirst = 0;
            SkinSecond = 0;
            SkinThird = 0;
            SkinMix = 0;
            firstHeadShape = 0;
            secondHeadShape = 0;
            firstSkinTone = 0;
            secondSkinTone = 0;
            headMix = 0;
            skinMix = 0;
            eyesColor = 0;
            sex = 0;
            facefeature = new List<float>();
            headOverlay = new List<List<float>>();
            decoration = new List<int>();
            facialDecoration = new List<int>();
        }


        public int Id { get; set; }
        public string Name { get; set; }
        public int LocalId { get; set; }
        public ushort RemoteId { get; set; }
        public uint Dimensions { get; set; }
        public main.Ventura.Constant.Constants.UpdateFlags Type { get; set; }
        public virtual byte ShapeFirst { get; set; }
        public virtual byte ShapeSecond { get; set; }
        public virtual byte ShapeThird { get; set; }
        public virtual byte SkinFirst { get; set; }
        public virtual byte SkinSecond { get; set; }
        public virtual byte SkinThird { get; set; }
        public virtual float ShapeMix { get; set; }
        public virtual float SkinMix { get; set; }
        public virtual float ThirdMix { get; set; }
        public virtual int firstHeadShape { get; set; }
        public virtual int secondHeadShape { get; set; }
        public virtual int firstSkinTone { get; set; }
        public virtual int secondSkinTone { get; set; }
        public virtual float headMix { get; set; }
        public virtual int sex { get; set; }
        public virtual float skinMix { get; set; }
        public virtual int eyesColor { get; set; }
        public virtual List<float> facefeature { get; set; }
        public virtual List<List<float>> headOverlay { get; set; }
        public virtual List<int> decoration { get; set; }
        public virtual List<int> facialDecoration { get; set; }
    }

    [ZeroFormattable]
    class WorldRigidBodyData
    {
        [Index(0)]
        public virtual int Id { get; set; }

        [Index(1)]
        public virtual string Name { get; set; }

        [Index(2)]
        public virtual int LocalId { get; set; }

        [Index(3)]
        public virtual ushort RemoteId { get; set; }

        [Index(4)]
        public virtual uint Dimensions { get; set; }

        [Index(5)]
        public bool IsActive { get; set; }

        [Index(6)]
        public virtual main.Ventura.Constant.Constants.UpdateFlags Type { get; set; }
        
        [Index(7)]
        public virtual List<bool> IsBreak { get; set; }

        [Index(8)]
        public virtual bool IsAlive { get; set; }


        public WorldRigidBodyData() { }

    }

    [JsonObject]
    class WorldVehicleData
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int LocalId { get; set; }
        public virtual int RemoteId { get; set; }
        public virtual uint Dimensions { get; set; }
        public bool IsActive { get; set; }
        public virtual main.Ventura.Constant.Constants.UpdateFlags Type { get; set; }
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
        public virtual List<bool> ModelDamaged { get; set; }
        public virtual List<bool> Extra { get; set; }
        public virtual List<int> TireSmokeColor { get; set; }
        public virtual bool TireSmoke { get; set; }

        public virtual float Heading { get; set; }
        public virtual float Gazol { get; set; }
        public virtual bool Xenon { get; set; }

        public virtual Engine.Inventory.Container contain { get; set; }

        public void SetDefault() {
            Id = 0;
            Name = "";
            LocalId = 0;
            RemoteId = 0;
            Dimensions = 0;
            TireSmoke = false;
            IsActive = false;
            IsBoost = false;
            IsDrivable = true;
            IsGpsActive = false;
            IsLock = false;
            IsOn = true;
            Heading = 0;
            Gazol = 100;
            Extra = new List<bool>();
            NumberPlate = "";
            NumberPlateIndex = 0;
            ModelDamaged = new List<bool>();
            NeonLight = false;
            NeonLightsColor = new List<int>() { 0, 0, 0 };
            ModColor1 = new List<int>();
            ModColor2 = new List<int>();
            ModCustom = new List<bool>();
            ModIndex = new List<int>();
            ModPaintType1 = new List<int>();
            TireSmokeColor = new List<int>() { 0, 0, 0 };
            ModPaintType2 = new List<int>();
            Indicators = new List<bool>() { false, false };
            SmashDoor = new List<bool>();
            SmashWindow = new List<bool>();
            DoorControl = new List<bool>() { false, false, false, false, false, false, false, false };
            DoorRatio = new List<float>() { 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f };
            RollWindow = new List<bool>();
            wy = 0f;
            wx = 0f;
            x = 0;
            y = 0;
            z = 0;
            Xenon = false;
            IndicatorLight = 0;
            PearlescentColor = 0;
            WindowTint = 0;
            Dcolour = 0;
            Colour1 = 0;
            Colour2 = 0;
            Pcolour1 = 0;
            Pcolour2 = 0;
            ColourCombination = 0;
            LightState = 0;
            AllowNoPassengers = false;
            BodyHealth = 1000;
            EngineHealth = 1000;
            DirtLevel = 0;
            WheelColor = 0;
            WheelType = 0;
            Type = Constant.Constants.UpdateFlags.WorldVehiculeData;
            contain = new Engine.Inventory.Container();
        }

        public WorldVehicleData() { }

    }


    [JsonObject]
    class WorldObjectData
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int LocalId { get; set; }
        public virtual ushort RemoteId { get; set; }
        public virtual uint Dimensions { get; set; }
        public bool IsActive { get; set; }
        public virtual main.Ventura.Constant.Constants.UpdateFlags Type { get; set; }
        public virtual main.Ventura.Engine.Constant.Constant.StructInventoryHash ObjectType { get; set; }
        public virtual long HashCode { get; set; }
        public virtual ZFVector3 Position { get; set; }

        public WorldObjectData() { }

    }



    class WorldSeedData
    {
        [Index(0)]
        public virtual int Id { get; set; }

        [Index(1)]
        public virtual string Name { get; set; }

        [Index(2)]
        public virtual int LocalId { get; set; }

        [Index(3)]
        public virtual ushort RemoteId { get; set; }

        [Index(4)]
        public virtual int Dimensions { get; set; }

        [Index(5)]
        public bool IsActive { get; set; }

        [Index(6)]
        public virtual main.Ventura.Constant.Constants.UpdateFlags Type { get; set; }
        
        [Index(7)]
        public virtual uint HashCode { get; set; }

        [Index(8)]
        public virtual ZFVector3 Position { get; set; }

        [Index(9)]
        public virtual int Step { get; set; }

        [Index(10)]
        public virtual long NextTick { get; set; }

        public WorldSeedData() { }

    }


    class WorldAttachData
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual int LocalId { get; set; }
        public virtual ushort RemoteId { get; set; }
        public virtual uint Dimensions { get; set; }
        public virtual main.Ventura.Constant.Constants.UpdateFlags Type { get; set; }
        public virtual int Bone { get; set; }
        public virtual bool IsDynamic { get; set; }
        public virtual bool IsNetwork { get; set; }
        public virtual main.Ventura.Database.Vector3 Position { get; set; }
        public virtual main.Ventura.Database.Vector3 Rotation { get; set; }
        public virtual bool P9 { get; set; }
        public virtual bool UseSoftPinning { get; set; }
        public virtual bool Collision { get; set; }
        public virtual bool IsPed { get; set; }
        public virtual int VertexIndex { get; set; }
        public virtual bool LockRotation { get; set; }
        public virtual uint Hashcode { get; set; }
        public virtual bool IsFakeObject { get; set; }
        public virtual bool IsAttached { get; set; }

        public WorldAttachData() { }

    }

    [JsonObject]
    class WorldFightData
    {

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int LocalId { get; set; }
        public virtual int RemoteId { get; set; }
        public virtual uint Dimensions { get; set; }
        public virtual int TargetRemoteId { get; set; }
        public virtual List<int> TaskActives { get; set; }
        public virtual List<int> FlagActives { get; set; }


        public WorldFightData() { }

    }


    class WorldIdentityData
    {
        [Index(0)]
        public virtual int Id { get; set; }

        [Index(1)]
        public virtual string Name { get; set; }

        [Index(2)]
        public virtual int LocalId { get; set; }

        [Index(3)]
        public virtual ushort RemoteId { get; set; }

        [Index(4)]
        public virtual int Dimensions { get; set; }

        [Index(5)]
        public bool IsActive { get; set; }

        [Index(6)]
        public virtual main.Ventura.Constant.Constants.UpdateFlags Type { get; set; }

        [Index(7)]
        public virtual float ActualMoney { get; set; }

        [Index(8)]
        public virtual float Hunger { get; set; }

        [Index(9)]
        public virtual float Water { get; set; }

        [Index(10)]
        public virtual float Alcool { get; set; }

        public WorldIdentityData() { }

    }

    class WorldUserData
    {
        [Index(0)]
        public virtual int Id { get; set; }

        [Index(1)]
        public virtual string Name { get; set; }

        [Index(2)]
        public virtual int LocalId { get; set; }

        [Index(3)]
        public virtual ushort RemoteId { get; set; }

        [Index(4)]
        public virtual int Dimensions { get; set; }

        [Index(5)]
        public bool IsActive { get; set; }

        [Index(6)]
        public virtual main.Ventura.Constant.Constants.UpdateFlags Type { get; set; }

        [Index(7)]
        public virtual bool Cuffed { get; set; }

        [Index(8)]
        public virtual bool Service { get; set; }

        [Index(9)]
        public virtual string Jobs { get; set; }

        [Index(10)]
        public virtual Dictionary<string, int> PermissionJobs { get; set; }

        [Index(11)]
        public virtual Dictionary<string, bool> ServiceJobs { get; set; }

        public WorldUserData() { }

    }


    class WorldTattooData
    {
        [Index(0)]
        public virtual int Id { get; set; }

        [Index(1)]
        public virtual string Name { get; set; }

        [Index(2)]
        public virtual int LocalId { get; set; }

        [Index(3)]
        public virtual ushort RemoteId { get; set; }

        [Index(4)]
        public virtual int Dimensions { get; set; }

        [Index(5)]
        public bool IsActive { get; set; }

        [Index(6)]
        public virtual main.Ventura.Constant.Constants.UpdateFlags Type { get; set; }
        

        public WorldTattooData() { }

    }

    [JsonObject]
    class WorldDoorsData
    {
        public int Hashcode { get; set; }
        public string Name { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float State { get; set; }
        public bool IsLock { get; set; }
    }


}
