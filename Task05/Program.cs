using System;
using System.Collections;

/* На вход подается число N. 
* Нужно создать коллекцию из N элементов последовательного ряда натуральных чисел, возведенных в 10 степень, 
* и вывести ее на экран ТРИЖДЫ. Инвертировать порядок элементов при каждом последующем выводе. 
* Элементы коллекции разделять пробелом. 
* Очередной вывод коллекции разделять переходом на новую строку. 
* Не хранить всю коллекцию в памяти. 
* 
* Код, данный в условии, НЕЛЬЗЯ стирать, его можно только дополнять. 
* Не использовать yield и foreach. Не вызывать метод Reset() в классе Program. 
* 
* Пример входных данных: 
* 2 
* 
* Пример выходных данных: 
* 1 1024 
* 1024 1 
* 1 1024 
* 
* В случае ввода некорректных данных выбрасывайте ArgumentException. 
* В других ситуациях выбрасывайте 
*/
namespace Task05
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int num = ParseToInt();
                MyDigits numbers = new MyDigits(num);
                IEnumerator enumerator = numbers.MyEnumerator(num);
                Iterator(enumerator, num);
                Console.WriteLine();
                Iterator(enumerator, num);
                Console.WriteLine();
                Iterator(enumerator, num);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("error");
            }
            catch (ArithmeticException)
            {
                Console.WriteLine("ooops");
            }
        }

        //вывод на экран последовательности
        static void Iterator(IEnumerator enumerator, int n)
        {
            for (int i = 0; i < n; i++)
            {
                enumerator.MoveNext();
                Console.Write($"{enumerator.Current}");
                if (i != n - 1)
                    Console.Write(" ");
            }
        }

        //Перевод числа в строки с соответствующими проверками
        public static int ParseToInt()
        {
            string strs = Console.ReadLine();
            int res;
            if (!int.TryParse(strs, out res) || res < 0)
                throw new ArgumentException();
            return res;
        }
    }

    class MyDigits : IEnumerator // НЕ МЕНЯТЬ ЭТУ СТРОКУ 
    {
        int N, position;
        bool isReversed;

        public MyDigits(int n)
        {
            N = n;
            position = 0;
            isReversed = false;
        }

        public bool MoveNext()
        {
            if (isReversed)
            {
                if (position > 1)
                {
                    position--;
                    return true;
                }
                isReversed = false;
                return false;
            }
            else
            {
                if (position < N)
                {
                    position++;
                    return true;
                }
                if (position == N)
                {
                    isReversed = true;
                }
                return false;
            }

        }

        public void Reset()
        {
            position = 1;
        }

        internal IEnumerator MyEnumerator(int value)
        {
            return new MyDigits(value);
        }


        public object Current
        {
            get
            {
                if (position == -1 || position > N)
                    throw new InvalidOperationException();
                return Math.Pow(position, 10);
            }
        }

    }
}