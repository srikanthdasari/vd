using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using vd.core.extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace vd.core.tests
{
    [TestClass]
    public class IsNotEqualToTests
    {
         [TestMethod]
        public void IsNotEqualTo_WithLeftNull_WithRighNull_IsFalse()
        {
            string targetLeft = null;
            string targetRight = null;

            var result = targetLeft.IsNotEqualTo(targetRight);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsNotEqualTo_WithLeftEmpty_WithRighNull_IsTrue()
        {
            string targetLeft = string.Empty;
            string targetRight = null;

            var result = targetLeft.IsNotEqualTo(targetRight);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsNotEqualTo_WithLeftString_WithRighString_IsFalse()
        {
            string targetLeft = "x";
            string targetRight = "x";

            var result = targetLeft.IsNotEqualTo(targetRight);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsNotEqualTo_WithLeftString_WithRighString_IsTrue()
        {
            const string targetLeft = "x";
            const string targetRight = "a";

            var result = targetLeft.IsNotEqualTo(targetRight);

            Assert.IsTrue(result);
        }


        //[TestMethod]
        //public void IfNotEqualTo_WithLeftString_WithRighString_WhenEqual()
        //{
        //    const string targetLeft = "x";
        //    const string targetRight = "X";

        //    var result = targetLeft.IfNotEqualTo(targetRight, (s, s1) => { Assert.Fail(); });
        //    ...
        //    Assert.IsTrue(result);
        //}
    }
}