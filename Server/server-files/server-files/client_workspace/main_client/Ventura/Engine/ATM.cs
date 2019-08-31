using System;
using System.Collections.Generic;
using System.Text;
using RAGE;

namespace main_client.Ventura.Engine
{
    class ATM : Events.Script
    {
        public static ATM instance = null;
        private long tick = 0;

        public ATM()
        {
            if (instance == null)
                instance = this;
            Events.Add("ReceiveCommandATM", ReceiveCommandATM);
            Events.Add("CEFATM", CEFATM);
            Events.Tick += OnTick;
        }


        void SetClock(double ms)
        {
            if (tick == 0)
                tick = DateTime.Now.AddMilliseconds(ms).Ticks;
        }

        private void OpenATM()
        {
            Events.CallLocal("createBrowser", "ATMForm", "package://ATM/index.html");
        }


        private void CloseATM()
        {
            Events.CallLocal("destroyBrowser", "ATMForm");
        }


        private void OnTick(List<Events.TickNametagData> nametags)
        {
            SetClock(300);
            if (Input.IsDown((int)ConsoleKey.DownArrow) && DateTime.Now.Ticks > tick)
            {
                RAGE.Ui.Cursor.Visible = true;
                //OpenATM();
                tick = 0;
            }
        }

        private void ReceiveCommandATM(object[] args)
        {
            string json = (string)args[0];
            Events.CallLocal("executeFunction", "InventoryForm", "make_matrix", json);
        }

        private void CEFATM(object[] args)
        {
            string json = (string)args[0];
            int flag = (int)args[1];
            Events.CallRemote("CEFCommandInventory", json, flag);
        }
        

        public void CallATM()
        {
            Events.CallRemote("SenderInventory");
        }
    }
}
