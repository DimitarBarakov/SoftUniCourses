namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void IsAddingAtTheLastPosition()
        {
            int[] expectedData = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 17 };
            int[] arr = new int[15];
            Database database = new Database(arr);

            database.Add(17);
            int[] actualData = database.Fetch();

            Assert.That(database.Count, Is.EqualTo(16));
            CollectionAssert.AreEqual(expectedData,actualData);
        }
        [Test]
        public void ThrowingExceptionForTooManyElements()
        {
            int[] arr = new int[16];
            Database database = new Database(arr);

            Assert.Throws<InvalidOperationException>(()=> 
            {
                database.Add(17);
            }, "Array's capacity must be exactly 16 integers!");
        }
        [Test]
        public void RemovingElementAtLastPosition()
        {
            int[] arr = new int[16];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i;
            }
            Database database = new Database(arr);
            database.Remove();
            int[] actualData = database.Fetch();
            List<int> expectedData = arr.ToList();
            expectedData.RemoveAt(expectedData.Count - 1);

            Assert.That(database.Count == 15);
            CollectionAssert.AreEqual(expectedData, actualData);
        }
        [Test]
        public void RemovingElementInEmptyArray()
        {
            int[] arr = new int[0];
            Database database = new Database(arr);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            }, "The collection is empty!");
        }
        [Test]
        public void CreatingdDatabaseWithExactly16Elements()
        {
            int[] arr = new int[16];
            Database database = new Database(arr);

            Assert.That(database.Count == 16);
        }
        [Test]
        public void CreatingdDatabaseWithMoreThan16Elements()
        {
            int[] arr = new int[17];

            Assert.Throws<InvalidOperationException>(() =>
            {
                Database database = new Database(arr);
            }, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        [TestCase(new int[] {})]
        [TestCase(new int[] { 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16 })]
        public void FetchShouldReturnDatabaseAsArray(int[] array)
        {
            Database database = new Database(array);
            int[] expectedData = array;
            int[] actualData = database.Fetch();

            CollectionAssert.AreEqual(expectedData, actualData);
        }
    }
}
