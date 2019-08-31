using System;
using System.Collections.Generic;
using System.Text;
using RAGE;

namespace main_client.Ventura.Engine
{
    class Inventory : Events.Script
    {
        

        public static Inventory instance = null;

        public Inventory() {
            if (instance == null)
                instance = this;
            Events.Add("ReceiveCommandInventory", ReceiveCommandInventory);
            Events.Add("CEFInventory", CEFInventory);
        }

        private void ReceiveCommandInventory(object[] args)
        {
            string json = (string)args[0];
            ClearInventory();
            //Chat.Output(json);
            Events.CallLocal("executeFunction", "InventoryForm", "make_matrix", json);
        }

        private void CEFInventory(object[] args)
        {
            string json = (string)args[0];
            int flag = (int)args[1];
            Events.CallRemote("CEFCommandInventory", json, flag);
        }

        public void ClearInventory()
        {
            Events.CallLocal("executeFunction", "InventoryForm", "clear_matrix");
        }

        public void CallInventory() {
            RAGE.Elements.Vehicle veh = null;
            float max = 25f;
            for (int i = 0; i < RAGE.Elements.Entities.Vehicles.All.Count; i++) {
                if (RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(RAGE.Elements.Entities.Vehicles.All[i].Position) < max)
                {
                    veh = RAGE.Elements.Entities.Vehicles.All[i];
                    max = RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(RAGE.Elements.Entities.Vehicles.All[i].Position);
                }
            }
            int r = veh == null ? Cheat(0, 0) : veh != null ? Cheat(1, veh.RemoteId) : -1;
        }

        public int Cheat(int i, uint remote) {
            Events.CallRemote("SenderInventory", i, remote);
            return 0;
        }
    }
}
