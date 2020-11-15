using System;
using System.IO;

namespace HIndexII
{
    class Program
    {
        public static int HIndex(int[] citations)
        {
            int len = citations.Length;
            int start = 0;
            int end = len - 1;

            while (start<=end)
            {
                int mid = start + (end - start) / 2;
                int val = citations[mid];
                if (len-mid==val)
                {
                    return val;
                }
                else if (len-mid > val)
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }
            return len-end-1;
        }

        public static void Main(string[] args)
        {
            for (int i = 0, j=1; i < 3 || j< 4; i++, j++)
            {
                Console.WriteLine("aa");
            }
            var input = new int[] { 100 };
            var index = HIndex(input);
            Console.WriteLine("Hello World!");
        }
    }
}
