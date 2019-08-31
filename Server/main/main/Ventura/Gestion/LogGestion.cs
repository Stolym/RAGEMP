using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RWAPI = main.Ventura.Database.ReaderWriter.ReaderWriter;


namespace main.Ventura.Gestion
{
    public class LogRequest
    {
        public string social_name { get; set; }
        public int RemoteId { get; set; }
        public int ToRemoteId { get; set; }
        public LogProcess action { get; set; }
        public string description { get; set; }

        public LogRequest() { }
    }

    public enum LogProcess {
        CONNECTION,
        LOGIN,
        REGISTER,
        INSTANCE,
    }

    class LogGestion
    {
        /*
         *  
         * 
         * 
         * 
         * 
         * */

        public static string path = "./data/Log/log.txt";
        
        public static void InsertLog(LogRequest logRequest) {
            RWAPI.WriteLineinPath(path, JsonConvert.SerializeObject(logRequest));
        }

        public static void ClearLog() {
            RWAPI.ClearFilePath(path);
        }

    }
}
