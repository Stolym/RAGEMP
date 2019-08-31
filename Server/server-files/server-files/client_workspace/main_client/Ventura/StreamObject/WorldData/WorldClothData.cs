using System;
using System.Collections.Generic;
using System.Text;
using main_client.Ventura.StreamObject.DataModel;

namespace main_client.Ventura.StreamObject.WorldData
{
    class WorldClothData : DataModel.DataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LocalId { get; set; }
        public int RemoteId { get; set; }
        public uint Dimensions { get; set; }
        public Constant.Constant.UpdateFlagsClient Type { get; set; }
        public virtual List<List<int>> cloth { get; set; }
        public virtual bool IsService { get; set; }

        public WorldClothData() { }
        public WorldClothData(RAGE.Elements.Player player)
        {
            this.RemoteId = player.RemoteId;
        }

        void set_cloth(List<List<int>> list, int handle) {
            for (int i = 0; i < 12; i++) {
                RAGE.Game.Ped.SetPedComponentVariation(handle, i, list[i][0], list[i][1], 0);
            }
        }

        public void StreamIn()
        {
            RAGE.Elements.Player target = RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == RemoteId);
            
            if (target == null || target.Handle == 0)
                return;
            set_cloth(cloth, target.Handle);
        }

        public void StreamOut()
        {
            RAGE.Elements.Player target = RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == RemoteId);

            if (target == null || (target.Handle == 0 && LocalId == 0))
                return;
        }
    }
}
