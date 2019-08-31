using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RAGE;
using RAGE.Elements;

namespace main_client.Ventura.Utils
{
    class Debug : Events.Script
    {
        public static Debug instance { get; set; }
        private bool DebugActive { get; set; }

        public Debug() {
            instance = this;
            DebugActive = false;
            Events.Add("CEFDEBUGCOMMAND", CEFDEBUGCOMMAND);
            Events.Add("TestTask", TestTask);
            Events.Add("ClearTask", ClearTask);
            Events.OnEntityCreated += OnEntityCreated;
        }

        private void CEFDEBUGCOMMAND(object[] args)
        {
            string json = (string)args[0];
            dynamic data = JsonConvert.DeserializeObject(json);

            DebugActive = data.Debug;

            OTicks.instance.limit[0] = data.Value[0];
            OTicks.instance.stream[0] = (float)data.Value[1];
            OTicks.instance.limit[1] = data.Value[2];
            OTicks.instance.stream[1] = (float)data.Value[3];
        }

        private void OnEntityCreated(Entity entity)
        {
            //Chat.Output("TR " + entity.RemoteId);
        }

        class Quaternion
        {
            public float X { get; set; }
            public float Y { get; set; }
            public float Z { get; set; }
            public float W { get; set; }
            public Quaternion() { }
        }

        Quaternion ToQuaternion(double yaw, double pitch, double roll)
        {
            float cy = (float)Math.Cos(yaw * 0.5);
            float sy = (float)Math.Sin(yaw * 0.5);
            float cp = (float)Math.Cos(pitch * 0.5);
            float sp = (float)Math.Sin(pitch * 0.5);
            float cr = (float)Math.Cos(roll * 0.5);
            float sr = (float)Math.Sin(roll * 0.5);

            Quaternion q = new Quaternion();
            q.W = cy * cp * cr + sy * sp * sr;
            q.X = cy * cp * sr - sy * sp * cr;
            q.Y = sy * cp * sr + cy * sp * cr;
            q.Z = sy * cp * cr - cy * sp * sr;

            return q;
        }


        private void NFunction(object[] args)
        {
            int i = (int)args[0];
            int j = (int)args[1];
            Events.CallRemote("Utils", "Debug " + i + " " + j);
            Events.CallRemote("Utils", RAGE.Game.Vehicle.GetVehicleDeformationAtPos(RAGE.Elements.Entities.Vehicles.All[0].Handle, i * 0.01f, j * 1f, 0.3f).X + " " + RAGE.Game.Vehicle.GetVehicleDeformationAtPos(RAGE.Elements.Entities.Vehicles.All[0].Handle, i * 0.01f, j * 0.01f, 0.3f).Y + " " + RAGE.Game.Vehicle.GetVehicleDeformationAtPos(RAGE.Elements.Entities.Vehicles.All[0].Handle, i * 0.01f, j * 0.01f, 0.3f).Z);
            Quaternion q = ToQuaternion(RAGE.Game.Vehicle.GetVehicleDeformationAtPos(RAGE.Elements.Entities.Vehicles.All[0].Handle, i * 0.01f, j * 1f, 0.3f).X, RAGE.Game.Vehicle.GetVehicleDeformationAtPos(RAGE.Elements.Entities.Vehicles.All[0].Handle, i * 0.01f, j * 0.01f, 0.3f).Y, RAGE.Game.Vehicle.GetVehicleDeformationAtPos(RAGE.Elements.Entities.Vehicles.All[0].Handle, i * 0.01f, j * 0.01f, 0.3f).Z);
            Events.CallRemote("Utils", q.W + " " + q.X + " " + q.Y + " " + q.Z);
            Events.CallRemote("Utils", "------------------------------");
        }
        private void ClearTask(object[] args)
        {
            int r1 = (int)args[0];

            /*for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Ventura.Utils.OTicks.instance.AddClockToInstance(new Utils.OClock(0, 0, 0, i * 10, NFunction, new object[] { i, j }));
                }            
            }*/
            //RAGE.Game.Misc.SetWeatherTypeNow("THUNDER");
            //RAGE.Game.Clock.SetClockTime(23, 59, 00);
            RAGE.Game.Pad.EnableAllControlActions(0);
            for (int i = 0; i < 330; i++) {
                RAGE.Game.Pad.EnableControlAction(0, i, true);

            }
            RAGE.Ui.Cursor.Visible = true;
            //RAGE.Game.Ai.TaskOpenVehicleDoor(RAGE.Elements.Entities.Players.All[0].Handle, RAGE.Elements.Entities.Vehicles.All[0].Handle, 15000, r1, 1);
            // RAGE.Game.Streaming.ClearFocus();
            // Chat.Output(RAGE.Game.Streaming.IsEntityFocus(RAGE.Elements.Player.LocalPlayer.Handle) + " res");
            /*int index = 0;

            
            RAGE.Game.Ped.SetPedConfigFlag(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r1).Handle, 60, true);
            RAGE.Game.Ped.SetPedConfigFlag(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r1).Handle, 61, true);
            RAGE.Game.Ped.SetPedConfigFlag(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r1).Handle, 104, true);*/
            /*for (int i = 0; i < Constant.Constant.ListDoor.Count; i++)
            {
                index = RAGE.Game.Object.GetClosestObjectOfType(RAGE.Elements.Player.LocalPlayer.Position.X, RAGE.Elements.Player.LocalPlayer.Position.Y, RAGE.Elements.Player.LocalPlayer.Position.Z, 3, RAGE.Game.Misc.GetHashKey(Constant.Constant.ListDoor[i]), false, false, false);
                if (index != 0) {
                    Vector3 pos = RAGE.Game.Entity.GetEntityCoords(index, true);
                    RAGE.Game.Object.SetStateOfClosestDoorOfType(RAGE.Game.Misc.GetHashKey(Constant.Constant.ListDoor[i]), pos.X, pos.Y, pos.Z, false, (float)r1, false);
                }
            }*/
            //RAGE.Game.Ai.ClearPedTasksImmediately(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r1).Handle);

        }

