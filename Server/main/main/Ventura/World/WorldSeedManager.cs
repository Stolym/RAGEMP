using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using main.Ventura.Stream;
using main.Ventura.Constant;
using main.Ventura.Engine.Item;
using main.Ventura.Engine.Stack;
using FAPI = main.Ventura.Database.Formatter.Formatter;
using CGAPI = main.Ventura.Gestion.CharacterGestion;
using DUSER = main.Ventura.Database.DataUser;

namespace main.Ventura.World
{
    class WorldSeedManager : Script
    {
        /*
         * Seed Manager
         * You can set on map Plant
         * And gather
         * 
         * 
         * */

        /*
         * Farm or Plant
         * 
         * */


        public WorldSeedManager()
        {
            if (instance == null)
                instance = this;
        }

        public static WorldSeedManager instance = null;
        public List<Ventura.Stream.StreamData.WorldSeedData> SeedList = new List<Stream.StreamData.WorldSeedData>();
        private uint ihash = 0x000000A3;


        //public List<main.Ventura.Engine.Item.Item> item_list = new List<main.Ventura.Engine.Item.Item>();

        // AddItemInWorld
        // AddStackInWorld
        // RemoveItemInWorld
        // RemoveStackInWorld

        private float Fractor = 2f;

        public uint SearchIHash()
        {
            while (SeedList.Find(x => x.HashCode == ihash) != null) { ihash++; }
            return (ihash);
        }


        public void SetEvolvePlant(Stream.StreamData.WorldSeedData seed) {

            switch (seed.Step) {
                case 0:
                    seed.Name = "";
                    seed.Step++;
                    break;
                case 1:
                    seed.Name = "";
                    seed.Step++;
                    break;
                case 2:
                    seed.Name = "";
                    seed.Step++;
                    break;
            }
            AllStreamInWorld();
        }

        [ServerEvent(Event.Update)]
        public void Tick()
        {
            for (int i = 0; i < SeedList.Count; i++) {
                if (DateTime.Now.Ticks >= SeedList[i].NextTick) {
                    SetEvolvePlant(SeedList[i]);
                }
            }
        }

        [RemoteEvent("FarmPlant")]
        public void FarmPlantInWorld(Client client, object[] args) {
            byte[] buffer = (byte[])args[0];
            Stream.StreamData.WorldSeedData seed = FAPI.DeserializeObject<Stream.StreamData.WorldSeedData>(buffer);

            if (seed == null || buffer == null)
            {
                NAPI.Util.ConsoleOutput("Seed not received correctly");
                return;
            }
            var data = SeedList.Find(x => x.HashCode == seed.HashCode);

            if (data == null) {
                NAPI.Util.ConsoleOutput("Seed not exist in seed list");
                return;
            }
            // Farm Section Code


            SeedList.Remove(data);
            AllStreamInWorld();
        }

        public void AddPlantInWorld(Client client, Iitem item)
        {
            Vector3 NewPos = new Vector3(client.Position.X + Math.Cos(client.Heading) * Fractor, client.Position.Y + Math.Sin(client.Heading) * Fractor, client.Position.Z);

            Ventura.Stream.StreamData.WorldSeedData newSeed = new Stream.StreamData.WorldSeedData()
            {
                Id = item.Id,
                Name = item.ModelName,
                HashCode = SearchIHash(),
                LocalId = 0,
                RemoteId = client.Handle.Value,
                Dimensions = Convert.ToInt32(client.Dimension),
                Type = Constant.Constants.UpdateFlags.WorldSeedData,
                IsActive = true,
                Position = new Stream.StreamData.ZFVector3(NewPos.X, NewPos.Y, NewPos.Z),
            };
            SeedList.Add(newSeed);
            AllStreamInWorld();
        }
        
      
        public void OneStreamInWorld(Client player)
        {
            player.TriggerEvent("UpdateListWorldSeed", FAPI.SerializeObject(SeedList));
        }

        public void AllStreamInWorld()
        {
            foreach (Client client in NAPI.Pools.GetAllPlayers())
            {
                client.TriggerEvent("UpdateListWorldSeed", FAPI.SerializeObject(SeedList));
            }
        }
    }
}
