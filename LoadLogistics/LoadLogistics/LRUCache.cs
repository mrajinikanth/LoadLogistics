using System.Collections.Generic;

namespace LoadLogistics
{
    internal class LRUCache<TKey, TValue>
    {
        private readonly int capacity;
        private readonly Dictionary<TKey, LinkedListNode<CacheItem>> cache;
        private readonly LinkedList<CacheItem> lruList;

        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            this.cache = new Dictionary<TKey, LinkedListNode<CacheItem>>(capacity);
            this.lruList = new LinkedList<CacheItem>();
        }

        public TValue Get(TKey key)
        {
            if (cache.TryGetValue(key, out var node))
            {
                TValue value = node.Value.Value;
                lruList.Remove(node);
                lruList.AddFirst(node);
                return value;
            }

            return default(TValue); // Key not found
        }

        public void Put(TKey key, TValue value)
        {
            if (cache.Count >= capacity)
            {
                // Remove least recently used item
                LinkedListNode<CacheItem> lastNode = lruList.Last;
                cache.Remove(lastNode.Value.Key);
                lruList.RemoveLast();
            }

            // Add new item as the most recently used
            LinkedListNode<CacheItem> newNode = new LinkedListNode<CacheItem>(new CacheItem(key, value));
            lruList.AddFirst(newNode);
            cache[key] = newNode;
        }

        private class CacheItem
        {
            public TKey Key { get; }
            public TValue Value { get; }

            public CacheItem(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }
        }
    }
}

