using System;
using System.Collections;
using System.Collections.Generic;

namespace FirstUniqChar
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "leetcode";
            //return 0.
            Console.WriteLine(FirstUniqChar(s));
            Console.WriteLine(FirstUniqChar2(s));
            Console.WriteLine(FirstUniqChar3(s));

            s = "loveleetcode";
            //return 2.
            Console.WriteLine(FirstUniqChar(s));
            Console.WriteLine(FirstUniqChar2(s));
            Console.WriteLine(FirstUniqChar3(s));
        }

        static int FirstUniqChar(string s)
        {
            Dictionary<char, int> letters = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (letters.ContainsKey(c))
                {
                    letters[c] = letters[c] + 1;
                }
                else
                {
                    letters.Add(c, 1);
                }
            }
            for (int i = 0; i < s.Length; i++)
            {
                //Console.WriteLine($"{s[i]} = {letters[s[i]]}");
                if (letters[s[i]] < 2)
                {
                    return i;
                }
            }
            return -1;
        }

        static int FirstUniqChar2(string s)
        {
            int[] letters = new int[256];
            foreach (char c in s)
            {
                letters[c]++;
            }
            for (int i = 0; i < s.Length; i++)
            {
                //Console.WriteLine($"{s[i]} = {letters[s[i]]}");
                if (letters[s[i]] == 1)
                {
                    return i;
                }
            }
            return -1;
        }

        // Runtime and Memory Distribution
        static int FirstUniqChar3(string s)
        {
            int[] freq = new int[26];
            foreach (char c in s)
            {
                freq[c - 'a']++;
            }
            for (int i = 0; i < s.Length; ++i)
            {
                if (freq[s[i] - 'a'] == 1) return i;
            }
            return -1;
        }
    }
}
