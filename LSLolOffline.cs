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
                Globals.fw.chat_dom = srvbox.Items[srvbox.SelectedIndex].ToString();
                Globals.fw.chat_ip = Globals.lc.GetIPFromDomain();
                var isBlocked = Globals.fw.isBlocked();
                if (isBlocked)
                {
                    Globals.fw.unblockLOL();
                }
                else
                {
                    Globals.fw.blockLOL();
                }
           

                UpdateState(!isBlocked);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

     
        private void LSLolOffline_Load(object sender, EventArgs e)
        {
            try
            {
                srvbox.SelectedIndex = 0;

                Globals.lc.Init();
                Globals.fw.chat_ip = Globals.lc.GetIPFromDomain();

                Globals.fw.test();
       

            }
           catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void pathText_TextChanged(object sender, EventArgs e)
        {

        }

        private  void UpdateState(bool isBlocked)
        {
            if (isBlocked)
            {
                switchButton.Text = "Switch to Online";
            } 
            else
            {
                switchButton.Text = "Switch to Offline";
            }

            srvbox.ForeColor = isBlocked ? System.Drawing.Color.Red : System.Drawing.Color.Green;
        }
        private void srvbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Globals.fw.chat_dom = srvbox.Items[srvbox.SelectedIndex].ToString();
            Globals.fw.chat_ip = Globals.lc.GetIPFromDomain();
            var isBlocked = Globals.fw.isBlocked();
            srvLabel.Focus();
            UpdateState(isBlocked);
        }
    }
}
