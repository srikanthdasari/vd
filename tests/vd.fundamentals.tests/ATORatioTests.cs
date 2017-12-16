using System;
using vd.fundamentals.Ratios;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace vd.fundamentals.tests
{
    [TestClass]
    public class ATORatioTests
    {
      
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void ATORatioTest_With_Zero_TotalAssets()
        {
            var t = a.CaliculateATORatio(1, 0);
        }

        [TestMethod]
        public void ATORatioTest_With_Zero_Revenue()
        {
            var t = a.CaliculateATORatio(0, 1);
            Assert.AreEqual(t, 0);
        }

        [TestMethod]
        public void ATORatioTest_With_Inputs()
        {
            var revenue = 2.00;
            var totalassets = 2.00;
            var t = a.CaliculateATORatio(revenue, totalassets);
            Assert.AreEqual(Math.Round(t, 2),1.00);
        }

        [TestInitialize]
        public void Setup()
        {
            a = new ATORatio();
        }

        ATORatio a;
    }
}
