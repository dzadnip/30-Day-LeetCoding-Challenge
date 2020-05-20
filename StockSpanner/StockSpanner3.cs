using System;
using System.Collections.Generic;
using System.Text;

namespace StockSpanner
{
    class StockSpanner3
    {
        private LinkedList<int> positions;

        private LinkedList<int> tops;

        private int current;

        public StockSpanner3()
        {
            positions = new LinkedList<int>();
            tops = new LinkedList<int>();
            current = 0;
        }

        public int Next(int price)
        {
            while (positions.Count > 0 && tops.Last.Value <= price)
            {
                positions.RemoveLast();
                tops.RemoveLast();
            }

            int previous = -1;
            if (positions.Count > 0)
            {
                previous = positions.Last.Value;
            }

            positions.AddLast(current);
            tops.AddLast(price);

            current++;
            return current - previous - 1;
        }
    }
}
