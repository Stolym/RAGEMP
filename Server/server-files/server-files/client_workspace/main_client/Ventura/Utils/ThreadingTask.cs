using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RAGE;

namespace main_client.Ventura.Utils
{
    class ThreadingTask : Events.Script
    {

        public static void make_task_with_timeout(Action function, int timeout)
        {
            Task.Factory.StartNew(() =>
            {
                var task = new Task(function);
                try
                {
                    if (!task.Wait(timeout))
                        task.Start();
                }
                catch (Exception e)
                {
                    Chat.Output("Exception " + e.Message);
                }
            });
        }

    }
}
