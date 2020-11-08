using System;
using DataStructures;

namespace MyDataScructConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList myList = new ArrayList();
            myList.Add(1);
            myList.Add(3);
            myList.Add(6);
            myList.Add(17);
            myList.Add(12);
            myList.Add(15);
            myList.Delete();
            myList.AddFirst(78);
            myList.AddFirst(66);
            myList.ShowList();
            int length = myList.ReturnLength();
            Console.WriteLine($"Длинна массива - {length}");
            myList.AddElByIndex(75, 1);
            myList.DeleteFirst();
            myList.DeleteByIndex(2);
            myList.ShowList();
            length = myList.ReturnLength();
            Console.WriteLine($"Длинна массива - {length}");
            int numbIndex = myList.AccessByIndex(3);
            Console.WriteLine($"Число под индексом 3 - {numbIndex}");
            int indexNumber = myList.FindIndexByNumber(17);
            Console.WriteLine($"Индекс числа 17 - {indexNumber}");
            myList.ChangeValueByIndex(3, 22);
            myList.Add(99);
            myList.Add(99);
            myList.Add(99);
            myList.Add(99);
            myList.Add(77);
            myList.Add(-15);
            myList.ShowList();
            myList.ReversArray();
            Console.WriteLine();
            myList.ShowList();
            int maxEl = myList.FindMaxEl();
            int maxElIndex = myList.FindIndexMaxEl();
            Console.WriteLine();
            Console.WriteLine($"Самое большое значение массива - {maxEl}, индекс эллемента - {maxElIndex}");
            int minEl = myList.FindMinEl();
            int minElIndex = myList.FindIndexMinEl();
            Console.WriteLine($"Самое маленькое значение массива - {minEl}, индекс эллемента - {minElIndex}");
            myList.SortAscending();
            Console.WriteLine();
            myList.ShowList();
            myList.SortDescending();
            Console.WriteLine();
            myList.ShowList();
            Console.WriteLine();
            myList.DeleteByValueFirst(77);
            myList.ShowList();
            Console.WriteLine();
            myList.DeleteByValueAll(99);
            myList.ShowList();
            Console.WriteLine();

        }
    }
}
