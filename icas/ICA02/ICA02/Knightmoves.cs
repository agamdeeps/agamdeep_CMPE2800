// Project : ICA_Generators
// Sept 17 2025
// By Agamdeep Singh
//
// MyLibrary type - class definition - Knightmove class
// Print Format : Landscape
// ///////////////////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA02
{
    public class KnightPos : IEnumerable
    {
        (int, int) currPos;                         // field to indicate the current position of knight

        public (int,int) getPos                     // Property to access the current position of knight
        {
            get
            {
                return currPos;
            }
            set
            {
                currPos = value;
            }
        }

        /*=======================================================================================
        * Function :  public KnightPos()
        * Purpose : Constrcutor that sets the initial position of the knight
        =========================================================================================*/
        public KnightPos(int x, int y) 
        {
            if (x < 0 || y < 0 || x > 7 || y > 7)                                                               // Checking if the values are out of the bounds of board
            {
                throw new ArgumentException("Cannot Update the position.Specified positions are out of board");
            }
            else
            {
                getPos = new(x, y);
            }
        }

        /*=======================================================================================
        * Function : public void moveKnight(int x, int y)
        * Purpose : Accepts a pair of coordinates and evaluates if it is a valid move
        * Argument -  x and y coordinates
        =========================================================================================*/
        public void moveKnight(int x, int y)
        {
            if(x < 0 || y < 0 || x > 7 || y > 7)                                                               // Checking if the values are out of the bounds of board
            {
               throw new ArgumentException("Cannot Update the position.Specified positions are out of board");
            }

            if (validMove(x, y))       // checking if the values confirm with a possible knight move
            {
                // Updating the current position if found valid
                getPos = (x, y);
            }
            else
            {
                throw new ArgumentException("Cannot Update the position.Specified position is not valid for knight");
            }
        }

        /*=======================================================================================
        * Function :  public IEnumerator GetEnumerator() 
        * Purpose : Provides possible kngiht moves
        =========================================================================================*/
        public IEnumerator GetEnumerator() 
        { 
            for(int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if(validMove(i, j))
                    {
                        yield return (i, j);
                    }
                }
            }
        }

        /*=======================================================================================
        * Function :  public bool validMove(int x, int y)
        * Purpose : Helper Function takes a pair of coordinates and evaluates if it is a valid move
        * Argument -  x and y coordinates
        =========================================================================================*/
        public bool validMove(int x, int y)
        {
            return Math.Abs(currPos.Item1 - x) == 2 && Math.Abs(currPos.Item2 - y) == 1 || Math.Abs(currPos.Item1 - x) == 1 && Math.Abs(currPos.Item2 - y) == 2;   // checking if move done by user is valid       
        }
    }
}
