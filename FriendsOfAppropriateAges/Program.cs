using System;
using System.Collections.Generic;

namespace FriendsOfAppropriateAges
{
    public class Solution
    {
        public int NumFriendRequests(int[] ages)
        {
            var map = new int[121];
            foreach (var age in ages)
            {
                map[age]++;
            }
            int result = 0;
            for (int i = 1; i <= 120; i++)
            {
                int ic = map[i];
                for (int j = i; j <= 120; j++)
                {
                    int jc = map[j];
                    if (i<=0.5*j+7)
                    {
                        continue;
                    }
                    result += ic * jc;
                    if (i==j)
                    {
                        result -= ic;
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
