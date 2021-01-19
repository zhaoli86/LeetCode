using System;
using System.Collections.Generic;
using System.Linq;

namespace TheMazeII
{
    public class Solution
    {
        public int ShortestDistance(int[][] maze, int[] start, int[] destination)
        {
            var q = new Queue<int[]>();
            var distance = new int[maze.Length, maze[0].Length];
            for (int i = 0; i < distance.GetLength(0); i++)
            {
                for (int j = 0; j < distance.GetLength(1); j++)
                {
                    distance[i, j] = int.MaxValue;
                }
            }
            distance[start[0], start[1]] = 0;
            var dirs = new int[4][] { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 } };

            q.Enqueue(start);
            while (q.Any())
            {
                var node = q.Dequeue();
                foreach (var dir in dirs)
                {
                    int row = node[0] + dir[0];
                    int column = node[1] + dir[1];
                    int count = 0;
                    while (row >= 0 && column >= 0 && row < maze.Length && column < maze[0].Length && maze[row][column] == 0)
                    {
                        row += dir[0];
                        column += dir[1];
                        count++;
                    }
                    if (distance[node[0], node[1]] + count < distance[row - dir[0], column - dir[1]])
                    {
                        distance[row - dir[0], column - dir[1]] = distance[node[0], node[1]] + count;
                        q.Enqueue(new int[] { row - dir[0], column - dir[1] });
                    }
                }
            }
            return distance[destination[0], destination[1]] == int.MaxValue ? -1 : distance[destination[0], destination[1]];
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[5][] { new int[] { 0, 0, 1, 0, 0 }, new int[] { 0, 0, 0, 0, 0 },
                new int[] { 0,0,0,1,0}, new int[] {1,1,0,1,1 }, new int[] { 0, 0, 0, 0, 0 } };
            var result = new Solution().ShortestDistance(input, new int[] {0, 4 }, new int[] {4,4 });
            Console.WriteLine("Hello World!");
        }
    }
}
