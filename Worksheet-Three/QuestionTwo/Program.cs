using System;
using System.Collections.Generic;
using System.Linq;

namespace QuestionTwo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var names = Read("Enter a series of names separated by spaces: ").Split(' ');

            Action<string> appendSirInFrontAndPrint = str => Console.WriteLine($"Sir {str}");

            names.ToList().ForEach(name => appendSirInFrontAndPrint(name));
        }

        public static string Read(string prompt)
        {
            Console.WriteLine(prompt);

            return Console.ReadLine();
        }
    }
}
