using System;

namespace DesignAddAndSearchWordsDataStructure
{

    public class WordDictionary
    {
        private class TrieNode
        {
            public bool IsWord { get; set; }
            public TrieNode[] Next { get; set; } = new TrieNode[26];
        }

        private TrieNode root = new TrieNode();

        public void AddWord(string word)
        {
            var p = root;

            foreach (var ch in word)
            {
                int idx = ch - 'a';
                if (p.Next[idx] == null)
                {
                    p.Next[idx] = new TrieNode();
                }
                p = p.Next[idx];
            }

            p.IsWord = true;
        }

        public bool Search(string word)
        {
            return Match(word, 0, root);
        }

        private bool Match(string word, int pos, TrieNode node)
        {
            if (pos == word.Length)
            {
                return node.IsWord;
            }
            if (word[pos] == '.')
            {
                for (int i = 0; i < 26; i++)
                {
                    if (node.Next[i] != null && Match(word, pos + 1, node.Next[i]))
                    {
                        return true;
                    }
                }
            }
            else
            {
                return node.Next[word[pos] - 'a'] != null && Match(word, pos + 1, node.Next[word[pos] - 'a']);
            }
            return false;
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
