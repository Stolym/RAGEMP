using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using main.Ventura.Constant;

namespace main.Synchronization
{

    class StreamGestionAsync : Script 
    {
        public static StreamGestionAsync instance = null;
       


        /*
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * /


        /*
         * He must to make thread with async 
         * Result this async is set shared data and call events
         *  
         * 
         * */

        public StreamGestionAsync() {
            if (instance == null)
                instance = this;
        }

        public void UltimeAsync(Entity entity, string data,  Constants.StreamFlags flags, Constants.UpdateFlags uflags, int range = 0, uint dimension = 0) {
            try
            {
                //NAPI.Util.ConsoleOutput(table[(int)uflags - 1] + " " + table_data_name[(int)uflags - 1]);

                main.Ventura.Stream.Async.Stream.AsyncStream.instance.ASUltimeAsync(entity, Constants.table[(int)uflags - 1], Constants.table_data_name[(int)uflags - 1], data, flags, range, dimension);
                //main.Async.AsyncFunction.instance.AUltimeAsync(entity, table[(int)uflags], data, flags, range, dimension).GetAwaiter();
            }
            catch (Exception ex) {
                NAPI.Util.ConsoleOutput(ex.Message + " 5");
            }
        }

    }
}
