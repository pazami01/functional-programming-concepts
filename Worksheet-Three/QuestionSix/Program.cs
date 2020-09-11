using System;
using System.Collections.Generic;
using System.Linq;

namespace QuestionSix
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        public static void Run()
        {
            Func<int, int, bool> isDivisible = (dividend, divisor) => dividend % divisor == 0;

            var rawNumbers = Read("Enter a collection of integers separated by spaces: ");
            var divisor = int.Parse(Read("Enter an integer as the divisor: "));
            var numbers = rawNumbers
                .Split(' ')
                .Select(number => int.Parse(number));

            var filteredNumbers = FilterOutMatches(numbers, divisor, isDivisible);

            Print(filteredNumbers.Reverse());
        }

        public static void Print<T>(IEnumerable<T> collection)
            => collection.ToList().ForEach(item => Console.Write($"{item} "));

        public static string Read(string message)
        {
            Console.WriteLine(message);

            return Console.ReadLine();
        }

        public static IEnumerable<T1> FilterOutMatches<T1, T2>
            (IEnumerable<T1> collection, T2 match, Func<T1, T2, bool> pred)
            => collection.Where(item => !pred(item, match));
    }
}
