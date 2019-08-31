using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using RAGE;
using RAGE.NUI;
//using Newtonsoft.Json;
using System.Threading.Tasks;
//using AAPI = main_client.Animation.Animation;
//using CAPI = main_client.Camera.Camera;
//using PAPI = main_client.Ped.Ped;
using RAGE.Elements;

namespace main_client.Player.Character
{

    /*class SkinInfo
    {
        public int gender { get; set; }
        public int father { get; set; }
        public int mother { get; set; }
        public int heredity { get; set; }
        public int skin { get; set; }
        public int eye_colors { get; set; }
        public int hat { get; set; }
        public int haut { get; set; }
        public int bas { get; set; }
        public int shoes { get; set; }
    }


    class CharacterEditor : Events.Script
    {
        int camera = 0;
        int index = 1;
        int timer = 0;
        int iterator = 0;
        int scaleform = 0;
        int renderId = 0;
        string side = "";
        bool[] active = new bool[3] { false, false, false };

        public static string inf = "";
        MapObject board = null;
        MapObject text = null;


        int iteratorParent = 0;
        List<int> variable = new List<int>();
        List<float> fvariable = new List<float>();

        public CharacterEditor()
        {
            for (int i = 0; i < 22; i++)
            {
                variable.Add(0);
                fvariable.Add(0);
            }

            Events.Add("setCharacter", setCharacter);
            Events.Add("setIDCharacter", setIDCharacter);
            Events.Add("setSelectIntroduction", setSelectIntroduction);
            Events.Add("CharacterIntro", character_intro_editor);
            Events.Add("SetCharacterActives", SetCharacterActives);
            Events.Add("attach_board_on_player", attach_board_on_player);
            Events.Tick += Tick;
        }

        private void setSelectIntroduction(object[] args)
        {
            Chat.Output("Test " + args[0].ToString());
            side = args[0].ToString();
            Events.CallLocal("destroyBrowser", "SelectIntro");
            Events.CallRemote("IfPlayerCanEnter", args[0].ToString());
            active[2] = true;
            RAGE.Ui.Cursor.Visible = false;
            RAGE.Game.Cam.DoScreenFadeOut(1);
        }

        private void setIDCharacter(object[] args)
        {

            Events.CallRemote("AddIdCard", args[0].ToString());
            Events.CallLocal("destroyBrowser", "card_id");
            Chat.Output(args[0].ToString());
            PAPI.PedGestion(1);
            
            Utils.ThreadingTask.make_task_with_timeout(() =>
            {
                Events.CallLocal("createBrowser", "SelectIntro", "package://SelectIntro/index.html");
            }, 6000);

        }

        private void attach_board_on_player(object[] args)
        {
            board = new RAGE.Elements.MapObject(RAGE.Game.Misc.GetHashKey("prop_police_id_board"), new Vector3(402.9378f, -998.05f, -98.85f), new Vector3(), 255, RAGE.Elements.Player.LocalPlayer.Dimension);
            text = new RAGE.Elements.MapObject(RAGE.Game.Misc.GetHashKey("prop_police_id_text"), new Vector3(402.9378f, -998.05f, -98.85f), new Vector3(), 255, RAGE.Elements.Player.LocalPlayer.Dimension);
            scaleform = RAGE.Game.Graphics.RequestScaleformMovie("mugshot_board_01");
            while (!RAGE.Game.Graphics.HasScaleformMovieLoaded(scaleform)) RAGE.Game.Invoker.Wait(0);
            RAGE.Game.Graphics.PushScaleformMovieFunction(scaleform, "SET_BOARD");
            RAGE.Game.Graphics.PushScaleformMovieFunctionParameterString("Welcome");
            RAGE.Game.Graphics.PushScaleformMovieFunctionParameterString("To");
            RAGE.Game.Graphics.PushScaleformMovieFunctionParameterString("Ventura");
            RAGE.Game.Graphics.PushScaleformMovieFunctionParameterString(Utils.GenerateIntro.intro_id_card());
            RAGE.Game.Graphics.PushScaleformMovieFunctionParameterInt(0);
            RAGE.Game.Graphics.PushScaleformMovieFunctionParameterInt(15);
            RAGE.Game.Graphics.PopScaleformMovieFunction();

            RAGE.Game.Ui.RegisterNamedRendertarget("ID_Text", false);
            RAGE.Game.Ui.LinkNamedRendertarget(RAGE.Game.Misc.GetHashKey("prop_police_id_text"));
            renderId = RAGE.Game.Ui.GetNamedRendertargetRenderId("ID_Text");
        }

        private void SetCharacterActives(object[] args)
        {
            active[(int)args[0]] = (bool)args[1];
        }

        public int[] fathers = new int[24] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 42, 43, 44};
        public int[] mothers = new int[22] { 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 45 };

        public enum AnimationFlags
        {
            Loop = 1 << 0,
            StopOnLastFrame = 1 << 1,
            OnlyAnimateUpperBody = 1 << 4,
            AllowPlayerControl = 1 << 5,
            Cancellable = 1 << 7
        };

        int chair = 0;

        private void setCharacter(object[] args)
        {
            //SkinInfo info = JsonConvert.DeserializeObject<SkinInfo>((string)args[0]);
            inf = (string)args[0];
            Chat.Output(inf);
            Events.CallRemote("setCharacterServer", inf);
            Events.CallRemote("StartAnimation", "mp_character_creation@customise@male_a", "loop", 1f);
            RAGE.Elements.Player.LocalPlayer.Position = new Vector3(402.9012f, -996.8196f, -99.00024f);
            Random rand = new Random();
            //RAGE.Game.Streaming.RequestAnimDict("doors@");

            //while (!RAGE.Game.Streaming.HasAnimDictLoaded("doors@")) { RAGE.Game.Invoker.Wait(0); }

            //RAGE.Game.Ai.TaskPlayAnim(RAGE.Elements.Player.LocalPlayer.Handle, "doors@", "door_sweep_r_hand_medium", 8f, 1, -1, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl) , 0, false, false, false);

            /*if (chair == 0)
                chair = RAGE.Game.Object.CreateObject(RAGE.Game.Misc.GetHashKey("p_yacht_chair_01_s"), RAGE.Elements.Player.LocalPlayer.Position.X + 1, RAGE.Elements.Player.LocalPlayer.Position.Y, RAGE.Elements.Player.LocalPlayer.Position.Z - 1, false, false, true);

            int scene = RAGE.Game.Ped.CreateSynchronizedScene(RAGE.Elements.Player.LocalPlayer.Position.X, RAGE.Elements.Player.LocalPlayer.Position.Y, RAGE.Elements.Player.LocalPlayer.Position.Z, 0f, 0f, RAGE.Elements.Player.LocalPlayer.GetHeading(), 2);
            RAGE.Game.Ai.TaskSynchronizedScene(RAGE.Elements.Player.LocalPlayer.Handle, scene, "anim@amb@office@boardroom@boss@male@", "base", 1.5f, -1.5f, 13, 16, 1.5f, 4);

            bool a = RAGE.Game.Invoker.Invoke<bool>(0xEEA929141F699854, RAGE.Elements.Player.LocalPlayer.Handle, scene, "anim@amb@office@boardroom@boss@male@", "base", 1.5f, -1.5f, 13, 16, 1.5f, 4);
            bool b = RAGE.Game.Invoker.Invoke<bool>(0xC77720A12FE14A86, chair, scene, "base_chair", "anim@amb@office@boardroom@boss@male@", 4f, -4f, 32781, 1000f);
            RAGE.Game.Ped.AttachSynchronizedSceneToEntity(scene, chair, 0);
            //Chat.Output(a + " " + b + " " + scene + " " + PAPI.GetPedByClient("cops_A").Handle);
            */
    //RAGE.Game.Streaming.RequestModel(0x9C9EFFD8);
    //while (!RAGE.Game.Streaming.HasModelLoaded(0x9C9EFFD8)) { RAGE.Game.Invoker.Wait(0); }
    //RAGE.Game.Streaming.Mo
    //RAGE.Game.Player.SetPlayerModel(0x9C9EFFD8);
    //RAGE.Game.Ped.SetPedDefaultComponentVariation(RAGE.Elements.Player.LocalPlayer.Handle);
    //RAGE.Game.Ped.SetPedBlendFromParents(RAGE.Elements.Player.LocalPlayer.Handle, 0, 0, 0, 0);

