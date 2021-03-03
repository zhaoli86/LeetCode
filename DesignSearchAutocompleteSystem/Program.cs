using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignSearchAutocompleteSystem
{
    public class AutocompleteSystem
    {
        private class Node
        {
            public string Sentence { get; set; }
            public int Times { get; set; }
            public Node(string sentence, int times)
            {
                Sentence = sentence;
                Times = times;
            }
        }

        private class TrieNode
        {
            public TrieNode[] Branch { get; set; } = new TrieNode[27];
            public int Times { get; set; }
        }

        private TrieNode root = new TrieNode();
        private string curSent = "";

        private int ToInt(char c)
        {
            return c == ' ' ? 26 : c - 'a';
        }

        public AutocompleteSystem(string[] sentences, int[] times)
        {
            for (int i = 0; i < sentences.Length; i++)
            {
                Insert(root, sentences[i], times[i]);
            }
        }

        private void Insert(TrieNode root, string sentence, int times)
        {
            var p = root;
            foreach (var ch in sentence)
            {
                if (p.Branch[ToInt(ch)] == null)
                {
                    p.Branch[ToInt(ch)] = new TrieNode();
                }
                p = p.Branch[ToInt(ch)];
            }
            p.Times += times;
        }

        public IList<string> Input(char c)
        {
            var result = new List<string>();
            if (c == '#')
            {
                Insert(root, curSent, 1);
                curSent = "";
            }
            else
            {
                curSent += c;
                List<Node> list = Lookup(root, curSent);
                result = list.OrderByDescending(n => n.Times).ThenBy(n => n.Sentence).Take(3).Select(n => n.Sentence).ToList();
            }

            return result;
        }

        private List<Node> Lookup(TrieNode root, string s)
        {
            var list = new List<Node>();
            var p = root;
            foreach (var ch in s)
            {
                if (p.Branch[ToInt(ch)]==null)
                {
                    return new List<Node>();
                }
                p = p.Branch[ToInt(ch)];
            }

            Traverse(p, s, list);
            return list;
        }

        private void Traverse(TrieNode p, string s, List<Node> list)
        {
            if (p.Times>0)
            {
                list.Add(new Node(s, p.Times));
            }
            for (char c='a'; c<='z'; c++)
            {
                if (p.Branch[ToInt(c)]!=null)
                {
                    Traverse(p.Branch[ToInt(c)], s + c, list);
                }
            }

            if (p.Branch[26]!=null)
            {
                Traverse(p.Branch[26], s + ' ', list);
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> { 1, 2 };
            list = list.Take(3).ToList();
            Console.WriteLine("Hello World!");
        }
    }
}
