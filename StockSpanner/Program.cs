using System;

namespace StockSpanner
{
    class Program
    {
        static void Main(string[] args)
        {
            StockSpanner1 obj1 = new StockSpanner1();

            int[] prices = new int[] { 100, 80, 60, 70, 60, 75, 85};

            // Expected 1,1,1,2,1,4,6

            foreach (int price in prices)
            {
                Console.Write($"{obj1.Next(price)} ");
            }
            Console.WriteLine();

            StockSpanner2 obj2 = new StockSpanner2();

            foreach (int price in prices)
            {
                Console.Write($"{obj2.Next(price)} ");
            }
            Console.WriteLine();

            StockSpanner3 obj3 = new StockSpanner3();

            foreach (int price in prices)
            {
                Console.Write($"{obj3.Next(price)} ");
            }
            Console.WriteLine();

            StockSpanner4 obj4 = new StockSpanner4();

            foreach (int price in prices)
            {
                Console.Write($"{obj4.Next(price)} ");
            }
            Console.WriteLine();

            StockSpanner5 obj5 = new StockSpanner5();

            foreach (int price in prices)
            {
                Console.Write($"{obj5.Next(price)} ");
            }
            Console.WriteLine();
        }
    }
}
