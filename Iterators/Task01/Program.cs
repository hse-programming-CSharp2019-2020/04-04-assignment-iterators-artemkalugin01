using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Необходимо построить ряд чисел Фибоначчи, ограниченный числом, введенным с клавиатуры.
 * 
 * Пример входных данных:
 * 6
 * Пример выходных данных:
 * 1 1 2 3 5
 * Пояснение:
 * следующее число 3 + 5 = 8 не выводится на экран, так как 8 > 6.
 * 
 * В случае ввода некорректных данных выбрасывайте ArgumentException.
 * 
*/
namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            try
            {
                int value;
                if (!int.TryParse(Console.ReadLine(), out value) || value <= 0)
                    throw new ArgumentException();
                foreach (int el in Fibonacci(value))
                {
                    Console.Write(el + " ");
                }
            }
            catch (ArgumentException)
            {
                Console.Write("error");
            }
        }


        //метод перевода строки в число с соответствующими проверками
        public static int ParseToInt()
        {
            string strs = Console.ReadLine();
            int res;
            if (!int.TryParse(strs, out res) ||  res < 0)
                throw new ArgumentException();
            return res;
        }

        //метод расчёта чисел Фиббоначи
        public static IEnumerable<int> Fibonacci(int maxValue)
        {
            int a = 1;
            int b = 0;
            int c = a + b;
            while (c < maxValue)
            {
                c = a + b;
                a = b;
                b = c;
                if (c > maxValue)
                    yield break;
                yield return c;
            }
        }
    }
}
