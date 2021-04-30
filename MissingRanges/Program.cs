using System;
using System.Collections.Generic;

namespace MissingRanges
{
    public class Solution
    {
        public IList<string> FindMissingRanges(int[] nums, int lower, int upper)
        {
            int cur = lower;
            var result = new List<string>();
            foreach (var num in nums)
            {
                if (num > cur)
                {
                    if (cur==num-1)
                    {
                        result.Add(cur.ToString());
                    }
                    else
                    {
                        result.Add($"{cur}->{num - 1}");
                    }
                }

                cur = num + 1;
            }
            if (cur<upper)
            {
                result.Add($"{cur}->{upper}");
            }
            else if (cur==upper)
            {
                result.Add(cur.ToString());
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
