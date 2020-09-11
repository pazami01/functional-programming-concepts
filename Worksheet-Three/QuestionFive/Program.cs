using System;
using System.Collections.Generic;
using System.Linq;

namespace QuestionFive
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Run();
        }

        public static void Run()
        {
            var rawNumbers = Read("Enter a collection of integers separated by spaces: ");
            var commands = ReadWhile("Enter a command ('add', 'multiply', 'subtract', 'print', or 'end' to stop): ", "end");
            
            var numbers = rawNumbers
                .Split(' ')
                .Select(number => int.Parse(number));

            foreach (var command in commands)
            {
                numbers = command switch
                {
                    "add" => AddOne(numbers),
                    "multiply" => MultiplyByTwo(numbers),
                    "subtract" => SubtractOne(numbers),
                    _ => numbers
                };

                if (command.Equals("print")) Print(numbers);
            }
        }

        public static string Read(string message)
        {
            Console.WriteLine(message);

            return Console.ReadLine();
        }

        public static IEnumerable<string> ReadWhile(string message, string endFlag)
        {
            var result = new List<string>();

            string input;

            do
            {
                input = Read(message);
                result.Add(input);

            } while (!input.Equals(endFlag));

            return result;
        }

        public static IEnumerable<int> AddOne(IEnumerable<int> numbers)
            => numbers.Select(number => number + 1);

        public static IEnumerable<int> MultiplyByTwo(IEnumerable<int> numbers)
            => numbers.Select(number => number * 2);

        public static IEnumerable<int> SubtractOne(IEnumerable<int> numbers)
            => numbers.Select(number => number - 1);

        public static void Print<T>(IEnumerable<T> collection)
            => collection.ToList().ForEach(item => Console.Write($"{item} "));
    }
}
