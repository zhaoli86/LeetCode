using System;
using System.Collections.Generic;
using System.Linq;

namespace GetWatchedVideosByYourFriends
{
    public class Solution
    {
        public IList<string> WatchedVideosByFriends(IList<IList<string>> watchedVideos, int[][] friends, int id, int level)
        {
            int n = friends.Length;
            var result = new Dictionary<string, int>();
            var seenFriends = new bool[n];
            var q = new Queue<int>();
            q.Enqueue(id);
            seenFriends[id] = true;

            while (q.Any() && level-- > 0)
            {
                int count = q.Count;
                while (count-- > 0)
                {
                    var node = q.Dequeue();
                    foreach (var friend in friends[node])
                    {
                        if (!seenFriends[friend])
                        {
                            seenFriends[friend] = true;
                            q.Enqueue(friend);
                        }
                    }
                }
            }

            while (q.Any())
            {
                foreach (var vid in watchedVideos[q.Dequeue()])
                {
                    if (!result.ContainsKey(vid))
                    {
                        result[vid] = 1;
                    }
                    else
                    {
                        result[vid]++;
                    }
                }
            }

            return result.Keys.OrderBy(k => result[k]).ThenBy(k=>k).ToList();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var map = new Dictionary<string, int> { { "aaaaa", 1 }, { "a", 1 } };

            Console.WriteLine("Hello World!");
        }
    }
}
