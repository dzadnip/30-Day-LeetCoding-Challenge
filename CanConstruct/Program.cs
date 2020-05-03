using System;
using System.Collections.Generic;

namespace CanConstruct
{
    class Program
    {
        static void Main(string[] args)
        {
            string ransomNote = "ace";
            string magazine = "abcd";
            Console.WriteLine(CanConstruct(ransomNote, magazine));

            ransomNote = "ac";
            magazine = "abcd";
            Console.WriteLine(CanConstruct(ransomNote, magazine));
        }

        // My submission 
        public static bool CanConstruct(string ransomNote, string magazine)
        {
            List<char> magazineList = new List<char>();
            foreach (char c in magazine)
            {
                magazineList.Add(c);
            }

            foreach (char c in ransomNote)
            {
                if(magazineList.Contains(c))
                {
                    magazineList.Remove(c);
                } else
                {
                    return false;
                }
            }
            return true;
        }

        // Runtime Distribution

        public static bool CanConstruct2(string ransomNote, string magazine)
        {
            if (ransomNote.Length > magazine.Length) return false;
            var letters = new int[('z' - 'a') + 1];

            foreach (char c in magazine) { letters[c - 'a']++; }

            foreach (char c in ransomNote)
            {
                if (letters[c - 'a']-- <= 0) return false;
            }

            return true;
        }

        public static bool CanConstruct3(string ransomNote, string magazine)
        {
            var availableChars = new Dictionary<char, int>();
            foreach (char c in magazine)
            {
                if (!availableChars.ContainsKey(c))
                    availableChars[c] = 0;
                availableChars[c]++;
            }

            foreach (char c in ransomNote)
            {
                if (!availableChars.ContainsKey(c) || availableChars[c] < 1)
                    return false;
                availableChars[c]--;
            }
            return true;
        }

    }
}
