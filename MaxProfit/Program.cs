using System;
using System.ComponentModel.DataAnnotations;

namespace MaxProfit
{
    class Program
    {
        static void Main(string[] args)
        {
            //Best Time to Buy and Sell Stock II
            //Say you have an array for which the ith element is the price of a given stock on day i.
            //Design an algorithm to find the maximum profit. You may complete as many transactions as you like (i.e., buy one and sell one share of the stock multiple times).
            //Note: You may not engage in multiple transactions at the same time (i.e., you must sell the stock before you buy again).
            //Example 1:
            //Input: [7,1,5,3,6,4]
            //Output: 7
            //Explanation: Buy on day 2 (price = 1) and sell on day 3 (price = 5), profit = 5-1 = 4.
            //             Then buy on day 4 (price = 3) and sell on day 5 (price = 6), profit = 6-3 = 3.
            //Example 2:
            //Input: [1,2,3,4,5]
            //Output: 4
            //Explanation: Buy on day 1 (price = 1) and sell on day 5 (price = 5), profit = 5-1 = 4.
            //             Note that you cannot buy on day 1, buy on day 2 and sell them later, as you are
            //             engaging multiple transactions at the same time. You must sell before buying again.
            //Example 3:
            //Input: [7,6,4,3,1]
            //Output: 0
            //Explanation: In this case, no transaction is done, i.e. max profit = 0.


            int[][] pricesArray = new int[5][];
            pricesArray[0] = new int[] { 7, 1, 5, 3, 6, 4 };
            pricesArray[1] = new int[] { 1, 2, 3, 4, 5};
            pricesArray[2] = new int[] { 1, 2};
            pricesArray[3] = new int[] { 2, 1, 4};
            pricesArray[4] = new int[] { 6, 1, 3, 2, 4, 7};

            foreach (int[] prices in pricesArray)
            {
                Console.WriteLine($"Profit: {MaxProfit(prices)}");
            }
        }

        //Traian's linear traversal
        //add only positive differences between current element and the previous

        static int MaxProfit(int[] prices)
        {
            int mp = 0;

            for (int i = 1; i < prices.Length; i++)
            {
                int d = prices[i] - prices[i - 1];
                if (d > 0)
                {
                    mp += d;
                }
            }

            return mp;
        }


        //Runtime Distribution

