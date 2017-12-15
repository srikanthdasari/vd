using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using vd.core.extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace vd.core.tests
{
    [TestClass]
    public class IfEmptyTests
    {
        [TestMethod]
        public void IfEmpty_WithNullString_CallAction()
        {
            string target = null;
            var isActionCalled = false;

            var result = target.IfEmpty(() => isActionCalled = true);

            Assert.IsTrue(isActionCalled);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void IfEmpty_WithEmptyString_CallAction()
        {
            var target = string.Empty;
            var isActionCalled = false;

            var result = target.IfEmpty(() => isActionCalled = true);

            Assert.IsTrue(isActionCalled);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsEmpty());
        }

        [TestMethod]
        public void IfEmpty_WithString_DoNotCallAction()
        {
            const string target = "a";

            var result = target.IfEmpty(() => Assert.Fail());

            Assert.AreEqual(result, "a");
        }

        [TestMethod]
        public void IfEmpty_WithString_DoNotCallFuncString()
        {
            const string target = "a";

            var result = target.IfEmpty(() => "b");

            Assert.AreEqual(result, "a");
        }

        [TestMethod]
        public void IfEmpty_WithNull_CallFuncString()
        {
            const string target = null;

            var result = target.IfEmpty(() => "b");

            Assert.AreEqual(result, "b");
        }
    }
}