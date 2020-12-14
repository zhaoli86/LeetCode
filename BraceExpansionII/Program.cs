using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BraceExpansionII
{
    public class Solution
    {
        private Queue<string> q = new Queue<string>();
        private List<string> result = new List<string>();
        private StringBuilder sb = new StringBuilder();
        private HashSet<string> set = new HashSet<string>();

        public IList<string> BraceExpansionII(string expression)
        {
            q.Enqueue(expression);
            BraceExImpl();
            return result.Distinct().OrderBy(a => a).ToList();
        }

        private void BraceExImpl()
        {
            while (q.Count!=0)
            {
                var str = q.Dequeue();
                if (!str.Contains('{'))
                {
                    if (!set.Contains(str))
                    {
                        set.Add(str);
                        result.Add(str);
                    }
                    continue;
                }

                int left = 0, right = 0, i = 0;

                while (str[i]!='}')
                {
                    if (str[i]=='{')
                    {
                        left = i;
                    }
                    i++;
                }
                right = i;

                var pre = str.Substring(0, left - 0);
                var post = str.Substring(right + 1);
                var args = str.Substring(left + 1, right - left - 1).Split(',');

                foreach (var arg in args)
                {
                    sb.Clear();
                    q.Enqueue(sb.Append(pre).Append(arg).Append(post).ToString());
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var input = "{{a,z},a{b,c},{ab,z}}";
            var result = s.BraceExpansionII(input);

            Console.WriteLine("Hello World!");
        }
    }
}
