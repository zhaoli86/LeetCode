using System;
using System.Collections.Generic;

namespace WordSearchII
{
    public class Solution
    {
        private class Trie
        {
            public Trie[] Next { get; set; } = new Trie[26];
            public string Word { get; set; }
        }

        public IList<string> FindWords(char[][] board, string[] words)
        {
            var result = new List<string>();
            var root = BuildTrie(words);
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    Dfs(board, root, i, j, result);
                }
            }
            return result;
        }

        private void Dfs(char[][] board, Trie p, int i, int j, List<string> result)
        {
            char c = board[i][j];

            if (c == '#' || p.Next[c - 'a'] == null)
            {
                return;
            }

            p = p.Next[c - 'a'];

            if (p.Word != null)
            {
                result.Add(p.Word);

                p.Word = null;
            }

            board[i][j] = '#';

            if (i > 0)
            {
                Dfs(board, p, i - 1, j, result);
            }
            if (j > 0)
            {
                Dfs(board, p, i, j - 1, result);
            }
            if (i < board.Length - 1)
            {
                Dfs(board, p, i + 1, j, result);
            }
            if (j < board[0].Length - 1)
            {
                Dfs(board, p, i, j + 1, result);
            }

            board[i][j] = c;
        }

        private Trie BuildTrie(string[] words)
        {
            var root = new Trie();
            foreach (var w in words)
            {
                var p = root;
                foreach (var c in w.ToCharArray())
                {
                    int i = c - 'a';
                    if (p.Next[i] == null)
                    {
                        p.Next[i] = new Trie();
                    }
                    p = p.Next[i];

                }
                p.Word = w;
            }
            return root;
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
