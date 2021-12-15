using Parser;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Y2021.Day13
{
    public class Part2
    {
        public class Input
        {
            public Dictionary<int, List<int>> Points { get; set; }

            public List<(bool IsY, int Point)> Commands { get; set; } = new List<(bool IsY, int Point)>();
        }

        private readonly ITestOutputHelper _console;

        public Part2(ITestOutputHelper console)
        {
            _console = console;
        }

        [Fact]
        public void Solution()
        {
            var input = InputReader.ReadTo<Input>("Day13.txt", lines =>
            {
                var points = new Dictionary<int, List<int>>();

                var it = 0;
                while (!string.IsNullOrWhiteSpace(lines[it]))
                {
                    var line = lines[it].Split(',');
                    int y = int.Parse(line[1]);
                    if (!points.ContainsKey(y))
                    {
                        points.Add(y, new List<int>());
                    }
                    points[y].Add(int.Parse(line[0]));
                    it++;
                }

                ++it;
                List<(bool IsY, int Point)> commands = new List<(bool IsY, int Point)>();
                for (; it < lines.Count; it++)
                {
                    var command = lines[it][11..].Split('=');
                    commands.Add((command[0] == "y", int.Parse(command[1])));
                }

                return new Input()
                {
                    Points = points,
                    Commands = commands
                };
            });

            var points = input.Points;
            foreach (var command in input.Commands)
            {
                points = command.IsY ? FoldAlongY(points, command.Point) : FoldAlongX(points, command.Point);
            }

            var maxV = points.Keys.Max();
            var maxH = points.Values.SelectMany(x => x).Max();

            var array = new bool[maxV + 1, maxH + 1];
            foreach (var (key, value) in points)
            {
                foreach (var cell in value)
                {
                    array[key, cell] = true;
                }
            }

            for (int i = 0; i <= maxV; i++)
            {
                for (int j = 0; j <= maxH; j++)
                {
                    Debug.Write(array[i, j] == true ? "#" : ".");
                }
                Debug.WriteLine("");
            }

            //###..####.####...##.#..#.###..####.####
            //#..#....#.#.......#.#..#.#..#.#.......#
            //#..#...#..###.....#.####.#..#.###....#.
            //###...#...#.......#.#..#.###..#.....#..
            //#....#....#....#..#.#..#.#.#..#....#...
            //#....####.#.....##..#..#.#..#.#....####
        }

        private Dictionary<int, List<int>> FoldAlongY(Dictionary<int, List<int>> points, int point)
        {
            List<KeyValuePair<int, List<int>>> rows = points.Where(kp => kp.Key > point).ToList();
            rows.ForEach(kv =>
            {
                var reflection = point - (kv.Key - point);
                if (!points.ContainsKey(reflection))
                {
                    points.Add(reflection, new List<int>());
                }

                kv.Value.ForEach(p =>
                {
                    if (!points[reflection].Any(point => point == p))
                    {
                        points[reflection].Add(p);
                    }
                });
            });

            if (points.ContainsKey(point))
            {
                points.Remove(point);
            }

            foreach (var row in rows)
            {
                points.Remove(row.Key);
            }

            return points;
        }

        private Dictionary<int, List<int>> FoldAlongX(Dictionary<int, List<int>> points, int point)
        {
            List<KeyValuePair<int, List<int>>> rows = points.Select(row => new KeyValuePair<int, List<int>>(row.Key, row.Value.Where(x => x > point).ToList())).ToList();

            rows.ForEach(kv =>
            {
                foreach (var cell in kv.Value)
                {
                    var reflection = point - (cell - point);
                    if (!points[kv.Key].Any(point => point == reflection))
                    {
                        points[kv.Key].Add(reflection);
                    }
                }
            });

            foreach (var (key, _) in rows)
            {
                points[key] = points[key].Where(v => v < point).ToList();
            }

            return points;
        }
    }
}