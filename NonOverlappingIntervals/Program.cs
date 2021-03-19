using System;
using System.Linq;

namespace NonOverlappingIntervals
{
    public class Solution
    {
        public int EraseOverlapIntervals(int[][] intervals)
        {
            if (intervals.Length == 0)
            {
                return 0;
            }
            var count = 1;
            intervals = intervals.OrderBy(i => i[1]).ToArray();
            int end = intervals[0][1];

            for (int i = 1; i < intervals.Length; i++)
            {
                if (intervals[i][0] >= end)
                {
                    count++;
                    end = intervals[i][1];
                }
            }

            return intervals.Length - count;
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
