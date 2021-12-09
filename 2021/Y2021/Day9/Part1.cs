using Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Y2021.Day9
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
            List<List<int>> input = InputReader.Read("Day9.txt", line =>
            {
                return line.Select(x => x - '0').ToList();
            });

            int maxH = input[0].Count;
            int maxV = input.Count;

            for (int i = 0; i < input.Count; i++)
            {
                for (int j = 0; j < input[i].Count; j++)
                {
                    var check = Math.Abs(input[i][j]);

                    (int X, int Y) v = new(1, 0);
                    for (int d = 0; d < 4; d++)
                    {
                        v = (v.Y, -v.X);
                        var x = i + v.Y >= 0 && i + v.Y < maxV ? i + v.Y : i;
                        var y = j + v.X >= 0 && j + v.X < maxH ? j + v.X : j;
                        if ((x != i || y != j) && input[x][y] >= check)
                        {
                            input[x][y] = input[x][y] * -1;
                        }
                    }
                }
            }

            var result = input.SelectMany(x => x.Select(x1 => x1)).Where(x => x >= 0).Sum(a => a + 1);
            _console.WriteLine(result.ToString());
        }
    }
}