using System;
using System.Text;
using NUnit.Framework;
using DataStructures;

namespace NUnitTestProject1
{
    class LinkedListTests
    {
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 3)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 5)]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, 4, -5)]
        [TestCase(new int[] { 1 }, 0, 1)]
        public void GetByIndexTest(int[] array, int index, int expected)
        {
            LinkedList linkedList = new LinkedList(array);

            int actual = linkedList[index];

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, int.MaxValue, new int[] { int.MaxValue, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 10, new int[] { 1, 2, 10, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, -9, new int[] { 1, 2, 3, 4, -9 })]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, 4, -100, new int[] { -1, -2, -3, -4, -100 })]
        [TestCase(new int[] { 1 }, 0, 0, new int[] { 0 })]
        public void SetByIndex(int[] array, int index, int value, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual[index] = value;

            Assert.AreEqual(expected, actual);

        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, int.MaxValue, new int[] { int.MaxValue, 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 10, new int[] { 1, 2, 10, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, -9, new int[] { 1, 2, 3, 4, -9, 5 })]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, 4, -100, new int[] { -1, -2, -3, -4, -100, -5 })]
        [TestCase(new int[] { 1 }, 0, 0, new int[] { 0, 1 })]
        [TestCase(new int[] { }, 0, 0, new int[] { 0 })]
        public void AddByIndex(int[] array, int index, int value, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.AddByIndex(index, value);

            Assert.AreEqual(expected, actual);

        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, -1, 15)]
        [TestCase(new int[] { }, 1, 789)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 26, 410)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 6, 20)]

        public void NegativeAddByIndexTest(int[] array, int index, int value)
        {
            LinkedList actual = new LinkedList(array);
            try
            {
                actual.AddByIndex(index, value);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [TestCase(new int[] { }, 20, new int[] { 20 })]
        [TestCase(new int[] { 0 }, 25, new int[] { 0, 25 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 6, new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { int.MinValue, 2, 3, 4, 5 }, int.MaxValue, new int[] { int.MinValue, 2, 3, 4, 5, int.MaxValue })]

        public void AddTest(int[] array, int value, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.Add(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, new int[] { 20 }, new int[] { 20 })]
        [TestCase(new int[] { }, new int[] { }, new int[] { })]
        [TestCase(new int[] { 0, 1, 2 }, new int[] { 3, 4, 5 }, new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 3, 4, 5 }, new int[] { 0, 1, 2, 3, 4, 5, 3, 4, 5 })]

        public void AddArrayTest(int[] array, int[] addArray, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.Add(addArray);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, 20, new int[] { 20 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, int.MinValue, new int[] { int.MinValue, 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, int.MaxValue, new int[] { int.MaxValue, 1, 2, 3, 4, 5, 6 })]

        public void AddFirstTest(int[] array, int value, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.AddFirst(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, new int[] { }, new int[] { })]
        [TestCase(new int[] { }, new int[] { 20 }, new int[] { 20 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { -2, -1, 0 }, new int[] { -2, -1, 0, 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 99, 98, 97, 96, 95, 94 }, new int[] { 99, 98, 97, 96, 95, 94, 1, 2, 3, 4, 5 })]

        public void AddFirstArrayTest(int[] array, int[] addArray, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.AddFirst(addArray);
            Assert.AreEqual(expected, actual);
        }
    }
}