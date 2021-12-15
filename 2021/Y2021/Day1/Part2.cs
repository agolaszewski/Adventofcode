using Parser;
using Xunit;
using Xunit.Abstractions;

namespace Y2021.Day1
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
            var input = InputReader.Read("Day1.txt", int.Parse);

            var counter = 0;
            var prev = input[0] + input[1] + input[2];

            for (int i = 1; i < input.Count - 2; i++)
            {
                var sum = input[i] + input[i + 1] + input[i + 2];

                if (sum > prev)
                {
                    counter++;
                }
                prev = sum;
            }
            _console.WriteLine(counter.ToString());
        }
    }
}