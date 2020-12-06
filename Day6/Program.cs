using System;
using System.Collections.Generic;
using System.Linq;
using Parser;

namespace Day6
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var parser = new InputReader();
            List<HashSet<char>> inputs = parser.ReadMultiLine<HashSet<char>>("input.txt", lines =>
            {
                return lines.SelectMany(x => x.ToList()).ToHashSet();
            });

            int sum = 0;
            foreach (var input in inputs)
            {
                sum += input.Count;
            }

            Console.WriteLine(sum);

            List<Input> inputs2 = parser.ReadMultiLine("input.txt", lines =>
            {
                return new Input()
                {
                    GroupCount = lines.Count,
                    Answers = lines.SelectMany(x => x.ToList()).ToList()
                };
            });

            int sum2 = 0;
            foreach (var input in inputs2)
            {
                sum2 += input.Answers.Distinct().Count(x => input.Answers.Count(a => a == x) == input.GroupCount);
            }

            Console.WriteLine(sum2);
        }
    }
}