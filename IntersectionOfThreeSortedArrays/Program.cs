using System;
using System.Collections.Generic;

namespace IntersectionOfThreeSortedArrays
{
    public class Solution
    {
        public IList<int> ArraysIntersection(int[] arr1, int[] arr2, int[] arr3)
        {
            int i = 0, j = 0, k = 0;
            var result = new List<int>();
            while (i<arr1.Length&&j<arr2.Length&&k<arr3.Length)
            {
                int n1 = arr1[i], n2 = arr2[j], n3 = arr3[k];
                if (n1==n2&&n1==n3)
                {
                    result.Add(n1);
                    i++;
                    j++;
                    k++;
                }
                else
                {
                    int min = Min(n1, n2, n3);
                    if (min==n1)
                    {
                        i++;
                    }
                    else if (min==n2)
                    {
                        j++;
                    }
                    else if (min==n3)
                    {
                        k++;
                    }
                }
            }
            return result;

        }
        private int Min(int a, int b, int c)
        {
            return Math.Min(Math.Min(a, b), c);
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
