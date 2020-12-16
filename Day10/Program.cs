using System;
using System.Collections.Generic;
using System.Linq;
using Parser;

namespace Day10
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var parser = new InputReader();
            List<int> inputs = parser.Read<int>("input.txt", int.Parse);

            inputs.Insert(0, 0);

            var max = inputs.Max();
            inputs.Add(max + 3);

            inputs = inputs.OrderBy(x => x).ToList();

            int j1 = 0;
            int j2 = 0;
            int j3 = 0;
            int previous = 0;
            for (int i = 1; i < inputs.Count; i++)
            {
                var difference = inputs[i] - previous;
                switch (difference)
                {
                    case 1:
                        j1++;
                        break;

                    case 2:
                        j2++;
                        break;

                    case 3:
                        j3++;
                        break;
                }

                previous = inputs[i];
            }

            var result = j1 * j3;
            Console.WriteLine(result);

            result = 1;

            inputs = inputs.OrderByDescending(x => x).ToList();
            Dictionary<int, long> subTotal = new Dictionary<int, long>();

            subTotal[inputs[0]] = 1;
            
            for (int i = 1; i < inputs.Count; i++)
            {
                long amount = 0;
                int j = i - 1;
                while (j >= 0 && inputs[j] - inputs[i] <= 3)
                {
                    amount += subTotal[inputs[j]];
                    j--;
                }
                subTotal[inputs[i]] = amount;
            }

            Console.WriteLine(subTotal[inputs[^1]]);
        }
    }
}