using System;
using System.Collections.Generic;
using System.Text;
using RAGE;
using Newtonsoft.Json;
using CAPI = main_client.Ventura.Engine.Camera;

namespace main_client.Ventura.Engine
{
    class Animation : Events.Script
    {

        public delegate void AnimationFunction();
        public static List<AnimationFunction> list_function = new List<AnimationFunction>();
        private string data_name = main_client.Ventura.Constant.Constant.table_data_name[((int)main_client.Ventura.Constant.Constant.UpdateFlagsClient.WorldAnimationData >> 2) - 1];
        //private List<Utils.OClock> clock = new List<Utils.OClock>();


        public Animation()
        {
            list_function.Add(introduction_character);
            list_function.Add(introduction_left_head);
            list_function.Add(introduction_left_back_head);
            list_function.Add(introduction_right_head);
            list_function.Add(introduction_right_back_head);
            list_function.Add(introduction_character_out);
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

        // Animation Gestion Invoker

        public static void AnimationGestion(int index)
        {
            list_function[index]();
        }

        public void UpdateAnimationSync() {

        }

        // Delegate funuction

        public void introduction_character_out()
        {
            Events.CallRemote("UpdateWorldAnimationData", JsonConvert.SerializeObject(new StreamObject.WorldData.WorldAnimationData()
            {
                IsActive = true,
                Dict = "mp_character_creation@lineup@male_a",
                Anim = "outro",
                Speed = 1f,
                SpeedMultiplier = 8f,
                Id = 0,
                Name = "",
                RemoteId = RAGE.Elements.Player.LocalPlayer.RemoteId,
                Dimensions = RAGE.Elements.Player.LocalPlayer.Dimension,
                Type = 0,
                Flags = (int)(Constant.Constant.AnimationFlags.Loop),
                Duration = -1,
                LockX = false,
                LockY = false,
                LockZ = false,
                Playback = 0,
                tick = DateTime.Now.AddMilliseconds(6000).Ticks,
                next = null
            }));
            //Events.CallRemote("StartAnimation", "mp_character_creation@lineup@male_a", "outro", 8f);
            //Events.CallRemote("StartAnimation", "mp_character_creation@lineup@male_a", "outro", 8f);
            Utils.ThreadingTask.make_task_with_timeout(() => {
                CAPI.RenderView(false, 1);
                RAGE.Game.Cam.DoScreenFadeOut(1);
                //if (main_client.Player.Character.CharacterEditor.inf != "")
                //    Events.CallRemote("setCharacterServer", main_client.Player.Character.CharacterEditor.inf);
                Utils.ThreadingTask.make_task_with_timeout(() => {
                    Events.CallLocal("SetCharacterActives", 2, true);
                }, 2000);
            }, 6000);
        }



        public void introduction_character()
        {
            Events.CallRemote("UpdateWorldAnimationData", JsonConvert.SerializeObject(new StreamObject.WorldData.WorldAnimationData()
            {
                IsActive = true,
                Dict = "mp_character_creation@customise@male_a",
                Anim = "intro",
                Speed = 1f,
                SpeedMultiplier = 4f,
                Id = 0,
                Name = "",
                RemoteId = RAGE.Elements.Player.LocalPlayer.RemoteId,
                Dimensions = RAGE.Elements.Player.LocalPlayer.Dimension,
                Type = 0,
                Flags = (int)(Constant.Constant.AnimationFlags.Loop),
                Duration = -1,
                LockX = false,
                LockY = false,
                LockZ = false,
                Playback = 0,
                tick = DateTime.Now.AddMilliseconds(7000).Ticks,
                next = new StreamObject.WorldData.WorldAnimationData()
                {
                    IsActive = true,
                    Dict = "mp_character_creation@customise@male_a",
                    Anim = "loop",
                    Speed = 1f,
                    SpeedMultiplier = 1f,
                    Id = 1,
                    Name = "",
                    RemoteId = RAGE.Elements.Player.LocalPlayer.RemoteId,
                    Dimensions = RAGE.Elements.Player.LocalPlayer.Dimension,
                    Type = 0,
                    Flags = (int)(Constant.Constant.AnimationFlags.Loop),
                    Duration = -1,
                    LockX = false,
                    LockY = false,
                    LockZ = false,
                    Playback = 0,
                    tick = DateTime.Now.AddHours(24).Ticks,
                    next = null
                }
            }));
            Constant.Constant.Notify("Bienvenu sur ~p~Ventura~w~, L'éditor possède plusieurs functionnalités");
            Constant.Constant.Notify("~p~A-E~w~ pour tourner la tête");
            Constant.Constant.Notify("~p~Z-S-D-Q-W~w~ pour changer de caméra");
            Constant.Constant.Notify("Pour confirmer appuyer sur ~p~N~w~");
            Utils.OTicks.instance.AddClockToInstance(new Utils.OClock(0, 0, 7, 0, () => {
                Constant.Constant.Notify("Bienvenu sur ~p~Ventura~w~, L'éditor possède plusieurs functionnalités");
                Constant.Constant.Notify("~p~A-E~w~ pour tourner la tête");
                Constant.Constant.Notify("~p~Z-S-D-Q-W~w~ pour changer de caméra");
                Constant.Constant.Notify("Pour confirmer appuyer sur ~p~N~w~");
                Events.CallLocal("MoveCam", 7);
                Events.CallLocal("createBrowser", "CharacterEditorForm", "package://MenuCharacterEditor/index.html");
            }));
            /*Utils.ThreadingTask.make_task_with_timeout(() => {
            }, 8000);*/
        }

        public void introduction_left_head()
        {
            Events.CallRemote("UpdateWorldAnimationData", JsonConvert.SerializeObject(new StreamObject.WorldData.WorldAnimationData()
            {
                IsActive = true,
                Dict = "mp_character_creation@customise@male_a",
                Anim = "profile_l_intro",
                Speed = 1f,
                SpeedMultiplier = 4f,
                Id = 0,
                Name = "",
                RemoteId = RAGE.Elements.Player.LocalPlayer.RemoteId,
                Dimensions = RAGE.Elements.Player.LocalPlayer.Dimension,
                Type = 0,
                Flags = (int)(Constant.Constant.AnimationFlags.Loop),
                Duration = -1,
                LockX = false,
                LockY = false,
                LockZ = false,
                Playback = 0,
                tick = DateTime.Now.AddMilliseconds(200).Ticks,
                next = new StreamObject.WorldData.WorldAnimationData()
                {
                    IsActive = true,
                    Dict = "mp_character_creation@customise@male_a",
                    Anim = "profile_l_loop",
                    Speed = 1f,
                    SpeedMultiplier = 1f,
                    Id = 1,
                    Name = "",
                    RemoteId = RAGE.Elements.Player.LocalPlayer.RemoteId,
                    Dimensions = RAGE.Elements.Player.LocalPlayer.Dimension,
                    Type = 0,
                    Flags = (int)(Constant.Constant.AnimationFlags.Loop),
                    Duration = -1,
                    LockX = false,
                    LockY = false,
                    LockZ = false,
                    Playback = 0,
                    tick = DateTime.Now.AddHours(24).Ticks,
                    next = null
                }
            }));
            /*Events.CallRemote("StartAnimation", "mp_character_creation@customise@male_a", "profile_l_intro", 1f);
            Utils.ThreadingTask.make_task_with_timeout(() => {
                Events.CallRemote("StartAnimation", "mp_character_creation@customise@male_a", "profile_l_loop", 1f);
            }, 400);*/
        }

        public void introduction_right_head()
        {
            Events.CallRemote("UpdateWorldAnimationData",  JsonConvert.SerializeObject(new StreamObject.WorldData.WorldAnimationData()
            {
                IsActive = true,
                Dict = "mp_character_creation@customise@male_a",
                Anim = "profile_r_intro",
                Speed = 1f,
                SpeedMultiplier = 4f,
                Id = 0,
                Name = "",
                RemoteId = RAGE.Elements.Player.LocalPlayer.RemoteId,
                Dimensions = RAGE.Elements.Player.LocalPlayer.Dimension,
                Type = 0,
                Flags = (int)(Constant.Constant.AnimationFlags.Loop),
                Duration = -1,
                LockX = false,
                LockY = false,
                LockZ = false,
                Playback = 0,
                tick = DateTime.Now.AddMilliseconds(10).Ticks,
                next = new StreamObject.WorldData.WorldAnimationData()
                {
                    IsActive = true,
                    Dict = "mp_character_creation@customise@male_a",
                    Anim = "profile_r_loop",
                    Speed = 1f,
                    SpeedMultiplier = 1f,
                    Id = 1,
                    Name = "",
                    RemoteId = RAGE.Elements.Player.LocalPlayer.RemoteId,
                    Dimensions = RAGE.Elements.Player.LocalPlayer.Dimension,
                    Type = 0,
                    Flags = (int)(Constant.Constant.AnimationFlags.Loop),
                    Duration = -1,
                    LockX = false,
                    LockY = false,
                    LockZ = false,
                    Playback = 0,
                    tick = DateTime.Now.AddHours(24).Ticks,
                    next = null
                }
            }));
            /*Events.CallRemote("StartAnimation", "mp_character_creation@customise@male_a", "profile_r_intro", 1f);
            Utils.ThreadingTask.make_task_with_timeout(() => {
                Events.CallRemote("StartAnimation", "mp_character_creation@customise@male_a", "profile_r_loop", 1f);
            }, 400);*/
        }

        public void introduction_left_back_head()
        {
            Events.CallRemote("UpdateWorldAnimationData", JsonConvert.SerializeObject(new StreamObject.WorldData.WorldAnimationData()
            {
                IsActive = true,
                Dict = "mp_character_creation@customise@male_a",
                Anim = "profile_l_outro",
                Speed = 1f,
                SpeedMultiplier = 4f,
                Id = 0,
                Name = "",
                RemoteId = RAGE.Elements.Player.LocalPlayer.RemoteId,
                Dimensions = RAGE.Elements.Player.LocalPlayer.Dimension,
                Type = 0,
                Flags = (int)(Constant.Constant.AnimationFlags.Loop),
                Duration = -1,
                LockX = false,
                LockY = false,
                LockZ = false,
                Playback = 0,
                tick = DateTime.Now.AddMilliseconds(10).Ticks,
                next = new StreamObject.WorldData.WorldAnimationData()
                {
                    IsActive = true,
                    Dict = "mp_character_creation@customise@male_a",
                    Anim = "loop",
                    Speed = 1f,
                    SpeedMultiplier = 1f,
                    Id = 1,
                    Name = "",
                    RemoteId = RAGE.Elements.Player.LocalPlayer.RemoteId,
                    Dimensions = RAGE.Elements.Player.LocalPlayer.Dimension,
                    Type = 0,
                    Flags = (int)(Constant.Constant.AnimationFlags.Loop),
                    Duration = -1,
                    LockX = false,
                    LockY = false,
                    LockZ = false,
                    Playback = 0,
                    tick = DateTime.Now.AddHours(24).Ticks,
                    next = null
                }
            }));
            /*Events.CallRemote("StartAnimation", "mp_character_creation@customise@male_a", "profile_l_outro", 1f);
            Utils.ThreadingTask.make_task_with_timeout(() => {
                Events.CallRemote("StartAnimation", "mp_character_creation@customise@male_a", "loop", 1f);
            }, 400);*/
        }

        public void introduction_right_back_head()
        {
            Events.CallRemote("UpdateWorldAnimationData", JsonConvert.SerializeObject(new StreamObject.WorldData.WorldAnimationData()
            {
                IsActive = true,
                Dict = "mp_character_creation@customise@male_a",
                Anim = "profile_r_outro",
                Speed = 1f,
                SpeedMultiplier = 4f,
                Id = 0,
                Name = "",
                RemoteId = RAGE.Elements.Player.LocalPlayer.RemoteId,
                Dimensions = RAGE.Elements.Player.LocalPlayer.Dimension,
                Type = 0,
                Flags = (int)(Constant.Constant.AnimationFlags.Loop),
                Duration = -1,
                LockX = false,
                LockY = false,
                LockZ = false,
                Playback = 0,
                tick = DateTime.Now.AddMilliseconds(10).Ticks,
                next = new StreamObject.WorldData.WorldAnimationData()
                {
                    IsActive = true,
                    Dict = "mp_character_creation@customise@male_a",
                    Anim = "loop",
                    Speed = 1f,
                    SpeedMultiplier = 1f,
                    Id = 1,
                    Name = "",
                    RemoteId = RAGE.Elements.Player.LocalPlayer.RemoteId,
                    Dimensions = RAGE.Elements.Player.LocalPlayer.Dimension,
                    Type = 0,
                    Flags = (int)(Constant.Constant.AnimationFlags.Loop),
                    Duration = -1,
                    LockX = false,
                    LockY = false,
                    LockZ = false,
                    Playback = 0,
                    tick = DateTime.Now.AddHours(24).Ticks,
                    next = null
                }
            }));
            /*Events.CallRemote("StartAnimation", "mp_character_creation@customise@male_a", "profile_r_outro", 1f);
            Utils.ThreadingTask.make_task_with_timeout(() => {
                Events.CallRemote("StartAnimation", "mp_character_creation@customise@male_a", "loop", 1f);
            }, 400);*/
        }
    }
}









/*if (active) {
             EAPI.Entity tmp = null;
             float max = 25f;
             /*foreach (EAPI.Entity ent in list_entity)
             {
                 if (Vector3.Distance(ent.Position, EAPI.Player.LocalPlayer.Position) < max)
                 {
                     max = Vector3.Distance(ent.Position, EAPI.Player.LocalPlayer.Position);
                     tmp = ent;
                 }
             }
             if (weapon != null)
             {
                 tmp = weapon;
             }

             if (tmp != null)
             {
                 if (marker == null)
                 {
                     //Random rand = new Random();
                     marker = new EAPI.Marker(27, tmp.Position, 1f, new Vector3(0, 90, 0), new Vector3(), new RGBA(0, 0 , 255));
                     marker.Rotating = true;
                 }
                 else
                 {
                     marker.Position = tmp.Position + new Vector3(0, 0, 0.2f);
                     if (RAGE.Input.IsDown((int)ConsoleKey.K))
                     {
                         Events.CallRemote("TakeWeapon", tmp);
                         //Events.CallRemote("GiveMoneyToPlayer", tmp.RemoteId, 100);
                         RAGE.Game.Invoker.Wait(100);
                     }

                 }
             }
             else if (marker != null){
                 marker = null;
                 //marker.Destroy();
             }
             //RAGE.Game.Graphics.DrawMarker(27, position.X, position.Y, position.Z, 0, 0, 0, 0, 0, 0, 1f, 1f, 1f, 254, 0, 0, 254, false, false, 2, false, "Closest_Player", "C_PLayer", true);
             //Events.CallRemote("update_player_closest");
         }*/
