using System;
using System.Collections.Generic;
using System.Linq;
using Parser;

namespace Day7
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var parser = new InputReader();
            List<Input> inputs = parser.Read("input.txt", line =>
            {
                //light red bags contain 1 bright white bag, 2 muted yellow bags.
                var name = line.Substring(0, line.IndexOf("bags")).Trim();
                var contains = line
                    .Substring(line.IndexOf("contain") + 7)
                    .Replace("bags", string.Empty)
                    .Replace("bag", string.Empty)
                    .Replace(".", string.Empty)
                    .Split(',').Select(element =>
                    {
                        element = element.Trim();

                        if (element == "no other")
                        {
                            return null;
                        }

                        int spaceIndex = element.IndexOf(' ');
                        string number = element.Substring(0, spaceIndex);
                        element = element.Substring(spaceIndex + 1);

                        return new Contains()
                        {
                            Name = element,
                            Number = int.Parse(number)
                        };
                    });

                return new Input()
                {
                    Name = name,
                    Contains = contains.Where(x => x != null).ToList()
                };
            });

            List<Bag> bags = new List<Bag>();
            foreach (var input in inputs)
            {
                var bag = bags.FirstOrDefault(x => x.Name == input.Name);
                if (bag is null)
                {
                    bag = new Bag()
                    {
                        Name = input.Name
                    };
                    bags.Add(bag);
                }

                foreach (var contain in input.Contains)
                {
                    var bag2 = bags.FirstOrDefault(x => x.Name == contain.Name);
                    if (bag2 is null)
                    {
                        bag2 = new Bag()
                        {
                            Name = contain.Name
                        };
                        bags.Add(bag2);
                    }
                    bag2.CanBePutIn.Add(bag);
                }
            }

            var acc = Calculate(bags.FirstOrDefault(x => x.Name == "shiny gold").CanBePutIn);
            Console.WriteLine(acc);

            acc = Traverse("shiny gold", 1, inputs);
            Console.WriteLine(acc - 1);
        }

        private static int Traverse(string parent, int amount, List<Input> inputs)
        {
            var bag = inputs.FirstOrDefault(x => x.Name == parent);
            var sum = amount;

            foreach (var contain in bag.Contains)
            {
                sum += Traverse(contain.Name, contain.Number * amount, inputs);
            }

            return sum;
        }

        public static int Calculate(List<Bag> bags)
        {
            var acc = 0;
            foreach (var bag in bags)
            {
                if (!bag.IsVisited)
                {
                    acc++;
                    bag.IsVisited = true;
                    acc += Calculate(bag.CanBePutIn);
                }
            }

            return acc;
        }

        public class Bag
        {
            public string Name { get; set; }
            public List<Bag> CanBePutIn { get; set; } = new List<Bag>();
            public bool IsVisited = false;
        }
    }
}