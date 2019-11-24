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
    public partial class MainMenu : BaseForm
    {
        public MainMenu()
        {
            InitializeComponent();
            // FOR FUTURE REFERENCE
            //Cursor = new Cursor(GetType(),  Application.StartupPath+ "\\windowfi.cur");
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            //create new button
            Button Start = new Button();
            Start.Size = new Size(360, 80);
            Start.BackColor = Color.Transparent;
            Start.Location = new Point(480, 280);
            Start.Text = "Start new game";

            Start.Click += new EventHandler(Start_Click);
            this.Controls.Add(Start);

        }

        private void Start_Click(object sender, EventArgs e)
        {
            this.Hide();
            NewGame game = new NewGame();
            game.Show();

        }
    }
}
