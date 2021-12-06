using Parser;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Y2021.Day6
{
    public class Part1
    {
        public class Fish
        {
            private int _days;

            public Fish(int days)
            {
                _days = days;
            }

            public Fish GetOlder()
            {
                _days -= 1;
                if (_days == -1)
                {
                    _days = 6;
                    return new Fish(8);
                }
                return null;
            }
        }

        private readonly ITestOutputHelper _console;

        public Part1(ITestOutputHelper console)
        {
            _console = console;
        }

        [Fact]
        public void Solution()
        {
            var fishes = InputReader.ReadTo("Day6.txt", line =>
            {
                return line[0].Split(',').Select(x =>
                {
                    int days = int.Parse(x.Trim());
                    return new Fish(days);
                });
            }).ToList();

            for(int days = 1; days <= 80; days++)
            {
                var newFishes = new List<Fish>();
                foreach (var fish in fishes)
                {
                    var newFish = fish.GetOlder();
                    if(newFish != null)
                    {
                        newFishes.Add(newFish);
                    }
                }
                fishes.AddRange(newFishes);
            }

            _console.WriteLine(fishes.Count.ToString());
        }
    }
}