using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using System.Threading.Tasks;
using Microsoft.CSharp.RuntimeBinder;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using TeamSpeak3QueryApi.Net;
using TeamSpeak3QueryApi.Net.Specialized;
using TeamSpeak3QueryApi.Net.Specialized.Responses;

namespace main.Ventura.Engine.Vocal
{
    class Vocal : Script
    {
        public void Connect(Client client, string characterName)
        {
            client.TriggerEvent("ConnectTeamspeak", characterName);
        }

    }
}
