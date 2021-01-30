using System;
using System.Collections.Generic;
using System.Linq;

namespace PacificAtlanticWaterFlow
{
    public class Solution
    {
        private int[][] dirs = new int[4][] { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 } };
        public IList<IList<int>> PacificAtlantic(int[][] matrix)
        {
            var result = new List<IList<int>>();
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
            {
                return result;
            }

            int m = matrix.Length;
            int n = matrix[0].Length;

            var aQ = new Queue<int[]>();
            var pQ = new Queue<int[]>();

            var aVisited = new bool[m, n];
            var pVisited = new bool[m, n];

            for (int i = 0; i < m; i++)
            {
                pQ.Enqueue(new int[] { i, 0 });
                aQ.Enqueue(new int[] { i, n - 1 });
                pVisited[i, 0] = true;
                aVisited[i, n - 1] = true;
            }

            for (int i = 0; i < n; i++)
            {
                pQ.Enqueue(new int[] { 0, i });
                aQ.Enqueue(new int[] { m - 1, i });
                pVisited[0, i] = true;
                aVisited[m - 1, i] = true;
            }

            Bfs(pQ, pVisited, matrix);
            Bfs(aQ, aVisited, matrix);

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (pVisited[i, j] && aVisited[i, j])
                    {
                        result.Add(new List<int> { i, j });
                    }
                }
            }
            return result;

        }

        private void Bfs(Queue<int[]> q, bool[,] visited, int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;
            while (q.Any())
            {
                var node = q.Dequeue();
                foreach (var dir in dirs)
                {
                    int x = node[0] + dir[0];
                    int y = node[1] + dir[1];
                    if (x < 0 || x >= m || y < 0 || y >= n || visited[x, y] || matrix[x][y] < matrix[node[0]][node[1]])
                    {
                        continue;
                    }
                    visited[x, y] = true;
                    q.Enqueue(new int[] { x, y });

                }
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
