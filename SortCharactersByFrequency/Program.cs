using System;
using System.Collections.Generic;
using System.Text;

namespace SortCharactersByFrequency
{
    public class Solution
    {
        public string FrequencySort(string s)
        {
            var frequency = new Dictionary<char, int>();
            foreach (var c in s)
            {
                if (frequency.ContainsKey(c))
                {
                    frequency[c]++;
                }
                else
                {
                    frequency[c] = 1;
                }
            }
            int len = s.Length;
            var buckets = new List<char>[len+1];
            foreach (var kvp in frequency)
            {
                if (buckets[kvp.Value]==null)
                {
                    buckets[kvp.Value] = new List<char> { kvp.Key };
                }
                else
                {
                    buckets[kvp.Value].Add(kvp.Key);
                }
            }

            var sb = new StringBuilder();
            for (int i = len; i >=0; i--)
            {
                if (buckets[i]!=null)
                {
                    foreach (var c in buckets[i])
                    {
                        for (int j = 0; j < frequency[c]; j++)
                        {
                            sb.Append(c);
                        }
                    }
                }
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
