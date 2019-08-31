using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
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
using main.Ventura.Stream;
using main.Ventura.Constant;
using FAPI = main.Ventura.Database.Formatter.Formatter;

namespace main.Ventura.Engine.Inventory
{
    class EventInventory : Script
    {
        /*
         *  SenderInventory == Send Inventory to Client Browser With Maker Json
         * 
         *  
         * 
         * 
         * 
         * */

        public static EventInventory instance = null;
        public uint Hashcode = 0x000AAAA;


        public EventInventory() {
            if (instance == null)
                instance = this;
        }


        private void UseStack(Client client, STACKCEFCOMMAND data)
        {
            DUSER user = CGAPI.GetDataPlayer(client);

            if (user == null)
                return;
            IStack selected_stack = user.inventory.ListStack.Find(x => x.Hashcode == data.hashcode);
            if (selected_stack == null)
                return;
            selected_stack.UseItemInStack(ref selected_stack , ref user);
            /*switch (selected_stack.id) {
                case 0:
                    user.information.ActualMoney += selected_stack.items_list.Count;
                    user.inventory.list_stack[user.inventory.list_stack.FindIndex(x => x.hashcode == data.hashcode)] = new Divers() {
                        id = 424242,
                        hashcode = Hashcode
                    };
                    Hashcode++;
                    break;
                case 35:
                    NAPI.Util.ConsoleOutput(JsonConvert.SerializeObject(((Cloth)user.inventory.list_stack[user.inventory.list_stack.FindIndex(x => x.hashcode == data.hashcode)].items_list[0])));
                    user.cloth.body_cloth[6] = ((Cloth)user.inventory.list_stack[user.inventory.list_stack.FindIndex(x => x.hashcode == data.hashcode)].items_list[0]).component;
                    user.inventory.list_stack[user.inventory.list_stack.FindIndex(x => x.hashcode == data.hashcode)] = new Divers()
                    {
                        id = 424242,
                        hashcode = Hashcode
                    };
                    Hashcode++;

                    user.inventory.SetClothListbyData(user);
                    Synchronization.StreamGestionAsync.instance.UltimeAsync(client, FAPI.SerializeObjectJson<Stream.StreamData.WorldClothData>(new Stream.StreamData.WorldClothData()
                    {
                        Id = 0,
                        Name = "",
                        LocalId = 0,
                        RemoteId = client.Handle.Value,
                        Type = Constants.UpdateFlags.WorldClothData,
                        Dimensions = (int)client.Dimension,
                        cloth = user.cloth.body_cloth,
                        IsService = user.user.service,
                    }), main.Ventura.Constant.Constants.StreamFlags.StreamDimensionsIn, main.Ventura.Constant.Constants.UpdateFlags.WorldClothData, 0, client.Dimension);


                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    user.inventory.list_stack[user.inventory.list_stack.FindIndex(x => x.hashcode == data.hashcode)] = new Divers()
                    {
                        id = 424242,
                        hashcode = Hashcode
                    };
                    Hashcode++;
                    Synchronization.StreamGestionAsync.instance.UltimeAsync(client, FAPI.SerializeObjectJson<Stream.StreamData.WorldAnimationData>(new Stream.StreamData.WorldAnimationData()
                    {
                        IsActive = true,
                        Dict = "amb@world_human_smoking@female@base",
                        Anim = "base",
                        Speed = 1f,
                        SpeedMultiplier = 1f,
                        Id = user.anim.Id,
                        Name = user.anim.Name,
                        RemoteId = client.Handle.Value,
                        Dimensions = (int)client.Dimension,
                        Type = user.anim.Type,
                        Flags = (int)(Constants.AnimationFlags.Loop),
                        Duration = -1,
                        LockX = user.anim.LockX,
                        LockY = user.anim.LockY,
                        LockZ = user.anim.LockZ,
                        Playback = user.anim.Playback,
                    }), main.Ventura.Constant.Constants.StreamFlags.StreamDimensionsIn, main.Ventura.Constant.Constants.UpdateFlags.WorldAnimationData, 0, client.Dimension);

                    Synchronization.StreamGestionAsync.instance.UltimeAsync(client, FAPI.SerializeObjectJson<Stream.StreamData.WorldAttachData>(new Stream.StreamData.WorldAttachData()
                    {
                        Name = selected_stack.items_list[0].model_name,
                        Type = user.attach.Type,
                        Bone = 28422,
                        IsNetwork = user.attach.IsNetwork,
                        IsDynamic = user.attach.IsDynamic,
                        Position = user.attach.Position,
                        Rotation = user.attach.Rotation,
                        VertexIndex = 2,
                        P9 = false,
                        UseSoftPinning = false,
                        IsPed = false,
                        Collision = false,
                        LockRotation = true,
                    }), main.Ventura.Constant.Constants.StreamFlags.StreamDimensionsIn, main.Ventura.Constant.Constants.UpdateFlags.WorldAttachData, 0, client.Dimension);
                    break;
                case 8:
                    break;
                case 9:
                    break;
                case 10:
                    break;
            }*/
            client.TriggerEvent("ReceiveCommandInventory", JsonConvert.SerializeObject(user.inventory.ConvertInventory(user.information.ActualMoney, 1)));
        }


