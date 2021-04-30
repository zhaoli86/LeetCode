using System;
using System.Collections.Generic;

namespace TopKFrequentElements
{
    public class Solution
    {
        public int[] TopKFrequent(int[] nums, int k)
        {
            var frequencies = new Dictionary<int, int>();
            var buckets = new List<int>[nums.Length + 1];
            foreach (var num in nums)
            {
                if (frequencies.ContainsKey(num))
                {
                    frequencies[num]++;
                }
                else
                {
                    frequencies[num] = 1;
                }
            }

            foreach (var key in frequencies.Keys)
            {

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
