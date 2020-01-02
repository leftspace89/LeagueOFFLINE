using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeagueOFFLINE
{
    public class LChatHelper
    {

        public string lolPath = @"C:\Riot Games\League of Legends\";
        public string GetLOLPath()
        {
            try
            {
                var p = Process.GetProcessesByName("LeagueClient").FirstOrDefault();
                if (p != null)
                {
                    return Path.GetDirectoryName(p.MainModule.FileName);
                }
                if(p == null)
                {
                    MessageBox.Show("Please run league client before start application");
                    Environment.Exit(0);
                }
            }

            catch (Exception ex)
            {
                LDebug.WriteLine(ex.ToString());

            }

            return string.Empty;
        }


        public void Init()
        {
            if (!Directory.Exists(lolPath))
            {
                LDebug.WriteLine("Trying get LOL Path");
                lolPath = GetLOLPath();
            }

            if (!Directory.Exists(lolPath))
            {
                LDebug.WriteLine("can't get LOL Path");
            }
        }

        public string GetLog()
        {
            var defaultPath = Path.Combine(GetLOLPath(), @"Logs\LeagueClient Logs"); ;
            var dir = Directory.GetFiles(defaultPath, "*_LeagueClient.log");
            var mlog = "";
            var ltime = TimeSpan.MaxValue;
            foreach (var d in dir)
            {
                var curDelta = ltime.Subtract(new TimeSpan(File.GetLastAccessTime(d).Ticks));
                if (curDelta < ltime)
                {
                    ltime = curDelta;
                    mlog = d;
                }
            }
            if (string.IsNullOrEmpty(mlog))
                throw new ArgumentException("empty string", "mlog");

            return mlog;
        }
        public string ReadClientLog()
        {
            try
            {
                var path = GetLog();
                using (FileStream fileStream = new FileStream(
                    path,
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.ReadWrite))
                {
                    using (StreamReader streamReader = new StreamReader(fileStream))
                    {
                        return streamReader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                LDebug.WriteLine(ex.ToString());
            }

            throw new ArgumentException("failed to read client log", "streamReader");

        }
        public string GetIPFromDomain()
        {
            try
            {
                var dns = Dns.GetHostAddresses(GetChatDomain()).FirstOrDefault();
                if (dns != null)
                    return dns.ToString();
            }
            catch (Exception ex)
            {
                LDebug.WriteLine(ex.ToString());
            }

            throw new ArgumentException("ip null", "ping");
        }
        public string GetChatDomain()
        {
            try
            {
                string pattern = @"rcp-be-lol-chat\| Chat configured to (.*):5223";
                var content = ReadClientLog().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Where(x => x.Contains("rcp-be-lol-chat"));
                foreach (var s in content)
                {
                    var IPRegex = Regex.Match(s, pattern);
                    if (IPRegex.Success)
                    {
                        return IPRegex.Groups[1].Value.ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                LDebug.WriteLine(ex.ToString());
            }

            throw new ArgumentException("failed to read client log", "IPRegex");
        }
    }

}
