using System;
using System.Text;
using NUnit.Framework;
using DataStructures;

namespace NUnitTestProject1
{
    class DoubleLLTests
    {
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 3)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 5)]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, 4, -5)]
        [TestCase(new int[] { 1 }, 0, 1)]
        public void GetByIndexTest(int[] array, int index, int expected)
        {

            DoubleLinkedList doubleLinkedList = new DoubleLinkedList(array);

            int actual = doubleLinkedList[index];

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, int.MaxValue, new int[] { int.MaxValue, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 10, new int[] { 1, 2, 10, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, -9, new int[] { 1, 2, 3, 4, -9 })]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, 4, -100, new int[] { -1, -2, -3, -4, -100 })]
        [TestCase(new int[] { 1 }, 0, 0, new int[] { 0 })]
        public void SetByIndex(int[] array, int index, int value, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual[index] = value;

            Assert.AreEqual(expected, actual);

        }

        [TestCase(new int[] { }, 20, new int[] { 20 })]
        [TestCase(new int[] { 0 }, 25, new int[] { 0, 25 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 6, new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { int.MinValue, 2, 3, 4, 5 }, int.MaxValue, new int[] { int.MinValue, 2, 3, 4, 5, int.MaxValue })]

        public void AddTest(int[] array, int value, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.Add(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, new int[] { 20 }, new int[] { 20 })]
        [TestCase(new int[] { }, new int[] { }, new int[] { })]
        [TestCase(new int[] { 0, 1, 2 }, new int[] { 3, 4, 5 }, new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 3, 4, 5 }, new int[] { 0, 1, 2, 3, 4, 5, 3, 4, 5 })]

        public void AddArrayTest(int[] array, int[] addArray, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.Add(addArray);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, 20, new int[] { 20 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, int.MinValue, new int[] { int.MinValue, 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, int.MaxValue, new int[] { int.MaxValue, 1, 2, 3, 4, 5, 6 })]

        public void AddFirstTest(int[] array, int value, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.AddFirst(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, new int[] { }, new int[] { })]
        [TestCase(new int[] { }, new int[] { 20 }, new int[] { 20 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { -2, -1, 0 }, new int[] { -2, -1, 0, 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 99, 98, 97, 96, 95, 94 }, new int[] { 99, 98, 97, 96, 95, 94, 1, 2, 3, 4, 5 })]

        public void AddFirstArrayTest(int[] array, int[] addArray, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.AddFirst(addArray);
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
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.AddByIndex(index, value);

            Assert.AreEqual(expected, actual);

        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, -1, 15)]
        [TestCase(new int[] { }, 1, 789)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 26, 410)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 6, 20)]

        public void NegativeAddByIndexTest(int[] array, int index, int value)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
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


        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, new int[] { 1, 2, 3 }, new int[] { 1, 2, 1, 2, 3, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4, 1, 2, 3, 5 })]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, 4, new int[] { 1, 2, 3 }, new int[] { -1, -2, -3, -4, 1, 2, 3, -5 })]
        [TestCase(new int[] { 1 }, 0, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 1 })]
        [TestCase(new int[] { }, 0, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        public void AddByIndexArrayTest(int[] array, int index, int[] arr, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.AddByIndex(index, arr);

            Assert.AreEqual(expected, actual);

        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        [TestCase(new int[] { 1, 2 }, new int[] { 1 })]

        public void DeleteTest(int[] array, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.Delete();
            Assert.AreEqual(expected, actual);

        }

        [TestCase(new int[] { }, new int[] { })]

        public void NegativeDeleteTest(int[] array, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            try
            {
                actual.Delete();
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 3, new int[] { 1, 2, 3, })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 6, new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 2, new int[] { 1, 2, 3, 4, })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 1, new int[] { 1, 2, 3, 4, 5 })]
        public void DeleteCountTest(int[] array, int count, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.Delete(count);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 0, new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, -1, new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { }, 1, new int[] { })]
        [TestCase(new int[] { 0 }, 2, new int[] { })]

        public void NegativeDeleteCountTest(int[] array, int count, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            try
            {
                actual.Delete(count);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [TestCase(new int[] { 0, 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 0 }, new int[] { })]
        [TestCase(new int[] { 5, 6, 7, 8, 9, 7, 1, 3, 5, 7, 89, 2 }, new int[] { 6, 7, 8, 9, 7, 1, 3, 5, 7, 89, 2 })]

        public void DeleteFirstTest(int[] array, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.DeleteFirst();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, new int[] { })]

        public void NegativeDeleteFirstTest(int[] array, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            try
            {
                actual.DeleteFirst();
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [TestCase(new int[] { 0, 1, 2, 3 }, 2, new int[] { 2, 3 })]
        [TestCase(new int[] { 0 }, 1, new int[] { })]
        [TestCase(new int[] { 5, 6, 7, 8, 9, 7, 1, 3, 5, 7, }, 10, new int[] { })]

        public void DeleteFirstTest(int[] array, int count, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.DeleteFirst(count);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0 }, 2, new int[] { })]
        [TestCase(new int[] { 0, 2, 5 }, 4, new int[] { })]
        [TestCase(new int[] { }, 0, new int[] { })]

        public void NegativeDeleteFirstTest(int[] array, int count, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            try
            {
                actual.DeleteFirst(count);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, new int[] { 1, 2, 4, 5 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 0, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 9, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 })]

        public void DeleteByIndexTest(int[] array, int index, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.DeleteByIndex(index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, 3, new int[] { 1, 5 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 0, 9, new int[] { 9 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 9, 1, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 })]

        public void DeleteByIndexTest(int[] array, int index, int count, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.DeleteByIndex(index, count);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 2, 1, 4, 3, 6, 5, 7, 9, 8 }, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [TestCase(new int[] { 0, 10, 20, 30 }, new int[] { 0, 10, 20, 30 })]
        [TestCase(new int[] { 99, 98, 97, 96, 94, 95 }, new int[] { 94, 95, 96, 97, 98, 99 })]

        public void SortAscendingTest(int[] array, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.SortAscending();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 2, 1, 4, 3, 6, 5, 7, 9, 8 }, new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 })]
        [TestCase(new int[] { 0, 10, 20, 30 }, new int[] { 30, 20, 10, 0 })]
        [TestCase(new int[] { 99, 98, 97, 96, 94, 95 }, new int[] { 99, 98, 97, 96, 95, 94 })]

        public void SortDescendingTest(int[] array, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.SortDescending();
            Assert.AreEqual(expected, actual);
        }

    }
}
