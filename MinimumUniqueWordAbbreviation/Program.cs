using System;
using System.Collections.Generic;
using System.Text;

namespace MinimumUniqueWordAbbreviation
{
    public class Solution
    {
        private class Node
        {
            public Node[] Nodes { get; set; }
            public bool IsWord { get; set; }
            public Node()
            {
                Nodes = new Node[26];
                IsWord = false;
            }

            public void Add(string str)
            {
                if (str.Length == 0)
                {
                    IsWord = true;
                }
                else
                {
                    int idx = str[0] - 'a';
                    if (Nodes[idx] == null)
                    {
                        Nodes[idx] = new Node();
                    }
                    Nodes[idx].Add(str.Substring(1));

                }
            }

            public bool IsAbbr(string abbr, int num)
            {
                if (num > 0)
                {
                    foreach (var node in Nodes)
                    {
                        if (node != null && node.IsAbbr(abbr, num - 1))
                        {
                            return true;
                        }
                    }
                    return false;
                }
                else
                {
                    if (abbr.Length == 0)
                    {
                        return IsWord;
                    }
                    int idx = 0;
                    while (idx < abbr.Length && abbr[idx] >= '0' && abbr[idx] <= '9')
                    {
                        num = (num * 10) + (abbr[idx++] - '0');
                    }
                    if (num > 0)
                    {
                        return IsAbbr(abbr.Substring(idx), num);
                    }
                    else
                    {
                        if (Nodes[abbr[0] - 'a'] != null)
                        {
                            return Nodes[abbr[0] - 'a'].IsAbbr(abbr.Substring(1), 0);
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }
        public string MinAbbreviation(string target, string[] dictionary)
        {
            var dict = new List<string>();
            int len = target.Length;
            foreach (var str in dictionary)
            {
                if (str.Length == len)
                {
                    dict.Add(str);
                }
            }
            if (dict.Count == 0)
            {
                return len.ToString();
            }
            var root = new Node();
            foreach (var str in dict)
            {
                root.Add(str);
            }
            var cc = target.ToCharArray();
            string ret = null;

            int min = 1, max = len;
            while (max >= min)
            {
                int mid = min + (max - min) / 2;
                var abbs = new List<string>();
                GetAbbs(cc, 0, mid, new StringBuilder(), abbs);
                bool confict = true;
                foreach (var abbr in abbs)
                {
                    if (!root.IsAbbr(abbr, 0))
                    {
                        confict = false;
                        ret = abbr;
                        break;
                    }

                }
                if (confict)
                {
                    min = mid + 1;
                }
                else
                {
                    max = mid - 1;
                }
            }
            return ret;
        }

        private void GetAbbs(char[] cc, int s, int len, StringBuilder sb, List<string> abbs)
        {
            bool preNum = (sb.Length > 0) && (sb[sb.Length - 1] >= '0') && (sb[sb.Length - 1] <= '9');
            if (len == 1)
            {
                if (s < cc.Length)
                {
                    if (s == cc.Length - 1)
                    {
                        abbs.Add(sb.ToString() + cc[s]);
                    }
                    if (!preNum)
                    {
                        abbs.Add(sb.ToString() + (cc.Length - s));
                    }
                }
            }
            else if (len > 1)
            {
                int last = sb.Length;
                for (int i = s + 1; i < cc.Length; i++)
                {
                    if (!preNum)
                    {
                        sb.Append(i - s);
                        GetAbbs(cc, i, len - 1, sb, abbs);
                        sb.Remove(last, sb.Length - last);
                    }
                    if (i == s + 1)
                    {
                        sb.Append(cc[s]);
                        GetAbbs(cc, i, len - 1, sb, abbs);
                        sb.Remove(last, sb.Length - last);
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var target = "apple";
            var list = new List<string> { "blade" }.ToArray();
            var result = new Solution().MinAbbreviation(target, list);
            Console.WriteLine("Hello World!");
        }
    }
}
