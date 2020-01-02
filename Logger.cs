using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOFFLINE
{
    public static class LDebug
    {
        public static StringBuilder LogString = new StringBuilder();
        public static void WriteLine(string str)
        {
            Console.WriteLine(str);
            LogString.Append(str).Append(Environment.NewLine);
            SaveLog();
        }
        public static void Write(string str)
        {
            Console.Write(str);
            LogString.Append(str);
            SaveLog();
        }
        public static void SaveLog(bool Append = false, string Path = "./Log.txt")
        {
            if (LogString != null && LogString.Length > 0)
            {
                if (Append)
                {
                    using (StreamWriter file = System.IO.File.AppendText(Path))
                    {
                        file.Write(LogString.ToString());
                        file.Close();
                        file.Dispose();
                    }
                }
                else
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(Path))
                    {
                        file.Write(LogString.ToString());
                        file.Close();
                        file.Dispose();
                    }
                }
            }
        }
    }
}
