using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxWidthRamp
{
    public class Solution
    {
        public int MaxWidthRamp(int[] A)
        {
            int res = 0;
            var s = new List<int>();
            for (int i = 0; i < A.Length; i++)
            {
                if (s.Count==0 || A[i] < A[s.Last()])
                {
                    s.Add(i);
                }

                else
                {
                    int left = 0, right = s.Count() - 1;
                    while (left<right)
                    {
                        int mid = (left + right) / 2;

                        if (A[s[mid]] > A[i])
                        {
                            left = mid + 1;
                        }
                        else
                        {
                            right = mid;
                        }
                    }
                    res = Math.Max(res, i - s[left]);
                }
            }

            return res;
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
