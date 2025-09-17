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
        [TestMethod()]
        public void KnightPosTest()
        {
            KnightPos sample = new KnightPos(1, 0);
            Assert.AreEqual((1,0), sample.getPos);
        }

        [TestMethod()]
        public void moveKnightTest()
        {
            KnightPos sample = new KnightPos(1, 0);
            sample.moveKnight(2, 2);
            Assert.AreEqual((2,2), sample.getPos);
        }

        [TestMethod()]
        public void GetEnumeratorTest()
        {
        }
    }
}