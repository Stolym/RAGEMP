using System;
using System.Collections.Generic;
using System.Text;
using RAGE;

namespace main_client.Ventura.Utils
{
    public class OTickEventConstant : Events.Script
    {
        public static OTickEventConstant instance;
        public List<Tuple<int, bool>> ListOTickEvent = new List<Tuple<int, bool>>();
        public OTickEventConstant() {
            instance = this;
            Events.Add("OTickEventChangeState", OTickEventChangeState);
        }

        private void OTickEventChangeState(object[] args)
        {
            int HashCode = (int)args[0];
            ChangeStateOTickEvent(HashCode);
        }

        public void AddOTickEvent(int Hashcode)
        {
            Tuple<int, bool> tmp = ListOTickEvent.Find(x => x.Item1 == Hashcode);
            if (tmp == null)
                ListOTickEvent.Add(new Tuple<int, bool>(Hashcode, false));
        }
        public void ChangeStateOTickEvent(int Hashcode, bool value = true)
        {
            Tuple<int, bool> tmp = ListOTickEvent.Find(x => x.Item1 == Hashcode);
            if (tmp != null)
                ListOTickEvent[ListOTickEvent.FindIndex(x => x.Item1 == Hashcode)] = new Tuple<int, bool>(tmp.Item1, value);
        }

        public bool GetStateOTickEvent(int Hashcode)
        {
            Tuple<int, bool> tmp = ListOTickEvent.Find(x => x.Item1 == Hashcode);
            if (tmp != null)
                return tmp.Item2;
            return false;
        }

        public void RemoveOTickEvent(int Hashcode)
        {
            Tuple<int, bool> tmp = ListOTickEvent.Find(x => x.Item1 == Hashcode);
            if (tmp == null)
                ListOTickEvent.Remove(tmp);
        }

    }
}
