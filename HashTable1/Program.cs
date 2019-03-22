using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable1
{
    class Program
    {
        static void Main(string[] args)
        {
            var hashTable = new MyHashtable<string, string>(255);
            hashTable.Insert("123", "don kihot?");
            hashTable.Insert("126", "don kihot22?");
            hashTable.Insert("126", "don kihot22?");
            hashTable.Insert("1224", "ahhahaha?");
            hashTable.Insert("Alice", "Why not?");
            hashTable.Insert("Mr.Peterson, wtf a u doing?", "lololoolol");
            Console.WriteLine("|| seacrh 2 elements ||");
            hashTable.Search("123");
            hashTable.Search("126");
            Console.WriteLine("|| ***************** ||");
            hashTable.ShowHashTable();
            hashTable.Delete("126");
            Console.WriteLine("|| after delete 1 element ||");
            hashTable.ShowHashTable();

            var hashTableInt = new MyHashtable<int, int>(255);
            Random rand = new Random();
            for (var i = 0; i < 10000; i++)
            {
                hashTableInt.Insert(rand.Next(255, 10001), rand.Next(0, 1500));
            }
            Console.WriteLine("|| ***************** ||");
            Console.WriteLine("|| ***************** ||");
            hashTableInt.ShowHashTable();
            Console.ReadKey();

        }
    }
}