        private void DropStack(Client client, STACKCEFCOMMAND data)
        {
            DUSER user = CGAPI.GetDataPlayer(client);

            if (user == null)
                return;
            IStack selected_stack = user.inventory.ListStack.Find(x => x.Hashcode == data.hashcode);
            if (selected_stack == null)
                return;
            user.inventory.ListStack[user.inventory.ListStack.FindIndex(x => x.Hashcode == data.hashcode)] = new Divers()
            {
                Id = 424242,
                Hashcode = (int)Constant.Crypton.GetNewHashcode()
            };
            World.WorldItemManager.instance.AddStackInWorld(client, selected_stack);
            client.TriggerEvent("ReceiveCommandInventory", JsonConvert.SerializeObject(user.inventory.ConvertInventory(user.information.ActualMoney, 1)));
        }


        private void ClothStackGestion(Client client, ITEMCEFCOMMAND data)
        {
            DUSER user = CGAPI.GetDataPlayer(client);
            List<int> p = null;
            
            if (user == null)
                return;
            Iitem slected_item = user.inventory.ListStack[0].ListItems.Find(x => x.Hashcode == data.hashcode);
            if (slected_item == null)
                return;
            switch (user.inventory.ListStack[0].ListItems.FindIndex(x => x.Hashcode == data.hashcode)) {
                case 6:
                    p = user.cloth.body_cloth[user.inventory.ListStack[0].ListItems.FindIndex(x => x.Hashcode == data.hashcode)];
                    user.cloth.body_cloth[user.inventory.ListStack[0].ListItems.FindIndex(x => x.Hashcode == data.hashcode)] = new List<int> { 34, 0 };
                    break;
            }
            user.inventory.SetClothListbyData(user);
            //user.inventory.ListStack[0].ListItems[user.inventory.ListStack[0].ListItems.FindIndex(x => x.Hashcode == data.hashcode)] = new Cloth() { hashcode = Hashcode };
            /*Hashcode++;
            user.inventory.AddItemInBestStack(new Cloth { hashcode = Hashcode, component = p });
            Hashcode++;*/



            Synchronization.StreamGestionAsync.instance.UltimeAsync(client, FAPI.SerializeObjectJson<Stream.StreamData.WorldClothData>(new Stream.StreamData.WorldClothData()
            {
                Id = 0,
                Name = "",
                LocalId = 0,
                RemoteId = client.Handle.Value,
                Type = Constants.UpdateFlags.WorldClothData,
                Dimensions = client.Dimension,
                cloth = user.cloth.body_cloth,
                IsService = user.user.service,
            }), main.Ventura.Constant.Constants.StreamFlags.StreamDimensionsIn, main.Ventura.Constant.Constants.UpdateFlags.WorldClothData, 0, client.Dimension);


            client.TriggerEvent("ReceiveCommandInventory", JsonConvert.SerializeObject(user.inventory.ConvertInventory(user.information.ActualMoney, 1)));
        }

