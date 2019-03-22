using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable1
{
    /// <summary>
    /// Special item for MyHashTable
    /// </summary>
    class HashTableItem<T1, T2>
    {
        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        public T1 Key { get; private set; }
        /// <summary>
        /// Gets the value of item.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public T2 Value { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HashTableItem{T}"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="System.ArgumentException">
        /// </exception>
        public HashTableItem (T1 key, T2 value)
        {
            if (string.IsNullOrEmpty(key.ToString()))
            {
               throw new ArgumentException(key.ToString());
            }

            if (value == null) 
            {
                throw new ArgumentException(value.ToString());
            }

            Key = key;
            Value = value;
        }
    }
}
