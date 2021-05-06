using System;
using System.Collections.Generic;

namespace ContainsDuplicate
{
    public class Solution
    {
        public bool ContainsDuplicate(int[] nums)
        {
            var map = new HashSet<int>();
            foreach (var num in nums)
            {
                if (!map.Add(num))
                {
                    return true;
                }
            }
            return false;
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
