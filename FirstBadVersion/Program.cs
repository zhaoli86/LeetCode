using System;

namespace FirstBadVersion
{
    public class Solution
    {
        bool IsBadVersion(int version) { return false; }
        public int FirstBadVersion(int n)
        {
            int low = 1, high = n;
            int result = -1;
            while (low<=high)
            {
                int mid = low + (high - low) / 2;
                if (IsBadVersion(mid))
                {
                    result = mid;
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
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
