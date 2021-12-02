﻿using Parser;
using Xunit;
using Xunit.Abstractions;

namespace Day2
{
    public class Part2
    {
        public record Point
        {
            public long X { get; init; }
            public long Y { get; init; }
            public long Aim { get; init; }
        }

        public interface ICommand
        {
            Point Apply(Point point);
        }

        public class Forward : ICommand
        {
            public Forward(long value)
            {
                _value = value;
            }

            public long _value;

            public Point Apply(Point point)
            {
                return new Point()
                {
                    X = point.X + _value,
                    Y = point.Y + point.Aim * _value,
                    Aim = point.Aim
                };
            }
        }

        public class Up : ICommand
        {
            public Up(long value)
            {
                _value = value;
            }

            public long _value;

            public Point Apply(Point point)
            {
                return point with { Aim = point.Aim - _value };
            }
        }

        public class Down : ICommand
        {
            public Down(long value)
            {
                _value = value;
            }

            public long _value;

            public Point Apply(Point point)
            {
                return point with { Aim = point.Aim + _value };
            }
        }

        private readonly ITestOutputHelper _console;

        public Part2(ITestOutputHelper console)
        {
            _console = console;
        }

        [Fact]
        public void Solution2()
        {
            var input = InputReader.Read<ICommand>("Input1.txt", line =>
            {
                var data = line.Split(" ");
                return data[0] switch
                {
                    "up" => new Up(long.Parse(data[1])),
                    "down" => new Down(long.Parse(data[1])),
                    "forward" => new Forward(long.Parse(data[1])),
                    _ => throw new System.NotImplementedException()
                };
            });

            var point = new Point();
            foreach (ICommand command in input)
            {
                point = command.Apply(point);
            }
            var result = point.X * point.Y;
            _console.WriteLine(result.ToString());
        }
    }
}