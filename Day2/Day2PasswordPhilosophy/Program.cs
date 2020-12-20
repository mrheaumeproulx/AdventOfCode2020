using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day2PasswordPhilosophy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Validating password...");
            var inputs = GetInputs();
            var numberOfPasswords = inputs.Where(p => p.IsPasswordValid()).Count();
            Console.WriteLine($"There are a total of {numberOfPasswords} valid passwords");

            numberOfPasswords = inputs.Where(p => p.IsPasswordPositionValid()).Count();
            Console.WriteLine($"Number of password based on positions: {numberOfPasswords}");
        }

        private static IEnumerable<Password> GetInputs()
        {
            using var reader = new StreamReader("Input.txt");
            string line;
            while((line = reader.ReadLine()) != null)
            {
                var lineParts = line.Split(' ');
                var conditions = lineParts[0].Split('-');
                yield return new Password
                {
                    MinimumOccurence = int.Parse(conditions[0]),
                    MaximumOccurence = int.Parse(conditions[1]),
                    Letter = lineParts[1][0],
                    Input = lineParts[2]
                };
            }
        }

        private class Password
        {
            public int MinimumOccurence { get; set; }
            public int MaximumOccurence { get; set; }
            public char Letter { get; set; }
            public string Input { get; set; }

            internal bool IsPasswordValid()
            {
                var count = Input.Where(input => input == Letter).Count();
                return count >= MinimumOccurence && count <= MaximumOccurence;
            }

            internal bool IsPasswordPositionValid()
            {
                var position1 = MinimumOccurence - 1;
                var position2 = MaximumOccurence - 1;

                if ((Input[position1] == Letter) != (Input[position2] == Letter))
                    return true;

                return false;
            }
        }
    }
}
