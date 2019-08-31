using System;
using System.Collections.Generic;
using System.Text;
using RAGE;
using EAPI = RAGE.Elements;
using GAPI = RAGE.Game;


namespace main_client.Jobs.Electricien
{
    /*class Electricien : Events.Script
    {
        bool isActive = false;
        bool isService = false;
        EAPI.Blip blip = null;
        EAPI.Marker marker = null;

        List<EAPI.Blip> list_blip = new List<EAPI.Blip>();
        List<EAPI.Marker> list_marker = new List<EAPI.Marker>();
        //List<EAPI.TextLabel> list_label = new List<EAPI.TextLabel>();

        List<Vector3> list_point = new List<Vector3>() {
            new Vector3(285.7363f, -696.0449f, 29.29529f),
            new Vector3(-92.09339f, 854.7074f, 235.1211f),
            new Vector3(-472.0776f, 646.5629f, 144.1887f),
            new Vector3(319.7533f, -995.1641f, 28.79442f),
            new Vector3(367.84f, -756.9072f, 28.7911f),
            new Vector3(-1705.897f, -438.8194f, 41.89584f),
            new Vector3(-1568.35f, -447.5459f, 35.98851f),
            new Vector3(-1544.925f, -390.8253f, 42.1734f),
            new Vector3(-1475.823f, -341.1863f, 45.20409f),
            new Vector3(-1249.461f, -270.5305f, 38.98117f),
            new Vector3(205.3374f, 1180.882f, 227.009f),
            new Vector3(-572.2796f, 311.7369f, 84.52396f),
            new Vector3(-442.8725f, 287.8481f, 83.23493f),
            new Vector3(-72.31204f, 347.0335f, 112.4462f),
            new Vector3(3123.7232f, -317.6876f, 45.5575f),
        };



        public Electricien() {
            Events.Add("electricien_active_sevice", electricien_active_sevice);
            Events.Tick += Tick;
        }

        private void electricien_active_sevice(object[] args)
        {
            switch ((int)args[0])
            {
                case 0:
                    isActive = (bool)args[1];
                    break;
                case 1:
                    isService = (bool)args[1];
                    break;
            }
        }

        void clear_object<T>(T obj) where T : EAPI.Entity
        {
            obj.Destroy();
            obj = default(T);
        }

        void create_mission() {
            for (int i = 0; i < list_point.Count; i++) {
                list_blip.Add(new EAPI.Blip(515, list_point[i], "Mission", 1, 75));
                list_marker.Add(new EAPI.Marker(1, list_point[i] - new Vector3(0, 0, 1f), 1f, new Vector3(), new Vector3(), new RGBA(0, 0, 255)));
            }
        }

        private void Tick(List<Events.TickNametagData> nametags)
        {
            if (isActive)
            {
                if (blip == null)
                    blip = new EAPI.Blip(484, new Vector3(499.6642f, -651.8285f, 24.9088f), "Electricien", 1, 75);
                else if (marker == null)
                    marker = new EAPI.Marker(1, new Vector3(499.6642f, -651.8285f, 24.9088f), 1f, new Vector3(), new Vector3(), new RGBA(0, 0, 255));
                if (!isService && Input.IsDown((int)ConsoleKey.G) && Vector3.Distance(EAPI.Player.LocalPlayer.Position, new Vector3(499.6642f, -651.8285f, 24.9088f)) < 5f) {
                    new EAPI.Vehicle(2518351607, new Vector3(502.8539f, -635.1005f, 24.31458f));
                    create_mission();
                    isService = true;
                }
                for (int i = 0; i < list_point.Count; i++) {
                    if (Vector3.Distance(EAPI.Player.LocalPlayer.Position, list_point[i]) < 5f && RAGE.Input.IsDown((int)ConsoleKey.E) && list_blip[i].GetColour() == 75) {
                        //Chat.Output("Fait !");
                        //new EAPI.TextLabel(list_point[i], "Fait", new RGBA(0x0000FFFF));
                        list_blip[i].SetColour(11);
                        Events.CallRemote("change_money", 25);
                    }
                }
            }
            else if (!isActive) {
                if (blip != null)
                    clear_object<EAPI.Blip>(blip);
                else if (marker != null)
                    clear_object<EAPI.Marker>(marker);
            }
        }
    }*/
}
