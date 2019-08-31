using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using GTANetworkAPI;

namespace main.Ventura.Database.ReaderWriter
{
    class ReaderWriter : Script
    {
        public static void CreateFile(string path)
        {
            NAPI.Util.ConsoleOutput("Path Create "+ path);
            File.Create(path);
        }


        public static bool IfLineExistInFile(string path, string line)
        {
            if (!File.Exists(path))
                CreateFile(path);
            using (StreamReader sr = File.OpenText(path))
            {
                string[] lines = File.ReadAllLines(path);
                for (int x = 0; x < lines.Length; x++)
                {
                    if (line == lines[x])
                    {
                        sr.Close();
                        return (true);
                    }
                }
                sr.Close();
            }
            return (false);
        }

        public static bool ClearFilePath(string path)
        {
            if (!File.Exists(path))
                CreateFile(path);
            using (StreamWriter wr = new StreamWriter(path))
            {
                wr.Close();
            }
            return (true);
        }


        public static void WriteLineinPath(string path, string line)
        {
            if (!File.Exists(path))
                CreateFile(path);
            if (IfLineExistInFile(path, line) == false)
            {
                string[] lines;
                using (StreamReader sr = File.OpenText(path))
                {
                    lines = File.ReadAllLines(path);
                    sr.Close();
                }
                using (StreamWriter wr = new StreamWriter(path))
                {
                    for (int i = 0; i < lines.Length; i++)
                    {
                        wr.WriteLine(lines[i]);
                    }
                    wr.WriteLine(line);
                    wr.Close();
                }
            }
        }

        public static void RemoveLineinPath(string path, string line)
        {
            if (!File.Exists(path))
                CreateFile(path);
            if (IfLineExistInFile(path, line) == true)
            {
                string[] lines;
                using (StreamReader sr = File.OpenText(path))
                {
                    lines = File.ReadAllLines(path);
                    sr.Close();
                }
                using (StreamWriter wr = new StreamWriter(path))
                {
                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (lines[i] != line)
                            wr.WriteLine(lines[i]);
                    }
                    wr.Close();
                }
            }
        }
    }
}
