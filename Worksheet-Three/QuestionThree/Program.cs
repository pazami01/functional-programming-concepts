using System;
using System.Collections.Generic;
using System.Linq;

namespace QuestionThree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Run();
        }

        public static void Run()
        {
            var rawNumbers = Read("Enter a set of integers separated by spaces: ");
            var numbers = rawNumbers
                .Split(' ')
                .ToList()
                .Select(item => int.Parse(item));

            Func<int, int, int> getSmallest = (numOne, numTwo)
                => numOne < numTwo ? numOne : numTwo;

            Console.WriteLine(Min(numbers, getSmallest));
        }

        public static string Read(string prompt)
        {
            Console.WriteLine(prompt);

            return Console.ReadLine();
        }

        public static T Min<T>(IEnumerable<T> collection, Func<T, T, T> func)
        {
            T result = collection.First();

            foreach (var item in collection)
            {
                result = func(item, result);
            }

            return result;
        }
    }
}
