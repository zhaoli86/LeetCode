using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace MazeIII
{
    public class Solution
    {
        private class Point : IComparable<Point>
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Length { get; set; }
            public string Path { get; set; }
            public Point(int x, int y)
            {
                X = x;
                Y = y;
                Length = int.MaxValue;
                Path = "";
            }

            public Point(int x, int y, int length, string path)
            {
                X = x;
                Y= y;
                Length = length;
                Path = path;
            }
            public int CompareTo([AllowNull] Point other)
            {
                return Length == other.Length ? Path.CompareTo(other.Path) : Length - other.Length;
            }
        }

        public string FindShortestWay(int[][] maze, int[] ball, int[] hole)
        {
            var q = new Queue<Point>();
            int m = maze.Length;
            int n = maze[0].Length;
            var points = new Point[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    points[i, j] = new Point(i, j);
                }
            }
            var dirs = new int[4][] { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 } };
            var ds = new string[] { "u", "d", "l", "r" };

            q.Enqueue(new Point(ball[0], ball[1], 0, ""));
            while (q.Any())
            {
                var node = q.Dequeue();
                if (points[node.X, node.Y].CompareTo(node)<=0)
                {
                    continue;
                }
                points[node.X, node.Y] = node;
                for (int i = 0; i < 4; i++)
                {
                    int r = node.X;
                    int c = node.Y;
                    int len = node.Length;
                    while (r>=0&&r<m&&c>=0&&c<n&&maze[r][c]==0&&!(r==hole[0] && c==hole[1]))
                    {
                        r += dirs[i][0];
                        c += dirs[i][1];
                        len++;
                    }
                    if (!(r==hole[0]&&c==hole[1]))
                    {
                        r -= dirs[i][0];
                        c -= dirs[i][1];
                        len--;
                    }
                    q.Enqueue(new Point(r, c, len, node.Path + ds[i]));
                }


            }

            return points[hole[0], hole[1]].Length == int.MaxValue ? "impossible" : points[hole[0], hole[1]].Path;
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
