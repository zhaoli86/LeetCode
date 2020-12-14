using System;
using System.Collections.Generic;
using System.Linq;

namespace BraceExpansion
{
    public class Solution
    {
        public string[] Expand(string s)
        {
            if (s.Length==0)
            {
                return new string[] { "" };
            }
            else if (s.Length==1)
            {
                return new string[] { s };
            }
            var set = new SortedSet<string>();

            if (s[0]=='{')
            {
                int i;
                for (i = 1; s[i] != '}'; i++){}
                var content = s.Substring(1, i - 1);
                var strs = content.Split(',');
                var rest = Expand(s.Substring(i + 1));
                foreach (var str in strs)
                {
                    foreach (var item in rest)
                    {
                        set.Add(str + item);
                    }
                }

            }
            else
            {
                var rest = Expand(s.Substring(1));
                foreach (var item in rest)
                {
                    set.Add(s[0] + item);
                }
            }

            return set.ToArray();
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
