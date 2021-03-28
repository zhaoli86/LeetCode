using System;
using System.Collections.Generic;

namespace RectangleAreaII
{
    public class Solution
    {
        public int RectangleArea(int[][] rectangles)
        {
            long result = 0;
            int mod = (int)Math.Pow(10, 9) + 7;
            var coordiates = new List<int[]>();
            foreach (var rec in rectangles)
            {
                GetCoordinates(coordiates, rec, 0);
            }
            foreach (var item in coordiates)
            {
                result = (result + ((long)(item[2] - item[0]) * (long)(item[3] - item[1]))) % mod;
            }
            return (int)result;
        }

        private void GetCoordinates(List<int[]> coordinates, int[] a, int start)
        {
            if (start >= coordinates.Count)
            {
                coordinates.Add(a);
                return;
            }
            var b = coordinates[start];

            //no overlap
            if (a[0] >= b[2] || a[2] <= b[0] || a[1] >= b[3] || a[3] <= b[1])
            {
                GetCoordinates(coordinates, a, start + 1);
                return;
            }

            //new block left is left of existing block left
            if (a[0] < b[0])
            {
                GetCoordinates(coordinates, new int[] { a[0], a[1], b[0], a[3] }, start + 1);
            }

            //new block right is right of existing block right
            if (a[2] > b[2])
            {
                GetCoordinates(coordinates, new int[] { b[2], a[1], a[2], a[3] }, start + 1);
            }

            //new block bottom is below existing block bottom
            if (a[1] < b[1])
            {
                GetCoordinates(coordinates, new int[] { Math.Max(a[0], b[0]), a[1], Math.Min(b[2], a[2]), b[1] }, start + 1);
            }

            //new block top is above existing block top
            if (a[3] > b[3])
            {
                GetCoordinates(coordinates, new int[] { Math.Max(a[0], b[0]), b[3], Math.Min(a[2], b[2]), a[3] }, start + 1);
            }

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
