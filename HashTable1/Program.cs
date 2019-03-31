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

            var hashTableInt = new MyHashtable<int, int>(10000);
            Random rand = new Random();
            for (var i = 0; i < 1000; i++)
            {
                hashTableInt.Insert(rand.Next(255, 10000), rand.Next(0, 1500));
            }
            Console.WriteLine("|| ***************** ||");
            Console.WriteLine("|| ***************** ||");
            hashTableInt.ShowHashTable();
            Console.ReadKey();

            HashSet<Spiders> KazanTerrarium = new HashSet<Spiders>();
            HashSet<Spiders> MoscowTerrarium = new HashSet<Spiders>();

            var spider1 = new Spiders(Suborders.Mesothelae, SpidersFamilies.Liphistiidae, Gender.Female, 20, "today");
            var spider2 = new Spiders(Suborders.Araneomorphae, SpidersFamilies.Liphistiidae, Gender.Female, 20, "today");
            var spider3_1 = new Spiders(Suborders.Mesothelae, SpidersFamilies.Liphistiidae, Gender.Female, 10, "yesterday");
            var spider4_2 = new Spiders(Suborders.Araneomorphae, SpidersFamilies.Liphistiidae, Gender.Female, 20, "yesterday");
            KazanTerrarium.Add(spider1);
            KazanTerrarium.Add(spider2);
            KazanTerrarium.Add(spider3_1);

            MoscowTerrarium.Add(spider4_2);

            Console.WriteLine("*** Kazan Terrarium ***");
            foreach (var spider in KazanTerrarium)
            {
                Console.WriteLine(spider.GetHashCode());
            }
            Console.WriteLine("*** **** ***");
            Console.ReadKey();

            KazanTerrarium.IntersectWith(MoscowTerrarium);

            Console.WriteLine("*** Kazan Terrarium ***");
            foreach (var spider in KazanTerrarium)
            {
                Console.WriteLine(spider.GetHashCode());
            }
            Console.WriteLine("*** **** ***");
            Console.ReadKey();
        }
    }
}
