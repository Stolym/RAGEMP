using System;
using System.Collections.Generic;
using System.Text;
using RAGE;
using RAGE.Elements;
using Newtonsoft.Json;
using CAPI = main_client.Ventura.Engine.Camera;
using AAPI = main_client.Ventura.Engine.Animation;
using PAPI = main_client.Ventura.Engine.Ped;



namespace main_client.Ventura.Engine
{
    [JsonObject]
    public class CEFCharacterEditor {

        public virtual int hair { get; set; }
        public virtual int hair_color { get; set; }
        public virtual int sourcils { get; set; }
        public virtual int sourcils_color { get; set; }
        public virtual int tenue { get; set; }
        public virtual int gender { get; set; }
        public virtual int eyes { get; set; }
        public virtual int barbes { get; set; }
        public virtual int barbes_color { get; set; }
        public virtual int father { get; set; }
        public virtual int mother { get; set; }
        public virtual int grandparent { get; set; }
        public virtual int degrade { get; set; }
        public virtual int poils { get; set; }
        public virtual int poils_color { get; set; }
        public virtual int vieille { get; set; }
        public virtual int skinSick { get; set; }
        public virtual int teint { get; set; }
        public virtual int taches { get; set; }
        public virtual int aspect { get; set; }
        public virtual int makeup { get; set; }
        public virtual int makeup_color { get; set; }
        public virtual int blush { get; set; }
        public virtual int blush_color { get; set; }
        public virtual float skinMix { get; set; }
        public virtual float heridityparent { get; set; }
        public virtual float heridity { get; set; }
        public virtual List<float> facefeature { get; set; }
        public virtual List<int> decoration { get; set; }
        public virtual List<int> facialDecoration { get; set; }
    }


