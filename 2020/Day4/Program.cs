using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Parser;

namespace Day4
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var parser = new InputReader();
            List<Dictionary<string, string>> inputs = parser.ReadMultiLine<Dictionary<string, string>>("input.txt", lines =>
            {
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                lines.ForEach(line =>
                {
                    var array = line.Split(' ').SelectMany(item => item.Split(':')).ToArray();
                    for (int i = 0; i < array.Length; i += 2)
                    {
                        dictionary.Add(array[i], array[i + 1]);
                    }
                });

                return dictionary;
            });

            var validParams = new List<string>() { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };

            int validPassports = 0;
            foreach (var passport in inputs)
            {
                if (validParams.All(x => passport.ContainsKey(x)))
                {
                    validPassports++;
                }
            }

            Console.WriteLine(validPassports);

            var checks = new Dictionary<string, Func<string, bool>>
            {
                {
                    "byr", line =>
                    {
                        if (line.Length != 4)
                        {
                            return false;
                        }

                        int year = int.Parse(line);
                        return year >= 1920 && year <= 2002;
                    }
                },
                {
                    "iyr", line =>
                    {
                        if (line.Length != 4)
                        {
                            return false;
                        }

                        int year = int.Parse(line);
                        return year >= 2010 && year <= 2020;
                    }
                },
                {
                    "eyr", line =>
                    {
                        if (line.Length != 4)
                        {
                            return false;
                        }

                        int year = int.Parse(line);
                        return year >= 2020 && year <= 2030;
                    }
                },
                {
                    "hgt", line =>
                    {
                        string unit = line.Substring(line.Length - 2,2);
                        int height = int.Parse(line.Substring(0,line.Length - 2));
                        return unit switch
                        {
                            "cm" => height >= 150 && height <= 193,
                            "in" => height >= 59 && height <= 76,
                            _ => false
                        };
                    }
                },
                {
                    "hcl", line => Regex.IsMatch(line,"^[#][a-f0-9]+$")
                },
                {
                    "ecl", line =>
                    {
                        switch (line)
                        {
                            case("amb"):
                            case("blu"):
                            case("brn"):
                            case("gry"):
                            case("grn"):
                            case("hzl"):
                            case("oth"):
                                return true;

                           default:
                               return false;
                        }
                    }
                },
                {
                    "pid", line => line.Length == 9 && Regex.IsMatch(line, "^[0-9]*$")
                },
                {
                    "cid", line => true
                }
            };

            int validPassports2 = 0;
            foreach (var passport in inputs)
            {
                var doesContainsAllKeys = validParams.All(x => passport.ContainsKey(x));
                if (!doesContainsAllKeys)
                {
                    continue;
                }

                var isValid = passport.All(x => checks[x.Key](x.Value));
                if (isValid)
                {
                    validPassports2++;
                }
            }

            Console.WriteLine(validPassports2);
        }
    }
}