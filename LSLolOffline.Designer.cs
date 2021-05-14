namespace LeagueOFFLINE
{
    partial class LSLolOffline
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.switchButton = new System.Windows.Forms.Button();
            this.srvLabel = new System.Windows.Forms.Label();
            this.srvbox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // switchButton
            // 
            this.switchButton.Location = new System.Drawing.Point(231, 12);
            this.switchButton.Name = "switchButton";
            this.switchButton.Size = new System.Drawing.Size(82, 44);
            this.switchButton.TabIndex = 2;
            this.switchButton.Text = "Switch Offline";
            this.switchButton.UseVisualStyleBackColor = true;
            this.switchButton.Click += new System.EventHandler(this.switchButton_Click);
            // 
            // srvLabel
            // 
            this.srvLabel.AutoSize = true;
            this.srvLabel.Location = new System.Drawing.Point(12, 28);
            this.srvLabel.Name = "srvLabel";
            this.srvLabel.Size = new System.Drawing.Size(41, 13);
            this.srvLabel.TabIndex = 3;
            this.srvLabel.Text = "Server:";
            // 
            // srvbox
            // 
            this.srvbox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.srvbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.srvbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.srvbox.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.srvbox.FormattingEnabled = true;
            this.srvbox.Items.AddRange(new object[] {
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
            "na2.chat.si.riotgames.com"});
            this.srvbox.Location = new System.Drawing.Point(59, 25);
            this.srvbox.Name = "srvbox";
            this.srvbox.Size = new System.Drawing.Size(158, 21);
            this.srvbox.TabIndex = 4;
            this.srvbox.SelectedIndexChanged += new System.EventHandler(this.srvbox_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(319, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 44);
            this.button1.TabIndex = 5;
            this.button1.Text = "Check";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LSLolOffline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 68);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.srvbox);
            this.Controls.Add(this.srvLabel);
            this.Controls.Add(this.switchButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "LSLolOffline";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOFFLINE By LeftSpace";
            this.Load += new System.EventHandler(this.LSLolOffline_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button switchButton;
        private System.Windows.Forms.Label srvLabel;
        private System.Windows.Forms.ComboBox srvbox;
        private System.Windows.Forms.Button button1;
    }
}

