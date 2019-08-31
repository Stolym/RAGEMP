using System;
using System.Collections.Generic;
using System.Text;
using RAGE;
using RAGE.Elements;

namespace main_client.Ventura.Utils
{
    class Memory : Events.Script
    {

        public Memory() {
            Events.OnPlayerQuit += LeakMemoryPath;
        }

        public static string ByteArrayToString(byte[] buffer)
        {
            return BitConverter.ToString(buffer).Replace("-", "");
        }

        private void LeakMemoryPath(RAGE.Elements.Player player)
        {
            Chat.Output("Test " + player.Name);
        }

    }
}
