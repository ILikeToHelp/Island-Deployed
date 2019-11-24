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
    public partial class BaseForm : Form
    {
        //Base class to unify design of the GUI.
        public BaseForm()
        {
            InitializeComponent();
            
        }


        private void BaseForm_Load(object sender, EventArgs e)
        {
            
            Size = new Size(1408,792);
            BackgroundImage = Properties.Resources.Background; // 'Background' is the 'camo' image.
            CenterToScreen();
            FormBorderStyle = FormBorderStyle.None;

            button1.Size = new Size(30, 30);
            button1.Location = new Point(1378, 0);                  // x position is: 1280 - 30 = 1250
            button1.BackgroundImage = Properties.Resources.Quit;    // 'Quit' is the name of the 'skull' image.
            button1.MouseHover += button1_MouseHover;
        }
        private void button1_MouseHover(object sender, EventArgs e)
        {
            ToolTip ToolTip1 = new ToolTip();
            ToolTip1.SetToolTip(button1, "Quit Application");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
            
        }
    }
}
