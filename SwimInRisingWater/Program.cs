using System;
using System.Collections.Generic;
using System.Linq;

namespace SwimInRisingWater
{
    public class Solution
    {
        public int SwimInWater(int[][] grid)
        {
            int lo = grid[0][0];
            int n = grid.Length;
            int hi = n * n;

            while (lo<hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (IsPossible(mid, grid))
                {
                    hi = mid;
                }
                else
                {
                    lo = mid + 1;
                }
            }
            return lo;
        }

        private bool IsPossible(int t, int[][] grid)
        {
            var rowShift = new int[] { -1, 1, 0, 0 };
            var columnShift = new int[] { 0, 0, -1, 1 };
            var n = grid.Length;

            var stack = new Stack<int>();
            var seen = new HashSet<int>();
            seen.Add(0);
            stack.Push(0);

            while (stack.Any())
            {
                var node = stack.Pop();
                int column = node % n;
                int row = node / n;
                if (row==n-1&&column==n-1)
                {
                    return true;
                }

                for (int i = 0; i < rowShift.Length; i++)
                {
                    int nr = row + rowShift[i];
                    int nc = column + columnShift[i];
                    int val = nc + nr * n;
                    if (nr>=0&& nr<n && nc>=0 && nc<n && !seen.Contains(val) && grid[nr][nc] <= t)
                    {
                        seen.Add(val);
                        stack.Push(val);

                    }
                }
            }
            return false;
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
