using System;
using System.Collections.Generic;

namespace InsertInterval
{
    public class Solution
    {
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            var list = new List<int[]>();
            int start = newInterval[0], end = newInterval[1], len = intervals.Length, i = 0;

            while (i < len && intervals[i][1] < start)
            {
                list.Add(intervals[i++]);
            }

            while (i < len && intervals[i][0] <= newInterval[1])
            {
                start = Math.Min(start, intervals[i][0]);
                end = Math.Max(end, intervals[i][1]);
                i++;
            }

            list.Add(new int[] { start, end });

            while (i < len)
            {
                list.Add(intervals[i++]);
            }

            return list.ToArray();
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
