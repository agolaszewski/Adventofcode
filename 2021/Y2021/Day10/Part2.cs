using Parser;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Y2021.Day10
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
            var input = InputReader.Read("Day10.txt", line => line);
            var pairs = new Dictionary<char, char>()
            {
                { '[', ']' },
                { '(', ')' },
                { '{', '}' },
                { '<', '>' },
            };

            var score = new Dictionary<char, long>()
            {
                { ']', 2 },
                { ')', 1 },
                { '}', 3 },
                { '>', 4 },
            };

            List<long> result = new List<long>();
            foreach (var line in input)
            {
                var array = line.Select(x => x).ToList();
                var stack = new Stack<char>();
                var isCorrupted = false;

                foreach (var element in array)
                {
                    if (pairs.ContainsKey(element))
                    {
                        stack.Push(element);
                    }
                    else
                    {
                        var pop = stack.Pop();
                        if (pairs[pop] != element)
                        {
                            isCorrupted = true;
                            break;
                        }
                    }
                }

                if (!isCorrupted)
                {
                    long sum = 0;
                    while (stack.Count > 0)
                    {
                        var pop = stack.Pop();
                        sum = sum * 5 + score[pairs[pop]];
                    }
                    result.Add(sum);
                }
            }

            var answer = result.OrderBy(x => x).Skip(result.Count / 2).First().ToString();
            _console.WriteLine(answer);
        }
    }
}