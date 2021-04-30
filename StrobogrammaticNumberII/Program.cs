using System;
using System.Collections.Generic;
using System.Linq;

namespace StrobogrammaticNumberII
{
    public class Solution
    {
        public IList<string> FindStrobogrammatic(int n)
        {

            return Helper(n, n).OrderBy(s => s).ToList();
        }

        private IList<string> Helper(int m, int n)
        {
            if (n==0)
            {
                return new List<string> { "" };
            }
            if (n==1)
            {
                return new List<string> { "0", "1", "8" };
            }

            var list = Helper(m, n - 2);
            var result = new List<string>();
            foreach (var item in list)
            {
                if (m!=n)
                {
                    result.Add("0" + item + "0");
                }
                result.Add("1" + item + "1");
                result.Add("6" + item + "9");
                result.Add("9" + item + "6");
                result.Add("8" + item + "8");
            }

            return result;
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
