using System;
using System.Collections.Generic;
using System.Text;
using RAGE;
using A = RAGE.Elements;
using Newtonsoft.Json;

namespace main_client.Ventura.Utils
{


    class OTicks : Events.Script
    {
        public static OTicks instance = null;
        public List<Utils.OClock> clock = new List<Utils.OClock>();
        public List<Utils.OClockEvent> clockEvent = new List<Utils.OClockEvent>();
        public List<long> ticks = new List<long>();
        public int[] addticks = new int[2] { 0, 3 };
        public List<double> time = new List<double>() { 100, 100, 100, 100, 100, 100, 100, 100, 100, 20, 100, 100, 100, 100, 100 };
        private long ftick = 0x0000000000000000;


        // Function 
        public void AddClockToInstance(OClock clock)
        {
            this.clock.Add(clock);
        }

        public void AddClockEventToInstance(OClockEvent clock)
        {
            this.clockEvent.Add(clock);
        }



        //

        public OTicks() {
            AddTick();
            instance = this;
            Events.Tick += OnTick;
        }

        private void AddTick()
        {
            for (int i = 0; i < main_client.Ventura.Constant.Constant.table_event_name.Count + addticks[1]; i++)
                ticks.Add(0);
            for (int i = 0; i < addticks[1]; i++)
                time.Add(100);
            addticks[0] = main_client.Ventura.Constant.Constant.table_event_name.Count - 1;
        }

        private void StartTicksClock() {
            for (int i = 0; i < ticks.Count; i++) {
                if (ticks[i] == 0)
                    ticks[i] = DateTime.Now.AddMilliseconds(time[i]).Ticks;
            }
            if (ftick == 0)
                ftick = DateTime.Now.AddSeconds(1).Ticks;
        }

        private void OClocksTicks()
        {
            Utils.OClock tmp = null;
            for (int i = 0; i < clock.Count; i++)
            {
                if (clock[i].Done())
                    tmp = clock[i];
            }
            if (tmp != null)
                clock.Remove(tmp);
            tmp = null;
        }
        private void OClocksEventTicks()
        {
            Utils.OClockEvent tmp = null;
            for (int i = 0; i < clockEvent.Count; i++)
            {
                if (clockEvent[i].Done())
                    tmp = clockEvent[i];
            }
            if (tmp != null)
                clockEvent.Remove(tmp);
            tmp = null;
        }


        private void StreamDataTicks()
        {
            IntroductionActivity(0);
            StreamObject.StreamData.StreamPedData.instance.OnTick();
            Utils.Debug.instance.OnTick();
            for (int i = 0; i < main_client.Ventura.Constant.Constant.table_event_name.Count; i++) {
                switch (i)
                {
                    case 15:
                        //IntroductionActivity(i);
                        break;
                    case 16:
                        break;
                    case 17:
                        break;
                }
                switch (main_client.Ventura.Constant.Constant.table_event_name[i]) {
                    case "WorldJobsActivityData":
                        WorldJobsActivityData(i, main_client.Ventura.Constant.Constant.table_data_name[i]);
                        break;
                    case "WorldAnimationData":
                        WorldAnimationData(i, main_client.Ventura.Constant.Constant.table_data_name[i]);
                        break;
                    case "WorldSceneData":
                        WorldSceneData(i, main_client.Ventura.Constant.Constant.table_data_name[i]);
                        break;
                    case "WorldSeatData":
                        WorldSeatData(i, main_client.Ventura.Constant.Constant.table_data_name[i]);
                        break;
                    case "WorldBodyData":
                        WorldBodyData(i, main_client.Ventura.Constant.Constant.table_data_name[i]);
                        break;
                    case "WorldClothData":
                        WorldClothData(i, main_client.Ventura.Constant.Constant.table_data_name[i]);
                        break;
                    case "WorldVehicleData":
                        WorldVehicleData(i, main_client.Ventura.Constant.Constant.table_data_name[i]);
                        break;
                    case "WorldObjectData":
                        WorldObjectData(i, main_client.Ventura.Constant.Constant.table_data_name[i]);
                        break;
                    case "WorldAttachData":
                        WorldAttachData(i, main_client.Ventura.Constant.Constant.table_data_name[i]);
                        break;
                    case "WorldFightData":
                        WorldFightData(i, main_client.Ventura.Constant.Constant.table_data_name[i]);
                        break;
                    case "WorldIdentityData":
                        WorldIdentityData(i, main_client.Ventura.Constant.Constant.table_data_name[i]);
                        break;
                    case "WorldUserData":
                        WorldUserData(i, main_client.Ventura.Constant.Constant.table_data_name[i]);
                        break;
                    case "WorldTattooData":
                        WorldJobsActivityData(i, main_client.Ventura.Constant.Constant.table_data_name[i]);
                        break;
                    case "WorldRigidBodyData":
                        WorldRigidBodyData(i, main_client.Ventura.Constant.Constant.table_data_name[i]);
                        break;
                    case "WorldDoorData":
                        WorldDoorData(i, main_client.Ventura.Constant.Constant.table_data_name[i]);
                        break;
                }
            }
        }

