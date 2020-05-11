using System;
using System.Collections.Generic;
using System.Text;

namespace FindJudge
{
    public class Solution
    {
        // This solution does not pass all tests
        public int FindJudge(int N, int[][] trust)
        {
            List<int> trusted = new List<int>();
            List<int> trusts = new List<int>();
            for (int i = 0; i < trust.Length; i++)
            {
                if (!trusts.Contains(trust[i][0]))
                {
                    trusts.Add(trust[i][0]);
                }
                if (!trusted.Contains(trust[i][1]))
                {
                    trusted.Add(trust[i][1]);
                }
            }

            for (int i = 0; i < trusted.Count; i++)
            {

                if (!trusts.Contains(trusted[i]))
                {
                    return trusted[i];
                }
            }

            return -1;
        }

        // Although this solution worked, it was 3 times slower than the fastest solution
        public int FindJudge2(int N, int[][] trust)
        {
            Dictionary<int, int> trusted = new Dictionary<int, int>();
            List<int> trusts = new List<int>();

            for (int i = 0; i < trust.Length; i++)
            {
                if (!trusts.Contains(trust[i][0]))
                {
                    trusts.Add(trust[i][0]);
                }

                if (trusted.ContainsKey(trust[i][1]))
                {
                    trusted[trust[i][1]] = trusted[trust[i][1]] + 1;
                }
                else
                {
                    trusted.Add(trust[i][1], 1);
                }
            }

            if (trusted.ContainsValue(N - 1))
            {
                foreach (KeyValuePair<int, int> pair in trusted)
                {
                    if (pair.Value == N - 1)
                    {
                        if (!trusts.Contains(pair.Key))
                        {
                            return pair.Key;
                        }
                    }
                }
            }

            return -1;
        }

        // Runtime Distribution
        public int FindJudge3(int N, int[][] trust)
        {
            if (trust == null || trust.Length == 0 || trust[0] == null || trust[0].Length == 0)
            {
                if (N == 1)
                    return 1;
                else
                    return -1;
            }
            HashSet<int> hash = new HashSet<int>();
            int[] peopleWhoTrust = new int[N];
            int judge = -1;
            int cnt = 0;
            for (int i = 0; i < trust.Length; i++)
            {
                peopleWhoTrust[trust[i][0] - 1]++;
            }

            for (int i = 0; i < N; i++)
            {
                if (peopleWhoTrust[i] == 0)
                {
                    judge = i + 1;
                    cnt++;
                }
            }

            if (cnt > 1 || judge == -1)
                return -1;

            for (int i = 0; i < trust.Length; i++)
            {
                if (trust[i][1] == judge)
                    hash.Add(trust[i][0]);
            }

            return hash.Count == N - 1 ? judge : -1;
        }

        public int FindJudge4(int N, int[][] trust)
        {
            if (trust.Length == 0)
                return N;
            int[] dic = new int[N + 1];
            HashSet<int> hs = new HashSet<int>();
            bool flag = false;
            int index = -1;
            for (int i = 0; i < trust.Length; i++)
            {
                hs.Add(trust[i][0]);
                dic[trust[i][1]]++;
                if (dic[trust[i][1]] == N - 1)
                {
                    flag = true;
                    index = trust[i][1];
                }

            }
            if (flag && !hs.Contains(index))
                return index;
            return -1;
        }

        public int FindJudge5(int N, int[][] trust)
        {

            int[] count = new int[N + 1];

            for (int i = 0; i < trust.Length; i++)
            {
                count[trust[i][0]]--;
                count[trust[i][1]]++;
            }

            for (int i = 1; i <= N; i++)
            {
                if (count[i] == N - 1)
                {
                    return i;
                }
            }

            return -1;
        }

        // Memory Distribution

        public int FindJudge6(int N, int[][] trust)
        {
            if (N == 1) return 1;
            List<int> people = new List<int>();
            Dictionary<int, int> trusted = new Dictionary<int, int>();

            for (int i = 0; i < trust.Length; i++)
            {
                int person = trust[i][0];
                int trusts = trust[i][1];

                if (!people.Contains(person))
                {
                    people.Add(person);
                }

                if (!trusted.ContainsKey(trusts))
                {
                    trusted.Add(trusts, 1);
                }
                else
                {
                    trusted[trusts] += 1;
                }
            }
            int result = -1;
            foreach (int person in people)
            {
                if (trusted.ContainsKey(person))
                {
                    trusted.Remove(person);
                }
            }

            foreach (KeyValuePair<int, int> entry in trusted)
            {
                if (entry.Value == N - 1)
                {
                    result = entry.Key;
                    break;
                }
            }

            return result;
        }
    }
}
