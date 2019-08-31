using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using GTANetworkAPI;
using main.Ventura.Engine.Item;
using main.Ventura.Engine.Stack;

using FAPI = main.Ventura.Database.Formatter.Formatter;

namespace main.Ventura.World
{
    class WorldItemManager : Script
    {
        /*
         * Item Manager
         * You can drop item or stack in world and other players can see him
         * 
         * Exemple : Drop Item
         *  WorldObjectSync Protect Data Sync
         *  Item or Stack get by hashcode see if object wasn't modify
         *  if yes
         *  Ban Player for cheat
         *  else
         *  Take Object
         * 
         * */

        /*
         * Take or Drop
         * 
         * */
         

        public WorldItemManager() {
            if (instance == null)
                instance = this;
        }

        public static WorldItemManager instance = null;
        public List<Ventura.Stream.StreamData.WorldObjectData> WorldList = new List<Stream.StreamData.WorldObjectData>();
        public List<Ventura.Engine.Stack.IStack> StackWorldList = new List<Engine.Stack.IStack>();
        public List<Ventura.Engine.Item.Iitem> ItemWorldList = new List<Engine.Item.Iitem>();
        private uint ihash = 0x000000A3;


        //public List<main.Ventura.Engine.Item.Item> item_list = new List<main.Ventura.Engine.Item.Item>();

        // AddItemInWorld
        // AddStackInWorld
        // RemoveItemInWorld
        // RemoveStackInWorld

        private float Fractor = 2f;

        public uint SearchIHash() {
            while (ItemWorldList.Find(x => x.Hashcode == ihash) != null ||
                StackWorldList.Find(x => x.Hashcode == ihash) != null ||
                WorldList.Find(x => x.HashCode == ihash) != null
                ) { ihash++; }
            return (ihash);
        }

        public void AddItemInWorld(Client client, Iitem item)
        {
            if (ItemWorldList.Contains(item))
            {
                NAPI.Util.ConsoleOutput("Drop item already dropped " + item.Hashcode);
                return;
            }
            ItemWorldList.Add(item);
            Vector3 NewPos = new Vector3(client.Position.X + Math.Cos(client.Heading) * Fractor, client.Position.Y + Math.Sin(client.Heading) * Fractor, client.Position.Z);

            Ventura.Stream.StreamData.WorldObjectData newObject = new Stream.StreamData.WorldObjectData()
            {
                Id = item.Id,
                Name = item.ModelName,
                HashCode = SearchIHash(),
                LocalId = 0,
                RemoteId = client.Handle.Value,
                Dimensions = client.Dimension,
                Type = Constant.Constants.UpdateFlags.WorldObjectData,
                ObjectType = Engine.Constant.Constant.StructInventoryHash.ITEM,
                IsActive = true,
                Position = new Stream.StreamData.ZFVector3(NewPos.X, NewPos.Y, NewPos.Z),
            };
            WorldList.Add(newObject);
            AllStreamInWorld();
        }


        public void AddStackInWorld(Client client, IStack stack)
        {
            if (StackWorldList.Contains(stack))
            {
                NAPI.Util.ConsoleOutput("Drop stack already dropped " + stack.Hashcode);
                return;
            }
            StackWorldList.Add(stack);
            //Vector3 NewPos = new Vector3(client.Position.X + Math.Cos(client.Heading) * Fractor, client.Position.Y + Math.Sin(client.Heading) * Fractor, client.Position.Z);
            Vector3 NewPos = new Vector3(client.Position.X, client.Position.Y, client.Position.Z);


            if (stack.ListItems[0] == null)
                return;

            Ventura.Stream.StreamData.WorldObjectData newObject = new Stream.StreamData.WorldObjectData()
            {
                Id = stack.ListItems[0].Id,
                Name = stack.ListItems[0].ModelName,
                HashCode = stack.Hashcode,
                LocalId = 0,
                RemoteId = client.Handle.Value,
                Dimensions = client.Dimension,
                Type = Constant.Constants.UpdateFlags.WorldObjectData,
                ObjectType = Engine.Constant.Constant.StructInventoryHash.STACK,
                IsActive = true,
                Position = new Stream.StreamData.ZFVector3(NewPos.X, NewPos.Y, NewPos.Z),
            };
            WorldList.Add(newObject);
            NAPI.Util.ConsoleOutput(FAPI.SerializeObjectJson<Stream.StreamData.WorldObjectData>(newObject));

            AllStreamInWorld();
        }

        [RemoteEvent("TakeObject")]
        public void TakeObject(Client client, object[] args) {
            byte[] buffer = (byte[])args[0];
            
            Ventura.Stream.StreamData.WorldObjectData obj = FAPI.DeserializeObject<Stream.StreamData.WorldObjectData>(buffer);
            
            if (!WorldList.Contains(obj) || (ItemWorldList.Find(x => x.Hashcode == obj.HashCode) == null && StackWorldList.Find(x => x.Hashcode == obj.HashCode) == null)) {
                NAPI.Util.ConsoleOutput("Object already took " + obj.HashCode);
                return;
            }
            switch (obj.ObjectType)
            {
                case Engine.Constant.Constant.StructInventoryHash.STACK:
                    RemoveStackInWorld(obj, StackWorldList.Find(x => x.ListItems[0].Hashcode == obj.HashCode));
                    break;
                case Engine.Constant.Constant.StructInventoryHash.ITEM:
                    RemoveItemInWorld(obj, ItemWorldList.Find(x => x.Hashcode == obj.HashCode));
                    break;
                case Engine.Constant.Constant.StructInventoryHash.INVENTORY:
                    break;
            }
        }
        
        public void RemoveItemInWorld(Stream.StreamData.WorldObjectData obj, Iitem item)
        {
            if (WorldList.Contains(obj))
                WorldList.Remove(obj);
            if (ItemWorldList.Contains(item))
                ItemWorldList.Remove(item);
            AllStreamInWorld();
        }
        
        public void RemoveStackInWorld(Stream.StreamData.WorldObjectData obj, IStack stack)
        {
            if (WorldList.Contains(obj))
                WorldList.Remove(obj);
            if (StackWorldList.Contains(stack))
                StackWorldList.Remove(stack);
            AllStreamInWorld();
        }
        
        public void OneStreamInWorld(Client player)
        {
            player.TriggerEvent("UpdateListWorldItem", FAPI.SerializeObjectJson(WorldList));
        }

        public void AllStreamInWorld()
        {
            foreach (Client client in NAPI.Pools.GetAllPlayers())
            {
                client.TriggerEvent("UpdateListObjectWorld", FAPI.SerializeObjectJson(WorldList));
            }
        }
    }
}
