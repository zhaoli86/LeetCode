using System;

namespace IslandPerimeter
{
    public class Solution
    {
        public int IslandPerimeter(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            int blocks = 0, neighbors = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j]==1)
                    {
                        blocks++;
                        if (i < m - 1 && grid[i + 1][j] == 1)
                        {
                            neighbors++;
                        }
                        if (j < n - 1 && grid[i][j + 1] == 1)
                        {
                            neighbors++;
                        }
                    }

                }
            }
            return blocks * 4 - neighbors * 2;
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
