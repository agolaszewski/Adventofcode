using Parser;
using System;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Y2021.Day18
{
    public class Part2
    {
        private static int _nodeId = 1;

        private readonly ITestOutputHelper _console;

        public Part2(ITestOutputHelper console)
        {
            _console = console;
        }

        [Fact]
        public void Solution()
        {
            var lines = InputReader.Read("Day18.txt", lines => lines);

            int max = int.MinValue;
            for (int i = 0; i < lines.Count; i++)
            {
                for (int j = i + 1; j < lines.Count; j++)
                {
                    var a = Build(lines[i]);
                    var b = Build(lines[j]);
                    var root = new Node
                    {
                        Left = a,
                        Right = b
                    };
                    a.Parent = root;
                    b.Parent = root;

                    Reducing(root);
                    a = root;
                    Magnitude(a);

                    if (max < a.Value)
                    {
                        max = a.Value;
                    }
                }
            }
            _console.WriteLine(max.ToString());
        }

        private Node Build(string line)
        {
            var root = new Node();
            foreach (var element in line)
            {
                switch (element)
                {
                    case ('['):
                        {
                            var node = new Node();
                            root.Left = node;
                            node.Parent = root;

                            root = node;
                            break;
                        }
                    case (','):
                        {
                            root = root.Parent;

                            var node = new Node();
                            root.Right = node;
                            node.Parent = root;
                            root = node;
                            break;
                        }
                    case (']'):
                        {
                            root = root.Parent;
                            break;
                        }
                    default:
                        {
                            root.Value = element - '0';
                            break;
                        }
                }
            }

            return root;
        }

        private void Explode(Node explodingNode)
        {
            var l = FindUp(explodingNode, explodingNode.Left, true);

            if (l?.Value > -1)
            {
                l.Value += explodingNode.Left.Value;
            }

            var r = FindUp(explodingNode, explodingNode.Right, false);

            if (r?.Value > -1)
            {
                r.Value += explodingNode.Right.Value;
            }

            explodingNode.Left = null;
            explodingNode.Right = null;
            explodingNode.Value = 0;
        }

        private bool Exploding(Node root)
        {
            var explodingNode = TryExplode(root, 0);
            if (explodingNode is not null)
            {
                Explode(explodingNode);
                return true;
            }

            return false;
        }

        private Node FindDown(Node node, Node previous, bool isLeft)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Value > -1)
            {
                return node;
            }

            var target = isLeft ? node.Left : node.Right;
            return FindDown(target, node, isLeft);
        }

        private Node FindUp(Node node, Node previous, bool isLeft)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Value > -1)
            {
                return node;
            }

            var target = isLeft ? node.Left : node.Right;
            if (target.Id == previous.Id)
            {
                return FindUp(node.Parent, node, isLeft);
            }

            return FindDown(target, node, !isLeft);
        }

        private void Magnitude(Node root)
        {
            if (root.Left is not null)
            {
                Magnitude(root.Left);
            }

            if (root.Right is not null)
            {
                Magnitude(root.Right);
            }

            if (root?.Left?.Value > -1 && root?.Right?.Value > -1)
            {
                root.Value = root.Left.Value * 3 + root.Right.Value * 2;
            }
        }

        private StringBuilder Print(Node root)
        {
            StringBuilder sb = new StringBuilder();

            if (root.Left is not null)
            {
                sb.Append('[');
                sb.Append(Print(root.Left));
            }

            if (root.Right is not null)
            {
                sb.Append(',');
                sb.Append(Print(root.Right));
            }

            if (root.Value > -1)
            {
                sb.Append(root.Value);
            }
            else
            {
                sb.Append(']');
            }

            return sb;
        }

        private void Reducing(Node root)
        {
            while (true)
            {
                if (Exploding(root)) continue;
                if (Splitting(root)) continue;
                break;
            }
        }

        private void Split(Node splitNode)
        {
            var splitValue = splitNode.Value / 2.0;
            splitNode.Value = -1;
            splitNode.Left = new Node()
            {
                Parent = splitNode,
                Value = (int)Math.Floor(splitValue)
            };

            splitNode.Right = new Node()
            {
                Parent = splitNode,
                Value = (int)Math.Ceiling(splitValue)
            };
        }

        private bool Splitting(Node root)
        {
            Node splitNode = TrySplit(root);
            if (splitNode is not null)
            {
                Split(splitNode);
                return true;
            }

            return false;
        }

        private Node TryExplode(Node root, int depth)
        {
            //?? >
            if (depth >= 4 && root?.Left?.Value > -1 && root?.Right?.Value > -1)
            {
                return root;
            }

            Node explodingNode = null;
            if (root.Left is not null)
            {
                explodingNode = TryExplode(root.Left, depth + 1);
            }

            if (root.Right is not null && explodingNode is null)
            {
                explodingNode = TryExplode(root.Right, depth + 1);
            }

            return explodingNode;
        }

        private Node TrySplit(Node root)
        {
            if (root.Value > 9)
            {
                return root;
            }

            Node splitNode = null;
            if (root.Left is not null)
            {
                splitNode = TrySplit(root.Left);
            }

            if (root.Right is not null && splitNode is null)
            {
                splitNode = TrySplit(root.Right);
            }

            return splitNode;
        }

        public class Node
        {
            public Node()
            {
                Id = _nodeId++;
            }

            public int Id { get; set; }

            public Node Left { get; set; }
            public Node Parent { get; set; }
            public Node Right { get; set; }
            public int Value { get; set; } = -1;
        }
    }
}