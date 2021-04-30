using System;

namespace ElementAppearingMoreThan25PercentInSortedArray
{
    public class Solution
    {
        public int FindSpecialInteger(int[] arr)
        {
            int n = arr.Length, t = n / 4;
            for (int i = 0; i < n-t; i++)
            {
                if (arr[i]==arr[i+t])
                {
                    return arr[i];
                }
            }
            return -1;
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
