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
            try
            {
                string str = Console.ReadLine();
                int value = 0;
                if (!int.TryParse(str, out value)) throw new ArgumentException();
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

        public static IEnumerable<int> Fibonacci(int maxValue)
        {
            int x0 = 1;
            int x1 = 1;
            if (x0 < maxValue)
            {
                yield return x0;
                int temp = x1;
                x1 += x0;
                x0 = temp;
            }
        }
    }
}
