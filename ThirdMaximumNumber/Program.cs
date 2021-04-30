using System;

namespace ThirdMaximumNumber
{
    public class Solution
    {
        public int ThirdMax(int[] nums)
        {
            int? first = null, second = null, third = null;
            foreach (var num in nums)
            {
                if (num==first||num==second||num==third)
                {
                    continue;
                }
                if (first!=null&&num>first)
                {
                    third = second;
                    second = first;
                    first = num;
                }
                else if (second!=null&&num>second)
                {
                    third = second;
                    second = num;
                }
                else if (third!=null&&num>third)
                {
                    third = num;
                }
                else if (first==null)
                {
                    first = num;
                }
                else if (second==null)
                {
                    second = num;
                }
                else if (third==null)
                {
                    third = num;
                }

            }
            return third == null ? first.Value : third.Value;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 1, 2 };
            var result = new Solution().ThirdMax(input);
            Console.WriteLine("Hello World!");
        }
    }
}
