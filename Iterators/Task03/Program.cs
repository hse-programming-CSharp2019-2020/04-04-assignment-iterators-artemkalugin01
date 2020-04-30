using System;
using System.Collections;

/* На вход подается число N. 
* На каждой из следующих N строках записаны ФИО человека, 
* разделенные одним пробелом. Отчество может отсутствовать. 
* Используя собственноручно написанный итератор, выведите имена людей, 
* отсортированные в лексико-графическом порядке в формате 
* <Фамилия_с_большой_буквы> <Заглавная_первая_буква_имени>. 
* Затем выведите имена людей в исходном порядке. 
* 
* Код, данный в условии, НЕЛЬЗЯ стирать, его можно только дополнять. 
* Не использовать yield. 
* 
* Пример входных данных: 
* 3 
* Bill Banana Bananovich 
* Alex Apple Applovich 
* Clark Carrot Carratovich 
* 
* Пример выходных данных: 
* Apple A. 
* Banana B. 
* Carrot C. 
* 
* Banana B. 
* Apple A. 
* Carrot C. 
* 
* В случае ввода некорректных данных выбрасывайте ArgumentException. 
*/
namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Person[] people = CreatePeople();
                People peopleList = new People(people);

                foreach (Person p in peopleList)
                    Console.WriteLine(p);

                foreach (Person p in peopleList.GetPeople)
                    Console.WriteLine(p);

            }
            catch (ArgumentException)
            {
                Console.Write("error");
            }
        }
        /// <summary> 
        /// Метод создает массив Person. 
        /// </summary> 
        /// <returns></returns> 
        private static Person[] CreatePeople()
        {
            int N = ParseToInt();
            Person[] people = new Person[N];
            for (int i = 0; i < N; i++)
            {
                string[] strs = Console.ReadLine().Split();
                if (strs.Length <= 1 || String.IsNullOrEmpty(strs[1]))
                    throw new ArgumentException();
                people[i] = new Person(strs[0], strs[1]);
            }

            return people;
        }

        /// <summary> 
        /// Метод превращает строку в int. 
        /// </summary> 
        /// <param name="strs"></param> 
        /// <returns></returns> 
        public static int ParseToInt()
        {
            string strs = Console.ReadLine();
            int res;
            if (!int.TryParse(strs, out res) || res < 0)
                throw new ArgumentException();
            return res;
        }
    }

    public class Person : IComparable
    {
        public string Name;
        public string Surname;

        public Person(string Name, string Surname)
        {
            this.Name = Name;
            this.Surname = Surname;
        }
        public int CompareTo(object o)
        {
            Person p = o as Person;
            if (p != null)
                return string.Compare(this.Name, p.Name, StringComparison.Ordinal);
            else
                throw new Exception("Невозможно сравнить два объекта");
        }
        public override string ToString()
        {
            return $"{Name} {Surname[0]}.";
        }
    }


    public class People : IEnumerable
    {
        private Person[] _people;

        public People(Person[] people)
        {
            _people = people;
        }
        public Person[] GetPeople
        {
            get
            {
                return _people;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public PeopleEnum GetEnumerator()
        {
            return new PeopleEnum(_people);
        }
    }

    public class PeopleEnum : IEnumerator
    {
        int position = -1;
        public Person[] _people;

        public PeopleEnum(Person[] people)
        {
            Person[] newpeople = people;
            Array.Sort(newpeople);
            _people = newpeople;
        }

        public bool MoveNext()
        {
            if (position < _people.Length - 1)
            {
                position++;
                return true;
            }
            else
                return false;
        }

        public void Reset()
        {
            position = -1;
        }

        public Person Current
        {
            get
            {
                if (position == -1 || position >= _people.Length)
                    throw new InvalidOperationException();
                return _people[position];
            }
        }
        object IEnumerator.Current
        {
            get { return Current; }
        }
    }
}