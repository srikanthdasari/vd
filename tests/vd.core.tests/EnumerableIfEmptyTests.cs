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
    public class EnumerableIfEmptyTests
    {
        [TestMethod]
        public void IfEmpty_WithNull_CallAction_ReturnEmpty()
        {
            var target = new MockClass1();

            IEnumerable<string> result = _sequenceNull.IfEnumEmpty(() => target.MethodReturnVoid());

            Assert.IsFalse(result.Any());
            Assert.IsTrue(target.SomeMethodCalled);
        }


        [TestMethod]
        public void IfEmpty_WithEmpty_CallAction_ReturnEmpty()
        {
            var target = new MockClass1();

            IEnumerable<string> result = _sequenceEmpty.IfEnumEmpty(() => target.MethodReturnVoid());

            Assert.IsFalse(result.Any());
            Assert.IsTrue(target.SomeMethodCalled);
        }


        [TestMethod]
        public void IfEmpty_WithFull_DoNotCallAction_ReturnEmpty()
        {
            var target = new MockClass1();

            var result = _sequenceFull.IfEnumEmpty(() => { Assert.Fail(); target.MethodReturnVoid(); });

            Assert.AreSame(result, _sequenceFull);
        }


        [TestMethod]
        public void IfEmpty_WithNull_CallFunc_ReturnOtherType_Full()
        {
            IEnumerable<MockClass1> result = _sequenceNull.IfEnumEmpty(() => _othetTypeSequence);

            Assert.IsTrue(result.Any());
        }


        [TestMethod]
        public void IfEmpty_WithEmpty_CallFunc_ReturnOtherType_Full()
        {
            IEnumerable<MockClass1> result = _sequenceEmpty.IfEnumEmpty(() => _othetTypeSequence);

            Assert.IsTrue(result.Any());
        }


        [TestMethod]
        public void IfEmpty_WithEmpty_CallFunc_ReturnType_Null()
        {
            IEnumerable<MockClass1> result = _sequenceEmpty.IfEnumEmpty(() => default(MockClass1[]));

            Assert.IsFalse(result.Any());
        }


        [TestMethod]
        public void IfEmpty_WithEmpty_CallFunc_ReturnOtherType_Null()
        {
            IEnumerable<MockClass2> result = _sequenceEmpty.IfEnumEmpty(() => default(MockClass2[]));

            Assert.IsFalse(result.Any());
        }


        [TestMethod]
        public void IfEmpty_WithFull_DoNotCallFunc_ReturnOtherType_Empty()
        {
            IEnumerable<MockClass1> result = _sequenceFull.IfEnumEmpty(() => { Assert.Fail(); return _othetTypeSequence; });

            Assert.IsFalse(result.Any());
        }


        private readonly IEnumerable<string> _sequenceNull = null;
        private readonly IEnumerable<string> _sequenceEmpty = new string[] { };
        private readonly IEnumerable<string> _sequenceFull = new string[] { "a", "b" };

        private readonly IEnumerable<MockClass1> _othetTypeSequence = new[] { new MockClass1() };
    }
}