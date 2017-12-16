using System;
using vd.fundamentals.Ratios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace vd.fundamentals.tests
{
    [TestClass]
    public class PBVRatioTests
    {
        [TestMethod]
        public void PBVRatioTests_With_Zero_StockPrice()
        {
            var t = p.CaliculatePBV(0, 1);
            Assert.AreEqual(t, 0);
        }

        [TestMethod]
        [ExpectedException(typeof( DivideByZeroException))]
        public void PBVRatioTests_With_Zero_Bookvaluepershare()
        {
            p.CaliculatePBV(1, 0);            
        }

        [TestMethod]
        public void PBVRatioTests_With_Inputs()
        {
            var stockprice = 60.56;
            var bookvaluepershare = 17.64;

            var expected = 3.43;
            var t = p.CaliculatePBV(stockprice, bookvaluepershare);

            Assert.AreEqual(Math.Round(t, 2), expected);
        }

        [TestInitialize]
        public void Setup()
        {
            p = new PBVRatio();
        }

        private PBVRatio p;
    }
}