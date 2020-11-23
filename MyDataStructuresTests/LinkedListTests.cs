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

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        [TestCase(new int[] { 1, 2 }, new int[] { 1 })]

        public void DeleteTest(int[] array, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.Delete();
            Assert.AreEqual(expected, actual);

        }

        [TestCase(new int[] { }, new int[] { })]


        public void NegativeDeleteTest(int[] array, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
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
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.Delete(count);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 0, new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, -1, new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { }, 1, new int[] { })]
        [TestCase(new int[] { 0 }, 2, new int[] { })]

        public void NegativeDeleteCountTest(int[] array, int count, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
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
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.DeleteFirst();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, new int[] { })]

        public void NegativeDeleteFirstTest(int[] array, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
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
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.DeleteFirst(count);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0 }, 2, new int[] { })]
        [TestCase(new int[] { 0,2,5 }, 4, new int[] { })]
        [TestCase(new int[] {}, 0, new int[] { })]

        public void NegativeDeleteFirstTest(int[] array, int count, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
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

        [TestCase(new int[] {1,2,3,4,5 },2,new int[] {1,2,4,5})]
        [TestCase(new int[] {0,1,2,3,4,5,6,7,8,9},0,new int[] {1,2,3,4,5,6,7,8,9})]
        [TestCase(new int[] {0,1,2,3,4,5,6,7,8,9},9,new int[] {0,1,2,3,4,5,6,7,8})]

        public void DeleteByIndexTest(int[] array, int index, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.DeleteByIndex(index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1,3, new int[] { 1,5 })]
        [TestCase(new int[] { 0,1, 2, 3, 4, 5,6,7,8,9 },0,9,  new int[] { 9 })]
        [TestCase(new int[] { 0,1, 2, 3, 4, 5,6,7,8,9 },9,1,  new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 })]

        public void DeleteByIndexTest(int[] array, int index, int count, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.DeleteByIndex(index,count);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0 },0, 2, new int[] { })]
        [TestCase(new int[] { 0, 2, 5 },1, 4, new int[] { })]
        [TestCase(new int[] { }, 2,3, new int[] { })]
        [TestCase(new int[] { 0, 2, 5 },4,1, new int[] { })]

        public void NegativeDeleteByIndexTest(int[] array,int index, int count, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            try
            {
                actual.DeleteByIndex(index,count);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [TestCase(new int[] { 35 }, 35, 0)]
        [TestCase(new int[] { 35,15,20 }, 15, 1)]
        [TestCase(new int[] { 35,15,20 }, 20, 2)]

        public void ShowIndexByValueTest(int[] array, int value, int expected)
        {
            LinkedList linkedList = new LinkedList(array);
            int actual = linkedList.GetIndexByValue(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 35 }, 34)]
        [TestCase(new int[] { 35,21,45,78 }, 48)]
        [TestCase(new int[] { 35 }, 38)]

        public void NegativeShowIndexByValueTest(int[] array, int value)
        {
            LinkedList linkedList = new LinkedList(array);
            try
            {
                int actual = linkedList.GetIndexByValue(value);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [TestCase(new int[] {0,1,2,3,4,5 }, 4,4)]
        [TestCase(new int[] {0,1,2,3,4,5 }, 5,5)]
        [TestCase(new int[] {10,502,3,4,},0,10)]
        [TestCase(new int[] {10,502,3,4,},1,502)]

        public void GetValueByIndexTest(int[] array, int index, int expected)
        {
            LinkedList linkedList = new LinkedList(array);
            int actual = linkedList.GetValueByIndex(index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 }, -1)]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 }, 6)]

        public void NegativeShowValueByIndexTest(int[] array, int index)
        {
            LinkedList linkedList = new LinkedList(array);
            try
            {
                int actual = linkedList.GetValueByIndex(index);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1, 0 })]
        [TestCase(new int[] { 0, 5 }, new int[] { 5,0 })]
        [TestCase(new int[] { 0, 3, 5 }, new int[] { 5, 3, 0 })]

        public void ReversTest(int[] array, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.Revers();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 }, 5)]
        [TestCase(new int[] { 0, 1, 32, 3, 4, 5 }, 32)]
        [TestCase(new int[] { 99, 1, 32, 3, 4, 5 }, 99)]

        public void FindMaxValueTest(int[] array, int expected)
        {
            LinkedList linkedList = new LinkedList(array);
            int actual = linkedList.FindMaxValue();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 }, 0)]
        [TestCase(new int[] { 0, 1, -32, 3, 4, 5 }, -32)]
        [TestCase(new int[] { 0, 1, 32, 3, 4, -99}, -99)]

        public void FindMinValueTest(int[] array, int expected)
        {
            LinkedList linkedList = new LinkedList(array);
            int actual = linkedList.FindMinValue();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 }, 0)]
        [TestCase(new int[] { 0, 1, -32, 3, 4, 5 }, 2)]
        [TestCase(new int[] { 0, 1, 32, 3, 4, -99 }, 5)]

        public void FindIndexMinValueTest(int[] array, int expected)
        {
            LinkedList linkedList = new LinkedList(array);
            int actual = linkedList.FindIndexMinValue();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 }, 5)]
        [TestCase(new int[] { 0, 1, 32, 3, 4, 5 }, 2)]
        [TestCase(new int[] { 99, 1, 32, 3, 4, 5 }, 0)]

        public void FindIndexMaxValueTest(int[] array, int expected)
        {
            LinkedList linkedList = new LinkedList(array);
            int actual = linkedList.FindIndexMaxValue();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] {0,2,1,4,3,6,5,7,9,8}, new int[] {0,1,2,3,4,5,6,7,8,9})]
        [TestCase(new int[] {0,10,20,30}, new int[] {0,10,20,30})]
        [TestCase(new int[] {99,98,97,96,94,95}, new int[] {94,95,96,97,98,99})]

        public void SortAscendingTest(int[] array, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.SortAscending();
            Assert.AreEqual(expected, actual);
        }

    }
}