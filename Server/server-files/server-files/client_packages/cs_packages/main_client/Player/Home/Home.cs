using System;
using System.Collections.Generic;
using System.Text;
//using Newtonsoft.Json;
using RAGE;
using RAGE.NUI;
using EAPI = RAGE.Elements;

namespace main_client.Player.Home
{
    /*class Home : Events.Script
    {
        ListHome list_home = null;
        List<EAPI.Blip> list_blip = new List<EAPI.Blip>();

        public Home()
        {
            Events.Add("UpdateListHome", UpdateListHome);
            Events.Tick += Tick;
        }

    
        private void Tick(List<Events.TickNametagData> nametags)
        {
            if (list_home == null)
                return;
            list_home.Draw();
        }

        private void UpdateListHome(object[] args)
        {
            string json = args[0].ToString();
            Chat.Output(json);
            List<HomeJson> list = JsonConvert.DeserializeObject<List<HomeJson>>(json);
            if (list == null)
                return;

            for (int i = 0; i < list_blip.Count; i++)
            {
                list_blip[i].SetAlpha(0);
                list_blip[i].Destroy();
            }
            list_blip.Clear();

            foreach (var data in list)
            {
                bool add = true;
                    for (int i = 0; i < list_blip.Count; i++)
                    {
                        if (data.from == list_blip[i].Position)
                        add = false;
                }
                if (add)
                    list_blip.Add(new EAPI.Blip(411, data.from, data.owner));
            }


            list_home = new ListHome() { list = list };
        }

        public class ListHome
        {
            int clock = 0;
            public List<HomeJson> list { get; set; }

            public ListHome() { }

            public bool Draw()
            {
                foreach (var home in list)
                {
                    Chat.Output("home " + home.id + " "+ RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(new Vector3(home.from.X, home.from.Y, home.from.Z)));
                    if (RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(new Vector3(home.from.X, home.from.Y, home.from.Z)) < 100f)
                    {
                        //RAGE.Game.Graphics.DrawMarker(1, home.from.X, home.from.Y, home.from.Z, 0, 0, 0, 0, 0, 0, 1, 1, 1, 23, 235, 2, 255, false, false, 0, false, "", "", false);
                        if (RAGE.Input.IsDown((int)ConsoleKey.E) && clock == 0 && (RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(new Vector3(home.from.X, home.from.Y, home.from.Z)) < 8f))
                        {

                            int interior = RAGE.Game.Interior.GetInteriorAtCoords(home.to.X, home.to.Y, home.to.Z);
                            Chat.Output(interior.ToString());
                            RAGE.Game.Streaming.RequestIpl(home.owner);
                            RAGE.Game.Interior.LoadInterior(interior);
                            RAGE.Game.Interior.RefreshInterior(interior);
                            while (!RAGE.Game.Interior.IsInteriorReady(interior)) { RAGE.Game.Invoker.Wait(0); }
                            RAGE.Elements.Player.LocalPlayer.Position = new Vector3(home.to.X, home.to.Y, home.to.Z);
                            RAGE.Elements.Player.LocalPlayer.FreezePosition(true);
                            clock++;
                            return (true);
                        }
                        else if (RAGE.Input.IsDown((int)ConsoleKey.E) && clock == 0 && RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(new Vector3(home.to.X, home.to.Y, home.to.Z)) < 8f)
                        {
                            RAGE.Elements.Player.LocalPlayer.Position = new Vector3(home.from.X, home.from.Y, home.from.Z);
                            RAGE.Elements.Player.LocalPlayer.FreezePosition(false);
                            clock++;
                            return (true);
                        }
                        else if (clock < 80)
                            clock++;
                        else if (clock >= 80)
                            clock = 0;
                        RAGE.Game.Graphics.DrawBox(home.from.X, home.from.Y, home.from.Z, home.from.X + 1, home.from.Y + 1, home.from.Z + 1, 0, 0, 255, 255);
                        RAGE.Game.Graphics.DrawBox(home.to.X, home.to.Y, home.to.Z, home.to.X + 1, home.to.Y + 1, home.to.Z + 1, 0, 0, 255, 255);
                    }
                }
                return (false);
            }

        }

        public class HomeJson
        {
            public int id { get; set; }
            public string owner { get; set; }
            public string interior_name { get; set; }
            public Vector3 from { get; set; }
            public Vector3 to { get; set; }

            public HomeJson()
            {

            }

            public HomeJson(int id, Vector3 f, Vector3 t)
            {
                this.id = id;
                this.from = f;
                this.to = t;
            }
        }
    }*/
}
