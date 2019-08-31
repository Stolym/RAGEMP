using RAGE;
using System;
using System.Collections.Generic;
using System.Text;

namespace main_client.Ventura.Utils
{
    class OClockEvent
    {
        private long ticks { get; set; }
        private int time { get; set; }

        public object[] data { get; set; }
        public string EventName { get; set; }
        private int Hashcode { get; set; }


        public static OClockEvent operator + (OClockEvent src, List<object> data)
        {
            data.Add(src.Hashcode);
            src.data = data.ToArray();
            return src;
        }
        public static OClockEvent operator + (OClockEvent src, string eventName)
        {
            src.EventName = eventName;
            return src;
        }


        public void SetNewHashCodeEvent() {
            this.Hashcode = Constant.Constant.HashcodeEventLocal;
            Constant.Constant.HashcodeEventLocal++;
        }

        public void ResetClockEvent() {
            if (DateTime.Now.Ticks > ticks)
                ticks = DateTime.Now.AddMilliseconds(time).Ticks;
        }

        public bool Done()
        {
            if (DateTime.Now.Ticks > ticks && OTickEventConstant.instance.GetStateOTickEvent(this.Hashcode))
            {
                OTickEventConstant.instance.RemoveOTickEvent(this.Hashcode);
                return true;
            } else if (DateTime.Now.Ticks > ticks && !OTickEventConstant.instance.GetStateOTickEvent(this.Hashcode))
            {
                Events.CallRemote(EventName, data);
                ResetClockEvent();
            }
            return false;
        }

        public OClockEvent(int millisecond)
        {
            this.time = millisecond;
            this.ticks = DateTime.Now.AddMilliseconds(millisecond).Ticks;
            this.data = null;
            this.EventName = "";
            this.Hashcode = 0;
            SetNewHashCodeEvent();
            OTickEventConstant.instance.AddOTickEvent(this.Hashcode);
        }
    }
}
