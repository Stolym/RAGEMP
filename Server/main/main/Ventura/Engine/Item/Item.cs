using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using Newtonsoft.Json;
using main.Ventura.Engine.Constant;
using CGAPI = main.Ventura.Gestion.CharacterGestion;
using WAPI = main.Ventura.Permission.WhiteListCommand;
using DAPI = main.Ventura.Gestion.DimensionGestion;
using DUSER = main.Ventura.Database.DataUser;
using LAPI = main.Ventura.Gestion.LogGestion;
using ASAPI = main.Ventura.Stream.Async.Event.AsyncEvent;

namespace main.Ventura.Engine.Item
{

    [JsonObject]
    public interface Iitem
    {
        int Id { get; set; }
        long Hashcode { get; set; }
        string Name { get; set; }
        string ModelName { get; set; }
        Constant.Constant.ItemHash Type { get; }
        Type CastType { get; }

        [JsonIgnore]
        Use UseFunction { get; }

        [JsonIgnore]
        Drop DropFunction { get; }

        [JsonIgnore]
        Give GiveFunction { get; }
    }



    [JsonObject]
    public class Billet : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Billet); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.BILLET; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public Billet()
        {
            Id = 0;
            Name = "Billet";
            ModelName = "p_banknote_s";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }

    [JsonObject]
    public class Burger : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Burger); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.BURGER; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseBurger; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public Burger()
        {
            Id = 1;
            Name = "Burger";
            ModelName = "prop_cs_burger_01";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }

    [JsonObject]
    public class WaterBottle : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(WaterBottle); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.WATERBOTTLE; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseWaterBottle; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public WaterBottle()
        {
            Id = 2;
            Name = "Water Bottle";
            ModelName = "prop_ld_flow_bottle";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }

    [JsonObject]
    public class Coffee : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Coffee); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.COFFEE; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public Coffee()
        {
            Id = 3;
            Name = "Coffee";
            ModelName = "prop_fib_coffee";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }

    [JsonObject]
    public class SodaBottle : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(SodaBottle); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.SODABOTTLE; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public SodaBottle()
        {
            Id = 4;
            Name = "Soda";
            ModelName = "ng_proc_sodacan_01a";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }

    [JsonObject]
    public class Donuts : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Donuts); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.DONUTS; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }
        public Donuts()
        {
            Id = 5;
            Name = "Donuts";
            ModelName = "prop_amb_donut";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }

    [JsonObject]
    public class Tacos : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Tacos); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.TACOS; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public Tacos()
        {
            Id = 6;
            Name = "Tacos";
            ModelName = "prop_taco_01";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }

    [JsonObject]
    public class Clope : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Clope); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.CLOPE; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public Clope()
        {
            Id = 7;
            Name = "Clope";
            ModelName = "ng_proc_cigarette01a";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }

    [JsonObject]
    public class PaquetClope : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(PaquetClope); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.PAQUETCLOPE; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public PaquetClope()
        {
            Id = 8;
            Name = "Paquet Clope";
            ModelName = "prop_fag_packet_01";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }

    [JsonObject]
    public class Jumelles : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Jumelles); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.JUMELLES; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public Jumelles()
        {
            Id = 10;
            Name = "Jumelles";
            ModelName = "prop_binoc_01";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }

    [JsonObject]
    public class Parapluie : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Parapluie); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.PARAPLUIE; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public Parapluie()
        {
            Id = 11;
            Name = "Parapluie";
            ModelName = "p_amb_brolly_01";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }

    [JsonObject]
    public class Rose : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Rose); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.ROSE; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public Rose()
        {
            Id = 12;
            Name = "Rose";
            ModelName = "p_single_rose_s";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }

    [JsonObject]
    public class RadioStation : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(RadioStation); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.RADIOSTATION; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public RadioStation()
        {
            Id = 13;
            Name = "RadioStation";
            ModelName = "prop_radio_01";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }

    [JsonObject]
    public class Sim : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Sim); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.SIM; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public Sim()
        {
            Id = 14;
            Name = "Sim";
            ModelName = "prop_phone_proto_battery";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }

    [JsonObject]
    public class Smartsphone : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Smartsphone); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.SMARTSPHONE; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public Smartsphone()
        {
            Id = 15;
            Name = "Smartsphone";
            ModelName = "prop_phone_ing";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }

    [JsonObject]
    public class Talkie : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Talkie); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.TALKIE; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public Talkie()
        {
            Id = 16;
            Name = "Talkie";
            ModelName = "prop_cs_walkie_talkie";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }

    [JsonObject]
    public class Malette : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Malette); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.MALETTE; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public Malette()
        {
            Id = 17;
            Name = "Malette";
            ModelName = "prop_ld_case_01";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }

    [JsonObject]
    public class Sandwich : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Sandwich); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.SANDWICH; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public Sandwich()
        {
            Id = 18;
            Name = "Sandwich";
            ModelName = "prop_sandwich_01";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }

    [JsonObject]
    public class PorteFeuille : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(PorteFeuille); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.PORTEFEUILLE; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public PorteFeuille()
        {
            Id = 19;
            Name = "PorteFeuille";
            ModelName = "";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }

    [JsonObject]
    public class BillBillet : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(BillBillet); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.BILLBILLET; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public BillBillet()
        {
            Id = 20;
            Name = "BillBillet";
            ModelName = "hei_prop_heist_cash_pile";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }

    [JsonObject]
    public class KeyHouse : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(KeyHouse); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.KEYHOUSE; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public KeyHouse()
        {
            Id = 21;
            Name = "KeyHouse";
            ModelName = "prop_cuff_keys_01";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }

    [JsonObject]
    public class CreditCard : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(CreditCard); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.CREDITCARD; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public CreditCard()
        {
            Id = 22;
            Name = "CreditCard";
            ModelName = "p_ld_id_card_01";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class GunCard : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(GunCard); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.GUNCARD; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public GunCard()
        {
            Id = 23;
            Name = "GunCard";
            ModelName = "prop_ld_contact_card";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class MedicCard : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(MedicCard); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.MEDICCARD; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public MedicCard()
        {
            Id = 24;
            Name = "MedicCard";
            ModelName = "p_ld_id_card_002";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class CopCard : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(CopCard); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.COPCARD; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public CopCard()
        {
            Id = 25;
            Name = "CopCard";
            ModelName = "p_ld_id_card_002";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class IdCard : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(IdCard); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.IDCARD; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public IdCard()
        {
            Id = 26;
            Name = "IdCard";
            ModelName = "p_ld_id_card_01";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class Pot : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Pot); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.POT; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public Pot()
        {
            Id = 27;
            Name = "Pot";
            ModelName = "prop_ld_planter3b";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class DirtBag : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(DirtBag); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.DIRTBAG; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public DirtBag()
        {
            Id = 28;
            Name = "DirtBag";
            ModelName = "prop_ld_planter3b";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class Parachute : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Parachute); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.PARACHUTE; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public Parachute()
        {
            Id = 29;
            Name = "Parachute";
            ModelName = "p_parachute_s_shop";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class MoneyBag : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(MoneyBag); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.MONEYBAG; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public MoneyBag()
        {
            Id = 30;
            Name = "MoneyBag";
            ModelName = "prop_money_bag_01";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class FishBox : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(FishBox); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.FISHBOX; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public FishBox()
        {
            Id = 31;
            Name = "FishBox";
            ModelName = "ng_proc_box_01a";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class Fish : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Fish); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.FISH; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public Fish()
        {
            Id = 32;
            Name = "Fish";
            ModelName = "p_shoalfish_s";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class BarrelBrut : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(BarrelBrut); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.BARRELBRUT; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public BarrelBrut()
        {
            Id = 33;
            Name = "BarrelBrut";
            ModelName = "prop_barrel_03a";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class BarrelGazol : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(BarrelGazol); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.BARRELGAZOL; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public BarrelGazol()
        {
            Id = 34;
            Name = "BarrelGazol";
            ModelName = "prop_barrel_exp_01a";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class RaisinR : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(RaisinB); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.RAISINR; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public RaisinR()
        {
            Id = 35;
            Name = "Raisin Rouge";
            ModelName = "";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class RedWine : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(RedWine); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.REDWINE; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public RedWine()
        {
            Id = 36;
            Name = "RedWine";
            ModelName = "prop_plonk_red";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class WhiteWine : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(WhiteWine); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.WHITEWINE; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public WhiteWine()
        {
            Id = 37;
            Name = "WhiteWine";
            ModelName = "prop_plonk_white";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class Champagne : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Champagne); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.CHAMPAGNE; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public Champagne()
        {
            Id = 38;
            Name = "Champagne";
            ModelName = "prop_champ_jer_01a";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class RaisinB : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(RaisinB); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.RAISINB; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public RaisinB()
        {
            Id = 39;
            Name = "Raisin Blanc";
            ModelName = "";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class Beer : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Beer); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.BEER; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public Beer()
        {
            Id = 40;
            Name = "Beer";
            ModelName = "prop_beer_blr";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class Malt : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Malt); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.MALT; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public Malt()
        {
            Id = 41;
            Name = "Malt";
            ModelName = "prop_feed_sack_01";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class Orge : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Orge); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.ORGE; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public Orge()
        {
            Id = 42;
            Name = "Orge";
            ModelName = "prop_feed_sack_01";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class Patato : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Patato); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.PATATO; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public Patato()
        {
            Id = 43;
            Name = "Patato";
            ModelName = "prop_feed_sack_01";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class Whisky : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Whisky); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.WHISKY; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public Whisky()
        {
            Id = 44;
            Name = "Whisky";
            ModelName = "prop_whiskey_bottle";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class Vodka : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Vodka); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.VODKA; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public Vodka()
        {
            Id = 45;
            Name = "Vodka";
            ModelName = "prop_vodka_bottle";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class CocainePaper : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(CocainePaper); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.COCAINEPAPER; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public CocainePaper()
        {
            Id = 46;
            Name = "CocainePaper";
            ModelName = "";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class GHB : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(GHB); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.GHB; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public GHB()
        {
            Id = 47;
            Name = "GHB";
            ModelName = "ng_proc_drug01a002";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class CocaineSeed : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(CocaineSeed); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.COCAINESEED; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public CocaineSeed()
        {
            Id = 48;
            Name = "CocaineSeed";
            ModelName = "";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class WeedSeed : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(WeedSeed); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.WEEDSEED; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public WeedSeed()
        {
            Id = 49;
            Name = "WeedSeed";
            ModelName = "bkr_prop_weed_dry_01a";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class CocainePouch : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(CocainePouch); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.COCAINEPOUCH; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public CocainePouch()
        {
            Id = 50;
            Name = "CocainePouch";
            ModelName = "";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class WeedPouch : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(WeedPouch); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.WEEDPOUCH; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public WeedPouch()
        {
            Id = 51;
            Name = "WeedPouch";
            ModelName = "prop_weed_bottle";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class Weed : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Weed); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.WEED; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public Weed()
        {
            Id = 52;
            Name = "Weed";
            ModelName = "prop_weed_bottle";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class Doliprane : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Doliprane); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.DOLIPRANE; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public Doliprane()
        {
            Id = 53;
            Name = "Doliprane";
            ModelName = "ng_proc_drug01a002";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class Seringue : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Seringue); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.SERINGUE; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public Seringue()
        {
            Id = 54;
            Name = "Seringue";
            ModelName = "prop_syringe_01";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class Cocktail : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Cocktail); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.COCKTAIL; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public Cocktail()
        {
            Id = 55;
            Name = "Cocktail";
            ModelName = "prop_cocktail";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class Frite : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Frite); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.FRITE; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public Frite()
        {
            Id = 56;
            Name = "Frite";
            ModelName = "";
        }

        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }

    [JsonObject]
    public class EarRing : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(EarRing); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.EARRING; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public EarRing()
        {
            Id = 57;
            Name = "EarRing";
            ModelName = "p_tmom_earrings_s";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class Bracelet : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Bracelet); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.BRACELET; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public Bracelet()
        {
            Id = 58;
            Name = "Bracelet";
            ModelName = "prop_cs_box_clothes";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class Collier : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Collier); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.COLLIER; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public Collier()
        {
            Id = 59;
            Name = "Collier";
            ModelName = "p_csbporndudes_necklace_s";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class Costume : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Costume); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.COSTUME; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public Costume()
        {
            Id = 60;
            Name = "EarRing";
            ModelName = "";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class Gants : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Gants); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.GANTS; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public Gants()
        {
            Id = 61;
            Name = "Gants";
            ModelName = "prop_cs_box_clothes";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class Lunette : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Lunette); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.LUNETTE; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public Lunette()
        {
            Id = 62;
            Name = "Lunette";
            ModelName = "prop_cs_sol_glasses";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class Montre : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Montre); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.MONTRE; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public Montre()
        {
            Id = 63;
            Name = "Montre";
            ModelName = "p_watch_01";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class Bag : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Bag); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.BAG; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public Bag()
        {
            Id = 64;
            Name = "Bag";
            ModelName = "p_ld_heist_bag_s_1";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class MaillotDeBain : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(MaillotDeBain); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.MAILLOTDEBAIN; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public MaillotDeBain()
        {
            Id = 65;
            Name = "MaillotDeBain";
            ModelName = "prop_cs_box_clothes";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class Pantalon : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Pantalon); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.PANTALON; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public Pantalon()
        {
            Id = 66;
            Name = "Pantalon";
            ModelName = "prop_cs_box_clothes";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class Shorts : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Shorts); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.SHORTS; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public Shorts()
        {
            Id = 67;
            Name = "Shorts";
            ModelName = "prop_cs_box_clothes";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class SousVetement : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(SousVetement); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.SOUSVETEMENT; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public SousVetement()
        {
            Id = 68;
            Name = "SousVetement";
            ModelName = "prop_cs_box_clothes";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class Basket : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Basket); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.BASKET; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[4] { -1, -1, 6, 0 };

        public Basket()
        {
            Id = 69;
            Name = "Basket";
            ModelName = "prop_cs_box_clothes";
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class Bikini : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Bikini); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.BIKINI; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public Bikini()
        {
            Id = 70;
            Name = "Bikini";
            ModelName = "prop_cs_box_clothes";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class Bonnet : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Bonnet); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.BONNET; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public Bonnet()
        {
            Id = 71;
            Name = "Bonnet";
            ModelName = "prop_cs_box_clothes";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class Cam : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Cam); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.CAM; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public Cam()
        {
            Id = 72;
            Name = "Cam";
            ModelName = "prop_v_cam_01";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class CarKey : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(CarKey); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.CARKEY; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public CarKey()
        {
            Id = 73;
            Name = "CarKey";
            ModelName = "p_car_keys_01";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class Casquette : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Casquette); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.CASQUETTE; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public Casquette()
        {
            Id = 74;
            Name = "Casquette";
            ModelName = "prop_cap_01";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class Chapeau : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Chapeau); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.CHAPEAU; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public Chapeau()
        {
            Id = 75;
            Name = "Chapeau";
            ModelName = "prop_ld_hat_01";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class ClassicShoes : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(ClassicShoes); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.CLASSICSHOES; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public ClassicShoes()
        {
            Id = 76;
            Name = "ClassicShoes";
            ModelName = "prop_ld_shoe_02";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class Chemise : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Chemise); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.CHEMISE; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public Chemise()
        {
            Id = 77;
            Name = "Chemise";
            ModelName = "prop_cs_box_clothes";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class Claquette : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Claquette); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.CLAQUETTE; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public Claquette()
        {
            Id = 78;
            Name = "Claquette";
            ModelName = "prop_cs_box_clothes";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class Cravatte : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Cravatte); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.CRAVATTE; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public Cravatte()
        {
            Id = 79;
            Name = "Cravatte";
            ModelName = "prop_cs_box_clothes";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class Echarpe : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Echarpe); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.ECHARPE; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public Echarpe()
        {
            Id = 80;
            Name = "Echarpe";
            ModelName = "prop_cs_box_clothes";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class MancheCourt : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(MancheCourt); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.MANCHECOURT; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public MancheCourt()
        {
            Id = 81;
            Name = "MancheCourt";
            ModelName = "prop_cs_box_clothes";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class MancheLong : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(MancheLong); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.MANCHELONG; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public MancheLong()
        {
            Id = 82;
            Name = "MancheLong";
            ModelName = "prop_ld_shirt_01";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class Manteau : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Manteau); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.MANTEAU; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public Manteau()
        {
            Id = 83;
            Name = "Manteau";
            ModelName = "prop_cs_box_clothes";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class Masque : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Masque); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.MASQUE; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public Masque()
        {
            Id = 84;
            Name = "Masque";
            ModelName = "prop_cs_box_clothes";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class Micro : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Micro); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.MICRO; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public Micro()
        {
            Id = 85;
            Name = "Micro";
            ModelName = "p_ing_microphonel_01";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class ShoesMontant : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(ShoesMontant); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.SHOESMONTANT; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public ShoesMontant()
        {
            Id = 86;
            Name = "ShoesMontant";
            ModelName = "prop_cs_box_clothes";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class NoeudPapillon : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(NoeudPapillon); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.NOEUDPAPILLON; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public NoeudPapillon()
        {
            Id = 87;
            Name = "NoeudPapillon";
            ModelName = "prop_cs_box_clothes";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class Perche : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Perche); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.PERCHE; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public Perche()
        {
            Id = 88;
            Name = "Perche";
            ModelName = "prop_v_bmike_01";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class Veste : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Veste); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.VESTE; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public Veste()
        {
            Id = 89;
            Name = "Veste";
            ModelName = "prop_cs_box_clothes";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class VesteDeCostume : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(VesteDeCostume); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.VESTEDECOSTUME; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public VesteDeCostume()
        {
            Id = 90;
            Name = "VesteDeCostume";
            ModelName = "prop_cs_box_clothes";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class VesteSansManche : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(VesteSansManche); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.VESTESANSMANCHE; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public VesteSansManche()
        {
            Id = 91;
            Name = "VesteSansManche";
            ModelName = "prop_cs_box_clothes";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class MBody : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(MBody); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.MBODY; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public MBody()
        {
            Id = 93;
            Name = "MBody";
            ModelName = "";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class MBoucle : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(MBoucle); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.MBOUCLE; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public MBoucle()
        {
            Id = 93;
            Name = "MBoucle";
            ModelName = "";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class MChapeau : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(MChapeau); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.MCHAPEAU; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public MChapeau()
        {
            Id = 94;
            Name = "MChapeau";
            ModelName = "";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class MGants : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(MGants); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.MGANTS; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public MGants()
        {
            Id = 95;
            Name = "MGants";
            ModelName = "";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class MJumelle : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(MJumelle); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.MJUMELLE; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public MJumelle()
        {
            Id = 96;
            Name = "MJumelle";
            ModelName = "";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class MLeg : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(MLeg); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.MLEG; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public MLeg()
        {
            Id = 97;
            Name = "MLeg";
            ModelName = "";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class MMasque : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(MMasque); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.MMASQUE; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public MMasque()
        {
            Id = 98;
            Name = "MMasque";
            ModelName = "";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class MBag : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(MBag); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.MBAG; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public MBag()
        {
            Id = 99;
            Name = "MBag";
            ModelName = "";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class MShirt : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(MShirt); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.MSHIRT; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public MShirt()
        {
            Id = 100;
            Name = "MShirt";
            ModelName = "";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class MShoes : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(MShoes); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.MSHOES; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public MShoes()
        {
            Id = 101;
            Name = "MShoes";
            ModelName = "";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class MTie : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(MTie); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.MTIE; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public MTie()
        {
            Id = 102;
            Name = "MTie";
            ModelName = "";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class MTShirt : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(MTShirt); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.MTSHIRT; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public MTShirt()
        {
            Id = 103;
            Name = "MTShirt";
            ModelName = "";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }
    [JsonObject]
    public class DriverLicense : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(DriverLicense); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.DRIVERLICENSE; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public int[] component = new int[2];

        public DriverLicense()
        {
            Id = 104;
            Name = "DriverLicense";
            ModelName = "prop_cs_swipe_card";
            component[0] = -1;
            component[1] = -1;
        }
        public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    } 


    [JsonObject]
    public class PassPort : Iitem
    {
        public virtual int Id { get; set; }
        public virtual long Hashcode { get; set; }
        public virtual string Name { get; set; }
        public virtual string ModelName { get; set; }
        public Type CastType { get => typeof(Billet); }
        public Constant.Constant.ItemHash Type { get => Constant.Constant.ItemHash.COFFEE; }
        [JsonIgnore]
        public Use UseFunction { get => EventItem.UseNormaly; }

        [JsonIgnore]
        public Drop DropFunction { get => EventItem.DropNormaly; }

        [JsonIgnore]
        public Give GiveFunction { get => EventItem.GiveNormaly; }

        public string pname { get; set; }
        public string birthday { get; set; }
        public string last_name { get; set; }
        public string date_issue { get; set; }
        public string date_expiration { get; set; }
        public string path_profil { get; set; }
        public string nationality { get; set; }
        public string place_of_birth { get; set; }
        public string height { get; set; }
        public string sex { get; set; }
        public PassPort()
        {
            Id = 11;
            Name = "PassPort";
            ModelName = "p_ld_id_card_01";

            pname = "";
            birthday = "";
            last_name = "";
            date_issue = "";
            date_expiration = "";
            path_profil = "";
            nationality = "";
            place_of_birth = "";
            height = "";
            sex = "";
        }

        public void SetDefault(DUSER data)
        {
            pname = data.id_card.name;
            birthday = data.id_card.birthday;
            last_name = data.id_card.last_name;
            date_issue = data.id_card.date_issue;
            date_expiration = data.id_card.date_expiration;
            path_profil = data.id_card.path_profil;
            nationality = data.id_card.nationality;
            place_of_birth = data.id_card.place_of_birth;
            height = "180";
            sex = "Homme";
        }

          public Inventory.ITEMCEFCOMMAND ConvertItem()
        {
            Inventory.ITEMCEFCOMMAND data = new Inventory.ITEMCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.description = "";
            return data;
        }
    }

    /*public class Item
    {
        public delegate void Use(Client client);
        public delegate void Drop(Client client);
        public delegate void Give(Client client, ushort RemoteId);
        
        public int Id { get; set; }
        public string name { get; set; }
        public string model_name { get; set; }
        public Constant.Constant.ItemHash Type { get; set; }
        public Use UseFunction { get; set; }
        public Drop DropFunction { get; set; }
        public Give GiveFunction { get; set; }

        public Item() { }

        public void DropNormaly(Client client)
        {

            Vector3 npos = new Vector3(client.Position.X + Math.Cos(client.Heading), client.Position.X + Math.Sin(client.Heading), client.Position.Z);
            //WorldItemManager.add_item_in_list(new Synchronization.WorldObjectSync() { name = model_name, Id = this.Id, x = client.Position.X, y = client.Position.Y, z = client.Position.Z }, this);
            //WorldItemManager.all_stream_in_world_list();
            
            /*if (ItemStream == null)
                ItemStream = NAPI.Object.CreateObject(NAPI.Util.GetHashKey(model_name), client.Position, client.Rotation, 255, CGAPI.get_data_player(client).user.dimensions);
            NAPI.ClientEvent.TriggerClientEventForAll("drop_item_by_remote", client.Handle.Value, ItemStream.Handle.Value);
        }

        public void GiveNormaly(Client client, ushort RemoteId)
        {
            Client target = NAPI.Pools.GetAllPlayers().Find(x => x.Handle.Value == RemoteId);

            if (CGAPI.get_data_player(client) != null && target != null && CGAPI.get_data_player(target) != null) {

            }
        }

        public void UseNormaly(Client client)
        {

        }

    }

    public class Gold : Item
    {
        public Gold()
        {
            name = "Gold";
            Type = Constant.Constant.ItemHash.GOLD;
            UseFunction += UseNormaly;
            DropFunction += DropNormaly;
            GiveFunction += GiveNormaly;
        }
    }


    public class Burger : Item
    {
        public Burger()
        {
            name = "Burger";
            model_name = "prop_cs_burger_01";
            Type = Constant.Constant.ItemHash.BURGER;
            UseFunction += UseBurger;
            DropFunction += DropNormaly;
            GiveFunction += GiveNormaly;
        }


        private void UseBurger(Client client)
        {
            if (CGAPI.get_data_player(client) != null)
            {
                CGAPI.get_data_player(client).info.hunger = CGAPI.get_data_player(client).info.hunger + 10 > 100 ? 100 : CGAPI.get_data_player(client).info.hunger + 10;
            }
        }
    }


    public class Water : Item
    {
        public Water()
        {
            name = "Water";
            model_name = "ng_proc_sodabot_01a";
            Type = Constant.Constant.ItemHash.WATER;
            UseFunction += UseWater;
            DropFunction += DropNormaly;
            GiveFunction += GiveNormaly;
        }

        private void UseWater(Client client)
        {
            if (CGAPI.get_data_player(client) != null)
            {
                CGAPI.get_data_player(client).info.water = CGAPI.get_data_player(client).info.water + 10 > 100 ? 100 : CGAPI.get_data_player(client).info.water + 10;
            }
        }
    }

    public class Phone : Item
    {
        public Phone()
        {
            name = "Phone";
            model_name = "prop_amb_phone";
            Type = Constant.Constant.ItemHash.PHONE;
            UseFunction += UseNormaly;
            DropFunction += DropNormaly;
            GiveFunction += GiveNormaly;
        }

    }

    class Contact
    {
        public string number { get; set; }
        public Dictionary<string, List<string>> sms { get; set; }
    }


    class Sim : Item
    {
        public List<Contact> list_contact = new List<Contact>();

        public Sim()
        {
            name = "Sim";
            model_name = "prop_fib_badge";
            Type = Constant.Constant.ItemHash.SIM;
            UseFunction += UseNormaly;
            DropFunction += DropNormaly;
            GiveFunction += GiveNormaly;
        }
    }

    class Board : Item
    {
        public Board()
        {
            name = "Board";
            model_name = "prop_police_id_board";
            Type = Constant.Constant.ItemHash.BOARD;
            UseFunction += UseNormaly;  
            DropFunction += DropNormaly;
            GiveFunction += GiveNormaly;
        }
    }


    public class Passport : Item
    {
        public string pname { get; set; }
        public string birthday { get; set; }
        public string last_name { get; set; }
        public string date_issue { get; set; }
        public string date_expiration { get; set; }
        public string path_profil { get; set; }
        public string nationality { get; set; }
        public string place_of_birth { get; set; }
        public string height { get; set; }
        public string sex { get; set; }

        public Passport()
        {
            name = "Passport";
            model_name = "prop_passport_01";
            Type = Constant.Constant.ItemHash.PASSPORT;
            UseFunction += UseNormaly;
            DropFunction += DropNormaly;
            GiveFunction += GiveNormaly;
        }
    }


    public class Clope : Item
    {
        public Clope() {
            name = "Clope";
            model_name = "ng_proc_cigarette01a";
            Type = Constant.Constant.ItemHash.CLOPE;
            UseFunction += UseClope;
            DropFunction += DropNormaly;
            GiveFunction += GiveNormaly;
        }

        private void UseClope(Client client)
        {
            //client.TriggerEvent("attach_object");
            //GTANetworkAPI.API.Shared.PlayPlayerAnimation(client, (int)(Constant.Constants.AnimationFlags.Loop | Constant.Constants.AnimationFlags.AllowPlayerControl), "amb@world_human_smoking@male@base ", "base");
            //NAPI.ClientEvent.TriggerClientEventForAll("attach_object_by_remote_id", client.Handle.Value, model_name);

        }
    }

    public class Money : Item
    {
        public Money() {
            name = "MONEY_BILL";
            Type = Constant.Constant.ItemHash.MONEY_BILL;
            UseFunction += UseMoney;
            DropFunction += DropNormaly;
        }

        private void UseMoney(Client client)
        {

        }
    }
    
    class Bottle : Item
    {
        public Bottle()
        {
            name = "Bouteille d'eau";
            model_name = "prop_ld_flow_bottle";
            Type = Constant.Constant.ItemHash.BOTTLE;
            UseFunction += UseNormaly;
            DropFunction += DropNormaly;
            GiveFunction += GiveNormaly;
        }
    }



    class Cocktail : Item
    {
        public Cocktail()
        {
            name = "Cocktail";
            model_name = "prop_cocktail";
            Type = Constant.Constant.ItemHash.COCKTAIL;
            UseFunction += UseNormaly;
            DropFunction += DropNormaly;
            GiveFunction += GiveNormaly;
        }
    }

    class Lighter : Item
    {
        public Lighter()
        {
            name = "Briquet";
            model_name = "p_cs_lighter_01";
            Type = Constant.Constant.ItemHash.LIGHTER;
            UseFunction += UseNormaly;
            DropFunction += DropNormaly;
            GiveFunction += GiveNormaly;
        }
    }

    class Beer : Item
    {
        public Beer()
        {
            name = "Biere";
            model_name = "prop_amb_beer_bottle";
            Type = Constant.Constant.ItemHash.BEER;
            UseFunction += UseNormaly;
            DropFunction += DropNormaly;
            GiveFunction += GiveNormaly;
        }
    }

    class Beer2 : Item
    {
        public Beer2()
        {
            name = "Biere sans alcool";
            model_name = "prop_beer_am";
            Type = Constant.Constant.ItemHash.BEER2;
            UseFunction += UseNormaly;
            DropFunction += DropNormaly;
            GiveFunction += GiveNormaly;
        }
    }

    class Sandwich : Item
    {
        public Sandwich()
        {
            name = "Sandwich";
            model_name = "prop_sandwich_01";
            Type = Constant.Constant.ItemHash.SANDWICH;
            UseFunction += UseNormaly;
            DropFunction += DropNormaly;
            GiveFunction += GiveNormaly;
        }
    }
    
    class Binoculars : Item
    {
        public Binoculars()
        {
            name = "Jumelles";
            model_name = "prop_binoc_01";
            Type = Constant.Constant.ItemHash.BINOCULARS;
            UseFunction += UseNormaly;
            DropFunction += DropNormaly;
            GiveFunction += GiveNormaly;
        }
    }

    class Umbrella : Item
    {
        public Umbrella()
        {
            name = "Parapluie";
            model_name = "p_amb_brolly_01";
            Type = Constant.Constant.ItemHash.UMBRELLA;
            UseFunction += UseNormaly;
            DropFunction += DropNormaly;
            GiveFunction += GiveNormaly;
        }
    }

    class Cuffs : Item
    {
        public Cuffs()
        {
            name = "Menottes";
            model_name = "p_cs_cuffs_02_s";
            Type = Constant.Constant.ItemHash.CUFFS;
            UseFunction += UseNormaly;
            DropFunction += DropNormaly;
            GiveFunction += GiveNormaly;
        }
    }

    class Microphone : Item
    {
        public Microphone()
        {
            name = "Micro Weazel News";
            model_name = "p_ing_microphonel_01";
            Type = Constant.Constant.ItemHash.MICROPHONE;
            UseFunction += UseNormaly;
            DropFunction += DropNormaly;
            GiveFunction += GiveNormaly;
        }
    }

    class Radio : Item
    {
        public Radio()
        {
            name = "Radio";
            model_name = "prop_cs_hand_radio";
            Type = Constant.Constant.ItemHash.RADIO;
            UseFunction += UseNormaly;
            DropFunction += DropNormaly;
            GiveFunction += GiveNormaly;
        }
    }
    

    class Coffee : Item
    {
        public Coffee()
        {
            name = "Café";
            model_name = "prop_fib_coffee";
            Type = Constant.Constant.ItemHash.COFFEE;
            UseFunction += UseNormaly;
            DropFunction += DropNormaly;
            GiveFunction += GiveNormaly;
        }
    }

    class Chips : Item
    {
        public Chips()
        {
            name = "Frite";
            model_name = "prop_food_bs_chips";
            Type = Constant.Constant.ItemHash.CHIPS;
            UseFunction += UseNormaly;
            DropFunction += DropNormaly;
            GiveFunction += GiveNormaly;
        }
    }

    class Suitcase : Item
    {
        public Suitcase()
        {
            name = "Mallette";
            model_name = "prop_ld_case_01";
            Type = Constant.Constant.ItemHash.SUITCASE;
            UseFunction += UseNormaly;
            DropFunction += DropNormaly;
            GiveFunction += GiveNormaly;
        }
    }

    class Microphone2 : Item
    {
        public Microphone2()
        {
            name = "Micro";
            model_name = "prop_microphone_02";
            Type = Constant.Constant.ItemHash.MICROPHONE2;
            UseFunction += UseNormaly;
            DropFunction += DropNormaly;
            GiveFunction += GiveNormaly;
        }
    }

    class Scalpel : Item
    {
        public Scalpel()
        {
            name = "Scalpel";
            model_name = "prop_scalpel";
            Type = Constant.Constant.ItemHash.SCALPEL;
            UseFunction += UseNormaly;
            DropFunction += DropNormaly;
            GiveFunction += GiveNormaly;
        }
    }

    class Pink : Item
    {
        public Pink()
        {
            name = "Rose";
            model_name = "prop_single_rose";
            Type = Constant.Constant.ItemHash.PINK;
            UseFunction += UseNormaly;
            DropFunction += DropNormaly;
            GiveFunction += GiveNormaly;
        }
    }

    class Joint : Item
    {
        public Joint()
        {
            name = "Joint";
            model_name = "prop_sh_joint_01";
            Type = Constant.Constant.ItemHash.JOINT;
            UseFunction += UseNormaly;
            DropFunction += DropNormaly;
            GiveFunction += GiveNormaly;
        }
    }

    class Syringe : Item
    {
        public Syringe()
        {
            name = "Seringue";
            model_name = "prop_syringe_01";
            Type = Constant.Constant.ItemHash.SYRINGE;
            UseFunction += UseNormaly;
            DropFunction += DropNormaly;
            GiveFunction += GiveNormaly;
        }
    }

    class Taco : Item
    {
        public Taco()
        {
            name = "Tacos";
            model_name = "prop_taco_02";
            Type = Constant.Constant.ItemHash.TACO;
            UseFunction += UseNormaly;
            DropFunction += DropNormaly;
            GiveFunction += GiveNormaly;
        }
    }

    class Camera : Item
    {
        public Camera()
        {
            name = "Grosse Caméra";
            model_name = "prop_v_cam_01";
            Type = Constant.Constant.ItemHash.CAMERA;
            UseFunction += UseNormaly;
            DropFunction += DropNormaly;
            GiveFunction += GiveNormaly;
        }
    }

    class Carkey : Item
    {
        public Carkey()
        {
            name = "Clé de voiture";
            model_name = "p_car_keys_01";
            Type = Constant.Constant.ItemHash.CARKEY;
            UseFunction += UseNormaly;
            DropFunction += DropNormaly;
            GiveFunction += GiveNormaly;
        }
    }

    class Housekey : Item
    {
        public Housekey()
        {
            name = "Clé de maison";
            model_name = "prop_cuff_keys_01";
            Type = Constant.Constant.ItemHash.HOUSEKEY;
            UseFunction += UseNormaly;
            DropFunction += DropNormaly;
            GiveFunction += GiveNormaly;
        }
    }

    class Donuts : Item
    {
        public Donuts()
        {
            name = "Donuts";
            model_name = "prop_amb_donut";
            Type = Constant.Constant.ItemHash.DONUTS;
            UseFunction += UseNormaly;
            DropFunction += DropNormaly;
            GiveFunction += GiveNormaly;
        }
    }
    

    class Bong : Item
    {
        public Bong()
        {
            name = "Bang";
            model_name = "prop_bong_01";
            Type = Constant.Constant.ItemHash.BONG;
            UseFunction += UseNormaly;
            DropFunction += DropNormaly;
            GiveFunction += GiveNormaly;
        }
    }

    class Bubbly : Item
    {
        public Bubbly()
        {
            name = "Champagne";
            model_name = "prop_champ_01b";
            Type = Constant.Constant.ItemHash.BUBBLY;
            UseFunction += UseNormaly;
            DropFunction += DropNormaly;
            GiveFunction += GiveNormaly;
        }
    }

    class Whiskey : Item
    {
        public Whiskey()
        {
            name = "Whisky";
            model_name = "prop_bottle_richard";
            Type = Constant.Constant.ItemHash.WHISKEY;
            UseFunction += UseNormaly;
            DropFunction += DropNormaly;
            GiveFunction += GiveNormaly;
        }
    }

    class Rope : Item
    {
        public Rope()
        {
            name = "Corde";
            model_name = "prop_devin_rope_01";
            Type = Constant.Constant.ItemHash.ROPE;
            UseFunction += UseNormaly;
            DropFunction += DropNormaly;
            GiveFunction += GiveNormaly;
        }
    }

    class Dildo : Item
    {
        public Dildo()
        {
            name = "Corde";
            model_name = "prop_cs_dildo_01";
            Type = Constant.Constant.ItemHash.DILDO;
            UseFunction += UseNormaly;
            DropFunction += DropNormaly;
            GiveFunction += GiveNormaly;
        }
    }

    
     class Baseballbat : Item
        {
            public Baseballbat()
            {
                name = "Batte de Baseball";
                model_name = "p_cs_bbbat_01";
                Type = Constant.Constant.ItemHash.BASEBALLBAT;
                UseFunction += UseNormaly;
                DropFunction += DropNormaly;
                GiveFunction += GiveNormaly;
            }
        }


        class Baton : Item
        {
            public Baton()
            {
                name = "Petite Matraque";
                model_name = "prop_blackjack_01";
                Type = Constant.Constant.ItemHash.BATON;
                UseFunction += UseNormaly;
                DropFunction += DropNormaly;
                GiveFunction += GiveNormaly;
            }
        }

        class Machete : Item
        {
            public Machete()
            {
                name = "Machette";
                model_name = "prop_ld_w_me_machette";
                Type = Constant.Constant.ItemHash.MACHETE;
                UseFunction += UseNormaly;
                DropFunction += DropNormaly;
                GiveFunction += GiveNormaly;
            }
        }

        class Minigun : Item
        {
            public Minigun()
            {
                name = "Minigun";
                model_name = "prop_minigun_01";
                Type = Constant.Constant.ItemHash.MINIGUN;
                UseFunction += UseNormaly;
                DropFunction += DropNormaly;
                GiveFunction += GiveNormaly;
            }
        }

        class Extinguisher : Item
        {
            public Extinguisher()
            {
                name = "Extincteur";
                model_name = "w_am_fire_exting";
                Type = Constant.Constant.ItemHash.EXTINGUISHER;
                UseFunction += UseNormaly;
                DropFunction += DropNormaly;
                GiveFunction += GiveNormaly;
            }
        }

        class Jerrycan : Item
        {
            public Jerrycan()
            {
                name = "Bidon d'essence";
                model_name = "w_am_jerrycan";
                Type = Constant.Constant.ItemHash.JERRYCAN;
                UseFunction += UseNormaly;
                DropFunction += DropNormaly;
                GiveFunction += GiveNormaly;
            }
        }

        class Advancedrifle : Item
        {
            public Advancedrifle()
            {
                name = "Fusil Avancé";
                model_name = "w_ar_advancedrifle";
                Type = Constant.Constant.ItemHash.ADVANCEDRIFLE;
                UseFunction += UseNormaly;
                DropFunction += DropNormaly;
                GiveFunction += GiveNormaly;
            }
        }

        class Bullpuprifle : Item
        {
            public Bullpuprifle()
            {
                name = "Fusil Bullpup";
                model_name = "w_ar_bullpuprifle";
                Type = Constant.Constant.ItemHash.ADVANCEDRIFLE;
                UseFunction += UseNormaly;
                DropFunction += DropNormaly;
                GiveFunction += GiveNormaly;
            }
        }

        class Carbinerifle : Item
        {
            public Carbinerifle()
            {
                name = "Carabine";
                model_name = "w_ar_carbinerifle";
                Type = Constant.Constant.ItemHash.CARBINERIFLE;
                UseFunction += UseNormaly;
                DropFunction += DropNormaly;
                GiveFunction += GiveNormaly;
            }
        }

        class Musket : Item
        {
            public Musket()
            {
                name = "Mousquet";
                model_name = "w_ar_musket";
                Type = Constant.Constant.ItemHash.MUSKET;
                UseFunction += UseNormaly;
                DropFunction += DropNormaly;
                GiveFunction += GiveNormaly;
            }
        }

        class Specialcarbine : Item
        {
            public Specialcarbine()
            {
                name = "Carabine spéciale";
                model_name = "w_ar_specialcarbine";
                Type = Constant.Constant.ItemHash.SPECIALCARBINE;
                UseFunction += UseNormaly;
                DropFunction += DropNormaly;
                GiveFunction += GiveNormaly;
            }
        }

        class Grenadefrag : Item
        {
            public Grenadefrag()
            {
                name = "Grenade";
                model_name = "w_ex_grenadefrag";
                Type = Constant.Constant.ItemHash.GRENADEFRAG;
                UseFunction += UseNormaly;
                DropFunction += DropNormaly;
                GiveFunction += GiveNormaly;
            }
        }

        class Grenadesmoke : Item
        {
            public Grenadesmoke()
            {
                name = "Grenade de fumée";
                model_name = "w_ex_grenadesmoke";
                Type = Constant.Constant.ItemHash.GRENADESMOKE;
                UseFunction += UseNormaly;
                DropFunction += DropNormaly;
                GiveFunction += GiveNormaly;
            }
        }


        class Molotov : Item
        {
            public Molotov()
            {
                name = "Cocktails Molotov";
                model_name = "w_ex_molotov";
                Type = Constant.Constant.ItemHash.MOLOTOV;
                UseFunction += UseNormaly;
                DropFunction += DropNormaly;
                GiveFunction += GiveNormaly;
            }
        }

        class Stickybombs : Item
        {
            public Stickybombs()
            {
                name = "Bombe collante";
                model_name = "w_ex_pe";
                Type = Constant.Constant.ItemHash.STICKYBOMBS;
                UseFunction += UseNormaly;
                DropFunction += DropNormaly;
                GiveFunction += GiveNormaly;
            }
        }

        class Grenadelauncher : Item
        {
            public Grenadelauncher()
            {
                name = "Lance grenade";
                model_name = "w_lr_firework";
                Type = Constant.Constant.ItemHash.GRENADELAUNCHER;
                UseFunction += UseNormaly;
                DropFunction += DropNormaly;
                GiveFunction += GiveNormaly;
            }
        }


        class Rpg : Item
        {
            public Rpg()
            {
                name = "RPG";
                model_name = "w_lr_rpg";
                Type = Constant.Constant.ItemHash.RPG;
                UseFunction += UseNormaly;
                DropFunction += DropNormaly;
                GiveFunction += GiveNormaly;
            }
        }

        class Brokenbottle : Item
        {
            public Brokenbottle()
            {
                name = "Bouteille cassée";
                model_name = "w_me_bottle";
                Type = Constant.Constant.ItemHash.BROKENBOTTLE;
                UseFunction += UseNormaly;
                DropFunction += DropNormaly;
                GiveFunction += GiveNormaly;
            }
        }

        class Crowbar : Item
        {
            public Crowbar()
            {
                name = "Pied de biche";
                model_name = "w_me_crowbar";
                Type = Constant.Constant.ItemHash.CROWBAR;
                UseFunction += UseNormaly;
                DropFunction += DropNormaly;
                GiveFunction += GiveNormaly;
            }
        }


        class Dagger : Item
        {
            public Dagger()
            {
                name = "Dague";
                model_name = "w_me_dagger";
                Type = Constant.Constant.ItemHash.DAGGER;
                UseFunction += UseNormaly;
                DropFunction += DropNormaly;
                GiveFunction += GiveNormaly;
            }
        }


        class Golfclub : Item
        {
            public Golfclub()
            {
                name = "Club de golf";
                model_name = "w_me_gclub";
                Type = Constant.Constant.ItemHash.GOLFCLUB;
                UseFunction += UseNormaly;
                DropFunction += DropNormaly;
                GiveFunction += GiveNormaly;
            }
        }


        class Hammer : Item
        {
            public Hammer()
            {
                name = "Marteau";
                model_name = "w_me_hammer";
                Type = Constant.Constant.ItemHash.HAMMER;
                UseFunction += UseNormaly;
                DropFunction += DropNormaly;
                GiveFunction += GiveNormaly;
            }
        }


        class Hatchet : Item
        {
            public Hatchet()
            {
                name = "Hache";
                model_name = "w_me_hatchet";
                Type = Constant.Constant.ItemHash.HATCHET;
                UseFunction += UseNormaly;
                DropFunction += DropNormaly;
                GiveFunction += GiveNormaly;
            }
        }

        class Knife : Item
        {
            public Knife()
            {
                name = "Couteau";
                model_name = "w_me_knife_01";
                Type = Constant.Constant.ItemHash.KNIFE;
                UseFunction += UseNormaly;
                DropFunction += DropNormaly;
                GiveFunction += GiveNormaly;
            }
        }



        class Nightstick : Item
        {
            public Nightstick()
            {
                name = "Matraque";
                model_name = "w_me_nightstick";
                Type = Constant.Constant.ItemHash.NIGHTSTICK;
                UseFunction += UseNormaly;
                DropFunction += DropNormaly;
                GiveFunction += GiveNormaly;
            }
        }


        class Combatmg : Item
        {
            public Combatmg()
            {
                name = "Combat MG Mk II";
                model_name = "w_mg_mg";
                Type = Constant.Constant.ItemHash.COMBATMG;
                UseFunction += UseNormaly;
                DropFunction += DropNormaly;
                GiveFunction += GiveNormaly;
            }
        }

        class Combatpistol : Item
        {
            public Combatpistol()
            {
                name = "Pistolet de combat";
                model_name = "w_pi_combatpistol";
                Type = Constant.Constant.ItemHash.COMBATPISTOL;
                UseFunction += UseNormaly;
                DropFunction += DropNormaly;
                GiveFunction += GiveNormaly;
            }
        }


        class Flaregun : Item
        {
            public Flaregun()
            {
                name = "Pistolet de détresse";
                model_name = "w_pi_flaregun";
                Type = Constant.Constant.ItemHash.FLAREGUN;
                UseFunction += UseNormaly;
                DropFunction += DropNormaly;
                GiveFunction += GiveNormaly;
            }
        }


        class Heavypistol : Item
        {
            public Heavypistol()
            {
                name = "Pistolet lourd";
                model_name = "w_pi_heavypistol";
                Type = Constant.Constant.ItemHash.HEAVYPISTOL;
                UseFunction += UseNormaly;
                DropFunction += DropNormaly;
                GiveFunction += GiveNormaly;
            }
        }


        class Pistol : Item
        {
            public Pistol()
            {
                name = "Pistolet";
                model_name = "w_pi_pistol";
                Type = Constant.Constant.ItemHash.PISTOL;
                UseFunction += UseNormaly;
                DropFunction += DropNormaly;
                GiveFunction += GiveNormaly;
            }
        }


        class Pistol50 : Item
        {
            public Pistol50()
            {
                name = "Pistolet .50";
                model_name = "w_pi_pistol50";
                Type = Constant.Constant.ItemHash.PISTOL50;
                UseFunction += UseNormaly;
                DropFunction += DropNormaly;
                GiveFunction += GiveNormaly;
            }
        }


        class Stungun : Item
        {
            public Stungun()
            {
                name = "Tazer";
                model_name = "w_pi_stungun";
                Type = Constant.Constant.ItemHash.STUNGUN;
                UseFunction += UseNormaly;
                DropFunction += DropNormaly;
                GiveFunction += GiveNormaly;
            }
        }



        class Vintagepistol : Item
        {
            public Vintagepistol()
            {
                name = "Pistolet Vintage";
                model_name = "w_pi_vintage_pistol";
                Type = Constant.Constant.ItemHash.VINTAGEPISTOL;
                UseFunction += UseNormaly;
                DropFunction += DropNormaly;
                GiveFunction += GiveNormaly;
            }
        }


        class Assaultmg : Item
        {
            public Assaultmg()
            {
                name = "Assaut SMG";
                model_name = "w_sb_assaultsmg";
                Type = Constant.Constant.ItemHash.ASSAULTMG;
                UseFunction += UseNormaly;
                DropFunction += DropNormaly;
                GiveFunction += GiveNormaly;
            }
        }

        class Gusenbergsweeper : Item
        {
            public Gusenbergsweeper()
            {
                name = "Gusenberg Sweeper";
                model_name = "w_sb_gusenberg";
                Type = Constant.Constant.ItemHash.GUSENBERGSWEEPER;
                UseFunction += UseNormaly;
                DropFunction += DropNormaly;
                GiveFunction += GiveNormaly;
            }
        }


        class Microsmg : Item
        {
            public Microsmg()
            {
                name = "Petite SMG";
                model_name = "w_sb_microsmg";
                Type = Constant.Constant.ItemHash.MICROSMG;
                UseFunction += UseNormaly;
                DropFunction += DropNormaly;
                GiveFunction += GiveNormaly;
            }
        }

        class Smg : Item
        {
            public Smg()
            {
                name = "SMG";
                model_name = "w_sb_smg";
                Type = Constant.Constant.ItemHash.SMG;
                UseFunction += UseNormaly;
                DropFunction += DropNormaly;
                GiveFunction += GiveNormaly;
            }
        }


        class Assaultshotgun : Item
        {
            public Assaultshotgun()
            {
                name = "Fusil d'assaut";
                model_name = "w_sg_assaultshotgun";
                Type = Constant.Constant.ItemHash.ASSAULTSHOTGUN;
                UseFunction += UseNormaly;
                DropFunction += DropNormaly;
                GiveFunction += GiveNormaly;
            }
        }


        class Bullpupshotgun : Item
        {
            public Bullpupshotgun()
            {
                name = "Shotgun Bullpup";
                model_name = "w_sg_bullpupshotgun";
                Type = Constant.Constant.ItemHash.BULLPUPSHOTGUN;
                UseFunction += UseNormaly;
                DropFunction += DropNormaly;
                GiveFunction += GiveNormaly;
            }
        }


        class Heavyshotgun : Item
        {
            public Heavyshotgun()
            {
                name = "Fusil de chasse lourd";
                model_name = "w_sg_heavyshotgun";
                Type = Constant.Constant.ItemHash.HEAVYSHOTGUN;
                UseFunction += UseNormaly;
                DropFunction += DropNormaly;
                GiveFunction += GiveNormaly;
            }
        }


        class Pumpshotgun : Item
        {
            public Pumpshotgun()
            {
                name = "Fusil à pompe";
                model_name = "w_sg_pumpshotgun";
                Type = Constant.Constant.ItemHash.PUMPSHOTGUN;
                UseFunction += UseNormaly;
                DropFunction += DropNormaly;
                GiveFunction += GiveNormaly;
            }
        }

        class Sawedoffshotgun : Item
        {
            public Sawedoffshotgun()
            {
                name = "Fusil à pompe";
                model_name = "w_sg_sawnoff";
                Type = Constant.Constant.ItemHash.SAWEDOFFSHOTGUN;
                UseFunction += UseNormaly;
                DropFunction += DropNormaly;
                GiveFunction += GiveNormaly;
            }
        }


        class Heavysniper : Item
        {
            public Heavysniper()
            {
                name = "Tireur d'élite lourd";
                model_name = "w_sr_heavysniper";
                Type = Constant.Constant.ItemHash.HEAVYSNIPER;
                UseFunction += UseNormaly;
                DropFunction += DropNormaly;
                GiveFunction += GiveNormaly;
            }
        }



        class Marksmanrifle : Item
        {
            public Marksmanrifle()
            {
                name = "Fusil de tireur d'élite";
                model_name = "w_sr_marksmanrifle";
                Type = Constant.Constant.ItemHash.MARKSMANRIFLE;
                UseFunction += UseNormaly;
                DropFunction += DropNormaly;
                GiveFunction += GiveNormaly;
            }
        }


        class Sniperrifle : Item
        {
            public Sniperrifle()
            {
                name = "Fusil de sniper";
                model_name = "w_sr_sniperrifle";
                Type = Constant.Constant.ItemHash.SNIPERRIFLE;
                UseFunction += UseNormaly;
                DropFunction += DropNormaly;
                GiveFunction += GiveNormaly;
            }
        }*/
}
