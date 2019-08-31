using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using GTANetworkAPI;
using main.Ventura.Stream.StreamData;
using main.Ventura.Constant;
using DUSER = main.Ventura.Database.DataUser;
using LAPI = main.Ventura.Gestion.LogGestion;
using CGAPI = main.Ventura.Gestion.CharacterGestion;
using FAPI = main.Ventura.Database.Formatter.Formatter;
using DAPI = main.Ventura.Gestion.DimensionGestion;
using ASAPI = main.Ventura.Stream.Async.Event.AsyncEvent;

namespace main
{
    class Commands : Script
    {
        private Vehicle veh;


        [Command("connect_ts")]
        public void connectTS(Client client)
        {
            //Ventura.Engine.Vocal.Vocal.instance.Connect(client, client.SocialClubName);
        }


        [Command("ped")]
        public void UpdatePed(Client client)
        {
            client.TriggerEvent("UpdatePedSharedData", FAPI.SerializeObjectJson<List<Ventura.Stream.StreamData.WorldPedData>>(Ventura.World.WorldPedManager.worldPedDatas));
        }

        [Command("unped")]
        public void UpdateUnPed(Client client)
        {
            client.TriggerEvent("UpdatePedSharedData", FAPI.SerializeObjectJson<List<Ventura.Stream.StreamData.WorldPedData>>(new List<Ventura.Stream.StreamData.WorldPedData>()));
        }

        [Command("task")]
        public void Task(Client client, int a, int b, int c, int d)
        {
            client.TriggerEvent("TestTask", a, b, c, d);
        }

        [Command("ctask")]
        public void CTask(Client client, int a)
        {
            client.TriggerEvent("ClearTask", a);
        }

        [Command("seat")]
        public void seat_vehicule(Client player, int c)
        {
            if (veh != null)
                player.SetIntoVehicle(veh.Handle, c);
        }


        [Command("weapon")]
        public void weapon_pos(Client player)
        {
            player.GiveWeapon(WeaponHash.Bat, 100);
            player.GiveWeapon(WeaponHash.Pistol, 100);
        }

        [Command("tp")]
        public void tp(Client sender, float x, float y, float z)
        {
            sender.Position = new Vector3(x, y, z);
        }


        [Command("pos")]
        public void print_pos(Client player)
        {
            NAPI.Chat.SendChatMessageToPlayer(player, player.Position.ToString() + " " + player.Heading.ToString());
            NAPI.Util.ConsoleOutput(player.Position.ToString() + " " + player.Heading.ToString());
            //RWAPI.write_line_in_file("./data/pos.txt", );
        }


        int nbr = 0;

        [RemoteEvent("Utils")]
        public void Utils(Client player, string m) {
            NAPI.Util.ConsoleOutput(m);
        }

        [Command("vehicle")]
        public void vehicle(Client player, string name)
        {

            for (int j = 0; j < 50; j++)
            {
                veh = NAPI.Vehicle.CreateVehicle(NAPI.Util.GetHashKey(name), player.Position.Around(5f), 0, 0, 0);

                Random rand = new Random();

                WorldVehicleData data = new WorldVehicleData();
                data.SetDefault();
                data.Id = NAPI.Pools.GetAllVehicles().Count;
                data.Colour1 = rand.Next(0, 30);
                data.Colour2 = rand.Next(0, 30);
                data.DoorControl.Add(rand.Next(0, 3) >= 2 ? true : false);
                data.DoorControl.Add(rand.Next(0, 3) >= 2 ? true : false);
                data.DoorControl.Add(rand.Next(0, 3) >= 2 ? true : false);
                data.DoorControl.Add(rand.Next(0, 3) >= 2 ? true : false);
                data.RemoteId = veh.Handle.Value;
                data.IsLock = false;
                data.IsOn = false;
                for (int i = 0; i < 50; i++)
                    data.ModIndex.Add(rand.Next(0, 10));

                data.contain.Name = "Closest Vehicle";

                Synchronization.StreamGestionAsync.instance.UltimeAsync(veh, FAPI.SerializeObjectJson<WorldVehicleData>(data), Constants.StreamFlags.StreamIn, Constants.UpdateFlags.WorldVehiculeData, 0, player.Dimension);
                nbr++;
            }
            NAPI.Util.ConsoleOutput("Number vehicle " + nbr);

            //Random rand = new Random();

            /*tmp.SetSharedData("StreamInVehicle", JsonConvert.SerializeObject(new Synchronization.SyncVehicleData(0, tmp)
            {
                IsLock = false,
                IsOn = true,
                IsDrivable = true,
                IsBoost = false,
                IsBootOpen = false,
                Heading = 0,
                BodyHealth = 1000,
                EngineHealth = 1000,
                AllowNoPassengers = false,
                Colour1 = rand.Next(0, 10),
                Colour2 = rand.Next(0, 10),
                ColourCombination = rand.Next(0, 10),
                Dcolour = rand.Next(0, 10),
                DirtLevel = (float)rand.NextDouble(),
                Extra = new bool[] { true, false, true },
                IndicatorLight = rand.Next(0, 10),
                InteriorColor = rand.Next(0, 10),
                InteriorLight = true,
                LightState = rand.Next(0, 2),
                Name = name,
                NeonLight = true,
                NumberPlate = "VENTURA",
                NumberPlateIndex = 3,
                WindowTint = rand.Next(0, 10),
                Pcolour1 = rand.Next(0, 10),
                Pcolour2 = rand.Next(0, 10),
                WheelType = rand.Next(0, 10),
                WheelColor = rand.Next(0, 10),
                x = tmp.Position.X,
                y = tmp.Position.Y,
                z = tmp.Position.Z,
            }));*/
        }
    }

