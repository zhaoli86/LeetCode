using System;

namespace KthMissingPositiveNumber
{
    public class Solution
    {
        public int FindKthPositive(int[] arr, int k)
        {
            if (arr[0] > k)
            {
                return k;
            }

            k -= arr[0] - 1;

            for (int i = 1; i < arr.Length; i++)
            {
                int gap = arr[i] - arr[i - 1];
                if (k <= gap - 1)
                {
                    return arr[i - 1] + k;
                }
                k -= gap - 1;
            }
            return arr[arr.Length - 1] + k;
        }
        public int FindKthPositive2(int[] arr, int k)
        {
            int low = 0, high = arr.Length - 1;
            while (low <= high)
            {
                int pivot = low + (high - low) / 2;
                if (arr[pivot] < pivot + 1 + k)
                {
                    low = pivot + 1;
                }
                else
                {
                    high = pivot - 1;
                }
            }
            return low + k;
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
