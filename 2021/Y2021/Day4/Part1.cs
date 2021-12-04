using Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Y2021.Day4
{
    public class Part1
    {
        public class Input
        {
            public Input(List<int> numbers, List<int[][]> boards)
            {
                Numbers = numbers;
                Boards = boards;
            }

            public List<int> Numbers { get; }
            public List<int[][]> Boards { get; }
        }

        private readonly ITestOutputHelper _console;

        public Part1(ITestOutputHelper console)
        {
            _console = console;
        }

        [Fact]
        public void Solution()
        {
            var input = InputReader.ReadTo("Day4.txt", lines =>
            {
                var numbers = lines[0].Split(',').Select(number => int.Parse(number)).ToList();
                List<int[][]> boards = new List<int[][]>();
                for (int i = 2; i < lines.Count; i += 6)
                {
                    int[][] board = new int[5][];
                    for (var row = 0; row < 5; row++)
                    {
                        board[row] = lines[i + row].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(number => int.Parse(number)).ToArray();
                    }
                    boards.Add(board);
                }

                return new Input(numbers, boards);
            });

            var result = FindResult(input);
            _console.WriteLine(result.ToString());
        }

        private int FindResult(Input input)
        {
            var numbers = input.Numbers;
            var boards = input.Boards;
            List<bool[,]> checkBoards = boards.Select(b => new bool[5, 5]).ToList();

            foreach (var luckyNumber in numbers)
            {
                for (var boardNo = 0; boardNo < boards.Count; boardNo++)
                {
                    for (int x = 0; x < 5; x++)
                    {
                        for (int y = 0; y < 5; y++)
                        {
                            if (boards[boardNo][x][y] == luckyNumber)
                            {
                                checkBoards[boardNo][x, y] = true;
                                if (CheckColumn(checkBoards[boardNo], x) || CheckRow(checkBoards[boardNo], y))
                                {
                                    return CalculateResult(boards[boardNo], checkBoards[boardNo], luckyNumber);
                                }
                            }
                        }
                    }
                }
            }

            throw new Exception("Should be at least one winning board");
        }

        private int CalculateResult(int[][] board, bool[,] checkBoard, int luckyNumber)
        {
            int sum = 0;
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    if (checkBoard[x, y] == false)
                    {
                        sum += board[x][y];
                    }
                }
            }

            return sum * luckyNumber;
        }

        private bool CheckColumn(bool[,] board, int x)
        {
            for (int i = 0; i < 5; i++)
            {
                if (board[x, i] == false)
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckRow(bool[,] board, int y)
        {
            for (int i = 0; i < 5; i++)
            {
                if (board[i, y] == false)
                {
                    return false;
                }
            }
            return true;
        }
    }
}