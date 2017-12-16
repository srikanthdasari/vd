using System;
using vd.fundamentals.Ratios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace vd.fundamentals.tests
{
    [TestClass]
    public class PERatioTests
    {
        [TestMethod]
        public void PERatioTests_With_Zero_Stockprice()
        {
            var t = p.CaliculatePE(0, 1);
            Assert.AreEqual(t, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void PERatioTests_With_Zero_EPS()
        {
            p.CaliculatePE(1, 0);
        }

        [TestMethod]
        public void PERatioTests_With_Inputs()
        {
            var expected = 23.81;
            var t = p.CaliculatePE(60.49, 2.54);
            Assert.AreEqual(expected, Math.Round(t,2));
        }


        [TestInitialize]
        public void Setup()
        {
            p = new PERatio();
        }

        private PERatio p;
    }
}