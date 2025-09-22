// Project : ICA_Generators
// Sept 17 2025
// By Agamdeep Singh
//
// MyLibrary type - class definition - KnightPosTests class
// Print Format : Landscape
// ///////////////////////////////////////////////////////////////////////////
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ICA02;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA02.Tests
{
    [TestClass()]
    public class KnightPosTests
    {
        /*=======================================================================================
        * Function :  public void KnightPosTest()
        * Purpose : Checks that when class instance is created, the knight position is valid
        =========================================================================================*/
        [TestMethod()]
        public void KnightPosTest()
        {
            KnightPos sample = new KnightPos(5,6);
            Assert.AreEqual((5,6), sample.getPos);                  // comparing the positions set in class
        }

        /*=======================================================================================
        * Function :public void knightPos_Lowpositiontest()
        * Purpose : Checks that when class is created with knight position out of bounds, it throws exception
        =========================================================================================*/
        [TestMethod()]
        public void knightPos_Lowpositiontest()
        {
            Assert.ThrowsException<ArgumentException>(() => new KnightPos(-1, 0));
        }
        /*=======================================================================================
        * Function : public void knightPos_Highpositiontest()
        * Purpose : Checks that when class is created with knight position greater than bounds, it throws exception
        =========================================================================================*/
        [TestMethod()]
        public void knightPos_Highpositiontest()
        {
            Assert.ThrowsException<ArgumentException>(() => new KnightPos(9, 4));
        }

        /*=======================================================================================
        * Function : public void knightPos_Highpositiontest()
        * Purpose : Checks that when knight is placed in corner ite returns only limited moves
        =========================================================================================*/
        [TestMethod()]
        public void knightPos_Cornertest()
        {
            KnightPos sample = new KnightPos(0, 7);
            Assert.AreEqual((5, 6), sample.getPos);                  // comparing the positions set in class
        }

        /*=======================================================================================
        * Function :   public void moveKnightTest()
        * Purpose : Checks that when a valid move is assigned to move knight, the method approves 
        =========================================================================================*/
        [TestMethod()]
        public void moveKnightTest()
        {
            KnightPos sample1 = new KnightPos(1, 0);
            sample1.moveKnight(2, 2);                               // assigning new position
            Assert.AreEqual((2,2), sample1.getPos);                 // validating the updated position
        }

        /*=======================================================================================
        * Function :  public void InvalidmoveTest()
        * Purpose : Checks that when an invalid move is assigned to move knight, the method does not update the value 
        =========================================================================================*/
        [TestMethod()]
        public void InvalidmoveTest()
        {
            KnightPos sample2 = new KnightPos(1, 0);
            Assert.ThrowsException<ArgumentException>(() => sample2.moveKnight(3,2));
        }
        /*=======================================================================================
        * Function : public void outOfBoundsMove()
        * Purpose : Checks that when an out of bounds move is tried to move knight, the method does not update the value 
        =========================================================================================*/
        [TestMethod()]
        public void outOfBoundsMove()
        {
            KnightPos sample2 = new KnightPos(0, 0);
            Assert.ThrowsException<ArgumentException>(() => sample2.moveKnight(-3, 2));
        }

        /*=======================================================================================
        * Function : public void GetEnumeratorTest()
        * Purpose : Checks that enumeration displays moves that are valid with the current position
        =========================================================================================*/
        [TestMethod()]
        public void GetEnumeratorTest()
        {
            KnightPos sample = new KnightPos(3,3);          
            List<(int, int)> tempList = new List<(int, int)> ();          // templist to store the enumeration values by the class

            foreach ((int,int) item in sample)                                      // iterating through the collection
            {
                tempList.Add(item);
            }

            List<(int, int)> expected = new List<(int, int)>                    // creating an expected list of outcomes
            {
                (1,2), (1,4), (2,1), (2,5),
                (4,1), (4,5), (5,2), (5,4)
            };

            CollectionAssert.AreEquivalent(expected, tempList);      // making sure the expected matches the generated list
        }
    }
}