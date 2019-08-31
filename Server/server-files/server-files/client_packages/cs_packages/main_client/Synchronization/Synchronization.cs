using System;
using System.Collections.Generic;
using System.Text;
using RAGE;
using RAGE.Elements;


namespace main_client.Synchronization
{
    /*class Synchronization : Events.Script
    {
        private RAGE.Elements.Player other = null;
        //private RAGE.Elements.Vehicle veh = null;

        private List<Vehicle> list_vehicule = new List<Vehicle>();


        public enum AnimationFlags
        {
            Loop = 1 << 0,
            StopOnLastFrame = 1 << 1,
            OnlyAnimateUpperBody = 1 << 4,
            AllowPlayerControl = 1 << 5,
            Cancellable = 1 << 7
        };


        public Synchronization()
        {
            Events.Add("ArrestPlayer", ArrestPlayer);
            Events.Add("IsFreezeClient", IsFreezeClient);
            Events.Add("IsAnimClient", IsAnimClient);
            Events.AddDataHandler("test_sync_player", test_sync_player);
            Events.AddDataHandler("test_sync_player_anim", test_sync_player_anim);
            Events.OnEntityStreamIn = OnStreamIn;
            Events.OnEntityStreamOut = OnStreamOut;
            Events.OnEntityDataChangeByKey += DataChange;

            Events.AddDataHandler("peer_to_peer_client_position", peer_to_peer_client_position);

            Events.Tick += OnTick;
        }

        private void peer_to_peer_client_position(Entity entity, object arg)
        {
            if (entity.Type == RAGE.Elements.Type.Player && other != null && entity == other)
            {
                if (((RAGE.Elements.Player)entity).GetHealth() <= 0 || other.GetHealth() <= 0)
                {
                    other.FreezePosition(true);
                    ((RAGE.Elements.Player)entity).FreezePosition(true);
                    RAGE.Game.Player.GivePlayerRagdollControl(false);
                    //Chat.Output("Player is death");
                    //((RAGE.Elements.Player)entity)
                } else if (((RAGE.Elements.Player)entity).GetHealth() > 0 || other.GetHealth() > 0)
                {
                    other.FreezePosition(false);
                    ((RAGE.Elements.Player)entity).FreezePosition(false);
                    RAGE.Game.Player.GivePlayerRagdollControl(true);
                    //Chat.Output("Player is not death");
                }

                //Chat.Output("Other " + other.Name + " " + Vector3.Distance(entity.Position, other.Position));
                if (Vector3.Distance(entity.Position, other.Position) > 0.1f)
                {
                    Chat.Output("Other " + other.Name + " " + Vector3.Distance(entity.Position, other.Position));
                    other.Position = entity.Position;
                    other.SetHeading(((RAGE.Elements.Player)entity).GetHeading());
                    //other = entity;
                }
            }
            if (entity.Type == RAGE.Elements.Type.Vehicle)
            {
                foreach (Vehicle veh in list_vehicule) {
                    if (entity == veh)
                    {
                        //Chat.Output("Vehicule Test " + veh.ToString() + " " + Vector3.Distance(entity.Position, veh.Position).ToString() + " " + entity.Position.ToString() + " " + veh.Position.ToString());
                        if (Vector3.Distance(entity.Position, veh.Position) > 0.01f)
                        {
                            Chat.Output("Vehicule " + veh.ToString() + " " + Vector3.Distance(entity.Position, veh.Position).ToString() + " " + entity.Position.ToString() + " " + veh.Position.ToString());
                            veh.Position = entity.Position;
                            veh.SetHeading(((RAGE.Elements.Vehicle)entity).GetHeading());
                        }
                    }
                }
               
            }
        }

        private void ArrestPlayer(object[] args)
        {
            //RAGE.Game.Ai.TaskClearLookAt(RAGE.Elements.Player.LocalPlayer.Handle);

            RAGE.Elements.Player tmp = (RAGE.Elements.Player)args[0];
            RAGE.Elements.Vehicle veh = (RAGE.Elements.Vehicle)args[1];
            //Ped ss = new RAGE.Elements.Ped(0xB564882B, RAGE.Elements.Player.LocalPlayer.Position + new Vector3(10, 0, 2));
            tmp.TaskEnterVehicle(veh.Handle, 1000, -1, 1, 1, 0);
            
            //RAGE.Game.Graphics.DrawScaleformMovie();
            //RAGE.Game.Ai.TaskGoToEntity(RAGE.Elements.Player.LocalPlayer.Handle, ss.Handle, -1, 1000, 1, 100, 0);
            //RAGE.Elements.Player.LocalPlayer.TaskClearLookAt();
            //RAGE.Elements.Player.LocalPlayer.TaskAimGunAtCoord(((RAGE.Elements.Player)args[0]).Position.X, ((RAGE.Elements.Player)args[0]).Position.Y, ((RAGE.Elements.Player)args[0]).Position.Z, 2000, true, true);
            //RAGE.Game.Ai.TaskEnterVehicle(tmp.Handle, veh.Handle, 0, -1, 1, 1, 0);
            //RAGE.Game.Ai.TaskGoToCoordAnyMeans(tmp.Handle, -429.7046f, 1172.925f, 325.9043f, 1f, 0, false, 786603, 0xbf800000);
        }

        private void DataChange(ulong key, Entity entity, object arg)
        {
            Chat.Output("Data changed ! " + entity.ToString());
        }

        private void test_sync_player_anim(Entity entity, object arg)
        {
            if (entity.Type == RAGE.Elements.Type.Player)
            {
                if (other != null && entity == other)
                {
                    Chat.Output("Handler " + other.Name);
                    other = (RAGE.Elements.Player)entity;
                    bool value = other.GetData<bool>("IsAnim");
                    RAGE.Game.Streaming.RequestAnimDict("amb@medic@standing@kneel@base");
                    while (!RAGE.Game.Streaming.HasAnimDictLoaded("amb@medic@standing@kneel@base")) { RAGE.Game.Invoker.Wait(0); };
                    RAGE.Game.Ai.TaskPlayAnim(other.Handle, "amb@medic@standing@kneel@base", "base", 8f, -1, -1, (int)(AnimationFlags.Loop), 0, false, false, false);
                    other.SetData<bool>("IsAnim", value);
                    Events.CallRemote("update_player", other);
                }
            }
        }

        private void IsFreezeClient(object[] args)
        {
            RAGE.Elements.Player.LocalPlayer.FreezePosition((bool)args[0]);
        }
        

        private void IsAnimClient(object[] args)
        {
            RAGE.Game.Streaming.RequestAnimDict("amb@medic@standing@kneel@base");
            while (!RAGE.Game.Streaming.HasAnimDictLoaded("amb@medic@standing@kneel@base")) { RAGE.Game.Invoker.Wait(0); };
            RAGE.Elements.Player.LocalPlayer.TaskPlayAnim("amb@medic@standing@kneel@base", "base", 8f, -1, -1, (int)(AnimationFlags.Loop), 0, false, false, false);
        }

        private void anim_sync_player(Entity entity, object arg)
        {
            if (entity.Type == RAGE.Elements.Type.Player)
            {
                if (other != null && entity == other)
                {
                    other = (RAGE.Elements.Player)entity;
                    bool value = other.GetData<bool>("IsAnim");
                    RAGE.Game.Streaming.RequestAnimDict("amb@medic@standing@kneel@base");
                    while (!RAGE.Game.Streaming.HasAnimDictLoaded("amb@medic@standing@kneel@base")) { RAGE.Game.Invoker.Wait(0); };
                    //RAGE.Game.

                    RAGE.Game.Ai.TaskPlayAnim(other.Handle, "amb@medic@standing@kneel@base", "base", 8f, -1, -1, (int)(AnimationFlags.Loop), 0, false, false, false);
                    other.SetData<bool>("IsAnim", value);
                    Events.CallRemote("update_player", other);
                }
            }
        }

        private void test_sync_player(Entity entity, object arg)
        {
            if (entity.Type == RAGE.Elements.Type.Player)
            {
                if (other != null && entity == other)
                {
                    Chat.Output("Handler " + other.Name);
                    other = (RAGE.Elements.Player)entity;
                    bool value = other.GetData<bool>("IsFreeze");
                    other.FreezePosition(value);
                    other.SetData<bool>("IsFreeze", value);
                    Events.CallRemote("update_player", other);
                }
            }
        }
        

        private void OnStreamIn(Entity entity)
        {
            if (entity.Type == RAGE.Elements.Type.Player)
            {
                Chat.Output("Player connected and add other !");
                if (other == null || other == entity)
                {
                    other = (RAGE.Elements.Player)entity;

                }
            }
            else if (entity.Type == RAGE.Elements.Type.Vehicle) {
                if (!list_vehicule.Contains((RAGE.Elements.Vehicle)entity)) {
                    list_vehicule.Add((RAGE.Elements.Vehicle)entity);
                }
            }
        }


        private void OnStreamOut(Entity entity)
        {

            if (entity.Type == RAGE.Elements.Type.Player)
            {
                Chat.Output("Player deconnect and sup other !");
                if (other != null)
                    other = null;
            }
        }

        private void OnTick(List<Events.TickNametagData> nametags)
        {
        }
    }*/
}
