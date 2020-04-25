using System;

namespace LRUCache
{
    class Program
    {
        static void Main(string[] args)
        {
            LRUCache cache = new LRUCache(2);
            Console.WriteLine("null");

            cache.Put(1, 1);
            Console.WriteLine("null");

            cache.Put(2, 2);
            Console.WriteLine("null");

            // 1
            Console.WriteLine(cache.Get(1));

            cache.Put(3, 3);
            Console.WriteLine("null");

            // -1
            Console.WriteLine(cache.Get(2));

            cache.Put(4, 4);
            Console.WriteLine("null");

            // -1
            Console.WriteLine(cache.Get(1));

            // 3
            Console.WriteLine(cache.Get(3));

            // 4
            Console.WriteLine(cache.Get(4));


            Console.WriteLine("");

            cache = new LRUCache(2);
            Console.WriteLine("null");

            // -1
            Console.WriteLine(cache.Get(2));

            cache.Put(2, 6);
            Console.WriteLine("null");

            // -1
            Console.WriteLine(cache.Get(1));

            cache.Put(1, 5);
            Console.WriteLine("null");

            cache.Put(1, 2);
            Console.WriteLine("null");

            // 2
            Console.WriteLine(cache.Get(1));

            // 6
            Console.WriteLine(cache.Get(2));



            Console.WriteLine("");

            cache = new LRUCache(2);
            Console.WriteLine("null");

            cache.Put(2, 1);
            Console.WriteLine("null");

            cache.Put(1, 1);
            Console.WriteLine("null");

            cache.Put(2, 3);
            Console.WriteLine("null");

            cache.Put(4, 1);
            Console.WriteLine("null");

            // -1
            Console.WriteLine(cache.Get(1));

            // 3
            Console.WriteLine(cache.Get(2));
        }
    }
}
