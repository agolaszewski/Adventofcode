using Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Y2021.Day9
{
    public class Part2
    {
        private readonly ITestOutputHelper _console;
        private (int X, int Y) v = new(1, 0);

        public Part2(ITestOutputHelper console)
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
            (int X, int Y) v = new(1, 0);

            for (int i = 0; i < input.Count; i++)
            {
                for (int j = 0; j < input[i].Count; j++)
                {
                    var check = Math.Abs(input[i][j]);

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

            List<(int X, int Y)> points = input.SelectMany((x, indexX) => x.Select((y, indexY) => (indexX, indexY))).Where(p => input[p.indexX][p.indexY] >= 0).ToList();

            for (int i = 0; i < input.Count; i++)
            {
                for (int j = 0; j < input[i].Count; j++)
                {
                    input[i][j] = Math.Abs(input[i][j]);
                }
            }

            List<long> results = new List<long>();
            foreach (var point in points)
            {
                long sum = 0;
                var currentPosition = (point.X, point.Y);
                Stack<(int X, int Y)> path = new Stack<(int X, int Y)>();
                path.Push((currentPosition.X, currentPosition.Y));

                do
                {
                    input[currentPosition.X][currentPosition.Y] = -1;
                    var next = Move(currentPosition, input);
                    if (next.Value > 0)
                    {
                        path.Push((currentPosition.X, currentPosition.Y));
                        currentPosition = (next.X, next.Y);
                    }
                    else
                    {
                        currentPosition = path.Pop();
                        sum++;
                    }
                } while (path.Count > 0);

                results.Add(sum);
            }
            var mul = results.OrderByDescending(x => x).Take(3).Aggregate(1, (long x1, long x2) => x1 * x2);
            _console.WriteLine(mul.ToString());
        }

        private (int X, int Y, int Value) Move((int X, int Y) point, List<List<int>> input)
        {
            int maxH = input[0].Count;
            int maxV = input.Count;

            for (int d = 0; d < 4; d++)
            {
                v = (v.Y, -v.X);
                var y = point.Y + v.Y >= 0 && point.Y + v.Y < maxH ? point.Y + v.Y : point.Y;
                var x = point.X + v.X >= 0 && point.X + v.X < maxV ? point.X + v.X : point.X;
                if ((x != point.Y || y != point.X) && input[x][y] is not 9 and >= 0)
                {
                    var nextPosition = (x, y, input[x][y]);
                    return nextPosition;
                }
            }

            return ((0, 0, -1));
        }
    }
}