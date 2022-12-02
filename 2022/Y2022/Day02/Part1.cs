using Parser;
using Xunit;
using Xunit.Abstractions;

namespace Y2022.Day02
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
            long score = 0;
            InputReader.Read("Day02.txt", line =>
            {
                var args = line.Split(' ');
                Shape opponentShape = ShapeFactory.Make(args[0]);
                Shape myShape = ShapeFactory.Make(args[1]);
                score += myShape.Against(opponentShape);
                return line;
            });
            _console.WriteLine(score.ToString());
        }

        public static class ShapeFactory
        {
            public static Shape Make(string symbol)
            {
                return symbol switch
                {
                    "A" or "X" => new Rock(),
                    "B" or "Y" => new Paper(),
                    "C" or "Z" => new Scissors(),
                    _ => throw new ArgumentOutOfRangeException(nameof(symbol), symbol, null)
                };
            }
        }

        public abstract class Shape
        {
            public abstract int Value { get; }

            public int Against(Shape shape)
            {
                return shape.Value switch
                {
                    1 => Against(shape as Rock),
                    2 => Against(shape as Paper),
                    3 => Against(shape as Scissors),
                    _ => throw new ArgumentOutOfRangeException()
                };
            }

            public abstract int Against(Paper shape);

            public abstract int Against(Rock shape);

            public abstract int Against(Scissors shape);
        }

       

        public class Rock : Shape
        {
            public override int Value => 1;

            public override int Against(Paper shape) => 1; //1 + 0

            public override int Against(Rock shape) => 4; // 1 + 3

            public override int Against(Scissors shape) => 7; // 1 + 6
        }

        public class Paper : Shape
        {
            public override int Value => 2;

            public override int Against(Paper shape) => 5; //2 + 3

            public override int Against(Rock shape) => 8; // 2 + 6

            public override int Against(Scissors shape) => 2; // 2 + 0
        }

        public class Scissors : Shape
        {
            public override int Value => 3;

            public override int Against(Paper shape) => 9; //3 + 6

            public override int Against(Rock shape) => 3; // 3 + 0

            public override int Against(Scissors shape) => 6; // 3 + 3
        }
    }
}