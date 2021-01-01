using System;
using System.Collections.Generic;
using System.Linq;

namespace JumpGameVI
{
    public class Solution
    {
        public int MaxResult(int[] nums, int k)
        {
            var list = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int max = list.Any() ? nums[list.First()] : 0;
                nums[i] = max + nums[i];
                while (list.Any() && nums[i] > nums[list.Last()])
                {
                    list.RemoveAt(list.Count - 1);
                }
                list.Add(i);
                while (list.Any() && i-list.First()+1>k)
                {
                    list.RemoveAt(0);
                }
                
            }
            return nums[nums.Length-1];
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
