using System;
using System.Collections.Generic;

namespace MyCalendarIII
{
    public class MyCalendarThree
    {

        private SortedDictionary<int, int> points = new SortedDictionary<int, int>();

        public int Book(int start, int end)
        {
            if (points.ContainsKey(start))
            {
                points[start]++;
            }
            else
            {
                points[start] = 1;
            }
            if (points.ContainsKey(end))
            {
                points[end]--;
            }
            else
            {
                points[end] = -1;
            }

            int max = 0, k = 0;
            foreach (var kvp in points)
            {
                max = Math.Max(max, k += kvp.Value);
            }
            return max;
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
