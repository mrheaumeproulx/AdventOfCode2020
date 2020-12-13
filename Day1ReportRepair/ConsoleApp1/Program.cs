using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Expenses reports 2020");

            (bool found, int entry1, int entry2) = GetEntries();

            if (found)
            {
                Console.WriteLine($"Two entries found: {entry1} + {entry2} = 2020");
                Console.WriteLine($"The answer is {entry1 * entry2}");
            }
            else
                Console.WriteLine("There are no entries that sums to 2020");

            Console.ReadKey();
        }

        public static (bool found, int entry1, int entry2) GetEntries()
        {
            var entries = GetExpenses();

            for (int i = 0; i < entries.Count(); i++)
            {
                var entry = entries.ElementAt(i);

                if (entries.Any(e => e == (2020 - entry)))
                    return (true, entry, entries.First(e => e == (2020 - entry)));
            }

            return (false, 0, 0);
        }

        private static IEnumerable<int> GetExpenses()
        {
            var lines = File.ReadAllLines("Expenses.txt");

            return lines.Select(line => int.Parse(line));
        }
    }
}
