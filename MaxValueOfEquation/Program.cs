using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxValueOfEquation
{
    public class Solution
    {
        public int FindMaxValueOfEquation(int[][] points, int k)
        {
            int res = int.MinValue;
            var list = new List<Tuple<int, int>>();
            foreach (var point in points)
            {
                while (list.Any() && point[0] - list.First().Item2 > k)
                {
                    list.RemoveAt(0);
                }
                if (list.Any())
                {
                    res = Math.Max(res, list.First().Item1 + point[0] + point[1]);
                }
                while (list.Any() && point[1]-point[0] > list.Last().Item1)
                {
                    list.RemoveAt(list.Count - 1);
                }
                list.Add(Tuple.Create(point[1] - point[0], point[0]));
            }
            return res;
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
