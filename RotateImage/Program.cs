using System;

namespace RotateImage
{
    public class Solution
    {
        public void Rotate(int[][] matrix)
        {
            Transpose(matrix);
            Reflect(matrix);
        }

        private void Reflect(int[][] m)
        {
            int n = m.Length;
            for (int i = 0; i < n; i++)
            {
                int j = 0, k = n - 1;
                while (j<k)
                {
                    int temp = m[i][j];
                    m[i][j] = m[i][k];
                    m[i][k] = temp;
                    j++;
                    k--;
                }
            }
        }

        private void Transpose(int[][] m)
        {
            int n = m.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = i+1; j < n; j++)
                {
                    int temp = m[i][j];
                    m[i][j] = m[j][i];
                    m[j][i] = temp;
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
