using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable1
{
    class MyHashtable<T1, T2>
    {
        private readonly int _size;
        /// <summary>
        /// The collection of elements hashtable.
        /// </summary>
        private IEnumerable<KeyValuePair<int, List<HashTableItem<T1, T2>>>> items;

        public MyHashtable(int size)
        {
            _size = size;
            items = new List<KeyValuePair<int, List<HashTableItem<T1, T2>>>>();
        }

        /// <summary>
        /// Inserts element by the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="System.Exception">This key already in hash table!</exception>
        public void Insert(T1 key, T2 value)
        {
            var item = new HashTableItem<T1, T2>(key, value);
            var hashOfKey = GetHashCode(key.ToString());

            if (items.Any(x=> x.Key == hashOfKey))
            {
                if (items.Where(x => x.Key == hashOfKey).Any(x => x.Value.Any(y => y.Key.ToString() == key.ToString())))
                {
                    Console.WriteLine($"This key: {key} already in hash table!");
                }
                else
                {
                    items.FirstOrDefault(x => x.Key == hashOfKey).Value.Add(item);
                }

            }
            else
            {
                var newItem = new List<HashTableItem<T1, T2>> {item};
                var newElement = new KeyValuePair<int, List<HashTableItem<T1, T2>>>(hashOfKey, newItem);

                var items2 = items.ToList();
                items2.Add(newElement);
                items = items2.AsEnumerable();
            }
        }

        /// <summary>
        /// Deletes element by the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        public void Delete(T1 key)
        {
            var hashOfKey = GetHashCode(key.ToString());
            if (items.All(x => x.Key != hashOfKey))
            {
                return;
            }

            var elementByCurrentHash = items.FirstOrDefault(x => x.Key == hashOfKey).Value;

            if (elementByCurrentHash.FirstOrDefault(x => x.Key.ToString() == key.ToString()) != null)
            {
                elementByCurrentHash.Remove(elementByCurrentHash.FirstOrDefault(x => x.Key.ToString() == key.ToString()));
            }

        }

        /// <summary>
        /// Searches the element by specified key in hash table.
        /// </summary>
        /// <param name="key">The key.</param>
        public void Search(T1 key)
        {
            var hashOfKey = GetHashCode(key.ToString());
            if (items.All(x => x.Key != hashOfKey))
            {
                Console.WriteLine($"Element by key: {key} not found!");
            }

            var elementByCurrentKey = items.FirstOrDefault(x => x.Key == hashOfKey).Value.FirstOrDefault(y=>y.Key.ToString() == key.ToString());
            if (elementByCurrentKey != null)
            {
                Console.WriteLine($"Key: {elementByCurrentKey.Key} || Value: {elementByCurrentKey.Value.ToString()}");
            }
            else
            {
                Console.WriteLine($"Element by key: {key} not found!");
            }
        }

        /// <summary>
        /// Shows the full hash table.
        /// </summary>
        public void ShowHashTable()
        {
            if (items.Any())
            {
                foreach (var item in items)
                {
                    if (item.Value != null && item.Value.Any())
                    foreach (var currentItemByKey in item.Value)
                    {
                        Console.WriteLine($"Hash: {item.Key} || Key: {currentItemByKey.Key} || Value: {currentItemByKey.Value.ToString()}");
                    }
                }
            }
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        private int GetHashCode(string key)
        {
            return key.Length;
        }
    }
}
