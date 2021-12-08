using Parser;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Y2021.Day8
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
            System.Collections.Generic.List<string> input = InputReader.Read("Day8.txt", line =>
            {
                return line.Split('|')[1];
            }).SelectMany( x => x.Split(' ')).ToList();

            var result = input.Where(x => x.Length == 2 || x.Length == 4 || x.Length == 3 || x.Length == 7).Count();
            _console.WriteLine(result.ToString());
        }
    }
}