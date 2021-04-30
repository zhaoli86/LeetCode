using System;
using System.Collections.Generic;
using System.Linq;

namespace AddToArrayFormInteger
{
    public class Solution
    {
        public IList<int> AddToArrayForm(int[] num, int k)
        {
            Array.Reverse(num);
            var list = num.ToList();
            int carry = k;
            for (int i = 0; i < list.Count; i++)
            {
                int sum = list[i] + carry;
                list[i] = sum % 10;
                carry = sum / 10;
            }
            if (carry > 0)
            {
                var carryStr = carry.ToString();
                for (int i = carryStr.Length-1; i >=0; i--)
                {
                    list.Add(carryStr[i] - '0');
                }
            }
             list.Reverse();
            return list;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 1, 2, 0, 0 };
            var r = new Solution().AddToArrayForm(input, 34);
            Console.WriteLine("Hello World!");
        }
    }
}
