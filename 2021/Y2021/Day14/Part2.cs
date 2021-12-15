using Parser;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Y2021.Day14
{
    public class Part2
    {
        public class Input
        {
            public List<char> Template { get; set; }
            public Dictionary<string, char> Pairs { get; set; } = new Dictionary<string, char>();
        }

        private readonly ITestOutputHelper _console;

        public Part2(ITestOutputHelper console)
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
            var mapping = input.Pairs;

            var pairs = new Dictionary<string, ulong>();
            var count = mapping.Select(x => new string(new[] { x.Key[0], x.Key[1], x.Value }))
                .SelectMany(x => x.ToCharArray()).Distinct().ToDictionary(x => x, x => (ulong)0);

            for (int j = 0; j < template.Count - 1; j++)
            {
                string pair = new string(new[] { template[j], template[j + 1] });
                if (pairs.ContainsKey(pair))
                {
                    pairs[pair]++;
                    continue;
                }
                pairs.Add(pair, 1);
            }

            for (int i = 1; i <= 40; i++)
            {
                var temp = new Dictionary<string, ulong>();
                foreach (var pair in pairs)
                {
                    char middle = mapping[pair.Key];
                    string pairA = new string(new[] { pair.Key[0], middle });
                    string pairB = new string(new[] { middle, pair.Key[1] });

                    var value = pairs[pair.Key];
                    count[middle] += value;

                    Check(pairA, temp, value);
                    Check(pairB, temp, value);
                }

                pairs = temp;
            }

            count[template[^1]]++;

            var max = count.MaxBy(x => x.Value).Value;
            var min = count.MinBy(x => x.Value).Value;
            _console.WriteLine((max - min).ToString());
        }

        private void Check(string pair, Dictionary<string, ulong> temp, ulong parentValue)
        {
            if (!temp.ContainsKey(pair))
            {
                temp.Add(pair, parentValue);
            }
            else
            {
                temp[pair] += parentValue;
            }
        }
    }
}