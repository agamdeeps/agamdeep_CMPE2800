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
            foreach (var item in positions)
            {
                Console.WriteLine($"{item.Key} : {((double)item.Value / 10000000) * 100}");
            }
        }

        [TestMethod()]
        public void PeelTest()
        {
            List<int> listnum = new List<int> { 1, 2, 3, 4, 5 };
            List<int> listnum2 = new List<int> { 1, 2, 3, 4 };
            List<int> listnum3 = new List<int> { 1, 2, 3, 4 };

            Assert.AreEqual(3, listnum.Peel().Count());
            Assert.AreEqual(2, listnum2.Peel().Count());

            List<int> temp = new List<int> { 1, 4};
            CollectionAssert.AreEqual(temp, listnum3.Peel().First());
        }

        [TestMethod()]
        public void SampleTest()
        {
        }
    }
}