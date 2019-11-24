using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace IslandDeployed
{
    public partial class Shop : BaseForm
    {
        int gold = 1000;
        public static int numberOfSnipers = 0;
        public static int numberOfMercenaries = 0;
        public static int numberOfInfantry = 0;

        public Shop()
        {
            InitializeComponent();
        }
        private void Shop_Load(object sender, EventArgs e)
        {

            goldLeft.Text = gold.ToString();
            //pictureBox0.MouseHover += pictureBox0_MouseHover;
        }

        private void CanAfford(int cost)
        {
            if (gold >= cost)
            {
                gold -= cost;
                goldLeft.Text = gold.ToString();
            }
            else
            {
                MessageBox.Show("You don't have enough money.");
            }
        }

        private void buyInfantry_Click(object sender, EventArgs e)
        {
           CanAfford(200);
            numberOfInfantry++;
        }

        private void buyMercenarie_Click(object sender, EventArgs e)
        {
            CanAfford(150);
            numberOfMercenaries++;
        }

        private void buySniper_Click(object sender, EventArgs e)
        {
            CanAfford(400);
            numberOfSnipers++;
        }



        private void Start_Click_1(object sender, EventArgs e)
        {
            Close();
            BattleField game = new BattleField();
            game.Show();

        }

        //private void pictureBox2_MouseHover(object sender, EventArgs e)
        //{
        //    ToolTip ToolTip1 = new ToolTip();
        //    ToolTip1.SetToolTip(pictureBox2, "You have " + numberOfSnipers.ToString() + " Snipers.");
        //}
    }
}
