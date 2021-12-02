using System;
using System.Collections.Generic;
using System.Linq;
using Parser;

namespace Day8
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            P1();
            P2();
        }

        private static void P2()
        {
            var parser = new InputReader();
            List<Input> inputs = parser.Read<Input>("input.txt", line =>
            {
                //acc +19
                var split = line.Split(' ');
                var value = int.Parse(split[1].Substring(1));
                var sign = split[1][0];

                return new Input()
                {
                    Instruction = split[0],
                    Value = sign == '-' ? value * -1 : value
                };
            });

            var index = 0;
            do
            {   
                inputs.ForEach(x => x.IsExecuted = false);
                index = Find(index * -1, inputs);
            } while (index <= 0);

            Console.WriteLine(index);
        }

        private static int Find(int index, List<Input> inputs)
        {
            if (inputs[index].Instruction == "acc")
            {
                return -(index + 1);
            }

            inputs[index].Instruction = inputs[index].Instruction == "jmp" ? "nop" : "jmp";

            int i = 0;
            int acc = 0;
           
            while (i < inputs.Count)
            {
                var row = inputs[i];

                if (row.IsExecuted)
                {
                    inputs[index].Instruction = inputs[index].Instruction == "jmp" ? "nop" : "jmp";
                    return -(index + 1);
                }

                switch (row.Instruction)
                {
                    case ("acc"):
                        {
                            acc += row.Value;
                            i++;
                            break;
                        }
                    case ("nop"):
                        {
                            i++;
                            break;
                        }
                    case ("jmp"):
                        {
                            i += row.Value;
                            break;
                        }
                }

                row.IsExecuted = true;
            }

            return acc;
        }

        private static void P1()
        {
            var parser = new InputReader();
            List<Input> inputs = parser.Read<Input>("input.txt", line =>
            {
                //acc +19
                var split = line.Split(' ');
                var value = int.Parse(split[1].Substring(1));
                var sign = split[1][0];

                return new Input()
                {
                    Instruction = split[0],
                    Value = sign == '-' ? value * -1 : value
                };
            });

            int i = 0;
            int acc = 0;
            while (!inputs[i].IsExecuted)
            {
                var row = inputs[i];

                switch (row.Instruction)
                {
                    case ("acc"):
                        {
                            acc += row.Value;
                            i++;
                            break;
                        }
                    case ("nop"):
                        {
                            i++;
                            break;
                        }
                    case ("jmp"):
                        {
                            i += row.Value;
                            break;
                        }
                }

                row.IsExecuted = true;
            }

            Console.WriteLine(acc);
        }
    }
}