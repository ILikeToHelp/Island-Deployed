namespace IslandDeployed.Forms
{
    partial class EndGameScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EndGameScreen));
            this.WinOrLose = new System.Windows.Forms.PictureBox();
            this.text = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BackToMainMenu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.WinOrLose)).BeginInit();
            this.SuspendLayout();
            // 
            // WinOrLose
            // 
            this.WinOrLose.BackColor = System.Drawing.Color.Transparent;
            this.WinOrLose.BackgroundImage = global::IslandDeployed.Properties.Resources.dead;
            this.WinOrLose.Location = new System.Drawing.Point(335, 45);
            this.WinOrLose.Name = "WinOrLose";
            this.WinOrLose.Size = new System.Drawing.Size(642, 538);
            this.WinOrLose.TabIndex = 3;
            this.WinOrLose.TabStop = false;
            this.WinOrLose.Click += new System.EventHandler(this.WinOrLose_Click);
            // 
            // text
            // 
            this.text.AutoSize = true;
            this.text.BackColor = System.Drawing.Color.Transparent;
            this.text.Font = new System.Drawing.Font("Visitor TT1 BRK", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text.ForeColor = System.Drawing.Color.Red;
            this.text.Location = new System.Drawing.Point(400, 560);
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(509, 86);
            this.text.TabIndex = 4;
            this.text.Text = "YOU LOSE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Visitor TT1 BRK", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkOrange;
            this.label1.Location = new System.Drawing.Point(1077, 259);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(331, 44);
            this.label1.TabIndex = 5;
            this.label1.Text = "Play again?";
            // 
            // BackToMainMenu
            // 
            this.BackToMainMenu.BackColor = System.Drawing.Color.Gray;
            this.BackToMainMenu.Font = new System.Drawing.Font("Visitor TT1 BRK", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackToMainMenu.ForeColor = System.Drawing.Color.DarkOrange;
            this.BackToMainMenu.Location = new System.Drawing.Point(1164, 306);
            this.BackToMainMenu.Name = "BackToMainMenu";
            this.BackToMainMenu.Size = new System.Drawing.Size(141, 45);
            this.BackToMainMenu.TabIndex = 6;
            this.BackToMainMenu.Text = "Click me.";
            this.BackToMainMenu.UseVisualStyleBackColor = false;
            this.BackToMainMenu.Click += new System.EventHandler(this.BackToMainMenu_Click);
            // 
            // EndGameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1408, 738);
            this.Controls.Add(this.BackToMainMenu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.text);
            this.Controls.Add(this.WinOrLose);
            this.Name = "EndGameScreen";
            this.Text = "EndGameScreen";
            this.Load += new System.EventHandler(this.EndGameScreen_Load);
            this.Controls.SetChildIndex(this.WinOrLose, 0);
            this.Controls.SetChildIndex(this.text, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.BackToMainMenu, 0);
            ((System.ComponentModel.ISupportInitialize)(this.WinOrLose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox WinOrLose;
        private System.Windows.Forms.Label text;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BackToMainMenu;
    }
}