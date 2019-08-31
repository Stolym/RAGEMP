using System;
using System.Collections.Generic;
using System.Text;
using main.Ventura.Engine.Constant;
using ZeroFormatter;
using main.Ventura.Engine.Item;
using main.Ventura.Engine.Inventory;
using Newtonsoft.Json;

namespace main.Ventura.Engine.Stack
{
    [JsonObject]
    public interface IStack
    {
        int ItemLimit { get; set; }
        int Id { get; set; }
        int Hashcode { get; set; }
        Constant.Constant.StackHash Type { get; }
        List<Iitem> ListItems { get; set; }
        Type CastType { get; }
        [JsonIgnore]
        AddItemInStack AddItemInStack { get; }
        [JsonIgnore]

        RemoveItemInStack RemoveItemInStack { get; }
        [JsonIgnore]

        UseItemInStack UseItemInStack { get; }
        [JsonIgnore]

        DropItemInStack DropItemInStack { get; }
        [JsonIgnore]

        GiveItemInStack GiveItemInStack { get; }
    }
    
    [JsonObject]
    public class SBody : IStack
    {
        public virtual int ItemLimit { get; set; }
        public Constant.Constant.StackHash Type { get => Constant.Constant.StackHash.BODY; }
        public virtual List<Iitem> ListItems { get; set; }
        public virtual int Id { get; set; }
        public virtual int Hashcode { get; set; }
        public virtual Type CastType { get => typeof(SBody); }
        [JsonIgnore]
        public virtual AddItemInStack AddItemInStack { get; }
        [JsonIgnore]
        public virtual RemoveItemInStack RemoveItemInStack { get; }
        [JsonIgnore]
        public virtual UseItemInStack UseItemInStack { get => EventStack.UseItemInStack; }
        [JsonIgnore]
        public virtual DropItemInStack DropItemInStack { get => EventStack.DropItemInStack; }
        [JsonIgnore]
        public virtual GiveItemInStack GiveItemInStack { get; }
        public SBody()
        {
            Id = 93;
            ItemLimit = 10;
            ListItems = new List<Iitem>();
        }

        public Inventory.STACKCEFCOMMAND ConvertStack(int x)
        {
            Inventory.STACKCEFCOMMAND data = new STACKCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.x = x;
            data.limit = ItemLimit;
            data.state = (int)Type;
            data.list_item = new List<ITEMCEFCOMMAND>();

            for (int i = 0; i < ListItems.Count; i++)
            {
                dynamic tmp = Convert.ChangeType(ListItems[i], ListItems[i].CastType);
                data.list_item.Add(tmp.ConvertItem());
            }
            return data;
        }
    }
    
    [JsonObject]
    public class Divers : IStack
    {
        public virtual int ItemLimit { get; set; }
        public Constant.Constant.StackHash Type { get => Constant.Constant.StackHash.DIVERSOBJECT; }
        public virtual List<Iitem> ListItems { get; set; }
        public virtual int Id { get; set; }
        public virtual int Hashcode { get; set; }
        public virtual Type CastType { get => typeof(Divers); }

        [JsonIgnore]
        public virtual AddItemInStack AddItemInStack { get; }

        [JsonIgnore]
        public virtual RemoveItemInStack RemoveItemInStack { get => EventStack.RemoveItemInStack; }

        [JsonIgnore]
        public virtual UseItemInStack UseItemInStack { get => EventStack.UseItemInStack; }

        [JsonIgnore]
        public virtual DropItemInStack DropItemInStack { get => EventStack.DropItemInStack; }

        [JsonIgnore]
        public virtual GiveItemInStack GiveItemInStack { get; }

        public Divers()
        {
            Id = 424242;
            ItemLimit = 0;
            ListItems = new List<Iitem>();
        }


        public Inventory.STACKCEFCOMMAND ConvertStack(int x)
        {
            Inventory.STACKCEFCOMMAND data = new STACKCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.x = x;
            data.limit = ItemLimit;
            data.state = (int)Type;
            data.list_item = new List<ITEMCEFCOMMAND>();

            for (int i = 0; i < ListItems.Count; i++)
            {
                dynamic tmp = Convert.ChangeType(ListItems[i], ListItems[i].CastType);
                data.list_item.Add(tmp.ConvertItem());
            }
            return data;
        }
    }

    [JsonObject]
    public class Keyring : IStack
    {
        public virtual int ItemLimit { get; set; }
        public Constant.Constant.StackHash Type { get => Constant.Constant.StackHash.KEYRING; }
        public virtual List<Iitem> ListItems { get; set; }
        public virtual int Id { get; set; }
        public virtual int Hashcode { get; set; }
        public virtual Type CastType { get => typeof(Keyring); }

        [JsonIgnore]
        public virtual AddItemInStack AddItemInStack { get; }

        [JsonIgnore]
        public virtual RemoveItemInStack RemoveItemInStack { get; }

        [JsonIgnore]
        public virtual UseItemInStack UseItemInStack { get => EventStack.UseItemInStack; }

        [JsonIgnore]
        public virtual DropItemInStack DropItemInStack { get => EventStack.DropItemInStack; }

        [JsonIgnore]
        public virtual GiveItemInStack GiveItemInStack { get; }

        public Keyring()
        {
            Id = 21;
            ItemLimit = 10;
            ListItems = new List<Iitem>();
        }

        public Inventory.STACKCEFCOMMAND ConvertStack(int x)
        {
            Inventory.STACKCEFCOMMAND data = new STACKCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.x = x;
            data.limit = ItemLimit;
            data.state = (int)Type;
            data.list_item = new List<ITEMCEFCOMMAND>();

            for (int i = 0; i < ListItems.Count; i++)
            {
                dynamic tmp = Convert.ChangeType(ListItems[i], ListItems[i].CastType);
                data.list_item.Add(tmp.ConvertItem());
            }
            return data;
        }
    }
    
    [JsonObject]
    public class Wallet : IStack
    {
        public virtual int ItemLimit { get; set; }
        public Constant.Constant.StackHash Type { get => Constant.Constant.StackHash.WALLET; }
        public virtual List<Iitem> ListItems { get; set; }
        public virtual int Id { get; set; }
        public virtual int Hashcode { get; set; }
        public virtual Type CastType { get => typeof(Wallet); }

        [JsonIgnore]
        public virtual AddItemInStack AddItemInStack { get; }

        [JsonIgnore]
        public virtual RemoveItemInStack RemoveItemInStack { get; }

        [JsonIgnore]
        public virtual UseItemInStack UseItemInStack { get => EventStack.UseItemInStack; }

        [JsonIgnore]
        public virtual DropItemInStack DropItemInStack { get => EventStack.DropItemInStack; }

        [JsonIgnore]
        public virtual GiveItemInStack GiveItemInStack { get; }

        public Wallet()
        {
            Id = 19;
            ItemLimit = 10;
            ListItems = new List<Iitem>();
        }
        public Inventory.STACKCEFCOMMAND ConvertStack(int x)
        {
            Inventory.STACKCEFCOMMAND data = new STACKCEFCOMMAND();
            data.hashcode = Hashcode;
            data.id = Id;
            data.x = x;
            data.limit = ItemLimit;
            data.state = (int)Type;
            data.list_item = new List<ITEMCEFCOMMAND>();

            for (int i = 0; i < ListItems.Count; i++)
            {
                dynamic tmp = Convert.ChangeType(ListItems[i], ListItems[i].CastType);
                data.list_item.Add(tmp.ConvertItem());
            }
            return data;
        }
    }
}