    public class TaskSync
    {
        public uint RemoteId { get; set; }
        public uint vRemoteId { get; set; }
        public string side { get; set; }
        public List<bool> active { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
        public float rx { get; set; }
        public float ry { get; set; }
        public float rz { get; set; }
        public float speed { get; set; }

        public TaskSync()
        {

        }

        public TaskSync(RAGE.Elements.Player player, RAGE.Elements.Vehicle veh, string side = "")
        {
            this.RemoteId = player.RemoteId;
            this.vRemoteId = veh.RemoteId;
            this.side = side;
        }

        public void StreamIn()
        {
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
            Vehicle veh = Entities.Vehicles.All.Find(x => x.RemoteId == vRemoteId);
            RAGE.Elements.Player player = Entities.Players.All.Find(x => x.RemoteId == RemoteId);

            if (veh == null || player == null)
                return;

            if (active[2] == true && player.Handle != RAGE.Elements.Player.LocalPlayer.Handle)
            {
                if (RAGE.Game.Vehicle.GetPedInVehicleSeat(veh.Handle, -1, 0) != player.Handle)
                    RAGE.Game.Ped.SetPedIntoVehicle(player.Handle, veh.Handle, -1);
                if (veh.Position.DistanceTo(new Vector3(x, y, z)) > 1.5f)
                {
                    Vector3 diff = veh.Position - new Vector3(x, y, z);
                    Vector3 newPosition = new Vector3(x - (diff.X * 0.15f), y - (diff.Y * 0.15f), z - (diff.Z * 0.15f));
                    veh.Position = new Vector3(x, y, z);
                    player.Position = new Vector3(x, y, z);
                    RAGE.Game.Ped.SetPedIntoVehicle(player.Handle, veh.Handle, -1);
                }
                if (veh.GetRotation(1).DistanceTo(new Vector3(rx, ry, rz)) > 1.5f)
                {
                    Vector3 diff = veh.GetRotation(1) - new Vector3(rx, ry, rz);
                    Vector3 newRotation = new Vector3(rx - (diff.X * 0.06f), ry - (diff.Y * 0.06f), rz - (diff.Z * 0.06f));
                    veh.SetRotation(rx, ry, rz, 1, false);
                }
                if (veh.GetSpeed() != speed)
                {
                    veh.SetForwardSpeed(speed);
                }
            }

            if (active[0] == true && player.Handle == RAGE.Elements.Player.LocalPlayer.Handle)
            {
                veh.SetForwardSpeed(200);
                RAGE.Game.Ped.SetPedIntoVehicle(player.Handle, veh.Handle, -1);
                RAGE.Game.Vehicle.SetVehicleForwardSpeed(veh.Handle, 300);
                RAGE.Game.Ai.TaskPlaneLand(player.Handle, veh.Handle, -1790.255f, -2696.766f, 125.4949f, -1219.258f, -3017.728f, 14.1612f);
                active[0] = false;
                RAGE.Elements.Player.LocalPlayer.SetData<string>("IntroductionTaskStream", JsonConvert.SerializeObject(this));
                player.SetData<string>("IntroductionTaskStream", JsonConvert.SerializeObject(this));
            }
            else if (active[1] == true && player.Handle == RAGE.Elements.Player.LocalPlayer.Handle)
            {
                RAGE.Game.Vehicle.SetVehicleForwardSpeed(veh.Handle, 0);
                RAGE.Game.Cam.RenderFirstPersonCam(true, 0, 3, 0);
                RAGE.Game.Ai.TaskLeaveVehicle(player.Handle, veh.Handle, 256);
                Events.CallRemote("delete_introduction_id", veh.RemoteId);
                Ventura.Utils.OTicks.instance.AddClockToInstance(new Utils.OClock(0, 0, 2, 0, () => {
                    Ventura.Engine.Vocal.instance.ConnectTeamspeak(null);
                    Ventura.Engine.Interaction.InteractPlayer.instance.InteractionActive(null);
                    RAGE.Elements.Player.LocalPlayer.Position = new Vector3(-1153.29f, -2713.873f, 19.8873f);
                    RAGE.Game.Cam.DoScreenFadeIn(2000);
                }));
                //Events.CallLocal("destroyBrowser", "intro_server");
                //Ventura.Engine.HudPlayer.instance.active = true;
                //Ventura.Engine.HudPlayer.instance.OpenHUD();
                //RAGE.Ui.Cursor.Visible = false;
                active[1] = false;
                RAGE.Elements.Player.LocalPlayer.SetData<string>("IntroductionTaskStream", null);
                player.SetData<string>("IntroductionTaskStream", null);
                Events.CallRemote("UpdateIntroductionTask", null);
            }
        }

        public void InFlyingNorth()
        {
           /* Vehicle veh = Entities.Vehicles.All.Find(x => x.RemoteId == vRemoteId);
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
                    Events.CallRemote("delete_introduction_id", veh.RemoteId);
                    Events.CallLocal("destroyBrowser", "intro_server");
                    Ventura.Engine.HudPlayer.instance.active = true;
                    Ventura.Engine.HudPlayer.instance.OpenHUD();
                }, 4000);
            }*/
        }

    }

    class IntroductionSidePlane : Events.Script
    {
        public static IntroductionSidePlane instance = null;
        public uint fly_remoteid = 0;
        public string side = "";
        private long tick = 0;

        public IntroductionSidePlane() {
            instance = this;
            //Events.Tick += Tick;
            Events.Add("IntroductionSelect", IntroductionSelect);
            Events.Add("IntroductionTaskStreamUpdate", IntroductionTaskStreamUpdate);
        }


        private void IntroductionTaskStreamUpdate(object[] args)
        {
            uint remoteId = Convert.ToUInt16(args[0]);
            RAGE.Elements.Player player = RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == remoteId);

            if (player.GetSharedData("IntroductionTaskStream") == null)
            {
                player.SetData<string>("IntroductionTaskStream", null);
                return;
            }


            TaskSync result = JsonConvert.DeserializeObject<TaskSync>(args[1].ToString());
            if (result == null || player == null)
                return;
            player.SetData<string>("IntroductionTaskStream", args[1].ToString());
            //result.StreamIn();
        }

