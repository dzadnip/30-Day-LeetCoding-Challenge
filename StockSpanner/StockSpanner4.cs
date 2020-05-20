using System;
using System.Collections.Generic;
using System.Text;

namespace StockSpanner
{
    class StockSpanner4
    {
        Stack<(int p, int c)> s;

        public StockSpanner4()
        {
            s = new Stack<(int p, int c)>();
        }

        public int Next(int price)
        {
            int count = 1;
            while (s.Count > 0 && price >= s.Peek().p) count += s.Pop().c;
            s.Push((price, count));
            return count;
        }
    }
}
