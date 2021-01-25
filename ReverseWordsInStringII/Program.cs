using System;

namespace ReverseWordsInStringII
{
    public class Solution
    {
        public void ReverseWords(char[] s)
        {
            Reverse(s, 0, s.Length - 1);
            int start = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i]==' ')
                {
                    Reverse(s, start, i - 1);
                    start = i + 1;
                }
            }
            Reverse(s, start, s.Length - 1);
        }
        private void Reverse(char[] s, int i, int j)
        {
            while (i<j)
            {
                char temp = s[i];
                s[i] = s[j];
                s[j] = temp;
                i++;
                j--;
            }
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
