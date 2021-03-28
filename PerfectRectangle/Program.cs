using System;
using System.Collections.Generic;

namespace PerfectRectangle
{
    public class Solution
    {
        //perfect rectangle: check area is the same as sum of sub-rectangles
        //all points except for 4 corners should occur even number of times
        public bool IsRectangleCover(int[][] rectangles)
        {
            int x1 = int.MaxValue;
            int x2 = int.MinValue;
            int y2 = int.MinValue;
            int y1 = int.MaxValue;
            int area = 0;
            var set = new HashSet<string>();

            foreach (var rectangle in rectangles)
            {
                x1 = Math.Min(x1, rectangle[0]);
                y1 = Math.Min(y1, rectangle[1]);
                x2 = Math.Max(x2, rectangle[2]);
                y2 = Math.Max(y2, rectangle[3]);
                area += (rectangle[2] - rectangle[0]) * (rectangle[3] - rectangle[1]);

                string p1 = rectangle[0] + " " + rectangle[1];
                string p2 = rectangle[0] + " " + rectangle[3];
                string p3 = rectangle[2] + " " + rectangle[1];
                string p4 = rectangle[2] + " " + rectangle[3];

                if (!set.Add(p1))
                {
                    set.Remove(p1);
                }
                if (!set.Add(p2))
                {
                    set.Remove(p2);
                }
                if (!set.Add(p3))
                {
                    set.Remove(p3);
                }
                if (!set.Add(p4))
                {
                    set.Remove(p4);
                }
            }
            if (!set.Contains(x1 + " " + y1) || !set.Contains(x1 + " " + y2) || !set.Contains(x2 + " " + y1) || !set.Contains(x2 + " " + y2) || set.Count != 4)
            {
                return false;
            }
            return area == (y2 - y1) * (x2 - x1);
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
