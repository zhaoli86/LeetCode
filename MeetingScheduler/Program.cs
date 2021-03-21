using System;
using System.Collections.Generic;
using System.Linq;

namespace MeetingScheduler
{
    public class Solution
    {
        public IList<int> MinAvailableDuration(int[][] slots1, int[][] slots2, int duration)
        {
            var result = new List<int>();
            slots1 = slots1.OrderBy(s => s[0]).ToArray();
            slots2 = slots2.OrderBy(s => s[0]).ToArray();
            int m = slots1.Length, n = slots2.Length, i = 0, j = 0;
            while (i < m && j < n)
            {
                int start = Math.Max(slots1[i][0], slots2[j][0]);
                int end = Math.Min(slots1[i][1], slots2[j][1]);
                if (start + duration <= end)
                {
                    return new List<int> { start, start + duration };
                }
                else if (slots1[i][1] > slots2[j][1])
                {
                    j++;
                }
                else
                {
                    i++;
                }
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
