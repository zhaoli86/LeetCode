using System;
using System.Collections.Generic;

namespace SetMatrixZeroes
{
    public class Solution
    {
        public void SetZeroes(int[][] matrix)
        {
            if (matrix==null || matrix.Length==0)
            {
                return;
            }
            var xs = new HashSet<int>();
            var ys = new HashSet<int>();
            int m = matrix.Length, n = matrix[0].Length;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i][j]==0)
                    {
                        xs.Add(i);
                        ys.Add(j);
                    }
                }
            }
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (xs.Contains(i) || ys.Contains(j))
                    {
                        matrix[i][j] = 0;
                    }
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
