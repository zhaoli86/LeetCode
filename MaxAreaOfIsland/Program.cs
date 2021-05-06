using System;

namespace MaxAreaOfIsland
{
    public class Solution
    {
        private int max;
        private int curMax;
        public int MaxAreaOfIsland(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j]==1)
                    {
                        curMax = 0;
                        Dfs(grid, i, j);
                    }
                }
            }
            return max;
        }

        private void Dfs(int[][] grid, int i, int j)
        {
            if (i<0||i>=grid.Length||j<0||j>=grid[0].Length||grid[i][j]==2||grid[i][j]==0)
            {
                return;
            }
            curMax++;
            grid[i][j] = 2;
            Dfs(grid, i + 1, j);
            Dfs(grid, i - 1, j);
            Dfs(grid, i, j + 1);
            Dfs(grid, i, j - 1);
            max = Math.Max(curMax, max);
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
