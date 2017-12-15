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
    public class NullCheckExtensionsTests
    {
        [TestMethod]
        public void Null_Extension_Test()
        {
            object target = null;
            Assert.IsTrue(target.IsNull());
            Assert.IsFalse(target.IsNotNull());
        }


        public void NotNull_Extension_Tests()
        {
            object target = new object();

            Assert.IsFalse(target.IsNull());
            Assert.IsTrue(target.IsNotNull());
        }


        [TestMethod]
        public void IfNull_WithNullTarget_CallAction_ReturnSameType()
        {
            var target = default(MockClass1);
            var targetOther = new MockClass2();

            var rtn = target.IfNull(() => targetOther.OtherMethodReturnVoid());

            Assert.AreSame(rtn, target);
            Assert.IsTrue(targetOther.SomeMethodCalled);
            
        }

        [TestMethod]
        public void IfNull_withNullTarget_CallFunc_ReurnSameType()
        {
            var target = default(MockClass1);

            MockClass1 rtn = target.IfNull(() => new MockClass1());

            Assert.AreNotSame(target, rtn);
        }


        [TestMethod]
        public void IfNull_WithNullTarget_CallFuncTR_ReturnOtherType()
        {
            var target = default(MockClass1);

            MockClass2 rtn = target.IfNull(() => new MockClass2());

            Assert.IsNotNull(rtn);
        }

        [TestMethod]
        public void IfNull_WithTarget_CallAction_ReturnTarget()
        {
            var target = new MockClass1();

            // If T is null, call Action, always return T
            var rtn = target.IfNull(() => Assert.Fail());

            Assert.AreSame(rtn, target);
        }

        [TestMethod]
        public void IfNull_WithTarget_DoNotCallAction_ReturnSameTypeNull()
        {
            var target = new MockClass1();

            MockClass1 rtn = target.IfNull(() => new MockClass1());

            Assert.AreSame(rtn, target);
        }

        [TestMethod]
        public void IfNull_WithTarget_DoNotCallFuncTR_ReturnOtherTypeNull()
        {
            var target = new MockClass1();

            MockClass2 rtn = target.IfNull(() => new MockClass2());

            Assert.IsNull(rtn);
        }

        [TestMethod]
        public void IfNotNull_WithNullTarget_DoNotCallAction_ReturnSameTypeNull()
        {
            var target = default(MockClass1);

            // Do not call Action, return source
            var rtn = target.IfNotNull(() => Assert.Fail());

            Assert.IsNull(rtn);
        }

        //[TestMethod]
        //public void IfNotNull_WithNullTarget_DoNotCallActionT_ReturnSameTypeNull()
        //{
        //    var target = default(MockClass1);

        //    // Do not call Action<T>, always return source
        //    var rtn = target.IfNotNull(x => x.MethodReturnVoid());

        //    Assert.IsNull(rtn);
        //}


        [TestMethod]
        public void IfNotNull_WithNullTarget_DoNotCallFuncTTR_ReturnOtherTypeNull()
        {
            var target = default(MockClass1);

            // Do not call Func<T,TR>(), return default(TR)
            MockClass2 otherRtn = target.IfNotNull(x => new MockClass2());

            Assert.IsNull(otherRtn);
        }


        [TestMethod]
        public void IfNotNull_WithNullTarget_DoNotCallFuncTR_ReturnOtherTypeNull()
        {
            var target = default(MockClass1);

            // Do not call Func<TR>(), return default(TR)
            MockClass2 otherRtn = target.IfNotNull(() => new MockClass2());

            Assert.IsNull(otherRtn);
        }

        [TestMethod]
        public void IfNotNull_WithTarget_CallAction_ReturnSameType()
        {
            var target = new MockClass1();

            var rtn = target.IfNotNull(() => target.MethodReturnVoid());

            Assert.IsNotNull(rtn);
            Assert.AreSame(rtn, target);
            Assert.IsTrue(target.SomeMethodCalled);
        }

        //[TestMethod]
        //public void IfNotNull_WithTarget_CallActionT_ReturnSameType()
        //{
        //    var target = new MockClass1();

        //    // Do not call Action<T>, always return source
        //    var rtn = target.IfNotNull(x => x.MethodReturnVoid());

        //    Assert.IsNotNull(rtn);
        //    Assert.AreSame(rtn, target);
        //    Assert.IsTrue(target.SomeMethodCalled);
        //}

        [TestMethod]
        public void IfNotNull_WithTarget_CallFuncTTR_ReturnOtherType()
        {
            var target = new MockClass1();

            MockClass2 otherRtn = target.IfNotNull(x => new MockClass2());

            Assert.IsNotNull(otherRtn);
        }

        [TestMethod]
        public void IfNotNull_WithTarget_CallFuncTR_ReturnOtherType()
        {
            var target = new MockClass1();

            // Do not call Func<TR>(), return default(TR)
            MockClass2 otherRtn = target.IfNotNull(() => new MockClass2());

            Assert.IsNotNull(otherRtn);
        }
    }
}