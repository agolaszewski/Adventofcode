using System;
using System.Collections.Generic;
using System.Linq;
using Parser;

namespace Day9
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var parser = new InputReader();
            List<long> inputs = parser.Read<long>("input.txt", long.Parse);

            int i = 0;
            for (i = 25; i < inputs.Count; i++)
            {
                var check = inputs[i];
                var subList = inputs.Skip(i - 25).Take(i).ToList();
                if (!subList.Any(x => subList.Contains(check - x)))
                {
                    Console.WriteLine(check);
                    break;
                }
            }

            long target = inputs[i];

            long sum = 0;
            int k = 0;
            int j = 0;
            long min = long.MaxValue;
            long max = 0;
            for (j = k; j < inputs.Count; j++)
            {
                if (inputs[j] < min)
                {
                    min = inputs[j];
                }

                if (inputs[j] > max)
                {
                    max = inputs[j];
                }

                sum += inputs[j];
                if (sum > target)
                {
                    j =k++;
                    sum = 0;
                    min = long.MaxValue;
                    max = 0;
                }

                if (sum == target)
                {
                    break;
                }
            }

            Console.WriteLine(min + max);
        }
    }
}