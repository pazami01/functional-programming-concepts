using System;
using System.Collections.Generic;
using System.Linq;

namespace QuestionSeven
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        public static void Run()
        {
            Func<string, int, bool> isLessOrEqualLen = (str, len) => str.Length <= len;

            var maxLength = int.Parse(Read("Enter a number representing the maximum word length: "));
            var names = Read("Enter a list of names separated by spaces: ").Split(' ');

            var filteredNames = Filter(names, maxLength, isLessOrEqualLen);

            Print(filteredNames);
        }

        public static string Read(string message)
        {
            Console.Write(message);

            return Console.ReadLine();
        }

        public static void Print<T>(IEnumerable<T> collection)
            => collection.ToList().ForEach(item => Console.WriteLine(item));

        public static IEnumerable<T1> Filter<T1, T2>
            (IEnumerable<T1> list, T2 match, Func<T1, T2, bool> pred)
        {
            var result = new List<T1>();

            foreach (var item in list)
            {
                if (pred(item, match))
                {
                    result.Add(item);
                }
            }

            return result;
        }
    }
}
