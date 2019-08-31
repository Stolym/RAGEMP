using System;
using System.Collections.Generic;
using System.Text;
using main.Ventura.Engine.Item;
using main.Ventura.Engine.Stack;


namespace main.Ventura.Engine.Constant
{
    public class OClock
    {
        long Ticks = 0;

        public OClock(int day, int hour, int min, int sec, int ms)
        {
            Ticks = DateTime.Now.AddDays(day).AddHours(hour).AddMinutes(min).AddSeconds(sec).AddMilliseconds(ms).Ticks;
        }

        public bool ResetTick(int day, int hour, int min, int sec, int ms)
        {

            if (Ticks == 0)
                Ticks = DateTime.Now.AddDays(day).AddHours(hour).AddMinutes(min).AddSeconds(sec).AddMilliseconds(ms).Ticks;
            return true;
        }

        public bool Tick()
        {
            if (DateTime.Now.Ticks > Ticks)
            {
                Ticks = 0;
                return true;
            }
            return false;
        }
    }

    public static class Crypton {
        private static long hashcode = 999;
        public static long GetNewHashcode() {
            hashcode++;
            return hashcode;
        }
    }

    public class Constant
    {
        

        public static void Swap<T>(IList<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }

        public enum StructInventoryHash
        {
            ITEM,
            STACK,
            INVENTORY,
        }


        public enum InventoryHash
        {
            PLAYER,
            CONTAIN
        }


        public static List<Type> stack_type = new List<Type>()
        {
            typeof(SBody),
            typeof(SBody),
            typeof(Divers),
            typeof(Wallet),
            typeof(Keyring),
        };

        public enum StackHash
        {
            BODY,
            FULLCLOTH,
            DIVERSOBJECT,
            WALLET,
            KEYRING,
        }
        public enum ItemHash
        {
            PHONE,
            MONEY_BILL,
            GPS,
            FOOD,
            WATER,
            CLOTH,
            GOLD,
            CLOPE,
            SIM,
            PASSPORT,
            BURGER,
            BOARD,
            BOTTLE,
            COCKTAIL,
            LIGHTER,
            BEER,
            BEER2,
            SANDWICH,
            BINOCULARS,
            UMBRELLA,
            CUFFS,
            MICROPHONE,
            RADIO,
            COFFEE,
            CHIPS,
            SUITCASE,
            MICROPHONE2,
            SCALPEL,
            PINK,
            JOINT,
            SYRINGE,
            SODABOTTLE,
            BILLET,
            WATERBOTTLE,
            DONUTS,
            PAQUETCLOPE,
            TACOS,
            JUMELLES,
            PARAPLUIE,
            ROSE,
            RADIOSTATION,
            SMARTSPHONE,
            TALKIE,
            MALETTE,
            PORTEFEUILLE,
            BILLBILLET,
            KEYHOUSE,
            CREDITCARD,
            GUNCARD,
            MEDICCARD,
            COPCARD,
            IDCARD,
            POT,
            DIRTBAG,
            PARACHUTE,
            MONEYBAG,
            FISHBOX,
            FISH,
            BARRELBRUT,
            BARRELGAZOL,
            RAISINR,
            REDWINE,
            WHITEWINE,
            CHAMPAGNE,
            RAISINB,
            MALT,
            ORGE,
            PATATO,
            WHISKY,
            VODKA,
            COCAINEPAPER,
            GHB,
            COCAINESEED,
            WEEDSEED,
            COCAINEPOUCH,
            WEEDPOUCH,
            WEED,
            DOLIPRANE,
            SERINGUE,
            FRITE,
            EARRING,
            BRACELET,
            COLLIER,
            COSTUME,
            GANTS,
            LUNETTE,
            MONTRE,
            BAG,
            MAILLOTDEBAIN,
            PANTALON,
            SHORTS,
            SOUSVETEMENT,
            BASKET,
            BIKINI,
            BONNET,
            CAM,
            CARKEY,
            CASQUETTE,
            CHAPEAU,
            CLASSICSHOES,
            CHEMISE,
            CLAQUETTE,
            CRAVATTE,
            ECHARPE,
            MANCHECOURT,
            MANCHELONG,
            MANTEAU,
            MASQUE,
            MICRO,
            SHOESMONTANT,
            NOEUDPAPILLON,
            PERCHE,
            VESTE,
            VESTEDECOSTUME,
            VESTESANSMANCHE,
            MBODY,
            MBOUCLE,
            MCHAPEAU,
            MGANTS,
            MJUMELLE,
            MLEG,
            MMASQUE,
            MBAG,
            MSHIRT,
            MSHOES,
            MTIE,
            MTSHIRT,
            DRIVERLICENSE,
        }

    }
}
