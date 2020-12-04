using System;
using System.Collections.Generic;
using Parser;

namespace Day3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var parser = new InputReader();
            List<List<int>> inputs = parser.Read<List<int>>("input.txt", line =>
            {
                var row = new List<int>();
                foreach (var @char in line)
                {
                    row.Add(@char == '#' ? 1 : 0);
                }

                return row;
            });
           
            var treesCount = CheckTrees(inputs, 3, 1);
            Console.WriteLine(treesCount);

            long result = 1;
            result *= CheckTrees(inputs, 1, 1);
            result *= CheckTrees(inputs, 3, 1);
            result *= CheckTrees(inputs, 5, 1);
            result *= CheckTrees(inputs, 7, 1);
            result *= CheckTrees(inputs, 1, 2);

            Console.WriteLine(result);
        }

        private static int CheckTrees(List<List<int>> inputs, int right, int down)
        {
            int treeCount = 0;
            int step = 0;
            int patterLength = inputs[0].Count;

            for(int i = down; i < inputs.Count; i += down)
            {
                step = (step + right) % patterLength;
                if (inputs[i][step] == 1)
                {
                    treeCount++;
                }
            }

            return treeCount;
        }
    }
}