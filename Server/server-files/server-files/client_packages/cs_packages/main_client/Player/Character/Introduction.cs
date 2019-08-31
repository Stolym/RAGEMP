using System;
using System.Collections.Generic;
using System.Text;
using RAGE;
using RAGE.Elements;

//using CAPI = main_client.Camera.Camera;
//using Newtonsoft.Json;
//using PAPI = main_client.Ped.Ped;

namespace main_client.Player.Character
{
    /*class GlobalIntroduction
    {

        public class TaskSync {
            public uint RemoteId { get; set; }
            public uint vRemoteId { get; set; }
            public string side { get; set; }
            public bool leave { get; set; }

            public TaskSync() {

            }

            public TaskSync(RAGE.Elements.Player player, RAGE.Elements.Vehicle veh, string side = "", bool leave = false) {
                this.RemoteId =  player.RemoteId;
                this.vRemoteId = veh.RemoteId;
                this.side = side;
            }
            
            public void StreamIn() {
                 switch (side)
                {
                    case "South":
                        InFlyingSouth();
                        break;
                    case "North":
                        InFlyingNorth();
                        break;
                }
            }


            public void InFlyingSouth()
            {
                Chat.Output(" Stream In "+RemoteId +" "+vRemoteId);
                Vehicle veh = Entities.Vehicles.All.Find(x => x.RemoteId == vRemoteId);
                RAGE.Elements.Player player = Entities.Players.All.Find(x => x.RemoteId == RemoteId);

                if (veh == null || player == null)
                    return;
                if (leave == false)
                {
                    veh.SetForwardSpeed(200);
                    RAGE.Game.Ped.SetPedIntoVehicle(player.Handle, veh.Handle, -1);
                    RAGE.Game.Vehicle.SetVehicleForwardSpeed(veh.Handle, 300);
                    RAGE.Game.Ai.TaskPlaneLand(player.Handle, veh.Handle, -1790.255f, -2696.766f, 125.4949f, -1219.258f, -3017.728f, 14.1612f);
                }
                else if (leave) { 
                    RAGE.Game.Vehicle.SetVehicleForwardSpeed(veh.Handle, 0);
                    RAGE.Game.Cam.RenderFirstPersonCam(true, 0, 3, 0);
                    RAGE.Game.Ai.TaskLeaveVehicle(player.Handle, veh.Handle, 256);
                    Utils.ThreadingTask.make_task_with_timeout(() =>
                    {
                        Events.CallLocal("destroyBrowser", "intro_server");
                        Events.CallRemote("delete_introduction_id", veh.RemoteId);
                        Events.CallLocal("createBrowser", "UserInfo", "package://Life/index.html");
                    }, 4000);
                }
            }

            public void InFlyingNorth()
            {
                Chat.Output(" Stream In " + RemoteId + " " + vRemoteId);
                Vehicle veh = Entities.Vehicles.All.Find(x => x.RemoteId == vRemoteId);
                RAGE.Elements.Player player = Entities.Players.All.Find(x => x.RemoteId == RemoteId);

                if (veh == null || player == null)
                    return;
                if (leave == false)
                {
                    veh.SetForwardSpeed(200);
                    RAGE.Game.Ped.SetPedIntoVehicle(player.Handle, veh.Handle, -1);
                    RAGE.Game.Vehicle.SetVehicleForwardSpeed(veh.Handle, 300);
                    RAGE.Game.Ai.TaskPlaneLand(player.Handle, veh.Handle, 1024.691f, 3061.382f, 184.825f, 1719.3323f, 3254.657f, 41.25867f);
                }
                else if (leave)
                {
                    RAGE.Game.Vehicle.SetVehicleForwardSpeed(veh.Handle, 0);
                    RAGE.Game.Cam.RenderFirstPersonCam(true, 0, 3, 0);
                    RAGE.Game.Ai.TaskLeaveVehicle(player.Handle, veh.Handle, 256);
                    Utils.ThreadingTask.make_task_with_timeout(() =>
                    {
                        Events.CallLocal("destroyBrowser", "intro_server");
                        Events.CallRemote("delete_introduction_id", veh.RemoteId);
                        Events.CallLocal("createBrowser", "UserInfo", "package://Life/index.html");
                    }, 4000);
                }
            }

        }


        class Introduction : Events.Script
        {
            // -1790.255 -2696.766 125.4949
            // -1219.258 -3017.728 14.1612
            // 807.2236 3001.308 159.0404
            // 1719.3323 3254.657 41.25867
            // 460.6563 2865.279 700



            List<Vector3> AllPosition = new List<Vector3>() { new Vector3(-3120.649f, -1507.507f, 99f) };
            uint fly_remoteid = 0;
            string side = "";
            float clock = 0;

            public Introduction()
            {
                Events.Add("IntroductionTaskStreamUpdate", IntroductionTaskStreamUpdate);
                Events.Add("IntroductionSelect", IntroductionSelect);
                Events.OnEntityStreamIn += OnEntityStreamIn;
                Events.OnEntityStreamOut += OnEntityStreamOut;
                Events.Tick += Tick;
            }

            private void OnEntityStreamOut(Entity entity)
            {

            }

            private void OnEntityStreamIn(Entity entity)
            {

                Chat.Output("Type A " + entity.ToString());
                if (entity.Type != RAGE.Elements.Type.Player && entity.Type != RAGE.Elements.Type.Vehicle)
                    return;

                Chat.Output("Type B " + entity.ToString());
                if (entity.Type == RAGE.Elements.Type.Vehicle)
                {
                    var jsonData = entity.GetSharedData("Introduction");

                    if (jsonData == null)
                        return;

                    var result = JsonConvert.DeserializeObject<TaskSync>(jsonData.ToString());
                    result.StreamIn();
                }
                else
                {
                    var jsonData = entity.GetSharedData("IntroductionTaskStream");

                    Chat.Output("Type C " + entity.ToString() + " " + jsonData.ToString());

                    if (jsonData == null)
                        return;

                    var result = JsonConvert.DeserializeObject<TaskSync>(jsonData.ToString());
                    result.StreamIn();

                }
            }

            private void IntroductionTaskStreamUpdate(object[] args)
            {
                TaskSync result = JsonConvert.DeserializeObject<TaskSync>(args[1].ToString());
                if (result == null)
                    return;
                result.StreamIn();
            }

            private void IntroductionSelect(object[] args)
            {
                uint remoteId = Convert.ToUInt16(args[0]);
                //Vehicle vehicle = RAGE.Elements.Entities.Vehicles.All.Find(x => x.RemoteId == remoteId);
                Camera.Camera.RenderView(false, 1);
                fly_remoteid = remoteId;
                side = args[1].ToString();

                Events.CallLocal("createBrowser", "intro_server", "package://IntroServer/index.html");
                switch (side)
                {
                    case "South":
                        RAGE.Elements.Player.LocalPlayer.Position = new Vector3(-2521.391f, -2264.896f, 127f);
                        CAPI.CameraGestion(6);
                        break;
                    case "North":
                        RAGE.Elements.Player.LocalPlayer.Position = new Vector3(257.2935f, 2849.016f, 275.5917f);
                        break;
                }
                RAGE.Game.Cam.DoScreenFadeIn(10000);
                Chat.Output(side);
            }

            private void Tick(List<Events.TickNametagData> nametags)
            {
                if (clock == 0)
                {
                    switch (side)
                    {
                        case "South":
                            InFlyingSouth(null);
                            break;
                        case "North":
                            InFlyingNorth(null);
                            break;
                    }
                    clock++;
                }
                else if (clock != 0 && clock < 80)
                {
                    clock++;
                }
                else if (clock == 80)
                    clock = 0;
            }

            public void InFlyingSouth(object[] args)
            {
                Vehicle sveh = Entities.Vehicles.All.Find(x => x.RemoteId == fly_remoteid);
                if (sveh != null && !RAGE.Elements.Player.LocalPlayer.IsInAnyVehicle(true))
                {
                    Chat.Output("Output " + sveh.RemoteId);
                    Events.CallRemote("UpdateIntroductionTask", JsonConvert.SerializeObject(new TaskSync() { RemoteId = RAGE.Elements.Player.LocalPlayer.RemoteId, vRemoteId = sveh.RemoteId, leave = false, side = side }));
                }
                else if (sveh != null)
                {
                    if (sveh.Position.DistanceTo(new Vector3(-1219.258f, -3017.728f, 14.1612f)) < 100f)
                    {
                        CAPI.RenderView(false, 2000);
                    }
                    if (sveh.Position.DistanceTo(new Vector3(-1219.258f, -3017.728f, 14.1612f)) < 20f)
                    {
                        Events.CallRemote("UpdateIntroductionTask", JsonConvert.SerializeObject(new TaskSync() { RemoteId = RAGE.Elements.Player.LocalPlayer.RemoteId, vRemoteId = sveh.RemoteId, leave = true, side = side }));
                        side = "";
                    }
                }
                /*foreach (RAGE.Elements.Player p in RAGE.Elements.Entities.Players.All) {
                    TaskSync data = (TaskSync)p.GetSharedData("IntroductionTaskStream");
                    if (data == null)
                        continue;
                    if (!p.IsInAnyVehicle(true))
                        data.StreamIn();
                }
                
            }

            public void InFlyingNorth(object[] args)
            {
                Vehicle sveh = Entities.Vehicles.All.Find(x => x.RemoteId == fly_remoteid);
                if (sveh != null && !RAGE.Elements.Player.LocalPlayer.IsInAnyVehicle(true))
                {
                    Chat.Output("Output " + sveh.RemoteId);
                    Events.CallRemote("UpdateIntroductionTask", JsonConvert.SerializeObject(new TaskSync() { RemoteId = RAGE.Elements.Player.LocalPlayer.RemoteId, vRemoteId = sveh.RemoteId, leave = false, side = side }));
                }
                else if (sveh != null)
                {
                    if (sveh.Position.DistanceTo(new Vector3(1719.3323f, 3254.657f, 41.25867f)) < 100f)
                    {
                        CAPI.RenderView(false, 2000);
                    }
                    if (sveh.Position.DistanceTo(new Vector3(1719.3323f, 3254.657f, 41.25867f)) < 20f)
                    {
                        Events.CallRemote("UpdateIntroductionTask", JsonConvert.SerializeObject(new TaskSync() { RemoteId = RAGE.Elements.Player.LocalPlayer.RemoteId, vRemoteId = sveh.RemoteId, leave = true, side = side }));
                        side = "";
                    }
                }
            }

            /*private void IntroductionNewPlayerSouth(object[] args)
            {
                ushort remoteID = Convert.ToUInt16(args[0]);
                RAGE.Elements.Player player = Entities.Players.GetAtRemote(remoteID);

                if (player.GetSharedData("LogPlaner") != null)
                {
                    ushort v_remoteID = Convert.ToUInt16((ushort)player.GetSharedData("LogPlaner"));
                    Vehicle vehicle = Entities.Vehicles.GetAtRemote(v_remoteID);
                    int ped = RAGE.Game.Ped.CreatePed(1, 1581098148, -1403, -2225, 1000, 270, false, false);
                    RAGE.Game.Invoker.Wait(200);
                    RAGE.Game.Ped.SetPedIntoVehicle(ped, vehicle.Handle, -1);
                    RAGE.Game.Ped.SetPedIntoVehicle(RAGE.Elements.Player.LocalPlayer.Handle, vehicle.Handle, 0);
                    RAGE.Game.Ai.TaskVehicleShootAtCoord(ped, 0, 0, 0, 0);
                }
            }

            private void IntroductionSouth(object[] args)
            {
                Vehicle vehicle = (RAGE.Elements.Vehicle)args[0];
                Camera.Camera.RenderView(false, 1);
                RAGE.Game.Cam.DoScreenFadeIn(1);
                RAGE.Elements.Player.LocalPlayer.Position = new Vector3(-3120.649f, -1507.507f, 99f);
                veh = vehicle;
                //RAGE.Elements.Player.LocalPlayer.Position = new Vector3(-1149.834f, -2812.012f, 34.40384f);
                //RAGE.Game.Ai.TaskGoToCoordAnyMeans(RAGE.Elements.Player.LocalPlayer.Handle, -1165.116f, -2735.451f, 19.88734f, 1, 0, false, 786603, 0xbf800000);
                //RAGE.Game.Ped.SetPedIntoVehicle(RAGE.Elements.Player.LocalPlayer.Handle, vehicle.Handle, -1);
                //new Vector3();
                /*int ped = RAGE.Game.Ped.CreatePed(1, 1581098148, -1403, -2225, 1000, 270, false, false);
                RAGE.Game.Ped.SetPedIntoVehicle(ped, vehicle.Handle, -1);
                RAGE.Game.Ped.SetPedIntoVehicle(player.Handle, vehicle.Handle, 0);
                RAGE.Game.Ai.TaskVehicleShootAtCoord(ped, 0, 0, 0, 0);
            }
        }
    }*/
}
