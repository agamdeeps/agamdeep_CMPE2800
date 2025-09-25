using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace ReviewLab
{
    public enum handTypes { Rock, Paper, Scissors };                // Enum for storing the different hand types

    public struct Hand
    {
        private const int radius = 20;                  
        private const float minSpeed = 0.5f;
        private const float maxSpeed = 2.0f;

        private PointF handPosition;
        private handTypes type;
        public handTypes GetHand                // Property to get the handtype of particular hand
        { 
            get { return type; }
            set { type = value; }
        }
        private PointF speed;                   // field for storing the speed of the hand  

        private static Random _rnd = new Random();

        /*=======================================================================================
        * Function :  public Hand(int drawerHeight, int drawerWidth) 
        * returns : handTypes? - the number of rounds
        * Purpose : Constructor to set the fields such as type, speed and position
        =========================================================================================*/
        public Hand(int drawerHeight, int drawerWidth) 
        { 
            type = (handTypes)_rnd.Next(3);
            handPosition = new PointF(_rnd.Next(radius, drawerWidth - radius), _rnd.Next(radius, drawerHeight - radius));

            float speedX = (float)(_rnd.NextDouble() * (maxSpeed - minSpeed) + minSpeed);
            float speedY = (float)(_rnd.NextDouble() * (maxSpeed - minSpeed) + minSpeed);

            if (_rnd.Next(2) == 0) speedX = -speedX;
            if (_rnd.Next(2) == 0) speedY = -speedY;

            speed = new PointF(speedX, speedY);
        }

        /*=======================================================================================
        * Function : public static bool handOverlap(Hand left, Hand right)
        * returns : bool which is if the hands overlap or not
        * Purpose : Checks for hand overlap and returns it
        =========================================================================================*/
        public static bool handOverlap(Hand left, Hand right)
        {
            double dist = Math.Sqrt(Math.Pow(left.handPosition.X - right.handPosition.X, 2)
                                    + Math.Pow(left.handPosition.Y - right.handPosition.Y, 2));

            return dist < radius * 2;
        }

        /*=======================================================================================
        * Function : public static handTypes handLogic(handTypes left, handTypes right)
        * returns : hand type - which is the winner from the current round
        * Purpose : Compares two hands for the winner and returns it
        =========================================================================================*/
        public static handTypes handLogic(handTypes left, handTypes right)
        {
            if(left == right)
            {
                return left;
            }
            else
            {
                if(left == handTypes.Rock && right == handTypes.Scissors || left == handTypes.Scissors && right == handTypes.Rock) 
                { 
                    return handTypes.Rock;
                }
                else if(left == handTypes.Scissors && right == handTypes.Paper || left == handTypes.Paper && right == handTypes.Scissors)
                {
                    return handTypes.Scissors;
                }
                else
                {
                    return handTypes.Paper;
                }
            }
        }

        /*=======================================================================================
        * Function :  public void Move(int drawerHeight, int drawerWidth)
        * Purpose : Moves the hands based on the drawer constraints
        =========================================================================================*/
        public void Move(int drawerHeight, int drawerWidth)
        {
            handPosition = new PointF(handPosition.X + speed.X, handPosition.Y + speed.Y);  // updating the position

            if(handPosition.X < radius || handPosition.X > drawerWidth - radius)            // comparing the x coordinate with drawer constraints
            {
                if(handPosition.X < radius)
                {
                    handPosition = new PointF(radius, handPosition.Y);
                }
                else
                {
                    handPosition = new PointF(drawerWidth - radius, handPosition.Y);
                }
                speed = new PointF(-speed.X, speed.Y);
            }
            if (handPosition.Y < radius || handPosition.Y > drawerHeight - radius)          // comparing the y coordinate with drawer constraints
            {
                if (handPosition.Y < radius)
                {
                    handPosition = new PointF(handPosition.X, radius);
                }
                else
                {
                    handPosition = new PointF(handPosition.X,drawerHeight - radius);
                }
                speed = new PointF(speed.X, -speed.Y);
            }
        }

        /*=======================================================================================
       * Function : public void render(GDIDrawer.CDrawer drawer)
       * Purpose : Renders the hand ellipse and text of hand on the drawer
       =========================================================================================*/
        public void render(GDIDrawer.CDrawer drawer)
        {
            Color hColor = Color.White;
            string htext = "";

            if(type == handTypes.Rock)
            {
                hColor = Color.Red;
                htext = "R";
            }
            else if(type == handTypes.Scissors)
            {
                hColor = Color.Blue;
                htext = "S";
            }
            else
            {
                hColor= Color.Green;
                htext= "P";
            }

            drawer.AddCenteredEllipse((int)handPosition.X, (int)handPosition.Y, 2 * radius,2 * radius, hColor);

            drawer.AddText(htext, 18,(int)handPosition.X - radius, (int)handPosition.Y - radius, radius * 2, radius * 2,Color.Yellow);
        }
    }
}
