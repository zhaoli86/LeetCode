using System;
using System.Collections.Generic;

namespace SpiralMatrix
{
    public class Solution
    {
        public IList<int> SpiralOrder(int[][] matrix)
        {
            var result = new List<int>();
            if (matrix==null || matrix.Length==0)
            {
                return result;
            }
            int m = matrix.Length, n = matrix[0].Length;
            int up = 0, down = m - 1, left = 0, right = n - 1;
            while (result.Count<m*n)
            {
                for (int i = left; i <= right && result.Count<m*n; i++)
                {
                    result.Add(matrix[up][i]);
                }
                for (int i = up+1; i <=down && result.Count<m*n; i++)
                {
                    result.Add(matrix[i][right]);
                }
                for (int i = right-1; i >=left && result.Count<m*n; i--)
                {
                    result.Add(matrix[down][i]);
                }
                for (int i = down-1; i >= up+1 && result.Count<m*n; i--)
                {
                    result.Add(matrix[i][left]);
                }

                up++;
                right--;
                down--;
                left++;
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
