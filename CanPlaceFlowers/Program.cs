using System;

namespace CanPlaceFlowers
{
    public class Solution
    {
        public bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            if (n==0)
            {
                return true;
            }
            for (int i = 0; i < flowerbed.Length; i++)
            {
                int prev = i == 0 ? 0 : flowerbed[i - 1];
                int next = i == flowerbed.Length - 1 ? 0 : flowerbed[i + 1];
                if (flowerbed[i]==0&& prev==0&&next==0)
                {
                    flowerbed[i] = 1;
                    n--;
                    if (n==0)
                    {
                        return true;
                    }
                }
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
