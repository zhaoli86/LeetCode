using System;
using System.Linq;

namespace ReverseWordsInString
{
    public class Solution
    {
        public string ReverseWords(string s)
        {
            var words = s.Split(' ').Where(w => w != "").Reverse();
            return string.Join(' ', words);

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