        private void IntroductionActivity(int i)
        {
            Ventura.Engine.Introduction.instance.OnTick();
        }

        private void WorldJobsActivityData(int i, string data_name)
        {
            if (DateTime.Now.Ticks < ticks[i])
                return;
            foreach (var client in A.Entities.Players.All)
            {
                if (client.GetSharedData(data_name) == null && client.GetData<string>(data_name) == null)
                    continue;
                else if (client.GetSharedData(data_name) != null && DateTime.Now.Ticks > ticks[i])
                {
                    JsonConvert.DeserializeObject<StreamObject.WorldData.WorldAnimationData>((string)client.GetSharedData(data_name)).StreamIn();
                    ticks[i] = 0;
                }
                else if (client.GetData<string>(data_name) != null && DateTime.Now.Ticks > ticks[i])
                {
                    JsonConvert.DeserializeObject<StreamObject.WorldData.WorldAnimationData>((string)client.GetData<string>(data_name)).StreamIn();
                    ticks[i] = 0;
                }
            }
        }

        private void WorldAnimationData(int i, string data_name)
        {
            if (DateTime.Now.Ticks < ticks[i])
                return;
            foreach (var client in A.Entities.Players.All)
            {
                if (client.GetSharedData(data_name) == null && client.GetData<string>(data_name) == null)
                    continue;
                else if (client.GetSharedData(data_name) != null && DateTime.Now.Ticks > ticks[i])
                {
                    //Chat.Output(client.GetSharedData(data_name).ToString());
                    JsonConvert.DeserializeObject<StreamObject.WorldData.WorldAnimationData>((string)client.GetSharedData(data_name)).StreamIn();
                    ticks[i] = 0;
                }
                else if (client.GetData<string>(data_name) != null && DateTime.Now.Ticks > ticks[i])
                {
                    JsonConvert.DeserializeObject<StreamObject.WorldData.WorldAnimationData>((string)client.GetData<string>(data_name)).StreamIn();
                    ticks[i] = 0;
                }
            }
        }

        private void WorldSceneData(int i, string data_name)
        {
            if (DateTime.Now.Ticks < ticks[i])
                return;
            foreach (var client in A.Entities.Players.All)
            {
                if (client.GetSharedData(data_name) == null && client.GetData<string>(data_name) == null)
                    continue;
                else if (client.GetSharedData(data_name) != null && DateTime.Now.Ticks > ticks[i])
                {
                    JsonConvert.DeserializeObject<StreamObject.WorldData.WorldSceneData>((string)client.GetSharedData(data_name)).StreamIn();
                    ticks[i] = 0;
                }
                else if (client.GetData<string>(data_name) != null && DateTime.Now.Ticks > ticks[i])
                {
                    JsonConvert.DeserializeObject<StreamObject.WorldData.WorldRigidBodyData>((string)client.GetSharedData(data_name)).StreamIn();
                    ticks[i] = 0;
                }
            }
        }

