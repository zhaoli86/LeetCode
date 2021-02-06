using System;
using System.Collections.Generic;

namespace Permutations
{
    public class Solution
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            var result = new List<IList<int>>();
            Backtrack(result, new List<int>(), nums);
            return result;
        }

        private void Backtrack(List<IList<int>> result, List<int> tempList, int[] nums)
        {
            if (tempList.Count==nums.Length)
            {
                result.Add(new List<int>(tempList));
            }
            else
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    if (tempList.Contains(nums[i]))
                    {
                        continue;
                    }
                    else
                    {
                        tempList.Add(nums[i]);
                        Backtrack(result, tempList, nums);
                        tempList.RemoveAt(tempList.Count - 1);
                    }
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
