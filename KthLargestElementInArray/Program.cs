using System;

namespace KthLargestElementInArray
{
    public class Solution
    {
        public int FindKthLargest(int[] nums, int k)
        {
            return Helper(nums, 0, nums.Length - 1, k);
        }

        private int Helper(int[] nums, int low, int high, int k)
        {
            int pivot = Partition(nums, low, high);
            if (pivot == k - 1)
            {
                return nums[pivot];
            }
            else if (pivot < k - 1)
            {
                return Helper(nums, pivot + 1, high, k);
            }
            else
            {
                return Helper(nums, low, pivot - 1, k);
            }
        }

        private int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int pivotLocation = low;
            for (int i = low; i <= high; i++)
            {
                if (arr[i] > pivot)
                {
                    Swap(arr, i, pivotLocation);
                    pivotLocation++;
                }
            }

            Swap(arr, high, pivotLocation);

            return pivotLocation;
        }

        private void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 3, 2, 1, 5, 6, 4 };
            var result = new Solution().FindKthLargest(input, 2);

            Console.WriteLine("Hello World!");
        }
    }
}
