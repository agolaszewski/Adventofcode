using Parser;
using Xunit;
using Xunit.Abstractions;

namespace Y2022.Day01
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
            long max = 0;
            InputReader.ReadMultiLine<long>("Day01.txt", lines =>
            {
                var sumCalories = lines.Select(long.Parse).Sum();
                if (sumCalories >= max)
                {
                    max = sumCalories;
                }

                return sumCalories;
            });
            _console.WriteLine(max.ToString());
        }
    }
}