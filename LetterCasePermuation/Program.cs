using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LetterCasePermuation
{
    public class Solution
    {
        public IList<string> LetterCasePermutation(string word)
        {
            var q = new Queue<string>();
            q.Enqueue(word);

            for (int i = 0; i < word.Length; i++)
            {
                if (char.IsDigit(word[i]))
                {
                    continue;
                }
                int s = q.Count;
                while (s-->0)
                {
                    var node = q.Dequeue();
                    var ca = node.ToCharArray();
                    ca[i] = char.ToLower(ca[i]);
                    q.Enqueue(new string(ca));
                    ca[i] = char.ToUpper(ca[i]);
                    q.Enqueue(new string(ca));
                }
            }

            return new List<string>(q);
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