        private void WorldSeatData(int i, string data_name)
        {
            if (DateTime.Now.Ticks < ticks[i])
                return;
            foreach (var client in A.Entities.Players.All)
            {
                if (client.GetSharedData(data_name) == null && client.GetData<string>(data_name) == null)
                    continue;
                else if (client.GetSharedData(data_name) != null && DateTime.Now.Ticks > ticks[i])
                {
                    JsonConvert.DeserializeObject<StreamObject.WorldData.WorldAnimationData>((string)client.GetSharedData(data_name)).StreamIn();
                    ticks[i] = 0;
                }
                else if (client.GetData<string>(data_name) != null && DateTime.Now.Ticks > ticks[i])
                {
                    JsonConvert.DeserializeObject<StreamObject.WorldData.WorldAnimationData>((string)client.GetData<string>(data_name)).StreamIn();
                    ticks[i] = 0;
                }
            }
        }

        private void WorldBodyData(int i, string data_name)
        {
            if (DateTime.Now.Ticks < ticks[i])
                return;
            foreach (var client in A.Entities.Players.All)
            {

                if (client.GetSharedData(data_name) == null && client.GetData<string>(data_name) == null)
                    continue;
                else if (client.GetSharedData(data_name) != null && DateTime.Now.Ticks > ticks[i])
                {
                    var data = JsonConvert.DeserializeObject<StreamObject.WorldData.WorldBodyData>((string)client.GetSharedData(data_name), Constant.Constant.setting);
                    if (data != null)
                        data.StreamIn();
                    ticks[i] = 0;
                }
                else if (client.GetData<string>(data_name) != null && DateTime.Now.Ticks > ticks[i])
                {
                    JsonConvert.DeserializeObject<StreamObject.WorldData.WorldBodyData>(client.GetData<string>(data_name)).StreamIn();
                    ticks[i] = 0;
                }

            }
        }

        private void WorldClothData(int i, string data_name)
        {
            if (DateTime.Now.Ticks < ticks[i])
                return;
            foreach (var client in A.Entities.Players.All)
            {
                if (client.GetSharedData(data_name) == null && client.GetData<string>(data_name) == null)
                    continue;
                else if (client.GetSharedData(data_name) != null && DateTime.Now.Ticks > ticks[i])
                {
                    var data = JsonConvert.DeserializeObject<StreamObject.WorldData.WorldClothData>(client.GetSharedData(data_name).ToString(), Constant.Constant.setting);
                    if (data != null)
                        data.StreamIn();
                    ticks[i] = 0;
                }
                else if (client.GetData<string>(data_name) != null && DateTime.Now.Ticks > ticks[i])
                {
                    JsonConvert.DeserializeObject<StreamObject.WorldData.WorldClothData>(client.GetData<string>(data_name)).StreamIn();
                    ticks[i] = 0;
                }
            }
        }

        private void WorldVehicleData(int i, string data_name)
        {
            if (DateTime.Now.Ticks < ticks[i])
                return;
            
            foreach (var veh in A.Entities.Vehicles.All)
            {
                if (veh.GetSharedData(data_name) != null && DateTime.Now.Ticks > ticks[i])
                {

                    JsonConvert.DeserializeObject<StreamObject.WorldData.WorldVehicleData>((string)veh.GetSharedData(data_name)).StreamIn();
                    //if (RAGE.Game.Vehicle.GetPedInVehicleSeat(veh.Handle, -1, 0) == RAGE.Elements.Player.LocalPlayer.Handle && DateTime.Now.Ticks > ftick)
                    //{
                    //    ftick = 0;
                    //}

                    ticks[i] = 0;
                }
            }
        }

        private void WorldObjectData(int i, string data_name)
        {
            if (DateTime.Now.Ticks < ticks[i])
                return;
            foreach (var client in A.Entities.Players.All)
            {
                if (client.GetSharedData(data_name) == null && client.GetData<string>(data_name) == null)
                    continue;
                else if (client.GetSharedData(data_name) != null && DateTime.Now.Ticks > ticks[i])
                {
                    JsonConvert.DeserializeObject<StreamObject.WorldData.WorldAnimationData>((string)client.GetSharedData(data_name)).StreamIn();
                    ticks[i] = 0;
                }
                else if (client.GetData<string>(data_name) != null && DateTime.Now.Ticks > ticks[i])
                {
                    JsonConvert.DeserializeObject<StreamObject.WorldData.WorldAnimationData>((string)client.GetData<string>(data_name)).StreamIn();
                    ticks[i] = 0;
                }
            }
        }