    /*class Commands : Script
    {
        private Vehicle tmp = null;


        [RemoteEvent("reload_character")]
        public void character(Client client) {
            UAPI.update_skin(client);
        }

        [RemoteEvent("AddItemUser")]
        public void AddItemUser(Client client, string name) {
            Random random = new Random();
            switch (name)
            {
                case "Clope":
                    CMAPI.get_data_player(client).inventory.add_matrix_item_in_stack_with_params(new Item.Clope() { Id = random.Next(0, 2147483647) });
                    break;
                case "Sim":
                    CMAPI.get_data_player(client).inventory.add_matrix_item_in_stack_with_params(new Item.Sim() { Id = random.Next(0, 2147483647) });
                    break;
                case "Burger":
                    CMAPI.get_data_player(client).inventory.add_matrix_item_in_stack_with_params(new Item.Burger() { Id = random.Next(0, 2147483647) });
                    break;
                case "Water":
                    CMAPI.get_data_player(client).inventory.add_matrix_item_in_stack_with_params(new Item.Water() { Id = random.Next(0, 2147483647) });
                    break;
                case "Phone":
                    CMAPI.get_data_player(client).inventory.add_matrix_item_in_stack_with_params(new Item.Phone() { Id = random.Next(0, 2147483647) });
                    break;
            }
        }

        [Command("make_scene")]
        public void make_scene(Client client)
        {
            NAPI.ClientEvent.TriggerClientEventForAll("MakeScene");
            //client.TriggerEvent("MakeScene");
        }


        [Command("make_dead")]
        public void make_dead(Client client)
        {
            NAPI.ClientEvent.TriggerClientEventForAll("InBoot");
            //client.TriggerEvent("InBoot");
        }

        [Command("use_item")]
        public void UseItem(Client client, int istack, int used = 1)
        {
            if (CMAPI.get_data_player(client) != null)
            {
                var inv = CMAPI.get_data_player(client).inventory;

                for (int i = 0; i < inv.list_stack.Count; i++)
                {
                    if (i == istack && inv.list_stack[i].items_list.Count > 0)
                    {
                        for (int j = 0; j < used; j++)
                        {
                            if (j >= inv.list_stack[i].items_list.Count)
                                break;
                            NAPI.Chat.SendChatMessageToPlayer(client, "Debug " + inv.list_stack[i].Type + " Size " + inv.list_stack[i].items_list.Count);
                            inv.list_stack[i].items_list[0].UseFunction(client);
                            inv.list_stack[i].items_list.Remove(inv.list_stack[i].items_list[0]);
                        }
                    }
                }
            }
        }

        [Command("drop_item")]
        public void DropItem(Client client, int istack)
        {
            if (CMAPI.get_data_player(client) != null)
            {
                var inv = CMAPI.get_data_player(client).inventory;

                for (int i = 0; i < inv.list_stack.Count; i++)
                {
                    if (i == istack)
                    {
                        NAPI.Chat.SendChatMessageToPlayer(client, "Debug " + inv.list_stack[i].Type + " Size " + inv.list_stack[i].items_list.Count);
                        inv.list_stack[i].items_list[0].DropFunction(client);
                        inv.list_stack[i].items_list.Remove(inv.list_stack[i].items_list[0]);
                    }
                }
            }
        }

        [Command("print_inventory")]
        public void PrintInventory(Client client, int istack) {
            if (CMAPI.get_data_player(client) != null)
            {
                var inv = CMAPI.get_data_player(client).inventory;

                for (int i = 0; i < inv.list_stack.Count; i++)
                {
                    if (i == istack || istack == -1)
                    {
                        NAPI.Chat.SendChatMessageToPlayer(client, "Debug " + inv.list_stack[i].Type + " Size " + inv.list_stack[i].items_list.Count);
                        foreach (var item in inv.list_stack[i].items_list)
                        {
                            NAPI.Chat.SendChatMessageToPlayer(client, "Debug " + item.Type + " id " + item.Id + " name " + item.name + " mname " + item.model_name);
                        }
                    }
                }
            }
        }

        [Command("texture")]
        public void texture(Client client, int t) {
            client.SetClothes(0, 11, t);
        }

        [Command("lolol")]
        public void lolol(Client client) {
            RWAPI.clear_file("./data/Vehicle/vehicleData.txt");
            foreach (Vehicle v in NAPI.Pools.GetAllVehicles())
            {
                var data = v.GetSharedData("StreamInVehicle");
                if (data == null)
                    continue;
                RWAPI.write_line_in_file("./data/Vehicle/vehicleData.txt", JsonConvert.SerializeObject(data));
            }
            foreach (Client c in NAPI.Pools.GetAllPlayers())
            {
                if (CMAPI.get_data_player(c) != null)
                {
                    CMAPI.get_data_player(c).info.pos = new Database.Vector3() { x = c.Position.X, y = c.Position.Y, z = c.Position.Z };
                    if (SQLAPI.get_data_player(c) == null)
                        SQLAPI.register_data_player(c, CMAPI.get_data_player(c));
                    else
                        SQLAPI.update_data_player(c, CMAPI.get_data_player(c));
                }
            }
        }

        [Command("pos")]
        public void print_pos(Client player)
        {
            NAPI.Chat.SendChatMessageToPlayer(player, player.Position.ToString() + " " + player.Heading.ToString());
            //RWAPI.write_line_in_file("./data/pos.txt", );
        }


        [Command("cpos")]
        public void print_pos(Client player, string name)
        {
            NAPI.Chat.SendChatMessageToPlayer(player, player.Position.ToString() + " " + player.Heading.ToString());
            RWAPI.write_line_in_file("./data/pos.txt", name+" "+player.Position.ToString());
        }

        [Command("no_clip")]
        public void ActiveNoClip(Client client, int i) {
            client.TriggerEvent("ActiveNoclip", i);
        }

        [Command("money")]
        public void update_money(Client player, float value = 0) {
            if (value != 0 && CMAPI.get_data_player(player) != null)
            {
                main.Bank.MoneyGestion.change_money(player, value);
            }
            if (CMAPI.get_data_player(player) != null)
                player.TriggerEvent("change_money_client", CMAPI.get_data_player(player).info.legal_money.ToString() + " $");
            //NAPI.Chat.SendChatMessageToPlayer(player, "Salut :", CMAPI.get_data_player(player).info.legal_money.ToString());
        }
        
        [Command("weapon")]
        public void weapon_pos(Client player) {
            player.GiveWeapon(WeaponHash.Pistol, 100);
        }

        [Command("active")]
        public void active_menu(Client player, bool tmp) {
            player.TriggerEvent("enable_menu_cloth", tmp);
        }

        [RemoteEvent("change_cloth")]
        void change_cloth(Client player, int a, int b, int c)
        {
            NAPI.Chat.SendChatMessageToPlayer(player, "Infomation slot " + a + " drawable " + b + " texture " + c + " Position "+player.Position.ToString());
            player.SetClothes(a, b, c);
        }

        [RemoteEvent("SpawnNewVehicule")]
        public void SpawnNewVehicule(Client player, string name)
        {
            NAPI.Util.ConsoleOutput("SpawnEvent "+name);
            tmp = NAPI.Vehicle.CreateVehicle(NAPI.Util.GetHashKey(name), player.Position.Around(5f), 0, 0, 0);

            Random rand = new Random();

            tmp.SetSharedData("StreamInVehicle", JsonConvert.SerializeObject(new Synchronization.SyncVehicleData(0, tmp)
            {
                IsLock = false,
                IsOn = true,
                IsDrivable = true,
                IsBoost = false,
                IsBootOpen = false,
                Heading = 0,
                BodyHealth = 1000,
                EngineHealth = 1000,
                AllowNoPassengers = false,
                Colour1 = rand.Next(0, 10),
                Colour2 = rand.Next(0, 10),
                ColourCombination = rand.Next(0, 10),
                Dcolour = rand.Next(0, 10),
                DirtLevel = (float)rand.NextDouble(),
                Extra = new bool[] { true, false, true },
                IndicatorLight = rand.Next(0, 10),
                InteriorColor = rand.Next(0, 10),
                InteriorLight = true,
                LightState = rand.Next(0, 2),
                Name = name,
                NeonLight = true,
                NumberPlate = "VENTURA",
                NumberPlateIndex = 3,
                WindowTint = rand.Next(0, 10),
                Pcolour1 = rand.Next(0, 10),
                Pcolour2 = rand.Next(0, 10),
                WheelType = rand.Next(0, 10),
                WheelColor = rand.Next(0, 10),
                x = tmp.Position.X,
                y = tmp.Position.Y,
                z = tmp.Position.Z,
            }));
        }

        [Command("vehicule")]
        public void gen_vehicule(Client player, string name)
        {
            tmp = NAPI.Vehicle.CreateVehicle(NAPI.Util.GetHashKey(name), player.Position.Around(5f), 0, 0, 0);

            Random rand = new Random();

            tmp.SetSharedData("StreamInVehicle", JsonConvert.SerializeObject(new Synchronization.SyncVehicleData(0, tmp)
            {
                IsLock = false,
                IsOn = true,
                IsDrivable = true,
                IsBoost = false,
                IsBootOpen = false,
                Heading = 0,
                BodyHealth = 1000,
                EngineHealth = 1000,
                AllowNoPassengers = false,
                Colour1 = rand.Next(0, 10),
                Colour2 = rand.Next(0, 10),
                ColourCombination = rand.Next(0, 10),
                Dcolour = rand.Next(0, 10),
                DirtLevel = (float)rand.NextDouble(),
                Extra = new bool[] { true, false, true },
                IndicatorLight = rand.Next(0, 10),
                InteriorColor = rand.Next(0, 10),
                InteriorLight = true,
                LightState = rand.Next(0, 2),
                Name = name,
                NeonLight = true,
                NumberPlate = "VENTURA",
                NumberPlateIndex = 3,
                WindowTint = rand.Next(0, 10),
                Pcolour1 = rand.Next(0, 10),
                Pcolour2 = rand.Next(0, 10),
                WheelType = rand.Next(0, 10),
                WheelColor = rand.Next(0, 10),
                x = tmp.Position.X,
                y = tmp.Position.Y,
                z = tmp.Position.Z,
            }));
        }

        [Command("seat")]
        public void seat_vehicule(Client player, int c) {
            if (tmp != null)
                player.SetIntoVehicle(tmp.Handle, c);
        }
        
        [Command("tp")]
        public void tp(Client sender, float x, float y, float z)
        {
            sender.Position = new Vector3(x, y, z);
        }

        GTANetworkAPI.Object tmpp = null;
        
        [Command("attach")]
        public void attach(Client player)
        {
            if (tmpp == null)
                tmpp = NAPI.Object.CreateObject(NAPI.Util.GetHashKey("prop_police_id_board"), player.Position, new Vector3(), 255, Manager.DimensionGestion.get_instance(player.SocialClubName));
            NAPI.ClientEvent.TriggerClientEventForAll("testAttach", player, tmpp);
            //player.TriggerEvent("test", tmpp);

            //NAPI.Entity.AttachEntityToEntity(tmp.Handle, player.Handle, "IK_Head", new Vector3(), new Vector3());
        }

        [Command("create_ped")]
        public void create_ped(Client player) {
            //NAPI.ClientEvent.TriggerClientEventInRange(player.Position, 120, "create_ped", player.Position);
            NAPI.ClientEvent.TriggerClientEvent(player, "create_ped", player.Position);
            //NAPI.Ped.CreatePed(PedHash.FreemodeFemale01, player.Position, 86.6f);
            //API.CreatePed(PedHash.FreemodeFemale01, player.Position, 86.6f);
            //API.CreatePed(PedHash.FreemodeFemale01, player.Position, 86.6f);
        }

        public GTANetworkAPI.Object tm = null;

        [Command("crd")]
        public void create_drop_object(Client client)
        {
            client.GiveWeapon(WeaponHash.AssaultShotgun, 1000);
            NAPI.ClientEvent.TriggerClientEventForAll("testAttach", client, tm);
            API.PlayPlayerAnimation(client, 0, "mp_weapon_drop", "drop_bh");

        }

        [Command("finger")]
        public void create_finger_object(Client client)
        {
            tm = NAPI.Object.CreateObject(NAPI.Util.GetHashKey("ng_proc_cigarette01a"), client.Position, new Vector3());
            NAPI.ClientEvent.TriggerClientEventForAll("testAttach", client, tm);
            //API.PlayPlayerAnimation(client, 0, "mp_weapon_drop", "drop_bh");

        }

        [Command("crde")]
        public void create_dr(Client client)
        {
            API.PlayPlayerAnimation(client, 0, "mp_weapon_drop", "drop_bh");
            client.RemoveWeapon(WeaponHash.AssaultShotgun);
            NAPI.Task.Run(() =>
            {
                tm = NAPI.Object.CreateObject(NAPI.Util.GetHashKey("w_sg_assaultshotgun"), client.Position + new Vector3(0, 1, -0.9f), new Vector3(90, 0, 0), 255, 0);
                client.TriggerEvent("physics_object", tm);
            }, 400);
        }

        [Command("del")]
        public void desd(Client client)
        {
            tm.Delete();
        }

        [Command("hud")]
        public void hud(Client client, int i)
        {
            client.TriggerEvent("desac_hud", i);
        }

        [RemoteEvent("TakeWeapon")]
        public void TakeWeapon(Client client) {
            API.PlayPlayerAnimation(client, 0, "mp_weapon_drop", "drop_bh");
            client.GiveWeapon(WeaponHash.AssaultShotgun, 1000);
            tm.Delete();
        }
        
        [Command("prop_info")]
        public void prop_info(Client client) {
            client.TriggerEvent("get_prop_info");
        }
        
        [RemoteEvent("client_created_ped")]
        public void client_created_ped(Client player, int ped) {
            NAPI.Util.ConsoleOutput("Passage Client Update "+ped);
            player.SetSharedData("client_update_ped", null);
        }

        [Command("falling")]
        public void falling(Client client)
        {
            NAPI.ClientEvent.TriggerClientEventInDimension(0, "TestFall", client.Handle.Value);
        }

        [Command("dama")]
        public void damage(Client client) {
            NAPI.ClientEvent.TriggerClientEventInDimension(0, "TestVehi", tmp.Handle.Value);
        }

        [Command("move_ped")]
        public void move_ped(Client player)
        {
            NAPI.ClientEvent.TriggerClientEvent(player, "move_ped", player.Position);
            //NAPI.ClientEvent.TriggerClientEventInRange(player.Position, 120, "move_ped", player.Position);
            //NAPI.Ped.CreatePed(PedHash.FreemodeFemale01, player.Position, 86.6f);
            //API.CreatePed(PedHash.FreemodeFemale01, player.Position, 86.6f);
            //API.CreatePed(PedHash.FreemodeFemale01, player.Position, 86.6f);
        }
        /*[Command("create_shop")]
        public void add_shop(Client sender) {
            API.CreatePed(PedHash.FreemodeFemale01, new Vector3(454.146f, -980.0009f, 30.6896f), 86.6f);

        }

        [Command("test_police")]
        public void test_police(Client sender)
        {
            sender.Position = new Vector3(452.146f, -980.0009f, 30.6896f);
            //NAPI.Ped.CreatePed(PedHash.FreemodeFemale01, new Vector3(454.146f, -980.0009f, 30.6896f), 86.6f);
            //API.CreatePed(PedHash.FreemodeFemale01, new Vector3(454.146f, -980.0009f, 30.6896f), 86.6f);
            //API.CreatePed(PedHash.FreemodeFemale01, new Vector3(454.146f, -980.0009f, 30.6896f), 86.6f);
            //tcl.PlayAnimation("mp_character_creation@customise@male_a", "profile_r_loop", true);
        }


        [Command("affichage")]
        public void affichage(Client sender, float x, float y, float z)
        {
            sender.Rotation = new Vector3(x, y, z);
            //sender.TriggerEvent("ShowLoginForm");
            //NAPI.ClientEvent.TriggerClientEvent(sender, "ShowLoginForm");
            sender.SendChatMessage("~y~Test Command c#");
        }

        [Command("pos")]
        public void pos(Client sender)
        {
            sender.TriggerEvent("get_prop_info");

        }

        [Command("tp")]
        public void tp(Client sender, float x, float y, float z)
        {
            sender.Position = new Vector3(x, y, z);
        }

        [RemoteEvent("show_pos_now")]
        public void show_pos_now(Client sender, float x, float y, float z)
        {
            sender.SendChatMessage("~y~Test Command c# "+x+" "+y+" "+z);
            //API.CreatePed(PedHash.Agent14, new Vector3(409.7778, -998.3335, -98.8), 0)->
            //NAPI.Ped.CreatePed(PedHash.FreemodeFemale01, sender.Position, sender.Heading);
        }


        public struct DoorInfo
        {
            public int Hash;
            public Vector3 Position;
            public int Id;

            public bool Locked;
            public float State;
        }

        [Command("oulou")]
        public void oulou(Client sender)
        {
            //ColShape colShape = NAPI.ColShape.CreateSphereColShape(sender.Position, 35f);
            GTANetworkAPI.Object tmp = NAPI.Object.CreateObject(NAPI.Util.GetHashKey("prop_police_door_l"), sender.Position, sender.Rotation);
            GTANetworkAPI.Ped ped = NAPI.Ped.CreatePed(PedHash.AfriAmer01AMM, sender.Position, sender.Heading);
            //NAPI.Marker.CreateMarker();
            //Scaleform tmpSFs = new Scaleform("PLAYER_NAME_02");
            //tmpSFs.CallFunction("SET_PLAYER_NAME", "Gang War");
            //tmpSFs.Render3D(marker_pos + new Vector3(0f, 0f, 0f), new Vector3(0f, 90f, Game.PlayerPed.Rotation.Z + 90f), new Vector3(12, 4, 3));
            //DrawMarker((int)MarkerType.VerticalCylinder, marker_pos.X, marker_pos.Y, marker_pos.Z - 2.1f, 0, 90, 0, 0, 0, 0, 3, 3, 1, 255, 255, 204, 255, false, false, 0, false, null, null, false);

            /*var info = new DoorInfo()
            {
                Hash = 1804626822,
                Position = sender.Position,
                Locked = false, // Open by default;
                Id = 0,
                State = 0
            };
            colShape.SetData("DOOR_INFO", info);
            colShape.SetData("DOOR_ID", 0);
            colShape.SetData("IS_DOOR_TRIGGER", true);
            //sender.SendChatMessage("oulou Event Call");
            //API.TriggerClientEvent(sender, "login_form", "package://main/views/index.html");
            //NAPI.Ped.CreatePed(PedHash.FreemodeFemale01, sender.Position, sender.Heading);
        }

        [Command("character")]
        public void character_intro(Client sender)
        {
            sender.SendChatMessage("character Event Call");
            API.TriggerClientEvent(sender, "CharacterIntro");
            API.TriggerClientEvent(sender, "PedPlate", "mp_character_creation@lineup@female_b", "intro", "Azkaban", " ", " ", " ", -1, 7000);
            //NAPI.Ped.CreatePed(PedHash.FreemodeFemale01, sender.Position, sender.Heading);
        }

        [Command("character_choose")]
        public void character_choose(Client sender, int c)
        {
            sender.SendChatMessage("character Event Call");
            API.TriggerClientEvent(sender, "CharacterChoose", c);
            //API.TriggerClientEvent(sender, "CharacterIntro");
            //NAPI.Ped.CreatePed(PedHash.FreemodeFemale01, sender.Position, sender.Heading);
        }


        [Command("update")]
        public void character_update(Client sender, int select)
        {
            sender.SendChatMessage("character Event Call");

            //sender.Position = new Vector3(406.2395f, -997.1383f, -99.00404f);
            API.TriggerClientEvent(sender, "PlayerPlate", "mp_character_creation@customise@male_a", "intro", "Azkaban", "Con", "jordan", "pute", 15, 7500);
            API.TriggerClientEvent(sender, "CharacterUpdate");
            API.TriggerClientEvent(sender, "PlayerPlate", "mp_character_creation@customise@male_a", "intro", "Azkaban", "Con", "jordan", "pute", -1, 7500);
            //PI.TriggerClientEvent(sender, "PlayerPlate", "mp_character_creation@lineup@male_a", "loop_raised", "Azkaban", "Con", "jordan", "pute", 0, -1);
            API.TriggerClientEvent(sender, "MoveCam", select);
            //NAPI.Ped.CreatePed(PedHash.FreemodeFemale01, sender.Position, sender.Heading);
        }

        [Command("npc")]
        public void npc(Client sender)
        {
            sender.SendChatMessage("Npc Event Call");
            API.TriggerClientEvent(sender, "PlayerPlate", "mp_character_creation@lineup@male_a", "loop_raised", "Azkaban", "Con", "jordan", "pute", 0, -1);

            //API.TriggerClientEvent(sender, "test", sender.Position);
            //NAPI.Ped.CreatePed(PedHash.FreemodeFemale01, sender.Position, sender.Heading);
        }

        [Command("create_vehicule_a")]
        public void create_vehicule(Client sender)
        {
            NAPI.Vehicle.CreateVehicle(1777363799, sender.Position.Around(3), 0, 0, 0);
        }

        [Command("achille")]
        public void achille(Client sender) {
            //NAPI.Ped.CreatePed(PedHash.Cop01SMY, sender.Position, sender.Heading);
            //API.CreateBlip(1, sender.Position, 12, 0x9a);
            sender.TriggerEvent("test_test_test");
        }

        [Command("scenario_play")]
        [RemoteEvent("scenario_play")]
        public void scenario_play(Client sender)
        {
            sender.TriggerEvent("scenario_intro_event_teaser");
            sender.TriggerEvent("video_intro_event", 0, 0, 0);
            sender.TriggerEvent("intro_board_anim_event");
            sender.TriggerEvent("AnimationSyncLaunchSetting", sender, "mp_character_creation@customise@male_a", "intro", 8f, -8f, 7500);
            NAPI.Task.Run(() => {
                sender.TriggerEvent("AnimationSyncClose", sender, "mp_character_creation@customise@male_a", "intro");
                sender.TriggerEvent("AnimationSyncLaunchSetting", sender, "mp_character_creation@lineup@male_a", "loop_raised", 8f, -8f, -1);
                sender.TriggerEvent("MoveCam", 7);
            }, 7000);

            NAPI.Task.Run(() => {
                sender.TriggerEvent("MoveCam", 8);
            }, 8000);

            NAPI.Task.Run(() => {
                sender.TriggerEvent("TakePhotoSave", "id_card_face_" + sender.SocialClubName + ".png");
            }, 9200);
            
            NAPI.Task.Run(() => {
                sender.TriggerEvent("Disable_cam_gestion");
                sender.TriggerEvent("AnimationSyncClose", sender, "mp_character_creation@lineup@male_a", "loop_raised");
                sender.Position = new Vector3(407f, -997f, 40f);
            }, 10000);
        }

        [Command("move_npc")]
        public void move_npc(Client sender, float x, float y, float z)
        {
            Vector3 pos = new Vector3(x, y, z);
            sender.SendChatMessage("Npc Event Call");
            API.TriggerClientEvent(sender, "move_npc", pos);
            //NAPI.Ped.CreatePed(PedHash.FreemodeFemale01, sender.Position, sender.Heading);
        }


        [Command("mine")]
        public void PlaceMine(Client sender, float MineRange = 10f)
        {
            var pos = NAPI.Entity.GetEntityPosition(sender);
            var playerDimension = NAPI.Entity.GetEntityDimension(sender);

            var prop = NAPI.Object.CreateObject(NAPI.Util.GetHashKey("prop_bomb_01"), pos - new Vector3(0, 0, 1f), new Vector3(), 255, playerDimension);
            var shape = NAPI.ColShape.CreateSphereColShape(pos, 10);
            shape.Dimension = playerDimension;
        }
    }*/

}
