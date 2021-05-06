using System;
using System.Collections.Generic;
using System.Linq;

namespace TopKFrequentWords
{
    public class Solution
    {
        public IList<string> TopKFrequent(string[] words, int k)
        {
            var map = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (map.ContainsKey(word))
                {
                    map[word]++;
                }
                else
                {
                    map[word] = 1;
                }
            }

            return map.OrderByDescending(kvp => kvp.Value).ThenBy(p => p.Key).Take(k).Select(i => i.Key).ToList();
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
