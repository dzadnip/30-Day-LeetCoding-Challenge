using System;
using System.Collections.Generic;
using System.Text;

namespace LRUCache
{
    class LRUCache
    {
        private List<int> _history = new List<int>();
        private Dictionary<int, int> _cache = new Dictionary<int, int>();
        private int _capacity = 0;

        public LRUCache(int capacity)
        {
            _cache.EnsureCapacity(capacity);
            _capacity = capacity;
        }

        public int Get(int key)
        {
            if (_cache.ContainsKey(key))
            {
                while (_history.Contains(key))
                {
                    _history.Remove(key);
                }
                _history.Add(key);
                return _cache[key];
            }
            return -1;
        }

        public void Put(int key, int value)
        {
            if (_cache.ContainsKey(key))
            {
                _cache[key] = value;
            }
            else
            {
                if (_cache.Count == _capacity)
                {
                    _cache.Remove(_history[0]);
                    int removeKey = _history[0];
                    while (_history.Contains(removeKey))
                    {
                        _history.Remove(removeKey);
                    }
                }
                _cache.Add(key, value);
            }

            while (_history.Contains(key))
            {
                _history.Remove(key);
            }
            _history.Add(key);
        }
    }
}
