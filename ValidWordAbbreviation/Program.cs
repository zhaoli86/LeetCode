using System;

namespace ValidWordAbbreviation
{
    public class Solution
    {
        public bool ValidWordAbbreviation(string word, string abbr)
        {
            int i = 0, j = 0, count = 0;
            while (i<word.Length&&j<abbr.Length)
            {
                if (abbr[j]>='a' && abbr[j]<='z')
                {
                    while (count>0)
                    {
                        count--;
                        i++;
                    }
                    if (i>=word.Length)
                    {
                        return false;
                    }
                    if (word[i] != abbr[j])
                    {
                        return false;
                    }
                    i++;
                    j++;
                }
                else
                {
                    count = count * 10 + (abbr[j] - '0');
                    if (count==0)
                    {
                        return false;
                    }
                    j++;
                }
            }
            while (count > 0)
            {
                count--;
                i++;
            }
            return i == word.Length && j == abbr.Length;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var result = new Solution().ValidWordAbbreviation("internationalization", "i12iz4n");
            Console.WriteLine("Hello World!");
        }
    }
}
