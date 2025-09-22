// Project : ICA_Generators
// Sept 17 2025
// By Agamdeep Singh
//
// MyLibrary type - class definition - UtilityTests class
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
    public class UtilityTests
    {
        [TestMethod()]
        /*=======================================================================================
        * Function : public void ShuffleTest()
        * Purpose : Does a statistical test to check each number in a collection is distributed equally
        =========================================================================================*/
        public void ShuffleTest()
        {
            List<int> listnums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };              // source collection to be tested

            Dictionary<int, int> positions = new Dictionary<int, int> { { 0, 0 }, { 1, 0 }, { 2, 0 }, { 3, 0 }, { 4, 0 }, { 5, 0 }, { 6, 0 }, { 7, 0 } };       // dictionary to store the statistical data

            for (int i = 0; i < 10000000; i++)                      // shuffling an iteration million times and tracking location of an element
            {
                listnums.OrderBy(x => x);
                listnums = listnums.Shuffle().ToList();
                positions[listnums.IndexOf(1)]++;
            }

            Console.WriteLine();
            Console.WriteLine("Positions --");
            List<int> checkList = new List<int>();
            foreach (var item in positions)                                                         // displaying data as percentages 
            {
                checkList.Add((int)((double)item.Value / 10000000) * 100);
                Console.WriteLine($"{item.Key} : {((double)item.Value / 10000000) * 100}");
            }

            Assert.AreEqual(checkList[0], checkList[5]);                    // checking that the positional probabilites are equal
        }

        [TestMethod()]
        /*=======================================================================================
        * Function : public void PeelTest()
        * Purpose : Checks that peel on odd and even numbered list returns the proper count and has required elemeents 
        =========================================================================================*/
        public void PeelTest()
        {
            List<int> listnum = new List<int> { 1, 2, 3, 4, 5 };            // odd numbered test list
            List<int> listnum2 = new List<int> { 1, 2, 3, 4 };              // even numbered test list
            List<int> listnum3 = new List<int> { 1, 2, 3, 4 };

            Assert.AreEqual(3, listnum.Peel().Count());                     // making sure count is equal
            Assert.AreEqual(2, listnum2.Peel().Count());

            List<int> temp1 = new List<int> { 1, 4};
            List<int> temp2 = new List<int> { 2, 3 };

            List<List<int>> peeledList = listnum3.Peel().ToList();

            CollectionAssert.AreEqual(temp1, peeledList[0]);                // checking that peel returns the expected elements
            CollectionAssert.AreEqual(temp2, peeledList[1]);
        }

        [TestMethod()]
        /*=======================================================================================
        * Function : public void PeelEmptyListTest()
        * Purpose : Checks that peel when tried on empty list returns an empty list
        =========================================================================================*/
        public void PeelEmptyListTest()
        {
            List<int> tempList = new List<int> { };
            List<List<int>> peeledList = tempList.Peel().ToList();
            Assert.AreEqual(1, peeledList.Count());      
            Assert.AreEqual(0, peeledList[0].Count);
        }

        [TestMethod()]
        /*=======================================================================================
        * Function :  public void SampleTest()
        * Purpose : Takes the first certain number of elements and verifies that they are present in the source list
        =========================================================================================*/
        public void SampleTest()
        {
            List<int> list = new List<int> { 10, 20, 30, 40, 50 };
            List<int> tempList = list.Sample().Take(50).ToList();

            foreach (int item in tempList)
            {
                Assert.IsTrue(list.Contains(item));    
            }
        }
    }
}