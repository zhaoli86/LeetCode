using System;
using System.Collections.Generic;

namespace PermutationsII
{
    public class Solution
    {
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            var result = new List<IList<int>>();
            Array.Sort(nums);
            Backtrack(result, new List<int>(), new bool[nums.Length], nums);
            return result;
        }

        private void Backtrack(List<IList<int>> result, List<int> tempList, bool[] used, int[] nums)
        {
            if (tempList.Count == nums.Length)
            {
                result.Add(new List<int>(tempList));
            }
            else
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    if (used[i] || i > 0 && nums[i] == nums[i - 1]&&!used[i - 1] )
                    {
                        continue;
                    }
                    used[i] = true;
                    tempList.Add(nums[i]);
                    Backtrack(result, tempList, used, nums);
                    used[i] = false;
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
