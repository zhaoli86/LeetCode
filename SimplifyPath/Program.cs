using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SimplifyPath
{
    public class Solution
    {
        public string SimplifyPath(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return path;
            }
            var stack = new Stack<string>();
            var components = path.Split('/');
            foreach (var component in components)
            {
                if (component=="" || component==".")
                {
                    continue;
                }
                else if (component=="..")
                {
                    if (stack.Count>0)
                    {
                        stack.Pop();
                    }
                }
                else
                {
                    stack.Push(component);
                }
            }

            var sb = new StringBuilder();
            foreach (var item in stack)
            {
                sb.Insert(0, item);
                sb.Insert(0, "/");
            }
            return sb.Length == 0 ? "/" : sb.ToString();
        }
    }
    class Program
    {
        public delegate void aaa(int a);
        static void Main(string[] args)
        {
            var s = new Solution();
            var input = "/a/b/";
            var result = s.SimplifyPath(input);

            Console.WriteLine("Hello World!");
        }
    }
}