        private void TestTask(object[] args)
        {
            int r1 = (int)args[0];
            int r2 = (int)args[1];
            int a = (int)args[2];
            int b = (int)args[3];


            RAGE.Game.Vehicle.ToggleVehicleMod(RAGE.Elements.Entities.Vehicles.All[0].Handle, 17, true);
            RAGE.Game.Vehicle.ToggleVehicleMod(RAGE.Elements.Entities.Vehicles.All[0].Handle, 18, true);
            RAGE.Game.Vehicle.ToggleVehicleMod(RAGE.Elements.Entities.Vehicles.All[0].Handle, 19, true);
            RAGE.Game.Vehicle.ToggleVehicleMod(RAGE.Elements.Entities.Vehicles.All[0].Handle, 20, true);
            RAGE.Game.Vehicle.ToggleVehicleMod(RAGE.Elements.Entities.Vehicles.All[0].Handle, 21, true);
            RAGE.Game.Vehicle.ToggleVehicleMod(RAGE.Elements.Entities.Vehicles.All[0].Handle, 22, true);

            RAGE.Game.Vehicle.SetVehicleBrakeLights(RAGE.Elements.Entities.Vehicles.All[0].Handle, true);
            RAGE.Game.Vehicle.SetVehicleIndicatorLights(RAGE.Elements.Entities.Vehicles.All[0].Handle, 0, true);
            RAGE.Game.Vehicle.SetVehicleLights(RAGE.Elements.Entities.Vehicles.All[0].Handle, r1);
            RAGE.Game.Vehicle.SetVehicleLightsMode(RAGE.Elements.Entities.Vehicles.All[0].Handle, r2);
            RAGE.Game.Vehicle.SetVehicleNeonLightEnabled(RAGE.Elements.Entities.Vehicles.All[0].Handle, 0, true);
            RAGE.Game.Vehicle.SetVehicleNeonLightEnabled(RAGE.Elements.Entities.Vehicles.All[0].Handle, 1, true);
            RAGE.Game.Vehicle.SetVehicleNeonLightEnabled(RAGE.Elements.Entities.Vehicles.All[0].Handle, 2, true);
            RAGE.Game.Vehicle.SetVehicleNeonLightEnabled(RAGE.Elements.Entities.Vehicles.All[0].Handle, 3, true);
            //RAGE.Game.Vehicle.SetVehicleNeonLightsColour(RAGE.Elements.Entities.Vehicles.All[0].Handle, 255, 255, 80);
            RAGE.Game.Vehicle.SetVehicleTyreSmokeColor(RAGE.Elements.Entities.Vehicles.All[0].Handle, 255, 0, 0);
            RAGE.Game.Vehicle.SetVehicleLightMultiplier(RAGE.Elements.Entities.Vehicles.All[0].Handle, a);

            RAGE.Game.Misc.SetWeatherTypeNow("EXTRASUNNY");
            //RAGE.Game.Clock.SetClockTime(23, 59, 00);
            //RAGE.Game.Ped.SetPedCanRagdoll(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r1).Handle, true);
            //RAGE.Game.Ped.SetPedCanRagdoll(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r2).Handle, true);

            //RAGE.Game.Ped.ForcePedMotionState(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r2).Handle, 0xEC17E58, true, true, true);
            //RAGE.Game.Ped.ForcePedMotionState(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r1).Handle, 0x3F67C6AF, true, true, true);
            //RAGE.Game.Ai.ClearPedTasksImmediately(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r2).Handle);
            //RAGE.Game.Ai.ClearPedSecondaryTask(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r1).Handle);

            /*for (int h = 0; h < 500; h++)
            {
                RAGE.Game.Ped.SetPedConfigFlag(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r1).Handle, h, false);
                RAGE.Game.Ped.SetPedConfigFlag(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r2).Handle, h, false);
            }*/
            //RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r1).TaskShootAt(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r2).Handle, 1000, RAGE.Game.Misc.GetHashKey("FIRING_PATTERN_FULL_AUTO"));
            /*for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Ventura.Utils.OTicks.instance.AddClockToInstance(new OClock(0, 0, 0, j * 20, () =>
                    {


                        RAGE.Game.Ped.SetPedConfigFlag(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r2).Handle, 60, true);
                        RAGE.Game.Ped.SetPedConfigFlag(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r2).Handle, 61, true);
                        RAGE.Game.Ped.SetPedConfigFlag(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r1).Handle, 60, true);
                        RAGE.Game.Ped.SetPedConfigFlag(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r1).Handle, 61, true);

                        RAGE.Game.Ped.SetPedConfigFlag(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r2).Handle, 191, true);
                        RAGE.Game.Ped.SetPedConfigFlag(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r2).Handle, 295, true);
                        RAGE.Game.Ped.SetPedConfigFlag(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r1).Handle, 191, true);
                        RAGE.Game.Ped.SetPedConfigFlag(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r1).Handle, 295, true);
                        RAGE.Elements.Player.LocalPlayer.TaskPutDirectlyIntoMelee(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r2).Handle, 1, 1, 1, true);
                        RAGE.Elements.Player.LocalPlayer.TaskCombat(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r2).Handle, 1, 1);
                        RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r2).TaskPutDirectlyIntoMelee(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r1).Handle, 1, 1, 1, true);


                        //RAGE.Elements.Player.LocalPlayer.TaskCombat(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r2).Handle, 0, 0);
                        /*RAGE.Game.Ped.SetPedConfigFlag(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r1).Handle, 65, true);
                        RAGE.Game.Ped.SetPedConfigFlag(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r1).Handle, 66, true);
                        RAGE.Game.Ped.SetPedConfigFlag(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r1).Handle, 168, true);
                        RAGE.Game.Ped.SetPedConfigFlag(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r2).Handle, 60, true);
                        RAGE.Game.Ped.SetPedConfigFlag(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r2).Handle, 61, true);
                        RAGE.Game.Ped.SetPedConfigFlag(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r2).Handle, 101, true);
                        RAGE.Game.Ped.SetPedConfigFlag(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r2).Handle, 102, true);
                        RAGE.Game.Ped.SetPedConfigFlag(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r2).Handle, 103, true);
                        RAGE.Game.Ped.SetPedConfigFlag(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r2).Handle, 59, true);
                        RAGE.Game.Ped.SetPedConfigFlag(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r2).Handle, 58, true);
                        //Vector3 pos = RAGE.Game.Entity.GetEntityCoords(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r2).Handle, true);

                        //RAGE.Game.Ai.TaskAimGunAtCoord(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r1).Handle, pos.X, pos.Y, pos.Z, 2000, true, true);
                        //RAGE.Game.Ai.TaskShootAtEntity(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r1).Handle, RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r2).Handle, 1000, RAGE.Game.Misc.GetHashKey("FIRING_PATTERN_FULL_AUTO"));
                        //RAGE.Game.Ai.TaskCombatPed(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r1).Handle, RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r2).Handle, 0, 0);
                    }));
                }
            }*/

            //RAGE.Game.Ai.TaskCombatPed(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r2).Handle, RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r1).Handle, 0, 16);
            //RAGE.Game.Ai.TaskCombatPed(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r1).Handle, RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r2).Handle, 0, 16);

            //RAGE.Game.Ped.SetPedConfigFlag(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r1).Handle, 60, true);
            //RAGE.Game.Ped.SetPedConfigFlag(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r1).Handle, 61, true);
            //RAGE.Game.Ped.SetPedConfigFlag(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r1).Handle, 104, true);

            /*for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Ventura.Utils.OTicks.instance.AddClockToInstance(new Utils.OClock(0, 0, (i * 20) + j, 0, NewFunction, new object[] { r1, r2, i, j }));
                }
            }*/
            /*for (int j = 0; j < 20; j++)
            {
                Ventura.Utils.OTicks.instance.AddClockToInstance(new Utils.OClock(0, 0, 0, j * 100, () =>
                {
                    RAGE.Game.Ai.TaskChatToPed(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r1).Handle, RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r2).Handle, 1, 0, 0, 0, 0, 0);

                }));
            }*/

            //RAGE.Game.Ai.TaskStayInCover(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r1).Handle);

            //RAGE.Game.Ai.TaskArrestPed(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r1).Handle, RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r2).Handle);
        }

