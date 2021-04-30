using System;
using System.Collections.Generic;

namespace NestedListWeightSum
{
    public interface NestedInteger
    {

        // @return true if this NestedInteger holds a single integer, rather than a nested list.
        bool IsInteger();

        // @return the single integer that this NestedInteger holds, if it holds a single integer
        // Return null if this NestedInteger holds a nested list
        int GetInteger();

        // Set this NestedInteger to hold a single integer.
        public void SetInteger(int value);

        // Set this NestedInteger to hold a nested list and adds a nested integer to it.
        public void Add(NestedInteger ni);

        // @return the nested list that this NestedInteger holds, if it holds a nested list
        // Return null if this NestedInteger holds a single integer
        IList<NestedInteger> GetList();
    }

    public class Solution
    {
        public int DepthSum(IList<NestedInteger> nestedList)
        {
            int result = 0;
            foreach (var item in nestedList)
            {
                result += GetSum(item, 1);
            }
            return result;

        }
        private int GetSum(NestedInteger nestedInteger, int level)
        {
            int result = 0;
            if (nestedInteger.IsInteger())
            {
                return nestedInteger.GetInteger()*level;
            }
            else
            {
                foreach (var item in nestedInteger.GetList())
                {
                    result += GetSum(item, level + 1);
                }
            }

            return result;
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
