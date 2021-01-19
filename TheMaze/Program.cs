using System;

namespace TheMaze
{
    public class Solution
    {
        public bool HasPath(int[][] maze, int[] start, int[] destination)
        {
            var visited = new bool[maze.Length, maze[0].Length];

            return Dfs(maze, start, destination, visited);
        }

        private bool Dfs(int[][] maze, int[] start, int[] destination, bool[,] visited)
        {
            if (visited[start[0], start[1]])
            {
                return false;
            }
            if (start[0]==destination[0]&&start[1]==destination[1])
            {
                return true;
            }

            visited[start[0], start[1]] = true;
            int left = start[1] - 1, right = start[1] + 1, up = start[0] - 1, down = start[0] + 1;
            while (left>=0&&maze[start[0]][left]==0)
            {
                left--;
            }
            if (Dfs(maze, new int[] {start[0], left+1}, destination, visited))
            {
                return true;
            }
            while (right<maze[0].Length&&maze[start[0]][right]==0)
            {
                right++;
            }
            if (Dfs(maze, new int[] {start[0], right -1}, destination, visited))
            {
                return true;
            }
            while (up>=0&&maze[up][start[1]]==0)
            {
                up--;
            }
            if (Dfs(maze, new int[] { up+1, start[1]}, destination, visited))
            {
                return true;
            }
            while (down<maze.Length&& maze[down][start[1]]==0)
            {
                down++;
            }
            if (Dfs(maze, new int[] { down-1, start[1] }, destination, visited))
            {
                return true;
            }
            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[5][] { new int[] { 0, 0, 1, 0, 0 }, new int[] { 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 1, 0 }, new int[] { 1, 1, 0, 1, 1 } ,
            new int[]{ 0, 0, 0, 0, 0 } };
            var result = new Solution().HasPath(input, new[] { 0, 4 }, new int[] { 4, 4 });
            Console.WriteLine("Hello World!");
        }
    }
}
