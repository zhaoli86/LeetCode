using System;
using System.Collections.Generic;

namespace Combinations
{
    public class Solution
    {
        public IList<IList<int>> Combine(int n, int k)
        {
            var result = new List<IList<int>>();
            Backtrack(result, new List<int>(), 1, n, k);
            return result;
        }

        private void Backtrack(List<IList<int>> result, List<int> tempList, int start, int n, int remain)
        {
            if (remain==0)
            {
                result.Add(new List<int>(tempList));
            }
            else
            {
                for (int i = start; i <= n; i++)
                {
                    tempList.Add(i);
                    Backtrack(result, tempList, i + 1, n, remain - 1);
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
