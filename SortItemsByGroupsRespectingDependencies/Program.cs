using System;
using System.Collections.Generic;
using System.Linq;

namespace SortItemsByGroupsRespectingDependencies
{
    public class Solution
    {
        public int[] SortItems(int n, int m, int[] group, IList<IList<int>> beforeItems)
        {
            var res = new List<int>();
            var graph = new List<int>[m + n];
            var indegree = new int[m + n];

            for (int i = 0; i < n+m; i++)
            {
                graph[i] = new List<int>();
            }

            for (int i = 0; i < group.Length; i++)
            {
                if (group[i]==-1)
                {
                    continue;
                }

                graph[n + group[i]].Add(i);
                indegree[i]++;
            }

            for (int i = 0; i < beforeItems.Count; i++)
            {
                foreach (var item in beforeItems[i])
                {
                    int repBeforeItem = group[item] == -1 ? item : n + group[item];
                    int repCurItem = group[i] == -1 ? i : n + group[i];

                    if (repBeforeItem==repCurItem)
                    {
                        graph[item].Add(i);
                        indegree[i]++;
                    }
                    else
                    {
                        graph[repBeforeItem].Add(repCurItem);
                        indegree[repCurItem]++;
                    }
                }
            }

            for (int i = 0; i < n+m; i++)
            {
                if (indegree[i]==0)
                {
                    Dfs(graph, indegree, i, n, res);
                }
            }

            return res.Count == n ? res.ToArray() : new int[] { };
        }

        private void Dfs(List<int>[] graph, int[] indegree, int cur, int n, List<int> res)
        {
            if (cur<n)
            {
                res.Add(cur);
            }
            indegree[cur]--;
            foreach (var child in graph[cur])
            {
                if (--indegree[child]==0)
                {
                    Dfs(graph, indegree, child, n, res);
                }
            }

        }
    }

    public class Solution2
    {
        Dictionary<int, List<int>> groupGraph = new Dictionary<int, List<int>>();
        Dictionary<int, List<int>> itemGraph = new Dictionary<int, List<int>>();

        int[] groupsIndegree;
        int[] itemsIndegree;

        public int[] SortItems(int n, int m, int[] group, IList<IList<int>> beforeItems)
        {
            for (int i = 0; i < group.Length; i++)
            {
                if (group[i] == -1)
                {
                    group[i] = m++;
                }
            }

            for (int i = 0; i < m; i++)
            {
                groupGraph[i] = new List<int>();
            }

            for (int i = 0; i < n; i++)
            {
                itemGraph[i] = new List<int>();
            }

            groupsIndegree = new int[m];
            itemsIndegree = new int[n];

            BuildGraphOfGroups(group, beforeItems, n);

            BuildGraphOfItems(beforeItems, n);

            var groupsList = TopologicalSortUtil(groupGraph, groupsIndegree, m);

            var itemsList = TopologicalSortUtil(itemGraph, itemsIndegree, n);

            if (groupsList.Count == 0 || itemsList.Count == 0)
            {
                return new int[0];
            }

            var groupsToItems = new Dictionary<int, List<int>>();
            foreach (var item in itemsList)
            {
                if (groupsToItems.ContainsKey(group[item]))
                {
                    groupsToItems[group[item]].Add(item);
                }
                else
                {
                    groupsToItems[group[item]] = new List<int> { item };
                }
            }

            var result = new int[n];
            int idx = 0;
            foreach (var grp in groupsList)
            {
                if (!groupsToItems.ContainsKey(grp))
                {
                    groupsToItems[grp] = new List<int>();
                }
                foreach (var item in groupsToItems[grp])
                {
                    result[idx++] = item;
                }
            }
            return result;

        }

        private List<int> TopologicalSortUtil(Dictionary<int, List<int>> graph, int[] indegree, int n)
        {
            var result = new List<int>();
            var q = new Queue<int>();
            for (int i = 0; i < indegree.Length; i++)
            {
                if (indegree[i]==0)
                {
                    q.Enqueue(i);
                }
            }

            while (q.Any())
            {
                var node = q.Dequeue();
                n--;
                result.Add(node);
                foreach (var neighbor in graph[node])
                {
                    indegree[neighbor]--;
                    if (indegree[neighbor]==0)
                    {
                        q.Enqueue(neighbor);
                    }
                }

            }

            return n == 0 ? result : new List<int>();
        }

        private void BuildGraphOfItems(IList<IList<int>> beforeItems, int n)
        {
            for (int i = 0; i < beforeItems.Count; i++)
            {
                foreach (var item in beforeItems[i])
                {
                    itemGraph[item].Add(i);
                    itemsIndegree[i]++;
                }
            }
        }

        private void BuildGraphOfGroups(int[] group, IList<IList<int>> beforeItems, int n)
        {
            for (int i = 0; i < beforeItems.Count; i++)
            {
                var destGroup = group[i];
                foreach (var item in beforeItems[i])
                {
                    var srcGroup = group[item];
                    if (srcGroup != destGroup)
                    {
                        groupGraph[srcGroup].Add(destGroup);
                        groupsIndegree[destGroup]++;
                    }
                }

            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var group = new int[] { 2, 0, -1, 3, 0 };
            var beforeItems = new List<IList<int>> { new List<int> {2, 1, 3 }, new List<int> { 2, 4 },
             new List<int>{ }, 
            new List<int>{ }, new List<int>{ } };
            var res = new Solution2().SortItems(5, 5, group, beforeItems);
            Console.WriteLine("Hello World!");
        }
    }
}
