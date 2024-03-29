﻿using Parser;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Y2021.Day11
{
    public class Part1
    {
        private readonly ITestOutputHelper _console;
        private int _flashes = 0;

        private readonly List<(int Y, int X)> _translations = new List<(int Y, int X)>()
        {
            (-1,0),
            (-1,1),
            (0,1),
            (1,1),
            (1,0),
            (1,-1),
            (0,-1),
            (-1,-1)
        };

        public Part1(ITestOutputHelper console)
        {
            _console = console;
        }

        [Fact]
        public void Solution()
        {
            var x = 0;
            var y = 0;
            var array = InputReader.ReadTo("Day11.txt", lines =>
            {
                y = lines.Count;
                x = lines[0].Length;

                var array = new int[x + 2, y + 2];

                for (var j = 0; j < x + 2; j++)
                {
                    array[0, j] = int.MinValue;
                    array[y + 1, j] = int.MinValue;
                }

                for (var i = 1; i <= y; i++)
                {
                    array[i, 0] = int.MinValue;
                    array[i, y + 1] = int.MinValue;
                    var horizontal = lines[i - 1].ToCharArray();
                    for (var j = 1; j <= x; j++)
                    {
                        array[i, j] = horizontal[j - 1] - '0';
                    }
                }

                return array;
            });

            for (int it = 1; it <= 100; it++)
            {
                for (var i = 1; i <= y; i++)
                {
                    for (var j = 1; j <= x; j++)
                    {
                        array[i, j]++;
                    }
                }

                for (var i = 1; i <= y; i++)
                {
                    for (var j = 1; j <= x; j++)
                    {
                        if (array[i, j] > 9)
                        {
                            Flash(array, i, j);
                        }
                    }
                }
            }
            _console.WriteLine(_flashes.ToString());
        }

        private void Flash(int[,] array, int i, int j)
        {
            _flashes++;
            array[i, j] = 0;

            foreach (var (Y, X) in _translations.Where(t => array[i + t.Y, j + t.X] != 0))
            {
                if (array[i + Y, j + X] < 9)
                {
                    array[i + Y, j + X]++;
                    continue;
                }

                Flash(array, i + Y, j + X);
            }
        }
    }
}