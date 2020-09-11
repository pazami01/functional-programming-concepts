using System;
using System.Collections.Generic;
using System.Linq;

namespace QuestionEight
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Run();
        }

        public static void Run()
        {
            var customComparator = EvensBeforeOddsComparator.GetIcomparerInstance();

            var userInput = Read("Enter a collection of integers separated by spaces:");
            var integers = userInput
                .Split(' ')
                .Select(input => int.Parse(input))
                .ToArray();

            Array.Sort(integers, customComparator);

            Print(integers);
        }

        public static void Print<T>(IEnumerable<T> list)
            => list.ToList().ForEach(item => Console.Write($"{item} "));

        public static string Read(string message)
        {
            Console.WriteLine(message);

            return Console.ReadLine();
        }
    }

    public class EvensBeforeOddsComparator : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x == y)
                return 0;
            
            bool xIsEven = x % 2 == 0;
            bool yIsEven = y % 2 == 0;

            if (xIsEven && !yIsEven)
                return -1;

            if (!xIsEven && yIsEven)
                return 1;

            if (x < y)
                return -1;
            else
                return 1;
        }

        public static IComparer<int> GetIcomparerInstance()
            => new EvensBeforeOddsComparator();
    }
}
