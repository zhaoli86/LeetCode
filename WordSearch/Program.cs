using System;

namespace WordSearch
{
    public class Solution
    {
        public bool Exist(char[][] board, string word)
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (Exist(board, word, i, j, 0))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool Exist(char[][] board, string word, int i, int j, int pos)
        {
            if (pos == word.Length)
            {
                return true;
            }
            if (i < 0 || j < 0 || i >= board.Length || j >= board[0].Length || board[i][j] != word[pos])
            {
                return false;
            }
            var c = board[i][j];
            board[i][j] = '*';
            var result = Exist(board, word, i + 1, j, pos + 1) || Exist(board, word, i - 1, j, pos + 1)
                || Exist(board, word, i, j + 1, pos + 1) || Exist(board, word, i, j - 1, pos + 1);
            board[i][j] = c;

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
