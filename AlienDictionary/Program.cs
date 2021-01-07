using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlienDictionary
{
    public class Solution
    {
        public string AlienOrder(string[] words)
        {
            var degree = new Dictionary<char, int>();
            var set = new Dictionary<char, HashSet<char>>();
            var result = new StringBuilder();

            if (words==null || words.Length==0)
            {
                return "";
            }

            foreach (var word in words)
            {
                foreach (var ch in word)
                {
                    degree[ch] = 0;
                }
            }

            for (int i = 0; i < words.Length-1; i++)
            {
                var cur = words[i];
                var next = words[i + 1];
                if (cur.Length>next.Length && cur.StartsWith(next))
                {
                    return "";
                }
                var len = Math.Min(cur.Length, next.Length);
                for (int j = 0; j < len; j++)
                {
                    if (cur[j]!=next[j])
                    {
                        if (set.ContainsKey(cur[j]))
                        {
                            if (set[cur[j]].Add(next[j]))
                            {
                                degree[next[j]]++;
                            }

                        }
                        else
                        {
                            set[cur[j]] = new HashSet<char> { next[j] };
                            degree[next[j]]++;
                        }
                        break;
                    }
                }
            }

            var q = new Queue<char>();

            foreach (var item in degree)
            {
                if (item.Value==0)
                {
                    q.Enqueue(item.Key);
                }
            }

            while (q.Any())
            {
                var c = q.Dequeue();
                result.Append(c);
                if (set.ContainsKey(c))
                {
                    foreach (var child in set[c])
                    {
                        degree[child]--;
                        if (degree[child] == 0)
                        {
                            q.Enqueue(child);
                        }
                    }
                }
            }

            if (degree.Count!=result.Length)
            {
                return "";
            }

            return result.ToString();

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var input = new string[] { "abc", "ab"};
            var result = new Solution().AlienOrder(input);
            Console.WriteLine("Hello World!");
        }
    }
}
