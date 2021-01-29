using System;
using System.Collections.Generic;
using System.Linq;

namespace ShortestPathVisitingAllNodes
{
    public class Solution
    {
        private class State
        {
            public int BitMask { get; set; }
            public int Cur { get; set; }
            public int Cost { get; set; }
            public State(int bit, int n, int c)
            {
                BitMask = bit;
                Cur = n;
                Cost = c;
            }

            public override bool Equals(object obj)
            {
                var p = (State)obj;
                return p.BitMask == BitMask && p.Cur == Cur;
            }

            public override int GetHashCode()
            {
                return BitMask.GetHashCode() ^ Cur.GetHashCode();
            }
        }

        public int ShortestPathLength(int[][] graph)
        {
            int n = graph.Length;
            var q = new Queue<State>();
            var visited = new HashSet<State>();
            for (int i = 0; i < n; i++)
            {
                int nodeBit = (1 << i);
                q.Enqueue(new State(nodeBit, i, 0));
                visited.Add(new State(nodeBit, i, 0));
            }

            while (q.Any())
            {
                var node = q.Dequeue();
                if (node.BitMask==(1<<n)-1)
                {
                    return node.Cost;
                }
                var neighbors = graph[node.Cur];
                foreach (var neighbor in neighbors)
                {
                    var bitMask = node.BitMask | (1 << neighbor);
                    var state = new State(bitMask, neighbor, node.Cost + 1);
                    if (!visited.Contains(state))
                    {
                        q.Enqueue(state);
                        visited.Add(state);
                    }
                }
            }

            return -1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[4][] { new int[] { 1, 2 }, new int[] {0, 3 }, new int[] {0, 3 }, new int[] { 1, 2} };
            var result = new Solution().ShortestPathLength(input);
            Console.WriteLine("Hello World!");
        }
    }
}
