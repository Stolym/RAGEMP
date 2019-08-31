using System;
using System.Collections.Generic;
using System.Text;
using RAGE;
using RAGE.Elements;
//using Newtonsoft.Json;


namespace main_client.World
{
    /*class StreamGestion
    {
        public class GlobalStream : Events.Script {

            public GlobalStream() {
                Events.OnEntityStreamIn += OnEntityStreamIn;
                Events.OnEntityStreamOut += OnEntityStreamOut;
                Events.OnPlayerJoin += OnPlayerJoin;
                Events.OnPlayerQuit += OnPlayerQuit;
                Events.OnPlayerSpawn += OnPlayerSpawn;
                Events.Tick += Tick;
            }

            private void Tick(List<Events.TickNametagData> nametags)
            {
            }

            private void OnPlayerSpawn(Events.CancelEventArgs cancel)
            {
                Chat.Output(cancel.ToString() + " Spawn");
            }

            private void OnPlayerQuit(RAGE.Elements.Player player)
            {
                Chat.Output(player.Name + " Quit");
            }

            private void OnPlayerJoin(RAGE.Elements.Player player)
            {
                Chat.Output(player.Name + " Joined");
            }

            private void OnEntityStreamOut(Entity entity)
            {
            }


            private void OnEntityStreamInDataLocal(Entity entity, Utils.Constant.UpdateFlagsClient flags)
            {
                var pointer =  JsonConvert.DeserializeObject((string)entity.GetSharedData(Utils.Constant.table_data_name[((int)flags >> 2) - 1]));
                var data = Utils.Constant.Cast(pointer, Utils.Constant.table_type[((int)flags >> 2) - 1]);
                data.StreamIn();
            }


            private void OnEntityStreamInDataShared(Entity entity, Utils.Constant.UpdateFlagsClient flags)
            {
                var pointer = JsonConvert.DeserializeObject(entity.GetData<string>(Utils.Constant.table_data_name[((int)flags >> 2) - 1]));
                var data = Utils.Constant.Cast(pointer, Utils.Constant.table_type[((int)flags >> 2) - 1]);
                data.StreamIn();
            }

            private void OnEntityStreamIn(Entity entity)
            {
                int c = 0x01;
                for (int i = 0; i < Utils.Constant.table_data_name.Count; i++) {
                    if (entity.GetSharedData(Utils.Constant.table_data_name[i]) != null)
                    {
                        OnEntityStreamInDataShared(entity, (Utils.Constant.UpdateFlagsClient)((i + 1) << 2));
                    } else if (entity.GetData<string>(Utils.Constant.table_data_name[i]) != null)
                    {
                        OnEntityStreamInDataLocal(entity, (Utils.Constant.UpdateFlagsClient)((i + 1) << 2));
                    }
                }
            }
        }



    }*/
}
