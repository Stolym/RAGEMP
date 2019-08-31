using System;
using System.Collections.Generic;
using System.Text;
using RAGE;

namespace main_client.Ventura.Jobs.JobsData
{

    public class HomeData
    {
        public int HashCode { get; set; }
        public int Key { get; set; }
        public string Owner { get; set; }
        public string InteriorName { get; set; }
        public Vector3 From { get; set; }
        public Vector3 To { get; set; }

        public HomeData()
        {

        }

        public HomeData(int id, int key, string name, Vector3 from, Vector3 to)
        {
            this.HashCode = id;
            this.Key = key;
            this.InteriorName = name;
            this.From = from;
            this.To = to;
        }
    }

    //
    //
    //

    public class ClothShopData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public Vector3 From { get; set; }
        public Vector3 To { get; set; }

        public ClothShopData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.From = new Vector3();
            this.To = new Vector3();
        }

        public ClothShopData(int id, int state, Vector3 from, Vector3 to)
        {
            this.HashCode = id;
            this.From = from;
            this.To = to;
            this.State = state;
        }
    }

    public class AmmuNationData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public Vector3 From { get; set; }
        public Vector3 To { get; set; }

        public AmmuNationData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.From = new Vector3();
            this.To = new Vector3();
        }

        public AmmuNationData(int id, int state, Vector3 from, Vector3 to)
        {
            this.HashCode = id;
            this.From = from;
            this.To = to;
            this.State = state;
        }
    }


    public class BikeShopData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public Vector3 From { get; set; }
        public Vector3 To { get; set; }

        public BikeShopData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.From = new Vector3();
            this.To = new Vector3();
        }

        public BikeShopData(int id, int state, Vector3 from, Vector3 to)
        {
            this.HashCode = id;
            this.From = from;
            this.To = to;
            this.State = state;
        }
    }


    public class TruckShopData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public Vector3 From { get; set; }
        public Vector3 To { get; set; }

        public TruckShopData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.From = new Vector3();
            this.To = new Vector3();
        }

        public TruckShopData(int id, int state, Vector3 from, Vector3 to)
        {
            this.HashCode = id;
            this.From = from;
            this.To = to;
            this.State = state;
        }
    }

    public class ParkingData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public Vector3 From { get; set; }
        public Vector3 To { get; set; }

        public ParkingData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.From = new Vector3();
            this.To = new Vector3();
        }

        public ParkingData(int id, int state, Vector3 from, Vector3 to)
        {
            this.HashCode = id;
            this.From = from;
            this.To = to;
            this.State = state;
        }
    }

    //
    //
    //


    public class MarketShopData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public Vector3 From { get; set; }
        public Vector3 To { get; set; }

        public MarketShopData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.From = new Vector3();
            this.To = new Vector3();
        }

        public MarketShopData(int id, int state, Vector3 from, Vector3 to)
        {
            this.HashCode = id;
            this.From = from;
            this.To = to;
            this.State = state;
        }
    }

    //
    //
    //

    public class BarberShopData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public Vector3 From { get; set; }
        public Vector3 To { get; set; }

        public BarberShopData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.From = new Vector3();
            this.To = new Vector3();
        }

        public BarberShopData(int id, int state, Vector3 from, Vector3 to)
        {
            this.HashCode = id;
            this.From = from;
            this.To = to;
            this.State = state;
        }
    }

    //
    //
    //

    public class TattooShopData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public Vector3 From { get; set; }
        public Vector3 To { get; set; }

        public TattooShopData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.From = new Vector3();
            this.To = new Vector3();
        }

        public TattooShopData(int id, int state, Vector3 from, Vector3 to)
        {
            this.HashCode = id;
            this.From = from;
            this.To = to;
            this.State = state;
        }
    }

    //
    //
    //

    public class LSPDData
    {

        public int HashCode { get; set; }
        public int State { get; set; }
        public string IPL { get; set; }
        public Vector3 Out { get; set; }
        public Vector3 Inside { get; set; }
        public Vector3 OutTop { get; set; }
        public Vector3 InsideTop { get; set; }
        public Vector3 GetService { get; set; }
        public Vector3 ZonePaintPosition { get; set; }
        public Vector3 ScriptPaintPosition { get; set; }
        public Vector3 CoffrePosition { get; set; }
        public Vector3 ComputerPosition { get; set; }
        public Vector3 GarbageVehicle { get; set; }
        public Vector3 SpawnVehicle { get; set; }
        public Vector3 GarbageHeli { get; set; }
        public Vector3 SpawnHeli { get; set; }

        public LSPDData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.Out = new Vector3();
            this.Inside = new Vector3();
            this.GetService = new Vector3();
            this.ZonePaintPosition = new Vector3();
            this.ScriptPaintPosition = new Vector3();
        }
    }

    //
    //
    //

    public class LSDHData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public string IPL { get; set; }
        public Vector3 Out { get; set; }
        public Vector3 Inside { get; set; }
        public Vector3 OutTop { get; set; }
        public Vector3 InsideTop { get; set; }
        public Vector3 GetService { get; set; }
        public Vector3 ZonePaintPosition { get; set; }
        public Vector3 ScriptPaintPosition { get; set; }
        public Vector3 CoffrePosition { get; set; }
        public Vector3 ComputerPosition { get; set; }
        public Vector3 GarbageVehicle { get; set; }
        public Vector3 SpawnVehicle { get; set; }
        public Vector3 GarbageHeli { get; set; }
        public Vector3 SpawnHeli { get; set; }

        public LSDHData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.Out = new Vector3();
            this.Inside = new Vector3();
            this.GetService = new Vector3();
            this.ZonePaintPosition = new Vector3();
            this.ScriptPaintPosition = new Vector3();
        }
    }



    public class MarshalData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public string IPL { get; set; }
        public Vector3 Out { get; set; }
        public Vector3 Inside { get; set; }
        public Vector3 OutTop { get; set; }
        public Vector3 InsideTop { get; set; }
        public Vector3 GetService { get; set; }
        public Vector3 ZonePaintPosition { get; set; }
        public Vector3 ScriptPaintPosition { get; set; }
        public Vector3 CoffrePosition { get; set; }
        public Vector3 ComputerPosition { get; set; }
        public Vector3 GarbageVehicle { get; set; }
        public Vector3 SpawnVehicle { get; set; }
        public Vector3 GarbageHeli { get; set; }
        public Vector3 SpawnHeli { get; set; }

        public MarshalData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.Out = new Vector3();
            this.Inside = new Vector3();
            this.GetService = new Vector3();
            this.ZonePaintPosition = new Vector3();
            this.ScriptPaintPosition = new Vector3();
        }
    }

    //
    //
    //

    public class LSCustomData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public Vector3 GetService { get; set; }
        public Vector3 GetUtils { get; set; }

        public LSCustomData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.GetUtils = new Vector3();
        }

        public LSCustomData(int id, int state, Vector3 getservice, Vector3 getutils)
        {
            this.HashCode = id;
            this.GetService = getservice;
            this.GetUtils = getutils;
            this.State = state;
        }
    }

    //
    //
    //

    public class UnicornData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public Vector3 GetService { get; set; }
        public Vector3 GetStock { get; set; }

        public UnicornData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.GetStock = new Vector3();
        }

        public UnicornData(int id, int state, Vector3 getservice, Vector3 getstock)
        {
            this.HashCode = id;
            this.GetService = getservice;
            this.GetStock = getstock;
            this.State = state;
        }
    }

    //
    //
    //

    public class BikeRiderData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public Vector3 GetService { get; set; }
        public Vector3 GetStock { get; set; }

        public BikeRiderData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.GetStock = new Vector3();
        }

        public BikeRiderData(int id, int state, Vector3 getservice, Vector3 getstock)
        {
            this.HashCode = id;
            this.GetService = getservice;
            this.GetStock = getstock;
            this.State = state;
        }
    }

    //
    //
    //

    public class BankData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public string IPL { get; set; }
        public Vector3 Out { get; set; }
        public Vector3 Inside { get; set; }
        public Vector3 OutTop { get; set; }
        public Vector3 InsideTop { get; set; }
        public Vector3 GetService { get; set; }
        public Vector3 ZonePaintPosition { get; set; }
        public Vector3 ScriptPaintPosition { get; set; }
        public Vector3 CoffrePosition { get; set; }
        public Vector3 ComputerPosition { get; set; }
        public Vector3 GarbageVehicle { get; set; }
        public Vector3 SpawnVehicle { get; set; }
        public Vector3 GarbageHeli { get; set; }
        public Vector3 SpawnHeli { get; set; }

        public BankData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.Out = new Vector3();
            this.Inside = new Vector3();
            this.GetService = new Vector3();
            this.ZonePaintPosition = new Vector3();
            this.ScriptPaintPosition = new Vector3();
        }
    }

    //
    //
    //

    public class BennysCustomData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public Vector3 Out { get; set; }
        public Vector3 Inside { get; set; }
        public Vector3 GetService { get; set; }
        public Vector3 ZonePaintPosition { get; set; }
        public Vector3 ScriptPaintPosition { get; set; }
        public Vector3 CoffrePosition { get; set; }
        public Vector3 ComputerPosition { get; set; }

        public BennysCustomData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.Out = new Vector3();
            this.Inside = new Vector3();
            this.GetService = new Vector3();
            this.ZonePaintPosition = new Vector3();
            this.ScriptPaintPosition = new Vector3();
        }

    }

    //
    //
    //

    public class JudgeData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public Vector3 GetService { get; set; }
        public Vector3 From { get; set; }

        public JudgeData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.From = new Vector3();
        }

        public JudgeData(int id, int state, Vector3 getservice, Vector3 from)
        {
            this.HashCode = id;
            this.GetService = getservice;
            this.From = from;
            this.State = state;
        }
    }

    //


    public class WeazelNewsData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public string IPL { get; set; }
        public Vector3 Out { get; set; }
        public Vector3 Inside { get; set; }
        public Vector3 OutTop { get; set; }
        public Vector3 InsideTop { get; set; }
        public Vector3 GetService { get; set; }
        public Vector3 ZonePaintPosition { get; set; }
        public Vector3 ScriptPaintPosition { get; set; }
        public Vector3 CoffrePosition { get; set; }
        public Vector3 ComputerPosition { get; set; }
        public Vector3 GarbageVehicle { get; set; }
        public Vector3 SpawnVehicle { get; set; }
        public Vector3 GarbageHeli { get; set; }
        public Vector3 SpawnHeli { get; set; }

        public WeazelNewsData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.Out = new Vector3();
            this.Inside = new Vector3();
            this.GetService = new Vector3();
            this.ZonePaintPosition = new Vector3();
            this.ScriptPaintPosition = new Vector3();
        }
    }

    //
    //
    //

    public class GaragePublicData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public Vector3 GetService { get; set; }
        public Vector3 From { get; set; }

        public GaragePublicData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.From = new Vector3();
        }

        public GaragePublicData(int id, int state, Vector3 getservice, Vector3 from)
        {
            this.HashCode = id;
            this.GetService = getservice;
            this.From = from;
            this.State = state;
        }
    }

    //
    //
    //

    public class GaragePrivateData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public Vector3 GetService { get; set; }
        public Vector3 From { get; set; }

        public GaragePrivateData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.From = new Vector3();
        }

        public GaragePrivateData(int id, int state, Vector3 getservice, Vector3 from)
        {
            this.HashCode = id;
            this.GetService = getservice;
            this.From = from;
            this.State = state;
        }
    }

    //
    //
    //


    public class ConcessShopData
    {
        public int HashCode { get; set; }
        public Vector3 UI { get; set; }
        public Vector3 Spawn { get; set; }

        public ConcessShopData()
        {
            this.HashCode = 0;
            this.UI = new Vector3();
            this.Spawn = new Vector3();
        }

        public ConcessShopData(int id, Vector3 getservice, Vector3 from)
        {
            this.HashCode = id;
            this.UI = getservice;
            this.Spawn = from;
        }
    }

    //
    //
    //

    public class RenssonConcessData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public string IPL { get; set; }
        public Vector3 Out { get; set; }
        public Vector3 Inside { get; set; }
        public Vector3 OutTop { get; set; }
        public Vector3 InsideTop { get; set; }
        public Vector3 GetService { get; set; }
        public Vector3 ZonePaintPosition { get; set; }
        public Vector3 ScriptPaintPosition { get; set; }
        public Vector3 CoffrePosition { get; set; }
        public Vector3 ComputerPosition { get; set; }
        public Vector3 GarbageVehicle { get; set; }
        public Vector3 SpawnVehicle { get; set; }
        public Vector3 GarbageHeli { get; set; }
        public Vector3 SpawnHeli { get; set; }

        public RenssonConcessData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.Out = new Vector3();
            this.Inside = new Vector3();
            this.GetService = new Vector3();
            this.ZonePaintPosition = new Vector3();
            this.ScriptPaintPosition = new Vector3();
        }

    }

    //
    //
    //

    public class BlackKnightData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public string IPL { get; set; }
        public Vector3 Out { get; set; }
        public Vector3 Inside { get; set; }
        public Vector3 OutTop { get; set; }
        public Vector3 InsideTop { get; set; }
        public Vector3 GetService { get; set; }
        public Vector3 ZonePaintPosition { get; set; }
        public Vector3 ScriptPaintPosition { get; set; }
        public Vector3 CoffrePosition { get; set; }
        public Vector3 ComputerPosition { get; set; }
        public Vector3 GarbageVehicle { get; set; }
        public Vector3 SpawnVehicle { get; set; }
        public Vector3 GarbageHeli { get; set; }
        public Vector3 SpawnHeli { get; set; }

        public BlackKnightData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.Out = new Vector3();
            this.Inside = new Vector3();
            this.GetService = new Vector3();
            this.ZonePaintPosition = new Vector3();
            this.ScriptPaintPosition = new Vector3();
        }
    }

    //
    //
    //


    public class LawyerData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public Vector3 GetService { get; set; }
        public Vector3 From { get; set; }

        public LawyerData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.From = new Vector3();
        }

        public LawyerData(int id, int state, Vector3 getservice, Vector3 from)
        {
            this.HashCode = id;
            this.GetService = getservice;
            this.From = from;
            this.State = state;
        }
    }

    //
    //
    //

    public class GasolineShopData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public Vector3 GetService { get; set; }
        public Vector3 From { get; set; }

        public GasolineShopData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.From = new Vector3();
        }

        public GasolineShopData(int id, int state, Vector3 getservice, Vector3 from)
        {
            this.HashCode = id;
            this.GetService = getservice;
            this.From = from;
            this.State = state;
        }
    }

    //
    //
    //

    public class LostData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public string IPL { get; set; }
        public Vector3 Out { get; set; }
        public Vector3 Inside { get; set; }
        public Vector3 OutTop { get; set; }
        public Vector3 InsideTop { get; set; }
        public Vector3 GetService { get; set; }
        public Vector3 ZonePaintPosition { get; set; }
        public Vector3 ScriptPaintPosition { get; set; }
        public Vector3 CoffrePosition { get; set; }
        public Vector3 ComputerPosition { get; set; }
        public Vector3 GarbageVehicle { get; set; }
        public Vector3 SpawnVehicle { get; set; }
        public Vector3 GarbageHeli { get; set; }
        public Vector3 SpawnHeli { get; set; }

        public LostData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.Out = new Vector3();
            this.Inside = new Vector3();
            this.GetService = new Vector3();
            this.ZonePaintPosition = new Vector3();
            this.ScriptPaintPosition = new Vector3();
        }
    }

    //
    //
    //

    public class DAndCData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public string IPL { get; set; }
        public Vector3 Out { get; set; }
        public Vector3 Inside { get; set; }
        public Vector3 OutTop { get; set; }
        public Vector3 InsideTop { get; set; }
        public Vector3 GetService { get; set; }
        public Vector3 ZonePaintPosition { get; set; }
        public Vector3 ScriptPaintPosition { get; set; }
        public Vector3 CoffrePosition { get; set; }
        public Vector3 ComputerPosition { get; set; }
        public Vector3 GarbageVehicle { get; set; }
        public Vector3 SpawnVehicle { get; set; }
        public Vector3 GarbageHeli { get; set; }
        public Vector3 SpawnHeli { get; set; }

        public DAndCData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.Out = new Vector3();
            this.Inside = new Vector3();
            this.GetService = new Vector3();
            this.ZonePaintPosition = new Vector3();
            this.ScriptPaintPosition = new Vector3();
        }
    }

    public class BrinksData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public string IPL { get; set; }
        public Vector3 Out { get; set; }
        public Vector3 Inside { get; set; }
        public Vector3 OutTop { get; set; }
        public Vector3 InsideTop { get; set; }
        public Vector3 GetService { get; set; }
        public Vector3 ZonePaintPosition { get; set; }
        public Vector3 ScriptPaintPosition { get; set; }
        public Vector3 CoffrePosition { get; set; }
        public Vector3 ComputerPosition { get; set; }
        public Vector3 GarbageVehicle { get; set; }
        public Vector3 SpawnVehicle { get; set; }
        public Vector3 GarbageHeli { get; set; }
        public Vector3 SpawnHeli { get; set; }

        public BrinksData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.Out = new Vector3();
            this.Inside = new Vector3();
            this.GetService = new Vector3();
            this.ZonePaintPosition = new Vector3();
            this.ScriptPaintPosition = new Vector3();
        }
    }



    public class OrganizData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public string IPL { get; set; }
        public Vector3 Out { get; set; }
        public Vector3 Inside { get; set; }
        public Vector3 OutTop { get; set; }
        public Vector3 InsideTop { get; set; }
        public Vector3 GetService { get; set; }
        public Vector3 ZonePaintPosition { get; set; }
        public Vector3 ScriptPaintPosition { get; set; }
        public Vector3 CoffrePosition { get; set; }
        public Vector3 ComputerPosition { get; set; }
        public Vector3 GarbageVehicle { get; set; }
        public Vector3 SpawnVehicle { get; set; }
        public Vector3 GarbageHeli { get; set; }
        public Vector3 SpawnHeli { get; set; }

        public OrganizData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.Out = new Vector3();
            this.Inside = new Vector3();
            this.GetService = new Vector3();
            this.ZonePaintPosition = new Vector3();
            this.ScriptPaintPosition = new Vector3();
        }
    }


    public class NigloTattooData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public string IPL { get; set; }
        public Vector3 Out { get; set; }
        public Vector3 Inside { get; set; }
        public Vector3 OutTop { get; set; }
        public Vector3 InsideTop { get; set; }
        public Vector3 GetService { get; set; }
        public Vector3 ZonePaintPosition { get; set; }
        public Vector3 ScriptPaintPosition { get; set; }
        public Vector3 CoffrePosition { get; set; }
        public Vector3 ComputerPosition { get; set; }
        public Vector3 GarbageVehicle { get; set; }
        public Vector3 SpawnVehicle { get; set; }
        public Vector3 GarbageHeli { get; set; }
        public Vector3 SpawnHeli { get; set; }

        public NigloTattooData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.Out = new Vector3();
            this.Inside = new Vector3();
            this.GetService = new Vector3();
            this.ZonePaintPosition = new Vector3();
            this.ScriptPaintPosition = new Vector3();
        }
    }

    public class BurnsData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public string IPL { get; set; }
        public Vector3 Out { get; set; }
        public Vector3 Inside { get; set; }
        public Vector3 OutTop { get; set; }
        public Vector3 InsideTop { get; set; }
        public Vector3 GetService { get; set; }
        public Vector3 ZonePaintPosition { get; set; }
        public Vector3 ScriptPaintPosition { get; set; }
        public Vector3 CoffrePosition { get; set; }
        public Vector3 ComputerPosition { get; set; }
        public Vector3 GarbageVehicle { get; set; }
        public Vector3 SpawnVehicle { get; set; }
        public Vector3 GarbageHeli { get; set; }
        public Vector3 SpawnHeli { get; set; }

        public BurnsData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.Out = new Vector3();
            this.Inside = new Vector3();
            this.GetService = new Vector3();
            this.ZonePaintPosition = new Vector3();
            this.ScriptPaintPosition = new Vector3();
        }
    }


    public class BarioData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public string IPL { get; set; }
        public Vector3 Out { get; set; }
        public Vector3 Inside { get; set; }
        public Vector3 OutTop { get; set; }
        public Vector3 InsideTop { get; set; }
        public Vector3 GetService { get; set; }
        public Vector3 ZonePaintPosition { get; set; }
        public Vector3 ScriptPaintPosition { get; set; }
        public Vector3 CoffrePosition { get; set; }
        public Vector3 ComputerPosition { get; set; }
        public Vector3 GarbageVehicle { get; set; }
        public Vector3 SpawnVehicle { get; set; }
        public Vector3 GarbageHeli { get; set; }
        public Vector3 SpawnHeli { get; set; }

        public BarioData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.Out = new Vector3();
            this.Inside = new Vector3();
            this.GetService = new Vector3();
            this.ZonePaintPosition = new Vector3();
            this.ScriptPaintPosition = new Vector3();
        }
    }


    public class PetrolData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public string IPL { get; set; }
        public Vector3 Out { get; set; }
        public Vector3 Inside { get; set; }
        public Vector3 OutTop { get; set; }
        public Vector3 InsideTop { get; set; }
        public Vector3 GetService { get; set; }
        public Vector3 ZonePaintPosition { get; set; }
        public Vector3 ScriptPaintPosition { get; set; }
        public Vector3 CoffrePosition { get; set; }
        public Vector3 ComputerPosition { get; set; }
        public Vector3 GarbageVehicle { get; set; }
        public Vector3 SpawnVehicle { get; set; }
        public Vector3 GarbageHeli { get; set; }
        public Vector3 SpawnHeli { get; set; }

        public PetrolData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.Out = new Vector3();
            this.Inside = new Vector3();
            this.GetService = new Vector3();
            this.ZonePaintPosition = new Vector3();
            this.ScriptPaintPosition = new Vector3();
        }
    }


    public class VigneronData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public string IPL { get; set; }
        public Vector3 Out { get; set; }
        public Vector3 Inside { get; set; }
        public Vector3 OutTop { get; set; }
        public Vector3 InsideTop { get; set; }
        public Vector3 GetService { get; set; }
        public Vector3 ZonePaintPosition { get; set; }
        public Vector3 ScriptPaintPosition { get; set; }
        public Vector3 CoffrePosition { get; set; }
        public Vector3 ComputerPosition { get; set; }
        public Vector3 GarbageVehicle { get; set; }
        public Vector3 SpawnVehicle { get; set; }
        public Vector3 GarbageHeli { get; set; }
        public Vector3 SpawnHeli { get; set; }

        public VigneronData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.Out = new Vector3();
            this.Inside = new Vector3();
            this.GetService = new Vector3();
            this.ZonePaintPosition = new Vector3();
            this.ScriptPaintPosition = new Vector3();
        }
    }


    public class FarmLarocheData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public string IPL { get; set; }
        public Vector3 Out { get; set; }
        public Vector3 Inside { get; set; }
        public Vector3 OutTop { get; set; }
        public Vector3 InsideTop { get; set; }
        public Vector3 GetService { get; set; }
        public Vector3 ZonePaintPosition { get; set; }
        public Vector3 ScriptPaintPosition { get; set; }
        public Vector3 CoffrePosition { get; set; }
        public Vector3 ComputerPosition { get; set; }
        public Vector3 GarbageVehicle { get; set; }
        public Vector3 SpawnVehicle { get; set; }
        public Vector3 GarbageHeli { get; set; }
        public Vector3 SpawnHeli { get; set; }

        public FarmLarocheData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.Out = new Vector3();
            this.Inside = new Vector3();
            this.GetService = new Vector3();
            this.ZonePaintPosition = new Vector3();
            this.ScriptPaintPosition = new Vector3();
        }
    }


    public class TransportData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public string IPL { get; set; }
        public Vector3 Out { get; set; }
        public Vector3 Inside { get; set; }
        public Vector3 OutTop { get; set; }
        public Vector3 InsideTop { get; set; }
        public Vector3 GetService { get; set; }
        public Vector3 ZonePaintPosition { get; set; }
        public Vector3 ScriptPaintPosition { get; set; }
        public Vector3 CoffrePosition { get; set; }
        public Vector3 ComputerPosition { get; set; }
        public Vector3 GarbageVehicle { get; set; }
        public Vector3 SpawnVehicle { get; set; }
        public Vector3 GarbageHeli { get; set; }
        public Vector3 SpawnHeli { get; set; }

        public TransportData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.Out = new Vector3();
            this.Inside = new Vector3();
            this.GetService = new Vector3();
            this.ZonePaintPosition = new Vector3();
            this.ScriptPaintPosition = new Vector3();
        }
    }


    //
    //
    //

    public class ConcessData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public Vector3 GetService { get; set; }
        public Vector3 From { get; set; }

        public ConcessData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.From = new Vector3();
        }

        public ConcessData(int id, int state, Vector3 getservice, Vector3 from)
        {
            this.HashCode = id;
            this.GetService = getservice;
            this.From = from;
            this.State = state;
        }
    }

    //
    //
    //


    public class FishData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public string IPL { get; set; }
        public Vector3 Out { get; set; }
        public Vector3 Inside { get; set; }
        public Vector3 OutTop { get; set; }
        public Vector3 InsideTop { get; set; }
        public Vector3 GetService { get; set; }
        public Vector3 ZonePaintPosition { get; set; }
        public Vector3 ScriptPaintPosition { get; set; }
        public Vector3 CoffrePosition { get; set; }
        public Vector3 ComputerPosition { get; set; }
        public Vector3 GarbageVehicle { get; set; }
        public Vector3 SpawnVehicle { get; set; }
        public Vector3 GarbageBoat { get; set; }
        public Vector3 SpawnBoat { get; set; }
        public Vector3 GarbageHeli { get; set; }
        public Vector3 SpawnHeli { get; set; }

        public Vector3 ZoneFishing { get; set; }
        public Vector3 ZoneTreat { get; set; }
        public Vector3 Container { get; set; }



        public FishData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.Out = new Vector3();
            this.Inside = new Vector3();
            this.GetService = new Vector3();
            this.ZonePaintPosition = new Vector3();
            this.ScriptPaintPosition = new Vector3();
        }
    }

    //
    //
    //

    public class TaxiData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public string IPL { get; set; }
        public Vector3 Out { get; set; }
        public Vector3 Inside { get; set; }
        public Vector3 OutTop { get; set; }
        public Vector3 InsideTop { get; set; }
        public Vector3 GetService { get; set; }
        public Vector3 ZonePaintPosition { get; set; }
        public Vector3 ScriptPaintPosition { get; set; }
        public Vector3 CoffrePosition { get; set; }
        public Vector3 ComputerPosition { get; set; }
        public Vector3 GarbageVehicle { get; set; }
        public Vector3 SpawnVehicle { get; set; }
        public Vector3 GarbageHeli { get; set; }
        public Vector3 SpawnHeli { get; set; }

        public TaxiData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.Out = new Vector3();
            this.Inside = new Vector3();
            this.GetService = new Vector3();
            this.ZonePaintPosition = new Vector3();
            this.ScriptPaintPosition = new Vector3();
        }
    }


    public class GouvernementData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public string IPL { get; set; }
        public Vector3 Out { get; set; }
        public Vector3 Inside { get; set; }
        public Vector3 OutTop { get; set; }
        public Vector3 InsideTop { get; set; }
        public Vector3 GetService { get; set; }
        public Vector3 ZonePaintPosition { get; set; }
        public Vector3 ScriptPaintPosition { get; set; }
        public Vector3 CoffrePosition { get; set; }
        public Vector3 ComputerPosition { get; set; }
        public Vector3 GarbageVehicle { get; set; }
        public Vector3 SpawnVehicle { get; set; }
        public Vector3 GarbageHeli { get; set; }
        public Vector3 SpawnHeli { get; set; }

        public GouvernementData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.Out = new Vector3();
            this.Inside = new Vector3();
            this.GetService = new Vector3();
            this.ZonePaintPosition = new Vector3();
            this.ScriptPaintPosition = new Vector3();
        }
    }


    public class PoleEmploiData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public string IPL { get; set; }
        public Vector3 Out { get; set; }
        public Vector3 Inside { get; set; }
        public Vector3 OutTop { get; set; }
        public Vector3 InsideTop { get; set; }
        public Vector3 GetService { get; set; }
        public Vector3 ZonePaintPosition { get; set; }
        public Vector3 ScriptPaintPosition { get; set; }
        public Vector3 CoffrePosition { get; set; }
        public Vector3 ComputerPosition { get; set; }
        public Vector3 GarbageVehicle { get; set; }
        public Vector3 SpawnVehicle { get; set; }
        public Vector3 GarbageHeli { get; set; }
        public Vector3 SpawnHeli { get; set; }

        public PoleEmploiData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.Out = new Vector3();
            this.Inside = new Vector3();
            this.GetService = new Vector3();
            this.ZonePaintPosition = new Vector3();
            this.ScriptPaintPosition = new Vector3();
        }
    }



    public class UrbanCompassData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public string IPL { get; set; }
        public Vector3 Out { get; set; }
        public Vector3 Inside { get; set; }
        public Vector3 OutTop { get; set; }
        public Vector3 InsideTop { get; set; }
        public Vector3 GetService { get; set; }
        public Vector3 ZonePaintPosition { get; set; }
        public Vector3 ScriptPaintPosition { get; set; }
        public Vector3 CoffrePosition { get; set; }
        public Vector3 ComputerPosition { get; set; }
        public Vector3 GarbageVehicle { get; set; }
        public Vector3 SpawnVehicle { get; set; }
        public Vector3 GarbageHeli { get; set; }
        public Vector3 SpawnHeli { get; set; }

        public UrbanCompassData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.Out = new Vector3();
            this.Inside = new Vector3();
            this.GetService = new Vector3();
            this.ZonePaintPosition = new Vector3();
            this.ScriptPaintPosition = new Vector3();
        }
    }


    //
    //
    //

    public class VehicleShooterData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public Vector3 GetService { get; set; }
        public Vector3 From { get; set; }

        public VehicleShooterData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.From = new Vector3();
        }

        public VehicleShooterData(int id, int state, Vector3 getservice, Vector3 from)
        {
            this.HashCode = id;
            this.GetService = getservice;
            this.From = from;
            this.State = state;
        }
    }

    //
    //
    //

    public class HomeJobsData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public Vector3 GetService { get; set; }
        public Vector3 From { get; set; }

        public HomeJobsData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.From = new Vector3();
        }

        public HomeJobsData(int id, int state, Vector3 getservice, Vector3 from)
        {
            this.HashCode = id;
            this.GetService = getservice;
            this.From = from;
            this.State = state;
        }
    }

    //
    //
    //

    public class ElectricienData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public Vector3 GetService { get; set; }
        public Vector3 From { get; set; }

        public ElectricienData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.From = new Vector3();
        }

        public ElectricienData(int id, int state, Vector3 getservice, Vector3 from)
        {
            this.HashCode = id;
            this.GetService = getservice;
            this.From = from;
            this.State = state;
        }
    }

    //
    //
    //

    public class VitreurData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public Vector3 GetService { get; set; }
        public Vector3 From { get; set; }

        public VitreurData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.From = new Vector3();
        }

        public VitreurData(int id, int state, Vector3 getservice, Vector3 from)
        {
            this.HashCode = id;
            this.GetService = getservice;
            this.From = from;
            this.State = state;
        }
    }

    //
    //
    //


    public class AtmData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public string IPL { get; set; }
        public Vector3 Out { get; set; }
        public Vector3 Inside { get; set; }
        public Vector3 OutTop { get; set; }
        public Vector3 InsideTop { get; set; }
        public Vector3 GetService { get; set; }
        public Vector3 ZonePaintPosition { get; set; }
        public Vector3 ScriptPaintPosition { get; set; }
        public Vector3 CoffrePosition { get; set; }
        public Vector3 ComputerPosition { get; set; }
        public Vector3 GarbageVehicle { get; set; }
        public Vector3 SpawnVehicle { get; set; }
        public Vector3 GarbageHeli { get; set; }
        public Vector3 SpawnHeli { get; set; }

        public AtmData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.Out = new Vector3();
            this.Inside = new Vector3();
            this.GetService = new Vector3();
            this.ZonePaintPosition = new Vector3();
            this.ScriptPaintPosition = new Vector3();
        }
    }

    //
    //
    //


    public class DoorData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public Vector3 GetService { get; set; }
        public Vector3 From { get; set; }

        public DoorData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.From = new Vector3();
        }

        public DoorData(int id, int state, Vector3 getservice, Vector3 from)
        {
            this.HashCode = id;
            this.GetService = getservice;
            this.From = from;
            this.State = state;
        }
    }

}
