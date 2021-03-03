using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace MaximumXORWithAnElementFromArray
{

    public class Solution
    {
        private class TrieNode
        {
            public TrieNode[] Next { get; set; } = new TrieNode[2];
            public int Val { get; set; }
        }


        public int[] MaximizeXor(int[] nums, int[][] queries)
        {
            var len = queries.Length;
            var ans = new int[len];
            var temp = new int[len][];
            for (int i = 0; i < len; i++)
            {
                temp[i] = new int[3];
                temp[i][0] = queries[i][0];
                temp[i][1] = queries[i][1];
                temp[i][2] = i;
            }

            Array.Sort(nums);
            Array.Sort(temp, (x, y) => x[1].CompareTo(y[1]));
            int index = 0;

            var root = new TrieNode();
            foreach (var query in temp)
            {
                while (index < nums.Length && nums[index] <= query[1])
                {
                    Insert(root, nums[index]);
                    index++;
                }
                int tempAns = -1;
                if (index != 0)
                {
                    tempAns = Search(root, query[0]);
                }
                ans[query[2]] = tempAns;
            }
            return ans;
        }

        private int Search(TrieNode root, int n)
        {
            var node = root;
            for (int i = 31; i >= 0; i--)
            {
                int bit = (n >> i) & 1;
                int requiredBit = bit ^ 1;
                if (node.Next[requiredBit] != null)
                {
                    node = node.Next[requiredBit];
                }
                else
                {
                    node = node.Next[bit];
                }
            }
            return node.Val ^ n;
        }

        private void Insert(TrieNode root, int n)
        {
            var node = root;
            for (int i = 31; i >= 0; i--)
            {
                int bit = (n >> i) & 1;
                if (node.Next[bit] == null)
                {
                    node.Next[bit] = new TrieNode();
                }
                node = node.Next[bit];
            }
            node.Val = n;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var temp = new int[3][]
            {
                new int[3], new int[3], new int[3]
            };
            temp[2][2] = 1;
            Console.WriteLine("Hello World!");
        }
    }
}
