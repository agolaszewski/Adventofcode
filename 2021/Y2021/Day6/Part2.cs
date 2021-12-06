using Parser;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Y2021.Day6
{
    public class Part2
    {
        private readonly ITestOutputHelper _console;

        public Part2(ITestOutputHelper console)
        {
            _console = console;
        }

        [Fact]
        public void Solution()
        {
            var generations = InputReader.ReadTo("Day6.txt", line =>
            {
                ulong[,] fishes = new ulong[9, 1];

                Array.ForEach(line[0].Split(','), x =>
                {
                    int days = int.Parse(x.Trim());
                    fishes[days, 0]++;
                });

                return fishes;
            });

            for (int days = 1; days <= 256; days++)
            {
                var newFishes = generations[0, 0];
                for (int i = 0; i <= 7; i++)
                {
                    generations[i, 0] = generations[i + 1, 0];
                }
                generations[8, 0] = newFishes;
                generations[6, 0] += newFishes;
            }

            ulong sum = 0;
            for (int i = 0; i <= 8; i++)
            {
                sum += generations[i, 0];
            }

            _console.WriteLine(sum.ToString());
        }
    }
}