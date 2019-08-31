using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

//using RAGE.Game;
using RAGE;

namespace main_client
{
    public class Main : Events.Script
    {
        public Main() {
            /*Assembly assembly = Assembly.LoadFrom(@"package://MessagePack.dll");
            Chat.Output("Took");

            //Get the type of the assembly 
            Type type = assembly.GetType("Namespace.Class");
            Chat.Output("Took");

            //Gets the entry method of the assembly
            MethodInfo methodInfo = type.GetMethod("EntryMethod");
            Chat.Output("Took");

            //Create an instance of the reflected class
            object classInstance = Activator.CreateInstance(type);
            Chat.Output("Took");*/
        }
    }

    /*public class Main : Events.Script
    {
        RAGE.Elements.Ped tmp = null;
        int ped = -1;
        int board = -1;

        public Main()
        {
            Events.Add("testAttach", test);
            Events.Add("TestFall", test_fall);
            Events.Add("TestVehi", test_vehi);
            Events.Add("create_ped", create_ped);
            Events.Add("move_ped", move_ped);
            Events.Add("physics_object", physics_object);
            Events.AddDataHandler("update_ped", update_ped);
            Events.Add("client_update_ped", client_update_ped);
            Events.Add("desac_hud", desac_hud);
            Events.Add("attach_object_by_remote_id", attach_object_by_remote_id);
        }

        private void attach_object_by_remote_id(object[] args)
        {
            uint remoteId = Convert.ToUInt16(args[0]);
            string name = args[1].ToString();
            int LocalID = RAGE.Game.Object.CreateObject(RAGE.Game.Misc.GetHashKey(name), RAGE.Elements.Player.LocalPlayer.Position.X, RAGE.Elements.Player.LocalPlayer.Position.Y, RAGE.Elements.Player.LocalPlayer.Position.Z, false, false, true);

            RAGE.Elements.Player tmp = RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == remoteId);

            RAGE.Game.Entity.AttachEntityToEntity(tmp.Handle, LocalID, 28366, 0, 0, 0, 0, 0, 0, false, false, false, true, 10, false);
        }

        private void desac_hud(object[] args)
        {
            if ((int)args[0] == 0)
            {
                RAGE.Game.Ui.DisplayRadar(false);
                //RAGE.Game.Ui.DisplayHud(false);
                Chat.Activate(false);
                Chat.Show(false);
            }
            else {
                RAGE.Game.Ui.DisplayRadar(true);
                //RAGE.Game.Ui.DisplayHud(false);
                Chat.Activate(true);
                Chat.Show(true);

            }
        }

        private void physics_object(object[] args)
        {
            RAGE.Elements.MapObject obj = (RAGE.Elements.MapObject)args[0];
            //main_client.Player.Interact.InteractPlayer.weapon = obj;

            RAGE.Game.Entity.ApplyForceToEntity(obj.Handle, 0 << 1, 0, 0, -1, 0, 0, 0, 0, false, false, true, false, false);
        }

        private void client_update_ped(object[] args)
        {
            Chat.Output(args[0].ToString());
        }

        private void update_ped(Entity entity, object arg)
        {
            Chat.Output("Entity pass P2P begin " + entity.ToString());
        }

        private void create_ped(object[] args)
        {
            Vector3 pos = (Vector3)args[0];
            Chat.Output("Ped create");

            //RAGE.Game.Ped
            tmp = new RAGE.Elements.Ped(0xD172497E, pos);
            Events.CallRemote("client_created_ped", tmp);
        }

        private void test(object[] args)
        {
            RAGE.Elements.Player tmp = (RAGE.Elements.Player)args[0];
            RAGE.Elements.MapObject obj = (RAGE.Elements.MapObject)args[1];
            //int id_p = tmp.RemoteId;
            //int id_o = obj.RemoteId;
            //int id_p = RAGE.Elements.Entities.Players.GetAtRemote(RAGE.Elements.Player.LocalPlayer.RemoteId).RemoteId;
            //int id_o = RAGE.Elements.Entities.Objects.GetAtRemote(obj.RemoteId).RemoteId;
            //Chat.Output(tmp.Handle + " " + obj.Handle + " " + tmp.Id + " "+ obj.Id);
            //RAGE.Game.Ai.TaskGoToCoordAnyMeans(tmp.Handle, -429.7046f, 1172.925f, 325.9043f, 1f, 0, false, 786603, 0xbf800000);
            RAGE.Game.Entity.AttachEntityToEntity(tmp.Handle, obj.Handle, RAGE.Elements.Player.LocalPlayer.GetBoneIndex(26611), 0, 0, 0, 0, 0, 0, false, false, false, false, 2, false);
        }

        private void test_vehi(object[] args)
        {
            ushort remoteID = Convert.ToUInt16(args[0]);
            RAGE.Elements.Vehicle vehicle = Entities.Vehicles.GetAtRemote(remoteID);

            /*List<string> names = new List<string>();

            using (System.IO.StreamReader rd = new System.IO.StreamReader(@"C:\RAGEMP\server-files\Bone\bone.txt", true))
            {
                string line = "";
                while ( (line = rd.ReadLine()) != null) {
                    names.Add(line);
                }
            }

            for (int i = 0; i < names.Count; i++)
            {
                Chat.Output(names[i]);
                RAGE.Game.Invoker.Invoke(0xBE70724027F85BCD, vehicle.Handle, vehicle.GetBoneIndexByName(names[i]), 2 );
            }

            //vehicle.SetDamage(0, 0f, 0f, 1000, 2000, false);

            Random rand = new Random();

            for (int i = 0; i < 100; i++)
            {
                RAGE.Game.Vehicle.SetVehicleDamage(vehicle.Handle, (float)rand.NextDouble(), (float)rand.NextDouble(), 0, 10000, 100, true);
            }
            //RAGE.Game.Invoker.Invoke(0xA1DD317EA8FD4F29, vehicle.Handle, vehicle.Position.X, vehicle.Position.Y, vehicle.Position.Z, 10000, 400, true);
            /*for (int i = 0; i < 4; i++)
            {
                Chat.Output("Test "+remoteID);
                RAGE.Game.Invoker.Invoke(0xA711568EEDB43069, vehicle.Handle, i);
            }
        }

        private void test_fall(object[] args)
        {
            ushort remoteID = Convert.ToUInt16(args[0]);
            RAGE.Elements.Player player = Entities.Players.GetAtRemote(remoteID);

            /*int[] list = new int[14] { 12844, 6286, 35502, 36029, 56604, 65245, 5232, 37119, 43810, 61007, 6442, 23639, 51826, 58271 };

            Chat.Output("Test Ragdoll " + RAGE.Game.Entity.GetEntityHealth(player.Handle));
            for (int i = 0; i < 14; i++)
            {
                int entityRagdoll = RAGE.Game.Ped.GetPedBoneIndex(player.Handle, list[i]);
                if (RAGE.Game.Ped.GetPedLastDamageBone(player.Handle, ref entityRagdoll))
                {
                    Chat.Output("Life Skell id " + list[i] + " life entity " + entityRagdoll);
                }
            }
            //player.SetRagdollForceFall();
            //RAGE.Elements.Player.LocalPlayer.SetRagdollForceFall();
            RAGE.Elements.Player.LocalPlayer.SetToRagdoll(10000, 10000, 1, false, false, false);
            //RAGE.Game.Ped.SetPedToRagdoll()
            //RAGE.Game.Ped.SetPedRagdollForceFall(player.Handle);
            //RAGE.Game.Ped.SetPedRagdollForceFall(RAGE.Elements.Player.LocalPlayer.Handle);
            //RAGE.Game.Ped.SetPedRagdollBlockingFlags(player.Handle, 2);
            /*int ped = RAGE.Game.Ped.CreatePed(1, 0xD172497E, RAGE.Elements.Player.LocalPlayer.Position.X, RAGE.Elements.Player.LocalPlayer.Position.Y, RAGE.Elements.Player.LocalPlayer.Position.Z, 0, false , false);
            
            RAGE.Game.Entity.FreezeEntityPosition(ped, false);
            RAGE.Game.Weapon.GiveWeaponToPed(ped, Convert.ToUInt16(736523883), 1000, false, true);
            Utils.ThreadingTask.make_task_with_timeout(() => {
                RAGE.Game.Ai.TaskArrestPed(ped, player.Handle);
                //ped.TaskArrest(player.Handle);
                RAGE.Game.Invoker.Invoke(0x26695EC767728D84, ped, 2);
                RAGE.Game.Invoker.Invoke(0x1913FE4CBF41C463, ped, 33, true);
            }, 5000);
            //Chat.Output("Change "+RAGE.Game.Invoker.Invoke<bool>(0xAE99FB955581844A, player.Handle, 2000, 2000, 1, true, true, true));
            //Chat.Output("Change " + RAGE.Game.Invoker.Invoke<bool>(0x01F6594B923B9251, player.Handle));

            //int id_p = tmp.RemoteId;
            //int id_o = obj.RemoteId;
            //int id_p = RAGE.Elements.Entities.Players.GetAtRemote(RAGE.Elements.Player.LocalPlayer.RemoteId).RemoteId;
            //int id_o = RAGE.Elements.Entities.Objects.GetAtRemote(obj.RemoteId).RemoteId;
            //Chat.Output(tmp.Handle + " " + obj.Handle + " " + tmp.Id + " "+ obj.Id);
            //RAGE.Game.Ai.TaskGoToCoordAnyMeans(tmp.Handle, -429.7046f, 1172.925f, 325.9043f, 1f, 0, false, 786603, 0xbf800000);
            //RAGE.Game.Entity.AttachEntityToEntity(tmp.Handle, obj.Handle, RAGE.Elements.Player.LocalPlayer.GetBoneIndex(26611), 0, 0, 0, 0, 0, 0, false, false, false, false, 2, false);
        }

        private void move_ped(object[] args)
        {
            Vector3 pos = (Vector3)args[0];
            tmp.FreezePosition(false);
            if (tmp != null)
            {
                //RAGE.Elements.Player.LocalPlayer.TaskGoToCoordAnyMeans(pos.X, pos.Y, pos.Z, 1, 0, false, 0, 0);
                tmp.TaskGoToCoordAnyMeans(pos.X, pos.Y, pos.Z, 1, 0, false, 0, 0);
            }
        }
            /*private void test(object[] args)
            {
                Vector3 pos = (Vector3)args[0];
                Chat.Output("Ped create");
                if (ped == -1)
                {
                    //ped = RAGE.Game.Ped.CreatePed(4, 0xD172497E, pos.X, pos.Y, pos.Z, 0, true, true);
                    //board = RAGE.Game.Object.CreateObject(RAGE.Game.Misc.GetHashKey("prop_police_id_board"), pos.X, pos.Y, pos.Z, true, false, true);
                }

                //RAGE.Game.Ped
                tmp = new RAGE.Elements.Ped(0xD172497E, pos);   
                //tmp.TaskGoToCoordAnyMeans(pos.X, pos.Y, pos.Z, 1, 0, true, 0, 0);
            }*/

            /*private void move_npc(object[] args)
            {
                Vector3 pos = (Vector3)args[0];
                tmp.FreezePosition(false);
                if (tmp != null)
                {
                    RAGE.Elements.Player.LocalPlayer.TaskGoToCoordAnyMeans(pos.X, pos.Y, pos.Z, 1, 0, false, 0, 0);
                    tmp.TaskGoToCoordAnyMeans(pos.X, pos.Y, pos.Z, 1, 0, false, 0, 0);
                }

            }
        }*/
}
