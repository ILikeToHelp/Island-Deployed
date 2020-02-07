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

        int computerGold = 1000;

        List<Coordinates> player1Soldiers = new List<Coordinates>();                     // lists needed for computer turns (decision on whom to shoot)
        List<Coordinates> computerSoldiers = new List<Coordinates>();                              

        int numberOfMercenaries = Shop.numberOfMercenaries;
        int numberOfInfantry = Shop.numberOfInfantry;
        int numberOfSnipers = Shop.numberOfSnipers;

        bool canContinue = true;


        Classes.Soldier temporary = new Classes.Soldier();                              // temporary object to reduce memory access (alternative includes nested for loop)

        bool[,] allowedMoves = new bool[width, height];                                 // mimics set up of the battlefield and tracks accessible tiles during "movement"

        Label[,] labelArray = new Label[width, height];                                 // used for displaying "health bars"

        PictureBox[,] pictureArray = new PictureBox[width, height];                     // visual representation of the battle field

        Classes.Soldier[,] arrayOfSoldiers =                                            // allows object manipulation, in a convenient way
                           new Classes.Soldier[width, height];                           


        string finiteStateMachine = "initialization";                                    
        string whoIsBeingDeployed = "none";
        public struct Coordinates
        {
            public int x, y;
            public Coordinates(int p1, int p2)
            {
                x = p1;
                y = p2;
            }

        }

        //-----------------END OF VARIABLE DECLARATION-----------------------------\\


        public BattleField()
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
        private void BattleField_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Deploy your units by clicking at the picture and then at a desired spot");
            ResetAllValues();
            CreateField();
            ComputerDeployment();
            finiteStateMachine = "deployment";
            UpdateLabels();
            deploymentPanel.Visible = true;
            deploymentPanel.BringToFront();

        }
        private void CreateField()                                                        // sets up the "battle field" (width x height picture boxes)
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
        private void Skip_Click(object sender, EventArgs e)
        {
            // short method for skipping turn
            CleanBoard();
            ActionPanel.Visible = false;
            finiteStateMachine = "computersTurn";
            HierarchyOfComputerMoves();
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            LogOfMoves.SelectionStart = LogOfMoves.Text.Length;
            LogOfMoves.ScrollToCaret();

            PictureBox picture = (PictureBox)sender;

            Coordinates coordinates = new Coordinates();
            coordinates = FindPicture(picture);

            int x = coordinates.x; int y = coordinates.y;                                 // saving coordinates of the picture to two integers for ease of use

            if (finiteStateMachine == "placement")
            {
                if (y < 3)
                {
                    PlaceUnit(picture, FindPicture(picture));
                }
                else
                {
                    MessageBox.Show("You can only place units within bottom 3 rows");
                }
                
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
                LogOfMoves.Text += "You are now moving. Boring.\n";
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
                LogOfMoves.Text += "You are now shooting. That's exciting!\n";
                Shooting(x, y);
            }

        }                    // game flow determined by states of FSM


        //----------------------Deployment methods below-----------------------------\\
        private void ComputerDeployment()                                                // randomly allocates computer's units
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
                    deployed = true;
                    computerGold -= 400;
                }


                else if (arrayOfSoldiers[v, g] == null && computerGold >= 200 && g == height)
                {
                    arrayOfSoldiers[v, g] = new Classes.Soldier(v, g, 3, 50, 33, 70, "Infantry", 200, 200, false);
                    pictureArray[v, g].Image = Properties.Resources.I2;
                    deployed = true;
                    computerGold -= 200;
                }

                else if (arrayOfSoldiers[v, g] == null && computerGold >= 150)
                {
                    arrayOfSoldiers[v, g] = new Classes.Soldier(v, g, 4, 60, 20, 60, "Mercenarie", 100, 100, false);
                    pictureArray[v, g].Image = Properties.Resources.M2;
                    deployed = true;
                    computerGold -= 150;

                }
                if (deployed)
                {
                    Coordinates coordinates = new Coordinates();
                    coordinates.x = v; coordinates.y = g;
                    computerSoldiers.Add(coordinates);
                    SetHealthBar(v, g);
                }

            }

        }

        private void DeployMercenarie_Click(object sender, EventArgs e)                  // three methods for deploying the correct unit
        {
            if (numberOfMercenaries > 0)
            {
                deploymentPanel.Visible = false;
                finiteStateMachine = "placement";
                whoIsBeingDeployed = "mercenarie";
                numberOfMercenaries -= 1;
                UpdateLabels();
            }
        }
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
        }                // cd
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
        }                  // cd

        private void PlaceUnit(PictureBox p, Coordinates a)                              // method responsible for placing units onto the field
        {
            if (whoIsBeingDeployed == "mercenarie")
            {
                p.Image = Properties.Resources.M;
                arrayOfSoldiers[a.x, a.y] = new Classes.Soldier(a.x, a.y, 4, 80, 20, 50, "Mercenarie", 100, 100, true);
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

                MessageBox.Show("Click your unit to open action panel. \nChoose to either shoot, move(and stab) or to skip turn. \nGood luck!");
                CleanBoard();
            }
            else
            {
                finiteStateMachine = "deployment";
                deploymentPanel.Visible = true;
            }

            Coordinates coordinates = new Coordinates();
            coordinates = a;
            player1Soldiers.Add(coordinates);


        }

        //-----------------------Deployment methods above---------------------------\\



        //--------------------------MY AI BELOW--------------------------------------\\
        private void HierarchyOfComputerMoves()                                         // prioritizes Snipers - they deal most damage and have highest accuracy. 

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
                        LogOfMoves.Text += "\nEnemy Sniper shoots...";
                        ComputerShoots(x, y);
                        computerMoved = true;
                        break;
                    }
                    else if (who == "Mercenarie")
                    {
                        temporary = arrayOfSoldiers[x, y];
                        LogOfMoves.Text += "\nEnemy Mercenarie is checking if he can reach you...";
                        finiteStateMachine = "computerMelee";
                        MovesAllowed();
                        CleanBoard();
                        computerMoved = true;
                        break;

                    }
                    else if (who == "Infantry")
                    {
                        LogOfMoves.Text += "\nEnemy Infantry shoots...";
                        ComputerShoots(x, y);
                        computerMoved = true;
                        break;
                    }
                }
                break;
            }
            // finnaly check if user has any units left#
            DidILose();


        }                                      // prioritizes Snipers - they deal most damage and have highest accuracy. 

        private void ComputerShoots(int xCP, int yCP)
        {
            // when computer shoots it randomly chooses target, from the list of players alive units

            Random random = new Random();
            int w = random.Next(player1Soldiers.Count);

            //users coordinates
            int y = player1Soldiers.ElementAt(w).y;
            int x = player1Soldiers.ElementAt(w).x;

            if (arrayOfSoldiers[xCP, yCP].dealDamage())                                      // Has computer missed or scored a hit ?
            {

                arrayOfSoldiers[x, y].TakeDamage(arrayOfSoldiers[xCP, yCP].RangeDamage);     // If so, damage user's unit.
                LogOfMoves.Text += " and hits! You received: " + arrayOfSoldiers[xCP, yCP].RangeDamage.ToString() + " damage.\n";
                if (IsUnitDead(x, y))
                {
                    pictureArray[x, y].BackgroundImage = Properties.Resources.dead;
                }

                CleanBoard();

            }
            else
            {
                LogOfMoves.Text += " and misses. Uff, that was close. \n";
            }

        }

        private void ChargeAtUser(int x, int y)
        {
            arrayOfSoldiers[x, y].Health -= temporary.MeleeDamage;
            LogOfMoves.Text += "and he does! Your unit lost " + temporary.MeleeDamage.ToString() + " hp.";
            IsUnitDead(x,y);
            
        }
        private bool IsUnitDead(int x, int y)
        {
            // if unit got killed, remove it from the list of objects and decreas count of user's units.

            if (arrayOfSoldiers[x, y].Health == 0)
            {

                arrayOfSoldiers[x, y] = null;
                pictureArray[x, y].BackgroundImage = Properties.Resources.dead;
                LogOfMoves.Text += " In the result, unit has perished. At least they have a grave stone.\n";

                if (finiteStateMachine == "computersTurn" || finiteStateMachine == "computerMelee")
                {
                    for (int m = 0; m < player1Soldiers.Count; m++)
                    {
                        if (player1Soldiers.ElementAt(m).x == x && player1Soldiers.ElementAt(m).y == y)
                        {
                            canContinue = false;
                            player1Soldiers.RemoveAt(m);
                            Classes.Soldier.countPlayer1 -= 1;
                            LogOfMoves.Text += "\n You have only  :" + Classes.Soldier.countPlayer1.ToString() + " unit/s alive!";
                            finiteStateMachine = "usersTurn";
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
                            LogOfMoves.Text += "\nYou only have to kill: " + Classes.Soldier.countPlayer2.ToString()+"  more unit/s to win!";
                            break;
                        }
                    }
                }

                return true;
            }
            return false;
        }
        //------------------------MY AI ABOVE---------------------------------\\

       
        

        //---------------------------Move methods below--------------------------\\
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

            int i = 0;

            do
            {
                i++;
                // validation to prevent "out of boundrier" error
                if (temporary.getXCoords() + i < width && canContinue)
                {

                    MovementVisuals(i, 0);                                   // right

                    if (temporary.getYCoords() + i < height && canContinue)
                    {
                        MovementVisuals(i, i);                              // diagno right up
                    }

                    if (temporary.getYCoords() - i >= 0 && canContinue)
                    {
                        MovementVisuals(i, -i);                              // diagno right down
                    }
                }


                if (temporary.getXCoords() - i >= 0& canContinue)
                {

                    MovementVisuals(-i, 0);                                 // left

                    if (temporary.getYCoords() - i >= 0 && canContinue)                    // left diagno down
                    {
                        MovementVisuals(-i, -i);
                    }

                    if (temporary.getYCoords() + i < height && canContinue)                // left diagno up
                    {
                        MovementVisuals(-i, i);
                    }

                }

                if (temporary.getYCoords() + i < height&& canContinue)
                {
                    MovementVisuals(0, i);                                 // up
                }

                if (temporary.getYCoords() - i >= 0 && canContinue)
                {
                    MovementVisuals(0, -i);                               // down
                }

            } while (canContinue && i != speed);
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
                if (finiteStateMachine == "computerMelee")
                {
                    canContinue = true;
                }
                else if (arrayOfSoldiers[x, y].Type == "Sniper")
                {
                    pictureArray[x, y].Image = Properties.Resources.S2Red;
                    canContinue = false;
                }
                else if (arrayOfSoldiers[x, y].Type == "Mercenarie")
                {
                    pictureArray[x, y].Image = Properties.Resources.M2Red;
                    canContinue = false;
                }
                else
                {
                    pictureArray[x, y].Image = Properties.Resources.I2Red;
                    canContinue = false;
                }

                               // if soldier encounters an enemy then he must not be able to continue past them
            }
            else if (finiteStateMachine == "computerMelee")
            {
                if (arrayOfSoldiers[x,y+1] == null)
                {
                    ChangePosition(x, y + 1);
                    canContinue = false;
                }

                ChargeAtUser(x, y);
                finiteStateMachine = "usersTurn";
            }

        }
        private void ChangePosition(int x, int y)
        {
            // swaps location of object which moves; i, j is the old position, x and y is the target position.

            int i = temporary.getXCoords();
            int j = temporary.getYCoords();

            Coordinates coOrds = new Coordinates();
            coOrds.x = x;
            coOrds.y = y;

            if (finiteStateMachine == "computerMelee")
            {
                for (int m = 0; m < computerSoldiers.Count; m++)
                {
                    if (computerSoldiers.ElementAt(m).x == i && computerSoldiers.ElementAt(m).y == j)
                    {
                        computerSoldiers.RemoveAt(m);
                        break;
                    }
                }
                computerSoldiers.Add(coOrds);
            }

            else
            {
                for (int m = 0; m < player1Soldiers.Count; m++)
                {
                    if (player1Soldiers.ElementAt(m).x == i && player1Soldiers.ElementAt(m).y == j)
                    {
                        player1Soldiers.RemoveAt(m);
                        break;
                    }
                }
                player1Soldiers.Add(coOrds);
                finiteStateMachine = "computersTurn";
            }

            arrayOfSoldiers[i,j] = null;    
            temporary.setXCoords(x); temporary.setYCoords(y);                          // object location <= new co-ords
            arrayOfSoldiers[x, y] = temporary;                                         // update array
            CleanBoard();

            if (finiteStateMachine == "computersTurn")
            {
                HierarchyOfComputerMoves();
            }
            else if (finiteStateMachine == "computerMelee")
            {
                finiteStateMachine = "usersTurn";
            }
            

        }
        private void Melee(int x, int y)
        {
            // moving on to a tile taken by computers unit causes a fight

            arrayOfSoldiers[x, y].Health -= temporary.MeleeDamage;
            LogOfMoves.Text += "You sticked them with the pointy end for: " + temporary.MeleeDamage.ToString();
            if (IsUnitDead(x, y))
            {
                LogOfMoves.Text += "\nand therfore they can't live anymore.\n";
            }

            ChangePosition(x, y);
            DidIWin();
            CleanBoard();
            finiteStateMachine = "computersTurn";                               //computers turn
            HierarchyOfComputerMoves();

        }

        //-----------------------End of user movement methods-----------------------\\




        //------------------------User fire power methods below-------------------------\\
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
                LogOfMoves.Text += "\nThe bullet takes off " + temporary.RangeDamage.ToString()+ " of his hp!";
                if (IsUnitDead(x, y))
                {
                    labelArray[x, y].Visible = false;
                    pictureArray[x, y].BackgroundImage = Properties.Resources.dead;
                    DidIWin();
                    
                }

                    CleanBoard();
                    finiteStateMachine = "computersTurn";
                    HierarchyOfComputerMoves();
                

            }
        }

        //----------------------------End of fire power methods-------------------------\\


        private Coordinates FindPicture(PictureBox p)
        {
            // nested 'for' loop to find which button was clicked

            Coordinates a = new Coordinates();

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
        private void DidILose()
        {
            if (player1Soldiers.Count == 0)
            {

                MessageBox.Show("YOU LOSE");
                this.Close();
                Forms.EndGameScreen c = new Forms.EndGameScreen();
                c.Show();
            }
            else
            {
                LogOfMoves.Text += "\nYour turn\n";
                finiteStateMachine = "playersTurn";
            }
        }
        //---------------------------Visual methods below-------------------------------\\
        private void UpdateLabels()
        {
            // short method to update labels on the deployment panel

            infantryLeft.Text = numberOfInfantry.ToString();
            mercenariesLeft.Text = numberOfMercenaries.ToString();
            snipersLeft.Text = numberOfSnipers.ToString();
        }
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

        //------------------Visual methods above--------------------\\

    }
}
