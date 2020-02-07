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
        int gold = Forms.Welcome.goldForUnits;
        
        public static int numberOfSnipers;
        public static int numberOfMercenaries;
        public static int numberOfInfantry;

        public Shop()
        {
            InitializeComponent();
        }
        private void Shop_Load(object sender, EventArgs e)
        {
            numberOfInfantry = 0; numberOfMercenaries = 0; numberOfSnipers = 0;

            goldLeft.Text = gold.ToString();
            //pictureBox0.MouseHover += pictureBox0_MouseHover;
        }

        private bool CanAfford(int cost)
        {
            if (gold >= cost)
            {
                gold -= cost;
                goldLeft.Text = gold.ToString();
                return true;
            }
            else
            {
                MessageBox.Show("You don't have enough money.");
                return false;
            }
        }

        private void buyInfantry_Click(object sender, EventArgs e)
        {
            if (CanAfford(200))
            {
                numberOfInfantry++;
                InfantryLabel.Text = "You bought: " + numberOfInfantry.ToString();
            }
            
            
        }

        private void buyMercenarie_Click(object sender, EventArgs e)
        {
            if (CanAfford(150))
            {
                numberOfMercenaries++;
                MercenarieLabel.Text = "You bought: " + numberOfMercenaries.ToString();
            }
            
        }

        private void buySniper_Click(object sender, EventArgs e)
        {
            if (CanAfford(400))
            {
                numberOfSnipers++;
                SniperLabel.Text = "You bought: " + numberOfSnipers.ToString();
            }
        }



        private void Start_Click_1(object sender, EventArgs e)
        {
            if (gold > 500)
            {
                MessageBox.Show("You haven't even spent half of your money. BUY MORE.");
            }
            else
            {
                Close();
                BattleField game = new BattleField();
                game.Show();
            }


        }


    }
}
