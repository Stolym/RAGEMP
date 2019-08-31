using System;
using System.Collections.Generic;
using System.Text;
using RAGE;
using System.Threading.Tasks;

namespace main_client.Player.Character
{
    /*class Vehicule : Events.Script
    {


        public Vehicule()
        {
            /*Events.Add("OpenDoor", openDoor);
            //Events.Add("AnimationSyncLaunch", AnimationSyncLaunch);
            //Events.Add("AnimationSyncClose", AnimationSyncClose);
            Events.Add("MecanoSetActive", MecanoSetActive);
            Events.Add("InclinVehiculeMecano", InclinVehiculeMecano);
            Events.Add("RepairVehiculeMecano", RepairVehiculeMecano);
            Events.Add("GetDoorPos", GetDoorPos);

            Events.OnEntityStreamIn += OnEntityStreamIn;
            Events.Tick += tick;
        }

        RAGE.Elements.MapObject obj = null;

        bool[] actives = new bool[4] { false, false, false , false };
        

        public void tick(List<Events.TickNametagData> nametags)
        {
            if (Input.IsDown((int)ConsoleKey.M) && actives[0] == false)
            {
                Events.CallRemote("MecanoRepair");
                actives[0] = !actives[0];
            }
            if (Input.IsDown((int)ConsoleKey.W) && actives[0] == false)
            {
                Events.CallRemote("MecanoRemoveVehicule");
                actives[0] = !actives[0];
            }
        }

        public void GetDoorPos(object[] args)
        {
            RAGE.Elements.Vehicle vehicle = (RAGE.Elements.Vehicle)args[0];
            //Vector3 tmp = new Vector3(vehicle.GetWorldPositionOfBone(vehicle.GetBoneIndexByName("wheel_lf")).X, vehicle.GetWorldPositionOfBone(vehicle.GetBoneIndexByName("wheel_lf")).Y, vehicle.GetWorldPositionOfBone(vehicle.GetBoneIndexByName("wheel_lf")).Z);
            //vehicle.SetData<Vector3>("DoorPos0", new Vector3(vehicle.GetWorldPositionOfBone(vehicle.GetBoneIndexByName("wheel_lf")).X, vehicle.GetWorldPositionOfBone(vehicle.GetBoneIndexByName("wheel_lf")).Y, vehicle.GetWorldPositionOfBone(vehicle.GetBoneIndexByName("wheel_lf")).Z));
            //vehicle.SetData<Vector3>("DoorPos1", new Vector3(vehicle.GetWorldPositionOfBone(vehicle.GetBoneIndexByName("wheel_rf")).X, vehicle.GetWorldPositionOfBone(vehicle.GetBoneIndexByName("wheel_rf")).Y, vehicle.GetWorldPositionOfBone(vehicle.GetBoneIndexByName("wheel_rf")).Z));
            //Chat.Output("TEST   " + vehicle.GetWorldPositionOfBone(vehicle.GetBoneIndexByName("wheel_lf")));
            //Chat.Output("TEST 2  " + new Vector3(vehicle.GetWorldPositionOfBone(vehicle.GetBoneIndexByName("wheel_lf")).X, vehicle.GetWorldPositionOfBone(vehicle.GetBoneIndexByName("wheel_lf")).Y, vehicle.GetWorldPositionOfBone(vehicle.GetBoneIndexByName("wheel_lf")).Z));
            Events.CallRemote("SetDataVehiculeValue", vehicle.GetWorldPositionOfBone(vehicle.GetBoneIndexByName("door_dside_f")).X, vehicle.GetWorldPositionOfBone(vehicle.GetBoneIndexByName("door_dside_f")).Y, vehicle.GetWorldPositionOfBone(vehicle.GetBoneIndexByName("door_dside_f")).Z, vehicle.GetWorldPositionOfBone(vehicle.GetBoneIndexByName("door_pside_f")).X, vehicle.GetWorldPositionOfBone(vehicle.GetBoneIndexByName("wheel_rf")).Y, vehicle.GetWorldPositionOfBone(vehicle.GetBoneIndexByName("door_pside_f")).Z, vehicle.GetWorldPositionOfBone(vehicle.GetBoneIndexByName("bumper_f")).X, vehicle.GetWorldPositionOfBone(vehicle.GetBoneIndexByName("bumper_f")).Y, vehicle.GetWorldPositionOfBone(vehicle.GetBoneIndexByName("bumper_f")).Z);
        }

        public void InclinVehiculeMecano(object[] args)
        {
            RAGE.Elements.Vehicle vehicle = (RAGE.Elements.Vehicle)args[0];
            RAGE.Elements.MapObject obj = (RAGE.Elements.MapObject)args[1];
            int side = (int)args[2];

            vehicle.Position += new Vector3(0, 0, side == -1 ? -0.1f : 0.1f);
            vehicle.SetHeading(0f);
            vehicle.SetRotation(0, side == 1 ? 15 : side == -1 ? 0 : -15, 1, 1, true);
            vehicle.FreezePosition(side == -1 ? false : true);

        }


        public void RepairVehiculeMecano(object[] args)
        {
            RAGE.Elements.Vehicle vehicle = (RAGE.Elements.Vehicle)args[0];

            vehicle.SetFixed();
            vehicle.SetHealth(10);
            vehicle.FreezePosition(false);
        }


        public void MecanoSetActive(object[] args)
        {
            actives[(int)args[0]] = (bool)args[1];
        }


        public void openDoor(object[] args)
        {
            RAGE.Elements.Vehicle vehicle = (RAGE.Elements.Vehicle)args[0];
            string doorId = (string)args[1];
            float angle = (float)args[2];

            Chat.Output("Test Test");

            vehicle.SetDoorOpen(Convert.ToInt32(doorId), angle == 0 ? false : true, angle == 0 ? false : true);
            vehicle.SetDoorControl(Convert.ToInt32(doorId), 1, angle);
            vehicle.FreezePosition(angle == 0 ? false : true);

        }

        public void AnimationSyncLaunch(object[] args)
        {
            Chat.Output("Salut");
            RAGE.Elements.Player _player = (RAGE.Elements.Player)args[0];
            //RAGE.Game.Streaming.RequestAnimDict((string)args[1]);
            _player.PlaySynchronizedAnim((int)args[3], (string)args[1], (string)args[2], 8.0f, -8.0f, -1, 1);
            //_player.PlayAnim((string)args[1], (string)args[2], 8.0f, true, true, false, 0, 0);

            /*Task.Run(() =>
            {
                //while (!RAGE.Game.Streaming.HasAnimDictLoaded((string)args[1])) { RAGE.Game.Utils.Wait(0); };
                //_player.PlaySynchronizedAnim((int)args[3], (string)args[1], (string)args[2], 8.0f, -8.0f, -1, 1);
            });
        }

        public void AnimationSyncClose(object[] args)
        {
            RAGE.Elements.Player _player = (RAGE.Elements.Player)args[0];
            _player.StopSynchronizedAnim((int)args[1], true);
        }

        public void OnEntityStreamIn(RAGE.Elements.Entity entity)
        {
            if (entity.Type == RAGE.Elements.Type.Vehicle)
            {
                RAGE.Elements.Vehicle vehicle = (RAGE.Elements.Vehicle)entity;
                vehicle.FreezePosition(true);
                for (int i = 0; i < 7; i++)
                {
                    if (vehicle.GetSharedData(i.ToString()) != null)
                    {
                        
                        //vehicle.SetDoorOpen(i, true, true);
                        //vehicle.Position += new Vector3(0, 0, 0.1f);
                        //vehicle.SetRotation(0, 15, 1, 1, true);
                        //vehicle.SetDoorControl(i, 2, (float)vehicle.GetSharedData(i.ToString()));
                        vehicle.FreezePosition(false);
                    }
                }
            }
            else if (entity.Type == RAGE.Elements.Type.Ped)
            {
                RAGE.Elements.Ped ped = (RAGE.Elements.Ped)entity;
                if (ped.GetSharedData("Animation") != null)
                {
                    RAGE.Game.Streaming.RequestAnimDict("amb@world_human_vehicle_mechanic@male@idle_a");
                    ped.TaskPlayAnim("amb@world_human_vehicle_mechanic@male@idle_a", "idle_a", 8.0f, -8.0f, -1, 1, 0.0f, false, false, false);
                }
            }
            else if (entity.Type == RAGE.Elements.Type.Player)
            {
                RAGE.Elements.Player _player = (RAGE.Elements.Player)entity;
                if (_player.GetSharedData("AnimationSyncLaunch") != null)
                {
                    Chat.Output("Animation 2");
                    object[] objs = (object[])_player.GetSharedData("AnimationSyncLaunch");

                    RAGE.Game.Streaming.RequestAnimDict((string)objs[0]);
                    while (!RAGE.Game.Streaming.HasAnimDictLoaded((string)objs[0])) { RAGE.Game.Utils.Wait(0); };
                    //_player.PlaySynchronizedAnim(0, (string)objs[0], (string)objs[1], 8.0f, -8.0f, -1, 1);
                    
                    _player.TaskPlayAnim((string)objs[0], (string)objs[1], 8.0f, -8.0f, -1, 1, 0.0f, false, false, false);
                    //_player.TaskPlayAnim(objs[0], objs[1], -8, 8, -1, );
                }
                else if (_player.GetSharedData("AnimationSyncClose") != null)
                {
                    _player.StopSynchronizedAnim((int)_player.GetSharedData("AnimationSyncClose"), true);
                }

            }
            /*else if (entity.Type == RAGE.Elements.Type.Object)
            {
                RAGE.Elements.MapObject objects = (RAGE.Elements.MapObject)entity;
                if (objects.GetSharedData("AttachElement") != null)
                {
                    objects.FreezePosition(false);
                    objects.SetCollision(false, true);
                    objects.SetDynamic(true);

                }
            }
        }
    }*/
}
