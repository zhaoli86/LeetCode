using System;

namespace PrefixAndSuffixSearch
{
    public class WordFilter
    {
        private class TrieNode
        {
            public TrieNode[] Next { get; set; } = new TrieNode[27];
            public int Weight { get; set; }

            public void Insert(string word, int weight)
            {
                var cur = this;
                foreach (var ch in word)
                {
                    if (cur.Next[ch - 'a'] == null)
                    {
                        cur.Next[ch - 'a'] = new TrieNode();
                    }
                    cur = cur.Next[ch - 'a'];
                    cur.Weight = weight;
                }
            }

            public int StartsWith(string s)
            {
                var p = this;
                foreach (var ch in s)
                {
                    if (p.Next[ch - 'a'] == null)
                    {
                        return -1;
                    }
                    p = p.Next[ch - 'a'];
                }
                return p.Weight;
            }
        }


        private readonly TrieNode root = new TrieNode();
        public WordFilter(string[] words)
        {
            for (int i = 0; i < words.Length; i++)
            {
                var word = words[i];

                for (int j = 0; j <= word.Length; j++)
                {
                    root.Insert(word.Substring(j) + "{" + word, i);
                }
            }
        }

        public int F(string prefix, string suffix)
        {
            return root.StartsWith(suffix + "{" + prefix);
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
