using System;
using System.Collections.Generic;
using System.Linq;

namespace ThreeSum
{
    public class Solution
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var result = new List<IList<int>>();
            Array.Sort(nums);
            for (int i = 0; i < nums.Length-2; i++)
            {
                if (i==0||nums[i]!=nums[i-1])
                {
                    int low = i + 1, high = nums.Length - 1;
                    while (low < high)
                    {
                        int complement = 0 - nums[i];
                        int curSum = nums[low] + nums[high];
                        if (curSum == complement)
                        {
                            result.Add(new List<int> { nums[i], nums[low], nums[high] });
                            while (low<high&&nums[low+1]==nums[low])
                            {
                                low++;
                            }
                            while (low<high&&nums[high-1]==nums[high])
                            {
                                high--;
                            }
                            low++;
                            high--;
                        }
                        else if (curSum > complement)
                        {
                            high--;
                        }
                        else
                        {
                            low++;
                        }
                    }
                }

            }
            return result.ToList();
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
