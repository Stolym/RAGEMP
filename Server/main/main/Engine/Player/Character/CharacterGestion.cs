using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;

namespace main.Engine.Player.Character
{
    class CharacterGestion : Script
    {
        /*[RemoteEvent("SetFP")]
        public void SetFP(Client player, object[] args)
        {
            player.Freeze((int)args[0] == 1 ? true : false);
            player.FreezePosition = (int)args[0] == 1 ? true : false;
        }

        [RemoteEvent("TestTest")]
        public void TestTest(Client player, object[] args)
        {
            NAPI.ClientEvent.TriggerClientEvent(player, "TestTest");
        }

        [RemoteEvent("DoorTest")]
        public void DoorTest(object[] args)
        {
            Client player = (Client)args[0];
            NAPI.Object.CreateObject(NAPI.Util.GetHashKey("prop_police_door_l"), player.Position, player.Rotation);
        }



        [RemoteEvent("SetCRot")]
        public void SetCRot(Client player, object[] arguments)
        {
            player.SendNotification("this player: " + player.Name + " is beatch");
            player.SendNotification("this player: " + (float)arguments[0] + " " + (float)arguments[1] + " " + (float)arguments[2]);
            player.Rotation = new Vector3((float)arguments[0], (float)arguments[1], (float)arguments[2]);
        }

        [RemoteEvent("SetCPos")]
        public void SetCPos(Client player, object[] arguments)
        {
            player.SendNotification("this player: " + player.Name + " is la");
            
            //player.SendNotification("this player: " + (float)arguments[0] + " " + (float)arguments[1] + " " + (float)arguments[2]);
            player.Position = new Vector3((float)arguments[0], (float)arguments[1], (float)arguments[2]);
        }



        /*[RemoteEvent("SetCharacterRotation")]
        public void SetCharacterRotation(Client player, object[] arguments)
        {
            player.SendNotification("this player: " + (float)arguments[0] + " " + (float)arguments[1] + " " + (float)arguments[2]);
            //player.Rotation = new Vector3((float)arguments[0], (float)arguments[1], (float)arguments[2]);
        }

        [RemoteEvent("SetCharacterPosition")]
        public void SetCharacterPosition(Client player, object[] arguments)
        {
            player.SendNotification("this player: " + (float)arguments[0] + " " + (float)arguments[1] + " " + (float)arguments[2]);
            //player.Position = new Vector3((float)arguments[0], (float)arguments[1], (float)arguments[2]);
        }*/
    }
}
