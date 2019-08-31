using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using main.Ventura.Engine.Constant;
using main.Ventura.Engine.Item;
using main.Ventura.Engine.Stack;
using CGAPI = main.Ventura.Gestion.CharacterGestion;
using WAPI = main.Ventura.Permission.WhiteListCommand;
using DAPI = main.Ventura.Gestion.DimensionGestion;
using DUSER = main.Ventura.Database.DataUser;
using LAPI = main.Ventura.Gestion.LogGestion;
using ASAPI = main.Ventura.Stream.Async.Event.AsyncEvent;



namespace main.Ventura.Engine.Inventory
{

    [JsonObject]
    public abstract class Inventory
    {
        public virtual string Name { get; set; }
        public virtual Constant.Constant.InventoryHash Type { get; set; }
        public virtual int StackLimit { get; set; }
        public virtual List<IStack> ListStack { get; set; }
        public virtual long Hashcode { get; set; }
        public Inventory() { SetDefault(); }
        void SetDefault()
        {
            Name = "matrix";
            Type = Constant.Constant.InventoryHash.CONTAIN;
            StackLimit = 10;
            ListStack = new List<IStack>();
            for (int i = 0; i < StackLimit; i++)
                ListStack.Add(null);
        }
        public IStack CreateStackInInventory(Type type)
        {
            return (IStack)Activator.CreateInstance(type);
        }

        public bool AddStackInInventory(IStack stack)
        {
            bool ret = false;

            for (int i = 0; i < ListStack.Count; i++)
            {
                if (ListStack[i] == null)
                {
                    ListStack[i] = stack;
                    ret = true;
                    break;
                }
            }
            return ret;
        }
        public bool AddItemInBestStack(Iitem item) {
            IStack best_stack = ListStack.Find(x => x.Id == 424242);

            if (best_stack == null)
                return false;

            best_stack.Id = Convert.ToUInt16(item.Id);
            best_stack.ListItems.Add(item);
            return true;
            /*if (best_stack == null)
            {
                IStack new_stack = this.CreateStackInInventory(Constant.Constant.stack_type[2]);
                if (new_stack == null)
                    return false;
                if (this.AddStackInInventory(new_stack) == false)
                    return false;
                return new_stack.AddItemInStack(new_stack, item);
            }
            return best_stack.AddItemInStack(best_stack, item);*/
        }
        public bool RemoveStackInInventory(IStack stack)
        {
            if (ListStack.Contains(stack) == false)
                return false;
            ListStack.Remove(stack);
            return true;
        }
        public bool SwapStacksInInventory(IStack stack, IStack stack_b)
        {
            if (ListStack.Contains(stack) == false || ListStack.Contains(stack_b) == false)
                return false;
            Constant.Constant.Swap<IStack>(ListStack, ListStack.FindIndex(x => x.Hashcode == stack.Hashcode), ListStack.FindIndex(x => x.Hashcode == stack_b.Hashcode));
            return true;
        }


        public INVENTORYCEFCOMMAND ConvertInventory(float money, int state) {
            INVENTORYCEFCOMMAND data = new INVENTORYCEFCOMMAND();

            data.hashcode = Hashcode;
            data.money = money;
            data.name = Name;
            data.stack_size = StackLimit;
            data.state = state;
            data.list_stack = new List<STACKCEFCOMMAND>();

            for (int i = 0; i < StackLimit; i++) {
                if (ListStack[i] != null)
                {
                    dynamic tmp = Convert.ChangeType(ListStack[i], ListStack[i].CastType);
                    data.list_stack.Add(tmp.ConvertStack(i));
                }

            }
            return data;
        }

    }

    [JsonObject]
    public class Container : Inventory {
        public override Constant.Constant.InventoryHash Type { get => Constant.Constant.InventoryHash.CONTAIN; set => base.Type = value; }

        public Container() { SetDefault(); }

        public Container InstanceInventory() {

            for (int i = 0; i < ListStack.Count; i++) {
                var tmp = Activator.CreateInstance(ListStack[i].CastType);
                ListStack[i] = (IStack)tmp;
                GTANetworkAPI.NAPI.Util.ConsoleOutput(ListStack[i].ToString());
            }
            return this;
        }

        void SetDefault()
        {
            Name = "own inventory";
            Type = Constant.Constant.InventoryHash.PLAYER;
            StackLimit = 10;
            ListStack = new List<IStack>();
            for (int i = 0; i < StackLimit; i++)
                ListStack.Add(new Divers()
                {
                    Id = 424242,
                    Hashcode = (int)Constant.Crypton.GetNewHashcode(),
                });
        }
    }

    public class PlayerInventory : Inventory
    {
        public override Constant.Constant.InventoryHash Type { get => Constant.Constant.InventoryHash.PLAYER; set => base.Type = value; }

        public PlayerInventory() { SetDefault(); }

        public void SetClothListbyData(DUSER data) {
            if (ListStack[0].Id != 33)
                return;

            /*for (int i = 0; i < 10; i++) {
                ((Cloth)ListStack[0].ListItems[i]).component = data.cloth.body_cloth[i];
            }*/
        }

        public IStack MakerStackWithItem(IStack stack, List<Iitem> Item) {
            stack.ListItems = Item;
            if (Item.Count > 0)
                stack.Id = Item[0].Id;
            return stack;
        }

