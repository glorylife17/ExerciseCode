using ExerciseCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseCode.LeetCode
{
    class BestTimeToBuyAndSellStock_II : IFunction
    {
        public void solve1()
        {
          
        }

        private int getMaxProfit1(int[] prices, int priceSize)
        {
            if (priceSize <= 1) return 0;
            //{ 7, 1, 5, 3, 6, 4 }
            //  0  1  2  3  4  5

            
            //最後一天要不要賣?
            var max = 0;
            var profit = 0;

            //不賣 0
            //{ 7, 1, 5, 3, 6, 4 }
            //{ 7, 1, 5, 3, 6 }
            //{ 7, 1, 5, 3 }
            profit = getMaxProfit1(prices, priceSize - 1);
            if (profit > max)
            {
                max = profit;
            }

            //賣 + (4-n)
            // { 7, 1, 5, 3, 6 } + (4-6) : getMaxProfit(prices, 5) + intpus[recode-1]-intpus[4]
            // { 7, 1, 5, 3 } + (4-3)    : getMaxProfit(prices, 4) + intpus[recode-1]-intpus[3]
            // { 7, 1, 5 } + (4-5)       : getMaxProfit(prices, 3) + intpus[recode-1]-intpus[2]
            // { 7, 1 } + (4-1)          : getMaxProfit(prices, 2) + intpus[recode-1]-intpus[1]
            // { 7 } + (4-7)             : getMaxProfit(prices, 1) + intpus[recode-1]-intpus[0]
            //getMaxProfit(intpus,i+1)+intpus[recode-1]-intpus[0]

            for (int i = 1; i < priceSize; i++)
            {
                profit = getMaxProfit1(prices, i) + (prices[priceSize - 1] - prices[i - 1]);
                if(profit>max)
                {
                    max = profit;
                }
            }

            return max;
        }

        private int getMaxProfitDP(int[] prices, int days)
        {
            if (days <= 1) return 0;

            var profits = new int[days + 1];
            profits[1] = 0;

            var max = 0;
            var profit = 0;

            for (int day = 2; day <= days; day++) //取代遞迴 先計算該天發生的狀況
            {
                profit = profits[day-1];  //不賣的狀況  profits[day-1]=profits[day]
                if (profit > max)
                {
                    max = profit;
                }

                for (int i = 1; i < day; i++)
                {
                    profit = profits[i] + (prices[day - 1] - prices[i - 1]);
                    if (profit > max)
                    {
                        max = profit;
                    }
                }
                profits[day] = max;
            }

            return profits[days];
        }

        private int getMaxProfit2(int[] prices, int priceSize)
        {
            var profit = 0;
            for (int i = 0; i + 1 < priceSize; i++)
            {
                if(prices[i]<prices[i+1])
                {
                    profit += prices[i + 1] - prices[i];
                }
            }

            return profit;
        }

        public void solve2()
        {
            var inputs = new int[] { 7, 1, 5, 3, 6, 4 };
            var p1 = getMaxProfit1(inputs, inputs.Length);
            Console.WriteLine($"max profit {p1}");

            var p2= getMaxProfitDP(inputs, inputs.Length);
            Console.WriteLine($"max profit {p2}");

            var p3 = getMaxProfit2(inputs, inputs.Length);
            Console.WriteLine($"max profit {p3}");
        }

        public void test()
        {
            Console.WriteLine("LeetCode Best Time To Buy And Sell Stock II:");
            solve2();

            Console.WriteLine("");
        }
    }
}
