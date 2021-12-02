using Parser;
using Xunit;
using Xunit.Abstractions;

namespace Day1
{
    public class Day1
    {
        private readonly ITestOutputHelper _console;

        public Day1(ITestOutputHelper console)
        {
            _console = console;
        }

        [Fact]
        public void Solution1()
        {
            var input = InputReader.Read("Day1.txt", line => int.Parse(line));

            var counter = 0;
            var prev = input[0];

            for (int i = 1; i < input.Count; i++)
            {
                if (input[i] > prev)
                {
                    counter++;
                }
                prev = input[i];
            }
            _console.WriteLine(counter.ToString());
        }

        [Fact]
        public void Solution2()
        {
            var input = InputReader.Read("Day1.txt", line => int.Parse(line));

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