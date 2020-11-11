using NUnit.Framework;
using DataStructures;
using System;

namespace MyDataStructuresTests
{
    public class ArrayListTests
    {
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4, 95 }, 95)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 99 }, 99)]
        [TestCase(new int[] { 1, -1, 35, 46, 102 }, new int[] { 1, -1, 35, 46, 102, 0 }, 0)]
        [TestCase(new int[] { }, new int[] { 25 }, 25)]

        public void AddTest(int[] array, int[] expArray, int value)
        {
            ArrayList expected = new ArrayList(expArray);
            ArrayList actual = new ArrayList(array);
            actual.Add(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4, 10, 15, 20 }, new int[] { 10, 15, 20 })]
        [TestCase(new int[] { 10, 20, 30, 40 }, new int[] { 10, 20, 30, 40, 50, 60, 70 }, new int[] { 50, 60, 70 })]
        [TestCase(new int[] { -10, 20, -30, 40 }, new int[] { -10, 20, -30, 40, -50, 60, -70 }, new int[] { -50, 60, -70 })]
        [TestCase(new int[] { }, new int[] { }, new int[] { })]

        public void AddTest(int[] array, int[] expArray, int[] addArray)
        {
            ArrayList expected = new ArrayList(expArray);
            ArrayList actual = new ArrayList(array);
            actual.Add(addArray);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 0, 1, 2, 3, 4, }, 0)]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 50, 1, 2, 3, 4, }, 50)]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { -5, 1, 2, 3, 4, }, -5)]
        [TestCase(new int[] { }, new int[] { 5 }, 5)]

        public void AddFirstTest(int[] array, int[] expArray, int value)
        {
            ArrayList expected = new ArrayList(expArray);
            ArrayList actual = new ArrayList(array);
            actual.AddFirst(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 0, -10, 20, 1, 2, 3, 4, }, new int[] { 0, -10, 20 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 150, 300, 450, 1, 2, 3, 4, }, new int[] { 150, 300, 450 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { -99, -52, -123, -456, -789, 1, 2, 3, 4, }, new int[] { -99, -52, -123, -456, -789 })]
        [TestCase(new int[] { }, new int[] { 5, 6 }, new int[] { 5, 6 })]

        public void AddFirstTest(int[] array, int[] expArray, int[] addArray)
        {
            ArrayList expected = new ArrayList(expArray);
            ArrayList actual = new ArrayList(array);
            actual.AddFirst(addArray);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 0, 1, 2, 3, 4, }, 0, 0)]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4, 5 }, 5, 4)]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 123, 3, 4, }, 123, 2)]
        [TestCase(new int[] { }, new int[] { 5 }, 5, 0)]

        public void AddByIndexTest(int[] array, int[] expArray, int value, int index)
        {
            ArrayList expected = new ArrayList(expArray);
            ArrayList actual = new ArrayList(array);
            actual.AddByIndex(value, index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 0, 15, -20, 1, 2, 3, 4, }, new int[] { 0, 15, -20 }, 0)]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4, 5, -100, 30, 75 }, new int[] { 5, -100, 30, 75 }, 4)]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 123, 159, 753, 321, 3, 4, }, new int[] { 123, 159, 753, 321 }, 2)]
        [TestCase(new int[] { }, new int[] { }, new int[] { }, 0)]

        public void AddByIndexTest(int[] array, int[] expArray, int[] addArray, int index)
        {
            ArrayList expected = new ArrayList(expArray);
            ArrayList actual = new ArrayList(array);
            actual.AddByIndex(addArray, index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, })]
        [TestCase(new int[] { 3, 2, 1, 0 }, new int[] { 3, 2, 1 })]
        [TestCase(new int[] { 123, 321, 147, 741, 987 }, new int[] { 123, 321, 147, 741 })]

        public void DeleteTest(int[] array, int[] expArray)
        {
            ArrayList expected = new ArrayList(expArray);
            ArrayList actual = new ArrayList(array);
            actual.Delete();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { }, 5)]
        [TestCase(new int[] { 3, 2, 1, 0 }, new int[] { 3, 2, 1, }, 1)]
        [TestCase(new int[] { 123, 321, 147, 741, 987 }, new int[] { 123, 321, }, 3)]

        public void DeleteTest(int[] array, int[] expArray, int count)
        {
            ArrayList expected = new ArrayList(expArray);
            ArrayList actual = new ArrayList(array);
            actual.Delete(count);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 })]
        [TestCase(new int[] { 10, 20, 30, 40, 50 }, new int[] { 20, 30, 40, 50 })]
        [TestCase(new int[] { -15, -30, -45, -60, -80, -100 }, new int[] { -30, -45, -60, -80, -100 })]

        public void DeleteFirstTest(int[] array, int[] expArray)
        {
            ArrayList expected = new ArrayList(expArray);
            ArrayList actual = new ArrayList(array);
            actual.DeleteFirst();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 3, 4, 5 }, 2)]
        [TestCase(new int[] { 10, 20, 30, 40, 50 }, new int[] { }, 5)]
        [TestCase(new int[] { -15, -30, -45, -60, -80, -100 }, new int[] { -30, -45, -60, -80, -100 }, 1)]

        public void DeleteFirstTest(int[] array, int[] expArray, int count)
        {
            ArrayList expected = new ArrayList(expArray);
            ArrayList actual = new ArrayList(array);
            actual.DeleteFirst(count);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 4, 5 }, 2)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 }, 0)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, }, 4)]

        public void DeleteByIndexTest(int[] array, int[] expArray, int index)
        {
            ArrayList expected = new ArrayList(expArray);
            ArrayList actual = new ArrayList(array);
            actual.DeleteByIndex(index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 4, 5 }, 2, 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { }, 5, 0)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 5 }, 3, 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 5 }, 2, 2)]

        public void DeleteByIndexTest(int[] array, int[] expArray, int count, int index)
        {
            ArrayList expected = new ArrayList(expArray);
            ArrayList actual = new ArrayList(array);
            actual.DeleteByIndex(count, index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 4, 5 }, 3)]
        [TestCase(new int[] { 1, 1, 1, 4, 5 }, new int[] { 1, 1, 4, 5 }, 1)]
        [TestCase(new int[] { 7, 6, 5, 4, 5 }, new int[] { 7, 6, 4, 5 }, 5)]

        public void DeleteByValueTest(int[] array, int[] expArray, int value)
        {

        }
    }
}