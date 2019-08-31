using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;

namespace main.Engine.Player.Animations
{
    class Animations : Script
    {

        [RemoteEvent("StartAnimation")]
        public void StartAnimation(Client client, string dict, string anim, float speed) {
            API.PlayPlayerAnimation(client, (int)(Ventura.Constant.Constants.AnimationFlags.Loop), dict, anim, speed);
        }

        /*[Command("play_anim")]
        public void play_anim(Client player, string dict, string anim, bool active) {
            player.TriggerEvent("add_data_anim", dict, anim);
            ToggleAnim(player, new object[] { active });
        }

        [RemoteEvent("ToggleAnim")]
        public void ToggleAnim(Client player, object[] args) {
                player.SetData("IsAnim", (bool)args[0]);
        }*/
        


    }
}
