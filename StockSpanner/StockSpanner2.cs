using System;
using System.Collections.Generic;
using System.Text;

namespace StockSpanner
{
    class StockSpanner2
    {
        Stack<Stock> stack;
        public StockSpanner2()
        {
            stack = new Stack<Stock>();
        }

        public int Next(int price)
        {
            Stock stock = new Stock(price, 1);

            while (stack.Count > 0 && stack.Peek().price <= stock.price)
            {
                stock.count += stack.Pop().count;
            }

            stack.Push(stock);

            return stock.count;
        }
    }

    public class Stock
    {
        public int price;
        public int count;

        public Stock(int price, int count)
        {
            this.price = price;
            this.count = count;
        }
    }
}
