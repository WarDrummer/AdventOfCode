using System.Collections.Generic;

namespace AdventOfCode.Year2021.Day08
{
    public class TwoWayLookup<TKey,TValue> 
    {
        private readonly Dictionary<TKey, TValue> _lookup = new ();
        private readonly Dictionary<TValue, TKey> _reverseLookup = new ();

        public bool ContainsKey(TKey key)
        {
            return _lookup.ContainsKey(key);
        }
        
        public bool ContainsValue(TValue value)
        {
            return _reverseLookup.ContainsKey(value);
        }

        public TKey GetKeyForValue(TValue value)
        {
            return _reverseLookup[value];
        }
        
        public TValue GetValueForKey(TKey key)
        {
            return _lookup[key];
        }

        public void Add(TKey key, TValue value)
        {
            _lookup[key] = value;
            _reverseLookup[value] = key;
        }

        public Dictionary<TKey, TValue> GetLookup()
        {
            return _lookup;
        }
        
        public Dictionary<TValue, TKey> GetReverseLookup()
        {
            return _reverseLookup;
        }
    }
}