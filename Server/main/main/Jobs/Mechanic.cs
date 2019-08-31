using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GTANetworkAPI;

namespace main.Jobs
{
    /*class Mechanic : Script
    {
        private Vehicle v = null;
        private Vector3[] a_pos = new Vector3[3];
        private GTANetworkAPI.Object o = null;


        [RemoteEvent("DebugOutput")]
        public void debug_output(string line)
        {
            NAPI.Util.ConsoleOutput(line);
        }

        [RemoteEvent("SetDataVehiculeValue")]
        public void SetDataVehiculeValue(Client player, float _x, float _y, float _z, float x, float y, float z, float __x, float __y, float __z) {
            
            a_pos[0] = new Vector3(_x, _y, _z);
            a_pos[1] = new Vector3(x, y, z);
            a_pos[2] = new Vector3(__x, __y, __z);
           
            NAPI.Util.ConsoleOutput(a_pos[0] + " | " + a_pos[1] + " | "+ a_pos[2]);
        }
        

        [RemoteEvent("MecanoRepair")]
        public void mecano_repair(Client player)
        {
            if (v == null && player.SocialClubName == "Creed12345678")
            {
                //o = NAPI.Object.CreateObject(NAPI.Util.GetHashKey("prop_cs_wrench"), player.Position, new Vector3(), 255, 0);
                v = NAPI.Vehicle.CreateVehicle(1777363799, player.Position.Around(3), 0, 0, 0);
                //v.FreezePosition = false;
                player.TriggerEvent("MecanoSetActive", 0, false);
            }
            else if (v != null) {
                if (a_pos[0] != null)
                {
                    //player.SendChatMessage(player.Position.ToString() + " | " + v.Position.ToString() + " | " + a_pos[0] + " | " + a_pos[1]);
                    if (player.Position.DistanceTo2D(a_pos[0]) < 1f)
                    {
                        NAPI.ClientEvent.TriggerClientEventInRange(player.Position, 1000f, "createBrowser", "package://Mechanic/index.html");
                        anim_start(player, "amb@world_human_vehicle_mechanic@male@idle_a", "idle_a");
                        NAPI.ClientEvent.TriggerClientEventInRange(player.Position, 1000f, "AttachObject", player, "prop_cs_wrench");
                        NAPI.ClientEvent.TriggerClientEventInRange(player.Position, 1000f, "AttachObjectVehicule", player, v, "prop_carjack", "door_dside_f");
                        NAPI.ClientEvent.TriggerClientEventInRange(player.Position, 1000f, "InclinVehiculeMecano", v, o, 1);
                        NAPI.Task.Run(() =>
                        {
                            NAPI.ClientEvent.TriggerClientEventInRange(player.Position, 1000f, "destroyBrowser");
                            anim_end(player, "amb@world_human_vehicle_mechanic@male@idle_a", "idle_a");
                            NAPI.ClientEvent.TriggerClientEventInRange(player.Position, 1000f, "AttachObject", player, "prop_cs_wrench");
                            NAPI.ClientEvent.TriggerClientEventInRange(player.Position, 1000f, "AttachObjectVehicule", player, v, "prop_carjack", "door_dside_f");
                            NAPI.ClientEvent.TriggerClientEventInRange(player.Position, 1000f, "InclinVehiculeMecano", v, o, -1);
                            NAPI.ClientEvent.TriggerClientEventInRange(player.Position, 1000f, "RepairVehiculeMecano", v);
                            player.TriggerEvent("MecanoSetActive", 0, false);
                        }, 16000);
                    }
                    else if (player.Position.DistanceTo2D(a_pos[1]) < 1f)
                    {
                        NAPI.ClientEvent.TriggerClientEventInRange(player.Position, 1000f, "createBrowser", "package://Mechanic/index.html");
                        anim_start(player, "amb@world_human_vehicle_mechanic@male@idle_a", "idle_a");
                        NAPI.ClientEvent.TriggerClientEventInRange(player.Position, 1000f, "AttachObject", player, "prop_cs_wrench");
                        NAPI.ClientEvent.TriggerClientEventInRange(player.Position, 1000f, "AttachObjectVehicule", player, v, "prop_carjack", "door_pside_f");
                        NAPI.ClientEvent.TriggerClientEventInRange(player.Position, 1000f, "InclinVehiculeMecano", v, o, 0);
                        NAPI.Task.Run(() =>
                        {
                            NAPI.ClientEvent.TriggerClientEventInRange(player.Position, 1000f, "destroyBrowser");
                            anim_end(player , "amb@world_human_vehicle_mechanic@male@idle_a", "idle_a");
                            NAPI.ClientEvent.TriggerClientEventInRange(player.Position, 1000f, "AttachObject", player, "prop_cs_wrench");
                            NAPI.ClientEvent.TriggerClientEventInRange(player.Position, 1000f, "AttachObjectVehicule", player, v, "prop_carjack", "door_pside_f");
                            NAPI.ClientEvent.TriggerClientEventInRange(player.Position, 1000f, "InclinVehiculeMecano", v, o, -1);
                            NAPI.ClientEvent.TriggerClientEventInRange(player.Position, 1000f, "RepairVehiculeMecano", v);
                            player.TriggerEvent("MecanoSetActive", 0, false);
                        }, 16000);
                    }
                    else if (player.Position.DistanceTo2D(a_pos[2]) < 1f)
                    {
                        //anim_start(player, "amb@world_human_vehicle_mechanic@male@idle_a", "idle_b");
                        NAPI.ClientEvent.TriggerClientEventInRange(player.Position, 1000f, "AttachObject", player, "prop_pliers_01");
                        NAPI.ClientEvent.TriggerClientEventInRange(player.Position, 1000f, "OpenDoor", v, "4", 120f);
                        NAPI.Task.Run(() =>
                        {
                            //anim_end(player);
                            NAPI.ClientEvent.TriggerClientEventInRange(player.Position, 1000f, "OpenDoor", v, "4", 0f);
                            NAPI.ClientEvent.TriggerClientEventInRange(player.Position, 1000f, "AttachObject", player, "prop_pliers_01");
                            NAPI.ClientEvent.TriggerClientEventInRange(player.Position, 1000f, "RepairVehiculeMecano", v);
                            player.TriggerEvent("MecanoSetActive", 0, false);
                        }, 16000);
                    }
                    else
                    {
                        NAPI.Task.Run(() =>
                        {

                            player.TriggerEvent("GetDoorPos", v);
                            player.TriggerEvent("MecanoSetActive", 0, false);
                            //anim_end(player);
                            NAPI.ClientEvent.TriggerClientEventInRange(player.Position, 100f, "InclinVehiculeMecano", v, -1);
                            //NAPI.ClientEvent.TriggerClientEventInRange(player.Position, 100f, "AttachObject", player, "prop_cs_wrench");

                        }, 1000);
                    }
                }
                else if (v != null)
                {
                    NAPI.Task.Run(() =>
                    {

                        player.TriggerEvent("GetDoorPos", v);
                        player.TriggerEvent("MecanoSetActive", 0, false);
                        //anim_end(player);
                        NAPI.ClientEvent.TriggerClientEventInRange(player.Position, 100f, "InclinVehiculeMecano", v, -1);
                        //NAPI.ClientEvent.TriggerClientEventInRange(player.Position, 100f, "AttachObject", player, "prop_cs_wrench");

                    }, 1000);
                }
            }
        }


        [Command("mecano_door")]
        public void door(Client player, string door, float angle)
        {
           if (o == null)
            {
                //prop_pliers_01
                v = NAPI.Vehicle.CreateVehicle(3078201489, player.Position + new Vector3(0, 0, 0.1f), 0, 0, 0);
                o = NAPI.Object.CreateObject(-1964997422, player.Position + new Vector3(2, 0, 0), new Vector3());

                //o = NAPI.Object.CreateObject(NAPI.Util.GetHashKey("prop_pliers_01"), player.Position, new Vector3(), 255, 0);
                //API.AttachEntityToEntity(model.Handle, player.Handle, "IK_R_Hand", new Vector3(), new Vector3());
                //NAPI.ClientEvent.TriggerClientEventInRange(< Vector3 position >, < float range >, < string eventName >, < Vehicle vehicle >, < string doorId >, < float angle >);
                //NAPI.Vehicle.SetVehicleDoorState()
                //v = API.CreateVehicle(3078201489, player.Position, 0, 0, 0);
            }
            //for (int i = 0; i < 7; i++)
            //{
            //    v.SetSharedData(i.ToString(), angle);
            //}
            //o.SetSharedData("AttachElement", (GTANetworkAPI.Entity)o);
            //player.AttachTo(o.Handle, "IK_R_Hand", new Vector3(), new Vector3());
            NAPI.Task.Run(() => {
                //player.TriggerEvent("AttachObject", o);
                //player.TriggerEvent("tasttost", (GTANetworkAPI.Entity)o);

                NAPI.ClientEvent.TriggerClientEventInRange(player.Position, 100f, "OpenDoor", v, door, angle);
            }, 1000);
            //NAPI.Vehicle.SetVehicleDoorState(v.Handle, door, true);

            //v.OpenDoor(door);
        }

        [RemoteEvent("update_vehicule")]
        public void update_v(string social)
        {
            //main.Engine.Player.Auth.LoginRegister.all_players_client[social].Position.X;
            //NAPI.ClientEvent.TriggerClientEventInRange(player.Position, 100f, "createVehicule", player.Position.X, player.Position.Y, player.Position.Z);
        }


        [RemoteEvent("TestATestBTestC")]
        public void gege(Client sender, object[] args)
        {
            NAPI.Chat.SendChatMessageToAll(sender.SocialClubName);
            sender.PlayAnimation((string)args[0], (string)args[1], 1);
            //main.Engine.Player.Auth.LoginRegister.all_players_client[social].Position.X;
            //NAPI.ClientEvent.TriggerClientEventInRange(player.Position, 100f, "createVehicule", player.Position.X, player.Position.Y, player.Position.Z);
        }


        [Command("mecano_break")]
        public void mbreak(Client player, int door)
        {
            if (v == null)
                v = NAPI.Vehicle.CreateVehicle(3078201489, player.Position, 0, 0, 0);
            v.BreakDoor(door);
        }

        [Command("mecano_close")]
        public void mclose(Client player, int door)
        {
            if (v == null)
                v = NAPI.Vehicle.CreateVehicle(3078201489, player.Position, 0, 0, 0);
            v.CloseDoor(door);
        }

        [Command("mecano_wbreak")]
        public void wbreak(Client player, int door)
        {
            if (v == null)
                v = NAPI.Vehicle.CreateVehicle(3078201489, player.Position, 0, 0, 0);
            v.BreakWindow(door);
        }

        [Command("mecano_test")]
        public void test(Client player, int door)
        {
            if (v == null)
                v = NAPI.Vehicle.CreateVehicle(3078201489, player.Position, 0, 0, 0);
            //player.PlayAnimation("amb@world_human_vehicle_mechanic@male@base", "base", 1);
            //player.StopAnimation();
            //player
        }

        public enum AnimationFlags
        {
            Loop = 1 << 0,
            StopOnLastFrame = 1 << 1,
            OnlyAnimateUpperBody = 1 << 4,
            AllowPlayerControl = 1 << 5,
            Cancellable = 1 << 7
        };


        [Command("anim_start")]
            public void anim_start(Client player, string d, string a)
            {
            player.PlayAnimation(d, a, (int)AnimationFlags.Loop);
            //player.SendChatMessage("Passage " + d + " " + a + "|");
            //NAPI.ClientEvent.TriggerClientEventForAll("AnimationSyncLaunch", player, d, a);

            //NAPI.ClientEvent.TriggerClientEventInRange(player.Position, 100f, "test_other_people", player, "amb@world_human_vehicle_mechanic@male@idle_a", "idle_a");
            //player.SetSharedData("AnimationSyncLaunch", new object[] { d, a });
            //player.SetData("od", 0);
            //player.SetSharedData("Anonymous", null);
            //v.SetSharedData("salut", 0.0f);
            /*for (int i = 0; i < 7; i++)
            {
                v.SetSharedData(i.ToString(), 0.0f);
            }
            //NAPI.ClientEvent.TriggerClientEventInRange(player.Position, 100f, "EntityStreamIn");
            
            //NAPI.ClientEvent.TriggerClientEventInRange(player.Position, 100f, "RepairVehiculeMecano", v);

            //v.FreezePosition = true;
            //v.Rotation = new Vector3(0, 45, 0);
            //v.Position += new Vector3(0, 0, 1.5f);
        }

        [Command("anim_end")]
            public void anim_end(Client player, string d, string a)
            {

                //NAPI.ClientEvent.TriggerClientEventForAll( "AnimationSyncClose", player, d, a);
                player.SetSharedData("AnimationSyncClose", 0);
                //player.StopAnimation();
                //v.Locked = !v.Locked;
            }


    }*/
}
