using Parser;
using System.Collections.Generic;
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
            List<string> input = InputReader.Read("Day8.txt", line => line.Split('|')[1]).SelectMany(x => x.Split(' ')).ToList();

            var result = input.Count(x => x.Length is 2 or 3 or 4 or 7);
            _console.WriteLine(result.ToString());
        }
    }
}