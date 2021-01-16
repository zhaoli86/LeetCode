using System;

namespace JumpGameIII
{
    public class Solution
    {
        public bool CanReach(int[] arr, int start)
        {
            if (start>=0 && start<arr.Length && arr[start]<arr.Length)
            {
                int jump = arr[start];
                arr[start] += arr.Length;
                return jump == 0 || CanReach(arr, start + jump) || CanReach(arr, start - jump);
            }
            return false;
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
