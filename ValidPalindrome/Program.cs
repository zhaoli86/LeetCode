using System;

namespace ValidPalindrome
{
    public class Solution
    {
        public bool IsPalindrome(string s)
        {
            s = s.ToLower();
            int i = 0, j = s.Length - 1;
            while (i<j)
            {
                while (i<j&&!IsValid(s[i]))
                {
                    i++;
                }
                while (i<j&&!IsValid(s[j]))
                {
                    j--;
                }
                if (i<j&&s[i++]!=s[j--])
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsValid(char c)
        {
            return (c >= '0' && c <= '9') || (c >= 'a' && c <= 'z');
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 4; i++)
            {
                var a = "aa";
                
            }
            Console.WriteLine("Hello World!");
        }
    }
}