    // RAGE.Game.Invoker.Invoke(0x262B14F48D29DE80, RAGE.Elements.Player.LocalPlayer.Handle, 0, 31, 0, 0);
    //RAGE.Game.Ped.SetPedComponentVariation(RAGE.Elements.Player.LocalPlayer.Handle, 0, 31, 0, 0);
    /*RAGE.Elements.Player.LocalPlayer.Model = 0x9C9EFFD8;
    RAGE.Game.Ped.SetPedComponentVariation(RAGE.Elements.Player.LocalPlayer.Handle, 1, 0, 0, 1);
    RAGE.Game.Ped.SetPedComponentVariation(RAGE.Elements.Player.LocalPlayer.Handle, 3, 32, 0, 3);
    RAGE.Game.Ped.SetPedComponentVariation(RAGE.Elements.Player.LocalPlayer.Handle, 4, 14, 0, 4);
    RAGE.Game.Ped.SetPedComponentVariation(RAGE.Elements.Player.LocalPlayer.Handle, 6, 4, 0, 6);
    RAGE.Game.Ped.SetPedComponentVariation(RAGE.Elements.Player.LocalPlayer.Handle, 8, 159, 0, 8);
    RAGE.Game.Ped.SetPedComponentVariation(RAGE.Elements.Player.LocalPlayer.Handle, 11, 260, 0, 11);

    RAGE.Game.Ped.SetPedBlendFromParents(RAGE.Elements.Player.LocalPlayer.Handle, rand.Next(0, 20), rand.Next(0, 20), (float)rand.NextDouble(), (float)rand.NextDouble());

    for (int i = 0; i < 1000; i++)
    {
        RAGE.Game.Ped.SetPedDecoration(RAGE.Elements.Player.LocalPlayer.Handle, Convert.ToUInt16(rand.Next(0, 255)), Convert.ToUInt16(rand.Next(0, 255)));
        RAGE.Game.Ped.SetPedFacialDecoration(RAGE.Elements.Player.LocalPlayer.Handle, Convert.ToUInt16(rand.Next(0, 255)), Convert.ToUInt16(rand.Next(0, 255)));
        RAGE.Game.Ped.SetPedFaceFeature(RAGE.Elements.Player.LocalPlayer.Handle, rand.Next(0, 19), (float)rand.NextDouble());
        RAGE.Game.Ped.SetPedHeadOverlay(RAGE.Elements.Player.LocalPlayer.Handle, rand.Next(0, 60), rand.Next(0, 60), 1);
        RAGE.Game.Ped.SetPedHeadOverlayColor(RAGE.Elements.Player.LocalPlayer.Handle, rand.Next(0, 60), rand.Next(0, 2), rand.Next(0, 60), rand.Next(0, 60));
        RAGE.Game.Ped.SetPedHeadBlendData(RAGE.Elements.Player.LocalPlayer.Handle, rand.Next(0, 60), rand.Next(0, 60), rand.Next(0, 60), rand.Next(0, 60), rand.Next(0, 60), rand.Next(0, 60), (float)rand.NextDouble(), (float)rand.NextDouble(), (float)rand.NextDouble(), rand.Next(0, 1) == 1 ? true : false);
        RAGE.Game.Ped.SetPedComponentVariation(RAGE.Elements.Player.LocalPlayer.Handle, 2, rand.Next(0, 50), 0, rand.Next(0, 12));
        //RAGE.Game.Ped.SetPedComponentVariation(RAGE.Elements.Player.LocalPlayer.Handle, i, rand.Next(0, 30), rand.Next(0, 30), rand.Next(0, 30));
        RAGE.Game.Ped.SetPedHairColor(RAGE.Elements.Player.LocalPlayer.Handle, rand.Next(0, 100), rand.Next(0, 100));
        RAGE.Game.Ped.SetPedEyeColor(RAGE.Elements.Player.LocalPlayer.Handle, rand.Next(0, 30));

    }
    RAGE.Game.Ped.SetPedDesiredHeading(RAGE.Elements.Player.LocalPlayer.Handle, 0);

    RAGE.Elements.Player.LocalPlayer.SetHeading(180f);
    //RAGE.Game.Ped.SetPedConfigFlag(RAGE.Elements.Player.LocalPlayer.Handle, ra)
    //RAGE.Game.Ped.SetPedHelmet
    //RAGE.Game.Ped.SetPedHelmetFlag
    //RAGE.Game.Ped.SetPedHelmetPropIndex
    //RAGE.Game.Ped.SetPedHelmetTextureIndex
    //RAGE.Game.Ped.SetPedMotionBlur
    //RAGE.Game.Ped.SetPedMovementClipset
    //RAGE.Game.Ped.SetPedPropIndex
    //RAGE.Game.Ped.SetPedRagdollBlockingFlags
    //RAGE.Game.Ped.CreateSynchronizedScene


    //RAGE.Elements.Player.LocalPlayer.SetBlendFromParents(info.father, info.mother, info.heredity, info.skin);
    //RAGE.Elements.Player.LocalPlayer.SetEyeColor(info.eye_colors);
    //RAGE.Elements.Player.LocalPlayer.SetHeadBlendData(mothers[info.mother], fathers[info.father], 0, mothers[info.mother], fathers[info.father], 0, info.heredity * 0.01f, info.skin * 0.01f, 0, false);
    //RAGE.Elements.Player.LocalPlayer.GetHeadOverlayValue(0);
    //RAGE.Elements.Player.LocalPlayer.head
    //RAGE.Elements.Player.LocalPlayer.SetHeadOverlay(2, 1, 0.4f);
}

public void local_character() {
    /*Chat.Output("Cursor "+iteratorParent+" current value "+variable[iteratorParent]+" float current value "+fvariable[iteratorParent]);

    Events.CallRemote("StartAnimation", "mp_character_creation@customise@male_a", "loop", 1f);
    RAGE.Elements.Player.LocalPlayer.Model = 0x9C9EFFD8;
    RAGE.Elements.Player.LocalPlayer.SetComponentVariation(0, 31, 0, 0);

    RAGE.Game.Ped.SetPedBlendFromParents(RAGE.Elements.Player.LocalPlayer.Handle, variable[0], variable[1], fvariable[0], fvariable[1]);
    RAGE.Game.Ped.SetPedComponentVariation(RAGE.Elements.Player.LocalPlayer.Handle, 0, 0, 0, 0);
    RAGE.Game.Ped.SetPedComponentVariation(RAGE.Elements.Player.LocalPlayer.Handle, 1, 0, 0, 1);
    RAGE.Game.Ped.SetPedComponentVariation(RAGE.Elements.Player.LocalPlayer.Handle, 3, 32, 0, 3);
    RAGE.Game.Ped.SetPedComponentVariation(RAGE.Elements.Player.LocalPlayer.Handle, 4, 14, 0, 4);
    RAGE.Game.Ped.SetPedComponentVariation(RAGE.Elements.Player.LocalPlayer.Handle, 6, 4, 0, 6);
    RAGE.Game.Ped.SetPedComponentVariation(RAGE.Elements.Player.LocalPlayer.Handle, 8, 159, 0, 8);
    RAGE.Game.Ped.SetPedComponentVariation(RAGE.Elements.Player.LocalPlayer.Handle, 11, 260, 0, 11);
    RAGE.Game.Ped.SetPedDecoration(RAGE.Elements.Player.LocalPlayer.Handle, Convert.ToUInt16(variable[2]), Convert.ToUInt16(variable[3]));
    RAGE.Game.Ped.SetPedFacialDecoration(RAGE.Elements.Player.LocalPlayer.Handle, Convert.ToUInt16(variable[4]), Convert.ToUInt16(variable[5]));
    RAGE.Game.Ped.SetPedFaceFeature(RAGE.Elements.Player.LocalPlayer.Handle, variable[5], fvariable[2]);
    RAGE.Game.Ped.SetPedHeadOverlay(RAGE.Elements.Player.LocalPlayer.Handle, variable[6], variable[7], fvariable[3]);
    RAGE.Game.Ped.SetPedHeadOverlayColor(RAGE.Elements.Player.LocalPlayer.Handle, variable[8], variable[9], variable[10], variable[11]);
    //RAGE.Game.Ped.SetPedBlendFromParents(RAGE.Elements.Player.LocalPlayer.Handle, rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
    RAGE.Game.Ped.SetPedHeadBlendData(RAGE.Elements.Player.LocalPlayer.Handle, variable[12], variable[13], variable[14], variable[15], variable[16], variable[17], fvariable[4], fvariable[5], fvariable[6], false);
    RAGE.Game.Ped.SetPedComponentVariation(RAGE.Elements.Player.LocalPlayer.Handle, 2, variable[18], 0, 0);
    //RAGE.Game.Ped.SetPedComponentVariation(RAGE.Elements.Player.LocalPlayer.Handle, i, rand.Next(0, 30), rand.Next(0, 30), rand.Next(0, 30));
    RAGE.Game.Ped.SetPedHairColor(RAGE.Elements.Player.LocalPlayer.Handle, variable[19], variable[20]);
    RAGE.Game.Ped.SetPedEyeColor(RAGE.Elements.Player.LocalPlayer.Handle, variable[21]);
    RAGE.Game.Ped.SetPedDesiredHeading(RAGE.Elements.Player.LocalPlayer.Handle, 0);
    RAGE.Elements.Player.LocalPlayer.SetHeading(180f);
}


public void character_intro_editor(object[] args)
{
    PAPI.PedGestion(0);
    AAPI.AnimationGestion(0);
    Utils.ThreadingTask.make_task_with_timeout(() =>
    {
        active[0] = true;
    }, 8000);
}


public void Tick(List<Events.TickNametagData> nametags)
{
    if (board != null && !RAGE.Game.Entity.IsEntityAttached(board.Handle))
    {
        if (active[2] && board != null)
            board.Destroy();
        //RAGE.Elements.Player.LocalPlayer.SetHeading(180f);
        RAGE.Game.Entity.AttachEntityToEntity(board.Handle, RAGE.Elements.Player.LocalPlayer.Handle, RAGE.Elements.Player.LocalPlayer.GetBoneIndex(28422), 0, 0, 0, 0, 0, 0, false, false, false, false, 2, true);
    }
    if (text != null && !RAGE.Game.Entity.IsEntityAttached(text.Handle))
    {
        if (active[2] && text != null)
            text.Destroy();
        RAGE.Game.Entity.AttachEntityToEntity(text.Handle, RAGE.Elements.Player.LocalPlayer.Handle, RAGE.Elements.Player.LocalPlayer.GetBoneIndex(28422), 0, 0, 0, 0, 0, 0, false, false, false, false, 2, true);
    }
    if (active[2]) {
        active[0] = false;
        if (timer == 0)
        {
            Chat.Output("call");
            Events.CallRemote("IfPlayerCanEnter", side);
            timer++;
        }
        else if (timer != 0 && timer <= 200)
        {
            timer++;
        }
        else if (timer >= 200)
            timer = 0;
    }
    if (active[0])
    {
        if (RAGE.Input.IsDown((int)ConsoleKey.P) && timer == 0)
        {
            iteratorParent++;
            local_character();
            timer++;
        }
        else if (RAGE.Input.IsDown((int)ConsoleKey.O) && timer == 0)
        {
            variable[iteratorParent]++;
            local_character();
            timer++;
        }
        else if (RAGE.Input.IsDown((int)ConsoleKey.L) && timer == 0)
        {
            variable[iteratorParent]--;
            local_character();
            timer++;
        }
        else if (RAGE.Input.IsDown((int)ConsoleKey.M) && timer == 0)
        {
            iteratorParent--;
            local_character();
            timer++;
        }
        else if (RAGE.Input.IsDown((int)ConsoleKey.I) && timer == 0)
        {
            fvariable[iteratorParent] += 0.05f;
            local_character();
            timer++;
        }
        else if (RAGE.Input.IsDown((int)ConsoleKey.K) && timer == 0)
        {
            fvariable[iteratorParent] -= 0.05f;
            local_character();
            timer++;
        }
        else if (RAGE.Input.IsDown((int)ConsoleKey.A) && timer == 0 && index != -1)
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
            timer++;
        } else if (RAGE.Input.IsDown((int)ConsoleKey.E) && timer == 0 && index != 1)
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
            timer++;
        }
        else if (RAGE.Input.IsDown((int)ConsoleKey.Z) && timer == 0 && camera != 0)
        {
            CAPI.CameraGestion(0);
            camera = 0;
            timer++;
        }
        else if (RAGE.Input.IsDown((int)ConsoleKey.D) && timer == 0 && camera != 2)
        {
            CAPI.CameraGestion(2);
            camera = 2;
            timer++;
        }
        else if (RAGE.Input.IsDown((int)ConsoleKey.S) && timer == 0 && camera != 1)
        {
            CAPI.CameraGestion(1);
            camera = 1;
            timer++;
        }
        else if (RAGE.Input.IsDown((int)ConsoleKey.Q) && timer == 0 && camera != 3)
        {
            CAPI.CameraGestion(3);
            camera = 3;
            timer++;
        }
        else if (RAGE.Input.IsDown((int)ConsoleKey.W) && timer == 0 && camera != 4)
        {
            CAPI.CameraGestion(4);
            camera = 4;
            timer++;
        }
        else if (RAGE.Input.IsDown((int)ConsoleKey.T) && timer == 0 && camera != 4)
        {
            active[1] = !active[1];
            RAGE.Ui.Cursor.Visible = active[1];
            timer++;
        }

        else if (RAGE.Input.IsDown((int)ConsoleKey.N) && timer == 0)
        {
            Events.CallLocal("executeFunction", "editor_character", "save");
            Events.CallLocal("destroyBrowser", "editor_character");
            Events.CallLocal("createBrowser", "card_id", "package://IdCard/index.html");
            Events.CallLocal("executeFunction", "card_id", "input");
            timer++;
        }

        if (timer != 0 && timer <= 10)
            timer++;
        if (timer == 10)
            timer = 0;
    }

    if (scaleform != 0 && renderId != 0)
    {
        RAGE.Game.Ui.SetTextRenderId(renderId);
        RAGE.Game.Graphics.DrawScaleformMovie(scaleform, 0.405f, 0.37f, 0.81f, 0.74f, 255, 255, 255, 255, 0);
        RAGE.Game.Ui.SetTextRenderId(1);
    }
}

/*private void intro(object[] args)
{
    //RAGE.Elements.Player.LocalPlayer.Position = new Vector3((float)402.8664, (float)-996.4108, (float)-99.00027);
    RAGE.Elements.Player.LocalPlayer.Position = new Vector3(409.1245f, -997.5353f, -99.0041f);
    RAGE.Elements.Player.LocalPlayer.FreezePosition(false);
    //RAGE.Elements.Player.LocalPlayer.SetHeading(176.891f);
    RAGE.Elements.Player.LocalPlayer.SetHeading(-90f);

    Events.CallRemote("StartAnimation", "mp_character_creation@lineup@male_a", "loop_raised", 8f);

    if (tmp == null)
    {
        tmp = new RAGE.Elements.Ped[2];
        //tmp[0] = new RAGE.Elements.Ped(RAGE.Game.Misc.GetHashKey("ArmyMech01SMY"), new Vector3(409.1245f, -997.5353f, -99.0041f), 0, RAGE.Elements.Player.LocalPlayer.Dimension);
        tmp[1] = new RAGE.Elements.Ped(RAGE.Game.Misc.GetHashKey("ArmyMech01SMY"), new Vector3(409.1245f, -999.7f, -99.0041f), 0, RAGE.Elements.Player.LocalPlayer.Dimension);
    }

    //tmp[0].SetRotation(0, 0, -90, 0, false);
    tmp[1].SetRotation(0, 0, -90, 0, false);

    RAGE.Game.Streaming.RequestAnimDict(data_anim[3]);
    while (!RAGE.Game.Streaming.HasAnimDictLoaded(data_anim[3])) RAGE.Game.Invoker.Wait(0);

    tmp[1].TaskPlayAnim(data_anim[3], data_anim[4], 8.0f, -8.0f, -1, 1, 0.0f, false, false, false);
    //tmp[0].TaskPlayAnim(data_anim[3], data_anim[4], 8.0f, -8.0f, -1, 1, 0.0f, false, false, false);

    int s_cam = RAGE.Game.Cam.CreateCameraWithParams(RAGE.Game.Misc.GetHashKey("DEFAULT_SCRIPTED_CAMERA"), 415.8449f, -998.3865f, -99.40415f, 0.0f, 0.0f, 90f, 90, true, 2);
    RAGE.Game.Cam.PointCamAtCoord(s_cam, 415.8449f, -998.3865f, -99.40415f);
    RAGE.Game.Cam.SetCamActive(s_cam, true);

    int e_cam = RAGE.Game.Cam.CreateCameraWithParams(RAGE.Game.Misc.GetHashKey("DEFAULT_SCRIPTED_CAMERA"), 414.8395f, -998.763f, -99.2f, 0.0f, 0.0f, 90f, 50, true, 2);
    RAGE.Game.Cam.PointCamAtCoord(s_cam, 409.7778f, -998.3335f, -98.8f);
    RAGE.Game.Cam.SetCamActiveWithInterp(e_cam, s_cam, 6000, 0, 0);
    RAGE.Game.Cam.RenderScriptCams(true, false, 4000, true, false, 0);
    Events.CallLocal("createBrowser", "IntroPage",  "package://IntroServer/index.html");
    Events.CallLocal("destroyBrowser", "editor_character");
    RAGE.Game.Invoker.Wait(6000);
    character_out();

    //Utils.ThreadingTask.make_task_with_timeout(character_out, 6000);
}

}*/
}
