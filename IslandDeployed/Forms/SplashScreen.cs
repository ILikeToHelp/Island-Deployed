using System;
using System.Threading;
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
    public partial class SplashScreen : BaseForm
    {
        public SplashScreen()
        {
            InitializeComponent();
        }
        private void SplashScreen_Load(object sender, EventArgs e)
        {
            BattleField a = new BattleField();
            a.Show();
            _ = this.TopMost;
            Thread.Sleep(100);
            this.Close();
  
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            
            
            
        }
    }
}
