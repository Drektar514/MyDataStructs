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
            _array = array;
            Lenght = array.Length;
        }

        public void Add(int value)
        {
            if (_TrueLenght <= Lenght)
            {
                IncreaseLenght();
            }
            _array[Lenght] = value;
            Lenght++;
        }

        public void Add(int[] array)
        {
            while (array.Length + Lenght > _array.Length)
            {
                IncreaseLenght();
            }
            int[] tempArray = new int[_TrueLenght];
            for (int i = 0; i < Lenght; i++)
            {
                tempArray[i] = _array[i];
            }
            for (int i = 0; i < array.Length; i++)
            {
                tempArray[Lenght + i] = array[i];
                
            }
            Lenght += array.Length;
            _array = tempArray;
        }
        
        public void AddFirst(int[] array)
        {
            while (array.Length + Lenght > _array.Length)
            {
                IncreaseLenght();
            }
            int[] tempArray = new int[_TrueLenght];
            for (int i = 0; i < Lenght; i++)
            {
                tempArray[array.Length + i] = _array[i];
            }
            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }
            Lenght += array.Length;
            _array = tempArray;
        }

        public void AddByIndex(int[] array, int index)
        {
            while (array.Length + Lenght > _array.Length)
            {
                IncreaseLenght();
            }
            int[] tempArray = new int[_TrueLenght];
            for (int i = 0; i < index; i++)
            {
                tempArray[i] = _array[i];
            }
            for (int i = 0; i < array.Length; i++)
            {
                tempArray[index + i] = array[i];
            }
            for (int i =index + array.Length ; i <array.Length + Lenght ; i++)
            {
                tempArray[i] = _array[i - array.Length];
            }
            Lenght += array.Length;
            _array = tempArray;
        }

        public void AddFirst(int value)
        {
            if (_TrueLenght <= Lenght)
            {
                IncreaseLenght();
            }
            int[] tempArray = new int[_array.Length];
            for (int i = 0; i < Lenght; i++)
            {
                tempArray[i + 1] = _array[i];
            }
            tempArray[0] = value;
            _array = tempArray;
            Lenght++;
        }

        public void AddByIndex(int value, int index)
        {
            if (_TrueLenght <= Lenght)
            {
                IncreaseLenght();
            }

            int[] tempArray = new int[_array.Length];
            for (int i = 0; i < index; i++)
            {
                tempArray[i] = _array[i];
            }
            for (int i = index; i < Lenght; i++)
            {
                tempArray[i + 1] = _array[i];
            }
            tempArray[index] = value;
            _array = tempArray;
            Lenght++;
        }

        public void Delete()
        {
            if (Lenght <= 0)
            {
                throw new Exception("Can't delete nothing");
            }
            else if (_TrueLenght > Lenght - 1)
            {
                DecreaseLength();
            }

            int[] tempArray = new int[_array.Length];
            for (int i = 0; i < Lenght - 1; i++)
            {
                tempArray[i] = _array[i];
            }
            _array = tempArray;
            Lenght--;
        }

        public void Delete(int count)
        {
            if (Lenght <= 0)
            {
                throw new Exception("Can't delete nothing");
            }
            else if (_TrueLenght > Lenght - 1)
            {
                DecreaseLength();
            }
            if (count <= 0)
            {
                throw new Exception("Please enter a positive number");
            }
            while (count != 0)
            {
                Delete();
                count--;
            }
        }

        public void DeleteFirst(int count)
        {
            if (Lenght <= 0)
            {
                throw new Exception("Can't delete nothing");
            }
            else if (_TrueLenght > Lenght - 1)
            {
                DecreaseLength();
            }
            if (count <= 0)
            {
                throw new Exception("Please enter a positive number");
            }
            while (count != 0)
            {
                DeleteFirst();
                count--;
            }
        }

        public void DeleteByIndex(int count,int index)
        {
            if (Lenght <= 0)
            {
                throw new Exception("Can't delete nothing");
            }
            else if (_TrueLenght > Lenght - 1)
            {
                DecreaseLength();
            }
            if (count <= 0)
            {
                throw new Exception("Please enter a positive number");
            }
            while(count != 0)
            {
                DeleteByIndex(index);
                count--;
            }
        }

        public void DeleteFirst()
        {
            if (Lenght <= 0)
            {
                throw new Exception("Can't delete nothing");
            }
            else if (_TrueLenght > Lenght - 1)
            {
                DecreaseLength();
            }

            int[] tempArray = new int[_TrueLenght];
            for (int i = 0; i < Lenght; i++)
            {
                tempArray[i] = _array[i + 1];
            }
            _array = tempArray;
            Lenght--;
        }

        public void DeleteByIndex(int index)
        {
            if (Lenght <= 0)
            {
                throw new Exception("Can't delete nothing");
            }
            else if (_TrueLenght > Lenght - 1)
            {
                DecreaseLength();
            }
            int[] tempArray = new int[_TrueLenght];
            for (int i = 0; i < index; i++)
            {
                tempArray[i] = _array[i];
            }
            for (int i = index+1; i < Lenght; i++)
            {
                tempArray[i - 1] = _array[i];
            }
            _array = tempArray;
            Lenght--;
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
                throw new Exception("Index outside the array ");
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
            int[] tempArray = new int[_array.Length];
            for (int i = 1; i <= Lenght ; i++)
            {
                tempArray[i-1] = _array[Lenght -i];
            }
            _array = tempArray;
        }

        public void ShowList()
        {
            for (int i = 0; i < _array.Length; i++)
            {
                Console.Write(_array[i] + " ");
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
            int newLenght = _TrueLenght;
            while (newLenght * 0.75 >= Lenght)
            {
                newLenght = (int)(newLenght - number);
            }
            int[] tempArray = new int[newLenght];
            Array.Copy(_array, tempArray, newLenght);
            _array = tempArray;
        }

        public override bool Equals(object obj)
        {
            return obj is ArrayList list &&
                   Lenght == list.Lenght &&
                   EqualityComparer<int[]>.Default.Equals(_array, list._array) &&
                   _TrueLenght == list._TrueLenght;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Lenght, _array, _TrueLenght);
        }
    }
}
