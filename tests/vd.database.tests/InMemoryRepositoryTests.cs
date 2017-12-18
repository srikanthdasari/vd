using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace vd.database.tests
{
    [TestClass]
    public class InMemoryRepositoryTests
    {
        [TestMethod, Ignore]
        public async Task TestCRUD()
        {
            var options=new DbContextOptionsBuilder<TestContext>().UseInMemoryDatabase(databaseName: "Add_writes_to_database"+Guid.NewGuid().ToString()).Options;
            
            var testobj=new TestEntity();
            testobj.ID=1;
            testobj.Property1="prop1";
            testobj.Property2="prop2";
            testobj.Property3="prop3";
            
            using(var context=new TestContext(options))
            {
                var service=new Repository<TestEntity>(context);
                await service.Add(testobj,context.TestEntities);
            }

            using(var context=new TestContext(options))
            {
                Assert.AreEqual(1,context.TestEntities.Count());
                Assert.AreEqual(1,context.TestEntities.FirstOrDefault().ID);
                Assert.AreEqual("prop1",context.TestEntities.FirstOrDefault().Property1);
                Assert.AreEqual("prop2",context.TestEntities.FirstOrDefault().Property2);
                Assert.AreEqual("prop3",context.TestEntities.FirstOrDefault().Property3);
             
                var service=new Repository<TestEntity>(context);
                var obj=await service.FindByID(1,context.TestEntities);
                obj.Property1="newprop1";
                await service.Update(testobj);
            }


            using(var context=new TestContext(options))
            {
                Assert.AreEqual(1,context.TestEntities.Count());
                Assert.AreEqual(1,context.TestEntities.FirstOrDefault().ID);
                Assert.AreEqual("newprop1",context.TestEntities.FirstOrDefault().Property1);

                var service=new Repository<TestEntity>(context);
                await service.Remove(1,context.TestEntities);
            }

            using (var context=new TestContext(options))
            {
                Assert.AreEqual(0,context.TestEntities.Count());
            }

        }


        [TestMethod, Ignore]
        public async Task TestAdd_ChangesNotSaved()
        {
            var options=new DbContextOptionsBuilder<TestContext>().UseInMemoryDatabase(databaseName: "TestAddChangesNotSaved"+Guid.NewGuid().ToString()).Options;

            var testObject2=new TestEntity();
            testObject2.ID=2;
            testObject2.Property1="prop1";
            testObject2.Property2="prop2";
            testObject2.Property3="prop3";

            using(var context=new TestContext(options))
            {
                var service=new Repository<TestEntity>(context);
                await service.Add(testObject2,context.TestEntities,false);    
            }

            using(var context=new TestContext(options))
            {
                Assert.AreEqual(0,context.TestEntities.Count());
            }
        }


        [TestMethod, Ignore]
        public async Task TestUpdate_ChangeNotSaved()
        {
            var options=new DbContextOptionsBuilder<TestContext>().UseInMemoryDatabase(databaseName: "TestUpdateChangesNotSaved"+Guid.NewGuid().ToString()).Options;

            var testObject3=new TestEntity();
            testObject3.ID=3;
            testObject3.Property1="prop1";
            testObject3.Property2="prop2";
            testObject3.Property3="prop3";

            using(var context=new TestContext(options))
            {
                var service=new Repository<TestEntity>(context);
                await service.Add(testObject3,context.TestEntities);
            }

            using(var context=new TestContext(options))
            {
                Assert.AreEqual(1,context.TestEntities.Count());
                Assert.AreEqual(3,context.TestEntities.FirstOrDefault().ID);
                Assert.AreEqual("prop1",context.TestEntities.FirstOrDefault().Property1);
                Assert.AreEqual("prop2",context.TestEntities.FirstOrDefault().Property2);
                Assert.AreEqual("prop3",context.TestEntities.FirstOrDefault().Property3);

                var service=new Repository<TestEntity>(context);
                var obj=await service.FindByID(3,context.TestEntities);

                obj.Property1="newprop1";

                await service.Update(obj,false);
            }

            using(var context=new TestContext(options))
            {
                Assert.AreEqual(1,context.TestEntities.Count());
                Assert.AreEqual(3,context.TestEntities.FirstOrDefault().ID);
                Assert.AreEqual("prop1",context.TestEntities.FirstOrDefault().Property1);
                Assert.AreEqual("prop2",context.TestEntities.FirstOrDefault().Property2);
                Assert.AreEqual("prop3",context.TestEntities.FirstOrDefault().Property3);
            }
        }


        [TestMethod, Ignore]
        public async Task TestDelete_ChangesNotSaved()
        {
            var options=new DbContextOptionsBuilder<TestContext>().UseInMemoryDatabase(databaseName: "TestDeleteChangesNotSaved"+Guid.NewGuid().ToString()).Options;

            var testObject4=new TestEntity();
            testObject4.ID=4;
            testObject4.Property1="prop1";
            testObject4.Property2="prop2";
            testObject4.Property3="prop3";

            using(var context=new TestContext(options))
            {
                var service=new Repository<TestEntity>(context);
                await service.Add(testObject4,context.TestEntities);
            }

            using(var context=new TestContext(options))
            {
                Assert.AreEqual(1,context.TestEntities.Count());
                Assert.AreEqual(4,context.TestEntities.FirstOrDefault().ID);
                Assert.AreEqual("prop1",context.TestEntities.FirstOrDefault().Property1);
                Assert.AreEqual("prop2",context.TestEntities.FirstOrDefault().Property2);
                Assert.AreEqual("prop3",context.TestEntities.FirstOrDefault().Property3);

                var service=new Repository<TestEntity>(context);
                await service.Remove(4,context.TestEntities,false);
            }

            using(var context=new TestContext(options))
            {
                Assert.AreEqual(1,context.TestEntities.Count());
                Assert.AreEqual(4,context.TestEntities.FirstOrDefault().ID);
                Assert.AreEqual("prop1",context.TestEntities.FirstOrDefault().Property1);
                Assert.AreEqual("prop2",context.TestEntities.FirstOrDefault().Property2);
                Assert.AreEqual("prop3",context.TestEntities.FirstOrDefault().Property3);
            }
        }
    }
}