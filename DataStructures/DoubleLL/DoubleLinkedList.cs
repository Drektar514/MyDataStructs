using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.DoubleLL
{
    class DoubleLinkedList
    {
        public int Length { get; private set; }

        private DoubleNode _root;

        public DoubleLinkedList()
        {
            Length = 0;
            _root = null;
        }
        public DoubleLinkedList(int[] array)
        {
            Length = array.Length;
            if (array.Length != 0)
            {
                _root = new DoubleNode(array[0]);
                DoubleNode tmp = _root;
                for (int i = 1; i < array.Length; i++)
                {
                    tmp.Next = new DoubleNode(array[i]);
                    if(i == 1)
                    {
                        tmp.Previous = _root;
                    }
                    else
                    tmp = tmp.Next;
                }
            }
            else
            {
                _root = null;
            }
        }
    }
}
