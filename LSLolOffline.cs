using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 
namespace LeagueOFFLINE
{
    public partial class LSLolOffline : Form
    {

      
        public LSLolOffline()
        {
            InitializeComponent();
        }

        private void switchButton_Click(object sender, EventArgs e)
        {
            try
            {

       
                if (Globals.fw.isBlocked())
                {
                    Globals.fw.unblockLOL();
                }
                else
                {
                    Globals.fw.blockLOL();
                }

                UpdateState();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void UpdateState()
        {

          
            if (Globals.fw.isBlocked())
            {
                switchButton.Text = "Switch to Online";
                toolStripStatusLabel1.Text = "[OFFLINE MODE]";
                statusStrip1.ForeColor = Color.DarkRed;
            }
            else
            {
                switchButton.Text = "Switch to Offline";
                toolStripStatusLabel1.Text = "[ONLINE MODE]";
                statusStrip1.ForeColor = Color.DarkGreen;
         
            }
        }
        private void LSLolOffline_Load(object sender, EventArgs e)
        {
            try
            {
                Globals.lc.Init();
                Globals.fw.chat_ip = Globals.lc.GetIPFromDomain();

                Globals.fw.test();

                pathText.Text = Globals.lc.lolPath;
                UpdateState();


            }
           catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
