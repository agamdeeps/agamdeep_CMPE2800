// Project : Review Lab
// Sept 24 2025
// By Agamdeep Singh
//
// MyLibrary type - class definition - SimState class
// Print Format : Landscape
// ///////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;

namespace ReviewLab
{
    internal class SimState
    {
        // Constants for drawer height and width
        private int drawerHeight = 600;
        private int drawerWidth = 800;

        private Random random = new Random();
        List<Hand> hands = new List<Hand>();                // list for maintaining the active hands
        private CDrawer drawer;
        private int frameCount = 0;

        /*=======================================================================================
        * Function : public SimState(int noHands)
        * Input : The number of hands generated
        * Purpose : populates the list with the required number of hands and creates a gdidrawer instance
        =========================================================================================*/
        public SimState(int noHands)
        { 
            drawer = new CDrawer();
            drawer.ContinuousUpdate = false;

            for(int i = 0; i < noHands; i++)
            {
                hands.Add(new Hand(drawerHeight, drawerWidth));
            }
        }

        /*=======================================================================================
        * Function :  public (int frame, handTypes? winner) Tick()
        * returns : int frame - the number of rounds
        *           handtypes - the handtype of the winner
        * Purpose : Moves the hands, check for overlaps and determines the winner
        =========================================================================================*/
        public (int frame, handTypes? winner) Tick()
        {
            frameCount++;
            drawer.Clear();

            // moving the hands - since it is a struct changes wont be affected in the original collection so need to reassign
            for(int i = 0;i < hands.Count ;i++) 
            { 
                Hand tempHand = hands[i];
                tempHand.Move(drawerHeight, drawerWidth);
                hands[i] = tempHand;
            }

            // Iterating through the collection two times to check for overlaps and updating the hands according to the rounds won
            for (int i = 0; i < hands.Count; i++)
            {
                for(int j = i + 1; j < hands.Count; j++)
                {
                    if (Hand.handOverlap(hands[i], hands[j]))       // if function encounters an overlap
                    {
                        handTypes result = Hand.handLogic(hands[i].GetHand, hands[j].GetHand);      // determining the winner of the round

                        Hand tempHand1 = hands[i];                                  // updating both of the hands accroding to the winner
                        Hand tempHand2 = hands[j];

                        tempHand1.GetHand = result;
                        tempHand2.GetHand = result;

                        hands[i] = tempHand1;
                        hands[j] = tempHand2;
                    }
                }
            }
            // rendering each item of the list on the drawer
            foreach (Hand item in hands)
            {
                item.render(drawer);
            }

            drawer.Render();                // rendering the drawer

            handTypes? winner = winnerCheck();   // checking for winner

            return (frameCount, winner);

        }

        /*=======================================================================================
        * Function :  public handTypes? winnerCheck()
        * returns : handTypes? - the number of rounds
        * Purpose : Moves the hands, check for overlaps and determines the winner
        =========================================================================================*/
        public handTypes? winnerCheck()
        {
            handTypes type = hands[0].GetHand;
            if (hands.All(h => h.GetHand == type))
            {
                return type;
            }
            else
            {
                return null;
            }
        }
    }
}
