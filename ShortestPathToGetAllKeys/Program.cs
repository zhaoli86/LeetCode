using System;
using System.Collections.Generic;
using System.Linq;

namespace ShortestPathToGetAllKeys
{
    public class Solution
    {
        private class State
        {
            public int Row { get; set; }
            public int Column { get; set; }
            public int Keys { get; set; }
            public State(int r, int c, int keys)
            {
                Row = r;
                Column = c;
                Keys = keys;
            }
        }

        public int ShortestPathAllKeys(string[] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            int startX = -1, startY = -1, keyCount = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    char c = grid[i][j];
                    if (c == '@')
                    {
                        startX = i;
                        startY = j;
                    }

                    if (c >= 'a' && c <= 'f')
                    {
                        keyCount = Math.Max(keyCount, c - 'a' + 1);
                    }
                }
            }

            var dirs = new int[4][] { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 } };
            var q = new Queue<State>();
            var visited = new HashSet<string>();
            q.Enqueue(new State(startX, startY, 0));
            visited.Add(0 + " " + startX + " " + startY);
            int step = 0;

            while (q.Any())
            {
                int size = q.Count;
                while (size-- > 0)
                {
                    var node = q.Dequeue();
                    if (node.Keys == (1 << keyCount) - 1)
                    {
                        return step;
                    }
                    foreach (var dir in dirs)
                    {
                        int r = node.Row + dir[0];
                        int c = node.Column + dir[1];
                        int k = node.Keys;
                        if (r >= 0 && c >= 0 && r < m && c < n)
                        {
                            var ch = grid[r][c];
                            if (ch == '#')
                            {
                                continue;
                            }
                            if (ch >= 'a' && ch <= 'f')
                            {
                                k |= 1 << (ch - 'a');
                            }
                            if (ch >= 'A' && ch <= 'F' && ((k >> (ch - 'A')) & 1) == 0)
                            {
                                continue;
                            }
                            if (!visited.Contains(k + " " + r + " " + c))
                            {
                                visited.Add(k + " " + r + " " + c);
                                q.Enqueue(new State(r, c, k));
                            }
                        }
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
            Console.WriteLine("Hello World!");
        }
    }
}
