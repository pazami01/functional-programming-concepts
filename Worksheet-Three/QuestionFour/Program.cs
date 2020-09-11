using System;
using System.Collections.Generic;
using System.Linq;

namespace QuestionFour
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Run();
        }

        public static void Run()
        {
            var rawBounds = Read("Enter a lower bound integer followed by an upper bound integer separated by a space: ");
            var command = Read("Enter 'even' for all even numbers or 'odd' for all odd numbers: ");
            var bounds = rawBounds.Split(' '); ;

            var lowerBound = int.Parse(bounds[0]);
            var upperBound = int.Parse(bounds[1]);

            Predicate<int> isEven = number => number % 2 == 0;
            Predicate<int> isOdd = number => number % 2 != 0;

            var filteredNumbers = Filter(Enumerable.Range(lowerBound, upperBound - lowerBound + 1),
                (command.Equals("even") ? isEven : isOdd));

            Print(filteredNumbers);
        }

        public static string Read(string prompt)
        {
            Console.WriteLine(prompt);

            return Console.ReadLine();
        }

        public static void Print<T>(IEnumerable<T> collection)
            => collection.ToList().ForEach(item => Console.Write($"{item} "));

        public static IEnumerable<T> Filter<T>(IEnumerable<T> collection, Predicate<T> pred)
        {
            var result = new List<T>();

            foreach (var item in collection)
            {
                if (pred(item))
                    result.Add(item);
            }

            return result;
        }
    }
}
