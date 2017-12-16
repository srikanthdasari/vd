using System;
using vd.fundamentals.Ratios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace vd.fundamentals.tests
{
    [TestClass]
    public class DTERatioTests
    {

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DTERatioTests_With_Zero_ShareHolderEquity()
        {
            var t = d.CaliculateDTE(1, 0);            
        }

        [TestMethod]
        public void DTERatioTests_With_Zero_TotalLongTermDebt()
        {
            var t = d.CaliculateDTE(0, 1);
            Assert.AreEqual(t, 0);
        }

        [TestMethod]
        public void DTERatioTests_With_Inputs()
        {
            var totalLongTermDebt = 797.00;
            var shareHolderEquity = 14262.00;
            var t = d.CaliculateDTE(totalLongTermDebt, shareHolderEquity);
            Assert.AreEqual(Math.Round(t,2), 0.06);
        }

        [TestInitialize]
        public void Setup()
        {
            d = new DTERatio();
        }

        private DTERatio d;
    }
}