using System;
using System.Collections;
/* На вход подается число N.
 * Нужно создать коллекцию из N квадратов последовательного ряда натуральных чисел 
 * и вывести ее на экран дважды. Элементы коллекции разделять пробелом. 
 * Выводы всей коллекции разделять переходом на новую строку.
 * Не хранить всю коллекцию в памяти.
 * 
 * Код, данный в условии, НЕЛЬЗЯ стирать, его можно только дополнять.
 * Не использовать yield и foreach. Не вызывать метод Reset() в классе Program.
 * 
 * Пример входных данных:
 * 3
 * 
 * Пример выходных данных:
 * 1 4 9
 * 1 4 9
 * 
 * В случае ввода некорректных данных выбрасывайте ArgumentException.
*/

namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int num = ParseToInt();
                MyInts myInts = new MyInts(num);
                IEnumerator enumerator = myInts.MyEnumerator(num);
                Iterator(enumerator, num);
                Console.WriteLine();
                Iterator(enumerator, num);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("error");
            }
        }

        //вывод коллекции на экран
        static void Iterator(IEnumerator enumerator, int n)
        {
            for (int i = 0; i < n; i++)
            {
                enumerator.MoveNext();
                Console.Write($"{enumerator.Current}");
                if (i != n - 1) Console.Write(" ");
            }
        }

        //Перевод строки в число с соответствующей проверкой
        public static int ParseToInt()
        {
            string strs = Console.ReadLine();
            int res;
            if (!int.TryParse(strs, out res) || res < 0) throw new ArgumentException();
            return res;
        }
    }

    class MyInts : IEnumerator // НЕ МЕНЯТЬ ЭТУ СТРОКУ
    {
        int N, position;
        public MyInts(int n) { N = n; position = 0; }
        public bool MoveNext()
        {
            if (position < N)
            {
                position++;
                return true;
            }
            Reset();
            return false;
        }

        public void Reset() { position = 1; }

        internal IEnumerator MyEnumerator(int value) { return new MyInts(value); }

        public object Current
        {
            get
            {
                if (position == -1 || position > N) throw new InvalidOperationException();
                return Math.Pow(position, 2);
            }
        }
    }
}