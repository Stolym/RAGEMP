using System;
using System.Collections.Generic;
using System.Text;
using RAGE;
using Newtonsoft.Json;

namespace main_client.Ventura.StreamObject.WorldData
{
    class WorldDoorsData : Events.Script
    {
        public static WorldDoorsData instance { get; set; }
        private List<DataModel.DoorsData> StreamDoors { get; set; }
        private long Ticks { get; set; }

        public WorldDoorsData() {
            instance = this;
            Ticks = 0;
            StreamDoors = null;
            Events.Add("StreamDoorsData", StreamDoorsData);
        }

        private void StreamDoorsData(object[] args)
        {
            string json = (string)args[0];
            List<DataModel.DoorsData> data = JsonConvert.DeserializeObject<List<DataModel.DoorsData>>(json);

            if (data == null)
                return;
            StreamDoors = data;
        }

        public void OnTick() {
            StartClock();
            CurrentClock();
        }

        private void CurrentClock()
        {
            if (DateTime.Now.Ticks > Ticks) {

                StreamDoorsList();
                Ticks = 0;
            }
        }

        private void StreamDoorsList()
        {
            int index = 0;

            if (StreamDoors == null)
            {
                Events.CallRemote("GetDoorsList");
                return;
            }

            CheckListDoors();
            for (int i = 0; i < StreamDoors.Count; i++) {
                RAGE.Game.Object.SetStateOfClosestDoorOfType(RAGE.Game.Misc.GetHashKey(StreamDoors[i].Name), StreamDoors[i].X, StreamDoors[i].Y, StreamDoors[i].Z, StreamDoors[i].IsLock, StreamDoors[i].State, false);
            }
        }

        private void CheckListDoors()
        {
            int index = 0;

            for (int i = 0; i < Constant.Constant.ListDoor.Count; i++)
            {
                index = RAGE.Game.Object.GetClosestObjectOfType(RAGE.Elements.Player.LocalPlayer.Position.X, RAGE.Elements.Player.LocalPlayer.Position.Y, RAGE.Elements.Player.LocalPlayer.Position.Z, 20, RAGE.Game.Misc.GetHashKey(Constant.Constant.ListDoor[i]), false, false, false);
                if (index != 0)
                    UpdateListDoors(index, Constant.Constant.ListDoor[i]);
            }
        }

        private void UpdateListDoors(int index, string v)
        {
            bool update = true;
            Vector3 PositionStream = null;
            Vector3 PositionDoor = RAGE.Game.Entity.GetEntityCoords(index, true);
            int locked = 0;
            float heading = 0f;

            RAGE.Game.Object.GetStateOfClosestDoorOfType(RAGE.Game.Misc.GetHashKey(v), PositionDoor.X, PositionDoor.Y, PositionDoor.Z, ref locked, ref heading);
            for (int i = 0; i < StreamDoors.Count; i++) {
                PositionStream = new Vector3(StreamDoors[i].X, StreamDoors[i].Y, StreamDoors[i].Z);
                if (PositionDoor.DistanceTo(PositionStream) < 1f)
                    update = false;
            }
            if (update) {
                StreamDoors.Add(new DataModel.DoorsData() {
                    Hashcode = StreamDoors.Count,
                    IsLock = locked == 1 ? false : true,
                    Name = v,
                    State = heading,
                    X = PositionDoor.X,
                    Y = PositionDoor.Y,
                    Z = PositionDoor.Z,
                });
                Events.CallRemote("UpdateDoorsList", JsonConvert.SerializeObject(StreamDoors));
            }
        }

        public void StartClock()
        {
            if (Ticks == 0)
                Ticks = DateTime.Now.AddMilliseconds(200).Ticks;
        }

    }
}
