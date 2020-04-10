using System;
using System.Collections.Generic;
using System.Text;

namespace BackspaceCompare
{
    class Program
    {
        static void Main(string[] args)
        {
            string S = "ab#c";
            string T = "ad#c";
            //true
            Console.WriteLine($"{S} and {T} are {BackspaceCompare(S, T)}");

            S = "ab##";
            T = "c#d#";
            //true
            Console.WriteLine($"{S} and {T} are {BackspaceCompare(S, T)}");

            S = "a##c";
            T = "#a#c";
            //true
            Console.WriteLine($"{S} and {T} are {BackspaceCompare(S, T)}");

            S = "a#c";
            T = "b";
            //false
            Console.WriteLine($"{S} and {T} are {BackspaceCompare(S, T)}");
        }

        //My submission
        static bool BackspaceCompare(string S, string T)
        {
            return ApplyBackspace(S) == ApplyBackspace(T) ? true : false;
        }

        static string ApplyBackspace(string S)
        {
            int counter = 0;
            while (counter != S.Length)
            {
                if (S[counter] == '#')
                {
                    if (counter != 0)
                    {
                        S = S.Remove(counter - 1, 2);
                        counter--;
                    } else if (counter == 0)
                    {
                        S = S.Remove(counter, 1);
                    }
                } else
                {
                    counter++;
                }
            }
            return S;
        }
        //


        // Runtime Distribuion
        public bool BackspaceCompare1(string S, string T)
        {
            string str1 = GetString(S);
            string str2 = GetString(T);

            Console.WriteLine(str1);
            Console.WriteLine(str2);

            if (str1 == str2)
            {
                return true;
            }
            return false;
        }

        public string GetString(string str)
        {
            Stack<char> stack = new Stack<char>();
            foreach (var c in str)
            {
                if (c == '#')
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                }
                else
                {
                    stack.Push(c);
                }
            }

            StringBuilder sb = new StringBuilder();
            while (stack.Count > 0)
            {
                sb.Append(stack.Pop());
            }

            return sb.ToString();
        }


        public bool BackspaceCompare2(string s, string t)
        {
            int i = s.Length - 1, j = t.Length - 1;
            while (true)
            {
                i = getPrevious(s, i);
                j = getPrevious(t, j);
                if (i < 0 && j < 0)
                {
                    return true;
                }

                if (i < 0 || j < 0)
                {
                    return false;
                }

                if (s[i] != t[j])
                {
                    return false;
                }

                i--; j--;
            }

            return true;
        }

        public int getPrevious(string s, int i)
        {
            int prev = i;
            while (i >= 0 && (s[i] == '#' || prev < i))
            {
                if (s[i] == '#')
                {
                    prev -= 2;
                }
                i--;
            }

            return i;
        }




        public bool BackspaceCompare3(string S, string T)
        {
            if (S == null && T == null) return true;
            if (S == null || T == null) return false;

            var sList = ProcessCharacters(S);
            var tList = ProcessCharacters(T);

            if (sList.Count != tList.Count)
            {
                return false;
            }

            for (int i = 0; i < sList.Count; i++)
            {
                if (sList[i] != tList[i])
                {
                    return false;
                }
            }

            return true;
        }

        List<char> ProcessCharacters(string s)
        {
            var list = new List<char>();

            foreach (var c in s)
            {
                if (c == '#')
                {
                    if (list.Count > 0)
                    {
                        list.RemoveAt(list.Count - 1);
                    }
                }
                else
                {
                    list.Add(c);
                }
            }

            return list;
        }


        public bool BackspaceCompare4(string S, string T)
        {
            var sIdx = S.Length - 1;
            var tIdx = T.Length - 1;

            var sBack = 0;
            var tBack = 0;
            while (sIdx >= 0 || tIdx >= 0)
            {
                if (sIdx >= 0 && S[sIdx] == '#')
                {
                    sBack++;
                    sIdx--;
                }
                else if (tIdx >= 0 && T[tIdx] == '#')
                {
                    tBack++;
                    tIdx--;
                }
                else if (sIdx >= 0 && sBack > 0)
                {
                    sBack--;
                    sIdx--;
                }
                else if (tIdx >= 0 && tBack > 0)
                {
                    tBack--;
                    tIdx--;
                }
                else
                {
                    if (sIdx < 0 || tIdx < 0 || S[sIdx] != T[tIdx])
                    {
                        return false;
                    }

                    sIdx--;
                    tIdx--;
                }
            }

            return sIdx < 0 && tIdx < 0;
        }



        // Memory Distribution

        public bool BackspaceCompare11(string s1, string s2)
        {
            int p1 = s1.Length - 1;
            int p2 = s2.Length - 1;
            int b1 = 0, b2 = 0;
            while (p1 >= 0 || p2 >= 0)
            {
                while (p1 >= 0 && (s1[p1] == '#' || b1 > 0))
                {
                    if (s1[p1] == '#')
                        ++b1;
                    else
                        --b1;
                    --p1;
                }

                while (p2 >= 0 && (s2[p2] == '#' || b2 > 0))
                {
                    if (s2[p2] == '#')
                        ++b2;
                    else
                        --b2;
                    --p2;
                }

                if (p1 < 0 && p2 >= 0 || p1 >= 0 && p2 < 0)
                    return false;
                if (p1 >= 0 && p2 >= 0 && s1[p1] != s2[p2])
                    return false;
                --p1;
                --p2;
            }

            return p1 < 0 && p2 < 0;
        }
    }
}
