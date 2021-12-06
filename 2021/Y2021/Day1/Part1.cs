using Parser;
using Xunit;
using Xunit.Abstractions;







namespace Y2021.Day1
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
    }
}