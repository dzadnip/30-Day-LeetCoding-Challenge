using System;
using System.Collections.Generic;
using System.Linq;

namespace MinStack
{
    class Program
    {
        static void Main(string[] args)
        {
            MinStack obj = new MinStack();
            obj.Push(-2);
            obj.Push(0);
            obj.Push(-3);
            Console.WriteLine(obj.GetMin()); //-3
            obj.Pop();
            Console.WriteLine(obj.Top()); // 0
            Console.WriteLine(obj.GetMin()); // -2

        }
    }

    // My submission
    public class MinStack
    {

        /** initialize your data structure here. */
        List<int> elements = new List<int>();
        int min = Int32.MaxValue;

        public MinStack()
        {

        }

        public void Push(int x)
        {
            elements.Add(x);
            min = elements[0];
            foreach (int element in elements)
            {
                if (min > element)
                {
                    min = element;
                }
            }
        }

        public void Pop()
        {
            if (elements.Count > 0)
            {
                elements.RemoveAt(elements.Count - 1);
                if (elements.Count > 0)
                {
                    min = elements[0];
                    foreach (int element in elements)
                    {
                        if (min > element)
                        {
                            min = element;
                        }
                    }
                }
            }
        }

        public int Top()
        {
            return elements[elements.Count - 1];
        }

        public int GetMin()
        {
            return min;
        }
    }

    // Runtime Distribution
    public class MinStack2
    {

        /** initialize your data structure here. */
        Stack<int> minStack, valStack;
        public MinStack2()
        {
            this.minStack = new Stack<int>();
            this.valStack = new Stack<int>();
        }

        public void Push(int x)
        {
            if (minStack.Any())
            {
                int y = minStack.Peek();
                if (x < y)
                    minStack.Push(x);
                else
                    minStack.Push(y);
            }
            else
            {
                minStack.Push(x);
            }
            valStack.Push(x);
        }

        public void Pop()
        {
            if (valStack.Any())
                valStack.Pop();
            if (minStack.Any())
                minStack.Pop();
        }

        public int Top()
        {
            if (valStack.Any())
                return valStack.Peek();
            else
                return -1;
        }

        public int GetMin()
        {
            if (minStack.Any())
                return minStack.Peek();
            else
                return -1;
        }
    }

    public class MinStack3
    {
        Stack<int> stack1, stack2;

        /** initialize your data structure here. */
        public MinStack3()
        {
            stack1 = new Stack<int>();
            stack2 = new Stack<int>();
        }

        public void Push(int x)
        {
            stack1.Push(x);
            if (stack2.Count == 0)
            {
                stack2.Push(x);
            }
            else if (x <= stack2.Peek())
            {
                stack2.Push(x);
            }
        }

        public void Pop()
        {
            if (stack1.Count != 0)
            {
                if (stack2.Peek() == stack1.Pop())
                {
                    stack2.Pop();
                }
            }
        }

        public int Top()
        {
            return stack1.Peek();
        }

        public int GetMin()
        {
            return stack2.Peek();
        }
    }

    // My favorite 
    public class MinStack4
    {
        List<int> stack;

        /** initialize your data structure here. */
        public MinStack4()
        {
            this.stack = new List<int>();
        }

        public void Push(int x)
        {
            this.stack.Add(x);
        }

        public void Pop()
        {
            this.stack.RemoveAt(stack.Count - 1);
        }

        public int Top()
        {
            return this.stack.Last();
        }

        public int GetMin()
        {
            return this.stack.Min();
        }
    }
}
