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
    public partial class Welcome : BaseForm
    {
        public static int goldForUnits;
        public Welcome()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            goldForUnits = 0;
        }

        private void Easy_Click(object sender, EventArgs e)
        {
            goldForUnits = 1500;
            Hide();
            Shop shop = new Shop();
            shop.Show();
        }

        private void Medium_Click(object sender, EventArgs e)
        {
            goldForUnits = 1000;
            Hide();
            Shop shop = new Shop();
            shop.Show();
        }

        private void Hard_Click(object sender, EventArgs e)
        {
            goldForUnits = 600;
            Hide();
            Shop shop = new Shop();
            shop.Show();
        }
    }
}
