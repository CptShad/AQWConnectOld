namespace AQWConnect
{
    partial class Settings
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
            this.label1 = new System.Windows.Forms.Label();
            this.TokenBox = new System.Windows.Forms.TextBox();
            this.SaveToken = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Token :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TokenBox
            // 
            this.TokenBox.Location = new System.Drawing.Point(75, 16);
            this.TokenBox.Name = "TokenBox";
            this.TokenBox.Size = new System.Drawing.Size(696, 22);
            this.TokenBox.TabIndex = 1;
            // 
            // SaveToken
            // 
            this.SaveToken.Location = new System.Drawing.Point(16, 44);
            this.SaveToken.Name = "SaveToken";
            this.SaveToken.Size = new System.Drawing.Size(105, 25);
            this.SaveToken.TabIndex = 2;
            this.SaveToken.Text = "Save Token";
            this.SaveToken.UseVisualStyleBackColor = true;
            this.SaveToken.Click += new System.EventHandler(this.SaveToken_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 87);
            this.Controls.Add(this.SaveToken);
            this.Controls.Add(this.TokenBox);
            this.Controls.Add(this.label1);
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TokenBox;
        private System.Windows.Forms.Button SaveToken;
    }
}