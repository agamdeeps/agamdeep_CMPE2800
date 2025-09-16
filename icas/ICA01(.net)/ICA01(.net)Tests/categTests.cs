using Microsoft.VisualStudio.TestTools.UnitTesting;
using ICA01_.net_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA01_.net_.Tests
{
    [TestClass()]
    public class categTests
    {
        [TestMethod()]
        /*
         * Purpose - To check the functionality of the categorize function
         */
        public void CategorizeTest()
        {
            int[] nums = { 6, 2, 4, 4, 5, 6, 7, 6 };                // create a sample array of ints

            Assert.AreEqual(5, nums.Categorize().Count);            // checking if the count is as expected
            Assert.AreEqual(3, nums.Categorize()[6]);               // checking the value of an insstance is as expected according to sample
        }

        [TestMethod()]
        public void PenultimateTest()
        {
            int[] nums = { 6, 2, 4, 4, 5, 6, 7, 6 };                        // sample array of ints
            int[] lessNum = { 6};
            Assert.AreEqual(7, nums.Penultimate());                         // checking that the function actually returns the second last value
            //Assert.AreEqual(6, lessNum.Penultimate());
        }

        [TestMethod()]
        public void RandoTest()
        {
            int[] iNums = { 1, 2, 3, 4 };

            int randNum = iNums.Categorize().Rando().Item1;                     // obtaining the key of the random element selected
            Assert.IsTrue(iNums.Contains(randNum));                             // Testing that initial array actually contains the key obtained
        }

        [TestMethod()]
        public void AdjacentDuplicateTest()
        {
            int[] iemp = { 4, 12, 12, 3, 5, 6, 7, 6, 12 };                      // sample array with an instance of adjacent duplicate
            int checknum = iemp.AdjacentDuplicate();                            // making sure the number returned is as expected
            Assert.AreEqual(12, checknum);
        }

        [TestMethod()]
        public void StringDisplayTest()
        {
            List<string> names = new List<string> { "Rick", "Rick", "Glenn" };      // sample of list of strings
            Tuple<string, int> display = names.StringDisplay();                     // storing the tuple return in a variable

            Assert.AreEqual(3, display.Item2);                                      // the second item returned is the count of elements and verifying that
        }

        public void staticTest()
        {
            CategorizedStack<string> tempStack = new CategorizedStack<string>();
            tempStack.Push("max");
            tempStack.Push("sally");
            tempStack.Push("twenty");
            //tempStack.Push(3);
            //tempStack.Push(5);

            Assert.AreEqual("max" ,tempStack[0]);
            Assert.AreEqual(1, tempStack["max"]);
        }
    }
}