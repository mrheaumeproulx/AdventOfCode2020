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
            var invalidTries = 0;
            while (true)
            {
                Console.WriteLine("Choose a report, 1 for two entries or 2 for three entries");
                var reportChosen = Console.ReadKey();
                Console.WriteLine();
                if (reportChosen.Key == ConsoleKey.D1)
                {
                    GetEntries1();
                    break;
                }
                else if (reportChosen.Key == ConsoleKey.D2)
                {
                    GetEntries2();
                    break;
                }
                else
                {
                    invalidTries++;
                    if (invalidTries == 2)
                    {
                        Console.WriteLine("You are a lost cause, closing this program for you");
                        break;
                    }
                    Console.WriteLine("Invalid key, please try again");
                }
            }

            Console.ReadKey();
        }

        public static void GetEntries1()
        {
            var entries = GetExpenses();

            for (int i = 0; i < entries.Count(); i++)
            {
                var entry = entries.ElementAt(i);

                if (entries.Any(e => e == (2020 - entry)))
                {
                    var match = entries.First(e => e == (2020 - entry));
                    Console.WriteLine($"Two entries found: {entry} + {match} = 2020");
                    Console.WriteLine($"The answer is {entry * match}");
                }
            }
            Console.WriteLine("There are no entries that sums to 2020");
        }

        private static void GetEntries2()
        {
            var entries = GetExpenses().ToArray();

            for (int i = 0; i < entries.Length - 2; i++)
            {
                for (int j = i + 1; j < entries.Length - 1; j++)
                {
                    for (int k = j + 1; k < entries.Length; k++)
                    {
                        if (entries[i] + entries[j] + entries[k] == 2020)
                        {
                            Console.WriteLine($"Two entries found: {entries[i]} + {entries[j]} + {entries[k]} = 2020");
                            Console.WriteLine($"The answer is {entries[i] * entries[j] * entries[k]}");
                            break;
                        }
                    }
                }
            }
        }

        private static IEnumerable<int> GetExpenses()
            => File.ReadAllLines("Expenses.txt").Select(line => int.Parse(line));
    }
}
