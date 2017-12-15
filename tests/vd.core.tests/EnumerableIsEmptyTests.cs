using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using vd.core.extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace vd.core.tests
{
    [TestClass]
    public class EnumerableIsEmptyTests
    {
        [TestMethod]
        public void IsEmpty_WithNull_ReturnTrue()
        {
            var result = _sequenceNull.IsEnumEmpty();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsEmpty_WithEmpty_ReturnTrue()
        {
            var result = _sequenceEmpty.IsEnumEmpty();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsEmpty_WithFull_ReturnFalse()
        {
            var result = _sequenceFull.IsEnumEmpty();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsNotEmpty_WithNull_ReturnFalse()
        {
            var result = _sequenceNull.IsEnumNotEmpty();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsNotEmpty_WithEmpty_ReturnFalse()
        {
            var result = _sequenceEmpty.IsEnumNotEmpty();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsNotEmpty_WithFull_ReturnTrue()
        {
            var result = _sequenceFull.IsEnumNotEmpty();

            Assert.IsTrue(result);
        }


        private readonly IEnumerable<string> _sequenceNull = null;
        private readonly IEnumerable<string> _sequenceEmpty = new string[] { };
        private readonly IEnumerable<string> _sequenceFull = new string[] { "a", "b" };
    }
}