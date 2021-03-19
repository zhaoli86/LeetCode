using System;
using System.Linq;

namespace RemoveCoveredIntervals
{
    public class Solution
    {
        public int RemoveCoveredIntervals(int[][] intervals)
        {
            int left = -1, right = -1, result = 0;
            intervals = intervals.OrderBy(i => i[0]).ToArray();
            foreach (var interval in intervals)
            {
                if (interval[0] > left && interval[1] > right)
                {
                    result++;
                    left = interval[0];
                }
                right = Math.Max(right, interval[1]);
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
