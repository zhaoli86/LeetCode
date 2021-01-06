using System;
using System.Collections.Generic;

namespace SequenceReconstruction
{
    public class Solution
    {
        public bool SequenceReconstruction(int[] org, IList<IList<int>> seqs)
        {
            if (seqs == null || seqs.Count == 0)
            {
                return false;
            }
            var pos = new int[org.Length + 1];
            var states = new bool[org.Length];

            for (int i = 0; i < org.Length; i++)
            {
                pos[org[i]] = i;
            }
            foreach (var seq in seqs)
            {
                for (int i = 0; i < seq.Count; i++)
                {
                    if (seq[i] < 1 || seq[i] > org.Length)
                    {
                        return false;
                    }

                    if (i > 0 && pos[seq[i-1]] >= pos[seq[i]])
                    {
                        return false;
                    }

                    if (i > 0 && pos[seq[i-1]] + 1 == pos[seq[i]])
                    {
                        states[pos[seq[i-1]]] = true;
                    }
                }
            }

            for (int i = 0; i < org.Length - 1; i++)
            {
                if (!states[i])
                {
                    return false;
                }
            }

            return true;
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
