using Parser;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Y2021.Day10
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
            var input = InputReader.Read("Day10.txt", line => line);
            var pairs = new Dictionary<char, char>()
            {
                { '[', ']' },
                { '(', ')' },
                { '{', '}' },
                { '<', '>' },
            };

            var score = new Dictionary<char, int>()
            {
                { ']', 57 },
                { ')', 3 },
                { '}', 1197 },
                { '>', 25137 },
            };

            var sum = 0;
            foreach (var line in input)
            {
                var array = line.ToCharArray();
                var stack = new Stack<char>();

                for (int i = 0; i < array.Length; i++)
                {
                    if (pairs.ContainsKey(array[i]))
                    {
                        stack.Push(array[i]);
                    }
                    else
                    {
                        var pop = stack.Pop();
                        if (pairs[pop] != array[i])
                        {
                            sum += score[array[i]];
                            break;
                        }
                    }
                }
            }
            _console.WriteLine(sum.ToString());
        }
    }
}