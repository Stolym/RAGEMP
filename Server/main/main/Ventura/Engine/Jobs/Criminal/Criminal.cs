using System;
using System.Collections.Generic;
using System.Text;

namespace main.Ventura.Engine.Jobs.Criminal
{

    class Registre
    {
        public string VictimName { get; set; }
        public string VictimLastname { get; set; }
        public string SuspectName { get; set; }
        public string SuspectLastname { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int flags { get; set; }


        public Registre() { }
    }


    class Criminal
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Birth { get; set; }
        public string IDIdentity { get; set; }
        public List<string> Description { get; set; }
        public bool Gps { get; set; }

        public Criminal() { }
    }
}
