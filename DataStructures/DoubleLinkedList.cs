using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class DoubleLinkedList
    {
        public int Length { get; private set; }

        private DoubleNode _root;
        private DoubleNode _tail;

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
                _tail = _root;
                for (int i = 1; i < array.Length; i++)
                {
                    tmp.Next = new DoubleNode(array[i]);
                    if (i == 1)
                    {
                        tmp.Next.Previous = _root;
                    }
                    else
                    {
                        tmp.Next.Previous = tmp;
                    }
                        tmp = tmp.Next;
                    _tail = tmp;
                }
            }
            else
            {
                _root = null;
            }
        }

        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException();
                }
                DoubleNode tmp = _root;
                for (int i = 0; i < index; i++)
                {
                    tmp = tmp.Next;
                }
                return tmp.Value;
            }

            set
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException();
                }
                DoubleNode tmp = _root;
                for (int i = 0; i < index; i++)
                {
                    tmp = tmp.Next;
                }
                tmp.Value = value;
            }
        }

        public void Add(int value)
        {
            if (Length == 0)
            {
                _root = new DoubleNode(value);
                _tail = _root;
            }
            else
            {
                _tail.Next = new DoubleNode(value);
                _tail.Next.Previous = _tail;
                _tail = _tail.Next;
            }
            Length++;
        }
        public void Add(int[] array)
        {
            {
                DoubleNode crnt;
                if (array.Length != 0)
                {
                    if (Length == 0)
                    {
                        _root = new DoubleNode(array[0]);
                        _tail = _root;
                        for (int i = 1; i < array.Length; i++)
                        {
                            _tail.Next = new DoubleNode(array[i]);
                            _tail.Next.Previous = _tail;
                            _tail = _tail.Next;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < array.Length; i++)
                        {
                            crnt = new DoubleNode(array[i]);
                            _tail.Next = crnt;
                            _tail.Next.Previous = _tail;
                            _tail = _tail.Next;
                        }
                    }
                    Length += array.Length;
                }
                else
                {
                    _root = null;
                }
            }
        }


        public override bool Equals(object obj)
        {
            DoubleLinkedList doubleLinkedList = (DoubleLinkedList)obj;

            if (Length != doubleLinkedList.Length)
            {
                return false;
            }

            DoubleNode tmp1 = _root;
            DoubleNode tmp2 = doubleLinkedList._root;

            for (int i = 0; i < Length; i++)
            {
                if (tmp1.Value != tmp2.Value)
                {
                    return false;
                }
                tmp1 = tmp1.Next;
                tmp2 = tmp2.Next;
            }

            tmp1 = _tail;
            tmp2 = doubleLinkedList._tail;

            for (int i = Length-1; i >= 0; i--)
            {
                if (tmp1.Value != tmp2.Value)
                {
                    return false;
                }
                tmp1 = tmp1.Previous;
                tmp2 = tmp2.Previous;
            }

            return true;
        }
        public override string ToString()
        {
            string s = "";

            DoubleNode tmp = _root;
            for (int i = 0; i < Length; i++)
            {
                s += tmp.Value + ";";
                tmp = tmp.Next;
            }
            return s;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
