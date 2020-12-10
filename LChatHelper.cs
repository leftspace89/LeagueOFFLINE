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

        public static List<string> servers = new List<string>() 
        {
            "tr1.chat.si.riotgames.com",
            "br.chat.si.riotgames.com",
            "eun1.chat.si.riotgames.com",
            "euw1.chat.si.riotgames.com",
            "jp1.chat.si.riotgames.com",
            "la1.chat.si.riotgames.com",
            "la2.chat.si.riotgames.com",
            "na2.chat.si.riotgames.com",
            "oc1.chat.si.riotgames.com",
            "ru1.chat.si.riotgames.com",
            "na2.chat.si.riotgames.com"
        };

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
            lolPath = GetLOLPath();
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

      
        public string GetIPFromDomain()
        {
            try
            {
                var dns = Dns.GetHostAddresses(Globals.fw.chat_dom).FirstOrDefault();
                if (dns != null)
                    return dns.ToString();
            }
            catch (Exception ex)
            {
                LDebug.WriteLine(ex.ToString());
            }

            throw new ArgumentException("ip null", "ping");
        }
     
    }

}
