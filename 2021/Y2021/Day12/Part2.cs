using Parser;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Y2021.Day12
{
    public class Part2
    {
        public class Node
        {
            public string Value { get; set; }

            public bool IsSmall { get; set; }

            public List<Node> Children { get; set; } = new List<Node>();

            public int Visited { get; set; }
        }

        private readonly ITestOutputHelper _console;

        public Part2(ITestOutputHelper console)
        {
            _console = console;
        }

        [Fact]
        public void Solution()
        {
            List<Node> nodes = InputReader.ReadTo<List<Node>>("Day12.txt", lines =>
            {
                var nodes = new List<Node>();
                foreach (var line in lines)
                {
                    var split = line.Split('-');
                    var node = nodes.FirstOrDefault(n => n.Value == split[0]);
                    if (node is null)
                    {
                        node = new Node()
                        {
                            Value = split[0],
                            IsSmall = split[0].ToLower() == split[0]
                        };
                        nodes.Add(node);
                    }
                    var child = nodes.FirstOrDefault(n => n.Value == split[1]);
                    if (child is null)
                    {
                        child = new Node()
                        {
                            Value = split[1],
                            IsSmall = split[1].ToLower() == split[1]
                        };
                        nodes.Add(child);
                    }
                    node.Children.Add(child);
                    child.Children.Add(node);
                }
                return nodes;
            });

            var start = nodes.FirstOrDefault(n => n.Value == "start");

            var paths = new List<Node>();
            int count = 0;
            count = Traverse(start, paths, count);
            _console.WriteLine(count.ToString());
        }

        private int Traverse(Node node, List<Node> path, int count)
        {
            path.Add(node);
            node.Visited++;

            if (node.Value == "end")
            {
                count++;
            }
            else
            {
                foreach (var child in node.Children)
                {
                    if (child.IsSmall)
                    {
                        if (child.Value == "start")
                        {
                            continue;
                        }

                        if (path.Where(x => x.IsSmall).Any(x => x.Visited == 2))
                        {
                            if (path.Any(p => p.Value == child.Value))
                            {
                                continue;
                            }
                        }
                    }
                    count = Traverse(child, path, count);
                }
            }

            path[^1].Visited--;
            path.RemoveAt(path.Count - 1);
            return count;
        }
    }
}