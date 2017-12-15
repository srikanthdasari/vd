using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using vd.core.extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace vd.core.tests
{
    [TestClass]
    public class IsNotEmptyTests
    {
        [TestMethod]
        public void IsNotEmpty_WithNullString_IsTrue()
        {
            string target = null;

            Assert.IsFalse(target.IsNotEmpty());
        }

        [TestMethod]
        public void IsNotEmpty_WithEmptyString_IsTrue()
        {
            var target = string.Empty;

            Assert.IsFalse(target.IsNotEmpty());
        }

        [TestMethod]
        public void IsNotEmpty_WithString_IsFalse()
        {
            const string target = "x";

            Assert.IsTrue(target.IsNotEmpty());
        }
    }
}