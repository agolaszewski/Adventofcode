using System;
using System.Collections.Generic;
using System.Linq;
using Parser;

namespace Day1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var parser = new InputReader();
            List<int> inputs = parser.Read<int>("input.txt", int.Parse);
            inputs = inputs.OrderByDescending(x => x).ToList();
            int target = 2020;
            int numbersCount = 3;

            for (int i = 0; i < inputs.Count; i++)
            {
                List<int> result = new List<int> { inputs[i] };

                for (int j = i + 1; j < inputs.Count; j++)
                {
                    if (result.Sum() + inputs[j] <= target)
                    {
                        result.Add(inputs[j]);
                    }

                    if (result.Count == numbersCount)
                    {
                        if (result.Sum() != target)
                        {
                            result.RemoveAt(result.Count - 1);
                        }
                        else
                        {
                            int answer = 1;
                            result.ForEach(x => answer *= x);
                            Console.WriteLine(answer);
                            break;
                        }
                    }
                }
            }
        }
    }
}