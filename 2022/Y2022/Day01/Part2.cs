using Parser;
using Xunit;
using Xunit.Abstractions;

namespace Y2022.Day01
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
            long max = 0;
            var elves = InputReader.ReadMultiLine("Day01.txt", lines => lines.Select(long.Parse).Sum());
            var total = elves.OrderByDescending(x => x).Take(3).Sum();
            _console.WriteLine(total.ToString());
        }
    }
}