        private void WorldAttachData(int i, string data_name)
        {
            if (DateTime.Now.Ticks < ticks[i])
                return;
            foreach (var client in A.Entities.Players.All)
            {

                if (client.GetSharedData(data_name) == null && client.GetData<string>(data_name) == null)
                    continue;
                /*else if (client.GetSharedData(data_name) != null && client.GetData<string>(data_name) == null && DateTime.Now.Ticks > tick)
                {
                    var data = JsonConvert.DeserializeObject<List<StreamObject.WorldData.WorldAttachData>>((string)client.GetSharedData(data_name));
                    for (int i = 0; i < data.Count; i++)
                        data[i].StreamIn();
                    client.SetData<string>(data_name, JsonConvert.SerializeObject(data));
                    tick = 0;
                }*/
                else if (client.GetData<string>(data_name) != null && DateTime.Now.Ticks > ticks[i])
                {
                    var data = JsonConvert.DeserializeObject<List<StreamObject.WorldData.WorldAttachData>>(client.GetData<string>(data_name));
                    for (int j = 0; j < data.Count; j++)
                        data[j].StreamIn();
                    ticks[i] = 0;
                }
            }
        }

        private void WorldFightData(int i, string data_name)
        {
            if (DateTime.Now.Ticks < ticks[i])
                return;
            foreach (var client in A.Entities.Players.All)
            {
                if (client.GetSharedData(data_name) == null && client.GetData<string>(data_name) == null)
                    continue;
                else if (client.GetSharedData(data_name) != null && DateTime.Now.Ticks > ticks[i])
                {
                    JsonConvert.DeserializeObject<StreamObject.WorldData.WorldFightData>((string)client.GetSharedData(data_name)).StreamIn();
                    ticks[i] = 0;
                }
                else if (client.GetData<string>(data_name) != null && DateTime.Now.Ticks > ticks[i])
                {
                    JsonConvert.DeserializeObject<StreamObject.WorldData.WorldFightData>((string)client.GetData<string>(data_name)).StreamIn();
                    ticks[i] = 0;
                }
            }
        }

        private void WorldIdentityData(int i, string data_name)
        {
            if (DateTime.Now.Ticks < ticks[i])
                return;
            foreach (var client in A.Entities.Players.All)
            {
                if (client.GetSharedData(data_name) == null && client.GetData<string>(data_name) == null)
                    continue;
                else if (client.GetSharedData(data_name) != null && DateTime.Now.Ticks > ticks[i])
                {
                    JsonConvert.DeserializeObject<StreamObject.WorldData.WorldAnimationData>((string)client.GetSharedData(data_name)).StreamIn();
                    ticks[i] = 0;
                }
                else if (client.GetData<string>(data_name) != null && DateTime.Now.Ticks > ticks[i])
                {
                    JsonConvert.DeserializeObject<StreamObject.WorldData.WorldAnimationData>((string)client.GetData<string>(data_name)).StreamIn();
                    ticks[i] = 0;
                }
            }
        }

        private void WorldUserData(int i, string data_name)
        {
            if (DateTime.Now.Ticks < ticks[i])
                return;
            foreach (var client in A.Entities.Players.All)
            {
                if (client.GetSharedData(data_name) == null && client.GetData<string>(data_name) == null)
                    continue;
                else if (client.GetSharedData(data_name) != null && DateTime.Now.Ticks > ticks[i])
                {
                    JsonConvert.DeserializeObject<StreamObject.WorldData.WorldAnimationData>((string)client.GetSharedData(data_name)).StreamIn();
                    ticks[i] = 0;
                }
                else if (client.GetData<string>(data_name) != null && DateTime.Now.Ticks > ticks[i])
                {
                    JsonConvert.DeserializeObject<StreamObject.WorldData.WorldAnimationData>((string)client.GetData<string>(data_name)).StreamIn();
                    ticks[i] = 0;
                }
            }
        }

