using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IslandDeployed.Forms
{
    public partial class EndGameScreen : BaseForm
    {
        public EndGameScreen()
        {
            InitializeComponent();
        }

        private void EndGameScreen_Load(object sender, EventArgs e)
        {
            if (BattleField.win)
            {
                WinOrLose.BackgroundImage = Properties.Resources.win;
                text.Text = "YOU WIN";
                text.Location = new Point(440, 200);
            }
            else
            {
                WinOrLose.BackgroundImage = Properties.Resources.dead;
                text.Text = "YOU LOSE";

            }
        }

        private void WinOrLose_Click(object sender, EventArgs e)
        {

        }

        private void BackToMainMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            Welcome back = new Welcome();
            back.Show();
        }
    }
}
