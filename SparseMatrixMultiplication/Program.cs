using System;

namespace SparseMatrixMultiplication
{
    public class Solution
    {
        public int[][] Multiply(int[][] mat1, int[][] mat2)
        {
            int r1 = mat1.Length, c1 = mat1[0].Length, c2 = mat2[0].Length;
            var result = new int[r1][];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new int[c2];
            }
            for (int i = 0; i < r1; i++)
            {
                for (int k = 0; k < c1; k++)
                {
                    if (mat1[i][k]!=0)
                    {
                        for (int j = 0; j < c2; j++)
                        {
                            result[i][j] += mat1[i][k] * mat2[k][j];
                        }
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
