namespace IslandDeployed
{
    partial class BattleField
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BattleField));
            this.deploymentPanel = new System.Windows.Forms.Panel();
            this.snipersLeft = new System.Windows.Forms.Label();
            this.infantryLeft = new System.Windows.Forms.Label();
            this.mercenariesLeft = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DeploySniper = new System.Windows.Forms.PictureBox();
            this.DeployInfantry = new System.Windows.Forms.PictureBox();
            this.DeployMercenarie = new System.Windows.Forms.PictureBox();
            this.ActionPanel = new System.Windows.Forms.Panel();
            this.ActionShot = new System.Windows.Forms.PictureBox();
            this.Skip = new System.Windows.Forms.PictureBox();
            this.ActionMove = new System.Windows.Forms.PictureBox();
            this.LogOfMoves = new System.Windows.Forms.RichTextBox();
            this.deploymentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeploySniper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeployInfantry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeployMercenarie)).BeginInit();
            this.ActionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ActionShot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Skip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ActionMove)).BeginInit();
            this.SuspendLayout();
            // 
            // deploymentPanel
            // 
            this.deploymentPanel.BackColor = System.Drawing.Color.Transparent;
            this.deploymentPanel.BackgroundImage = global::IslandDeployed.Properties.Resources.Parchment;
            this.deploymentPanel.Controls.Add(this.snipersLeft);
            this.deploymentPanel.Controls.Add(this.infantryLeft);
            this.deploymentPanel.Controls.Add(this.mercenariesLeft);
            this.deploymentPanel.Controls.Add(this.label3);
            this.deploymentPanel.Controls.Add(this.label2);
            this.deploymentPanel.Controls.Add(this.label1);
            this.deploymentPanel.Controls.Add(this.DeploySniper);
            this.deploymentPanel.Controls.Add(this.DeployInfantry);
            this.deploymentPanel.Controls.Add(this.DeployMercenarie);
            this.deploymentPanel.Location = new System.Drawing.Point(333, 118);
            this.deploymentPanel.Name = "deploymentPanel";
            this.deploymentPanel.Size = new System.Drawing.Size(640, 432);
            this.deploymentPanel.TabIndex = 3;
            this.deploymentPanel.Visible = false;
            // 
            // snipersLeft
            // 
            this.snipersLeft.AutoSize = true;
            this.snipersLeft.Font = new System.Drawing.Font("Neogrey Medium", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.snipersLeft.Location = new System.Drawing.Point(468, 320);
            this.snipersLeft.Name = "snipersLeft";
            this.snipersLeft.Size = new System.Drawing.Size(33, 45);
            this.snipersLeft.TabIndex = 10;
            this.snipersLeft.Text = " ";
            // 
            // infantryLeft
            // 
            this.infantryLeft.AutoSize = true;
            this.infantryLeft.Font = new System.Drawing.Font("Neogrey Medium", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infantryLeft.Location = new System.Drawing.Point(468, 200);
            this.infantryLeft.Name = "infantryLeft";
            this.infantryLeft.Size = new System.Drawing.Size(33, 45);
            this.infantryLeft.TabIndex = 9;
            this.infantryLeft.Text = " ";
            // 
            // mercenariesLeft
            // 
            this.mercenariesLeft.AutoSize = true;
            this.mercenariesLeft.Font = new System.Drawing.Font("Neogrey Medium", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mercenariesLeft.Location = new System.Drawing.Point(468, 79);
            this.mercenariesLeft.Name = "mercenariesLeft";
            this.mercenariesLeft.Size = new System.Drawing.Size(33, 45);
            this.mercenariesLeft.TabIndex = 8;
            this.mercenariesLeft.Text = " ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Neogrey Medium", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(235, 320);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(227, 45);
            this.label3.TabIndex = 7;
            this.label3.Text = "Units left: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Neogrey Medium", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(235, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 45);
            this.label2.TabIndex = 6;
            this.label2.Text = "Units left: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Neogrey Medium", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(235, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 45);
            this.label1.TabIndex = 5;
            this.label1.Text = "Units left: ";
            // 
            // DeploySniper
            // 
            this.DeploySniper.BackgroundImage = global::IslandDeployed.Properties.Resources.S;
            this.DeploySniper.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DeploySniper.Location = new System.Drawing.Point(100, 265);
            this.DeploySniper.Name = "DeploySniper";
            this.DeploySniper.Size = new System.Drawing.Size(100, 100);
            this.DeploySniper.TabIndex = 4;
            this.DeploySniper.TabStop = false;
            this.DeploySniper.Click += new System.EventHandler(this.DeploySniper_Click);
            // 
            // DeployInfantry
            // 
            this.DeployInfantry.BackgroundImage = global::IslandDeployed.Properties.Resources.I;
            this.DeployInfantry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DeployInfantry.Location = new System.Drawing.Point(100, 145);
            this.DeployInfantry.Name = "DeployInfantry";
            this.DeployInfantry.Size = new System.Drawing.Size(100, 100);
            this.DeployInfantry.TabIndex = 3;
            this.DeployInfantry.TabStop = false;
            this.DeployInfantry.Click += new System.EventHandler(this.DeployInfantry_Click);
            // 
            // DeployMercenarie
            // 
            this.DeployMercenarie.BackgroundImage = global::IslandDeployed.Properties.Resources.M;
            this.DeployMercenarie.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DeployMercenarie.Location = new System.Drawing.Point(100, 25);
            this.DeployMercenarie.Name = "DeployMercenarie";
            this.DeployMercenarie.Size = new System.Drawing.Size(100, 100);
            this.DeployMercenarie.TabIndex = 0;
            this.DeployMercenarie.TabStop = false;
            this.DeployMercenarie.Click += new System.EventHandler(this.DeployMercenarie_Click);
            // 
            // ActionPanel
            // 
            this.ActionPanel.BackColor = System.Drawing.Color.Transparent;
            this.ActionPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ActionPanel.Controls.Add(this.ActionShot);
            this.ActionPanel.Controls.Add(this.Skip);
            this.ActionPanel.Controls.Add(this.ActionMove);
            this.ActionPanel.Location = new System.Drawing.Point(252, 594);
            this.ActionPanel.Name = "ActionPanel";
            this.ActionPanel.Size = new System.Drawing.Size(633, 121);
            this.ActionPanel.TabIndex = 4;
            this.ActionPanel.Visible = false;
            // 
            // ActionShot
            // 
            this.ActionShot.BackgroundImage = global::IslandDeployed.Properties.Resources.rifl;
            this.ActionShot.Location = new System.Drawing.Point(259, 3);
            this.ActionShot.Name = "ActionShot";
            this.ActionShot.Size = new System.Drawing.Size(101, 100);
            this.ActionShot.TabIndex = 1;
            this.ActionShot.TabStop = false;
            this.ActionShot.Click += new System.EventHandler(this.ActionShot_Click);
            // 
            // Skip
            // 
            this.Skip.BackgroundImage = global::IslandDeployed.Properties.Resources.wait;
            this.Skip.Location = new System.Drawing.Point(508, 3);
            this.Skip.Name = "Skip";
            this.Skip.Size = new System.Drawing.Size(97, 100);
            this.Skip.TabIndex = 0;
            this.Skip.TabStop = false;
            this.Skip.Click += new System.EventHandler(this.Skip_Click);
            // 
            // ActionMove
            // 
            this.ActionMove.BackgroundImage = global::IslandDeployed.Properties.Resources.Move1;
            this.ActionMove.Location = new System.Drawing.Point(39, 13);
            this.ActionMove.Name = "ActionMove";
            this.ActionMove.Size = new System.Drawing.Size(96, 90);
            this.ActionMove.TabIndex = 0;
            this.ActionMove.TabStop = false;
            this.ActionMove.Click += new System.EventHandler(this.ActionMove_Click);
            // 
            // LogOfMoves
            // 
            this.LogOfMoves.BackColor = System.Drawing.SystemColors.InfoText;
            this.LogOfMoves.Font = new System.Drawing.Font("Neogrey Medium", 9.7F, System.Drawing.FontStyle.Bold);
            this.LogOfMoves.ForeColor = System.Drawing.Color.Green;
            this.LogOfMoves.Location = new System.Drawing.Point(1057, 168);
            this.LogOfMoves.Name = "LogOfMoves";
            this.LogOfMoves.Size = new System.Drawing.Size(211, 360);
            this.LogOfMoves.TabIndex = 5;
            this.LogOfMoves.Text = "Hello world. U";
            // 
            // BattleField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.LogOfMoves);
            this.Controls.Add(this.ActionPanel);
            this.Controls.Add(this.deploymentPanel);
            this.Name = "BattleField";
            this.Text = "BattleField";
            this.Load += new System.EventHandler(this.BattleField_Load);
            this.Controls.SetChildIndex(this.deploymentPanel, 0);
            this.Controls.SetChildIndex(this.ActionPanel, 0);
            this.Controls.SetChildIndex(this.LogOfMoves, 0);
            this.deploymentPanel.ResumeLayout(false);
            this.deploymentPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeploySniper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeployInfantry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeployMercenarie)).EndInit();
            this.ActionPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ActionShot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Skip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ActionMove)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel deploymentPanel;
        private System.Windows.Forms.Label snipersLeft;
        private System.Windows.Forms.Label infantryLeft;
        private System.Windows.Forms.Label mercenariesLeft;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox DeploySniper;
        private System.Windows.Forms.PictureBox DeployInfantry;
        private System.Windows.Forms.PictureBox DeployMercenarie;
        private System.Windows.Forms.Panel ActionPanel;
        private System.Windows.Forms.PictureBox ActionShot;
        private System.Windows.Forms.PictureBox Skip;
        private System.Windows.Forms.PictureBox ActionMove;
        private System.Windows.Forms.RichTextBox LogOfMoves;
    }
}