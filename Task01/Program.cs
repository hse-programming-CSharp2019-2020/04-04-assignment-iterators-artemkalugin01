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
                int value;
                //Проверка введённого пользователем числа
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

        //Построение чисел Фиббоначи до введённого пользователем 
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
                if (c >= maxValue)
                    yield break;
                yield return c;
            }
        }
    }
}