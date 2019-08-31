using System;
using System.Collections.Generic;
using System.Text;
using RAGE;

namespace main_client.Ventura.Engine
{
    class Camera : Events.Script 
    {
        public delegate void CameraFunction();
        public static Dictionary<string, int> list_camera = new Dictionary<string, int>();
        public static List<CameraFunction> list_function = new List<CameraFunction>();


        public Camera()
        {
            list_function.Add(Head);
            list_function.Add(Torso);
            list_function.Add(Legs);
            list_function.Add(Feet);
            list_function.Add(Body);
            list_function.Add(SelectMovieIntroduction);
            list_function.Add(SouthMoviesIntroduction);
        }

        public static void AddModCameraToClientWithParams(string name, Vector3 pos, Vector3 rot, float fov = 60, int order = 1, bool p8 = true, int p9 = 2)
        {
            if (list_camera.ContainsKey(name) == false)
            {
                list_camera.Add(name, RAGE.Game.Cam.CreateCameraWithParams(RAGE.Game.Misc.GetHashKey("DEFAULT_SCRIPTED_CAMERA"), pos.X, pos.Y, pos.Z, rot.X, rot.Y, rot.Z, fov, p8, p9));
            }
            else {
                int cam = list_camera[name];
                RAGE.Game.Cam.SetCamCoord(cam, pos.X, pos.Y, pos.Z);
                RAGE.Game.Cam.SetCamRot(cam, rot.X, rot.Y, rot.Z, order);
                RAGE.Game.Cam.SetCamFov(cam, fov);
            }
        }

        public static int GetCameraByClient(string name)
        {
            if (list_camera.ContainsKey(name) == false)
                return (-1);
            return (list_camera[name]);
        }

        public static bool RemoveCameraByClient(string name)
        {
            if (list_camera.ContainsKey(name) == false)
                return (true);
            return (list_camera.Remove(name));
        }

        public static void RenderView(bool value, int time) {
            if (value) {
                RAGE.Game.Cam.RenderScriptCams(true, false, time, true, false, 0);
            } else if (!value) {

                RAGE.Game.Cam.RenderScriptCams(false, true, time, false, true, 0);
            }
        }

        public static void CamGotoCam(int index_a, int index_b, int time) {
            AddModCameraToClientWithParams("two", RAGE.Game.Cam.GetCamCoord(GetCameraByClient("one")), RAGE.Game.Cam.GetCamRot(GetCameraByClient("one"), Convert.ToInt32(RAGE.Game.Cam.GetCamFov(GetCameraByClient("one")))));
            int cam = GetCameraByClient("two");
            CameraGestion(index_b);
            RAGE.Game.Cam.SetCamActiveWithInterp(GetCameraByClient("two"), GetCameraByClient("one"), time, 0, 0);
        }

        public static void ActiveMenuHud(bool radar, bool hud, bool chat) {
            RAGE.Game.Ui.DisplayRadar(radar);
            RAGE.Game.Ui.DisplayHud(hud);
            Chat.Activate(chat);
            Chat.Show(chat);
        }
        
        public static void CameraGestion(int index) {
            list_function[index]();
        }

        public void Head()
        {
            AddModCameraToClientWithParams("one", new Vector3(402.9378f, -998.05f, -98.35f), new Vector3(0.0f, 0.0f, 176.891f), 40);
            int cam = GetCameraByClient("one");
            RAGE.Game.Cam.PointCamAtCoord(cam, 402.9198f, -996.5348f, -98.35f);
            RenderView(true, 2000);
        }


        public void Torso()
        {
            AddModCameraToClientWithParams("one", new Vector3(402.9378f, -998.5f, -98.60f), new Vector3(0.0f, 0.0f, 176.891f), 40);
            int cam = GetCameraByClient("one");
            RAGE.Game.Cam.PointCamAtCoord(cam, 402.9198f, -996.5348f, -98.60f);
            RenderView(true, 2000);
        }

        public void Legs()
        {
            AddModCameraToClientWithParams("one", new Vector3(402.9378f, -998.5f, -99.40f), new Vector3(0.0f, 0.0f, 176.891f), 40);
            int cam = GetCameraByClient("one");
            RAGE.Game.Cam.PointCamAtCoord(cam, 402.9198f, -996.5348f, -99.40f);
            RenderView(true, 2000);
        }

        public void Feet()
        {
            AddModCameraToClientWithParams("one", new Vector3(402.9378f, -997.5f, -99.85f), new Vector3(0.0f, 0.0f, 176.891f), 40);
            int cam = GetCameraByClient("one");
            RAGE.Game.Cam.PointCamAtCoord(cam, 402.9198f, -996.5348f, -99.85f);
            RenderView(true, 2000);
        }