        private void WorldTattooData(int i, string data_name)
        {
            if (DateTime.Now.Ticks < ticks[i])
                return;
            foreach (var client in A.Entities.Players.All)
            {
                if (client.GetSharedData(data_name) == null && client.GetData<string>(data_name) == null)
                    continue;
                else if (client.GetSharedData(data_name) != null && DateTime.Now.Ticks > ticks[i])
                {
                    JsonConvert.DeserializeObject<StreamObject.WorldData.WorldAnimationData>((string)client.GetSharedData(data_name)).StreamIn();
                    ticks[i] = 0;
                }
                else if (client.GetData<string>(data_name) != null && DateTime.Now.Ticks > ticks[i])
                {
                    JsonConvert.DeserializeObject<StreamObject.WorldData.WorldAnimationData>((string)client.GetData<string>(data_name)).StreamIn();
                    ticks[i] = 0;
                }
            }
        }

        private void WorldRigidBodyData(int i, string data_name)
        {
            if (DateTime.Now.Ticks < ticks[i])
                return;
            foreach (var client in A.Entities.Players.All)
            {
                if (client.GetSharedData(data_name) == null && client.GetData<string>(data_name) == null)
                    continue;
                else if (client.GetSharedData(data_name) != null && DateTime.Now.Ticks > ticks[i])
                {
                    JsonConvert.DeserializeObject<StreamObject.WorldData.WorldRigidBodyData>((string)client.GetSharedData(data_name)).StreamIn();
                    ticks[i] = 0;
                }
                else if (client.GetData<string>(data_name) != null && DateTime.Now.Ticks > ticks[i])
                {
                    JsonConvert.DeserializeObject<StreamObject.WorldData.WorldRigidBodyData>((string)client.GetSharedData(data_name)).StreamIn();
                    ticks[i] = 0;
                }
            }
        }

        private void WorldDoorData(int i, string data_name)
        {
            if (DateTime.Now.Ticks < ticks[i])
                return;
            foreach (var client in A.Entities.Players.All)
            {
                if (client.GetSharedData(data_name) == null && client.GetData<string>(data_name) == null)
                    continue;
                else if (client.GetSharedData(data_name) != null && DateTime.Now.Ticks > ticks[i])
                {
                    JsonConvert.DeserializeObject<StreamObject.WorldData.WorldAnimationData>((string)client.GetSharedData(data_name)).StreamIn();
                    ticks[i] = 0;
                }
                else if (client.GetData<string>(data_name) != null && DateTime.Now.Ticks > ticks[i])
                {
                    JsonConvert.DeserializeObject<StreamObject.WorldData.WorldAnimationData>((string)client.GetData<string>(data_name)).StreamIn();
                    ticks[i] = 0;
                }
            }
        }

        private void StreamIntroductionTicks() {
            if (ticks[addticks[0] + 1] == 0)
                ticks[addticks[0] + 1] = DateTime.Now.AddMilliseconds(10).Ticks;

            if (DateTime.Now.Ticks > ticks[addticks[0] + 1])
            {
                for (int i = 0; i < RAGE.Elements.Entities.Players.All.Count; i++)
                {

                    if (RAGE.Elements.Entities.Players.All[i].GetData<string>("IntroductionTaskStream") != null)
                    {
                        Engine.TaskSync sync = JsonConvert.DeserializeObject<Engine.TaskSync>(RAGE.Elements.Entities.Players.All[i].GetData<string>("IntroductionTaskStream"));
                        sync.StreamIn();
                    }
                }

                switch (Engine.IntroductionSidePlane.instance.side)
                {
                    case "South":
                        Engine.IntroductionSidePlane.instance.InFlyingSouth(null);
                        break;
                    case "North":
                        Engine.IntroductionSidePlane.instance.InFlyingNorth(null);
                        break;
                }
                ticks[addticks[0] + 1] = 0;
            }
        }

        private void OnTick(List<Events.TickNametagData> nametags)
        {

            OClocksTicks();
            OClocksEventTicks();
            StartTicksClock();
            StreamDataTicks();
            StreamIntroductionTicks();
            OSyncLimitation();
            StreamObject.WorldData.WorldDoorsData.instance.OnTick();
            OKeyEvent.instance.OnTickKeyEvent();
        }

