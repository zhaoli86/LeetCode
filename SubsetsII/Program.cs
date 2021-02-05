using System;
using System.Collections.Generic;

namespace SubsetsII
{
    public class Solution
    {
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            var result = new List<IList<int>>();
            Array.Sort(nums);
            Dfs(nums, result, new List<int>(), 0);
            return result;
        }

        private void Dfs(int[] nums, List<IList<int>> result, List<int> tempList, int start)
        {
            result.Add(new List<int>(tempList));
            for (int i = start; i < nums.Length; i++)
            {
                if (i > start && nums[i] == nums[i - 1])
                {
                    continue;
                }
                tempList.Add(nums[i]);
                Dfs(nums, result, tempList, i + 1);
                tempList.RemoveAt(tempList.Count - 1);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 1, 2, 2 };
            var result = new Solution().SubsetsWithDup(input);
            Console.WriteLine("Hello World!");
        }
    }
}
