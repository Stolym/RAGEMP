using System;
using System.Collections.Generic;
using System.Text;

namespace main_client.Ventura.Utils
{
    class OClock
    {
        public delegate void ActionWithParams(object[] args);
        private long ticks = 0;
        private Action action = null;
        private ActionWithParams actionWithParams = null;
        private object[] data = null;


        public bool Done() {
            if (DateTime.Now.Ticks > ticks) {
                if (action != null)
                    action.Invoke();
                else
                    actionWithParams.Invoke(data);
                return true;
            }
            return false;
        }

        public OClock(int hour, int minute, int second, int millisecond, Action action)
        {
            this.action = action;
            this.actionWithParams = null;
            this.ticks = DateTime.Now.AddHours(hour).AddMinutes(minute).AddSeconds(second).AddMilliseconds(millisecond).Ticks;
        }
        public OClock(int hour, int minute, int second, int millisecond, ActionWithParams actionWithParams, object[] data = null)
        {
            this.data = data;
            this.action = null;
            this.actionWithParams = actionWithParams;
            this.ticks = DateTime.Now.AddHours(hour).AddMinutes(minute).AddSeconds(second).AddMilliseconds(millisecond).Ticks;
        }
    }
}