        public int[] limit = new int[] { 20, 20 };
        public float[] stream = new float[] { 200, 20 };
        List<Tuple<A.Vehicle, float>> ListVehicle = new List<Tuple<A.Vehicle, float>>();
        List<Tuple<A.Player, float>> ListPlayers = new List<Tuple<A.Player, float>>();
        private void OSyncLimitation()
        {
            if (A.Entities.Vehicles.All.Count == 0 ||
                A.Entities.Players.All.Count == 0)
                return;

            for (int i = 0; i < A.Entities.Vehicles.All.Count; i++)
            {
                if (A.Player.LocalPlayer.Position.DistanceTo(A.Entities.Vehicles.All[i].Position) < stream[0])
                {
                    A.Entities.Vehicles.All[i].SetVisible(true, true);
                }
                else
                {
                    A.Entities.Vehicles.All[i].SetVisible(false, true);
                }
            }
            for (int i = 0; i < A.Entities.Players.All.Count; i++)
            {
                if (A.Player.LocalPlayer.Position.DistanceTo(A.Entities.Players.All[i].Position) < stream[1])
                {
                    A.Entities.Players.All[i].SetVisible(true, true);
                }
                else
                {
                    A.Entities.Players.All[i].SetVisible(false, true);
                }
            }
            for (int i = 0; i < A.Entities.Vehicles.All.Count; i++)
            {
                if (A.Player.LocalPlayer.Position.DistanceTo(A.Entities.Vehicles.All[i].Position) < stream[0]) {
                    ListVehicle.Add(new Tuple<A.Vehicle, float>(A.Entities.Vehicles.All[i], A.Player.LocalPlayer.Position.DistanceTo(A.Entities.Vehicles.All[i].Position)));
                }
            }
            if (ListVehicle.Count > limit[0]) {
                ForceUnStreamVehicle(ListVehicle, limit[0]);
            }
            for (int i = 0; i < A.Entities.Players.All.Count; i++)
            {
                if (A.Player.LocalPlayer.Position.DistanceTo(A.Entities.Players.All[i].Position) < stream[1])
                {
                    ListPlayers.Add(new Tuple<A.Player, float>(A.Entities.Players.All[i], A.Player.LocalPlayer.Position.DistanceTo(A.Entities.Vehicles.All[i].Position)));
                }
            }
            if (ListPlayers.Count > limit[1])
            {
                ForceUnStreamPlayers(ListPlayers, limit[1]);
            }
            ListPlayers.Clear();
            ListVehicle.Clear();
        }

        private void ForceUnStreamPlayers(List<Tuple<A.Player, float>> listPlayers, int limit)
        {
            listPlayers.Sort(delegate (Tuple<A.Player, float> a, Tuple<A.Player, float> b) {
                if (a.Item2 > b.Item2) return 1;
                else if (a.Item2 < b.Item2) return -1;
                else return 0;
            });
            for (int i = limit; i < listPlayers.Count; i++)
            {
                if (i < limit)
                {
                    listPlayers[i].Item1.SetVisible(true, true);
                }
                else
                {
                    A.Player Ugly = A.Entities.Players.Streamed.Find(x => x.RemoteId == listPlayers[i].Item1.RemoteId);
                    if (Ugly != null)
                    {
                        Ugly.SetVisible(false, true);
                    }
                }
            }
        }

        private void ForceUnStreamVehicle(List<Tuple<A.Vehicle, float>> listVehicle, int limit)
        {
            listVehicle.Sort(delegate (Tuple<A.Vehicle, float> a, Tuple<A.Vehicle, float> b) {
                if (a.Item2 > b.Item2) return 1;
                else if (a.Item2 < b.Item2) return -1;
                else return 0;
            });
            for (int i = 0; i < listVehicle.Count; i++) {
                if (i < limit)
                {
                    listVehicle[i].Item1.SetVisible(true, true);
                }
                else
                {
                    A.Vehicle Ugly = A.Entities.Vehicles.Streamed.Find(x => x.RemoteId == listVehicle[i].Item1.RemoteId);
                    if (Ugly != null)
                    {
                        Ugly.SetVisible(false, true);
                    }
                }
            }
        }
    }

}
