using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;

namespace main.Synchronization
{
    /*
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * */

    /// <summary>
    /// ////////////////////////////////////////////////////////////
    /// </summary>




    /// <summary>
    /// ////////////////////////////////////////////////////////////
    /// </summary>



    /*public class ClothShop
    {
        public int id { get; set; }
        public int state { get; set; }
        public Vector3 from { get; set; }
        public Vector3 to { get; set; }

        public ClothShop()
        {
            this.id = 0;
            this.from = new Vector3();
            this.to = new Vector3();
            this.state = 0;
        }

        public ClothShop(int id, Vector3 f, Vector3 t, int state)
        {
            this.id = id;
            this.from = f;
            this.to = t;
            this.state = state;
        }
    }


    /// <summary>
    /// ////////////////////////////////////////////////////////////
    /// </summary>


    public class MarketShopJson
    {
        public int id { get; set; }
        public int state { get; set; }
        public Vector3 from { get; set; }
        public Vector3 to { get; set; }

        public MarketShopJson() { }
    }

    /// <summary>
    /// ////////////////////////////////////////////////////////////
    /// </summary>

    public class GarageJson
    {
        public int id { get; set; }
        public int state { get; set; }
        public Vector3 from { get; set; }
        public Vector3 to { get; set; }

        public GarageJson() { }
    }

    /// <summary>
    /// ////////////////////////////////////////////////////////////
    /// </summary>


    public class BarberShopJson
    {
        public int id { get; set; }
        public int state { get; set; }
        public Vector3 from { get; set; }
        public Vector3 to { get; set; }

        public BarberShopJson() { }
    }



    /// <summary>
    /// ////////////////////////////////////////////////////////////
    /// </summary>


    public class TaskSync
    {
        public uint RemoteId { get; set; }
        public uint vRemoteId { get; set; }
        public string side { get; set; }
        public bool leave { get; set; }

        public TaskSync()
        {

        }

        public TaskSync(Client player, Vehicle veh, string side = "", bool leave = false)
        {
            this.RemoteId = player.Handle.Value;
            this.vRemoteId = veh.Handle.Value;
            this.side = side;
        }
    }


    /// <summary>
    /// ////////////////////////////////////////////////////////////
    /// </summary>


    public class VehiclesDatas
    {
        public List<SyncVehicleData> list_vehicle = new List<SyncVehicleData>();

        public VehiclesDatas()
        {
        }

        public VehiclesDatas(List<SyncVehicleData> list)
        {
            list_vehicle = list;
        }

        public void UpdateStreamInClientLogin()
        {
            foreach (SyncVehicleData vd in list_vehicle)
            {
                bool spawn = true;
                foreach (Vehicle v in NAPI.Pools.GetAllVehicles())
                {
                    var data = v.GetSharedData("StreamInVehicle");
                    if (data == null)
                        continue;
                    if (vd.Id == data.Id)
                        spawn = false;
                }
                if (spawn)
                    main.Vehicule.VehicleManager.SpawnVehicleInStreamWorld(vd);
            }

        }

        public void UpdateData(SyncVehicleData data)
        {
            if (list_vehicle.Find(x => x.Id == data.Id) != null)
            {
                list_vehicle[list_vehicle.IndexOf(list_vehicle.Find(x => x.Id == data.Id))] = data;
            }
        }
    }


    /// <summary>
    /// ////////////////////////////////////////////////////////////
    /// </summary>
    /// 

    public class HeatlhData
    {
        public ushort RemoteId { get; set; }
        public bool IsAlive { get; set; }
        public List<int> bone_break { get; set; }

        public HeatlhData() { }
    }

    /// <summary>
    /// ////////////////////////////////////////////////////////////
    /// </summary>

    public class WorldObjectSync
    {
        public string name { get; set; }
        public int Id { get; set; }
        public int LocalId { get; set; }
        public int Dimensions { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
        public float rx { get; set; }
        public float ry { get; set; }
        public float rz { get; set; }
    }
    
    /// <summary>
    /// ////////////////////////////////////////////////////////////
    /// </summary>

    public class AttachItemObject {

        public int Id { get; set; }
        public string Name { get; set; }
        public int LocalId { get; set; }
        public int Dimensions { get; set; }
        public int Bone { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
        public float rx { get; set; }
        public float ry { get; set; }
        public float rz { get; set; }

        public AttachItemObject() {

        }
    }

    /// <summary>
    /// ////////////////////////////////////////////////////////////
    /// </summary>

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
            RollWindow = new List<int>();
            SmashWindow = new List<int>();
            SmashDoor = new List<int>();
            ModelDamage = new List<Vector3Json>();
            DoorControl = new List<int>();
            wx = 0;
            wy = 0;

            for (int i = 0; i < 20 * 20; i++)
            {
                if (i < 8)
                {
                    RollWindow.Add(0);
                    SmashDoor.Add(0);
                    SmashWindow.Add(0);
                    DoorControl.Add(0);
                }

                ModelDamage.Add(new Vector3Json());
            }
        }

        public SyncVehicleData(int Id, Vehicle vehicle)
        {
            this.Id = Id;
            this.RemoteId = vehicle.Handle.Value;
            RollWindow = new List<int>();
            SmashWindow = new List<int>();
            SmashDoor = new List<int>();
            ModelDamage = new List<Vector3Json>();
            DoorControl = new List<int>();
            wx = 0;
            wy = 0;

            GTANetworkAPI.API.Shared.;
            

            for (int i = 0; i < 20 * 20; i++)
            {
                if (i < 8)
                {
                    RollWindow.Add(0);
                    SmashDoor.Add(0);
                    SmashWindow.Add(0);
                    DoorControl.Add(0);
                }

                ModelDamage.Add(new Vector3Json());
            }
        }
    }

    /// <summary>
    /// ////////////////////////////////////////////////////////////
    /// </summary>


    class PasswordSync {
        public string name { get; set; }
        public string lastname { get; set; }
        public string nat { get; set; }
        public string birth { get; set; }
        public string from_birth { get; set; }
        public string sex { get; set; }
        public string height { get; set; }
        public string del { get; set; }
        public string exp { get; set; }


        public PasswordSync() {

        }
    }*/

}
