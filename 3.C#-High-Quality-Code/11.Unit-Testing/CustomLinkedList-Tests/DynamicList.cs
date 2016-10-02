// Created by: Evgeni Nikolov on 2016 / 01 / 14 / 12:40 PM
namespace CustomLinkedList_Tests
{
    using System;

    using CustomLinkedList;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DynamicList
    {
        private DynamicList<int> dynamicListTest;

        [TestInitialize]
        public void DynamicListInitializer()
        {
            this.dynamicListTest = new DynamicList<int>();

            // Add first 5 elements
            for (int i = 0; i < 5; i++)
            {
                this.dynamicListTest.Add(i);
            }
        }

        [TestMethod]
        public void TestCount_ShouldPass()
        {
            this.dynamicListTest.Add(5);
            Assert.AreEqual(6, this.dynamicListTest.Count, "Wrong count implementation.");
        }

        [TestMethod]
        public void TestAddItemsAtTheEndOfList_ShouldPass()
        {
            for (int i = 0; i < 5; i++)
            {
                this.dynamicListTest.Add(i);
                Assert.AreEqual(i, this.dynamicListTest[i], "Does not add the right item at the end of the list.");
            }
        }

        [TestMethod]
        public void TestRemoveElementsAtGivenIndex_ShouldPass()
        {
            this.dynamicListTest.RemoveAt(2);
            Assert.AreEqual(3, this.dynamicListTest[2], "Returns wrong element after removal.");
        }

        [TestMethod]
        public void TestRemoveExistingElementAndReturnsIndex_ShouldPass()
        {
            Assert.AreEqual(3, this.dynamicListTest.Remove(3));
        }

        [TestMethod]
        public void TestRemoveUneistingElementAndReturnsIndex_ShouldPass()
        {
            Assert.AreEqual(-1, this.dynamicListTest.Remove(7));
        }

        [TestMethod]
        public void TestSearchOfExistingElementAndReturnFirstOccurenceIndex_ShouldPass()
        {
            Assert.AreEqual(3, this.dynamicListTest.IndexOf(3));
        }

        [TestMethod]
        public void TestSearchOfUnexistingElementAndReturnNegativeIndex_ShouldPass()
        {
            Assert.AreEqual(-1, this.dynamicListTest.IndexOf(7));
        }

        [TestMethod]
        public void TestIfListContainsExistingElement_ShouldPass()
        {
            Assert.IsTrue(this.dynamicListTest.Contains(2));
        }

        [TestMethod]
        public void TestIfListContainsUnexistingElement_ShouldPass()
        {
            Assert.IsFalse(this.dynamicListTest.Contains(10));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestRemoveElementAtGreaterThanCoundIndex_ShouldThrowException()
        {
            this.dynamicListTest.RemoveAt(this.dynamicListTest.Count + 1);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestRemoveElementFromNegativeNumber_ShouldThrowException()
        {
            this.dynamicListTest.RemoveAt(-6);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestSetInvalidIndex_ShouldThrowException()
        {
            var index = this.dynamicListTest[10];
        }
    }
}