using System;
using System.Collections.Generic;
using System.Linq;

namespace Utility
{
    public class PriorityQueue<TElement, TKey>
    {
        private SortedDictionary<TKey, Queue<TElement>> dictionary;
        private Func<TElement, TKey> selector;


        public PriorityQueue(Func<TElement, TKey> selector)
        {
            this.selector = selector;
            this.dictionary = new SortedDictionary<TKey, Queue<TElement>>();
        }

        public PriorityQueue(Func<TElement, TKey> selector, IComparer<TKey> comparer)
        {
            this.selector = selector;
            this.dictionary = new SortedDictionary<TKey, Queue<TElement>>(comparer);
        }

        public void Enqueue(TElement item)
        {
            TKey key = selector(item);
            Queue<TElement> queue;
            if (!dictionary.TryGetValue(key, out queue))
            {
                queue = new Queue<TElement>();
                dictionary.Add(key, queue);
            }

            queue.Enqueue(item);
        }

        public TElement Dequeue()
        {
            if (dictionary.Count == 0)
                throw new InvalidOperationException();

            var first = dictionary.First();
            var queue = first.Value;
            var output = queue.Dequeue();
            if (queue.Count == 0)
                dictionary.Remove(first.Key);

            return output;
        }

        public bool Any()
        {
            return dictionary.Any();
        }
    }


    public class PriorityQueue<T>
    {
        private T[] items;
        private int N;
        private Func<T, T, int> comparer;

        public PriorityQueue(Func<T, T, int> comparer, int capacity)
        {
            items = new T[capacity + 1];
            this.comparer = comparer;
        }

        public bool IsEmpty()
        {
            return N == 0;
        }

        public int Size()
        {
            return N;
        }

        public void Insert(T t)
        {
            items[++N] = t;
            Swim(N);
        }

        public T Del()
        {
            T item = items[1];
            Swap(1, N--);
            Sink(1);

            return item;
        }

        public T Top()
        {
            return items[1];
        }

        public void Remove(T t)
        {
            int index = 0;

            for (int i = 1; i < items.Length; i++)
            {
                if (comparer(items[i], t) == 0)
                {
                    index = i;
                    break;
                }
            }

            T item = items[index];
            Swap(index, N--);
            Sink(index);
        }

        private void Swim(int k)
        {
            while (k > 1 && comparer(items[k / 2], items[k]) > 0)
            {
                Swap(k, k / 2);
                k /= 2;
            }
        }

        private void Sink(int k)
        {
            while (2 * k <= N)
            {
                int j = 2 * k;

                if (j < N && comparer(items[j + 1], items[j]) < 0)
                {
                    j++;
                }

                if (comparer(items[j], items[k]) >= 0)
                {
                    break;
                }

                Swap(k, j);
                k = j;
            }
        }

        private void Swap(int i, int j)
        {
            T temp = items[i];
            items[i] = items[j];
            items[j] = temp;
        }
    }
}
