using System;
using System.Collections.Generic;
using System.Text;
using RAGE;
using RAGE.Elements;
using CAPI = main_client.Ventura.Engine.Camera;
using AAPI = main_client.Ventura.Engine.Animation;
using PAPI = main_client.Ventura.Engine.Ped;
using System.Threading.Tasks;

namespace main_client.Ventura.Engine
{
    class Ped : Events.Script
    {
        public delegate void PedFunction();
        public static Dictionary<string, RAGE.Elements.Ped> list_ped = new Dictionary<string, RAGE.Elements.Ped>();
        public static List<PedFunction> list_function = new List<PedFunction>();
        //private List<Utils.OClock> clock = new List<Utils.OClock>();

        public Ped() {
            list_function.Add(introduction_cops);
            list_function.Add(introduction_select);
            //Events.Tick += OnTick;
        }


        /*private void OnTick(List<Events.TickNametagData> nametags)
        {
            Utils.OClock tmp = null;
            for (int i = 0; i < clock.Count; i++)
            {
                if (clock[i].Done())
                    tmp = clock[i];
            }
            if (tmp != null)
                clock.Remove(tmp);
        }*/

        public static void AddPedByClient(string name, uint model, Vector3 pos, float heading, uint dimension)
        {
            if (list_ped.ContainsKey(name) == false)
            {
                list_ped.Add(name, new RAGE.Elements.Ped(model, pos, heading, dimension));
            }
        }

        public static RAGE.Elements.Ped GetPedByClient(string name)
        {
            if (list_ped.ContainsKey(name) == false)
                return (null);
            return (list_ped[name]);
        }

        public static bool RemovePedByClient(string name)
        {
            if (list_ped.ContainsKey(name) == false)
                return (true);
            return (list_ped.Remove(name));
        }
        
        public static void PedGestion(int index)
        {
            list_function[index]();
        }

        public static void PedSetAnim(string name, string dict, string anim, float speed) {
            RAGE.Game.Entity.FreezeEntityPosition(list_ped[name].Handle, false);
            RAGE.Game.Streaming.RequestAnimDict(dict);
            while (!RAGE.Game.Streaming.HasAnimDictLoaded(dict)) { RAGE.Game.Invoker.Wait(1); };
            //list_ped[name].TaskPlayAnim(dict, name, speed, 1, -1,  1 << 0, 0.1f, false, false, false);
            RAGE.Game.Ai.TaskPlayAnim(list_ped[name].Handle, dict, name, speed, 1, -1, 1 << 0, 0.1f, false, false, false);
        }

        public void introduction_cops()
        {
            RAGE.Elements.Player.LocalPlayer.Position = new Vector3(405.5f, -997.3f, -99.00404f);
            RAGE.Elements.Player.LocalPlayer.FreezePosition(false);
            RAGE.Elements.Player.LocalPlayer.SetHeading(88f);
            //RAGE.Game.Object.CreateObject(RAGE.Game.Misc.GetHashKey("prop_mugs_rm_flashb"), 403.1151f, -1001.229f, -100.004f, false, false, false);

            //RAGE.Elements.MapObject project = null;
            Utils.OTicks.instance.AddClockToInstance(new Utils.OClock(0, 0, 2, 500, () =>
            {
                new RAGE.Elements.MapObject(RAGE.Game.Misc.GetHashKey("prop_mugs_rm_flashb"), new Vector3(403.1151f, -1001.229f, -100.004f), new Vector3(), 255, RAGE.Elements.Player.LocalPlayer.Dimension);
            }));
            
            //while ((project = new RAGE.Elements.MapObject(RAGE.Game.Misc.GetHashKey("prop_mugs_rm_flashb"), new Vector3(403.1151f, -1001.229f, -100.004f), new Vector3(), 255, RAGE.Elements.Player.LocalPlayer.Dimension)) == null) { RAGE.Game.Invoker.Wait(0); };
            AddPedByClient("cops_a", 1581098148, new Vector3(401.2023f, -997.3085f, -99.00404f), 270, RAGE.Elements.Player.LocalPlayer.Dimension);
            AddPedByClient("cops_b", 1581098148, new Vector3(401.5399f, -1001.95f, -99.00404f), 338, RAGE.Elements.Player.LocalPlayer.Dimension);

            Utils.OTicks.instance.AddClockToInstance(new Utils.OClock(0, 0, 2, 500, () =>
            {
                new RAGE.Elements.MapObject(RAGE.Game.Misc.GetHashKey("prop_mugs_rm_flashb"), new Vector3(403.1151f, -1001.229f, -100.004f), new Vector3(), 255, RAGE.Elements.Player.LocalPlayer.Dimension);
                GetPedByClient("cops_a").ActivatePhysics();
                GetPedByClient("cops_b").ActivatePhysics();
                GetPedByClient("cops_a").FreezePosition(false);
                GetPedByClient("cops_b").FreezePosition(false);
                PedSetAnim("cops_a", "mp_am_hold_up", "handsup_base", 8);
                PedSetAnim("cops_b", "mp_am_hold_up", "handsup_base", 8);
            }));


            RAGE.Game.Invoker.Wait(100);
            CAPI.ActiveMenuHud(false, true, true);
            CAPI.CameraGestion(4);
        }

        public void introduction_select()
        {
            RAGE.Elements.Player.LocalPlayer.Position = new Vector3(409.1245f, -997.5353f, -99.0041f);
            RAGE.Elements.Player.LocalPlayer.FreezePosition(false);
            RAGE.Elements.Player.LocalPlayer.SetHeading(-90f);
            RemovePedByClient("cops_a");
            RemovePedByClient("cops_b");
            //AddPedByClient("other_a", RAGE.Game.Misc.GetHashKey("ArmyMech01SMY"), new Vector3(409.1245f, -999.7f, -99.0041f), 338, RAGE.Elements.Player.LocalPlayer.Dimension);
            //RAGE.Game.Invoker.Wait(100);
            CAPI.ActiveMenuHud(false, true, false);
            CAPI.CameraGestion(5);
            AAPI.AnimationGestion(5);
        }

    }
}
