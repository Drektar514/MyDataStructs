using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class LinkedList
    {
        public int Length { get; private set; }
        private Node _root;

        public LinkedList()
        {
            Length = 0;
            _root = null;
        }
        public LinkedList(int[] array)
        {
            Length = array.Length;

            if (array.Length != 0)
            {
                _root = new Node(array[0]);
                Node tmp = _root;
                for (int i = 1; i < array.Length; i++)
                {
                    tmp.Next = new Node(array[i]);
                    tmp = tmp.Next;
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
                Node tmp = _root;
                for (int i = 0; i < index; i++)
                {
                    tmp = tmp.Next;
                }
                return tmp.Value;
            }

            set
            {
                Node tmp = _root;
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
                _root = new Node(value);
            }
            else
            {
                Node crnt = _root;
                for (int i = 1; i < Length; i++)
                {
                    crnt = crnt.Next;
                }
                Node tmp = new Node(value);
                crnt.Next = tmp;
            }
            Length++;
        }

        public void Add(int[] array)
        {
            Node crnt;
            Node temp;
            if (array.Length != 0)
            {
                if (Length == 0)
                {
                    _root = new Node(array[0]);
                    crnt = _root;
                    for (int i = 1; i < array.Length; i++)
                    {
                        crnt.Next = new Node(array[i]);
                        crnt = crnt.Next;
                    }
                }
                else
                {
                    crnt = _root;
                    for (int i = 1; i < Length; i++)
                    {
                        crnt = crnt.Next;
                    }
                    for (int i = 0; i < array.Length; i++)
                    {
                        temp = new Node(array[i]);
                        crnt.Next = temp;
                        crnt = crnt.Next;
                    }
                }
                Length += array.Length;
            }
            else
            {
                _root = null;
            }
        }

        public void AddFirst(int value)
        {
            if (Length == 0)
            {
                _root = new Node(value);
            }
            else
            {
                Node tmp = new Node(value);
                tmp.Next = _root;
                _root = tmp;
            }
            Length++;
        }

        public void AddFirst(int[] array)
        {
            Node crnt;
            if (array.Length != 0)
            {
                if (Length == 0)
                {
                    _root = new Node(array[0]);
                    crnt = _root;
                    for (int i = 1; i < array.Length; i++)
                    {
                        crnt.Next = new Node(array[i]);
                        crnt = crnt.Next;
                    }
                }
                else
                {
                    crnt = new Node(array[0]);
                    Node tmp = crnt;
                    for (int i = 1; i < array.Length; i++)
                    {
                        crnt.Next = new Node(array[i]);
                        crnt = crnt.Next;
                    }
                    crnt.Next = _root;
                    _root = tmp;
                }
                Length += array.Length;
            }
            else
            {
                _root = null;
            }
        }

        public void AddByIndex(int index, int value)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }
            if (index != 0)
            {
                Node crnt = _root;
                for (int i = 0; i < index - 1; i++)
                {
                    crnt = crnt.Next;
                }
                Node tmp = new Node(value);
                tmp.Next = crnt.Next;
                crnt.Next = tmp;
            }
            else
            {
                Node tmp = new Node(value);
                tmp.Next = _root;
                _root = tmp;
            }
            Length++;
        }

        public void Delete()
        {
            CheckError(Length);
            Node tmp = _root;
            for (int i = 0; i < Length - 1; i++)
            {
                tmp = tmp.Next;
            }
            tmp.Next = null;
            Length--;
        }

        public void Delete(int count)
        {
            CheckError(count);
            Node tmp = _root;
            for (int i = 0; i < Length - count; i++)
            {
                tmp = tmp.Next;
            }
            tmp.Next = null;
            Length -= count;
        }

        public void DeleteFirst()
        {
            CheckError(Length);
            Node tmp = _root;
            _root = tmp.Next;
            tmp.Next = null;
            Length--;
        }

        public void DeleteFirst(int count)
        {
            CheckError(count);
            Node tmp;

            for (int i = 0; i < count; i++)
            {
                tmp = _root;
                _root = tmp.Next;
                tmp.Next = null;
            }
            Length -= count;
        }

        public void DeleteByIndex(int index)
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
                Node tmp = _root;
                for (int i = 0; i != index - 1; i++)
                {
                    tmp = tmp.Next;
                }
                tmp.Next = tmp.Next.Next;
                Length--;
            }
        }

        public void DeleteByIndex(int index, int count)
        {
            CheckError(count);

            if (index == 0)
            {
                DeleteFirst(count);
            }
            else if (index == Length - 1)
            {
                Delete();
            }
            else
            {
                Node tmp = _root;
                for (int i = 0; i != index - 1; i++)
                {
                    tmp = tmp.Next;
                }
                for (int i = 0; i != count; i++)
                {
                    tmp.Next = tmp.Next.Next;
                }
                Length -= count;
            }
        }

        public int GetIndexByValue(int value)
        {
            bool check = false;
            int index = 0;
            Node tmp = _root;
            for (int i = 0; i < Length; i++)
            {
                if (tmp.Value == value)
                {
                    index = i;
                    check = true;
                    break;
                }
                tmp = tmp.Next;
            }
            if (check)
            {
                return index;
            }
            else
            {
                throw new Exception("Index not found");
            }
        }

        public int GetValueByIndex(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }
            int value;
            Node tmp = _root;
            for (int i = 0; i != index; i++)
            {
                tmp = tmp.Next;
            }
            value = tmp.Value;
            return value;
        }

        public void Revers()
        {
            Node oldRoot = _root;
            Node tmp;
            while (oldRoot.Next != null)
            {
                tmp = oldRoot.Next;
                oldRoot.Next = tmp.Next;
                tmp.Next = _root;
                _root = tmp;
            }
        }

        public int FindMaxValue()
        {
            if (Length > 0)
            {
                int value = int.MinValue;
                Node crnt = _root;
                for (int i = 0; i < Length; i++)
                {
                    if (value < crnt.Value)
                    {
                        value = crnt.Value;
                    }
                    crnt = crnt.Next;
                }
                return value;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public int FindMinValue()
        {
            if (Length > 0)
            {
                int value = int.MaxValue;
                Node crnt = _root;
                for (int i = 0; i < Length; i++)
                {
                    if (value > crnt.Value)
                    {
                        value = crnt.Value;
                    }
                    crnt = crnt.Next;
                }
                return value;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public int FindIndexMinValue()
        {
            if (Length > 0)
            {
                int value = int.MaxValue;
                int index = 0;
                Node crnt = _root;
                for (int i = 0; i < Length; i++)
                {
                    if (value > crnt.Value)
                    {
                        value = crnt.Value;
                        index = i;
                    }
                    crnt = crnt.Next;
                }
                return index;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public int FindIndexMaxValue()
        {
            if (Length > 0)
            {
                int value = int.MinValue;
                int index = 0;
                Node crnt = _root;
                for (int i = 0; i < Length; i++)
                {
                    if (value < crnt.Value)
                    {
                        value = crnt.Value;
                        index = i;
                    }
                    crnt = crnt.Next;
                }
                return index;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public void SortAscending()
        {
            for (int i = 1; i < Length ; i++)
            {
            Node crnt = _root;
                for (int j = 0; j < Length -i; j++)
                {
                    if (crnt.Value > crnt.Next.Value)
                    {
                        Swap(crnt, crnt.Next);
                    }
                    crnt = crnt.Next;
                }
            }
        }

        public void SortDescending()
        {
            for (int i = 1; i < Length; i++)
            {
                Node crnt = _root;
                for (int j = 0; j < Length - i; j++)
                {
                    if (crnt.Value < crnt.Next.Value)
                    {
                        Swap(crnt, crnt.Next);
                    }
                    crnt = crnt.Next;
                }
            }
        }

        public void RemoveByValueFirst(int value)
        {
            Node tmp = _root;
            for (int i = 0; i < Length; i++)
            {
                if(tmp.Value == value)
                {
                    DeleteByIndex(i);
                    break;
                }
                tmp = tmp.Next;
            }
        }

        public void RemoveByValueAll(int value)
        {
            Node tmp = _root;
            while (tmp.Next != null)
            {
                if (tmp.Value == value)
                {
                    tmp = tmp.Next;
                    RemoveByValueFirst(value);
                    continue;
                }
                tmp = tmp.Next;
            }
            if (tmp.Value == value)
            {
                tmp = tmp.Next;
                RemoveByValueFirst(value);
            }
        }

        public override bool Equals(object obj)
        {
            LinkedList linkedList = (LinkedList)obj;

            if (Length != linkedList.Length)
            {
                return false;
            }

            Node tmp1 = _root;
            Node tmp2 = linkedList._root;

            for (int i = 0; i < Length; i++)
            {
                if (tmp1.Value != tmp2.Value)
                {
                    return false;
                }
                tmp1 = tmp1.Next;
                tmp2 = tmp2.Next;
            }
            return true;
        }
        public override string ToString()
        {
            string s = "";

            Node tmp = _root;
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

        private void Swap(Node crnt, Node nextCrnt)
        {
            int tmp = crnt.Value;
            crnt.Value = nextCrnt.Value;
            nextCrnt.Value = tmp;
        }
        private void CheckError(int count)
        {
            if (Length <= 0)
            {
                throw new NullReferenceException();
            }
            if (count <= 0)
            {
                throw new Exception("Count can't be less 1");
            }
            if (Length < count)
            {
                throw new Exception("Count bigger than List");
            }
        }

    }
}
