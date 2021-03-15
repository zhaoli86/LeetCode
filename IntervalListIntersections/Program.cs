using System;
using System.Collections.Generic;

namespace IntervalListIntersections
{
    public class Solution
    {
        public int[][] IntervalIntersection(int[][] firstList, int[][] secondList)
        {
            int m = firstList.Length;
            int n = secondList.Length;
            var result = new List<int[]>();
            int i = 0, j = 0;
            while (i < m && j < n)
            {
                int start = Math.Max(firstList[i][0], secondList[j][0]);
                int end = Math.Min(firstList[i][1], secondList[j][1]);
                if (start <= end)
                {
                    result.Add(new int[] { start, end });
                }
                if (firstList[i][1] < secondList[j][1])
                {
                    i++;
                }
                else
                {
                    j++;
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
