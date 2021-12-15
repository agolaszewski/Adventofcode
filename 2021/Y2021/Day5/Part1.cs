using Parser;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Y2021.Day5
{
    public class Part1
    {
        public class Line
        {
            public Line(int x1, int y1, int x2, int y2)
            {
                Start = new Point(x1, y1);
                End = new Point(x2, y2);
                MakePoints(Start, End);
            }

            public Point Start { get; }
            public Point End { get; }

            public List<Point> PointsOnTheLine { get; } = new List<Point>();

            private void MakePoints(Point start, Point end)
            {
                if (start.OnSameRow(end))
                {
                    DrawHorizontalLine(start, end);
                    return;
                }
                else if (start.OnSameColumn(end))
                {
                    DrawVerticalLine(start, end);
                }
            }

            private void DrawHorizontalLine(Point start, Point end)
            {
                var increment = start.X < end.X ? 1 : -1;
                for (var x = start.X; x != end.X; x += increment)
                {
                    PointsOnTheLine.Add(new Point(x, end.Y));
                }
                PointsOnTheLine.Add(end);
            }

            private void DrawVerticalLine(Point start, Point end)
            {
                var increment = start.Y < end.Y ? 1 : -1;
                for (var y = start.Y; y != end.Y; y += increment)
                {
                    PointsOnTheLine.Add(new Point(end.X, y));
                }
                PointsOnTheLine.Add(end);
            }
        }

        public class Point
        {
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int X { get; }
            public int Y { get; }

            public bool OnSameRow(Point point)
            {
                return Y == point.Y;
            }

            public bool OnSameColumn(Point point)
            {
                return X == point.X;
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
            var input = InputReader.Read("Day5.txt", line =>
            {
                var data = line.Split("->");
                var start = data[0].Split(',');
                var end = data[1].Split(',');

                return new Line(int.Parse(start[0].Trim()), int.Parse(start[1].Trim()), int.Parse(end[0].Trim()), int.Parse(end[1].Trim()));
            });

            var result = input.SelectMany(p => p.PointsOnTheLine).GroupBy(p => new { p.X, p.Y }).Count(g => g.Count<Point>() >= 2);
            _console.WriteLine(result.ToString());
        }
    }
}