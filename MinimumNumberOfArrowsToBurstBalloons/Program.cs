using System;
using System.Linq;

namespace MinimumNumberOfArrowsToBurstBalloons
{
    public class Solution
    {
        public int FindMinArrowShots(int[][] points)
        {
            if (points.Length == 0)
            {
                return 0;
            }
            points = points.OrderBy(p => p[1]).ToArray();
            int result = 1;
            int endPos = points[0][1];
            for (int i = 1; i < points.Length; i++)
            {
                if (endPos >= points[i][0])
                {
                    continue;
                }
                result++;
                endPos = points[i][1];
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
