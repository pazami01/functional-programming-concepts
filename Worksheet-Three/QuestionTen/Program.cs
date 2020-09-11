using System;
using System.Collections.Generic;
using System.Linq;

namespace QuestionTen
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Run();
        }

        public static void Run()
        {
            Func<string, string, bool> startsWith = (str, subStr) => str.StartsWith(subStr);
            Func<string, string, bool> endsWith = (str, subStr) => str.EndsWith(subStr);
            Func<string, int, bool> isSameLen = (str, len) => str.Length == len;

            var rawNames = Read("Enter the names of all the people that are coming to the party (separated by spaces):");
            var names = rawNames.Split(' ');
            var rawCommands = ReadWhile("Enter commands to remove or double names on the list (\"Party!\" to stop):", "Party!");

            IEnumerable<string> updateNames = new List<string>(names);
            
            foreach (var rawCommand in rawCommands)
            {
                var command = rawCommand.Split(' ');

                if (command[0].Equals("Remove"))
                {
                    updateNames = command[1].Equals("StartsWith")
                        ? RemoveMatch(updateNames, command[2], startsWith)
                        : command[1].Equals("EndsWith")
                        ? RemoveMatch(updateNames, command[2], endsWith)
                        : RemoveMatch(updateNames, int.Parse(command[2]), isSameLen);
                } else if (command[0].Equals("Double"))
                {
                    updateNames = command[1].Equals("StartsWith")
                        ? DoubleMatch(updateNames, command[2], startsWith)
                        : command[1].Equals("EndsWith")
                        ? DoubleMatch(updateNames, command[2], endsWith)
                        : DoubleMatch(updateNames, int.Parse(command[2]), isSameLen);
                }
            }

            Print(updateNames.ToList(), "are going to the party!");
        }

        public static void Print<T>(List<T> list, string outputTail)
        {
            for (int i = 0; i < list.Count(); i++)
            {
                Console.Write(list[i]);

                if (i != list.Count() -1)
                {
                    Console.Write(", ");
                }
            }

            Console.Write($" {outputTail}");
        }

        public static string Read(string prompt)
        {
            Console.WriteLine(prompt);

            return Console.ReadLine();
        }

        public static IEnumerable<string> ReadWhile(string prompt, string endTrigger)
        {
            var result = new List<string>();

            var input = String.Empty;

            while (!input.Equals(endTrigger))
            {
                Console.WriteLine(prompt);

                input = Console.ReadLine();

                result.Add(input);
            }

            return result;
        }

        /// <summary>
        /// Returns a new collection that excludes any items that matched the criteria.
        /// </summary>
        public static IEnumerable<T1> RemoveMatch<T1, T2>(IEnumerable<T1> list, T2 match, Func<T1, T2, bool> pred)
            => list.Where(item => !pred(item, match));

        /// <summary>
        /// Returns a new collection that doubles any items that matched the criteria.
        /// </summary>
        public static IEnumerable<T1> DoubleMatch<T1, T2>(IEnumerable<T1> list, T2 match, Func<T1, T2, bool> pred)
        {
            var newList = new List<T1>();

            foreach (var item in list)
            {
                if (pred(item, match))
                {
                    newList.Add(item);
                }

                newList.Add(item);
            }

            return newList;
        }
    }
}
