using System;

namespace PermutationInString
{
    public class Solution
    {
        public bool CheckInclusion(string s1, string s2)
        {
            if (s2.Length < s1.Length)
            {
                return false;
            }
            var map1 = new int[26];
            var map2 = new int[26];
            for (int i = 0; i < s1.Length; i++)
            {
                map1[s1[i] - 'a']++;
                map2[s2[i] - 'a']++;
            }
            if (Match(map1, map2))
            {
                return true;
            }
            int j = s1.Length;
            while (j < s2.Length)
            {
                map2[s2[j] - 'a']++;
                map2[s2[j - s1.Length] - 'a']--;
                if (Match(map1, map2))
                {
                    return true;
                }
                j++;
            }
            return false;
        }
        private bool Match(int[] m1, int[] m2)
        {
            for (int i = 0; i < m1.Length; i++)
            {
                if (m1[i]!=m2[i])
                {
                    return false;
                }
            }
            return true;
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
