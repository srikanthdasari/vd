using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using vd.core.extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace vd.core.tests
{
    [TestClass]
    public class StringDateTimeExtensionsTests
    {
        /// <summary>
        /// ToDateTimeCountText
        /// </summary>
        [TestMethod]
        public void TestDateToString()
        {
            Assert.IsTrue((DateTime.Parse("06/03/2013").ToString("yyyy-MM-dd")).Equals("2013-06-03"));
            Assert.IsTrue((DateTime.Parse("06/03/2013 13:55:34").ToString("yyyy-MM-dd.HH-mm-ss")).Equals("2013-06-03.13-55-34"));
        }


        [TestMethod]
        public void TestDateTime()
        {
            var date = "Tue, 10 Jun 2014 15:48:01 EST".ToDateTimeFromStr();
            Assert.IsTrue(date == new DateTime(2014, 06, 10, 16, 48, 01));

            Assert.AreEqual(((string)null).ToDateTimeFromStr().Date, new DateTime(1, 1, 1).Date);
            Assert.IsTrue("Sun, 23 Jun 2013 18:20:01".ToDateTimeFromStr().Date == new DateTime(2013, 06, 23).Date);
            Assert.IsTrue("Sun, 23 Jun 2013 18:20:01 GMT".ToDateTimeFromStr().Date == new DateTime(2013, 06, 23).Date);
            Assert.IsTrue("Mon, 08 Apr 2013 00:02:00".ToDateTimeFromStr().Date == new DateTime(2013, 4, 8).Date);
            Assert.IsTrue("Tue, 02 Jul 2013 12:00:01 GMT".ToDateTimeFromStr() == "Tue, 02 Jul 2013 08:00:01 EDT".ToDateTimeFromStr());
            Assert.IsTrue("Fri, 28 Jun 2013 19:00:18 +0100".ToDateTimeFromStr() == DateTime.Parse("6/28/2013 2:00:18 PM"));
            Assert.IsTrue("Sun, 23 Jun 2013 20:56:30 EDT".ToDateTimeFromStr() == DateTime.Parse("6/23/2013 8:56:30 PM"));
            Assert.AreEqual(2, "Fri, 07 Feb 2014 11:52:10 EST".ToDateTimeFromStr().Month);
            Assert.AreEqual(2014, "Tue, 7 Jan 2014 10:02:00 -0400".ToDateTimeFromStr().Year);
            Assert.AreEqual(2010, "Thu, 20 May 2010 10:16:00 -0400".ToDateTimeFromStr().Year);
        }
    }
}