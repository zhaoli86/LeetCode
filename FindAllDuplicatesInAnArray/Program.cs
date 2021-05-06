using System;
using System.Collections.Generic;

namespace FindAllDuplicatesInAnArray
{
    public class Solution
    {
        public IList<int> FindDuplicates(int[] nums)
        {
            var result = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {

                var val = nums[i];
                if (nums[Math.Abs(val)-1]<0)
                {
                    result.Add(Math.Abs(val));
                }
                nums[Math.Abs(val) - 1] *= -1;
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
