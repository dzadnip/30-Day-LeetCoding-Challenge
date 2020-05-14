using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RemoveKdigits
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input: num = "1432219", k = 3
            //Output: "1219"
            Console.WriteLine(RemoveKdigits("1432219", 3));

            //Input: num = "10200", k = 1
            //Output: "200"
            Console.WriteLine(RemoveKdigits("10200", 1));

            //Input: num = "10", k = 2
            //Output: "0"
            Console.WriteLine(RemoveKdigits("10", 2));

        }

        // Copied solution from discusison area
        public static string RemoveKdigits(string num, int k)
        {
            var list = new LinkedList<char>(num);
            var node = list.First;
            while (node != null && k-- > 0)
            {
                while (node.Next != null && node.Value <= node.Next.Value)
                {
                    node = node.Next;
                }
                var prev = node.Previous;
                list.Remove(node);
                node = prev ?? list.First;
            }
            while (list.Count > 1 && list.First.Value == '0') list.Remove(list.First);
            if (list.Count == 0) list.AddFirst('0');
            return string.Join("", list);
        }

        // Runtime Distribution
        public static string RemoveKdigits2(string num, int k)
        {
            if (k >= num.Length)
            {
                return "0";
            }
            Stack<char> stack = new Stack<char>();
            int index = 0;
            while (index < num.Length)
            {
                while (k > 0 && stack.Count > 0 && stack.Peek() > num[index])
                {
                    stack.Pop();
                    k--;
                }
                stack.Push(num[index]);
                index++;
            }
            while (k > 0)
            {
                stack.Pop();
                k--;
            }
            StringBuilder sb = new StringBuilder();
            while (stack.Count > 0)
            {
                sb.Append(stack.Pop());
            }
            var chars = sb.ToString().ToCharArray();
            Array.Reverse(chars);
            string result = new string(chars).TrimStart('0');
            if (result != "")
            {
                return result;
            }
            else
            {
                return "0";
            }
        }

        public static string RemoveKdigits3(string num, int k)
        {
            if (k == 0) return num;
            if (k == num.Length) return "0";
            Stack<char> stc = new Stack<char>();
            int i = 0;
            while (i < num.Length)
            {
                while (k > 0 && stc.Count() != 0 && stc.Peek() > num[i])
                {
                    k--;
                    stc.Pop();
                }
                stc.Push(num[i]);
                i++;
            }

            while (k > 0 && stc.Count() > 0)
            {
                stc.Pop();
                k--;
            }


            if (stc.Count() == 0)
                return "0";

            StringBuilder sb = new StringBuilder();
            while (stc.Count() > 0)
            {
                sb.Append(stc.Pop());
            }
            StringBuilder sb1 = new StringBuilder();
            var len = sb.Length - 1;
            while (len >= 0)
            {
                sb1.Append(sb[len]);
                len--;
            }
            while (sb1.Length > 1 && sb1[0] == '0')
                sb1.Remove(0, 1);

            return sb1.ToString();
        }

        // Memory Distribution

        public static string RemoveKdigits4(string num, int k)
        {
            if (k >= num.Length) return "0";
            for (int j = 0; j < k; j++)
            {
                bool hasremoved = false;
                for (int i = 0; i < num.Length - 1; i++)
                {
                    if (num[i] > num[i + 1])
                    {
                        num = num.Remove(i, 1);
                        hasremoved = true;
                        break;
                    }
                }
                if (!hasremoved) num = num.Remove(num.Length - 1);
            }

            //remove leading 0
            while (num != "0" && num[0] == '0') num = num.Remove(0, 1);

            return num;
        }
    }
}
