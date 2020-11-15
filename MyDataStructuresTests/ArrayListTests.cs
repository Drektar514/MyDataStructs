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

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4, 10 }, new int[] { 10 })]
        [TestCase(new int[] { 10, 20, 30, 40 }, new int[] { 10, 20, 30, 40, 50, 60 }, new int[] { 50, 60 })]
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

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4})]
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
        [TestCase(new int[] { 3, 2, 1, 0 }, new int[] { 3, 2, 1 }, 1)]
        [TestCase(new int[] { 123, 321, 147, 741, 987 }, new int[] { 123, 321}, 3)]

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

        public void DeleteByValueFirstTest(int[] array, int[] expArray, int value)
        {
            ArrayList expected = new ArrayList(expArray);
            ArrayList actual = new ArrayList(array);
            actual.DeleteByValueFirst(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 4, 5 }, 3)]
        [TestCase(new int[] { 1, 1, 1, 4, 5 }, new int[] {4, 5}, 1)]
        [TestCase(new int[] { 7, 6, 5, 4, 5 }, new int[] { 7, 6, 4 }, 5)]

        public void DeleteByValueTest(int[] array, int[] expArray, int value)
        {
            ArrayList expected = new ArrayList(expArray);
            ArrayList actual = new ArrayList(array);
            actual.DeleteByValue(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 },4,5)]
        [TestCase(new int[] { 95, 21, 35},0,95)]
        [TestCase(new int[] {150,200,305,123,546,789},3,123)]

        public void AccessByIndex(int[] array,int index,int expected)
        {
            ArrayList arrayList = new ArrayList(array);
            int actual = arrayList.AccessByIndex(index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1, 0 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4}, new int[] {4, 3, 2, 1, 0 })]
        [TestCase(new int[] {99,98,97}, new int[] {97,98,99})]

        public void ReversTest(int[] array,int[] expArray)
        {
            ArrayList expected = new ArrayList(expArray);
            ArrayList actual = new ArrayList(array);
            actual.Revers();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 },0,0)]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 },5,5)]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 },3,3)]
        [TestCase(new int[] { 99,98,97,94,92,90 },98,1)]

        public void FindIndexByNumberTest(int[] array,int number, int expected)
        {
            ArrayList arrayList = new ArrayList(array);
            int actual = arrayList.FindIndexByNumber(number);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 2, 5, 8, 6, 4, 1, 90 }, 90)]
        [TestCase(new int[] { 0, 2, 5, 95, 6, 4, 1, 90 }, 95)]
        [TestCase(new int[] {0}, 0)]

        public void FindMaxTest(int[] array, int expected)
        {
            ArrayList arrayList = new ArrayList(array);
            int actual = arrayList.FindMax();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 2, 5, 8, 6, 4, 1, 90 }, 0)]
        [TestCase(new int[] { 2, 5, 95, 6, 4, 1, 90 }, 1)]
        [TestCase(new int[] { 90,91 }, 90)]

        public void FindMinTest(int[] array, int expected)
        {
            ArrayList arrayList = new ArrayList(array);
            int actual = arrayList.FindMin();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 2, 5, 8, 6, 4, 1, 90, 0 }, 7)]
        [TestCase(new int[] { 2, 5, 95, 6, 4, 1, 90 }, 5)]
        [TestCase(new int[] { 90, 91 }, 0)]
        [TestCase(new int[] {}, 0)]

        public void FindMinIndexTest(int[] array, int expected)
        {
            ArrayList arrayList = new ArrayList(array);
            int actual = arrayList.FindMinIndex();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 2, 5, 8, 6, 4, 1, 90 }, 7)]
        [TestCase(new int[] { 0, 2, 5, 95, 6, 4, 1, 90 }, 3)]
        [TestCase(new int[] { 0 }, 0)]
        [TestCase(new int[] {}, 0)]

        public void FindMaxIndexTest(int[] array, int expected)
        {
            ArrayList arrayList = new ArrayList(array);
            int actual = arrayList.FindMaxIndex();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 3, 2, 5, 4, 6, 7, 1, 0 }, new int[] { 0, 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 9, 8, 7, 6, 5 }, new int[] { 5, 6, 7, 8, 9 })]
        [TestCase(new int[] { int.MaxValue, int.MinValue }, new int[] { int.MinValue, int.MaxValue })]

        public void SortAscendingTest(int[] array, int[] expArray)
        {   
            ArrayList expected = new ArrayList(expArray);
            ArrayList actual = new ArrayList(array);
            actual.SortAscending();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 3, 2, 5, 4, 6, 7, 1, 0 }, new int[] { 7,6,5,4,3,2,1,0 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 9, 8, 7, 6, 5 }, new int[] { 9,8,7,6,5 })]
        [TestCase(new int[] { 0,10,20,30,40,50,60,70,80,90 }, new int[] {90,80,70,60,50,40,30,20,10,0})]
        [TestCase(new int[] {int.MinValue, int.MaxValue, int.MinValue }, new int[] {int.MaxValue, int.MinValue, int.MinValue })]

        public void SortDescendingTest(int[] array, int[] expArray)
        {
            ArrayList expected = new ArrayList(expArray);
            ArrayList actual = new ArrayList(array);
            actual.SortDescending();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 3, 2, 5, 4, 6, 7, 1, 0 }, new int[] { 0, 2, 5, 4, 6, 7, 1, 0 }, 0,0)]
        [TestCase(new int[] { 9, 8, 7, 6, 5 }, new int[] { 9, 8, 7, 6, 30 },4,30)]
        [TestCase(new int[] { 0, 10, 20, 30, 40, 50, 60, 70, 80, 90 }, new int[] { 0, 10, 20, 30, 40, 99, 60, 70, 80, 90 },5,99)]
        [TestCase(new int[] { int.MinValue, int.MaxValue, int.MinValue }, new int[] { int.MinValue, 0, int.MinValue },1,0)]

        public void ChangeValueByIndexTest(int[] array, int[] expArray, int index, int value)
        {
            ArrayList expected = new ArrayList(expArray);
            ArrayList actual = new ArrayList(array);
            actual.ChangeValueByIndex(index, value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] {1,2,3}, new int[] {0,1,2,3 },-1,0)]
        [TestCase(new int[] {1,2,3}, new int[] {1,2,3,0,0,0,0,5 },7,5)]
        [TestCase(new int[] {}, new int[] {99},0,99)]

        public void NegativeChangeValueByIndexTest(int[] array, int[] expArray, int index, int value)
        {
            ArrayList expected = new ArrayList(expArray);
            ArrayList actual = new ArrayList(array);
            try
            { 
            actual.ChangeValueByIndex(index, value);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] {1, 2, 3 },5)]
        [TestCase(new int[] { 1, 2, 3 }, new int[] {1, 2, 3 },-1)]
        [TestCase(new int[] {}, new int[] {},0)]

        public void NegativeDeleteTest(int[] array, int[] expArray, int count)
        {
            ArrayList expected = new ArrayList(expArray);
            ArrayList actual = new ArrayList(array);
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

    }
}