using System;
using System.Collections.Generic;
using System.Linq;

namespace QuestionNine
{
    static class Program
    {
        public static void Main(string[] args)
        {
            Run();
        }

        public static void Run()
        {
            var minDivident = 0;
            var minDivisor = 0;

            var maxDividendInput = Read($"Enter an integer higher than {minDivident} as the max dividend:");
            var divisorsInput = Read($"Enter a series of integers larger than {minDivisor} that are separated by spaces:");

            var maxDividend = int.Parse(maxDividendInput);
            var divisors = divisorsInput.Split(' ').Select(s => int.Parse(s));

            var result = Filter(Enumerable.Range(minDivident, maxDividend + 1), divisors, IsDivisible);

            Print(result);
        }
        public static string Read(string message)
        {
            Console.WriteLine(message);

            return Console.ReadLine();
        }

        public static void Print<T>(IEnumerable<T> collection)
            => collection.ToList().ForEach(item => Console.Write($"{item} "));

        /// <summary>
        /// Checks if the given dividend is divisible by all given divisors.
        /// </summary>
        public static bool IsDivisible(int dividend, IEnumerable<int> divisors)
            => divisors
            .Where(divisor => dividend % divisor == 0)
            .Count() == divisors.Count();

        /// <summary>
        /// Returns a new filtered list after applying a function to each item
        /// in the first list against all the items in the second list.
        /// </summary>
        public static IEnumerable<T> Filter<T>
            (IEnumerable<T> ls, IEnumerable<T> ls2, Func<T, IEnumerable<T>, bool> func)
            => ls.Where(item => func(item, ls2));

    }
}
