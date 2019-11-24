using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IslandDeployed
{
    public partial class NewGame : BaseForm
    {
        public NewGame()
        {
            InitializeComponent();
        }

        private void NewGame_Load(object sender, EventArgs e)
        {
            //create new button
            Button Single = new Button();
            Single.Size = new Size(360, 80);
            Single.BackColor = Color.Transparent;
            Single.Location = new Point(480, 280);
            Single.Text = "Single Player";

            Single.Click += new EventHandler(Single_Click);
            this.Controls.Add(Single);

        }

        private void Single_Click(object sender, EventArgs e)
        {
            this.Close();
            Shop game = new Shop();
            game.Show();

        }
    }
}
