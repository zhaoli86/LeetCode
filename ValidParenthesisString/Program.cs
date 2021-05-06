using System;

namespace ValidParenthesisString
{
    public class Solution
    {
        public bool CheckValidString(string s)
        {
            int lo=0, hi = 0;
            foreach (var c in s)
            {
                if (c=='(')
                {
                    lo++;
                }
                else
                {
                    lo--;
                }

                if (c!=')')
                {
                    hi++;
                }
                else
                {
                    hi--;
                }

                if (hi<0)
                {
                    return false;
                }
                lo = Math.Max(lo, 0);
            }
            return lo == 0;
        }
    }

    class Program
    {
        static int N = 4;

        static void transpose(int[,] A, int[,] B)
        {
            int i, j;
            for (i = 0; i < N; i++)
                for (j = 0; j < N; j++)
                    B[i, j] = A[j, i];
        }

        static void Transpose2(int[,] a)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = i+1; j < 4; j++)
                {
                    int temp = a[i, j];
                    a[i, j] = a[j, i];
                    a[j, i] = temp;
                }

            }
        }
        static void Main(string[] args)
        {
            int[,] A = { {1, 1, 1, 1},
                     {2, 2, 2, 2},
                     {3, 3, 3, 3},
                     {4, 4, 4, 4}};

            int[,] B = new int[N, N];

            // Function calling
            Transpose2(A);

            Console.Write("Result matrix is \n");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.Write(A[i, j] + " ");
                Console.Write("\n");
            }

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
