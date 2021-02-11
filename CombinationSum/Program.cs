using System;
using System.Collections.Generic;

namespace CombinationSum
{
    public class Solution
    {
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var result = new List<IList<int>>();
            Backtrack(result, candidates, target, new List<int>(), 0);
            return result;
        }

        private void Backtrack(List<IList<int>> result, int[] candidates, int target, List<int> tempList, int start)
        {
            if (target<0)
            {
                return;
            }
            else if (target==0)
            {
                result.Add(new List<int>(tempList));
            }
            else
            {
                for (int i = start; i < candidates.Length; i++)
                {
                    tempList.Add(candidates[i]);
                    Backtrack(result, candidates, target - candidates[i], tempList, i);
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
