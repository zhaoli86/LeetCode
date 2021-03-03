using System;
using System.Collections.Generic;

namespace MaximumXOROfTwoNumberInArray
{
    public class Solution
    {
        public int FindMaximumXOR(int[] nums)
        {
            int maxResult = 0, mask = 0;
            for (int i = 31; i >=0; i--)
            {
                var leftPartOfNums = new HashSet<int>();
                mask = mask | (1 << i);
                foreach (var num in nums)
                {
                    leftPartOfNums.Add(num & mask);
                }

                int greedyResult = maxResult | (1 << i);
                foreach (var leftPartNum in leftPartOfNums)
                {
                    int theOtherNum = leftPartNum ^ greedyResult;
                    if (leftPartOfNums.Contains(theOtherNum))
                    {
                        maxResult = greedyResult;
                        break;
                    }
                }           
            }
            return maxResult;
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
