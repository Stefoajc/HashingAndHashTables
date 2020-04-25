using System;
using System.Collections;
using System.Collections.Generic;

namespace NetIt.Group2.DictionariesAndHashTables
{
    public class CustomHashTable<K,V> : IEnumerable, IEnumerable<KeyValuePair<string, V>>
    {
        private Dictionary<string, V> keyValuePairs = new Dictionary<string, V>();

        private Func<K, string> hashFunction;

        public CustomHashTable(Func<K, string> hashFunction)
        {
            this.hashFunction = hashFunction;
        }

        public void Add(K key, V value)
        {
            var hash = hashFunction(key); //construct the real key
            keyValuePairs.Add(hash, value);
        }

        public void Delete(K key)
        {
            var hash = hashFunction(key); //get the real key
            keyValuePairs.Remove(hash);
        }

        public V Find(K key)
        {
            var hash = hashFunction(key); //get the real key
            return keyValuePairs[hash];
        }

        IEnumerator<KeyValuePair<string, V>> IEnumerable<KeyValuePair<string, V>>.GetEnumerator() 
            => keyValuePairs.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => keyValuePairs.GetEnumerator();
    }
}
