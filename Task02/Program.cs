using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
В основной программе объявите и инициализируйте одномерный строковый массив 
и выполните циклический перебор его элементов с разных «начальных точек», 
разделяя элементы одним пробелом. 

Тестирование приложения выполняется путем запуска разных наборов тестов. 
На вход в первой строке поступает число - номер элемента, начиная с которого 
пойдет циклический перебор. 
В следующей строке указаны элементы последовательности, разделенные одним или 
несколькими пробелами. 
3 
1 2 3 4 5 
Программа должна вывести на экран: 
3 4 5 1 2 

В случае ввода некорректных данных выбрасывайте ArgumentException. 

Никаких дополнительных символов выводиться не должно. 

Код метода Main можно подвергнуть изменениям, но вывод меняться не должен. 

*/
namespace Task02
{
    class IteratorSample : IEnumerable<string> // НЕ МЕНЯТЬ 
    {
        string[] values;
        int start;

        public IteratorSample(string[] values, int start)
        {
            this.values = values;
            this.start = start;
        }
        public IEnumerator GetEnumerator()
        {
            return new IteratorSampleEnumerator(values, start - 2);
        }

        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            throw new ArgumentException();
        }
    }
    class IteratorSampleEnumerator : IEnumerator
    {

        string[] values;
        int position;
        int startposition;
        bool loop;

        public IteratorSampleEnumerator(string[] values, int start)
        {
            this.values = values;
            position = start;
            startposition = start;
            loop = false;
        }

        public object Current
        {
            get
            {
                if (position == -1 || position >= values.Length)
                    throw new ArgumentException();
                return values[position];
            }
        }

        public bool MoveNext()
        {
            if (position != startposition || !loop)
            {
                if (position < values.Length - 1)
                {
                    position++;
                    return true;
                }
                if (position == values.Length - 1)
                {
                    loop = true;
                    position = 0;
                    return true;
                }
                else
                    return false;
            }
            return false;
        }

        public void Reset()
        {
            position = -1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.InputEncoding = Encoding.UTF8;

                int startingIndex = ParseToInt();
                string[] values = Console.ReadLine().Split();
                if (string.IsNullOrWhiteSpace(values[0]) || values.Length < startingIndex)
                    throw new ArgumentException();
                foreach (string ob in new IteratorSample(values, startingIndex))
                    Console.Write(ob + " ");
                Console.WriteLine();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("error");
            }
            catch (Exception e)
            {
                Console.WriteLine("error");
            }

            Console.ReadLine();
        }

        //Преобразование строки в чесло с необходимой проверкой
        public static int ParseToInt()
        {
            string str = Console.ReadLine();
            int num;
            if (!int.TryParse(str, out num))
                throw new ArgumentException();
            return num;
        }
    }
}