using System;

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

        public void Add(int value)
        {
            if (_TrueLenght <= Lenght)
            {
                IncreaseLenght();
            }
            _array[Lenght] = value;
            Lenght++;
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

        public void AddElByIndex(int value, int index)
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
            while (newLenght <= Lenght + number)
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
    }
}
