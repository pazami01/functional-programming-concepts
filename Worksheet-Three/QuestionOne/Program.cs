using System;
using System.Collections.Generic;
using System.Linq;

namespace QuestionOne
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var strings = Read("Enter a series of strings separated by spaces: ").Split(' ');

            Action<IEnumerable<string>> Print = collection
                => collection.ToList().ForEach(item => Console.WriteLine(item));

            Print(strings);
        }

        public static string Read(string prompt)
        {
            Console.WriteLine(prompt);

            return Console.ReadLine();
        }
    }
}
