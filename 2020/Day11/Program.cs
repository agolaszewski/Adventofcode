using System;
using System.Collections.Generic;
using System.Linq;
using Parser;

namespace Day11
{
    internal class Program
    {
        public enum State
        {
            Floor = -1,
            Empty = 0,
            Occupied = 1
        }

        private static void Main(string[] args)
        {
            var parser = new InputReader();
            List<State[]> inputs = parser.Read<State[]>("input.txt", line =>
            {
                var array = new State[line.Length];
                for (int i = 0; i < line.Length; i++)
                {
                    switch (line[i])
                    {
                        case '#':
                            {
                                array[i] = State.Occupied;
                                break;
                            }

                        case 'L':
                            {
                                array[i] = State.Empty;
                                break;
                            }

                        case '.':
                            {
                                array[i] = State.Floor;
                                break;
                            }
                    }
                }

                return array;
            });

            bool stateChanged;
            do
            {
                //Draw(inputs);
                stateChanged = false;
                var copy = Copy(inputs);
                for (int i = 0; i < inputs.Count; i++)
                {
                    for (int j = 0; j < inputs[0].Length; j++)
                    {
                        State currentState = inputs[i][j];
                        switch (currentState)
                        {
                            case State.Occupied:
                                {
                                    var hasChanged = CheckAdjacent(inputs, i, j, State.Empty) >= 4;
                                    if (hasChanged)
                                    {
                                        stateChanged = true;
                                        copy[i][j] = State.Empty;
                                    }
                                    else
                                    {
                                        copy[i][j] = State.Occupied;
                                    }
                                    break;
                                }
                            case State.Empty:
                                {
                                    var hasChanged = CheckAdjacent(inputs, i, j, State.Empty) == 0;
                                    if (hasChanged)
                                    {
                                        stateChanged = true;
                                        copy[i][j] = State.Occupied;
                                    }
                                    else
                                    {
                                        copy[i][j] = State.Empty;
                                    }
                                    break;
                                }
                            case State.Floor:
                                {
                                    copy[i][j] = State.Floor;
                                    break;
                                }
                        }
                    }
                }

                inputs = copy;
            } while (stateChanged);

            var result = inputs.SelectMany(x => x).Count(x => x == State.Occupied);
            Console.WriteLine(result);

            inputs = parser.Read<State[]>("input.txt", line =>
            {
                var array = new State[line.Length];
                for (int i = 0; i < line.Length; i++)
                {
                    switch (line[i])
                    {
                        case '#':
                            {
                                array[i] = State.Occupied;
                                break;
                            }

                        case 'L':
                            {
                                array[i] = State.Empty;
                                break;
                            }

                        case '.':
                            {
                                array[i] = State.Floor;
                                break;
                            }
                    }
                }

                return array;
            });

            stateChanged = false;
            do
            {
                //Draw(inputs);
                stateChanged = false;
                var copy = Copy(inputs);
                for (int i = 0; i < inputs.Count; i++)
                {
                    for (int j = 0; j < inputs[0].Length; j++)
                    {
                        State currentState = inputs[i][j];
                        switch (currentState)
                        {
                            case State.Occupied:
                                {
                                    var hasChanged = CheckAdjacent2(inputs, i, j, State.Empty) >= 5;
                                    if (hasChanged)
                                    {
                                        stateChanged = true;
                                        copy[i][j] = State.Empty;
                                    }
                                    else
                                    {
                                        copy[i][j] = State.Occupied;
                                    }
                                    break;
                                }
                            case State.Empty:
                                {
                                    var hasChanged = CheckAdjacent2(inputs, i, j, State.Empty) == 0;
                                    if (hasChanged)
                                    {
                                        stateChanged = true;
                                        copy[i][j] = State.Occupied;
                                    }
                                    else
                                    {
                                        copy[i][j] = State.Empty;
                                    }
                                    break;
                                }
                            case State.Floor:
                                {
                                    copy[i][j] = State.Floor;
                                    break;
                                }
                        }
                    }
                }

                inputs = copy;
            } while (stateChanged);

            result = inputs.SelectMany(x => x).Count(x => x == State.Occupied);
            Console.WriteLine(result);
        }

