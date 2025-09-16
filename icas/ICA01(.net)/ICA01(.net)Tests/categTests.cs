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
        public void CategorizeTest()
        {
            int[] nums = { 6, 2, 4, 4, 5, 6, 7, 6 };

            Assert.AreEqual(5, nums.Categorize().Count);
            Assert.AreEqual(3, nums.Categorize()[6]);
        }

        [TestMethod()]
        public void PenultimateTest()
        {
            int[] nums = { 6, 2, 4, 4, 5, 6, 7, 6 };
            int[] lessNum = { 6};
            Assert.AreEqual(7, nums.Penultimate());
            //Assert.AreEqual(6, lessNum.Penultimate());
        }

        [TestMethod()]
        public void RandoTest()
        {
            int[] iNums = { 1, 2, 3, 4 };
            int randNum = iNums.Categorize().Rando().Item1; 
            Assert.IsTrue(iNums.Contains(randNum));
        }

        [TestMethod()]
        public void AdjacentDuplicateTest()
        {
            int[] iemp = { 4, 12, 12, 3, 5, 6, 7, 6, 12 };
            int checknum = iemp.AdjacentDuplicate();
            Assert.AreEqual(12, checknum);
        }

        [TestMethod()]
        public void StringDisplayTest()
        {
            List<string> names = new List<string> { "Rick", "Rick", "Glenn" };
            Tuple<string, int> display = names.StringDisplay();

            Assert.AreEqual(3, display.Item2);
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