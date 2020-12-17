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

    public class Solution2
    {
        public int NumSubarraysWithSum(int[] A, int S)
        {
            int res = 0, idxLo = 0, idxHi = 0, sumLo = 0, sumHi = 0;
            for (int j = 0; j < A.Length; j++)
            {
                sumLo += A[j];
                while (idxLo < j && sumLo > S)
                {
                    sumLo -= A[idxLo++];
                }

                sumHi += A[j];
                while (idxHi < j && (sumHi > S || sumHi == S && A[idxHi] == 0))
                {
                    sumHi -= A[idxHi++];
                }
                if (sumLo == S)
                {
                    res += idxHi - idxLo + 1;
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
