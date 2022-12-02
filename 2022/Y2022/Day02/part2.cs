using Parser;
using Xunit;
using Xunit.Abstractions;

namespace Y2022.Day02
{
    public class Part2
    {
        private readonly ITestOutputHelper _console;

        public Part2(ITestOutputHelper console)
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
                score += opponentShape.Strategy(args[1]);
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
                    "A" => new Rock(),
                    "B" => new Paper(),
                    "C" => new Scissors(),
                    _ => throw new ArgumentOutOfRangeException(nameof(symbol), symbol, null)
                };
            }
        }

        public abstract class Shape
        {
            public abstract int Strategy(string strategySymbol);
        }

        public class Rock : Shape
        {
            public static int Value => 1;

            public override int Strategy(string strategySymbol)
            {
                return strategySymbol switch
                {
                    "X" => Scissors.Value, //Scissors 3 + 0
                    "Y" => Rock.Value + 3, //Rock 1 + 3
                    "Z" => Paper.Value + 6, //Paper 2 + 6
                    _ => throw new ArgumentOutOfRangeException(nameof(strategySymbol), strategySymbol, null)
                };
            }
        }

        public class Paper : Shape
        {
            public static int Value => 2;

            public override int Strategy(string strategySymbol)
            {
                return strategySymbol switch
                {
                    "X" => Rock.Value, //Rock 1 + 0
                    "Y" => Paper.Value + 3, //Paper 2 + 3
                    "Z" => Scissors.Value + 6, //Scissors 3 + 6
                    _ => throw new ArgumentOutOfRangeException(nameof(strategySymbol), strategySymbol, null)
                };
            }
        }

        public class Scissors : Shape
        {
            public static int Value => 3;

            public override int Strategy(string strategySymbol)
            {
                return strategySymbol switch
                {
                    "X" => Paper.Value, //Paper 2 + 0
                    "Y" => Scissors.Value + 3, //Scissors 3 + 3
                    "Z" => Rock.Value + 6, //Rock 1 + 6
                    _ => throw new ArgumentOutOfRangeException(nameof(strategySymbol), strategySymbol, null)
                };
            }
        }
    }
}