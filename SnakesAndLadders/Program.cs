using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakesAndLadders
{
    public class Solution
    {
        public int SnakesAndLadders(int[][] board)
        {
            int n = board.Length;
            var q = new Queue<int>();
            q.Enqueue(1);
            var steps = new Dictionary<int, int>();
            steps[1] = 0;
            while (q.Any())
            {
                int node = q.Dequeue();
                if (node == n * n)
                {
                    return steps[node];
                }
                for (int next = node + 1; next <= Math.Min(node + 6, n * n); next++)
                {
                    var coordinates = GetCoordiates(next, n);
                    int x = coordinates.Item1;
                    int y = coordinates.Item2;
                    int final = board[x][y] == -1 ? next : board[x][y];
                    if (!steps.ContainsKey(final))
                    {
                        steps[final] = steps[node] + 1;
                        q.Enqueue(final);
                    }
                    
                }
            }
            return -1;
        }

        private Tuple<int, int> GetCoordiates(int s, int n)
        {
            int r = (s-1) / n;
            int x = n - 1 - r;
            int y = r % 2 == 0 ? s - 1 - r * n : n + r * n - s;
            return Tuple.Create(x, y);            
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
