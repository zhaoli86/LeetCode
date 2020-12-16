using System;

namespace BinarySubarraysWithSum
{
    public class Solution
    {
        public int NumSubarraysWithSum(int[] A, int S)
        {
            var count = new int[A.Length + 1];
            count[0] = 1;
            int psum = 0;
            int result = 0;
            foreach (var num in A)
            {
                psum += num;
                if (psum>=S)
                {
                    result += count[psum - S];
                }
                count[psum]++;
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
