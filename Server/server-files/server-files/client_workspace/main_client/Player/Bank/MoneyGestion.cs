using System;
using System.Collections.Generic;
using System.Text;
using RAGE;


namespace main_client.Player.Bank
{
    /*class MoneyGestion : Events.Script
    {
        RAGE.Elements.Marker mark = null;
        RAGE.Elements.TextLabel text = null;
        static string money = "0 $";


        public MoneyGestion() {
            //Events.Tick += tick;
            Events.Add("change_money_client", change_money_client);
        }

        private void change_money_client(object[] args)
        {
            if (args[0] != null)
                money = (string)args[0];
            text.Destroy();
            text = null;
        }

        private void tick(List<Events.TickNametagData> nametags)
        {
            //if (mark == null)
            //    mark = new RAGE.Elements.Marker(1, RAGE.Elements.Player.LocalPlayer.Position += new Vector3(0, 0, -2), 1f, new Vector3(), new Vector3(), new RGBA(0, 0, 255));
            //else
            //    mark.Position = RAGE.Elements.Player.LocalPlayer.Position;
            if (text == null)
                text = new RAGE.Elements.TextLabel(RAGE.Elements.Player.LocalPlayer.Position, money, new RGBA(0xFF0000FF));
            else
                text.Position = RAGE.Elements.Player.LocalPlayer.Position;
            //RAGE.Game.Graphics.DrawDebugText("1000 $", RAGE.Elements.Player.LocalPlayer.Position.X, RAGE.Elements.Player.LocalPlayer.Position.Y, RAGE.Elements.Player.LocalPlayer.Position.Z + 1, 255, 255, 0, 255);
            //RAGE.Game.Graphics.DrawMarker(1, RAGE.Elements.Player.LocalPlayer.Position.X, RAGE.Elements.Player.LocalPlayer.Position.Y, RAGE.Elements.Player.LocalPlayer.Position.Z, 0, 0, 0, 0, 0, 0, 1, 1, 1, 255, 0, 0, 255, true, true, 0, false, "Screen", "Test", false);
        }
    }*/
}
