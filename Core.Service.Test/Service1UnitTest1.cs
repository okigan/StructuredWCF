using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Contract;

namespace Core.Service.Test {
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class TechnobabbleUnitTest1 {
        public TechnobabbleUnitTest1() {
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext {
            get {
                return testContextInstance;
            }
            set {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestGetCollection() {
            ITechnobabble service = new TechnobabbleService();
            var list = service.GetCollection();
            Assert.IsTrue(list.Count > 0);
        }

        [TestMethod]
        public void TestGet() {
            ITechnobabble service = new TechnobabbleService();
            var list = service.GetCollection();

            foreach (var x in list) {
                SampleItem item = service.Get(x.Id);
                Assert.AreEqual(item.Id, x.Id);
            }
        }

        [TestMethod]
        public void TestUpdate() {
            ITechnobabble service = new TechnobabbleService();
            var initialList = service.GetCollection();

            foreach (var originalItem in initialList) {
                SampleItem item = service.Get(originalItem.Id);
                item.StringValue = "Updated from" + item.StringValue;

                SampleItem newItem = service.Update(item.Id, item);
                Assert.AreEqual(item, newItem);

                var updatedList = service.GetCollection();
                SampleItem updateItemFromCollection = (from temp in updatedList
                                                       where
                                                           temp.Id == item.Id
                                                       select temp).First();

                Assert.AreEqual(updateItemFromCollection.Id, newItem.Id);
                Assert.AreEqual(updateItemFromCollection.StringValue, newItem.StringValue);
            }
        }

        [TestMethod]
        public void TestDelete() {
            ITechnobabble service = new TechnobabbleService();
            var list = service.GetCollection();

            foreach (var x in list) {
                SampleItem item = service.Get(x.Id);
                service.Delete(item.Id);

                var updatedList = service.GetCollection();
                Assert.IsFalse(updatedList.Contains(item));

                try {
                    //now get shall fail
                    service.Get(item.Id);
                } catch (Exception) {
                    continue;
                }
                //should not reach this code
                Assert.Fail();
            }
        }
    }
}
