using System;
using System.Collections.Generic;
using System.Linq;

namespace NetworkDelayTime
{
    public class Solution
    {
        private Dictionary<int, int> distance = new Dictionary<int, int>();

        public int NetworkDelayTime(int[][] times, int n, int k)
        {
            var graph = new Dictionary<int, List<int[]>>();

            for (int i = 0; i < times.Length; i++)
            {
                if (!graph.ContainsKey(times[i][0]))
                {
                    graph[times[i][0]] = new List<int[]>();
                }

                graph[times[i][0]].Add(new int[] { times[i][1], times[i][2] });
            }

            foreach (var item in graph.Values)
            {
                item.Sort(delegate (int[] x, int[] y) { return x[1].CompareTo(y[1]); });
            }
            for (int i = 1; i <= n; i++)
            {
                distance[i] = int.MaxValue;
            }

            Dfs(graph, k, 0);

            int result = 0;
            foreach (var item in distance.Values)
            {
                if (item == int.MaxValue)
                {
                    return -1;
                }
                result = Math.Max(result, item);
            }
            return result;
        }

        private void Dfs(Dictionary<int, List<int[]>> graph, int k, int elapsed)
        {
            if (elapsed>=distance[k])
            {
                return;
            }
            distance[k] = elapsed;
            if (graph.ContainsKey(k))
            {
                foreach (var item in graph[k])
                {
                    Dfs(graph, item[0], elapsed + item[1]);
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[][] { new int[] { 2, 1, 1 }, new int[] { 2, 3, 1 }, new int[] { 3, 4, 1 } };
            var result = new Solution().NetworkDelayTime(input, 4, 2);
            Console.WriteLine("Hello World!");
        }
    }
}
