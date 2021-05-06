using System;
using System.Collections.Generic;
using System.Linq;

namespace TopKFrequentElements
{
    public class Solution
    {
        public int[] TopKFrequent(int[] nums, int k)
        {
            var map = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (map.ContainsKey(num))
                {
                    map[num]++;
                }
                else
                {
                    map[num] = 1;
                }
            }
            return map.OrderByDescending(kvp => kvp.Value).Take(k).Select(k => k.Key).ToArray();

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
