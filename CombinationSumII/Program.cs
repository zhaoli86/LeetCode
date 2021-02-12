using System;
using System.Collections.Generic;

namespace CombinationSumII
{
    public class Solution
    {
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            var result = new List<IList<int>>();
            Array.Sort(candidates);
            Backtrack(result, new List<int>(), candidates, target, 0);
            return result;

        }

        private void Backtrack(List<IList<int>> list, List<int> tempList, int[] nums, int remain, int start)
        {
            if (remain < 0)
            {
                return;
            }
            else if (remain == 0)
            {
                list.Add(new List<int>(tempList));
            }
            else
            {
                for (int i = start; i < nums.Length; i++)
                {
                    if (i > start && nums[i] == nums[i - 1])
                    {
                        continue;
                    }
                    tempList.Add(nums[i]);
                    Backtrack(list, tempList, nums, remain - nums[i], i + 1);
                    tempList.RemoveAt(tempList.Count - 1);
                }
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