        private static void Draw(List<State[]> inputs)
        {
            Console.Clear();
            for (int i = 0; i < inputs.Count; i++)
            {
                for (int j = 0; j < inputs[0].Length; j++)
                {
                    switch (inputs[i][j])
                    {
                        case State.Occupied:
                            {
                                Console.Write("#");
                                break;
                            }

                        case State.Empty:
                            {
                                Console.Write("L");
                                break;
                            }

                        case State.Floor:
                            {
                                Console.Write(".");
                                break;
                            }
                    }
                }
                Console.WriteLine();
            }
        }

        private static List<State[]> Copy(List<State[]> inputs)
        {
            return inputs.Select(x => new State[inputs[0].Length]).ToList();
        }

        private static int CheckAdjacent2(List<State[]> inputs, int i, int j, State checkAgainst)
        {
            int isRuleSatisfied = 0;

            for (int y = j + 1; y < inputs[0].Length; y++)
            {
                var result = Check2(inputs, i, y, checkAgainst);
                if (result != State.Floor)
                {
                    if (result == State.Occupied)
                    {
                        isRuleSatisfied++;
                    }
                    break;
                }
            }

            for (int y = j - 1; y >= 0; y--)
            {
                var result = Check2(inputs, i, y, checkAgainst);
                if (result != State.Floor)
                {
                    if (result == State.Occupied)
                    {
                        isRuleSatisfied++;
                    }
                    break;
                }
            }

            for (int x = i + 1; x < inputs.Count; x++)
            {
                var result = Check2(inputs, x, j, checkAgainst);
                if (result != State.Floor)
                {
                    if (result == State.Occupied)
                    {
                        isRuleSatisfied++;
                    }
                    break;
                }
            }

            for (int x = i - 1; x >= 0; x--)
            {
                var result = Check2(inputs, x, j, checkAgainst);
                if (result != State.Floor)
                {
                    if (result == State.Occupied)
                    {
                        isRuleSatisfied++;
                    }
                    break;
                }
            }

            int y2 = 1;
            for (int x = i + 1; x < inputs.Count; x++)
            {
                var result = Check2(inputs, x, j - y2, checkAgainst);
                if (result != State.Floor)
                {
                    if (result == State.Occupied)
                    {
                        isRuleSatisfied++;
                    }
                    break;
                }

                y2++;
            }

            y2 = 1;
            for (int x = i + 1; x < inputs.Count; x++)
            {
                var result = Check2(inputs, x, j + y2, checkAgainst);
                if (result != State.Floor)
                {
                    if (result == State.Occupied)
                    {
                        isRuleSatisfied++;
                    }
                    break;
                }

                y2++;
            }

            y2 = 1;
            for (int x = i - 1; x >= 0; x--)
            {
                var result = Check2(inputs, x, j - y2, checkAgainst);
                if (result != State.Floor)
                {
                    if (result == State.Occupied)
                    {
                        isRuleSatisfied++;
                    }
                    break;
                }

                y2++;
            }

            y2 = 1;
            for (int x = i - 1; x >= 0; x--)
            {
                var result = Check2(inputs, x, j + y2, checkAgainst);
                if (result != State.Floor)
                {
                    if (result == State.Occupied)
                    {
                        isRuleSatisfied++;
                    }
                    break;
                }

                y2++;
            }

            return isRuleSatisfied;
        }

        private static int CheckAdjacent(List<State[]> inputs, int i, int j, State checkAgainst)
        {
            int isRuleSatisfied = 0;
            for (int x = i - 1; x <= i + 1; x++)
            {
                for (int y = j - 1; y <= j + 1; y++)
                {
                    if (x == i && y == j)
                    {
                        continue;
                    }

                    if (Check2(inputs, x, y, checkAgainst) == State.Occupied)
                    {
                        isRuleSatisfied++;
                    }
                }
            }

            return isRuleSatisfied;
        }

        private static State Check2(List<State[]> inputs, int x, int y, State checkAgainst)
        {
            if (x < 0 || x >= inputs.Count)
            {
                return State.Floor;
            }

            if (y < 0 || y >= inputs[x].Length)
            {
                return State.Floor;
            }

            return inputs[x][y];
        }
    }
}