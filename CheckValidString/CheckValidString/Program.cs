using System;
using System.Collections;
using System.Collections.Generic;

namespace CheckValidString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "()";
            Console.WriteLine(input);
            Console.WriteLine(CheckValidString0(input));
            Console.WriteLine("");

            input = "(*)";
            Console.WriteLine(input);
            Console.WriteLine(CheckValidString0(input));
            Console.WriteLine("");

            input = "(*))";
            Console.WriteLine(input);
            Console.WriteLine(CheckValidString0(input));
            Console.WriteLine("");
        }

        static bool CheckValidString(string s)
        {
            if (s == null || s == "")
            {
                return true;
            }

            Stack<char> stack = new Stack<char>();
            char top = ' ';
            foreach (char c in s)
            {
                bool anyMoreInStack = stack.TryPop(out top);

                Console.WriteLine($"switch is {c}");
                Console.WriteLine($"anyMore is {anyMoreInStack}");
                Console.WriteLine($"top is {top}");

                switch (c)
                {
                    case ' ':
                        break;
                    case ')':
                        if (top != '*')
                        {
                            if (top != '(')
                            {
                                if (!anyMoreInStack)
                                {
                                    Console.WriteLine($"returned false");
                                    return false;
                                }
                            }
                        }
                        break;
                    default:
                        Console.WriteLine($"Added {c} to stack");
                        stack.Push(c);
                        break;
                }
            }

            return true;
        }

        // Submitted this based on discussion area
        static bool CheckValidString0(string s)
        {
            int min = 0;
            int max = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    min++;
                    max++;
                }
                else if (s[i] == ')')
                {
                    min--;
                    max--;
                }
                else
                {
                    min--;
                    max++;
                }
                if (max < 0) return false;
                min = Math.Max(min, 0);
            }
            return min == 0;
        }

        //Runtime Distribution
        static bool CheckValidString1(string s)
        {
            int leftMin = 0, leftMax = 0;

            foreach (var ch in s)
            {
                if (ch == '(')
                {
                    leftMin++;
                    leftMax++;
                }
                else if (ch == ')')
                {
                    leftMin = Math.Max(leftMin - 1, 0);
                    leftMax--;

                    if (leftMax < 0) return false;
                }
                else
                {
                    leftMin = Math.Max(leftMin - 1, 0);
                    leftMax++;
                }
            }

            return leftMin == 0;
        }



    }
}
