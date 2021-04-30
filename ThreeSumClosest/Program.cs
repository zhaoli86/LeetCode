using System;

namespace ThreeSumClosest
{
    public class Solution
    {
        public int ThreeSumClosest(int[] nums, int target)
        {
            int result = 0;
            Array.Sort(nums);
            int closestTarget = int.MaxValue;
            for (int i = 0; i < nums.Length-2; i++)
            {
                int low = i + 1, high = nums.Length - 1;
                int complement = target - nums[i];
                while (low<high)
                {
                    int curSum = nums[low] + nums[high];
                    int curDiff = Math.Abs(curSum - complement);

                    if (curDiff<closestTarget)
                    {
                        closestTarget = curDiff;
                        result = curSum + nums[i];

                    }
                    closestTarget = Math.Min(closestTarget, Math.Abs(curSum - complement));
                    if (curSum>complement)
                    {
                        high--;
                    }
                    else
                    {
                        low++;
                    }
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
