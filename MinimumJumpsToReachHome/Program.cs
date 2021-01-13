using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace MinimumJumpsToReachHome
{
    public class State //: IComparable
    {
        public int Step { get; set; }
        public int Pos { get; set; }
        public bool Forward { get; set; }

        //public int CompareTo(object obj)
        //{
        //    return Step.CompareTo(((State)obj).Step);
        //}
        public override bool Equals(object obj)
        {
            var otherState = obj as State;
            return otherState.Step == Step && otherState.Pos == Pos && otherState.Forward == Forward;
        }
        public override int GetHashCode()
        {
            return Step.GetHashCode() ^ Pos.GetHashCode() + Forward.GetHashCode();
        }
    }

    public class StateComparer : IComparer<State>
    {
        public int Compare([AllowNull] State x, [AllowNull] State y)
        {
            return x.Step.CompareTo(y.Step);
        }
    }
    public class Solution
    {

        public int MinimumJumps(int[] forbidden, int a, int b, int x)
        {
            var states = new SortedSet<State>();
            states.Add(new State { Step = 0, Forward = true, Pos = 0 });
            var visited = new HashSet<string>();
            var forbid = new HashSet<int>();

            int max = 2000 + 2 * b;
            foreach (var item in forbidden)
            {
                forbid.Add(item);
                max = Math.Max(max, item + 2 * b);
            }
            while (states.Any())
            {
                var state = states.First();
                states.Remove(state);

                if (state.Pos == x)
                {
                    return state.Step;
                }

                if (state.Pos + a < max && !forbid.Contains(state.Pos + a) && !visited.Contains(state.Pos + a + "," + state.Forward))
                {
                    states.Add(new State { Pos = state.Pos + a, Forward = true, Step = state.Step + 1 });
                    visited.Add(state.Pos + a + "," + state.Forward);
                }
                if (state.Pos - b >= 0 && !forbid.Contains(state.Pos - b) && !visited.Contains(state.Pos - b + "," + state.Forward) && state.Forward)
                {
                    states.Add(new State { Pos = state.Pos - b, Forward = false, Step = state.Step + 1 });
                    states.Add(new State { Pos = 111, Forward = false, Step = 22 });
                    visited.Add(state.Pos - b + "," + state.Forward);
                }
            }
            return -1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 1, 6, 2, 14, 5, 17, 4 };
            //var result = new Solution().MinimumJumps(input, 16, 9, 7);
            var set = new SortedSet<State>(new StateComparer());
            set.Add(new State { Step = 2, Pos = 32, Forward = true });
            set.Add(new State { Step = 2, Pos = 9, Forward = false });
            Console.WriteLine("Hello World!");
        }
    }
}
