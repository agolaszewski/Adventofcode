﻿using Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Y2021.Day15
{
    public class Part2
    {
        private readonly ITestOutputHelper _console;
        private int x;
        private int y;

        public class PriorityQueue
        {
            private List<(Location Location, int Priority)> elements = new List<(Location Location, int Priority)>();

            public int Count => elements.Count;

            public void Enqueue(Location item, int priority)
            {
                elements.Add((item, priority));
            }

            public Location Dequeue()
            {
                var element = elements.MinBy(x => x.Priority);
                elements.Remove((element.Location, element.Priority));

                return element.Location;
            }
        }

        public record Location
        {
            public Location(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int X { get; set; }

            public int Y { get; set; }

            public IEnumerable<Location> Neighbors(int[,] maze)
            {
                yield return new Location(X - 1, Y);
                yield return new Location(X + 1, Y);
                yield return new Location(X, Y + 1);
                yield return new Location(X, Y - 1);
            }

            public bool IsInBounds(int[,] maze)
            {
                return X >= 0 && Y >= 0 && X < maze.GetLength(0) * 5 && Y < maze.GetLength(1) * 5;
            }
        }

        public Part2(ITestOutputHelper console)
        {
            _console = console;
        }

        [Fact]
        public void Solution()
        {
            var maze = InputReader.ReadTo("Day15.txt", lines =>
            {
                y = lines.Count;
                x = lines[0].Length;

                var array = new int[x, y];

                for (var i = 0; i < y; i++)
                {
                    var horizontal = lines[i].ToCharArray();
                    for (var j = 0; j < x; j++)
                    {
                        array[i, j] = horizontal[j] - '0';
                    }
                }

                return array;
            });

            var start = new Location(0, 0);
            var goal = new Location(x * 5 - 1, y * 5 - 1);

            var queue = new PriorityQueue();
            queue.Enqueue(start, 0);

            var totalCost = new Dictionary<Location, int>();
            totalCost.Add(start, 0);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (current.X == goal.X && current.Y == goal.Y)
                {
                    break;
                }

                foreach (var next in current.Neighbors(maze))
                {
                    if (!next.IsInBounds(maze))
                    {
                        continue;
                    }

                    var newCost = totalCost[current] + GetRisk(next, maze);

                    if (!totalCost.ContainsKey(next) || newCost < totalCost[next])
                    {
                        totalCost[next] = newCost;
                        int priority = newCost + ManhattanDistance(next, goal);
                        queue.Enqueue(next, priority);
                    }
                }
            }

            _console.WriteLine(totalCost[goal].ToString());
        }

        private int ManhattanDistance(Location next, Location goal)
        {
            return Math.Abs(next.X - goal.X) + Math.Abs(next.Y - goal.Y);
        }

        private int GetRisk(Location location, int[,] maze)
        {
            var risk = maze[location.X % maze.GetLength(0), location.Y % maze.GetLength(1)];
            risk = risk + (location.X / maze.GetLength(0)) + (location.Y / maze.GetLength(1));
            risk = risk > 9 ? risk % 10 + 1 : risk;
            return risk;
        }
    }
}