using System;
using vd.fundamentals.Ratios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace vd.fundamentals.tests
{
    [TestClass]
    public class PSRatioTests
    {
        [TestMethod]
        public void PSRatioTests_With_ZERO_StockPrice()
        {
            var t = p.CaliculatePS(0, 1);
            Assert.AreEqual(t, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void PSRatioTests_With_ZERO_RevenueperShare()
        {
            p.CaliculatePS(1, 0);
        }

        [TestMethod]
        public void PSRatioTests_With_Inputs()
        {
            var stockprice = 60.56;
            var revenuepershare = 22.22;

            var expected = 2.73;
            var t = p.CaliculatePS(stockprice, revenuepershare);

            Assert.AreEqual(expected, Math.Round(t, 2));
        }

        [TestInitialize]
        public void Setup()
        {
            p = new PSRatio();
        }

        private PSRatio p;
    }
}