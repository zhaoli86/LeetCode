using System;
using System.Collections.Generic;

namespace CombinationSumIII
{
    public class Solution
    {
        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            var result = new List<IList<int>>();
            Backtrack(result, new List<int>(), k, n, 1);
            return result;
        }

        private void Backtrack(List<IList<int>> result, List<int> tempList, int k, int remain, int start)
        {
            if (tempList.Count > k || remain < 0)
            {
                return;
            }
            else if (tempList.Count == k && remain == 0)
            {
                result.Add(new List<int>(tempList));
            }
            else
            {
                for (int i = start; i <= 9; i++)
                {
                    tempList.Add(i);
                    Backtrack(result, tempList, k, remain - i, i + 1);
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
