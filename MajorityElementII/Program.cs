using System;
using System.Collections.Generic;

namespace MajorityElementII
{
    class Program
    {

        public class Solution
        {
            public IList<int> MajorityElement(int[] nums)
            {
                var result = new List<int>();
                if (nums==null || nums.Length==0)
                {
                    return result;
                }
                int num1 = nums[0], count1 = 1, num2 = nums[0], count2 = 0;
                foreach (var num in nums)
                {
                    if (num==num1)
                    {
                        count1++;
                    }
                    else if (num==num2)
                    {
                        count2++;
                    }
                    else if(count1==0)
                    {
                        num1 = num;
                        count1=1;
                    }
                    else if (count2==0)
                    {
                        num2 = num;
                        count2=1;
                    }
                    else
                    {
                        count1--;
                        count2--;
                    }
                }
                count1 = count2 = 0;
                foreach (var num in nums)
                {
                    if (num==num1)
                    {
                        count1++;
                    }
                    else if (num==num2)
                    {
                        count2++;
                    }
                }
                if (count1>nums.Length/3)
                {
                    result.Add(num1);
                }
                if (count2>nums.Length/3)
                {
                    result.Add(num2);
                }
                return result;
            }
        }
        static void Main(string[] args)
        {
            var s = new Solution();
            var a = new int[] { 2, 2, 9, 3, 9, 3, 9, 3, 9, 3, 9, 3, 9, 3, 9, 3, 9 };
            var r = s.MajorityElement(a);
            Console.WriteLine("Hello World!");
        }
    }
}
