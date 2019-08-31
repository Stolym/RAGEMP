using System;
using System.Collections.Generic;
using System.Text;
using RAGE;

namespace main_client.Ventura.Jobs.Delta
{
    class JobsEvent : Events.Script
    {
        public static JobsEvent instance = null;
        public bool Debug = true;


        public JobsEvent() { instance = this; }



    }
}
