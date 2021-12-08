using Parser;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Y2021.Day8
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
            var sum = 0;

            List<string> input = InputReader.Read("Day8.txt", x => x);
            foreach (var line in input)
            {
                var data = line.Split("|");
                var dataInput = data[0].Split(" ");

                //I know 1 is build from two elements;
                var one = dataInput.Where(x => x.Length == 2).Single().ToArray();

                //I know 7 is build from 3 eleemnts;
                var seven = dataInput.Where(x => x.Length == 3).Single().ToArray();

                //I know that upperRight and lowerRight elements are common for those digits so I am able to figure out upper element
                var upper = seven.Except(one.ToArray()).Single();

                //I know that digit 4 is build from 4 elements
                var four = dataInput.Where(x => x.Length == 4).Single().ToArray();

                //If I know upper value plus all values used to build digit 4. I am able to find 9 and lower part
                var check = four.ToList();
                check.Add(upper);

                var nine = dataInput.Where(x => x.Length == 6 && x.Except(check).Count() == 1).Single().ToArray();
                var lower = nine.Except(check).Single();

                //If I know nine then I will be able to find 8 and lowerLeft part
                var eight = dataInput.Where(x => x.Length == 7).Single().ToArray();
                var lowerLeft = eight.Except(nine.ToArray()).Single();

                //If I know lower and upper and also I know 1 then I am able to find 3 and middle part
                check = new List<char> { lower, upper };
                check.AddRange(one);
                var three = dataInput.Where(x => x.Length == 5 && x.Except(check).Count() == 1).Single().ToArray();
                var middle = three.Except(check).Single();

                //If i know middle, upper, lower, lowerLeft I can find 2 and upperRight
                check = new List<char> { middle, upper, lower, lowerLeft };
                var two = dataInput.Where(x => x.Length == 5 && x.Except(check).Count() == 1).Single().ToArray();
                var upperRight = two.Except(check).Single();

                //if i know upperRight then from one I can figoure out lowerRight
                var lowerRight = one[0] == upperRight ? one[1] : one[0];

                //if I know every part except upperLeft then I can get it from 8
                check = new List<char> { upper, upperRight, middle, lowerLeft, lowerRight, lower };
                var upperLeft = eight.Except(check).Single();

                var zero = new char[] { upper, upperRight, upperLeft, lowerLeft, lowerRight, lower };
                var five = new char[] { upper, upperLeft, middle, lowerRight, lower };
                var six = new char[] { upper, upperLeft, middle, lowerLeft, lowerRight, lower };

                var dataOutput = data[1].Trim().Split(' ');
                var digits = new List<char[]> { zero, one, two, three, four, five, six, seven, eight, nine };
                var result = 0;
                result += digits.FindIndex(d => d.IsEqual(dataOutput[0])) * 1000;
                result += digits.FindIndex(d => d.IsEqual(dataOutput[1])) * 100;
                result += digits.FindIndex(d => d.IsEqual(dataOutput[2])) * 10;
                result += digits.FindIndex(d => d.IsEqual(dataOutput[3]));
                sum += result;
            }

            _console.WriteLine(sum.ToString());
        }
    }

    public static class Extensions
    {
        public static bool IsEqual(this char[] that, string other)
        {
            if (that.Length != other.Length)
            {
                return false;
            }
            return that.OrderBy(x => x).SequenceEqual(other.OrderBy(o => o));
        }
    }
}