using System;
using System.Collections.Generic;
using System.Linq;

namespace MinCostToMakeAtLeastOneValidPathInGrid
{
    public class Solution
    {
        private int[][] dirs = new int[4][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };
        public int MinCost(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            var costs = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    costs[i, j] = int.MaxValue;
                }
            }

            int cost = 0;
            var q = new Queue<int[]>();
            Dfs(0, 0, grid, q, costs, cost);
            while (q.Any())
            {
                cost++;
                int size = q.Count;
                while (size-- > 0)
                {
                    var node = q.Dequeue();
                    int row = node[0];
                    int column = node[1];
                    foreach (var dir in dirs)
                    {
                        Dfs(row + dir[0], column + dir[1], grid, q, costs, cost);
                    }
                }
            }
            return costs[m - 1, n - 1];
        }

        private void Dfs(int r, int c, int[][] grid, Queue<int[]> q, int[,] costs, int cost)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            if (r < 0 || r >= m || c < 0 || c >= n || costs[r, c] != int.MaxValue)
            {
                return;
            }
            costs[r, c] = cost;
            q.Enqueue(new int[] { r, c });
            int nextDir = grid[r][c] - 1;
            Dfs(r + dirs[nextDir][0], c + dirs[nextDir][1], grid, q, costs, cost);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[4][] { new int[] {1,1,1,1 }, new int[] {2,2,2,2 }, 
                new int[] { 1,1,1,1}, new int[] {2,2,2,2 }, };
            var result = new Solution().MinCost(input);
            Console.WriteLine("Hello World!");
        }
    }
}
