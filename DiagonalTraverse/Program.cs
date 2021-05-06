using System;

namespace DiagonalTraverse
{
    public class Solution
    {
        public int[] FindDiagonalOrder(int[][] mat)
        {
            int m = mat.Length, n = mat[0].Length;
            int len = m * n, row = 0, col = 0;
            var result = new int[len];
            for (int i = 0; i < len; i++)
            {
                result[i] = mat[row][col];

                if ((row+col)%2==0)
                {
                    if (col==n-1)
                    {
                        row++;
                    }
                    else if (row==0)
                    {
                        col++;
                    }
                    else
                    {
                        row--;
                        col++;
                    }

                }
                else
                {
                    if (row==m-1)
                    {
                        col++;
                    }
                    else if (col==0)
                    {
                        row++;
                    }
                    else
                    {
                        row++;
                        col--;
                    }
                }
            }
            return result;
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
