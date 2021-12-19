using Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Y2021.Day17
{
    public class Part2
    {
        public record Cords
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        public class Target
        {
            public Target(IEnumerable<char> xMin, IEnumerable<char> xMax, IEnumerable<char> yMin, IEnumerable<char> yMax)
            {
                XMin = Convert(xMin.ToArray());
                XMax = Convert(xMax.ToArray());
                YMin = Convert(yMin.ToArray());
                YMax = Convert(yMax.ToArray());
            }

            public int XMin { get; }
            public int XMax { get; }
            public int YMin { get; }
            public int YMax { get; }

            private int Convert(char[] array)
            {
                var it = 1;
                var result = 0;
                for (var i = array.Count() - 1; i >= 0; i--)
                {
                    if (array[i] == '-')
                    {
                        result *= -1;
                        continue;
                    }

                    result += (array[i] - '0') * it;
                    it *= 10;
                }
                return result;
            }

            public bool IsOverShoot(int x, int y)
            {
                return x > XMax || y < YMin;
            }

            public bool IsInside(int x, int y)
            {
                return x >= XMin && x <= XMax && y >= YMin && y <= YMax;
            }

            public (int X, int Y) CalculateShoot(int velX, int velY)
            {
                int x = velX;
                int y = velY;
                var maxY = velY;
                while (!IsOverShoot(x, y))
                {
                    if (!IsInside(x, y))
                    {
                        if (--velX > 0)
                        {
                            x += velX;
                        }

                        y += --velY;
                    }
                    else
                    {
                        return (x, y);
                    }
                }

                return (x, y);
            }

            public int Distance(int x, int y)
            {
                var destX = 0;
                var destY = 0;
                if (x >= XMin && x <= XMax)
                {
                    destX = x;
                }
                else
                {
                    destX = Math.Max(XMin, x);
                    destX = Math.Min(XMax, destX);
                }

                if (y >= YMax && y <= YMin)
                {
                    destY = y;
                }
                else
                {
                    destY = Math.Max(YMin, y);
                    destY = Math.Min(YMax, destY);
                }

                return Math.Abs(x - destX) + Math.Abs(y - destY);
            }
        }

        private readonly ITestOutputHelper _console;

        public Part2(ITestOutputHelper console)
        {
            _console = console;
        }

        [Fact]
        public void Solution()
        {
            var target = InputReader.ReadTo("Day17.txt", lines =>
            {
                //target area: x=20..30, y=-10..-5
                var line = lines[0];
                var split = line.Split("..");

                var xMin = split[0].Reverse().TakeWhile(c => c != '=').Reverse();
                var xMax = split[1].TakeWhile(c => c != ',');
                var yMin = split[1].Reverse().TakeWhile(c => c != '=').Reverse();
                var yMax = split[2];
                return new Target(xMin, xMax, yMin, yMax);
            });

            var count = 0;
            for (int x = 0; x <= target.XMax; x++)
            {
                for (int y = target.YMin; y <= 300; y++)
                {
                    var result = target.CalculateShoot(x, y);
                    var distance = target.Distance(result.X, result.Y);

                    if (target.Distance(result.X, result.Y) == 0)
                    {
                        count++;
                    }
                }
            }
            _console.WriteLine(count.ToString());
        }
    }
}