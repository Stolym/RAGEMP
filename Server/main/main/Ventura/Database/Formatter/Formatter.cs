using System;
using System.Collections.Generic;
using System.Text;
using ZeroFormatter;
using Newtonsoft.Json;
using System.IO.Compression;
using GTANetworkAPI;
using System.IO;
using Newtonsoft.Json.Serialization;

namespace main.Ventura.Database.Formatter
{
    class Formatter
    {
        public static void CopyTo(System.IO.Stream src, System.IO.Stream dest)
        {
            byte[] bytes = new byte[4096];

            int cnt;

            while ((cnt = src.Read(bytes, 0, bytes.Length)) != 0)
            {
                dest.Write(bytes, 0, cnt);
            }
        }

        public static byte[] Zip(string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);

            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(mso, CompressionMode.Compress))
                {
                    //msi.CopyTo(gs);
                    CopyTo(msi, gs);
                }

                return mso.ToArray();
            }
        }

        public static string Unzip(byte[] bytes)
        {
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(msi, CompressionMode.Decompress))
                {
                    //gs.CopyTo(mso);
                    CopyTo(gs, mso);
                }

                return Encoding.UTF8.GetString(mso.ToArray());
            }
        }


        public static byte[] SerializeObjectZipJson<T>(T obj)
        {
            string json = SerializeObjectJson<T>(obj);
            return Zip(json);
        }

        public static T DeserializeObjectZipJson<T>(byte[] buffer)
        {
            var ptr = DeserializeObjectJson<T>(Unzip(buffer));
            return ptr;
        }


        public static string SerializeObjectJson<T>(T obj)
        {
            var jsonSerializerSettings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };
            return JsonConvert.SerializeObject(obj, jsonSerializerSettings);
        }

        public static T DeserializeObjectJson<T>(string json)
        {

            return JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings
            {
                Error = HandleDeserializationError
            });
        }

        private static void HandleDeserializationError(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs e)
        {
            var currentError = e.ErrorContext.Error.Message;
            e.ErrorContext.Handled = true;
        }

        public static byte[] SerializeObject<T>(T obj)
        {
            var buffer = ZeroFormatterSerializer.Serialize(obj);
            return buffer;
        }

        public static T DeserializeObject<T>(byte[] buffer)
        {
            var ptr = ZeroFormatterSerializer.Deserialize<T>(buffer);
            return ptr;
        }
    }
}
