using System;
using System.Collections.Generic;
using System.Text;
using main_client.Ventura.StreamObject.DataModel;

namespace main_client.StreamObject.WorldData
{
    /*class WorldTattooData : IDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LocalId { get; set; }
        public ushort RemoteId { get; set; }
        public int Dimensions { get; set; }
        public Utils.Constant.UpdateFlagsClient Type { get; set; }

        public WorldTattooData() { }
        public WorldTattooData(RAGE.Elements.Player player)
        {
            this.RemoteId = player.RemoteId;
        }

        public void StreamIn()
        {
            RAGE.Elements.Player target = RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == RemoteId);

            if (target == null || target.Handle == 0)
                return;
        }

        public void StreamOut()
        {
            RAGE.Elements.Player target = RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == RemoteId);

            if (target == null || (target.Handle == 0 && LocalId == 0))
                return;
        }
    }*/
}
