namespace AQWConnect
{
    partial class Controls
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Controls));
            this.ViewLogButton = new System.Windows.Forms.Button();
            this.SendPacketButton = new System.Windows.Forms.Button();
            this.PacketField = new System.Windows.Forms.TextBox();
            this.ConnectDiscordButton = new System.Windows.Forms.Button();
            this.DonateButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ViewLogButton
            // 
            this.ViewLogButton.Location = new System.Drawing.Point(12, 12);
            this.ViewLogButton.Name = "ViewLogButton";
            this.ViewLogButton.Size = new System.Drawing.Size(151, 27);
            this.ViewLogButton.TabIndex = 0;
            this.ViewLogButton.Text = "View Packet Log";
            this.ViewLogButton.UseVisualStyleBackColor = true;
            this.ViewLogButton.Click += new System.EventHandler(this.ViewLogButton_Click);
            // 
            // SendPacketButton
            // 
            this.SendPacketButton.Location = new System.Drawing.Point(12, 204);
            this.SendPacketButton.Name = "SendPacketButton";
            this.SendPacketButton.Size = new System.Drawing.Size(151, 27);
            this.SendPacketButton.TabIndex = 1;
            this.SendPacketButton.Text = "Send Packet";
            this.SendPacketButton.UseVisualStyleBackColor = true;
            this.SendPacketButton.Click += new System.EventHandler(this.SendPacketButton_Click);
            // 
            // PacketField
            // 
            this.PacketField.Location = new System.Drawing.Point(12, 113);
            this.PacketField.Multiline = true;
            this.PacketField.Name = "PacketField";
            this.PacketField.Size = new System.Drawing.Size(703, 85);
            this.PacketField.TabIndex = 2;
            // 
            // ConnectDiscordButton
            // 
            this.ConnectDiscordButton.Location = new System.Drawing.Point(169, 12);
            this.ConnectDiscordButton.Name = "ConnectDiscordButton";
            this.ConnectDiscordButton.Size = new System.Drawing.Size(151, 27);
            this.ConnectDiscordButton.TabIndex = 3;
            this.ConnectDiscordButton.Text = "Connect Discord";
            this.ConnectDiscordButton.UseVisualStyleBackColor = true;
            this.ConnectDiscordButton.Click += new System.EventHandler(this.ConnectDiscordButton_Click);
            // 
            // DonateButton
            // 
            this.DonateButton.Location = new System.Drawing.Point(565, 12);
            this.DonateButton.Name = "DonateButton";
            this.DonateButton.Size = new System.Drawing.Size(151, 27);
            this.DonateButton.TabIndex = 4;
            this.DonateButton.Text = "Donate To Me :)";
            this.DonateButton.UseVisualStyleBackColor = true;
            this.DonateButton.Click += new System.EventHandler(this.DonateButton_Click);
            // 
            // Controls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 254);
            this.Controls.Add(this.DonateButton);
            this.Controls.Add(this.ConnectDiscordButton);
            this.Controls.Add(this.PacketField);
            this.Controls.Add(this.SendPacketButton);
            this.Controls.Add(this.ViewLogButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Controls";
            this.Text = "Controls";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ViewLogButton;
        private System.Windows.Forms.Button SendPacketButton;
        private System.Windows.Forms.TextBox PacketField;
        private System.Windows.Forms.Button ConnectDiscordButton;
        private System.Windows.Forms.Button DonateButton;
    }
}