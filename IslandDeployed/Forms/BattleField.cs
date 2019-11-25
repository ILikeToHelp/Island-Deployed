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

        public static bool win = false;

        int computerGold = 200;

        List<CoOrds> player1Soldiers = new List<CoOrds>();//players 2 soldiers coordinatees
        List<CoOrds> computerSoldiers = new List<CoOrds>();//players 1 soldiers coordinatees

        int numberOfMercenaries = Shop.numberOfMercenaries;
        int numberOfInfantry = Shop.numberOfInfantry;
        int numberOfSnipers = Shop.numberOfSnipers;

        bool canContinue = true;


        Classes.Soldier temporary = new Classes.Soldier();

        bool[,] allowedMoves = new bool[width, height];

        Label[,] labelArray = new Label[width, height];

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

        void ResetAllValues()
        {
            Classes.Soldier.countPlayer1 = 0;
            Classes.Soldier.countPlayer2 = 0;
            finiteStateMachine = "initialization";
            whoIsBeingDeployed = "none";

            temporary = null;
            canContinue = true;
            win = false;
            for (int i = 0; i < player1Soldiers.Count; i++)
            {
                player1Soldiers = null;
            }
            for (int i = 0; i < computerSoldiers.Count; i++)
            {
                computerSoldiers = null;
            }

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    allowedMoves[i, j] = false;
                    arrayOfSoldiers[i, j] = null;
                    pictureArray[i, j] = null;

                }
            }
        }
        private void BattleField_Load(object sender, EventArgs e)                        // loads
        {
            ResetAllValues();
            CreateField();
            ComputerDeployment();
            finiteStateMachine = "deployment";
            UpdateLabels();
            deploymentPanel.Visible = true;
            deploymentPanel.BringToFront();

        }
        private void CreateField()                                                       // sets up the "battle field" (width x height picture boxes)  


        {
            //starting coordinates
            int x = 0;
            int y;

            for (int i = 0; i < width; i++)
            {
                x += 65;        // increment horizontal spacing each row
                y = 595;       // constant height when row finished/initialised
                for (int j = 0; j < height; j++)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureArray[i, j] = pictureBox;
                    pictureBox.BackColor = Color.Transparent;
                    pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
                    pictureBox.Location = new Point(x, y);
                    pictureBox.Size = new Size(60, 60);
                    pictureBox.Image = Properties.Resources.grassSmall;

                    //handler for the picture boxes
                    pictureBox.Click += new EventHandler(pictureBox_Click);
                    Controls.Add(pictureBox);


                    Label newlabel = new Label(); //creating a new label
                    labelArray[i, j] = newlabel;
                    newlabel.Location = new Point(x + 10, y);
                    newlabel.Text = "";
                    newlabel.Width = 46;
                    newlabel.Height = 10;
                    newlabel.ForeColor = Color.DarkRed;
                    Controls.Add(newlabel);
                    newlabel.BringToFront();
                    newlabel.Visible = false;

                    y -= 65; //increment after each button
                }
            }
        }
        private void ComputerDeployment()
        {
            // method which deploys computers unit

            Random rnd = new Random();

            while (computerGold > 150)
            {

                // randomly chooses coordinates 
                int v = rnd.Next(0, width);
                int g = rnd.Next(height - 3, height);
                bool deployed = false;

                if (arrayOfSoldiers[v, g] == null && computerGold >= 400 && g == height - 1)
                {
                    arrayOfSoldiers[v, g] = new Classes.Soldier(v, g, 2, 50, 100, 80, "Sniper", 50, 50, false);
                    pictureArray[v, g].Image = Properties.Resources.S2;
                    computerGold -= 400;

                    CoOrds coordinates = new CoOrds();
                    coordinates.x = v; coordinates.y = g;
                    computerSoldiers.Add(coordinates);
                    SetHealthBar(v, g);
                }



                else if (arrayOfSoldiers[v, g] == null && computerGold >= 200 && g != height - 3)
                {
                    arrayOfSoldiers[v, g] = new Classes.Soldier(v, g, 3, 50, 33, 70, "Infantry", 200, 200, false);
                    pictureArray[v, g].Image = Properties.Resources.I2;
                    computerGold -= 200;

                    CoOrds coordinates = new CoOrds();
                    coordinates.x = v; coordinates.y = g;
                    computerSoldiers.Add(coordinates);
                    SetHealthBar(v, g);
                }

                else if (arrayOfSoldiers[v, g] == null && computerGold >= 150 )
                {
                    arrayOfSoldiers[v, g] = new Classes.Soldier(v, g, 4, 60, 20, 60, "Mercenarie", 100, 100, false);
                    pictureArray[v, g].Image = Properties.Resources.M2;
                    deployed = true;
                    computerGold -= 150;

                    CoOrds coordinates = new CoOrds();
                    coordinates.x = v; coordinates.y = g;
                    computerSoldiers.Add(coordinates);
                    SetHealthBar(v, g);

                }

            }

        }                                            // randomly allocates computer's units

        private bool IsPlayerNear(int x, int y)
        {
            bool isIt = false;

            MovesAllowed();

            return isIt;
        }
        private void ChargeAtUser()
        { }
        private void HierarchyOfComputerMoves()
        {
            bool computerMoved = false;

            while (!computerMoved)
            {
                for (int i = 0; i < computerSoldiers.Count; i++)
                {

                    int x = computerSoldiers.ElementAt(i).x;
                    int y = computerSoldiers.ElementAt(i).y;
                    string who = arrayOfSoldiers[x, y].Type;
                    if (who == "Sniper")
                    {
                        LogOfMoves.Text += "\nSniper";
                        ComputerShoots(x, y);
                        computerMoved = true;
                        break;
                    }
                    else if (who == "Mercenarie")
                    {
                        temporary = arrayOfSoldiers[x, y];
                        LogOfMoves.Text += "\nMercenarie";
                        if (IsPlayerNear(x, y))
                        {
                            ChargeAtUser();
                            computerMoved = true;
                            break;
                        }
                    }
                    else if (who == "Infantry")
                    {
                        LogOfMoves.Text += "\nInfantry";
                        ComputerShoots(x, y);
                        computerMoved = true;
                        break;
                    }
                }
                break;
            }
            // finnaly check if user has any units left
            if (player1Soldiers.Count == 0)
            {

                MessageBox.Show("YOU LOSE");
                this.Close();
                Forms.EndGameScreen c = new Forms.EndGameScreen();
                c.Show();
            }
            else
            {
                LogOfMoves.Text += "\nYour turn";
                finiteStateMachine = "playersTurn";
            }

        }
        private bool IsUnitDead(int x, int y)
        {
            // if unit got killed, remove it from the list of objects and decreas count of user's units.
            if (arrayOfSoldiers[x, y].Health == 0)
            {

                arrayOfSoldiers[x, y] = null;

                if (finiteStateMachine == "computersTurn")
                {
                    for (int m = 0; m < player1Soldiers.Count; m++)
                    {
                        if (player1Soldiers.ElementAt(m).x == x && player1Soldiers.ElementAt(m).y == y)
                        {
                            player1Soldiers.RemoveAt(m);
                            Classes.Soldier.countPlayer1 -= 1;
                            break;
                        }
                    }
                }
                else
                {
                    for (int m = 0; m < computerSoldiers.Count; m++)
                    {
                        if (computerSoldiers.ElementAt(m).x == x && computerSoldiers.ElementAt(m).y == y)
                        {
                            computerSoldiers.RemoveAt(m);
                            Classes.Soldier.countPlayer2 -= 1;
                            break;
                        }
                    }
                }

                return true;
            }

            return false;
        }
        private void ComputerShoots(int xCP, int yCP)
        {
            // when computer shoots it randomly chooses target.

            Random random = new Random();
            int w = random.Next(player1Soldiers.Count);

            //users coordinates
            int y = player1Soldiers.ElementAt(w).y;
            int x = player1Soldiers.ElementAt(w).x;

            if (arrayOfSoldiers[xCP, yCP].dealDamage())                                      // Has computer missed or scored a hit ?
            {

                arrayOfSoldiers[x, y].TakeDamage(arrayOfSoldiers[xCP, yCP].RangeDamage);     // If so, damage user's unit.
                LogOfMoves.Text += "\nDelt: " + arrayOfSoldiers[xCP, yCP].RangeDamage.ToString();
                if (IsUnitDead(x, y))
                {
                    pictureArray[x, y].BackgroundImage = Properties.Resources.dead;
                }
                
                CleanBoard();

            }

        }

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

        private void PlaceUnit(PictureBox p, CoOrds a)                                  // method responsible for placing unit onto the field
        {                                                                               // and assigning correct values to the object array
            if (whoIsBeingDeployed == "mercenarie")
            {
                p.Image = Properties.Resources.M;
                arrayOfSoldiers[a.x, a.y] = new Classes.Soldier(a.x, a.y, 4, 60, 20, 50, "Mercenarie", 100, 100, true);
            }
            else if (whoIsBeingDeployed == "infantry")
            {
                p.Image = Properties.Resources.I;
                arrayOfSoldiers[a.x, a.y] = new Classes.Soldier(a.x, a.y, 3, 50, 33, 66, "Infantry", 200, 200, true);
            }
            else
            {
                p.Image = Properties.Resources.S;
                arrayOfSoldiers[a.x, a.y] = new Classes.Soldier(a.x, a.y, 2, 50, 100, 80, "Sniper", 50, 50, true);
            }

            if (numberOfInfantry == 0 && numberOfMercenaries == 0 && numberOfSnipers == 0)
            {
                finiteStateMachine = "playersTurn";
                CleanBoard();
            }
            else
            {
                finiteStateMachine = "deployment";
                deploymentPanel.Visible = true;
            }

            CoOrds coordinates = new CoOrds();
            coordinates = a;
            player1Soldiers.Add(coordinates);
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            LogOfMoves.Text += "\n mine: " + Classes.Soldier.countPlayer1.ToString() + " and: " + Classes.Soldier.countPlayer2.ToString();
            LogOfMoves.Text += "\n FSM: " + finiteStateMachine;
            PictureBox picture = (PictureBox)sender;

            int x = FindPicture(picture).x;
            int y = FindPicture(picture).y;

            if (finiteStateMachine == "placement")
            {
                PlaceUnit(picture, FindPicture(picture));
            }

            else if (finiteStateMachine == "playersTurn" && arrayOfSoldiers[x, y] != null) // can perform an action if and only if this place is occupied by players unit
            {

                if (arrayOfSoldiers[x, y].Player1Owned)
                {
                    ActionPanel.Visible = true;
                    ActionPanel.BackgroundImage = Properties.Resources.panel;
                    temporary = arrayOfSoldiers[x, y];

                }

            }
            else if (finiteStateMachine == "moving")
            {

                if (arrayOfSoldiers[x, y] == null)
                {
                    ChangePosition(x, y);
                }
                else if (!arrayOfSoldiers[x, y].Player1Owned)
                {
                    Melee(x, y);
                }
            }
            else if (finiteStateMachine == "shooting")
            {
                Shooting(x, y);
            }
            
        }                    // game flow determined by states of FSM

        private void Skip_Click(object sender, EventArgs e)
        {
            CleanBoard();
            ActionPanel.Visible = false;
            finiteStateMachine = "computersTurn";
            HierarchyOfComputerMoves();
        }

        //--------------------Move methods below-------------------\\
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
                pictureArray[x, y].Image = Properties.Resources.canGo;

            }
            else if (!arrayOfSoldiers[x, y].Player1Owned)
            {
                if (arrayOfSoldiers[x, y].Type == "Sniper")
                {
                    pictureArray[x, y].Image = Properties.Resources.S2Red;
                }
                else if (arrayOfSoldiers[x, y].Type == "Mercenarie")
                {
                    pictureArray[x, y].Image = Properties.Resources.M2Red;
                }
                else
                {
                    pictureArray[x, y].Image = Properties.Resources.I2Red;
                }

                canContinue = false;                // if soldier encounters an enemy then he must not be able to continue past them
            }

        }
        private void ChangePosition(int x, int y)
        {
            // swaps location of object which moves

            int i = temporary.getXCoords();
            int j = temporary.getYCoords();

            for (int m = 0; m < player1Soldiers.Count; m++)
            {
                if (player1Soldiers.ElementAt(m).x == i && player1Soldiers.ElementAt(m).y == j)
                {
                    player1Soldiers.RemoveAt(m);
                    break;
                }
            }
            arrayOfSoldiers[i,j] = null;    // old location <= null

            CoOrds coOrds = new CoOrds();
            coOrds.x = x;
            coOrds.y = y;
            player1Soldiers.Add(coOrds);

            temporary.setXCoords(x); temporary.setYCoords(y);                          // object location <= new co-ords
            arrayOfSoldiers[x, y] = temporary;                                         // update array
            CleanBoard();
            finiteStateMachine = "computersTurn";
            HierarchyOfComputerMoves();

        }
        private void Melee(int x, int y)
        {
            // moving on to a tile taken by computers unit causes a fight
            arrayOfSoldiers[x, y].Health -= temporary.MeleeDamage;

            if (IsUnitDead(x, y))
            {
                for (int m = 0; m < computerSoldiers.Count; m++)
                {
                    if (player1Soldiers.ElementAt(m).x == x && player1Soldiers.ElementAt(m).y == y)
                    {
                        computerSoldiers.RemoveAt(m);
                        break;
                    }
                }

                ChangePosition(x, y);
                Classes.Soldier.countPlayer2--;
                DidIWin();

            }
            CleanBoard();

            finiteStateMachine = "computersTurn";
            HierarchyOfComputerMoves();

        }

        //------------------End of user movement methods--------------------\\

        //-----------------User fire power methods below--------------------\\
        private void ActionShot_Click(object sender, EventArgs e)
        {
            finiteStateMachine = "shooting";
            ActionPanel.Visible = false;
        }
        private void Shooting(int x, int y)
        {
            if (arrayOfSoldiers[x, y] != null && !arrayOfSoldiers[x, y].Player1Owned)
            {
                arrayOfSoldiers[x, y].Health -= temporary.RangeDamage;
                if (IsUnitDead(x, y))
                {
                    Classes.Soldier.countPlayer1--;
                    labelArray[x, y].Visible = false;
                    pictureArray[x, y].BackgroundImage = Properties.Resources.dead;
                    
                }
                if (DidIWin())
                {

                }
                else
                {
                    CleanBoard();
                    finiteStateMachine = "computersTurn";
                    HierarchyOfComputerMoves();
                }

            }
        }

        //--------------------End of fire power methods--------------------\\
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

        private void CleanBoard()
        {
            // nested 'for' loop which reads value and restores the original images

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (arrayOfSoldiers[i, j] == null)
                    {
                        pictureArray[i, j].Image = Properties.Resources.grassSmall;
                        labelArray[i, j].Visible = false;
                    }
                    else
                    {
                        VisualiseBoard(i, j);
                        labelArray[i, j].Visible = true;
                        SetHealthBar(i, j);
                    }

                }
            }
        }
        private void VisualiseBoard(int x, int y)
        {
            // check the type of an enemy soldier and set the correct picture
            if (arrayOfSoldiers[x, y].Player1Owned)
            {
                if (arrayOfSoldiers[x, y].Type == "Sniper")
                {
                    pictureArray[x, y].Image = Properties.Resources.S;
                }
                else if (arrayOfSoldiers[x, y].Type == "Mercenarie")
                {
                    pictureArray[x, y].Image = Properties.Resources.M;
                }
                else
                {
                    pictureArray[x, y].Image = Properties.Resources.I;
                }

            }
            else
            {
                if (arrayOfSoldiers[x, y].Type == "Sniper")
                {
                    pictureArray[x, y].Image = Properties.Resources.S2;
                }
                else if (arrayOfSoldiers[x, y].Type == "Mercenarie")
                {
                    pictureArray[x, y].Image = Properties.Resources.M2;
                }
                else
                {
                    pictureArray[x, y].Image = Properties.Resources.I2;
                }
            }


        }                                    // sets correct pictures for soldiers
        void SetHealthBar(int x, int y)
        {
            labelArray[x, y].Text = "";

            for (int i = 0; i <= arrayOfSoldiers[x, y].GetHealthBar(); i++)
            {
                labelArray[x, y].Text += "|";
            }

            if (arrayOfSoldiers[x, y].Health == 0)
            {
                labelArray[x, y].Visible = false;
            }

        }
        private bool DidIWin()
        {
            if (Classes.Soldier.countPlayer2 == 0)
            {
                
                MessageBox.Show("YOU WIN");
                win = true;
                this.Close();
                Forms.EndGameScreen c = new Forms.EndGameScreen();
                c.Show();
                return true;
            }
            return false;
        }
    }
}
