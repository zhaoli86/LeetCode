using System;

namespace RangeSumQuery2D
{
    public class NumMatrix
    {
        private int[][] sumM;
        public NumMatrix(int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;
            sumM = new int[m+1][];
            for (int i = 0; i <= m; i++)
            {
                sumM[i] = new int[n+1];
            }
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    sumM[i][j] = sumM[i][j - 1] + sumM[i - 1][j] - sumM[i - 1][j - 1] + matrix[i-1][j-1];
                }
            }
        }

        public int SumRegion(int row1, int col1, int row2, int col2)
        {
            return sumM[row2+1][col2+1] + sumM[row1][col1] - sumM[row1][col2+1] - sumM[row2+1][col1];
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
