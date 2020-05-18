using System;
using System.Collections.Generic;

namespace FindAnagrams
{
    class Program
    {
        static void Main(string[] args)
        {
            // 0, 6
            foreach (int result in FindAnagrams("cbaebabacd", "abc"))
            {
                Console.WriteLine(result);
            }
            Console.WriteLine();

            // 0, 1, 2
            foreach (int result in FindAnagrams2("abab", "ab"))
            {
                Console.WriteLine(result);
            }
            Console.WriteLine();

            // 0, 6
            foreach (int result in FindAnagrams3("cbaebabacd", "abc"))
            {
                Console.WriteLine(result);
            }
            Console.WriteLine();
        }

        public static IList<int> FindAnagrams(string s, string p)
        {
            IList<int> result = new List<int>();

            int[] chars = new int[26];
            if (s == null || p == null || s.Length < p.Length)
            {
                return result;
            }

            foreach (char c in p)
            {
                chars[c - 'a']++;
            }

            int start = 0;
            int end = 0;
            int count = p.Length;

            while (end < s.Length)
            {
                if (end - start == p.Length && chars[s[start++] - 'a']++ >= 0)
                {
                    count++;
                }

                if (--chars[s[end++] - 'a'] >= 0)
                {
                    count--;
                }

                if (count == 0)
                {
                    result.Add(start);
                }
            }

            return result;
        }

        // Runtime Distribution
        public static IList<int> FindAnagrams2(string s, string p)
        {
            if (p.Length == 0 || p == null)
                return new List<int>();

            if (s.Length < p.Length)
                return new List<int>();

            int right = 0, left = 0, counter = p.Length;
            int[] index = new int[256];
            IList<int> startindices = new List<int>();

            foreach (char c in p.ToCharArray())
                index[c]++;

            while (right < s.Length)
            {
                if (index[s[right]] > 0)
                    counter--;

                index[s[right]]--;
                right++;

                while (counter == 0)
                {
                    if (right - left == p.Length)
                        startindices.Add(left);

                    index[s[left]]++;
                    if (index[s[left]] > 0)
                        counter++;
                    left++;
                }

            }

            return startindices.Count == 0 ? new List<int>() : startindices;
        }

        // Memory Distribution
        public static IList<int> FindAnagrams3(string s, string p)
        {
            IList<int> result = new List<int>();

            int[] chars = new int[26];
            if (s == null || p == null || s.Length < p.Length)
                return result;

            foreach (char c in p)
                chars[c - 'a']++;

            int start = 0, end = 0, count = p.Length;

            while (end < s.Length)
            {
                if (end - start == p.Length && chars[s[start++] - 'a']++ >= 0)
                    count++;
                if (--chars[s[end++] - 'a'] >= 0)
                    count--;
                if (count == 0)
                    result.Add(start);
            }

            return result;
        }
    }
}
