using System;
using System.Collections.Generic;
using System.Text;

namespace StockSpanner
{
    class StockSpanner5
    {
        private Stack<Tuple<int, int>> stack;

        public StockSpanner5()
        {
            stack = new Stack<Tuple<int, int>>();
        }

        public int Next(int price)
        {
            int span = 1;
            while (stack.Count > 0 && stack.Peek().Item1 <= price)
            {
                span += stack.Pop().Item2;
            }

            stack.Push(new Tuple<int, int>(price, span));
            return span;
        }
    }
}
