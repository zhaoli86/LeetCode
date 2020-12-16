using System;
using System.Collections.Generic;
using System.Text;

namespace NumberOfAtoms
{
    public class Solution
    {
        public string CountOfAtoms(string formula)
        {
            var map = new SortedDictionary<string, int>();
            var stack = new Stack<SortedDictionary<string, int>>();
            int i = 0;
            int n = formula.Length;
            while (i < n)
            {
                var c = formula[i];
                i++;
                if (c == '(')
                {
                    stack.Push(map);
                    map = new SortedDictionary<string, int>();
                }
                else if (c == ')')
                {
                    int value = 0;
                    while (i < n && char.IsDigit(formula[i]))
                    {
                        value = value * 10 + (formula[i] - '0');
                        i++;
                    }
                    if (value == 0)
                    {
                        value = 1;
                    }
                    var temp = map;
                    map = stack.Pop();
                    foreach (var key in temp.Keys)
                    {
                        map[key] = (map.ContainsKey(key) ? map[key] : 0) + temp[key] * value;
                    }
                }
                else
                {
                    int start = i - 1;
                    while (i < n && char.IsLower(formula[i]))
                    {
                        i++;
                    }
                    var name = formula.Substring(start, i - start);
                    int value = 0;
                    while (i < n && char.IsDigit(formula[i]))
                    {
                        value = value * 10 + (formula[i] - '0');
                        i++;
                    }
                    if (value == 0)
                    {
                        value = 1;
                    }
                    map[name] = (map.ContainsKey(name) ? map[name] : 0) + value;
                }
            }
            var sb = new StringBuilder();
            foreach (var item in map)
            {
                sb.Append(item.Key);
                if (item.Value>1)
                {
                    sb.Append(item.Value);
                }
            }
            return sb.ToString();
        }
    }
    class Program
    {
      
        static void Main(string[] args)
        {
            var s = new Solution();
            var input = "H11He49NO35B7N46Li20"; //"B7H11He49Li20N47O35"

            var result = s.CountOfAtoms(input);
            Console.WriteLine("Hello World!");
        }
    }
}
