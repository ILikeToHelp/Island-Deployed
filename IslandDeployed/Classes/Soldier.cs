using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandDeployed.Classes
{
    class Soldier
    {
        // first, define all data types of which a soldier is built.


        public struct Position
        {
            public int x, y;
            public Position(int p1, int p2)
            {
                x = p1;
                y = p2;
            }

        }
        Position position;


        private int speed;
        private int meleeDamage;
        private int rangeDamage;
        private string type;
        private double health;
        private readonly int totalHealth;
        private readonly int accuracy;
        private bool player1Owned;
        public static int countPlayer1;
        public static int countPlayer2;


        // then it's time for getters and setters
        public int Speed
        { 
            get { return speed; }
            set { speed = value; }
        }
        public int MeleeDamage 
        {
            get { return meleeDamage; }
            set { meleeDamage = value; }
        }
        public int RangeDamage
        { 
            get { return rangeDamage; }
            set { rangeDamage = value; }

        }
        public string Type
        { get { return type; }
            set { type = value; }
        }
        public double Health
        {
            get { return health; }
            set
            {
                if (value > 200)
                {
                    health = 200;
                }
                else if (value < 0)
                {
                    health = 0;
                }
                else
                {
                    health = value;
                }
            }
        }
        public double GetHealthBar()
        {
            // reutrns how many bars of health (one bar = 10% ) to display on 
            double bar;
            bar = 10 * health / totalHealth;
            Math.Round(bar);
            return bar;
        }
        public bool dealDamage()
        {
            bool output = false;
            Random rnd = new Random();
            int v = 0;
            v = rnd.Next(1, 101);

            if (v <= accuracy)  //if unit hits then output =true
            {
                output = true;
            }
            else
            {                   //if unit misses return false
                output = false;
            }

            return output;
        }
        public bool Player1Owned
        { get { return player1Owned; }
            set { player1Owned = value; }
        }

        public void setXCoords(int x)
        {
            position.x = x;
        }
        public void setYCoords(int y)
        {
            position.y = y;
        }
        public int getXCoords()
        {
            return position.x;
        }
        public int getYCoords()
        {
            return position.y;
        }

        // then, define constructor; using 'a' as a prefix and abreviation for argument
        public Soldier(int aX, int aY, int aSpeed, int aMeleeDamage, int aRangeDamage,
            int aAccuracy, string aType, double aHealth, int aTotalHealth, bool aPlayer1Owned)
        { 
            position.x = aX; position.y = aY;
            accuracy = aAccuracy;
            Speed = aSpeed;
            MeleeDamage = aMeleeDamage;
            RangeDamage = aRangeDamage;
            Type = aType;
            Health = aHealth;
            totalHealth = aTotalHealth;
            Player1Owned = aPlayer1Owned;

            if (player1Owned)   // if the unit is owned by player one 
            {
                countPlayer1++; // then add one to his count
            }
            else
            {
                countPlayer2++; //if it's player2, update his count
            }
        }
        public Soldier()
        { }
        // methods defined below 
        // ------------------------------------ Note to self - method is a function defined within a class - since c# is oop lang then all functions are methods


        // TakeDamage works for both melee and ranged attacks.
        public double TakeDamage(double damage)
        {

            Health -= damage;
            return Health;
        }



    }
}
