using System;
using System.Collections.Generic;

namespace LongestSubstringWithAtLeastKRepeatingChars
{
    //brute force
    public class Solution
    {
        public int LongestSubstring(string s, int k)
        {
            int res = 0;
            var count = new int[26];


            for (int i = 0; i < s.Length; i++)
            {
                Array.Fill(count, 0);
                for (int j = i; j < s.Length; j++)
                {
                    count[s[j] - 'a']++;
                    if (IsValid(count, k))
                    {
                        res = Math.Max(res, j - i + 1);
                    }
                }
            }
            return res;
        }

        private bool IsValid(int[] count, int k)
        {
            int allCount = 0, kCount = 0;
            foreach (var c in count)
            {
                if (c>0)
                {
                    if (c >= k)
                    {
                        kCount++;
                    }
                    allCount++;
                }

            }

            return kCount == allCount;
        }
    }

    public class Solution2
    {
        public int LongestSubstring(string s, int k)
        {
            int res = 0, start = 0, end = 0;

            var countMap = new Dictionary<char, int>();
            var lessMap = new Dictionary<char, int>();
            foreach (var c in s)
            {
                if (countMap.ContainsKey(c))
                {
                    countMap[c]++;
                }
                else
                {
                    countMap[c] = 1;
                }
            }
            foreach (var kvp in countMap)
            {
                if (kvp.Value < k)
                {
                    lessMap[kvp.Key] = kvp.Value;
                }
            }
            if (lessMap.Count==0)
            {
                return s.Length;
            }
            while (end<s.Length)
            {
                var c = s[end];
                if (lessMap.ContainsKey(c))
                {
                    if (start<end)
                    {
                        res = Math.Max(res, LongestSubstring(s.Substring(start, end - start), k));
                    }
                    start = end + 1;
                }
                end++;

            }
            if (start!=end)
            {
                res = Math.Max(res, LongestSubstring(s.Substring(start), k));
            }
            return res;
        }

    }


    public class Solution3
    {
        public int LongestSubstring(string s, int k)
        {
            int res = 0;
            int uniqueCount = GetUniqueCount(s);
            var countMap = new int[26];
            for (int curUnique = 1; curUnique <= uniqueCount; curUnique++)
            {
                int start = 0, end = 0, countAtLeastK = 0, unique = 0;
                Array.Fill(countMap, 0);
                while (end < s.Length)
                {
                    //bbaaacbd
                    if (unique <= curUnique)
                    {
                        int idx = s[end] - 'a';
                        if (countMap[idx] == 0)
                        {
                            unique++;
                        }
                        if (++countMap[idx] == k)
                        {
                            countAtLeastK++;
                        }
                        end++;
                    }
                    else
                    {
                        int idx = s[start] - 'a';
                        if (countMap[idx] == k)
                        {
                            countAtLeastK--;
                        }
                        if (--countMap[idx] == 0)
                        {
                            unique--;
                        }

                        start++;
                    }
                    if (unique == curUnique && unique == countAtLeastK)
                    {
                        res = Math.Max(res, end - start);
                    }

                }

            }
            return res;
        }

        private int GetUniqueCount(string s)
        {
            int count = 0;
            var map = new int[26];
            foreach (var c in s)
            {
                if (map[c-'a']++==0)
                {
                    count++;
                }
            }
            return count;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            var input = "bbaaacbd";
            int k = 3;
            var res = new Solution3().LongestSubstring(input, k);
            Console.WriteLine("Hello World!");
        }
    }
}
