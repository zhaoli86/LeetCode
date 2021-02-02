using System;
using System.Collections.Generic;
using System.Linq;

namespace WordLadder
{
    public class Solution
    {
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            var q = new Queue<string>();
            var visited = new HashSet<string>();
            var wordSet = wordList.ToHashSet();
            int len = 1;
            q.Enqueue(beginWord);
            //visited.Add(beginWord);

            while (q.Any())
            {
                int size = q.Count;
                while (size-- > 0)
                {
                    var node = q.Dequeue();
                    if (node == endWord)
                    {
                        return len;
                    }
                    for (int i = 0; i < beginWord.Length; i++)
                    {
                        var ca = node.ToCharArray();

                        for (char c = 'a'; c <= 'z'; c++)
                        {
                            if (ca[i] == c)
                            {
                                continue;
                            }
                            ca[i] = c;
                            var nw = new string(ca);
                            if (wordSet.Contains(nw) && visited.Add(nw))
                            {
                                q.Enqueue(nw);
                            }
                        }
                    }
                }
                len++;
            }
            return 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var input = new List<string> { "hot", "dot", "dog", "lot", "log", "cog" };
            var result = new Solution().LadderLength("hit", "cog", input);
            Console.WriteLine("Hello World!");
        }
    }
}
