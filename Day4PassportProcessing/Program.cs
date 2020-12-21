using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Day4PassportProcessing
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            Console.WriteLine("Day 4 Passport Processing");
            Console.WriteLine("Gathering passports");
            var passports = await GetPassorts();
            Console.WriteLine($"Number of valid passports: {passports.Count(p => p.IsValid())}");
            Console.WriteLine($"Passport : \tbyr \tiyr \teyr \thgt \thcl \tecl \tpid");
            foreach (var passport in passports.Where(p => !p.IsValid()))
            {
                Console.WriteLine($"Passport: byr= {passport.byr} \tiry= {passport.iyr} \teyr= {passport.eyr} \thgt= {passport.hgt} \thcl= {passport.hcl} \tecl= {passport.ecl} \tpid= {passport.pid}");
            }
            return 0;
        }

        static async Task<IEnumerable<Passport>> GetPassorts()
        {
            var passports = new List<Passport>();
            using var reader = new StreamReader("Input.txt");

            var passport = new Passport();
            while (true)
            {
                var line = await reader.ReadLineAsync();
                if (line == null)
                    break;

                if (String.IsNullOrWhiteSpace(line))
                {
                    passports.Add(passport);
                    passport = new Passport();
                    continue;
                }

                passport.MapInput(line.Split(' '));
            }

            return passports;
        }

        internal class Passport
        {
            internal string byr;
            internal string iyr;
            internal string eyr;
            internal string hgt;
            internal string hcl;
            internal string ecl;
            internal string pid;
            internal string cid;

            internal bool IsValid()
            {
                return !String.IsNullOrEmpty(byr)
                    && !String.IsNullOrEmpty(iyr)
                    && !String.IsNullOrEmpty(eyr)
                    && !String.IsNullOrEmpty(hgt)
                    && !String.IsNullOrEmpty(hcl)
                    && !String.IsNullOrEmpty(ecl)
                    && !String.IsNullOrEmpty(pid);
            }

            internal void MapInput(string[] input)
            {
                for (int i = 0; i < input.Length; i++)
                {
                     var pair = input[i].Split(':');
                    var id = pair[0];

                    switch (id)
                    {
                        case "byr":
                            byr = pair[1];
                            break;
                        case "iyr":
                            iyr = pair[1];
                            break;
                        case "eyr":
                            eyr = pair[1];
                            break;
                        case "hgt":
                            hgt = pair[1];
                            break;
                        case "hcl":
                            hcl = pair[1];
                            break;
                        case "ecl":
                            ecl = pair[1];
                            break;
                        case "pid":
                            pid = pair[1];
                            break;
                        case "cid":
                            cid = pair[1];
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
