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
        public void ShuffleTest()
        {
            List<int> listnums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };

            Dictionary<int, int> positions = new Dictionary<int, int> { { 0, 0 }, { 1, 0 }, { 2, 0 }, { 3, 0 }, { 4, 0 }, { 5, 0 }, { 6, 0 }, { 7, 0 } };

            for (int i = 0; i < 10000000; i++)
            {
                listnums.Order();
                listnums = listnums.Shuffle().ToList();
                positions[listnums.IndexOf(1)]++;
            }

            Console.WriteLine();
            Console.WriteLine("Positions --");
            List<int> checkList = new List<int>();
            foreach (var item in positions)
            {
                checkList.Add((int)((double)item.Value / 10000000) * 100);
                Console.WriteLine($"{item.Key} : {((double)item.Value / 10000000) * 100}");
            }

            Assert.AreEqual(checkList[0], checkList[5]);
        }

        [TestMethod()]
        public void PeelTest()
        {
            List<int> listnum = new List<int> { 1, 2, 3, 4, 5 };
            List<int> listnum2 = new List<int> { 1, 2, 3, 4 };
            List<int> listnum3 = new List<int> { 1, 2, 3, 4 };

            Assert.AreEqual(3, listnum.Peel().Count());
            Assert.AreEqual(2, listnum2.Peel().Count());

            List<int> temp1 = new List<int> { 1, 4};
            List<int> temp2 = new List<int> { 2, 3 };

            List<List<int>> peeledList = listnum3.Peel().ToList();

            CollectionAssert.AreEqual(temp1, peeledList[0]);
            CollectionAssert.AreEqual(temp2, peeledList[1]);
        }

        [TestMethod()]
        public void PeelEmptyListTest()
        {
            List<int> tempList = new List<int> { };
            List<List<int>> peeledList = tempList.Peel().ToList();
            Assert.AreEqual(1, peeledList.Count());       // contains an empty list
            Assert.AreEqual(0, peeledList[0].Count);
        }

        [TestMethod()]
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