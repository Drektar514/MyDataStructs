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
            myList.AddElByIndex(75, 1);
            myList.ShowList();
        }
    }
}
