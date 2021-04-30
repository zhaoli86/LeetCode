using System;
using System.Collections.Generic;
using System.Text;

namespace GroupShiftedStrings
{
    public class Solution
    {
        public IList<IList<string>> GroupStrings(string[] strings)
        {
            var result = new List<IList<string>>();
            var map = new Dictionary<string, List<string>>();
            foreach (var s in strings)
            {
                var encodedStr = Encode(s);
                if (map.ContainsKey(encodedStr))
                {
                    map[encodedStr].Add(s);
                }
                else
                {
                    map[encodedStr] = new List<string> { s };
                }
            }

            foreach (var kvp in map)
            {
                result.Add(kvp.Value);
            }
            return result;
        }

        private string Encode(string s)
        {
            var sb = new StringBuilder();
            int len = s.Length;
            sb.Append(len).Append(";");
            for (int i = 1; i < len; i++)
            {
                int offset = s[i] - s[i - 1];
                if (offset<0)
                {
                    offset += 26;
                }
                sb.Append(offset).Append(",");
            }
            return sb.ToString();
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
