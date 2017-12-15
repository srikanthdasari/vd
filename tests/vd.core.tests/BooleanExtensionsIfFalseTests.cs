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
    public class BooleanExtensionsIfFalseTests
    {
        [TestMethod]
        public void IfFalse_WithTrue_DoNotCallAction()
        {
            true.IfFalse(() => Assert.Fail());
        }


        [TestMethod]
        public void IfFalse_WithFalse_CallAction()
        {
            var actionCalled = false;

            false.IfFalse(() => actionCalled = true);

            Assert.IsTrue(actionCalled);
        }


        [TestMethod]
        public void IfFalse_WithTrue_DoNotCallActionBool()
        {
            true.IfFalse(x => Assert.Fail());
        }


        [TestMethod]
        public void IfFalse_WithFalse_CallActionBool()
        {
            var actionCalled = true;

            false.IfFalse(x => actionCalled = x);

            Assert.IsFalse(actionCalled);
        }


        [TestMethod]
        public void IfFalse_WithTrue_DoNotCallFuncT()
        {
            MockClass1 result = true.IfFalse(x => { Assert.Fail(); return new MockClass1(); });
        }


        [TestMethod]
        public void IfFalse_WithFalse_CallFunctT()
        {
            MockClass1 result = false.IfFalse(x => new MockClass1());

            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void IfFalse_WithTrue_CallFunctT_ReturnDefault()
        {
            MockClass1 result = true.IfFalse(x => new MockClass1());

            Assert.IsTrue(result == default(MockClass1));
        }
    }
}