        public void Body()
        {
            AddModCameraToClientWithParams("one", new Vector3(402.9103f, -1000.49f, -98.5f), new Vector3(0.0f, 0.0f, 176.891f), 40);
            int cam = GetCameraByClient("one");
            RAGE.Game.Cam.PointCamAtCoord(cam, 402.9198f, -996.5348f, -99.00024f);
            RenderView(true, 2000);
        }


        private void SelectMovieIntroduction()
        {
            AddModCameraToClientWithParams("one", new Vector3(415.8449f, -998.3865f, -99.40415f), new Vector3(0.0f, 0.0f, 90f), 90);
            AddModCameraToClientWithParams("two", new Vector3(414.8395f, -998.763f, -99.2f), new Vector3(0.0f, 0.0f, 90f), 50);
            int s_cam = GetCameraByClient("one");
            int e_cam = GetCameraByClient("two");
            RAGE.Game.Cam.PointCamAtCoord(s_cam, 415.8449f, -998.3865f, -99.40415f);
            RAGE.Game.Cam.SetCamActive(s_cam, true);
            RAGE.Game.Cam.PointCamAtCoord(s_cam, 409.7778f, -998.3335f, -98.8f);
            RAGE.Game.Cam.SetCamActiveWithInterp(e_cam, s_cam, 6000, 0, 0);
            //RAGE.Game.Cam.RenderScriptCams(true, false, 4000, true, false, 0);
            RenderView(true, 2000);
        }

        private void SouthMoviesIntroduction()
        {
            int interiora = RAGE.Game.Interior.GetInteriorAtCoords(-745.60f, -2228.059f, 20.55f);
            int interiorb = RAGE.Game.Interior.GetInteriorAtCoords(-801.6185f, -2135.059f, 111.7778f);
            //RAGE.Game.Streaming.RequestIpl(RA);
            RAGE.Game.Interior.RefreshInterior(interiora);
            RAGE.Game.Interior.RefreshInterior(interiorb);
            AddModCameraToClientWithParams("one", new Vector3(-745.60f, -2228.059f, 20.55f), new Vector3(0.0f, 0.0f, 90f), 90);
            AddModCameraToClientWithParams("two", new Vector3(-801.6185f, -2135.059f, 111.7778f), new Vector3(0.0f, 0.0f, 90f), 50);
            int s_cam = GetCameraByClient("one");
            int e_cam = GetCameraByClient("two");
            RAGE.Game.Cam.PointCamAtCoord(s_cam, -99.6683f, -813.3262f, 326.5321f);
            RAGE.Game.Cam.SetCamActive(s_cam, true);
            RAGE.Game.Cam.PointCamAtCoord(e_cam, -99.6683f, -813.3262f, 326.5321f);
            RAGE.Game.Cam.SetCamActiveWithInterp(e_cam, s_cam, 12000, 0, 0);
            //RAGE.Game.Cam.RenderScriptCams(true, false, 4000, true, false, 0);
            RenderView(true, 12000);

            Ventura.Utils.OTicks.instance.AddClockToInstance(new Utils.OClock(0, 0, 12, 0, () => {
                SouthMoviesIntroduction2();
            }));
        }

        private void SouthMoviesIntroduction2()
        {
            AddModCameraToClientWithParams("one", new Vector3(RAGE.Elements.Player.LocalPlayer.Position.X - 200f, RAGE.Elements.Player.LocalPlayer.Position.Y - 200f, RAGE.Elements.Player.LocalPlayer.Position.Z), new Vector3(0.0f, 0.0f, 120f), 90);
            AddModCameraToClientWithParams("two", new Vector3(-1219.258f, -3017.728f, 14.1612f), new Vector3(0.0f, 0.0f, 180f), 50);
            int s_cam = GetCameraByClient("one");
            int e_cam = GetCameraByClient("two");
            RAGE.Game.Cam.PointCamAtCoord(s_cam, -1219.258f, -3017.728f, 14.1612f);
            RAGE.Game.Cam.SetCamActive(s_cam, true);
            RAGE.Game.Cam.PointCamAtCoord(s_cam, -1219.258f, -3017.728f, 14.1612f);
            RAGE.Game.Cam.SetCamActiveWithInterp(e_cam, s_cam, 40000, 0, 0);

            Ventura.Utils.OTicks.instance.AddClockToInstance(new Utils.OClock(0, 0, 33, 0, () => {
                Events.CallLocal("destroyBrowser", "IntroForm");
                RAGE.Game.Cam.DoScreenFadeOut(2000);
            }));
            //RenderView(false, 6000);
        }


    }
}
