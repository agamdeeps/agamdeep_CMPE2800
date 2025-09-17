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
            List<int> listnum = new List<int> { 1, 2, 3, 4, 5 };
            Assert.AreEqual(5, listnum.Shuffle().Count());
            Assert.AreNotEqual(listnum, listnum.Shuffle());
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