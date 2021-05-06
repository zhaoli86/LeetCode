using System;

namespace NumberOfIslands
{
    public class Solution
    {
        private int[][] dirs = new int[4][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };

        public int NumIslands(char[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            int count = 0;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j <n; j++)
                {
                    if (grid[i][j]=='1')
                    {
                        Visit(grid, i, j, m, n);
                        count++;

                    }
                }
            }
            return count;
        }

        private void Visit(char[][] grid, int i, int j, int m, int n)
        {
            if (i<0||j<0||i>=m||j>=n||grid[i][j]=='2'||grid[i][j]=='0')
            {
                return;
            }
            grid[i][j] = '2';
            foreach (var dir in dirs)
            {
                int ii = i + dir[0];
                int jj = j + dir[1];
                Visit(grid, ii, jj, m, n);
            }
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
