using System;
using System.Collections.Generic;
using System.Linq;

namespace MergeInterval
{
    public class Solution
    {
        public int[][] Merge(int[][] intervals)
        {
            int len = intervals.Length;
            var result = new List<int[]>();
            intervals = intervals.OrderBy(i => i[0]).ToArray();

            var newInterval = intervals[0];
            result.Add(newInterval);
            foreach (var interval in intervals)
            {
                if (interval[0] <= newInterval[1])
                {
                    newInterval[1] = Math.Max(newInterval[1], interval[1]);
                }
                else
                {
                    newInterval = interval;
                    result.Add(newInterval);
                }
            }

            return result.ToArray();
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
