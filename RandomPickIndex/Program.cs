using System;
using System.Collections.Generic;

namespace RandomPickIndex
{
    public class Solution
    {
        private Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
        private Random rand = new Random();
        public Solution(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (map.ContainsKey(nums[i]))
                {
                    map[nums[i]].Add(i);
                }
                else
                {
                    map[nums[i]] = new List<int> { i };
                }
            }
        }

        public int Pick(int target)
        {
            var list = map[target];
            return list[rand.Next(0, list.Count)];
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
