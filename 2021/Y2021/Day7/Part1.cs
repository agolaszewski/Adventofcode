using Parser;
using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Y2021.Day7
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
            var positions = InputReader.ReadTo("Day7.txt", line =>
            {
                return line[0].Split(',').Select(x => int.Parse(x)).ToList();
            });

            int l = positions.Min();
            int r = positions.Max();

            int result = 0;
            bool lastIteration = false;

            while (true)
            {
                var suml = 0;
                var sumr = 0;

                positions.ForEach(position =>
                {
                    suml += Math.Abs(position - l);
                    sumr += Math.Abs(position - r);
                });

                if (suml < sumr)
                {
                    result = suml;
                    r = (l + r) / 2;
                }
                else
                {
                    result = sumr;
                    l = (l + r) / 2;
                }

                if (lastIteration)
                {
                    break;
                }

                if (r - l == 1)
                {
                    lastIteration = true;
                }
            }

            _console.WriteLine(result.ToString());
        }
    }
}