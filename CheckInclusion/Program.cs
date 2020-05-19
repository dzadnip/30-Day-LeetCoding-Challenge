using System;

namespace CheckInclusion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CheckInclusion("ab", "eidbaooo"));
            Console.WriteLine(CheckInclusion("ab", "eidboaoo"));

            Console.WriteLine(CheckInclusion2("ab", "eidbaooo"));
            Console.WriteLine(CheckInclusion2("ab", "eidboaoo"));

            Console.WriteLine(CheckInclusion3("ab", "eidbaooo"));
            Console.WriteLine(CheckInclusion3("ab", "eidboaoo"));
        }

        // Copied from discussion area

        public static bool CheckInclusion(string s1, string s2)
        {
            int[] dic = new int[26];
            int i = 0;
            int j = 0;
            int count = 0;
            string ans = string.Empty;
            for (int k = 0; k < s1.Length; k++)
            {
                dic[s1[k] - 'a']++;
            }

            while (j < s2.Length)
            {
                dic[s2[j] - 'a']--;

                if (dic[s2[j] - 'a'] >= 0)
                {
                    count++;
                }

                while (count == s1.Length)
                {
                    int val = j - i + 1;

                    if (s1.Length == val)
                    {
                        return true;
                    }

                    dic[s2[i] - 'a']++;

                    if (dic[s2[i] - 'a'] > 0)
                    {
                        count--;
                    }

                    i++;
                }

                j++;
            }

            return false;
        }

        // Runtime Distribution
        public static bool CheckInclusion2(string s1, string s2)
        {
            int[] charmap = new int[128];
            foreach (char c in s1)
            {
                charmap[c]++;
            }

            int left = 0, right = 0;
            int cnt = s1.Length;

            while (right < s2.Length)
            {
                char c = s2[right];
                charmap[c]--;
                if (charmap[c] >= 0)
                {
                    cnt--;
                }

                while (cnt == 0)
                {
                    if (right - left + 1 == s1.Length)
                    {
                        return true;
                    }
                    charmap[s2[left]]++;
                    if (charmap[s2[left]] > 0)
                    {
                        cnt++;
                    }
                    left++;
                }

                right++;
            }
            return false;
        }

        public static bool CheckInclusion3(string s1, string s2)
        {
            if (s2.Length < s1.Length)
            {
                return false;
            }
            int[] s1Arr = new int[26];
            int[] s2Arr = new int[26];
            int s1Len = s1.Length;
            for (int i = 0; i < s1Len; i++)
            {
                s1Arr[s1[i] - 'a']++;
                s2Arr[s2[i] - 'a']++;
            }
            for (int i = 0; i < s2.Length - s1Len; i++)
            {
                if (CheckEquality3(s1Arr, s2Arr)) return true;
                s2Arr[s2[i] - 'a']--;
                s2Arr[s2[i + s1Len] - 'a']++;
            }

            return CheckEquality3(s1Arr, s2Arr);
        }

        private static bool CheckEquality3(int[] arr1, int[] arr2)
        {
            for (int i = 0; i < 26; i++)
            {
                if (arr1[i] != arr2[i]) return false;
            }
            return true;
        }
    }
}
