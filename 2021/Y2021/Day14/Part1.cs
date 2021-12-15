using Parser;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Y2021.Day14
{
    public class Part1
    {
        public class Input
        {
            public List<char> Template { get; set; }
            public Dictionary<string, char> Pairs { get; set; } = new Dictionary<string, char>();
        }

        private readonly ITestOutputHelper _console;

        public Part1(ITestOutputHelper console)
        {
            _console = console;
        }

        [Fact]
        public void Solution()
        {
            var input = InputReader.ReadTo("Day14.txt", lines =>
            {
                var input = new Input();
                input.Template = lines[0].ToList();

                for (int i = 2; i < lines.Count; i++)
                {
                    var line = lines[i].Split("->");
                    input.Pairs.Add(line[0].Trim(), line[1].Trim()[0]);
                }

                return input;
            });

            var template = input.Template;
            var pairs = input.Pairs;
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 0; j < template.Count - 1; j += 2)
                {
                    string pair = new string(new[] { template[j], template[j + 1] });
                    template.Insert(j + 1, pairs[pair]);
                }
            }

            (int Letter, int Value) max = (0, int.MinValue);
            (int Letter, int Value) min = (0, int.MaxValue);

            var ordered = template.OrderBy(x => x).ToList();
            ordered.Add('&');
            int current = ordered[0];
            int sum = 0;

            foreach (var element in ordered)
            {
                if (current == element)
                {
                    sum++;
                    continue;
                }

                if (sum > max.Value)
                {
                    max = (current, sum);
                }

                if (sum < min.Value)
                {
                    min = (current, sum);
                }

                current = element;
                sum = 1;
            }

            _console.WriteLine((max.Value - min.Value).ToString());
        }
    }
}