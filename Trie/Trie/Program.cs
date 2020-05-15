using System;

namespace Trie
{
    class Program
    {
        static void Main(string[] args)
        {
            Trie2 trie = new Trie2();

            trie.Insert("apple");
            Console.WriteLine(trie.Search("apple"));   // returns true
            Console.WriteLine(trie.Search("app"));     // returns false
            Console.WriteLine(trie.StartsWith("app")); // returns true
            trie.Insert("app");
            Console.WriteLine(trie.Search("app"));     // returns true
        }
    }
}
