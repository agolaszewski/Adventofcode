using Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Y2021.Day3
{
    public class Part2
    {
        private readonly ITestOutputHelper _console;

        public Part2(ITestOutputHelper console)
        {
            _console = console;
        }

        [Fact]
        public void Solution()
        {
            var inputOriginal = InputReader.Read("Day3.txt", line => line);
            var input = inputOriginal.ToList();

            var position = 0;
            while (input.Count != 1)
            {
                input = CalculateOxygenRating(input, position);
                position++;
            }
            var oxygenRating = Convert.ToInt64(input[0], 2);

            position = 0;
            input = inputOriginal.ToList();
            while (input.Count != 1)
            {
                input = CalculateCO2Rating(input, position);
                position++;
            }
            var co2Rating = Convert.ToInt64(input[0], 2);
            var answer = oxygenRating * co2Rating;
            _console.WriteLine(answer.ToString());
        }

        private List<string> CalculateOxygenRating(List<string> input, int position)
        {
            var count = input.Count(line => line[position] == '1');

            var isOne = count >= input.Count - count;
            input = input.Where(line =>
            {
                var selected = isOne ? '1' : '0';
                return line[position] == selected;
            }).ToList();

            return input;
        }

        private List<string> CalculateCO2Rating(List<string> input, int position)
        {
            var count = input.Count(line => line[position] == '0');

            var isZero = count <= input.Count - count;
            input = input.Where(line =>
            {
                var selected = isZero ? '0' : '1';
                return line[position] == selected;
            }).ToList();

            return input;
        }
    }
}