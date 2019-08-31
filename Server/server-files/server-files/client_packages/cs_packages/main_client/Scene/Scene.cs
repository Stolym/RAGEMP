using System;
using System.Collections.Generic;
using System.Text;
using RAGE;

namespace main_client.Scene
{
    /*class Scene : Events.Script
    {
        public enum AnimationFlags
        {
            Loop = 1 << 0,
            StopOnLastFrame = 1 << 1,
            OnlyAnimateUpperBody = 1 << 4,
            AllowPlayerControl = 1 << 5,
            Cancellable = 1 << 7
        };

        int scene = 0;
        bool active = false;
        int timer = 0;

        public Scene()
        {
            Events.Add("MakeScene", MakeScene);
            Events.Add("InBoot", InBoot);
            Events.Tick += Tick;
        }

        private void Tick(List<Events.TickNametagData> nametags)
        {
            if (active && timer < 500)
            {
                timer++;
            }
            else if (timer >= 500) {
                Chat.Output("Salut");
                RAGE.Elements.Player.LocalPlayer.FreezePosition(false);
                RAGE.Game.Ped.DetachSynchronizedScene(scene);
                RAGE.Game.Ai.ClearPedTasksImmediately(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == 0).Handle);
                RAGE.Game.Ai.ClearPedTasksImmediately(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == 1).Handle);

                //RAGE.Game.Streaming.RequestAnimDict("anim@move_m@prisoner_cuffed");
                //while (!RAGE.Game.Streaming.HasAnimDictLoaded("anim@move_m@prisoner_cuffed")) { RAGE.Game.Invoker.Wait(0); }
                //RAGE.Game.Ai.TaskPlayAnim(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == 1).Handle, "anim@move_m@prisoner_cuffed", "idle", 1f, 4.0f, -1, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), 0, false, false, false);
                active = false;
                timer = 0;
            }
        }

        private void InBoot(object[] args)
        {
            int veh = RAGE.Game.Vehicle.GetClosestVehicle(RAGE.Elements.Player.LocalPlayer.Position.X, RAGE.Elements.Player.LocalPlayer.Position.Y, RAGE.Elements.Player.LocalPlayer.Position.Z, 20, 0, 70);

            for (int i = 0; i < 10; i++)
            {
                RAGE.Game.Vehicle.SetVehicleDoorOpen(veh, i, true, true);
            }

            RAGE.Game.Entity.AttachEntityToEntity(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == 0).Handle, veh, RAGE.Game.Entity.GetEntityBoneIndexByName(veh, "boot"), 0, 0, -0.5f, 0, 0, 0, false, false, false, true, 0, true);
            RAGE.Game.Streaming.RequestAnimDict("mp_dispose_of_veh");
            while (!RAGE.Game.Streaming.HasAnimDictLoaded("mp_dispose_of_veh")) { RAGE.Game.Invoker.Wait(0); }
            RAGE.Game.Ai.TaskPlayAnim(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == 0).Handle, "mp_dispose_of_veh", "dead_ped_idle", 1f, 4.0f, -1, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), 0, false, false, false);

            for (int i = 0; i < 10; i++)
            {
                RAGE.Game.Vehicle.SetVehicleDoorShut(veh, i, true);
            }
        }


        private void MakeScene(object[] args)
        {
            Chat.Output("Load");
            //RAGE.Elements.Ped tmp = new RAGE.Elements.Ped(2047212121, RAGE.Elements.Player.LocalPlayer.Position, 86.6f);
            //int ped = RAGE.Game.Ped.CreatePed(26, Convert.ToUInt16(-781039234), RAGE.Elements.Player.LocalPlayer.Position.X, RAGE.Elements.Player.LocalPlayer.Position.Y, RAGE.Elements.Player.LocalPlayer.Position.Z + 2, 0, true, true);
            RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == 0).SetHeading(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == 0).GetHeading() + 180);
            RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == 0).Position = RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == 1).Position.Around(1f);
            scene = RAGE.Game.Ped.CreateSynchronizedScene(RAGE.Elements.Player.LocalPlayer.Position.X, RAGE.Elements.Player.LocalPlayer.Position.Y, RAGE.Elements.Player.LocalPlayer.Position.Z, 0, 0, 0, 2);
            RAGE.Game.Ped.SetSynchronizedSceneLooped(scene, false);
            RAGE.Game.Streaming.RequestAnimDict("anim@mp_player_intcelebrationpaired@f_f_bro_hug");
            while (!RAGE.Game.Streaming.HasAnimDictLoaded("anim@mp_player_intcelebrationpaired@f_f_bro_hug")) { RAGE.Game.Invoker.Wait(0); }
            //RAGE.Game.Ai.TaskSynchronizedScene(RAGE.Elements.Player.LocalPlayer.Handle, scene, "mp_arresting", "arrest_on_floor_back_right_a", 1.0f, 4.0f, 0, 0, 0, 0);
            //RAGE.Game.Ai.TaskSynchronizedScene(tmp.Handle, scene, "mp_arresting", "arrest_on_floor_back_right_b", 1.0f, 4.0f, 0, 0, 0, 0);
            //RAGE.Game.Ai.TaskPlayAnim(RAGE.Elements.Player.LocalPlayer.Handle, "mp_arresting", "arrest_on_floor_back_right_a", 1f, 4.0f, -1, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), 0, false, false, false);
            //RAGE.Game.Ai.TaskPlayAnim(tmp.Handle, "mp_arresting", "arrest_on_floor_back_right_b", 1f, 4.0f, -1, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), 0, false, false, false);

            RAGE.Game.Ai.ClearPedTasksImmediately(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == 0).Handle);
            RAGE.Game.Ai.ClearPedTasksImmediately(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == 1).Handle);

            RAGE.Game.Ped.SetSynchronizedSceneOrigin(scene, RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == 0).Position.X, RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == 0).Position.Y, RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == 0).Position.Z, 0, 0, 0, true);

            RAGE.Game.Ped.AttachSynchronizedSceneToEntity(scene, RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == 0).Handle, 28422);
            RAGE.Game.Ped.AttachSynchronizedSceneToEntity(scene, RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == 1).Handle, 28422);

            RAGE.Game.Ai.TaskPlayAnim(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == 0).Handle, "anim@mp_player_intcelebrationpaired@f_f_bro_hug", "bro_hug_left", 1f, 4.0f, -1, (int)(AnimationFlags.AllowPlayerControl), 0, false, false, false);
            RAGE.Game.Ai.TaskPlayAnim(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == 1).Handle, "anim@mp_player_intcelebrationpaired@f_f_bro_hug", "bro_hug_right", 1f, 4.0f, -1, (int)(AnimationFlags.AllowPlayerControl), 0, false, false, false);
            
            //RAGE.Game.Ai.task
            //RAGE.Game.Ai.TaskSynchronizedScene(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == 0).Handle, scene, "mp_arresting", "arrest_on_floor_back_right_a", 1.0f, 4.0f, 0, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), 0, 0);
            //RAGE.Game.Ai.TaskSynchronizedScene(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == 1).Handle, scene, "mp_arresting", "arrest_on_floor_back_right_b", 1.0f, 4.0f, 0, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), 0, 0);
            RAGE.Game.Ai.TaskSynchronizedScene(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == 0).Handle, scene, "anim@mp_player_intcelebrationpaired@f_f_bro_hug", "bro_hug_left", 1.0f, 1.0f, 0, (int)(AnimationFlags.AllowPlayerControl), 0x447a0000, 0);
            RAGE.Game.Ai.TaskSynchronizedScene(RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == 1).Handle, scene, "anim@mp_player_intcelebrationpaired@f_f_bro_hug", "bro_hug_right", 1.0f, 1.0f, 0, (int)(AnimationFlags.AllowPlayerControl), 0x447a0000, 0);
            active = true;
        }
    }*/
}