        [RemoteEvent("CEFCommandInventory")]
        public void CEFCommandInventory(Client client, string json, int flag)
        {
            STACKCEFCOMMAND sdata = null;
            ITEMCEFCOMMAND idata = null;
            try
            {
                sdata = JsonConvert.DeserializeObject<STACKCEFCOMMAND>(json);
            }
            catch (Exception ex) { }
            try
            {
                idata = JsonConvert.DeserializeObject<ITEMCEFCOMMAND>(json);
            }
            catch (Exception ex) { }
            

            switch (flag) {
                case 0:
                    UseStack(client, sdata);
                    break;
                case 1:
                    DropStack(client, sdata);
                    break;
                case 4:
                    ClothStackGestion(client, idata);
                    break;
            }
        }

        [RemoteEvent("SenderInventory")]
        public void SenderInventory(Client client, int mode, uint remote) {
            DUSER data = CGAPI.GetDataPlayer(client);
            Vehicle veh = NAPI.Pools.GetAllVehicles().Find(x => x.Handle.Value == remote);


            if (data == null && veh.GetSharedData("StreamVehicleData") != null)
                return;
            switch (mode) {
                case 0:
                    client.TriggerEvent("ReceiveCommandInventory", JsonConvert.SerializeObject(new List<INVENTORYCEFCOMMAND>() {
                        data.inventory.ConvertInventory(data.information.ActualMoney, 1)
                    }));
                    break;
                case 1:
                    NAPI.Util.ConsoleOutput((string)veh.GetSharedData("StreamVehicleData"));
                    var tmp = JsonConvert.DeserializeObject<Stream.StreamData.WorldVehicleData>((string)veh.GetSharedData("StreamVehicleData")).contain;
                    NAPI.Util.ConsoleOutput(tmp.ToString());
                    client.TriggerEvent("ReceiveCommandInventory", JsonConvert.SerializeObject(new List<INVENTORYCEFCOMMAND>() {
                        data.inventory.ConvertInventory(data.information.ActualMoney, 1),
                        tmp.ConvertInventory(0, 0),
                    })); ;
                    break;
            }
        }
        

    }


    /*
     * 
     * 
var item_a = {
    id: 0,
    hashcode: 0x02AB77A1,
    description: "",
};

var stack_a = {
    id: 0,
    limit: 10,
    list_item: [item_a, item_a, item_a, item_a, item_a, item_a],
    x: 3,
    hashcode: 0x1F3A57A8,
};

     * 
     * var matrix_a = {
    name: "Own Inventory",
    state: 1,
    money: 2000,
    stack_size: 10,
    list_stack: [stack_a, stack_b],
    hashcode: 0x02AB5138,
};*/

        
    [JsonObject]
    public class ITEMCEFCOMMAND
    {
        public int id { get; set; }
        public long hashcode { get; set; }
        public string description { get; set; }
        public int[] component { get; set; }

    }

    [JsonObject]
    public class STACKCEFCOMMAND
    {
        public int id { get; set; }
        public int limit { get; set; }
        public int state { get; set; }
        public List<ITEMCEFCOMMAND> list_item;
        public int x { get; set; }
        public long hashcode { get; set; }
    }


    [JsonObject]
    public class BODYCEFCOMMAND
    {
        public int id { get; set; }
        /*public int limit { get; set; }
        public int state { get; set; }
        public List<ITEMCEFCOMMAND> list_stack;
        public int x { get; set; }
        public uint hashcode { get; set; }*/
    }

    [JsonObject]
    public class INVENTORYCEFCOMMAND
    {
        public string name { get; set; }
        public int state { get; set; }
        public float money { get; set; }
        public int stack_size { get; set; }

        public List<STACKCEFCOMMAND> list_stack;
        public long hashcode { get; set; }

    }

}
