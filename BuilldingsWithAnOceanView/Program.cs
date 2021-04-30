using System;
using System.Collections.Generic;

namespace BuilldingsWithAnOceanView
{
    public class Solution
    {
        public int[] FindBuildings(int[] heights)
        {
            var result = new List<int>();
            int max = 0;
            for (int i = heights.Length-1; i >=0; i--)
            {
                if (heights[i]>max)
                {
                    result.Add(i);
                    max = heights[i];
                }
            }
            result.Reverse();
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
