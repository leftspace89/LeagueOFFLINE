using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Net;
using System.Windows.Forms;

namespace LeagueOFFLINE
{

   

    public  class FWManager
    {
    


        public string chat_ip = string.Empty;
        public string RunAction(string strCmdText)
        {
       
            ProcessStartInfo psi = new ProcessStartInfo("netsh.exe", strCmdText);
            psi.RedirectStandardOutput = true;
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;

            var sb = new StringBuilder();
            try
            {
                var  p = Process.Start(psi);
                while (!p.StandardOutput.EndOfStream)
                {
                    string line = p.StandardOutput.ReadLine();
                   
                    sb.AppendLine(line);
                }
                p.WaitForExit();
            }
            catch (Exception ex)
            {
                LDebug.WriteLine(ex.Message);
            }
            return sb.ToString();
        }

        public void blockLOL()
        {
            if (string.IsNullOrEmpty(chat_ip) || string.IsNullOrWhiteSpace(chat_ip))
            {
                throw new ArgumentException("empty or null", "chat_ip");
            }

            var str = RunAction("advfirewall firewall show rule name=all");

            if (str.Contains("LeftSpace_LolOfflineMode"))
            {
                LDebug.WriteLine("Chat endpoint already blocked");
                return;
            }


            string strCmdText = $"advfirewall firewall add rule name=\"LeftSpace_LolOfflineMode\" dir=out remoteip={chat_ip} protocol=any action=block";
            RunAction(strCmdText);
        }
        public void unblockLOL()
        {
            string strCmdText = $"advfirewall firewall delete rule name=\"LeftSpace_LolOfflineMode\"";
            RunAction(strCmdText);
        }

        public void test()
        {
            var str = RunAction("advfirewall show allprofiles state");

            if (str.Contains("OFF"))
            {
                LDebug.WriteLine("Firewall is not enabled");
                MessageBox.Show("Firewall is not enabled please enable your firewall");
                Environment.Exit(0);
                return;
            }
        }
        public bool isBlocked()
        {
            try
            {
                var p = new Ping();
                var r = p.Send(Globals.lc.GetIPFromDomain());
                
                if (r.Status != IPStatus.Success)
                    return true;
            }
            catch(Exception ex)
            {
                return true;
            }
         

            return false;
        }
    }

}
