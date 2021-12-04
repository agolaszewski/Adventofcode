using Parser;
using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Y2021.Day3
{
    public class Part1
    {
        private readonly ITestOutputHelper _console;

        public Part1(ITestOutputHelper console)
        {
            _console = console;
        }

        [Fact]
        public void Solution()
        {
            var input = InputReader.Read("Day3.txt", line => line);

            int[] count = new int[input[0].Length];
            foreach (string line in input)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == '1')
                    {
                        count[i]++;
                    }
                }
            }

            var avg = Math.Ceiling(input.Count / 2.0);
            var gammaBinary = new string(count.Select(x => x >= avg ? '1' : '0').ToArray());
            var gamma = Convert.ToInt64(gammaBinary, 2);

            var epsilonBinary = new string(gammaBinary.Select(x => x == '1' ? '0' : '1').ToArray());
            var epsilon = Convert.ToInt64(epsilonBinary, 2);
            var answer = epsilon * gamma;
            _console.WriteLine(answer.ToString());
        }
    }
}