using System;
using System.Collections.Generic;
using System.Linq;
using Parser;

namespace Day2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var parser = new InputReader();
            List<Input> inputs = parser.Read<Input>("input.txt", line =>
            {
                //1-3 a: abcde
                var array = line.Split(' ');
                var minMaxArray = array[0].Split('-');

                return new Input()
                {
                    Min = int.Parse(minMaxArray[0]),
                    Max = int.Parse(minMaxArray[1]),
                    CharToValidate = array[1][0],
                    Password = array[2]
                };
            });

            int validPassword = 0;
            foreach (var input in inputs)
            {
                int charInPassword = input.Password.Count(x => x == input.CharToValidate);
                if (charInPassword >= input.Min && charInPassword <= input.Max)
                {
                    validPassword++;
                }
            }

            Console.WriteLine(validPassword);

            validPassword = 0;
            foreach (var input in inputs)
            {
                if (input.Password[input.Min - 1] == input.CharToValidate ^ input.Password[input.Max - 1] == input.CharToValidate)
                {
                    validPassword++;
                }
            }

            Console.WriteLine(validPassword);
        }
    }
}