        public int MaxProfit1(int[] prices)
        {
            if (prices.Length == 0) return 0;

            int puy_price = Int32.MaxValue;
            int sell_price = 0;
            int profit = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] > puy_price)
                {
                    if (prices[i] > sell_price)
                    {
                        sell_price = prices[i];
                    }
                    else
                    {
                        profit = profit + (sell_price - puy_price);
                        puy_price = prices[i];
                        sell_price = 0;
                    }

                }
                else
                {
                    if (sell_price != 0)
                    {
                        profit = profit + (sell_price - puy_price);
                        puy_price = prices[i];
                        sell_price = 0;
                    }
                    else
                    {
                        puy_price = prices[i];
                    }
                }
            }

            if (sell_price != 0)
                profit = profit + (sell_price - puy_price);

            return profit;
        }


        public int MaxProfit2(int[] prices)
        {
            if (prices.Length == 0) return 0;

            int res = 0;
            int sell = -prices[0];

            for (int i = 0; i < prices.Length; i++)
            {
                res = Math.Max(res, sell + prices[i]);
                sell = Math.Max(sell, res - prices[i]);
            }

            return res;
        }


        public int MaxProfit3(int[] prices)
        {

            if (prices.Length < 2)
                return 0;

            int Earn = 0, BuyPrice = -1, TomorrowPrice = 0;
            for (int i = 0; i < prices.Length; i++)
            {

                TomorrowPrice = (i + 1) == prices.Length ? 0 : prices[i + 1];

                if (prices[i] <= TomorrowPrice && BuyPrice == -1)
                {
                    BuyPrice = prices[i];
                }
                else if (prices[i] > TomorrowPrice && BuyPrice > -1)
                {
                    Earn += (prices[i] - BuyPrice);
                    BuyPrice = -1;
                }
            }
            return Earn;
        }


        public int MaxProfit4(int[] prices)
        {
            // Empty or null arrary
            if (prices == null || prices.Length == 0)
            {
                return 0;
            }

            int profit = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i - 1] < prices[i])
                {
                    profit = profit + prices[i] - prices[i - 1];
                }
            }
            return profit;

        }

        public int MaxProfit5(int[] prices)
        {
            int maxProfit = 0;
            int minPrice = Int32.MaxValue;
            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < minPrice)
                {
                    minPrice = prices[i];
                }

                if (prices[i] - minPrice > 0)
                {
                    maxProfit += prices[i] - minPrice;
                    minPrice = prices[i];
                }
            }

            return maxProfit;
        }


        //Memory Distribution
        public int MaxProfit11(int[] prices)
        {
            int i = 0;
            int profit = 0;
            int l = prices.Length;
            while (i < prices.Length - 1)
            {
                while (i < l - 1 && prices[i] >= prices[i + 1])
                    i++;
                int v = prices[i];
                while (i < l - 1 && prices[i] <= prices[i + 1])
                    i++;
                int p = prices[i];
                profit += p - v;
                i++;
            }
            return profit;
        }

        public int MaxProfit12(int[] prices)
        {
            var maxprofit = 0;
            for (var i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[i - 1])
                    maxprofit += prices[i] - prices[i - 1];
            }
            return maxprofit;
        }

        public int MaxProfit13(int[] prices)
        {
            if (prices.Length <= 1) return 0;
            var profit = 0;
            for (var j = 1; j < prices.Length; j++)
            {
                if (prices[j] > prices[j - 1])
                {
                    profit += prices[j] - prices[j - 1];
                }
            }

            return profit;
        }


        public int MaxProfit14(int[] prices)
        {
            var i = 0;
            var profit = 0;

            // Can't maximize for one day of data
            if (prices.Length <= 1)
            {
                return profit;
            }

            while (i < prices.Length)
            {
                var buy = 0;

                //Find local minimum
                while (i < prices.Length - 1 && prices[i] >= prices[i + 1])
                {
                    i++;
                }

                if (i == prices.Length - 1)
                    break;

                buy = i;

                //Need to step one ahead 
                i++;

                //Find local maxima (as long as prices are acending we are good to go)
                while (i < prices.Length && prices[i] >= prices[i - 1])
                {
                    i++;
                }

                profit += prices[i - 1] - prices[buy];

            }

            return profit;
        }


        public int MaxProfit15(int[] prices)
        {
            if (prices.Length == 0) return 0;
            int maxProfit = 0;
            int valley = prices[0];
            int peak = prices[0];
            int i = 0;
            while (i < prices.Length - 1)
            {
                while (i < prices.Length - 1 && prices[i] >= prices[i + 1])
                    i++;
                valley = prices[i];
                while (i < prices.Length - 1 && prices[i] <= prices[i + 1])
                    i++;
                peak = prices[i];
                maxProfit += peak - valley;
            }
            return maxProfit;
        }

        public int MaxProfit16(int[] prices)
        {
            int profit = 0;
            if (prices.Length < 2)
            {
                return 0;
            }

            for (int i = 0; i <= prices.Length - 2; i++)
            {
                if (prices[i] <= prices[i + 1])
                    profit += -(prices[i]) + prices[i + 1];
            }

            return profit;
        }

        public int MaxProfit17(int[] prices)
        {

            // buy on 1st low and then sell on 1st high [ just before start falling down]

            //what is profile if previous is lower than current. 

            int maxProfit = 0;

            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[i - 1])
                {
                    maxProfit += prices[i] - prices[i - 1];
                }
            }

            return maxProfit;
        }

    }
}