        private void IntroductionSelect(object[] args)
        {
            uint remoteId = Convert.ToUInt16(args[0]);
            Camera.RenderView(false, 1);
            Camera.ActiveMenuHud(true, true, true);
            fly_remoteid = remoteId;
            side = args[1].ToString();


            switch (side)
            {
                case "South":
                    RAGE.Elements.Player.LocalPlayer.Position = new Vector3(-2521.391f, -2264.896f, 127f);
                    //CAPI.CameraGestion(6);
                    break;
                case "North":
                    RAGE.Elements.Player.LocalPlayer.Position = new Vector3(257.2935f, 2849.016f, 275.5917f);
                    break;
            }
            Ventura.Engine.Card.instance.update = false;
            Ventura.Utils.OTicks.instance.AddClockToInstance(new Utils.OClock(0, 0, 8, 0, () => {
                Events.CallLocal("createBrowser", "IntroForm", "package://IntroServer/index.html");

                RAGE.Game.Graphics.StartScreenEffect("LostTimeNight", 100000, true);
                RAGE.Game.Cam.DoScreenFadeIn(2000);
                CAPI.CameraGestion(6);
            }));
        }

        /*private void Tick(List<Events.TickNametagData> nametags)
        {
            if (tick == 0)
                tick = DateTime.Now.AddMilliseconds(10).Ticks;

            if (DateTime.Now.Ticks > tick)
            {
                for (int i = 0; i < RAGE.Elements.Entities.Players.All.Count; i++) {

                    if (RAGE.Elements.Entities.Players.All[i].GetData<string>("IntroductionTaskStream") != null)
                    {
                        TaskSync sync = JsonConvert.DeserializeObject<TaskSync>(RAGE.Elements.Entities.Players.All[i].GetData<string>("IntroductionTaskStream"));
                        sync.StreamIn();
                    }
                }

                switch (side)
                {
                    case "South":
                        InFlyingSouth(null);
                        break;
                    case "North":
                        InFlyingNorth(null);
                        break;
                }
                tick = 0;
            }
        }*/


        public void InFlyingNorth(object[] args)
        {
            Vehicle sveh = Entities.Vehicles.All.Find(x => x.RemoteId == fly_remoteid);
            if (sveh != null && !RAGE.Elements.Player.LocalPlayer.IsInAnyVehicle(true))
            {
                /*Events.CallRemote("UpdateIntroductionTask", JsonConvert.SerializeObject(new TaskSync() {
                    RemoteId = RAGE.Elements.Player.LocalPlayer.RemoteId,
                    vRemoteId = sveh.RemoteId, leave = false, side = side }));*/
            }
            else if (sveh != null)
            {
                if (RAGE.Elements.Player.LocalPlayer.IsInVehicle(sveh.Handle, true)) {
                    if (RAGE.Elements.Player.LocalPlayer.GetSharedData("IntroductionTaskStream") != null) {

                    }
                }
                if (sveh.Position.DistanceTo(new Vector3(1719.3323f, 3254.657f, 41.25867f)) < 100f)
                {
                    CAPI.RenderView(false, 2000);
                }
                if (sveh.Position.DistanceTo(new Vector3(1719.3323f, 3254.657f, 41.25867f)) < 20f)
                {
                    //Events.CallRemote("UpdateIntroductionTask", JsonConvert.SerializeObject(new TaskSync() { RemoteId = RAGE.Elements.Player.LocalPlayer.RemoteId, vRemoteId = sveh.RemoteId, leave = true, side = side }));
                    side = "";
                }
            }
        }

