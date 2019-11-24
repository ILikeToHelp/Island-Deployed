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
    public partial class BattleField : BaseForm
    {
        //-----------------START OF VARIABLE DECLARATION-----------------------------\\
        static readonly int width = 15;
        static readonly int height = 9;

        bool canContinue = true;

        int numberOfMercenaries = Shop.numberOfMercenaries;
        int numberOfInfantry = Shop.numberOfInfantry;
        int numberOfSnipers = Shop.numberOfSnipers;

        int computerGold = 1500;
        Classes.Soldier temporary = new Classes.Soldier();

        bool [,] allowedMoves = new bool [width, height];
        PictureBox[,] pictureArray = new PictureBox[width, height];

        Classes.Soldier[,] arrayOfSoldiers =                                             // Object array, of size of the battlefield 
                           new Classes.Soldier[width, height];                           // to allow object manipulation


        string finiteStateMachine = "initialization";
        string whoIsBeingDeployed = "none";
        public struct CoOrds
        {
            public int x, y;
            public CoOrds(int p1, int p2)
            {
                x = p1;
                y = p2;
            }

        }



        //-----------------END OF VARIABLE DECLARATION-----------------------------\\


        public BattleField()                                                             // initializes
        {
            InitializeComponent();
        }
        private void BattleField_Load(object sender, EventArgs e)                        // loads
        {
            CreateField();
            finiteStateMachine = "deployment";
            UpdateLabels();
            ComputerDeployment();

        }
        private void CreateField()                                                       // sets up the "battle field" (width x height picture boxes)  


        {
            //starting coordinates
            int x = 0;
            int y;

            for (int i = 0; i < width; i++)
            {
                x += 65; // increment horizontal spacing each row
                y = 595;     // constant height when row finished/initialised
                for (int j = 0; j < height; j++)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureArray[i, j] = pictureBox;
                    pictureBox.BackColor = Color.Transparent;
                    pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
                    pictureBox.Location = new Point(x, y);
                    pictureBox.Size = new Size(60, 60);
                    pictureBox.BackgroundImage = Properties.Resources.grassSmall;

                    //handler for the picture boxes
                    pictureBox.Click += new EventHandler(pictureBox_Click);
                    Controls.Add(pictureBox);

                    y -= 65; //increment after each button
                }
            }
        }
        private void ComputerDeployment()
        {
            Random rnd = new Random();

            while (computerGold > 150)
            {
                // pseudo-random 33% for each of the soldiers to be deployed
                int l = rnd.Next(1, 100);
                // randomly chooses coordinates of computer units that are going to be deployed
                int v = rnd.Next(0, width);
                int g = rnd.Next(height - 3, height);
                if (l < 33 && g != 0)
                {

                    if (arrayOfSoldiers[v, g] == null && computerGold >= 150)
                    {
                        arrayOfSoldiers[v, g] = new Classes.Soldier(v, g, 4, 60, 20, "Mercenarie", 100, false);
                        pictureArray[v, g].BackgroundImage = Properties.Resources.M2;
                        Classes.Soldier.countPlayer2++;
                        computerGold -= 150;
                    }
                }
                else if (l > 66)
                {
                    if (arrayOfSoldiers[v, g] == null && computerGold >= 200)
                    {
                        arrayOfSoldiers[v, g] = new Classes.Soldier(v, g, 3, 50, 33, "Infantry", 200, false);
                        pictureArray[v, g].BackgroundImage = Properties.Resources.I2;
                        Classes.Soldier.countPlayer2++;
                        computerGold -= 200;
                    }
                }
                else
                {
                    if (arrayOfSoldiers[v, g] == null && computerGold >= 400 && g == 0)
                    {
                        arrayOfSoldiers[v, g] = new Classes.Soldier(v, g, 2, 50, 100, "Sniper", 50, false);
                        pictureArray[v, g].BackgroundImage = Properties.Resources.S2;
                        Classes.Soldier.countPlayer2++;
                        computerGold -= 400;
                    }
                }
            }
        }                                            // randomly allocates computer's units

        private void DeployMercenarie_Click(object sender, EventArgs e)
        {
            if (numberOfMercenaries > 0)
            {
                deploymentPanel.Visible = false;
                finiteStateMachine = "placement";
                whoIsBeingDeployed = "mercenarie";
                numberOfMercenaries -= 1;
                UpdateLabels();
            }
        }              // <-
        private void DeployInfantry_Click(object sender, EventArgs e)
        {
            if (numberOfInfantry > 0)
            {
                deploymentPanel.Visible = false;
                finiteStateMachine = "placement";
                whoIsBeingDeployed = "infantry";
                numberOfInfantry -= 1;
                UpdateLabels();
            }
        }                // three methods for deploying the correct unit
        private void DeploySniper_Click(object sender, EventArgs e)
        {
            if (numberOfSnipers > 0)
            {
                deploymentPanel.Visible = false;
                finiteStateMachine = "placement";
                whoIsBeingDeployed = "sniper";
                numberOfSnipers -= 1;
                UpdateLabels();
            }
        }                  // <-

        private void UpdateLabels()
        {
            // short method to update labels on the deployment panel

            infantryLeft.Text = numberOfInfantry.ToString();
            mercenariesLeft.Text = numberOfMercenaries.ToString();
            snipersLeft.Text = numberOfSnipers.ToString();
        }                                                  

        private void PlaceUnit(PictureBox p, CoOrds a)                                  // method responsible for placing unit on the field
        {                                                                               // and assigning correct values to the object array
            if (whoIsBeingDeployed == "mercenarie")
            {
                p.BackgroundImage = Properties.Resources.M;
                arrayOfSoldiers[a.x, a.y] = new Classes.Soldier(a.x, a.y, 4, 60, 20, "Mercenarie", 100, true);
            }
            else if (whoIsBeingDeployed == "infantry")
            {
                p.BackgroundImage = Properties.Resources.I;
                arrayOfSoldiers[a.x, a.y] = new Classes.Soldier(a.x, a.y, 3, 50, 33, "Infantry", 200, true);
            }
            else
            {
                p.BackgroundImage = Properties.Resources.S;
                arrayOfSoldiers[a.x, a.y] = new Classes.Soldier(a.x, a.y, 2, 59, 100, "Sniper", 50, true);
            }

            if (numberOfInfantry == 0 && numberOfMercenaries == 0 && numberOfSnipers == 0)
            {
                finiteStateMachine = "p1turn";
            }
            else
            {
                finiteStateMachine = "deployment";
                deploymentPanel.Visible = true;
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;

            int x = FindPicture(picture).x;
            int y = FindPicture(picture).y;

            if (finiteStateMachine == "placement")
            {
                PlaceUnit(picture, FindPicture(picture));
            }

            else if (finiteStateMachine == "p1turn" && arrayOfSoldiers[x, y] != null) // can perform an action if and only if this place is occupied by players unit
            {

                if (arrayOfSoldiers[x, y].Player1Owned)
                {
                    ActionPanel.Visible = true;
                    ActionPanel.BackgroundImage = Properties.Resources.panel;
                    temporary = arrayOfSoldiers[x, y];

                }

            }
            else if (finiteStateMachine == "moving" )
            {

                if (arrayOfSoldiers[x, y] == null)
                {
                    ChangePosition(x, y);
                }
                else if (!arrayOfSoldiers[x,y].Player1Owned)
                {
                    Melee(x,y);
                }
            }
        }                    // game flow determined by states of FSM

        private void Skip_Click(object sender, EventArgs e)
        {
            CleanBoard();
            ActionPanel.Visible = false;
        }

        //--------------------ALL MOVE METHODS BELOW-----------------------------\\
        private void ActionMove_Click(object sender, EventArgs e)
        {
            finiteStateMachine = "moving";
            ActionPanel.Visible = false;
            MovesAllowed();

        } 
        private void MovesAllowed()
        {
            // logic behind movement system

            canContinue = true;
            int speed = temporary.Speed;

            for (int i = 1; i <= speed; i++)
            {
                if (canContinue)
                {

                    if (temporary.getXCoords() + i < width)
                    {
                        
                        MovementVisuals(i, 0);                                // right
                       
                        if (temporary.getYCoords() + i < height)
                        {
                            MovementVisuals(i, i);                            // diagno right up
                        }
                        
                        if (temporary.getYCoords() - i >= 0)
                        {
                            MovementVisuals(i, -i);                           // diagno right down
                        }
                    }


                    if (temporary.getXCoords() - i >= 0)
                    {
                        
                        MovementVisuals(-i, 0);                               // left

                        if (temporary.getYCoords() - i >= 0)        // left diagno down
                        {
                            MovementVisuals(-i, -i);
                        }
                        
                        if (temporary.getYCoords() + i < height)    // left diagno up
                        {
                            MovementVisuals(-i, i);
                        }

                    }

                    if (temporary.getYCoords() + i < height)
                    {
                        MovementVisuals(0, i);                                // up
                    } 

                    if (temporary.getYCoords() - i >= 0)
                    {
                        MovementVisuals(0, -i);                               // down
                    }

                }

            }

        }                                           
        private void MovementVisuals(int xOffset, int yOffset)
        {  
            // visual effect and assigment of moves to allowedMoves array.

            int x = temporary.getXCoords() + xOffset;
            int y = temporary.getYCoords() + yOffset;

            allowedMoves[x, y] = true;

            if (arrayOfSoldiers[x, y] == null)
            {
                pictureArray[x, y].BackgroundImage = Properties.Resources.canGo;

            }
            else if (arrayOfSoldiers[x, y].Player1Owned == false)
            {
                VisualiseEnemy(x, y);
                
                canContinue = false;                // if soldier encounters an enemy then he must not be able to continue past them
            }

        }
        private void ChangePosition(int x, int y)
        {   
            // swaps location of object which moves

            arrayOfSoldiers[temporary.getXCoords(), temporary.getYCoords()] = null;    // old location <= null
            temporary.setXCoords(x); temporary.setYCoords(y);                          // object location <= new co-ords
            arrayOfSoldiers[x, y] = temporary;                                         // update array
            pictureArray[x, y].BackgroundImage = Properties.Resources.M;
            CleanBoard();
            finiteStateMachine = "p1turn";
        
        }
        private void Melee(int x, int y)
        {
            // moving on to a tile taken by computers unit causes a fight
            arrayOfSoldiers[x, y].Health -= temporary.MeleeDamage;

            if (arrayOfSoldiers[x,y].Health == 0)
            {
                ChangePosition(x, y);
            }

            CleanBoard();

            finiteStateMachine = "p1turn";

        }

        //---------------------END OF MOVE METHODS------------------------------\\

        private CoOrds FindPicture(PictureBox p)
        {
            // nested 'for' loop to find which button was clicked

            CoOrds a = new CoOrds();

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (pictureArray[i, j] == p)
                    {

                        a.x = i;
                        a.y = j;

                    }
                }
            }
            return a;
        }                                     // returns cooridantes of the picturebox clicked
        private void VisualiseEnemy(int x, int y)
        {
            // check the type of an enemy soldier and set the correct picture

            if (arrayOfSoldiers[x, y].Type == "Sniper")
            {
                pictureArray[x, y].BackgroundImage = Properties.Resources.S2;
            }
            else if (arrayOfSoldiers[x, y].Type == "Mercenarie")
            {
                pictureArray[x, y].BackgroundImage = Properties.Resources.M2;
            }
            else
            {
                pictureArray[x, y].BackgroundImage = Properties.Resources.I2;
            }
        }                                    // sets correct pictures
        private void CleanBoard()
        {
            // nested 'for' loop which reads value and restores the original images

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (arrayOfSoldiers[i,j] == null)
                    {
                        pictureArray[i, j].BackgroundImage = Properties.Resources.grassSmall;
                    }
                    else if (!arrayOfSoldiers[i, j].Player1Owned)
                    {
                        VisualiseEnemy(i,j);
                    }
                    
                }
            }
        }                                                    // gets rid of visual effects and resets important values

    }
}