        public List<Iitem> BodyMaker() {
            List<Iitem> list = new List<Iitem>();
            list.Add(new Masque()
            {
                Hashcode = (int)Constant.Crypton.GetNewHashcode(),
            });
            list.Add(new Chapeau()
            {
                Hashcode = (int)Constant.Crypton.GetNewHashcode(),
            });
            list.Add(new EarRing()
            {
                Hashcode = (int)Constant.Crypton.GetNewHashcode(),
            });
            list.Add(new Jumelles()
            {
                Hashcode = (int)Constant.Crypton.GetNewHashcode(),
            });
            list.Add(new Cravatte()
            {
                Hashcode = (int)Constant.Crypton.GetNewHashcode(),
            });
            list.Add(new VesteSansManche()
            {
                Hashcode = (int)Constant.Crypton.GetNewHashcode(),
            });
            list.Add(new Veste()
            {
                Hashcode = (int)Constant.Crypton.GetNewHashcode(),
            });
            list.Add(new Pantalon()
            {
                Hashcode = (int)Constant.Crypton.GetNewHashcode(),
            });
            list.Add(new Basket()
            {
                Hashcode = (int)Constant.Crypton.GetNewHashcode(),
            });
            list.Add(new Bag()
            {
                Hashcode = (int)Constant.Crypton.GetNewHashcode(),
            });
            list.Add(new Gants()
            {
                Hashcode = (int)Constant.Crypton.GetNewHashcode(),
            });
            return list;
        }

        void SetDefault()
        {
            Name = "own inventory";
            Type = Constant.Constant.InventoryHash.PLAYER;
            StackLimit = 10;
            ListStack = new List<IStack>();

            ListStack.Add(MakerStackWithItem(new SBody()
            {
                ItemLimit = 10,
                Hashcode = (int)Constant.Crypton.GetNewHashcode(),
            }, BodyMaker()));

            ListStack.Add(MakerStackWithItem(new Wallet()
            {
                ItemLimit = 10,
                Hashcode = (int)Constant.Crypton.GetNewHashcode(),
            }, new List<Iitem>()));

            ListStack.Add(MakerStackWithItem(new Keyring()
            {
                ItemLimit = 10,
                Hashcode = (int)Constant.Crypton.GetNewHashcode(),
            }, new List<Iitem>()));

            for (int i = 3; i < StackLimit - 2; i++)
            {
                ListStack.Add(MakerStackWithItem(new Divers()
                {
                    ItemLimit = 10,
                    Hashcode = (int)Constant.Crypton.GetNewHashcode(),
                }, new List<Iitem>() {
                        new Burger(),
                        new Burger(),
                        new Burger(),
                        new Burger(),
                        new Burger(),
                }));


            }

            ListStack.Add(MakerStackWithItem(new Divers()
            {
                ItemLimit = 10,
                Hashcode = (int)Constant.Crypton.GetNewHashcode(),
            }, new List<Iitem>() {
                        new WaterBottle(),
                        new WaterBottle(),
                        new WaterBottle(),
                        new WaterBottle(),
                        new WaterBottle(),
                }));

            ListStack.Add(MakerStackWithItem(new Divers()
            {
                ItemLimit = 50,
                Hashcode = (int)Constant.Crypton.GetNewHashcode(),
            }, new List<Iitem>() {
                        new Billet(),
                        new Billet(),
                        new Billet(),
                        new Billet(),
                        new Billet(),
                        new Billet(),
                        new Billet(),
                        new Billet(),
                        new Billet(),
                        new Billet(),
                        new Billet(),
                        new Billet(),
                        new Billet(),
                        new Billet(),
                        new Billet(),
                        new Billet(),
                        new Billet(),
                }));

            /*ListStack.Add(tmp_stack = new SBody()
            {
                ItemLimit = 10,
                Hashcode = (int)Constant.Crypton.GetNewHashcode(),
            });
            for (int i = 0; i < 10; i++)
            {
                tmp_stack.ListItems.Add(new Basket()
                {
                    Hashcode = (int)Constant.Crypton.GetNewHashcode(),
                });
            }
            ListStack.Add(tmp_stack = new Wallet()
            {
                ItemLimit = 10,
                Hashcode = (int)Constant.Crypton.GetNewHashcode(),
            });
            
            tmp_stack.ListItems.Add(tmp_item = new PassPort() { });
            
            ListStack.Add(tmp_stack = new Keyring()
            {
                ItemLimit = 10,
                Hashcode = (int)Constant.Crypton.GetNewHashcode(),
            });

            Divers stack = null;
            for (int j = 3; j < StackLimit - 1; j++) { 
                
                stack = new Divers()
                {
                    Id = 0,
                    Hashcode = (int)Constant.Crypton.GetNewHashcode(),
                    ItemLimit = 100,
                };
                
                for (int i = 0; i < 100; i++)
                {
                    stack.ListItems.Add(new Item.Billet()
                    {
                        Id = 0,
                        Hashcode = (int)Constant.Crypton.GetNewHashcode(),
                    });
                    
                }
                ListStack.Add(stack);
            }
            
            stack = new Divers()
            {
                Id = 7,
                Hashcode = (int)Constant.Crypton.GetNewHashcode(),
                ItemLimit = 10,
            };
            
            for (int i = 0; i < 10; i++)
            {
                stack.ListItems.Add(new Item.Clope()
                {
                    Hashcode = (int)Constant.Crypton.GetNewHashcode(),
                });
                
            }
            ListStack.Add(stack);*/
        }
    }
}
