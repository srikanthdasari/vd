using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using vd.core.extensions;
using vd.mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace vd.core.tests
{
    [TestClass]
    public class IfNotEmptyTests
    {
        [TestMethod]
        public void IfNotEmpty_WithNullString_DoNotCallFunc()
        {
            string target = null;

            var result = target.IfNotEmpty(x => { Assert.Fail(); return string.Empty; });

            Assert.IsNull(result);
        }

        [TestMethod]
        public void IfNotEmpty_WithString_CallFunc()
        {
            const string target = "a";

            var result = target.IfNotEmpty(x => x + "b");

            Assert.AreEqual(result, "ab");
        }

        [TestMethod]
        public void IfNotEmpty_WithString_CallAction()
        {
            const string target = "a";
            var isActionCalled = false;

            var result = target.IfNotEmpty(() => isActionCalled = true);

            Assert.IsTrue(isActionCalled);
            Assert.AreEqual(result, "a");
        }

        [TestMethod]
        public void IfNotEmpty_WithNullString_DoNotCallAction()
        {
            const string target = null;
            var isActionCalled = false;

            var result = target.IfNotEmpty(() => isActionCalled = true);

            Assert.IsFalse(isActionCalled);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void IfNotEmpty_WithNullString_DoNotCallFuncTRet()
        {
            const string target = null;

            MockClass1 result = target.IfNotEmpty(x => { Assert.Fail(); return new MockClass1(); });

            Assert.IsNull(result);
        }

        [TestMethod]
        public void IfNotEmpty_WithString_CallFuncTRet()
        {
            const string target = "a";

            MockClass1 result = target.IfNotEmpty(x => new MockClass1());

            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void IfNotEmpty_WithNullString_DoNotCallActionString()
        {
            const string target = null;

            var result = target.IfNotEmpty(x => Assert.Fail());

            Assert.IsNull(result);
        }



        [TestMethod]
        public void IfNotEmpty_WithString_CallActionString()
        {
            const string target = "a";
            var someType = new MockClass1();

            var result = target.IfNotEmpty(x => someType.MethodReturnVoid());

            Assert.AreEqual(result, target);
            Assert.IsTrue(someType.SomeMethodCalled);
        }
    }
}