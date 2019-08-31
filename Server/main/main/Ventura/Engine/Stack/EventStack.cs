using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using main.Ventura.Engine.Item;
using CGAPI = main.Ventura.Gestion.CharacterGestion;
using WAPI = main.Ventura.Permission.WhiteListCommand;
using DAPI = main.Ventura.Gestion.DimensionGestion;
using DUSER = main.Ventura.Database.DataUser;
using LAPI = main.Ventura.Gestion.LogGestion;
using ASAPI = main.Ventura.Stream.Async.Event.AsyncEvent;
using main.Ventura.Stream;
using main.Ventura.Constant;
using FAPI = main.Ventura.Database.Formatter.Formatter;

namespace main.Ventura.Engine.Stack
{
    /* Delegate Event */

    public delegate bool AddItemInStack(IStack obj, Iitem target);
    public delegate bool RemoveItemInStack(ref IStack obj, Iitem target);
    public delegate bool UseItemInStack(ref IStack obj, ref DUSER data);
    public delegate bool DropItemInStack(ref IStack obj);
    public delegate bool GiveItemInStack(IStack obj, Client client);
    public delegate bool SetDefaultItemInStack(Client client, IStack obj, Iitem target);

    public static class EventStack
    {
        private static int[] ListSpecific = new int[] { 0 };
        private static bool CheckInStack(ref IStack obj) {
            if (obj.ListItems.Count == 0)
            {
                obj.Id = 424242;
                obj.Hashcode = (int)Constant.Crypton.GetNewHashcode();
            }
            return true;
        }

        private static bool CheckSpecificUseByStack(ref IStack obj)
        {
            for (int i = 0; i < ListSpecific.Length; i++)
            {
                if (obj.Id == ListSpecific[i])
                    return (true);
            }
            return false;
        }

        private static bool SpecificUseByStack(ref IStack obj, ref DUSER data)
        {
            int select = -1;
            int Hashcode = obj.Hashcode;

            for (int i = 0; i < ListSpecific.Length; i++)
            {
                if (obj.Id == ListSpecific[i])
                    select = obj.Id;
            }

            switch (select) {
                case -1:
                    return false;
                    break;
                case 0:
                    data.information.ActualMoney += obj.ListItems.Count;
                    data.inventory.ListStack[data.inventory.ListStack.FindIndex(x => x.Hashcode == Hashcode)] = new Divers()
                    {
                        Id = 424242,
                        Hashcode = (int)Constant.Crypton.GetNewHashcode()
                    };
                    break;
                case 105: //  tenue
                    break;
            }

            return true;
        }

        public static bool UseItemInStack(ref IStack obj, ref DUSER data)
        {
            if (obj.ListItems.Count == 0)
                return false;
            if (CheckSpecificUseByStack(ref obj))
                return SpecificUseByStack(ref obj, ref data);
            obj.ListItems[0].UseFunction(obj.ListItems[0], data);
            if (obj.RemoveItemInStack(ref obj, obj.ListItems[0]) == false) ;
                return false;
            return CheckInStack(ref obj);
        }

        public static bool DropItemInStack(ref IStack obj)
        {
            if (obj.ListItems.Count == 0)
                return false;
            obj.ListItems[0].DropFunction(obj.ListItems[0]);
            if (obj.RemoveItemInStack(ref obj, obj.ListItems[0]) == false) ;
                return false;
            return CheckInStack(ref obj);
        }

        public static bool RemoveItemInStack(ref IStack obj, Iitem target)
        {
            if (obj.ListItems.Contains(target) == false)
                return false;
            obj.ListItems.Remove(target);
            return true;
        }
        /*public static bool AddItemInStack(IStack obj, Iitem target)
        {
            IStack data = obj;
            Iitem item = target;

            if (data.items_list.Count >= data.item_limit)
                return false;
            data.items_list.Add(item);
            return true;
        }

        public static bool RemoveItemInStack(dynamic obj, dynamic target)
        {
            IStack data = obj;
            Iitem item = target;

            if (data.items_list.Contains(item) == false)
                return false;
            data.items_list.Remove(item);
            return true;
        }
        
        public static bool SwapItemsInStack(dynamic obj, dynamic target, dynamic other)
        {
            IStack data = obj;
            Iitem item = target;
            Iitem item_b = other;

            if (data.items_list.Contains(item) == false || data.items_list.Contains(item_b) == false)
                return false;
            Constant.Constant.Swap<Iitem>(
                data.items_list,
                data.items_list.FindIndex(x => x.hashcode == item.hashcode),
                data.items_list.FindIndex(x => x.hashcode == item_b.hashcode)
                );
            return true;
        }*/

    }
}
