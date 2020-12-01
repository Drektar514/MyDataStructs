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

        public void AddFirst(int value)
        {

            DoubleNode crnt = new DoubleNode(value);
            if (Length != 0)
            {
                crnt.Next = _root;
                _root.Previous = crnt;
                _root = crnt;
            }
            else
            {
                _root = crnt;
                _tail = crnt;
            }
                Length++;
        }

        public void AddFirst(int[] array)
        {
            DoubleNode crnt;
            DoubleNode tmp;
            DoubleNode oldRoot;
            if (array.Length > 0)
            {
                if (Length != 0)
                {
                    oldRoot = _root;
                    crnt = new DoubleNode(array[0]);
                    crnt.Next = _root;
                    _root.Previous = crnt;
                    _root = crnt;
                    for (int i = 1; i < array.Length; i++)
                    {
                        tmp = new DoubleNode(array[i]);
                        crnt.Next = tmp;
                        tmp.Previous = crnt;
                        crnt = tmp;
                    }
                    crnt.Next = oldRoot;
                    oldRoot.Previous = crnt;
                }
                else
                {
                    crnt = new DoubleNode(array[0]);
                    _root = crnt;
                    for (int i = 1; i < array.Length; i++)
                    {
                        tmp = new DoubleNode(array[i]);
                        crnt.Next = tmp;
                        tmp.Previous = crnt;
                        crnt = tmp;
                    }
                    _tail = crnt;
                }
            }
            else
            {
                _root = null;
                _tail = null;
            }
            Length += array.Length;
        }

        public void AddByIndex(int index ,int value)
        {
            if (index >= 0)
            {
                if (index == 0)
                {
                    AddFirst(value);
                }
                else if (index == Length)
                {
                    Add(value);
                }
                else
                {
                    DoubleNode crnt = _root;
                    for (int i = 1; i < index; i++)
                    {
                        crnt = crnt.Next;
                    }
                    DoubleNode tmp = new DoubleNode(value);
                    tmp.Next = crnt.Next;
                    tmp.Previous = crnt;
                    crnt.Next.Previous = tmp;
                    crnt.Next = tmp;
                    Length++;
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void AddByIndex(int index, int[] array)
        {
            if (index == 0)
            {
                AddFirst(array);
            }
            else if (index == Length)
            {
                Add(array);
            }
            else
            {
                DoubleNode crnt = _root;
                DoubleNode oldNext;
                for (int i = 1; i < index; i++)
                {
                    crnt = crnt.Next;
                }
                oldNext = crnt.Next;
                for (int i = 0; i < array.Length; i++)
                {
                    DoubleNode tmp = new DoubleNode(array[i]);
                    crnt.Next = tmp;
                    tmp.Previous = crnt;
                    crnt = tmp;
                }
                crnt.Next = oldNext;
                oldNext.Previous = crnt;
                Length += array.Length;
            }
        }

        public void Delete()
        {
            if (Length > 1)
            {
                _tail = _tail.Previous;
                _tail.Next = null;
                Length--;
            }
            else if(Length == 1)
            {
                _root = null;
                _tail = null;
                Length--;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Delete(int count)
        {
            if(count == 1)
            {
                Delete();
            }
            else if(count > Length || count <= 0)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    _tail = _tail.Previous;
                }
                Length -= count;
            }
        }

        public void DeleteFirst()
        {
            if (Length > 1)
            {
                _root = _root.Next;
                _root.Previous = null;
                Length--;
            }
            else if (Length == 1)
            {
                _root = null;
                _tail = null;
                Length--;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void DeleteFirst(int count)
        {
            if (count == 1)
            {
                DeleteFirst();
            }
            else if (count > Length || count <= 0)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    _root = _root.Next;
                }
                Length -= count;
            }
        }

        public void DeleteByIndex(int index)
        {
            if (index >= 0)
            {
                if (index == 0)
                {
                    DeleteFirst();
                }
                else if (index == Length - 1)
                {
                    Delete();
                }
                else
                {
                    if(index <= Length / 2)
                    {
                    DoubleNode tmp = _root;
                        for (int i = 1; i < index; i++)
                        {
                            tmp = tmp.Next;
                        }
                        tmp.Next = tmp.Next.Next;
                        tmp.Next.Previous = tmp;
                    }
                    else
                    {
                    DoubleNode tmp = _tail;
                        for (int i = Length; i != index; i++)
                        {
                            tmp = tmp.Previous;
                        }
                        tmp.Previous = tmp.Previous.Previous;
                        tmp.Previous.Next = tmp;
                    }
                    Length--;
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void DeleteByIndex(int index, int count)
        {
            if (index >= 0 && count > 0)
            {
                if (index == 0)
                {
                    DeleteFirst(count);
                }
                else if (index == Length - 1)
                {
                    Delete(count);
                }
                else
                {
                    if (index <= Length / 2)
                    {
                        DoubleNode tmp = _root;
                        for (int i = 1; i < index ; i++)
                        {
                            tmp = tmp.Next;
                        }
                        for (int i = 0; i != count; i++)
                        {
                            tmp.Next = tmp.Next.Next;
                        }
                        tmp.Next.Previous = tmp;
                    }
                    else
                    {
                        DoubleNode tmp = _tail;
                        for (int i = Length; i != index; i++)
                        {
                            tmp = tmp.Previous;
                        }
                        for (int i = 0; i !=count -1 ; i++)
                        {
                            tmp.Previous = tmp.Previous.Previous;
                        }
                        tmp.Previous.Next = tmp;
                    }
                    Length -= count;
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
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
        /*Удалить по индексу (массив) 
         *Сортировки возврастиание/убывание
         *Поиск по значению, мин/макс элемент/индекс 
        */
    }
}
