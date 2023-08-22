namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Data;
    using System.Xml.Linq;

    [TestFixture]
    public class DatabaseTests
    {
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]

        public void Test_AddArrayIntViaConstructor(int[] testArray)
        {

            Database database = new Database(testArray);
            int[] expecAray = testArray;
            int[] actualCount = database.Fetch();
            CollectionAssert.AreEqual(expecAray, actualCount);

        }
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]

        public void Test_CountDatabase(int[] testArray)
        {

            Database database = new Database(testArray);
            int expecCount = testArray.Length;
            int actualCount = database.Count;

            Assert.AreEqual(expecCount, actualCount);
        }
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, })]
        public void Test_AddElementWhenArrayLessThan16(int[] data)
        {
            int expectEleent = 88;
            Database database = new Database(data);
            database.Add(expectEleent);
            int actualElemet = database.Fetch()[database.Count - 1];

            Assert.AreEqual(expectEleent, actualElemet);

        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Test_AddElementWhenArrayIsGreaterThan16(int[] data)
        {
            Database database = new Database(data);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(17);
            }, "Array's capacity must be exactly 16 integers!"
            );
        }
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Test_RemoveItemFromValidDatabase(int[] data)
        {
            int expecCount = data.Length-1;
            Database database = new Database(data);
            database.Remove();
            int actualCount = database.Count;

            Assert.AreEqual(expecCount, actualCount);
        }
        [Test]
        public void Test_InvalidOperationExceptionRemoveItemEmptyatabase()
        {
            Database database = new Database(new int[] { });

            Assert.Throws<InvalidOperationException>(() => database.Remove(), "The collection is empty!");
        }
        [Test]
        public void Test_InvalidOperationExceptionAddArrayGreaterThan16()
        {
            int[] dataT = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
            Assert.Throws<InvalidOperationException>(() =>  new Database(dataT), "Array's capacity must be exactly 16 integers!");
        }

    }
}
