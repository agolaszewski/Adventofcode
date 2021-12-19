using Parser;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Y2021.Day18
{
    public class Part1
    {
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

            public int CalculateShoot(int velX, int velY)
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

                        if (maxY < y)
                        {
                            maxY = y;
                        }
                    }
                    else
                    {
                        return maxY;
                    }
                }

                return int.MinValue;
            }
        }

        private readonly ITestOutputHelper _console;

        public Part1(ITestOutputHelper console)
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

            var maxV = int.MinValue;
            //loops go brrr
            for (int x = 0; x < 125; x++)
            {
                for (int y = 0; y < 200; y++)
                {
                    var result = target.CalculateShoot(x, y);
                    if (result > maxV)
                    {
                        maxV = result;
                        Debug.WriteLine(maxV.ToString());
                    }
                }
            }
            _console.WriteLine(maxV.ToString());
        }
    }
}