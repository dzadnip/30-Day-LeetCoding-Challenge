using System;
using System.Collections.Generic;
using System.Text;

namespace StockSpanner
{
    class StockSpanner1
    {
        List<(int price, int days)> stocks;

        public StockSpanner1()
        {
            stocks = new List<(int price, int days)>();
        }

        public int Next(int price)
        {
            int count = 1;
            int index = stocks.Count - 1;

            while (index >= 0 && stocks[index].price <= price)
            {
                count += stocks[index].days;
                index -= stocks[index].days;
            }

            stocks.Add((price, count));
            return count;
        }
    }
}
