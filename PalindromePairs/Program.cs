using System;
using System.Collections.Generic;

namespace PalindromePairs
{
    public class Solution
    {
        private class TrieNode
        {
            public TrieNode[] Next { get; set; } = new TrieNode[26];
            public int Index { get; set; } = -1;
            public List<int> List { get; set; } = new List<int>();
        }

        public IList<IList<int>> PalindromePairs(string[] words)
        {
            var result = new List<IList<int>>();
            var root = new TrieNode();
            for (int i = 0; i < words.Length; i++)
            {
                AddWord(root, words[i], i);
            }

            for (int i = 0; i < words.Length; i++)
            {
                Search(words, i, root, result);
            }
            return result;
        }

        private void Search(string[] words, int i, TrieNode root, List<IList<int>> result)
        {
            for (int j = 0; j < words[i].Length; j++)
            {
                if (root.Index >= 0 && root.Index != i && IsPalindrome(words[i], j, words[i].Length - 1))
                {
                    result.Add(new List<int> { i, root.Index });
                }

                root = root.Next[words[i][j] - 'a'];
                if (root == null)
                {
                    return;
                }
            }

            foreach (var j in root.List)
            {
                if (i == j)
                {
                    continue;
                }
                result.Add(new List<int> { i, j });
            }
        }


        private void AddWord(TrieNode root, string word, int index)
        {
            for (int i = word.Length - 1; i >= 0; i--)
            {
                int j = word[i] - 'a';
                if (root.Next[j] == null)
                {
                    root.Next[j] = new TrieNode();
                }

                if (IsPalindrome(word, 0, i))
                {
                    root.List.Add(index);
                }

                root = root.Next[j];
            }
            root.List.Add(index);
            root.Index = index;
        }

        private bool IsPalindrome(string word, int i, int j)
        {
            while (i < j)
            {
                if (word[i++] != word[j--])
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