        private void NewFunction(object [] args)
        {
            int r1 = (int)args[0];
            int r2 = (int)args[1];
            int i = (int)args[2];
            int j = (int)args[3];
            Chat.Output(i + " "+ j);
            RAGE.Game.Ai.TaskCombatPed(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r1).Handle, RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == r2).Handle, i, j);
        }



        public void OnTick() {
            int index = 0;
            if (DebugActive)
            {
                for (int i = 0; i < RAGE.Elements.Entities.Vehicles.All.Count; i++)
                {
                    if (RAGE.Elements.Entities.Vehicles.All[i].Position.DistanceTo(RAGE.Elements.Player.LocalPlayer.Position) < 20f)
                        DEBUGVEHICLE(RAGE.Elements.Entities.Vehicles.All[i]);
                }

                for (int i = 0; i < RAGE.Elements.Entities.Players.All.Count; i++)
                {

                    if (RAGE.Elements.Entities.Players.All[i].Position.DistanceTo(RAGE.Elements.Player.LocalPlayer.Position) < 20f)
                        DEBUGPLAYER(RAGE.Elements.Entities.Players.All[i]);
                }

                for (int i = 0; i < Constant.Constant.ListDoor.Count; i++)
                {
                    index = RAGE.Game.Object.GetClosestObjectOfType(RAGE.Elements.Player.LocalPlayer.Position.X, RAGE.Elements.Player.LocalPlayer.Position.Y, RAGE.Elements.Player.LocalPlayer.Position.Z, 20, RAGE.Game.Misc.GetHashKey(Constant.Constant.ListDoor[i]), false, false, false);
                    if (index != 0)
                        DEBUGDOOR(index, RAGE.Game.Misc.GetHashKey(Constant.Constant.ListDoor[i]));
                }
            }
        }

        private void DEBUGDOOR(int index, uint v)
        {
            float screenX = 0;
            float screenY = 0;
            int resolutionX = 0;
            int resolutionY = 0;
            int locked = 0;
            float heading = 0f;
            Vector3 pos = RAGE.Game.Entity.GetEntityCoords(index, true);

            if (RAGE.Game.Graphics.GetScreenCoordFromWorldCoord(pos.X, pos.Y, pos.Z, ref screenX, ref screenY))
            {
                RAGE.Game.Object.GetStateOfClosestDoorOfType(v, pos.X, pos.Y, pos.Z, ref locked, ref heading);
                RAGE.Game.Graphics.GetScreenResolution(ref resolutionX, ref resolutionY);
                RAGE.Game.UIText.Draw("Door " + index + " state "+ locked + " "+heading, new System.Drawing.Point((int)(screenX * resolutionX), (int)(screenY * resolutionY)), 0.5f, System.Drawing.Color.Purple, RAGE.Game.Font.Pricedown, true);
            }
            RAGE.Game.Graphics.DrawLine(RAGE.Elements.Player.LocalPlayer.Position.X, RAGE.Elements.Player.LocalPlayer.Position.Y, RAGE.Elements.Player.LocalPlayer.Position.Z, pos.X, pos.Y, pos.Z, 0, 255, 0, 200);

        }

        private void DEBUGVEHICLE(Vehicle vehicle)
        {
            int index = -1;
            float screenX = 0;
            float screenY = 0;
            int resolutionX = 0;
            int resolutionY = 0;
            Vector3 pos = null;
            RAGE.Game.Graphics.DrawBox(vehicle.Position.X - 0.1f, vehicle.Position.Y - 0.1f, vehicle.Position.Z - 0.1f, vehicle.Position.X + 0.1f, vehicle.Position.Y + 0.1f, vehicle.Position.Z + 0.1f, 255, 60, 60, 100);
            if (RAGE.Game.Graphics.GetScreenCoordFromWorldCoord(vehicle.Position.X, vehicle.Position.Y, vehicle.Position.Z + 2, ref screenX, ref screenY))
            {
                RAGE.Game.Graphics.GetScreenResolution(ref resolutionX, ref resolutionY);
                RAGE.Game.UIText.Draw("Remote Id " + vehicle.RemoteId, new System.Drawing.Point((int)(screenX * resolutionX), (int)(screenY * resolutionY)), 0.5f, System.Drawing.Color.Purple, RAGE.Game.Font.Pricedown, true);
            }
            for (int i = 0; i < Constant.Constant.VehicleBone.Count; i++)
            {
                index = RAGE.Game.Entity.GetEntityBoneIndexByName(vehicle.Handle, Constant.Constant.VehicleBone[i]);
                if (index != -1)
                {
                    pos = RAGE.Game.Entity.GetWorldPositionOfEntityBone(vehicle.Handle, index);
                    if (RAGE.Game.Graphics.GetScreenCoordFromWorldCoord(pos.X, pos.Y, pos.Z, ref screenX, ref screenY))
                        RAGE.Game.UIText.Draw(Constant.Constant.VehicleBone[i], new System.Drawing.Point((int)(screenX * resolutionX), (int)(screenY * resolutionY)), 0.5f, System.Drawing.Color.White, RAGE.Game.Font.Pricedown, true);
                    RAGE.Game.Graphics.DrawBox(pos.X - 0.1f, pos.Y - 0.1f, pos.Z - 0.1f, pos.X + 0.1f, pos.Y + 0.1f, pos.Z + 0.1f, 255, 60, 255, 200);
                }
            }
            RAGE.Game.Graphics.DrawLine(RAGE.Elements.Player.LocalPlayer.Position.X, RAGE.Elements.Player.LocalPlayer.Position.Y, RAGE.Elements.Player.LocalPlayer.Position.Z, vehicle.Position.X, vehicle.Position.Y, vehicle.Position.Z, 0, 255, 0, 200);
        }

        private void DEBUGPLAYER(RAGE.Elements.Player player)
        {
            int index = -1;
            Vector3 pos = null;
            float screenX = 0;
            float screenY = 0;
            int resolutionX = 0;
            int resolutionY = 0;
            RAGE.Game.Graphics.DrawBox(player.Position.X - 0.1f, player.Position.Y - 0.1f, player.Position.Z - 0.1f, player.Position.X + 0.1f, player.Position.Y + 0.1f, player.Position.Z + 0.1f, 255, 60, 60, 100);
            if (RAGE.Game.Graphics.GetScreenCoordFromWorldCoord(player.Position.X, player.Position.Y, player.Position.Z + 2, ref screenX, ref screenY))
            {
                RAGE.Game.Graphics.GetScreenResolution(ref resolutionX, ref resolutionY);
                RAGE.Game.Ped.GetCombatFloat(player.Handle, 0);
                RAGE.Game.UIText.Draw("Remote Id " + player.RemoteId + "\nCombat "+RAGE.Game.Ped.GetPedCombatMovement(player.Handle) + "\nTarget " + RAGE.Game.Ped.GetMeleeTargetForPed(player.Handle)+ "\nRagdoll " + RAGE.Game.Ped.CanPedRagdoll(player.Handle), new System.Drawing.Point((int)(screenX * resolutionX), (int)(screenY * resolutionY)), 0.5f, System.Drawing.Color.Purple, RAGE.Game.Font.Pricedown, true);
            }

            for (int i = 0, k = 0; i < 500; i++)
            {
                if (RAGE.Game.Ai.GetIsTaskActive(player.Handle, i) && RAGE.Game.Graphics.GetScreenCoordFromWorldCoord(player.Position.X, player.Position.Y, player.Position.Z + 2 + 0.2f * (k + 1), ref screenX, ref screenY))
                {
                    /*if (RAGE.Game.Ai.GetIsTaskActive(player.Handle, 342) && RAGE.Game.Ai.GetIsTaskActive(player.Handle, 351))
                    {
                        Ventura.Utils.OTicks.instance.AddClockToInstance(new Utils.OClock(0, 0, 10, 0, () => {
                            RAGE.Game.Ai.ClearPedTasksImmediately(RAGE.Elements.Player.LocalPlayer.Handle);
                        }));
                    }
                    if (i == 128 && !RAGE.Game.Ai.GetIsTaskActive(player.Handle, 341) && !RAGE.Game.Ai.GetIsTaskActive(player.Handle, 342))
                    {
                        Random rand = new Random();
                        int a = rand.Next(0, 20);
                        int b = rand.Next(0, 20);
                        Chat.Output(a + " " + b);
                        RAGE.Game.Ai.TaskCombatPed(RAGE.Elements.Player.LocalPlayer.Handle, RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == RAGE.Elements.Player.LocalPlayer.RemoteId + 1).Handle, a, b);
                    }*/
                    RAGE.Game.Graphics.GetScreenResolution(ref resolutionX, ref resolutionY);
                    RAGE.Game.UIText.Draw("Task Active " + i, new System.Drawing.Point((int)(screenX * resolutionX), (int)(screenY * resolutionY)), 0.5f, System.Drawing.Color.Purple, RAGE.Game.Font.Pricedown, true);
                    k++;
                }
            }


            for (int i = 0, k = 0; i < 600; i++)
            {
                if (RAGE.Elements.Player.LocalPlayer.RemoteId == player.RemoteId)
                {
                    if (RAGE.Game.Ped.GetPedConfigFlag(player.Handle, i, true))
                        RAGE.Game.UIText.Draw("Flag True " + i, new System.Drawing.Point((int)(50 + 50 * (i/50)), (int)(10 * (i%50))), 0.3f, System.Drawing.Color.Green, RAGE.Game.Font.Pricedown, true);
                    //else
                    //    RAGE.Game.UIText.Draw("Flag False " + i, new System.Drawing.Point((int)(50 + 50 * (i/50)), (int)(10 * (i %50))), 0.2f, System.Drawing.Color.Red, RAGE.Game.Font.Pricedown, true);
                }
                else {
                    if (RAGE.Game.Ped.GetPedConfigFlag(player.Handle, i, true) && RAGE.Game.Graphics.GetScreenCoordFromWorldCoord(player.Position.X + 2, player.Position.Y, player.Position.Z - 5 + 0.2f * (k + 1), ref screenX, ref screenY))
                    {
                        RAGE.Game.Graphics.GetScreenResolution(ref resolutionX, ref resolutionY);
                        RAGE.Game.UIText.Draw("Flag Active " + i, new System.Drawing.Point((int)(screenX * resolutionX), (int)(screenY * resolutionY)), 0.5f, System.Drawing.Color.White, RAGE.Game.Font.Pricedown, true);
                        k++;
                    }

                }
            }

            /*for (int i = 0; i < 27; i++)
            {
                if (RAGE.Game.Graphics.GetScreenCoordFromWorldCoord(player.Position.X, player.Position.Y, player.Position.Z + 2 + 0.2f * (i + 1), ref screenX, ref screenY))
                {
                    RAGE.Game.Graphics.GetScreenResolution(ref resolutionX, ref resolutionY);
                    fightState = RAGE.Game.Ped.GetCombatFloat(player.Handle, i);
                    RAGE.Game.UIText.Draw("Fight State " + fightState, new System.Drawing.Point((int)(screenX * resolutionX), (int)(screenY * resolutionY)), 0.5f, System.Drawing.Color.Purple, RAGE.Game.Font.Pricedown, true);
                }

            }*/

            for (int i = 0; i < Constant.Constant.PedBone.Count; i++) {
                index = RAGE.Game.Entity.GetEntityBoneIndexByName(player.Handle, Constant.Constant.PedBone[i]);
                if (index != -1) {
                    pos = RAGE.Game.Entity.GetWorldPositionOfEntityBone(player.Handle, index);
                    RAGE.Game.Graphics.DrawBox(pos.X - 0.1f, pos.Y - 0.1f, pos.Z - 0.1f, pos.X + 0.1f, pos.Y + 0.1f, pos.Z + 0.1f, 255, 60, 255, 200);
                }
            }
            RAGE.Game.Graphics.DrawLine(RAGE.Elements.Player.LocalPlayer.Position.X, RAGE.Elements.Player.LocalPlayer.Position.Y, RAGE.Elements.Player.LocalPlayer.Position.Z, player.Position.X, player.Position.Y, player.Position.Z, 0, 255, 0, 200);
        }
    }
}
