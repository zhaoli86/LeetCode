using System;

namespace SudokuSolver
{
    public class Solution
    {
        public void SolveSudoku(char[][] board)
        {
            if (board == null || board.Length == 0)
            {
                return;
            }
            Solve(board);
        }

        private bool Solve(char[][] board)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j] == '.')
                    {
                        for (char k = '1'; k <= '9'; k++)
                        {
                            if (IsValid(board, i, j, k))
                            {
                                board[i][j] = k;

                                if (Solve(board))
                                {
                                    return true;
                                }

                                else board[i][j] = '.';
                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        }

        private bool IsValid(char[][] board, int r, int c, char k)
        {
            for (int i = 0; i < 9; i++)
            {
                if (board[r][i] == k)
                {
                    return false;
                }
                if (board[i][c] == k)
                {
                    return false;
                }
                if (board[(r / 3) * 3 + i / 3][(c / 3) * 3 + i % 3] == k)
                {
                    return false;
                }
            }
            return true;

        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");
        }
    }
}
