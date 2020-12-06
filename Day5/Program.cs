using System;
using System.Collections.Generic;
using System.Linq;
using Parser;

namespace Day5
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var parser = new InputReader();
            List<string> inputs = parser.Read("input.txt", x => x);
            List<int> results = new List<int>();
            var array = new int[128, 8];

            foreach (var input in inputs)
            {
                Queue<int> rowQueue =
                    new Queue<int>(input.Substring(0, input.Length - 3).Select(c => c == 'F' ? 1 : 0));
                Queue<int> columnQueue =
                    new Queue<int>(input.Substring(input.Length - 3).Select(c => c == 'L' ? 1 : 0));
                int row = FindRow(rowQueue, 0, 128);
                int column = FindRow(columnQueue, 0, 8);
                results.Add(row * 8 + column);
                array[row, column] = 1;
            }

            Console.WriteLine(results.Max());

            for (int r = 1; r < array.GetLength(0) - 1; r++)
            {
                for (int c = 0; c < array.GetLength(1) - 1; c++)
                {
                    if (array[r, c] == 0)
                    {
                        Console.WriteLine(r * 8 + c);
                        break;
                    }
                }
            }
        }

        private static int FindRow(Queue<int> queue, int left, int right)
        {
            var direction = queue.Dequeue();
            if (queue.Count == 0)
            {
                return direction == 1 ? left : right - 1;
            }

            if (direction == 1)
            {
                return FindRow(queue, left, left + ((right - left) / 2));
            }

            return FindRow(queue, left + ((right - left) / 2), right);
        }
    }
}