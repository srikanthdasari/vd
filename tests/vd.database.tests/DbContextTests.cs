using Microsoft.VisualStudio.TestTools.UnitTesting;
using vd.database;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace vd.database.tests
{
    [TestClass, Ignore]
    public class DbContextTests
    {
        [TestMethod]
        public void ConnectionTest()
        {
         //   Assert.IsNotNull(context);
         //   Assert.IsNotNull(context.tags);
         //   Assert.AreNotEqual(0,context.tags.Count());

        }

        [TestInitialize]
        public void Setup()
        {
           // context=new VDContext(new DbContextOptions())
           // context.Database.EnsureCreated();
        }

        VDContext context;
    }
}
