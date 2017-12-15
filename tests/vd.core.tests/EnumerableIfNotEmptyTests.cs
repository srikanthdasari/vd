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
    public class EnumerableIfNotEmptyTests
    {
        [TestMethod]
        public void IfNotEmpty_WithNull_DoNotCallAction_ReturnEmpty()
        {
            var result = _sequenceNull.IfEnumNotEmpty(x => Assert.Fail());

            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void IfNotEmpty_WithEmpty_DoNotCallAction_ReturnNull()
        {
            var result = _sequenceEmpty.IfEnumNotEmpty(x => Assert.Fail());

            Assert.AreSame(result, _sequenceEmpty);
        }


        [TestMethod]
        public void IfNotEmpty_WithFull_DoNotCallAction_ReturnNull()
        {
            var target = new MockClass1();

            var result = _sequenceFull.IfEnumNotEmpty(x => target.MethodReturnVoid());

            Assert.IsTrue(target.SomeMethodCalled);
            Assert.AreSame(result, _sequenceFull);
        }


        [TestMethod]
        public void IfNotEmpty_WithNull_DoNotCallFunc_ReturnOtherType_Empty()
        {
            var result = _sequenceNull.IfEnumNotEmpty(x => { Assert.Fail(); return _othetTypeSequence; });

            Assert.IsFalse(result.Any());
            Assert.IsTrue(result is IEnumerable<MockClass1>);
        }


        [TestMethod]
        public void IfNotEmpty_WithEmpty_DoNotCallFunc_ReturnOtherType_Empty()
        {
            var result = _sequenceEmpty.IfEnumNotEmpty(x => { Assert.Fail(); return _othetTypeSequence; });

            Assert.IsFalse(result.Any());
            Assert.IsTrue(result is IEnumerable<MockClass1>);
        }


        [TestMethod]
        public void IfNotEmpty_WithFull_DoNotCallFunc_ReturnOtherType_Empty()
        {
            var result = _sequenceFull.IfEnumNotEmpty(x => _othetTypeSequence);

            Assert.IsTrue(result.Any());
            Assert.IsTrue(result is IEnumerable<MockClass1>);
        }


        private readonly IEnumerable<string> _sequenceNull = null;
        private readonly IEnumerable<string> _sequenceEmpty = new string[] { };
        private readonly IEnumerable<string> _sequenceFull = new string[] { "a", "b" };

        private readonly IEnumerable<MockClass1> _othetTypeSequence = new[] { new MockClass1() };
    }
}