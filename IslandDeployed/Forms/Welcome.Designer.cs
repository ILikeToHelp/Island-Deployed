namespace IslandDeployed.Forms
{
    partial class Welcome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcome));
            this.Easy = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Medium = new System.Windows.Forms.Button();
            this.Hard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Easy
            // 
            this.Easy.BackColor = System.Drawing.Color.Gray;
            this.Easy.Font = new System.Drawing.Font("Visitor TT1 BRK", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Easy.ForeColor = System.Drawing.Color.DarkOrange;
            this.Easy.Location = new System.Drawing.Point(561, 363);
            this.Easy.Name = "Easy";
            this.Easy.Size = new System.Drawing.Size(185, 80);
            this.Easy.TabIndex = 7;
            this.Easy.Text = "Easy?";
            this.Easy.UseVisualStyleBackColor = false;
            this.Easy.Click += new System.EventHandler(this.Easy_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Visitor TT1 BRK", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkOrange;
            this.label1.Location = new System.Drawing.Point(468, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(470, 88);
            this.label1.TabIndex = 8;
            this.label1.Text = "Welcome to\r\nISLAND DEPLOYED\r\n";
            // 
            // Medium
            // 
            this.Medium.BackColor = System.Drawing.Color.Gray;
            this.Medium.Font = new System.Drawing.Font("Visitor TT1 BRK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Medium.ForeColor = System.Drawing.Color.DarkOrange;
            this.Medium.Location = new System.Drawing.Point(514, 449);
            this.Medium.Name = "Medium";
            this.Medium.Size = new System.Drawing.Size(298, 103);
            this.Medium.TabIndex = 9;
            this.Medium.Text = "Medium!";
            this.Medium.UseVisualStyleBackColor = false;
            this.Medium.Click += new System.EventHandler(this.Medium_Click);
            // 
            // Hard
            // 
            this.Hard.BackColor = System.Drawing.Color.Gray;
            this.Hard.Font = new System.Drawing.Font("Visitor TT1 BRK", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hard.ForeColor = System.Drawing.Color.DarkOrange;
            this.Hard.Location = new System.Drawing.Point(432, 558);
            this.Hard.Name = "Hard";
            this.Hard.Size = new System.Drawing.Size(446, 126);
            this.Hard.TabIndex = 10;
            this.Hard.Text = "Hard...";
            this.Hard.UseVisualStyleBackColor = false;
            this.Hard.Click += new System.EventHandler(this.Hard_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1408, 792);
            this.Controls.Add(this.Hard);
            this.Controls.Add(this.Medium);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Easy);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.Controls.SetChildIndex(this.Easy, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.Medium, 0);
            this.Controls.SetChildIndex(this.Hard, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Easy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Medium;
        private System.Windows.Forms.Button Hard;
    }
}