        public void InFlyingSouth(object[] args)
        {
            Vehicle sveh = Entities.Vehicles.All.Find(x => x.RemoteId == fly_remoteid);
            if (sveh != null && !RAGE.Elements.Player.LocalPlayer.IsInAnyVehicle(true))
            {
                string tmp = null;
                Events.CallRemote("UpdateIntroductionTask", tmp = JsonConvert.SerializeObject(new TaskSync() {
                    RemoteId = RAGE.Elements.Player.LocalPlayer.RemoteId,
                    vRemoteId = sveh.RemoteId,
                    active = new List<bool>() { true, false, true, false },
                    side = side,
                    x = sveh.Position.X,
                    y = sveh.Position.Y,
                    z = sveh.Position.Z,
                    rx = sveh.GetRotation(1).X,
                    ry = sveh.GetRotation(1).Y,
                    rz = sveh.GetRotation(1).Z,
                    speed = sveh.GetSpeed(),
                }));
            }
            else if (sveh != null)
            {
                TaskSync sync = null;
                if (RAGE.Elements.Player.LocalPlayer.IsInVehicle(sveh.Handle, true) && RAGE.Elements.Player.LocalPlayer.GetSharedData("IntroductionTaskStream") != null)
                {
                    TaskSync tmp = null;
                    if (RAGE.Elements.Player.LocalPlayer.GetData<string>("IntroductionTaskStream") != null) {
                        tmp = JsonConvert.DeserializeObject<TaskSync>(RAGE.Elements.Player.LocalPlayer.GetData<string>("IntroductionTaskStream"));
                    }
                    sync = JsonConvert.DeserializeObject<TaskSync>(RAGE.Elements.Player.LocalPlayer.GetSharedData("IntroductionTaskStream").ToString());
                    sync.x = sveh.Position.X;
                    sync.y = sveh.Position.Y;
                    sync.z = sveh.Position.Z;
                    sync.rx = sveh.GetRotation(1).X;
                    sync.ry = sveh.GetRotation(1).Y;
                    sync.rz = sveh.GetRotation(1).Z;
                    sync.speed = sveh.GetSpeed();
                    if (tmp != null)
                        sync.active = tmp.active;
                    RAGE.Elements.Player.LocalPlayer.SetData<string>("IntroductionTaskStream", JsonConvert.SerializeObject(sync));
                    Events.CallRemote("UpdateIntroductionTask", JsonConvert.SerializeObject(sync));

                }
                if (sveh.Position.DistanceTo(new Vector3(-1219.258f, -3017.728f, 14.1612f)) < 100f)
                {
                    CAPI.RenderView(false, 2000);
                }
                if (sveh.Position.DistanceTo(new Vector3(-1219.258f, -3017.728f, 14.1612f)) < 20f)
                {
                    sync = JsonConvert.DeserializeObject<TaskSync>(RAGE.Elements.Player.LocalPlayer.GetSharedData("IntroductionTaskStream").ToString());
                    sync.active[1] = true;
                    Events.CallRemote("UpdateIntroductionTask", JsonConvert.SerializeObject(sync));
                    side = "";
                }

            }
        }


    }

    class Introduction : Events.Script
    {
        public static Introduction instance = null;

        int index = 1;
        int time = 0;
        int camera;
        long tick = 0;
        bool[] active = new bool[3] { false, false, false };
        private string data_name_c = main_client.Ventura.Constant.Constant.table_data_name[((int)main_client.Ventura.Constant.Constant.UpdateFlagsClient.WorldClothData >> 2) - 1];
        private string data_name_b = main_client.Ventura.Constant.Constant.table_data_name[((int)main_client.Ventura.Constant.Constant.UpdateFlagsClient.WorldBodyData >> 2) - 1];

        public Introduction()
        {
            Events.Add("CEFCharacterEditorCommand", CEFCharacterEditorCommand);
            Events.Add("CEFCharacterEditorTenue", CEFCharacterEditorTenue);
            Events.Add("CEFCharacterEditorReset", CEFCharacterEditorReset);
            Events.Add("CEFCharacterEditorSave", CEFCharacterEditorSave);
            instance = this;
        }

        private void CEFCharacterEditorTenue(object[] args)
        {
            List<int[]> cloth = JsonConvert.DeserializeObject<List<int[]>>((string)args[0]);
            var stream = JsonConvert.DeserializeObject<StreamObject.WorldData.WorldClothData>((string)RAGE.Elements.Player.LocalPlayer.GetSharedData(data_name_c));

            for (int i = 0; i < cloth.Count; i++)
            {
                stream.cloth[i][0] = cloth[i][0];
                stream.cloth[i][1] = cloth[i][1];
            }
            Events.CallRemote("UpdateWorldClothData", JsonConvert.SerializeObject(stream));
        }

