using System;
using System.Collections.Generic;

namespace ImplementTrie
{
    public class Trie
    {
        private class TrieNode
        {
            public char Val { get; set; }
            public bool IsWord { get; set; }
            public TrieNode[] Next { get; set; }
            public TrieNode(char ch)
            {
                Val = ch;
                Next = new TrieNode[26];
            }
        }
        private TrieNode root;
        /** Initialize your data structure here. */
        public Trie()
        {
            root = new TrieNode(' ');
        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            var p = root;
            foreach (var ch in word)
            {
                int idx = ch - 'a';
                if (p.Next[idx] == null)
                {
                    p.Next[idx] = new TrieNode(ch);
                }
                p = p.Next[idx];
            }
            p.IsWord = true;
        }

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            var p = root;
            foreach (var ch in word)
            {
                int idx = ch - 'a';
                if (p.Next[idx] == null)
                {
                    return false;
                }
                p = p.Next[idx];
            }
            return p.IsWord;
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            var p = root;
            foreach (var ch in prefix)
            {
                int idx = ch - 'a';
                if (p.Next[idx] == null)
                {
                    return false;
                }
                p = p.Next[idx];
            }
            return true;
        }
    }
    public class Node
    {

    }
    class Program
    {
        static void Main(string[] args)
        {
            var nodes = new List<Node>() { new Node() };
            var n1 = nodes[0];
            n1 = null;

            Console.WriteLine("Hello World!");
        }
    }
}
