using System;
using System.Collections.Generic;
using System.Linq;

namespace WordLadderII
{
    public class Solution
    {
        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
        {
            var neighbors = new Dictionary<string, List<string>>();
            var words = new HashSet<string>(wordList);
            words.Add(beginWord);
            var result = new List<IList<string>>();
            var distance = new Dictionary<string, int>();
            var curList = new List<string>();

            Bfs(beginWord, endWord, words, neighbors, distance);
            Dfs(beginWord, endWord, words, neighbors, distance, curList, result);
            return result;
        }
        private void Bfs(string beginWord, string endWord, HashSet<string> words,
            Dictionary<string, List<string>> neighbors, Dictionary<string, int> distance)
        {
            foreach (var str in words)
            {
                neighbors[str] = new List<string>();
            }
            var q = new Queue<string>();
            q.Enqueue(beginWord);
            distance[beginWord] = 0;

            while (q.Any())
            {
                int count = q.Count;
                while (count-- > 0)
                {
                    string cur = q.Dequeue();
                    int curDistance = distance[cur];
                    foreach (var neighbor in GetNeighbors(cur, words))
                    {
                        neighbors[cur].Add(neighbor);
                        if (!distance.ContainsKey(neighbor))
                        {
                            distance[neighbor] = curDistance + 1;

                            if (neighbor!=endWord)
                            {
                                q.Enqueue(neighbor);
                            }
                        }
                    }
                }
            }
        }

        private List<string> GetNeighbors(string node, HashSet<string> words)
        {
            var neighbors = new List<string>();
            var ca = node.ToCharArray();

            for (int i = 0; i < node.Length; i++)
            {
                for (char c = 'a'; c <= 'z'; c++)
                {
                    if (ca[i] == c)
                    {
                        continue;
                    }
                    else
                    {
                        var oldCh = ca[i];
                        ca[i] = c;
                        var ns = new string(ca);
                        if (words.Contains(ns))
                        {
                            neighbors.Add(ns);
                        }
                        ca[i] = oldCh;
                    }
                }
            }
            return neighbors;
        }

        private void Dfs(string beginWord, string endWord, HashSet<string> words, 
            Dictionary<string, List<string>> neighbors, Dictionary<string, int> distance, 
            List<string> curList, List<IList<string>> result)
        {
            curList.Add(beginWord);
            if (beginWord==endWord)
            {
                result.Add(new List<string>(curList));
            }
            foreach (var neighbor in neighbors[beginWord])
            {
                if (distance[neighbor]==distance[beginWord]+1)
                {
                    Dfs(neighbor, endWord, words, neighbors, distance, curList, result);
                }
            }
            curList.RemoveAt(curList.Count - 1);
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            string start = "hit", end = "cog";
            var list = new List<string> { "hot", "dot", "dog", "lot", "log", "cog" };
            var result = new Solution().FindLadders(start, end, list);

            Console.WriteLine("Hello World!");
        }
    }
}
