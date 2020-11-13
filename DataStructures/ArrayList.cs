using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class ArrayList
    {
        public int Lenght { get; private set; }

        private int[] _array;
        private int _TrueLenght
        {
            get
            {
                return _array.Length;
            }
        }

        public ArrayList()
        {
            _array = new int[9];
            Lenght = 0;
        }

        public ArrayList(int length)
        {
            _array = new int[length];
            Lenght = 0;
        }

        public ArrayList(int[] array)
        {
            _array = new int[(int)(array.Length * 1.33)];
            for (int i = 0; i < array.Length; i++)
            {
                _array[i] = array[i];
            }
            Lenght = array.Length;
        }

        public void Add(int value)
        {
            Move('+',Lenght);
            _array[Lenght-1] = value;
        }

        public void Add(int[] array)
        {
            Move('+', Lenght, array.Length);
            for (int i = 0; i < array.Length; i++)
            {
                _array[i + Lenght-array.Length] = array[i];
            }
        }
        
        public void AddFirst(int value)
        {
            Move('+');
            _array[0] = value;
        }

        public void AddFirst(int[] array)
        {

            Move('+', arLenght : array.Length);
            for (int i = 0; i < array.Length; i++)
            {
                _array[i] = array[i];
            }
        }

        public void AddByIndex(int value, int index)
        {
            Move('+', index);
            _array[index] = value;
        }

        public void AddByIndex(int[] array, int index)
        {
            Move('+', index, array.Length);
            for (int  i = 0;  i < array.Length;  i++)
            {
                _array[index + i] = array[i];
            }
        }

        public void Delete()
        {
            Move('-',Lenght);
        }

        public void Delete(int count)
        {
            Move('-', Lenght, count);
        }

        public void DeleteFirst()
        {
            Move('-');
        }

        public void DeleteFirst(int count)
        {
            Move('-', arLenght : count);
        }

        public void DeleteByIndex(int index)
        {
            Move('-', index);
        }

        public void DeleteByIndex(int count,int index)
        {
            Move('-', index, count);
        }

        public void DeleteByValueFirst(int value)
        {
           int index = FindIndexByNumber(value);
            DeleteByIndex(index);
        }

        public void DeleteByValue(int value)
        {
            int valueCount = 0;
            for (int i = 0; i < Lenght; i++)
            {
                if(_array[i] == value)
                {
                    valueCount++;
                }
            }
            while (valueCount != 0)
            {
                for (int i = 0; i < Lenght; i++)
                {
                    if(_array[i] == value)
                    {
                        DeleteByIndex(i);
                        valueCount--;
                    }
                }
            }
        }

        public int ReturnLength()
        {
            return _TrueLenght;
        }

        public int AccessByIndex(int index)
        {
            if(index < 0 || index > _array.Length)
            {
                throw new IndexOutOfRangeException();
            }
            int number = _array[index];
            return number;
        }

        public int FindIndexByNumber(int number)
        {
            int index;
            for (int i = 0; i < _array.Length; i++)
            {
                if(_array[i] == number)
                {
                    index = i;
                    return index;
                }
            }
            throw new Exception("Number is not found");
        }

        public int FindMax()
        {
            int max = _array[0];
            for (int i = 0; i < Lenght; i++)
            {
                if (max < _array[i])
                {
                    max = _array[i];
                }
            }
            return max;
        }

        public int FindMin()
        {
            int min = _array[0];
            for (int i = 0; i < Lenght; i++)
            {
                if(min > _array[i])
                {
                    min = _array[i];
                }
            }
            return min;
        }

        public int FindMinIndex()
        {
            int index = 0;
            for (int i = 0; i < Lenght; i++)
            {
                if(_array[index] > _array[i])
                {
                    index = i;
                }
            }
            return index;
        }

        public int FindMaxIndex()
        {
            int index = 0;
            for (int i = 0; i < Lenght; i++)
            {
                if (_array[index] < _array[i])
                {
                    index = i;
                }
            }
            return index;

        }

        public void SortAscending()
        {
            for (int i = Lenght; i > 0; i--)
            {
                int temp;
                for (int j = 0; j < i - 1; j++)
                {
                    int max = _array[j];
                    int min = _array[j + 1];
                    if (max > min)
                    {
                        temp = _array[j];
                        _array[j] = _array[j + 1];
                        _array[j + 1] = temp;
                    }
                }
            }
        }

        public void SortDescending()
        {
            for (int i = 0; i < Lenght; i++)
            {
                int max = _array[i];
                int index = i;
                for (int j = i; j < Lenght; j++)
                {
                    if (max < _array[j])
                    {
                        max = _array[j];
                        index = j;
                    }
                }
                int temp = _array[i];
                _array[i] = max;
                _array[index] = temp;
            }
        }
        public void ChangeValueByIndex(int index, int value)
        {
            if (index >= 0 && index < _array.Length)
            {
                _array[index] = value;
            }
            else
            {
                throw new Exception("Index outside the array");
            }
        }

        public void Revers()
        {
            for (int i = 0; i < Lenght/2 ; i++)
            {
                int a = _array[i];
                _array[i] = _array[Lenght - 1 - i];
                _array[Lenght - 1 - i] = a;
            }
        }

        private void Move(char pointer, int index = 0, int arLenght = 1)
        {
            if (pointer == '+')
            {
                while (Lenght + arLenght >= _array.Length)
                {
                    IncreaseLenght();
                }
                for (int i = arLenght; i > 0; i--)
                {
                    for (int j = Lenght-1; j >=index; j--)
                    {
                        _array[j + 1] = _array[j];
                    }
                    _array[index] = 0;
                    Lenght++;
                }
            }
            else if(pointer == '-')
            {
                if (Lenght <= 0)
                {
                    throw new Exception("Can't delete nothing");
                }
                if(index < 0 || index > Lenght)
                {
                    throw new IndexOutOfRangeException();
                }

                for (int i = arLenght; i > 0 ; i--)
                {
                    for (int j = index; j < Lenght-1; j++)
                    {
                        _array[j] = _array[j + 1];
                    }
                    _array[Lenght - 1] = 0;
                    Lenght--;
                }
                if(_TrueLenght > Lenght - 1)
                {
                    DecreaseLength();
                }
            }
        }
        private void IncreaseLenght(int number = 1)
        {
            int newLenght = _TrueLenght;
            while (newLenght <= _array.Length + number)
            {
                newLenght = (int)(newLenght * 1.33 + 1);
            }

            int[] newArray = new int[newLenght];
            Array.Copy(_array, newArray, _TrueLenght);
            
            _array = newArray;
        }
        private void DecreaseLength(int number = 1)
        {
            int newLenght = _array.Length;
            while (newLenght * 0.75 > Lenght)
            {
                newLenght = (int)(newLenght - number);
            }
            int[] tempArray = new int[newLenght];
            Array.Copy(_array, tempArray, newLenght);
            _array = tempArray;
        }
        public override bool Equals(object obj)
        {
            ArrayList arrayList = (ArrayList)obj;

            if (Lenght != arrayList.Lenght)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < Lenght; i++)
                {
                    if (_array[i] != arrayList._array[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
