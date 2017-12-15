using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using vd.core.extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace vd.core.tests
{
    [TestClass]
    public class EnumerableForEachTests
    {
        [TestMethod]
        public void ForEach_WithNull_DoNotCallAction_ReturnEmpty()
        {
            var result = _sequenceNull.ForEach(x => Assert.Fail());

            Assert.IsFalse(result.Any());
        }

        [TestMethod]
        public void ForEach_WithEmpty_DoNotCallAction_ReturnSame()
        {
            var result = _sequenceEmpty.ForEach(x => Assert.Fail());

            Assert.IsFalse(result.Any());
        }

        [TestMethod]
        public void ForEach_WithFull_CallAction_ReturnSame()
        {
            var iCallTimes = 0;

            var result = _sequenceFull.ForEach(x => ++iCallTimes);

            Assert.IsTrue(iCallTimes > 0);
            Assert.IsTrue(iCallTimes == _sequenceFull.Count());
            Assert.AreSame(result, _sequenceFull);
        }

        private readonly IEnumerable<string> _sequenceNull = null;
        private readonly IEnumerable<string> _sequenceEmpty = new string[] { };
        private readonly IEnumerable<string> _sequenceFull = new string[] { "a", "b" };
    }
}