        public void CEFCharacterEditorReceive()
        {
            var body = JsonConvert.DeserializeObject<StreamObject.WorldData.WorldBodyData>((string)RAGE.Elements.Player.LocalPlayer.GetSharedData(data_name_b));
            var stream = JsonConvert.DeserializeObject<StreamObject.WorldData.WorldClothData>((string)RAGE.Elements.Player.LocalPlayer.GetSharedData(data_name_c));

            CEFCharacterEditor data = new CEFCharacterEditor();
            data.gender = body.sex;
            data.father = body.ShapeFirst;
            data.mother = body.ShapeSecond;
            data.hair = stream.cloth[2][0];
            data.hair_color = body.firstHeadShape;
            data.grandparent = body.ShapeSecond;
            data.skinMix = body.skinMix;
            data.heridity = body.ShapeMix;
            data.heridityparent = body.ThirdMix;
            for (int i = 0; i < body.headOverlay.Count; i++) {
                switch (i)
                {
                    case 0:
                        data.sourcils = (int)body.headOverlay[i][0];
                        data.sourcils_color = (int)body.headOverlay[i][1];
                        break;
                    case 1:

                        data.barbes = (int)body.headOverlay[i][0];
                        data.barbes_color = (int)body.headOverlay[i][1];
                        break;
                    case 2:
                        data.poils = (int)body.headOverlay[i][0];
                        data.poils_color = (int)body.headOverlay[i][1];
                        break;
                    case 3:
                        data.skinSick = (int)body.headOverlay[i][0];
                        break;
                    case 4:
                        data.vieille = (int)body.headOverlay[i][0];
                        break;
                    case 5:
                        data.teint = (int)body.headOverlay[i][0];
                        break;
                    case 6:
                        data.taches = (int)body.headOverlay[i][0];
                        break;
                    case 7:
                        data.aspect = (int)body.headOverlay[i][0];
                        break;
                    case 8:
                        data.makeup = (int)body.headOverlay[i][0];
                        data.makeup_color = (int)body.headOverlay[i][1];
                        break;
                    case 9:
                        data.blush = (int)body.headOverlay[i][0];
                        data.blush_color = (int)body.headOverlay[i][1];
                        break;
                    case 10:

                        break;
                }
            }
            data.eyes = body.eyesColor;
            data.degrade = body.overlayHair;
            data.facefeature = body.facefeature;
            data.decoration = body.decoration;
            data.facialDecoration = body.facialDecoration;
            Events.CallLocal("executeFunction", "CharacterEditorForm", "UpdateCharacterBodyValues", JsonConvert.SerializeObject(data));
        }

        private void CEFCharacterEditorReset(object[] args)
        {
           Events.CallRemote("ResetData", data_name_b);
           Events.CallRemote("ResetData", data_name_c);
        }

        private void CEFCharacterEditorSave(object[] args)
        {
           Events.CallRemote("SaveData", data_name_b);
           Events.CallRemote("SaveData", data_name_c);
        }

        private void CEFCharacterEditorCommand(object[] args)
        {
            var data = JsonConvert.DeserializeObject<CEFCharacterEditor>((string)args[0]);
            var body = JsonConvert.DeserializeObject<StreamObject.WorldData.WorldBodyData>((string)RAGE.Elements.Player.LocalPlayer.GetSharedData(data_name_b));
            var clothData = JsonConvert.DeserializeObject<StreamObject.WorldData.WorldClothData>((string)RAGE.Elements.Player.LocalPlayer.GetSharedData(data_name_c));

            body.sex = data.gender;
            body.ShapeFirst = Convert.ToByte(data.father);
            body.ShapeSecond = Convert.ToByte(data.mother);
            body.ShapeThird = Convert.ToByte(data.grandparent);
            body.skinMix = data.skinMix;
            body.ShapeMix = data.heridity;
            body.ThirdMix = data.heridityparent;
            clothData.cloth[2][0] = data.hair;
            body.firstHeadShape = data.hair_color;
            body.headOverlay = new List<List<float>>() {
                new List<float> { data.sourcils, data.sourcils_color, 0 },
                new List<float> { data.barbes, data.barbes_color, 0 },
                new List<float> { data.poils, data.poils_color, 0 },
                new List<float> { data.skinSick, 0, 0 },
                new List<float> { data.vieille, 0, 0 },
                new List<float> { data.teint, 0, 0 },
                new List<float> { data.taches, 0, 0 },
                new List<float> { data.aspect, 0, 0 },
                new List<float> { data.makeup, data.makeup_color, 0 },
                new List<float> { data.blush, data.blush_color, 0 },
            };
            body.eyesColor = data.eyes;
            body.overlayHair = data.degrade;
            body.facefeature = data.facefeature;
            body.decoration = data.decoration;
            body.facialDecoration = data.facialDecoration;
            Events.CallRemote("UpdateWorldBodyData", JsonConvert.SerializeObject(body));
            Events.CallRemote("UpdateWorldClothData", JsonConvert.SerializeObject(clothData));
        }

