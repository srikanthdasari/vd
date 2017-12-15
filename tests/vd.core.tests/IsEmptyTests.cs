using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using vd.core.extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace vd.core.tests
{
    [TestClass]
    public class IsEmptyTests
    {
         [TestMethod]
        public void IsEmpty_WithNullString_IsTrue()
        {
            string target = null;

            Assert.IsTrue(target.IsEmpty());
        }

        [TestMethod]
        public void IsEmpty_WithEmptyString_IsTrue()
        {
            var target = string.Empty;

            Assert.IsTrue(target.IsEmpty());
        }

        [TestMethod]
        public void IsEmpty_WithString_IsFalse()
        {
            const string target = "x";

            Assert.IsFalse(target.IsEmpty());
        }
    }
}