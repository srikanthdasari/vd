using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using vd.core.extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace vd.core.tests
{
    [TestClass]
    public class EnumerableDoTests
    {
        [TestMethod]
        public void Do_WithNull_CallActionOnce_ReturnEmpty()
        {
            bool wasMethodCalled = false;
            IEnumerable<string> result = _sequenceNull.Do(x =>
            {
                wasMethodCalled = true;
                return;
            });

            Assert.AreSame(_sequenceNull, result);
            Assert.IsTrue(wasMethodCalled);
        }

        [TestMethod]
        public void Do_WithEmpty_CallActionOnce_ReturnEmpty()
        {
            bool wasMethodCalled = false;
            IEnumerable<string> result = _sequenceEmpty.Do(x =>
            {
                wasMethodCalled = true;
                return;
            });

            Assert.AreSame(_sequenceEmpty, result);
            Assert.IsTrue(wasMethodCalled);
        }

        [TestMethod]
        public void Do_WithFull_CallActionOnce_ReturnSame()
        {
            bool wasMethodCalled = false;
            IEnumerable<string> result = _sequenceFull.Do(x =>
            {
                wasMethodCalled = true;
                return;
            });

            Assert.AreSame(_sequenceFull, result);
            Assert.IsTrue(wasMethodCalled);
        }

        [TestMethod]
        public void Do_WithNull_CallFuncTRetOnce_ReturnEmpty()
        {
            bool wasMethodCalled = false;
            bool result = _sequenceNull.Do(x =>
            {
                wasMethodCalled = true;
                return x.IsEnumEmpty();
            });

            Assert.IsTrue(result);
            Assert.IsTrue(wasMethodCalled);
        }

        [TestMethod]
        public void Do_WithEmpty_CallFuncTRetOnce_ReturnEmpty()
        {
            bool wasMethodCalled = false;
            bool result = _sequenceEmpty.Do(x =>
            {
                wasMethodCalled = true;
                return x.IsEnumEmpty();
            });

            Assert.IsTrue(result);
            Assert.IsTrue(wasMethodCalled);
        }

        [TestMethod]
        public void Do_WithFull_CallFuncTRetOnce_ReturnSame()
        {
            bool wasMethodCalled = false;
            bool result = _sequenceFull.Do(x =>
            {
                wasMethodCalled = true;
                return x.IsEnumEmpty();
            });

            Assert.IsFalse(result);
            Assert.IsTrue(wasMethodCalled);
        }

        private readonly IEnumerable<string> _sequenceNull = null;
        private readonly IEnumerable<string> _sequenceEmpty = new string[] { };
        private readonly IEnumerable<string> _sequenceFull = new[] { "a", "b" };
    }
}