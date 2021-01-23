using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MinNumberOfFlipsToConvertBinaryMatrixToZeroMatrix
{
    public class Solution
    {
        public int MinFlips(int[][] mat)
        {
            var dirs = new int[] { 0, 0, 1, 0, -1, 0 };
            var q = new Queue<int>();
            int rowCount = mat.Length;
            int columnCount = mat[0].Length;
            int cur = 0;
            var visited = new HashSet<int>();
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    cur |= mat[i][j] << (i * columnCount + j);
                }
            }
            q.Enqueue(cur);
            visited.Add(cur);
            int step = 0;
            while (q.Any())
            {
                for (int i = q.Count; i > 0; i--)
                {
                    var node = q.Dequeue();
                    if (node==0)
                    {
                        return step;
                    }
                    for (int r = 0; r < rowCount; r++)
                    {
                        for (int c = 0; c < columnCount; c++)
                        {
                            int next = node;
                            for (int k = 0; k < 5; k++)
                            {
                                int row = r + dirs[k];
                                int column = c + dirs[k + 1];
                                if (row>=0&&column>=0&&row<rowCount&&column<columnCount)
                                {
                                    next ^= 1 << (row * columnCount + column);
                                }
                            }
                            if (visited.Add(next))
                            {
                                q.Enqueue(next);
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
