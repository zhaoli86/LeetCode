using System;

namespace ShortestSubarrayToBeRemovedToMakeArraySorted
{
    //have 2 pointers left and right, and both move inwards
    //
    //find the first point from left pointer where arr[i+1]<arr[i] (if array already sorted, return 0)
    //and first point from right pointer where arr[i+1]<arr[i]
    //now we can choose to remove either everything right of left pointer, or everything left of right pointer
    //we find the min of the 2 candidates for removal
    //another option is to remove a subarray in the middle from i==0 to j==right pointer
    //if arr[i]<=arr[j], record the length(j-i-1) and compare with min so far, increment i, else increment j

    public class Solution
    {
        public int FindLengthOfShortestSubarray(int[] arr)
        {
            int left = 0, right = arr.Length - 1, len = arr.Length;

            while (left < len - 1 && arr[left] <= arr[left + 1])
            {
                left++;
            }

            if (left == len - 1)
            {
                return 0;
            }

            while (right > left && arr[right - 1] <= arr[right])
            {
                right--;
            }

            int min = Math.Min(len - left - 1, right);
            int i = 0, j = right;
            while (i <= left && j < len)
            {
                if (arr[i] <= arr[j])
                {
                    min = Math.Min(min, j - i - 1);
                    i++;
                }
                else
                {
                    j++;
                }
            }

            return min;
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
