using System;
using System.Collections.Generic;
using System.Linq;

namespace GroupAnagrams
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strs = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };

            IList<IList<string>> output = new List<IList<string>>();
            
            output = GroupAnagrams(strs);

            foreach (List<string> group in output)
            {
                Console.WriteLine();
                foreach (string str in group)
                {
                    Console.WriteLine(str);
                }
            }
        }

        //My submission

        static public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            IList<IList<string>> output = new List<IList<string>>();
            List<string> anagrams = new List<string>();

            foreach (string str in strs)
            {
                char[] a = str.ToCharArray();
                Array.Sort(a);
                string anagram = new string(a);
                if (!anagrams.Contains(anagram))
                {
                    anagrams.Add(anagram);
                    List<string> group = new List<string>();
                    output.Add(group);
                }
                output[anagrams.IndexOf(anagram)].Add(str);
            }
            return output;
        }

        //



        //Runtime Distribution
        public IList<IList<string>> GroupAnagrams1(string[] strs)
        {
            var result = new List<IList<string>>();

            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

            foreach (var str in strs)
            {
                var charArr = str.ToCharArray();
                Array.Sort(charArr);
                var key = new string(charArr);

                if (dictionary.ContainsKey(key))
                {
                    dictionary[key].Add(str);
                }
                else
                {
                    dictionary[key] = new List<string> { str };
                }
            }

            foreach (var item in dictionary)
            {
                result.Add(item.Value);
            }

            return result;
        }

        public IList<IList<string>> GroupAnagrams2(string[] strs)
        {
            IList<IList<string>> list = new List<IList<string>>();
            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
            if (strs.Length == 0)
            {
                return list;
            }

            foreach (string str in strs)
            {
                //string tmp = String.Concat(str.OrderBy(c => c));
                char[] chr = str.ToCharArray();
                Array.Sort(chr);
                string tmp = new String(chr);
                if (map.ContainsKey(tmp))
                {
                    map[tmp].Add(str);
                }
                else
                {
                    List<string> lst = new List<string> { str };
                    map.Add(tmp, lst);
                }
            }
            foreach (KeyValuePair<string, List<string>> pair in map)
            {
                list.Add(pair.Value);
            }
            return list;
        }


        public IList<IList<string>> GroupAnagrams3(string[] strs)
        {
            var d = new Dictionary<string, List<string>>();

            foreach (var s in strs)
            {
                var index = Index(s);
                if (d.ContainsKey(index))
                {
                    d[index].Add(s);
                }
                else
                {
                    d[index] = new List<string> { s };
                }
            }

            var ret = new List<IList<string>>();

            foreach (var l in d.Values)
            {
                ret.Add(l);
            }

            return ret;
        }

        private string Index(string s)
        {
            var i = s.ToCharArray();
            Array.Sort(i);
            return new string(i);
        }


        public IList<IList<string>> GroupAnagrams4(string[] strs)
        {

            var result = new List<IList<string>>();
            var dic = new Dictionary<string, List<string>>();
            foreach (var str in strs)
            {
                var chars = str.ToCharArray();
                Array.Sort(chars);
                var key = new string(chars);

                if (!dic.ContainsKey(key))
                {
                    dic[key] = new List<string>();
                }
                dic[key].Add(str);

            }

            foreach (var kvp in dic)
            {
                result.Add(kvp.Value);
            }
            return result;
        }

        public IList<IList<string>> GroupAnagrams5(string[] strs)
        {
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

            foreach (string str in strs)
            {
                char[] va = str.ToCharArray();
                Array.Sort(va);
                string v = new string(va);

                if (dict.TryGetValue(v, out List<string> list))
                {
                    list.Add(str);
                }
                else
                {
                    dict.Add(v, new List<string>() { str });
                }
            }

            return dict.Values.ToList().ToArray();
        }


        //Memory Distribution
        public IList<IList<string>> GroupAnagrams11(string[] strs)
        {
            int[] array = new int[] {
            2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101
        };

            var output = new Dictionary<long, IList<string>>();

            for (int i = 0; i < strs.Length; i++)
            {

                long key = 1;
                for (int j = 0; j < strs[i].Length; j++)
                {
                    key *= array[strs[i][j] - 'a'];
                }

                if (output.ContainsKey(key))
                {
                    output[key].Add(strs[i]);
                }
                else
                {
                    output.Add(key, new List<string> { strs[i] });
                }
            }

            return output.Values.ToList();
        }

        public IList<IList<string>> GroupAnagrams12(string[] strs)
        {
            Dictionary<string, IList<string>> dict = new Dictionary<string, IList<string>>();
            foreach (string s in strs)
            {
                char[] characters = s.ToCharArray();
                Array.Sort(characters);
                string key = new String(characters);
                if (!dict.ContainsKey(key))
                {
                    dict.Add(key, new List<string>());
                }
                dict[key].Add(s);
            }
            return dict.Values.ToList();
        }

        public IList<IList<string>> GroupAnagrams13(string[] strs)
        {
            var map = new Dictionary<string, IList<string>>();

            for (int i = 0; i < strs.Length; i++)
            {
                char[] ch = strs[i].ToCharArray();
                Array.Sort(ch);
                var key = new String(ch);

                if (!map.ContainsKey(key))
                {
                    map.Add(key, new List<string>());
                }

                map[key].Add(strs[i]);
            }

            return map.Values.ToList() as List<IList<string>>;
        }

        public IList<IList<string>> GroupAnagrams14(string[] strs)
        {
            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
            List<IList<string>> result = new List<IList<string>>();
            for (int i = 0; i < strs.Length; i++)
            {
                char[] array = strs[i].ToCharArray();
                Array.Sort<char>(array);
                string ap = new string(array);
                Console.WriteLine(ap);
                if (!map.ContainsKey(ap))
                {
                    List<string> groupT = new List<string>();
                    groupT.Add(strs[i]);
                    map.Add(ap, groupT);
                }
                else
                {
                    List<string> groupT = map[ap];
                    groupT.Add(strs[i]);
                    map[ap] = groupT;
                }
            }

            foreach (KeyValuePair<string, List<string>> k in map)
            {

                List<string> list = k.Value;
                result.Add(list);
            }
            return result;
        }

        public IList<IList<string>> GroupAnagrams15(string[] strs)
        {
            Dictionary<string, List<string>> ht = new Dictionary<string, List<string>>();
            IList<IList<string>> res = new List<IList<string>>();
            for (int i = 0; i < strs.Length; i++)
            {
                var tmp = strs[i].ToCharArray();
                Array.Sort(tmp);
                var curr = new String(tmp);
                if (ht.ContainsKey(curr))
                    ht[curr].Add(strs[i]);
                else
                    ht.Add(curr, new List<string> { strs[i] });
            }
            foreach (var key in ht.Keys)
            {
                res.Add(ht[key]);
            }
            return res;

        }
    }
}
