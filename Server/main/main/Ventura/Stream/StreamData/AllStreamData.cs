using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;

namespace main.Ventura.Stream.StreamData
{
    //
    //
    //

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
        public Vector3 GetService { get; set; }
        public Vector3 GetWeapon { get; set; }
        public Vector3 GetVehicule { get; set; }

        public LSPDData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.GetWeapon = new Vector3();
            this.GetVehicule = new Vector3();
        }

        public LSPDData(int id, int state, Vector3 getservice, Vector3 getweapon, Vector3 getvehicle)
        {
            this.HashCode = id;
            this.GetService = getservice;
            this.GetWeapon = getweapon;
            this.GetVehicule = getvehicle;
            this.State = state;
        }
    }

    //
    //
    //

    public class LSDHData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public Vector3 GetService { get; set; }
        public Vector3 GetUtils { get; set; }
        public Vector3 GetVehicule { get; set; }

        public LSDHData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.GetUtils = new Vector3();
            this.GetVehicule = new Vector3();
        }

        public LSDHData(int id, int state, Vector3 getservice, Vector3 getutils, Vector3 getvehicle)
        {
            this.HashCode = id;
            this.GetService = getservice;
            this.GetUtils = getutils;
            this.GetVehicule = getvehicle;
            this.State = state;
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
        public Vector3 GetService { get; set; }
        public Vector3 From { get; set; }

        public BankData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.From = new Vector3();
        }

        public BankData(int id, int state, Vector3 getservice, Vector3 from)
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
    //

    public class BennysCustomData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public Vector3 GetService { get; set; }
        public Vector3 From { get; set; }

        public BennysCustomData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.From = new Vector3();
        }

        public BennysCustomData(int id, int state, Vector3 getservice, Vector3 from)
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
        public Vector3 GetService { get; set; }
        public Vector3 From { get; set; }

        public WeazelNewsData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.From = new Vector3();
        }

        public WeazelNewsData(int id, int state, Vector3 getservice, Vector3 from)
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
        public int State { get; set; }
        public Vector3 GetService { get; set; }
        public Vector3 From { get; set; }

        public ConcessShopData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.From = new Vector3();
        }

        public ConcessShopData(int id, int state, Vector3 getservice, Vector3 from)
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

    public class BlackKnightData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public Vector3 GetService { get; set; }
        public Vector3 From { get; set; }

        public BlackKnightData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.From = new Vector3();
        }

        public BlackKnightData(int id, int state, Vector3 getservice, Vector3 from)
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
        public Vector3 GetService { get; set; }
        public Vector3 From { get; set; }

        public LostData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.From = new Vector3();
        }

        public LostData(int id, int state, Vector3 getservice, Vector3 from)
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
        public Vector3 GetService { get; set; }
        public Vector3 From { get; set; }

        public FishData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.From = new Vector3();
        }

        public FishData(int id, int state, Vector3 getservice, Vector3 from)
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

    public class TaxiData
    {
        public int HashCode { get; set; }
        public int State { get; set; }
        public Vector3 GetService { get; set; }
        public Vector3 From { get; set; }

        public TaxiData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.From = new Vector3();
        }

        public TaxiData(int id, int state, Vector3 getservice, Vector3 from)
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
        public Vector3 GetService { get; set; }
        public Vector3 From { get; set; }

        public AtmData()
        {
            this.HashCode = 0;
            this.State = 0;
            this.GetService = new Vector3();
            this.From = new Vector3();
        }

        public AtmData(int id, int state, Vector3 getservice, Vector3 from)
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
