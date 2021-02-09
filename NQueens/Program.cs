using System;
using System.Collections.Generic;

namespace NQueens
{
    public class Solution
    {
        public IList<IList<string>> SolveNQueens(int n)
        {
            var board = new char[n][];
            for (int i = 0; i < n; i++)
            {
                board[i] = new char[n];
                for (int j = 0; j < n; j++)
                {
                    board[i][j] = '.';
                }
            }

            var result = new List<IList<string>>();
            Dfs(result, board, 0);
            return result;
        }

        private void Dfs(List<IList<string>> result, char[][] board, int row)
        {
            if (row == board.Length)
            {
                result.Add(Construct(board));
            }
            else
            {
                for (int col = 0; col < board.Length; col++)
                {
                    if (IsValid(board, row, col))
                    {
                        board[row][col] = 'Q';
                        Dfs(result, board, row + 1);
                        board[row][col] = '.';
                    }
                }
            }
        }

        private bool IsValid(char[][] board, int row, int col)
        {
            //check col
            for (int i = 0; i < row; i++)
            {
                if (board[i][col] == 'Q')
                {
                    return false;
                }
            }
            //check 135 degree
            for (int r = row - 1, c = col - 1; r >= 0 && c >= 0; r--, c--)
            {
                if (board[r][c] == 'Q')
                {
                    return false;
                }
            }
            //check 45 degree
            for (int r = row - 1, c = col + 1; r >= 0 && c < board.Length; r--, c++)
            {
                if (board[r][c] == 'Q')
                {
                    return false;
                }
            }
            return true;
        }

        private IList<string> Construct(char[][] board)
        {
            var result = new List<string>();
            foreach (var item in board)
            {
                result.Add(new string(item));
            }
            return result;
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
