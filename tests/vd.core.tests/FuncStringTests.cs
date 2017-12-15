using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using vd.core.extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace vd.core.tests
{
    [TestClass]
    public class FuncStringTests
    {
        [TestMethod]
        public void FunNull()
        {
            Func<string> func = null;
            Assert.IsTrue(func.Call().IsEmpty());
        }

        [TestMethod]
        public void FuncNotNull()
        {
            Func<string> func = () => "a";
            Assert.IsTrue(func.Call().IsEqualTo("a"));
        }

        [TestMethod]
        public void IfNullEmptyStr()
        {
            string target = null;
            Assert.AreEqual("", target.IfNullEmptyStr());
        }
    }
}