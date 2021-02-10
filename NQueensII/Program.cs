using System;
using System.Collections.Generic;

namespace NQueensII
{
    public class Solution
    {
        private HashSet<int> occupiedCols = new HashSet<int>();
        private HashSet<int> occupiedDiag1 = new HashSet<int>();

        private HashSet<int> occupiedDiag2 = new HashSet<int>();

        public int TotalNQueens(int n)
        {
            return Helper(0, 0, n);
        }

        private int Helper(int row, int count, int n)
        {
            for (int col = 0; col < n; col++)
            {
                if (occupiedCols.Contains(col))
                {
                    continue;
                }

                var diff = row - col;
                if (occupiedDiag1.Contains(diff))
                {
                    continue;
                }
                var sum = row + col;
                if (occupiedDiag2.Contains(sum))
                {
                    continue;
                }
                //can place the last queen required on the board at this point, so increment solution count
                if (row==n-1)
                {
                    count++;
                }
                else
                {
                    occupiedCols.Add(col);
                    occupiedDiag1.Add(diff);
                    occupiedDiag2.Add(sum);
                    count = Helper(row + 1, count, n);
                    occupiedCols.Remove(col);
                    occupiedDiag1.Remove(diff);
                    occupiedDiag2.Remove(sum);
                }
            }
            return count;
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
