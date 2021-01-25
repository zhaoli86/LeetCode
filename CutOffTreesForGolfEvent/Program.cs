using System;
using System.Collections.Generic;
using System.Linq;

namespace CutOffTreesForGolfEvent
{
    public class Solution
    {
        public int CutOffTree(IList<IList<int>> forest)
        {
            var q = new Queue<int[]>();
            int m = forest.Count;
            int n = forest[0].Count;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (forest[i][j] > 1)
                    {
                        q.Enqueue(new int[] { i, j, forest[i][j] });
                    }
                }
            }

            q = new Queue<int[]>(q.OrderBy(i => i[2]));
            int result = 0;
            var start = new int[2];

            while (q.Any())
            {
                var next = q.Dequeue();
                int distance = GetDistance(start, next, forest, m, n);
                if (distance == -1)
                {
                    return -1;
                }
                result += distance;
                start = next;
            }
            return result;
        }
        private int GetDistance(int[] start, int[] next, IList<IList<int>> forest, int m, int n)
        {
            var q = new Queue<int[]>();
            var visited = new bool[m, n];
            int step = 0;
            q.Enqueue(start);
            visited[start[0], start[1]] = true;
            var dirs = new int[4][] { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 } };
            while (q.Any())
            {
                int size = q.Count;
                for (int i = 0; i < size; i++)
                {
                    var node = q.Dequeue();
                    if (node[0] == next[0] && node[1] == next[1])
                    {
                        return step;
                    }
                    foreach (var dir in dirs)
                    {
                        int row = node[0] + dir[0];
                        int column = node[1] + dir[1];
                        if (row < 0 || row >= m || column < 0 || column >= n || forest[row][column] == 0 || visited[row, column])
                        {
                            continue;
                        }
                        visited[row, column] = true;
                        q.Enqueue(new int[] { row, column });
                    }
                }
                step++;
            }
            return -1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var input = new List<IList<int>> { new List<int>{ 1, 2, 3 }, new List<int> { 0, 0, 4 },
            new List<int>{7, 6, 5} };
            var result = new Solution().CutOffTree(input);
            Console.WriteLine("Hello World!");
        }
    }
}
