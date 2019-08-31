using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RAGE;

namespace main_client.Cops
{
    /*class Cops : Events.Script
    {
        private bool service = false;
        private List<Vector3> spawn = new List<Vector3>() { new Vector3(456.1582f, -990.738f, 30.68959f), new Vector3(433.0488f, -1011.696f, 28.72602f) };
        private int timer = 0;

        public Cops() {
            Events.Tick += Tick;
        }

        private void Tick(List<Events.TickNametagData> nametags)
        {

            RAGE.Game.Graphics.DrawBox(spawn[1].X, spawn[1].Y, spawn[1].Z, spawn[1].X + 1, spawn[1].Y + 1, spawn[1].Z + 1, 24, 234, 154, 255);
            RAGE.Game.Graphics.DrawBox(spawn[0].X, spawn[0].Y, spawn[0].Z, spawn[0].X + 1, spawn[0].Y + 1, spawn[0].Z + 1, 24, 234, 154, 255);

            if (RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(spawn[0]) < 5f && RAGE.Input.IsDown((int)ConsoleKey.E) && timer == 0)
            {
                RAGE.Game.Ped.SetPedComponentVariation(RAGE.Elements.Player.LocalPlayer.Handle, 0, 0, 0, 2);
                RAGE.Game.Ped.SetPedComponentVariation(RAGE.Elements.Player.LocalPlayer.Handle, 1, 0, 0, 2);
                RAGE.Game.Ped.SetPedComponentVariation(RAGE.Elements.Player.LocalPlayer.Handle, 2, 31, 0, 2);
                RAGE.Game.Ped.SetPedComponentVariation(RAGE.Elements.Player.LocalPlayer.Handle, 3, 0, 0, 2);
                RAGE.Game.Ped.SetPedComponentVariation(RAGE.Elements.Player.LocalPlayer.Handle, 4, 35, 0, 2);
                RAGE.Game.Ped.SetPedComponentVariation(RAGE.Elements.Player.LocalPlayer.Handle, 5, 0, 0, 2);
                RAGE.Game.Ped.SetPedComponentVariation(RAGE.Elements.Player.LocalPlayer.Handle, 6, 24, 0, 2);
                RAGE.Game.Ped.SetPedComponentVariation(RAGE.Elements.Player.LocalPlayer.Handle, 7, 0, 0, 2);
                RAGE.Game.Ped.SetPedComponentVariation(RAGE.Elements.Player.LocalPlayer.Handle, 8, 58, 0, 2);
                RAGE.Game.Ped.SetPedComponentVariation(RAGE.Elements.Player.LocalPlayer.Handle, 9, 4, 0, 2);
                RAGE.Game.Ped.SetPedComponentVariation(RAGE.Elements.Player.LocalPlayer.Handle, 10, 8, 3, 2);
                RAGE.Game.Ped.SetPedComponentVariation(RAGE.Elements.Player.LocalPlayer.Handle, 11, 55, 0, 2);
                RAGE.Game.Ped.SetPedPropIndex(RAGE.Elements.Player.LocalPlayer.Handle, 0, 46, 0, true);
                //RAGE.Game.Weapon.AddAmmoToPed(RAGE.Elements.Player.LocalPlayer.Handle, Convert.ToUInt16(-1716589765), 100);
                service = !service;
                Chat.Output(service.ToString());
                timer++;
            }
            else if (RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(spawn[1]) < 5f && RAGE.Input.IsDown((int)ConsoleKey.E) && service && timer == 0)
            {
                Chat.Output("Spawn");
                Events.CallRemote("SpawnNewVehicule", "Police");
                timer++;
            }
            else if (timer != 0 && timer < 20)
                timer++;
            else if (timer >= 20)
                timer = 0;
        }

        /*private int timer = 0;
        private bool loop = false;
        private bool back = false;
        private RAGE.Elements.Marker marker = null;
        private RAGE.Elements.Ped tmp = null;
        private RAGE.Elements.Vehicle pt = null;
        private List<string> data = null;
        RAGE.Game.Scaleform scale = null;

        string[] names = new string[2] { "v_club_officechair", "prop_off_chair_05" };


        public Cops()
        {
            //Events.Add("createVehicule", create_vehicule);
            //Events.Add("VehiculeClientIsAir", VehiculeClientIsAir);
            //Events.Add("PlayerSyncPed", PlayerSyncPed);
            Events.Add("SaveBlip", SaveBlip);
            Events.Add("get_prop_info", get_prop_info);
            Events.Tick += Tick;
            //Events.AddDataHandler("Anonymous", Anonymous);
        }

        private void SaveBlip(object[] args)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\RAGEMP\server-files\data\pos.txt", true))
            {
                file.WriteLine("new Vector3(" + ((float)args[0]).ToString().Replace(',','.') + "," + ((float)args[1]).ToString().Replace(',', '.') + "," + ((float)args[2]).ToString().Replace(',', '.') + ") " + (string)args[3], (string)args[4], (string)args[5]);
            }
        }

        public void Anonymous(RAGE.Elements.Entity entity, object value) {
            /*Chat.Output("Ta soeur "+entity.ToString());
            RAGE.Game.Streaming.RequestAnimDict("amb@world_human_vehicle_mechanic@male@idle_a");
            while (!RAGE.Game.Streaming.HasAnimDictLoaded("amb@world_human_vehicle_mechanic@male@idle_a")) { RAGE.Game.Invoker.Wait(0); };
            //((RAGE.Elements.Player)entity)
            ((RAGE.Elements.Player)entity).TaskPlayAnim("amb@world_human_vehicle_mechanic@male@idle_a", "idle_a", -8f, 1, -1, 1, 0, false, false, false);
            //((RAGE.Elements.Player)entity).TaskPlayAnim("amb@world_human_vehicle_mechanic@male@idle_a", "idle_a", 1000f, false, false, false, 0f, 0x4000);
        }

        public void get_prop_info(object[] args)
        {
            string line;
            int obj = 0;
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\RAGEMP\server-files\client_packages\DataProps.txt");
            while ((line = file.ReadLine()) != null)
            {
                line = line.Substring(1, line.Length - 3);
                //Chat.Output(line);
                obj = RAGE.Game.Object.GetClosestObjectOfType(RAGE.Elements.Player.LocalPlayer.Position.X, RAGE.Elements.Player.LocalPlayer.Position.Y, RAGE.Elements.Player.LocalPlayer.Position.Z, 5f, RAGE.Game.Misc.GetHashKey(line), false, false, false);
                if (obj != 0) {
                    Chat.Output("Name " + line + " obj " + obj + " entity pos " + RAGE.Game.Object.GetObjectOffsetFromCoords(RAGE.Elements.Player.LocalPlayer.Position.X, RAGE.Elements.Player.LocalPlayer.Position.Y, RAGE.Elements.Player.LocalPlayer.Position.Z, 0f, 5f, 5f, 5f));
                }
            }
            //int tmp = RAGE.Game.Object.CreateObject(RAGE.Game.Misc.GetHashKey("prop_mugs_rm_flashb"), RAGE.Elements.Player.LocalPlayer.Position.X, RAGE.Elements.Player.LocalPlayer.Position.Y, RAGE.Elements.Player.LocalPlayer.Position.Z, true, false, false );
            //RAGE.Game.Object.SetDesObjectState(tmp, 4);
            //RAGE.Game.Graphics.DrawSpotLight(RAGE.Elements.Player.LocalPlayer.Position.X, RAGE.Elements.Player.LocalPlayer.Position.Y, RAGE.Elements.Player.LocalPlayer.Position.Z, 0, 0, 0, 255, 0, 0, 25f, 10f, 10f, 25f, 0f);
            int closeDoor = RAGE.Game.Object.GetClosestObjectOfType(461.8065f, -994.4086f, 25.06443f, 2f, 631614199, false, false, false);
            int obj = RAGE.Game.Object.GetClosestObjectOfType(RAGE.Elements.Player.LocalPlayer.Position.X, RAGE.Elements.Player.LocalPlayer.Position.Y, RAGE.Elements.Player.LocalPlayer.Position.Z, 1000f, RAGE.Game.Misc.GetHashKey("prop_mugs_rm_flashb"), false, false, false);
            //RAGE.Game.
            RAGE.Game.Entity.GetEntityCoords(obj, false);
            Chat.Output("uint " + obj + " uint door "+ closeDoor + " key "+ RAGE.Game.Misc.GetHashKey("prop_mugs_rm_flashb"));
            RAGE.Game.Object.SetDesObjectState(obj, 4);
            RAGE.Game.Object.SetObjectTextureVariant(obj, 15);
            Chat.Output("test");
        }

        public void PlayerSyncPed(object[] args) {
            RAGE.Elements.Player p = (RAGE.Elements.Player)args[0];
            //p.Position = p.Position;
            //p.SetHeading(p.GetHeading());
            //p.PlayAnim("amb@world_human_vehicle_mechanic@male@idle_a", "idle_a", 8.0f, true, true, true, 0.0f, 0);
        }

        public void VehiculeClientIsAir(object[] args) {
            RAGE.Elements.Vehicle v = (RAGE.Elements.Vehicle)args[0];

            if (v.IsInAir()) {
                Chat.Output("Vehicule in Air "+v.GetEngineHealth() +" "+ v.GetBodyHealth());
                v.ApplyForceToCenterOfMass(3, 0, 0, -3f, false, false, false, false);

                v.SetEngineHealth(v.GetEngineHealth() - 20f);
                v.SetBodyHealth(v.GetBodyHealth() - 20f);
                v.SetDirtLevel(100);
                v.SetDamage(0, 0, 0, 10, 10, false);
                //v.ApplyForceTo(3,0, 0, -10f, 0, 0, 0, v.GetBoneIndexByName("chassis"), true, false, true, false, false);
            }
        }

        public float abs(float v)
        {
            return (v < 0 ? v * -1 : v);
        }



        public void update_vehicule(object[] args)
        {
            //pt.Position = new Vector3((float)args[0], (float)args[1], (float)args[2]);
            //Events.CallRemote("update_vehicule", main_client.Player.LoginRegister.main);
        }

        public void create_vehicule(object[] args)
        {
            //RAGE.Elements.Ped ped = new RAGE.Elements.Ped(2047212121, new Vector3((float)args[0], (float)args[1], (float)args[2]), 86.6f);
            //ped.FreezePosition(false);
            //pt = new RAGE.Elements.Vehicle(3078201489, new Vector3((float)args[0], (float)args[1], (float)args[2]), 86.6f);
            //Events.CallRemote("update_vehicule", main_client.Player.LoginRegister.main);
        }

        public bool GetDistanceByPoint(Vector3 a, Vector3 b, float distance)
        {
            float x_a = a.X < 0 ? a.X * -1 : a.X;
            float x_b = b.X < 0 ? b.X * -1 : b.X;
            float y_a = a.Y < 0 ? a.Y * -1 : a.Y;
            float y_b = b.Y < 0 ? b.Y * -1 : b.Y;
            float z_a = a.Z < 0 ? a.Z * -1 : a.Z;
            float z_b = b.Z < 0 ? b.Z * -1 : b.Z;
            if (distance == 2)
            {
                Chat.Output("Res :" + a.X);
                Chat.Output("Res :" + b.X);
                Chat.Output("Res :" + a.Y);
                Chat.Output("Res :" + b.Y);
            }
            if (abs(a.X - b.X) + abs(a.Y - b.Y) + abs(a.Z - b.Z) < distance)
                return (true);
            return (false);
        }

        public void model_add_object_handle(RAGE.Elements.Ped tmp, string name_item)
        {
            int item = RAGE.Game.Object.CreateObject(RAGE.Game.Misc.GetHashKey(name_item), tmp.Position.X, tmp.Position.Y, tmp.Position.Z, true, true, true);
            RAGE.Game.Invoker.Invoke(0x6B9BBD38AB0796DF,  item, tmp.GetBoneIndex(28422), 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, false, false, false, false, 2, true);
            //RAGE.Game.Object.
        }


        public void model_load_anim(RAGE.Elements.Ped tmp, string dict, string anim, int dur)
        {
            RAGE.Game.Streaming.RequestAnimDict(dict);
            //while (!RAGE.Game.Streaming.HasAnimDictLoaded(dict)) { };
            tmp.TaskPlayAnim(dict, anim, 8.0f, -8.0f, dur, 1, 0.0f, false, false, false);
            return;
        }

        public void Tick(List<Events.TickNametagData> nametags)
        {

            if (Input.IsDown((int)ConsoleKey.B) && timer == 0)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\RAGEMP\server-files\data\pos.txt", true))
                {
                    file.WriteLine("new Vector3(" + RAGE.Elements.Player.LocalPlayer.Position.X.ToString() + "," + RAGE.Elements.Player.LocalPlayer.Position.Y.ToString() + "," + RAGE.Elements.Player.LocalPlayer.Position.Z.ToString() + ") " + RAGE.Elements.Player.LocalPlayer.GetHeading().ToString());
                }
                timer++;
            } else if (RAGE.Input.IsDown((int)ConsoleKey.H) && timer == 0)
            {
                //RAGE.Elements.Player.LocalPlayer.Position = new Vector3(-31.46478f, -1112.632f, 26.42235f);
                timer++;
            }
            else if (timer != 0 && timer <= 100)
                timer++;
            else if (timer >= 100)
                timer = 0;*/
        //if (Input.IsDown((int)ConsoleKey.M) && tmp == null)
        //    Events.CallRemote("InitializePed", main_client.Player.LoginRegister.main, tmp = new RAGE.Elements.Ped(2047212121, RAGE.Elements.Player.LocalPlayer.Position, 86.6f));
        //RAGE.Game.Graphics.DrawMarker(1, 452.146f, -980.0009f, 30.6896f , 0, 90, 0, 0, 0, 0, 3, 3, 1, 255, 255, 204, 255, false, false, 0, false, null, null, false);
        /* if (Input.IsDown((int)ConsoleKey.A) && GetDistanceByPoint(RAGE.Elements.Player.LocalPlayer.Position, new Vector3(452.146f, -980.0009f, 30.6896f), 10f))
             loop = true;
         else if (loop && time > 5)
         {
             if (tmp == null)
             {
                 tmp = new RAGE.Elements.Ped(2047212121, new Vector3(454.146f, -980.0009f, 30.6896f), 86.6f);
                 tmp.FreezePosition(false);

             }
             else {
                   model_load_anim(tmp, "mp_character_creation@customise@male_a", "profile_r_loop", -1);

             }
             back = back == true ? false : true;
             /*if (back)
                 tmp.TaskGoToCoordAnyMeans(461.3315f, -982.9602f, 30.6896f, 1, 0, false, 1, 0);
             else
                 tmp.TaskGoToCoordAnyMeans(454.146f, -980.0009f, 30.6896f, 1, 0, false, 1, 0);
             //tmp.TaskGoToCoordAnyMeans(461.3315f, -982.9602f, 30.6896f, 1, 0, false, 1, 0);

             //int board = RAGE.Game.Object.CreateObject(RAGE.Game.Misc.GetHashKey(data_anim[0]), 409.1245f, -997.5353f, -98f, true, false, true);
             //int graphic = RAGE.Game.Graphics.RequestScaleformMovie("mugshot_board_01");
             //Chat.Output(RAGE.Game.Graphics.HasScaleformMovieLoaded(graphic).ToString());
             //Chat.Output(RAGE.Game.Streaming.HasAnimDictLoaded(data_anim[3]).ToString());
             //while (!RAGE.Game.Graphics.HasScaleformMovieLoaded(graphic)) RAGE.Game.Utils.Wait(0);
             //RAGE.Game.Graphics.PushScaleformMovieFunction(graphic, "SET_BOARD");


             //RAGE.Game.Streaming.RequestAnimDict(data_anim[3]);
             //while (!RAGE.Game.Streaming.HasAnimDictLoaded(data_anim[3])) RAGE.Game.Utils.Wait(0);
             //tmp[0].SetRotation(0, 0, -90, 0, false);
             //tmp[1].SetRotation(0, 0, -90, 0, false);
             //tmp[0]
             //tmp[0].Handle
             //tmp[1].TaskPlayAnim(data_anim[3], data_anim[4], 8.0f, -8.0f, -1, 1, 0.0f, false, false, false);
             //tmp[0].TaskPlayAnim(data_anim[3], data_anim[4], 8.0f, -8.0f, -1, 1, 0.0f, false, false, false);
             //tmp.TaskGoToCoordAnyMeans(409.1245f, -997.5353f, -99.0041f, 2, 0, false, 1, 0);


             //marker = new RAGE.Elements.Marker(1, new Vector3(452.146f, -980.0009f, 30.6896f), 10f, new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new RGBA(0x0000FF));
             loop = false;
             time = 0;
         }
         else if (loop)
             time++;
    }
    }*/
}