        public void CharacterIntroEditor(object[] args)
        {
            PAPI.PedGestion(0);
            AAPI.AnimationGestion(0);
            Ventura.Utils.OTicks.instance.AddClockToInstance(new Utils.OClock(0, 0, 10, 0, () => {
                active[0] = true;
                CEFCharacterEditorReceive();
            }));
        }

        public void StartClock()
        {
            if (tick == 0)
                tick = DateTime.Now.AddMilliseconds(200).Ticks;
        }

        public void OnTick()
        {
            StartClock();
            if (active[0])
            {
                if (RAGE.Input.IsDown((int)ConsoleKey.A) && DateTime.Now.Ticks > tick && index != -1)
                {
                    switch (index)
                    {
                        case 0:
                            AAPI.AnimationGestion(1);
                            index--;
                            break;
                        case 1:
                            AAPI.AnimationGestion(4);
                            index--;
                            break;
                    }
                    tick = 0;
                }
                else if (RAGE.Input.IsDown((int)ConsoleKey.E) && DateTime.Now.Ticks > tick && index != 1)
                {
                    switch (index)
                    {
                        case -1:
                            AAPI.AnimationGestion(2);
                            index++;
                            break;
                        case 0:
                            AAPI.AnimationGestion(3);
                            index++;
                            break;
                    }
                    tick = 0;
                }
                else if (RAGE.Input.IsDown((int)ConsoleKey.Z) && DateTime.Now.Ticks > tick && camera != 0)
                {
                    CAPI.CameraGestion(0);
                    camera = 0;
                    tick = 0;
                }
                else if (RAGE.Input.IsDown((int)ConsoleKey.D) && DateTime.Now.Ticks > tick && camera != 2)
                {
                    CAPI.CameraGestion(2);
                    camera = 2;
                    tick = 0;
                }
                else if (RAGE.Input.IsDown((int)ConsoleKey.S) && DateTime.Now.Ticks > tick && camera != 1)
                {
                    CAPI.CameraGestion(1);
                    camera = 1;
                    tick = 0;
                }
                else if (RAGE.Input.IsDown((int)ConsoleKey.Q) && DateTime.Now.Ticks > tick && camera != 3)
                {
                    CAPI.CameraGestion(3);
                    camera = 3;
                    tick = 0;
                }
                else if (RAGE.Input.IsDown((int)ConsoleKey.W) && DateTime.Now.Ticks > tick && camera != 4)
                {
                    CAPI.CameraGestion(4);
                    camera = 4;
                    tick = 0;
                }
                else if (RAGE.Input.IsDown((int)ConsoleKey.N) && DateTime.Now.Ticks > tick)
                {
                    if (time == 0)
                    {
                        Constant.Constant.Notify("Vous êtes sur de vouloir faire ce personnage ? Si oui réapuyer sur ~p~N~w~");
                        time++;
                    }
                    else
                    {
                        Events.CallRemote("SaveData", data_name_b);
                        Events.CallRemote("SaveData", data_name_c);
                        Events.CallLocal("destroyBrowser", "CharacterEditorForm");
                        Ventura.Engine.Card.instance.ActiveCardIdInput();
                        active[0] = false;
                    }
                    tick = 0;
                }
            }
        }

    }
}
