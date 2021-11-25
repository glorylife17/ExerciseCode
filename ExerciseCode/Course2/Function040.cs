using ExerciseCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ExerciseCode.Course2
{
    /// <summary>
    /// 硬幣問題
    /// 現有硬幣六種，分別為1元、5元、10元、20元、50元、100元，
    /// 假設每種硬幣數量均無限多，
    /// 問用它們來湊夠N元有多少種組合方式。
    /// </summary>
    class Function040 : IFunction
    {
        private List<Coin> coins;
        private int pay;

        private void setData()
        {
            this.coins = new List<Coin>
            {
                new Coin{ denomination=500, ownerNumber=2, useNumber=0 },
                new Coin{ denomination=100, ownerNumber=0, useNumber=0 },
                new Coin{ denomination=50, ownerNumber=3, useNumber=0 },
                new Coin{ denomination=10, ownerNumber=1, useNumber=0 },
                new Coin{ denomination=5, ownerNumber=2, useNumber=0 },
                new Coin{ denomination=1, ownerNumber=3, useNumber=0 },
            };

            this.pay = 620;
        }

        public void solve1()
        {
            Console.Write("solve1 :");

            var sw = new Stopwatch();
            sw.Start();

            var amountMoney = this.pay;
            this.coins = this.coins.OrderByDescending(x => x.denomination).ToList();
            foreach (var coin in this.coins)
            {
                if (coin.ownerNumber == 0) continue;
                var needNumber = amountMoney / coin.denomination;

                coin.useNumber = (needNumber - coin.ownerNumber) > 0 ? coin.ownerNumber : needNumber;
                amountMoney = amountMoney - (coin.denomination * coin.useNumber);
            }

            sw.Stop();

            print();
            Console.WriteLine($"time:{sw.ElapsedMilliseconds}");
        }

        public void solve2()
        {
            Console.Write("solve2 :");
            var sw = new Stopwatch();
            sw.Start();

            var amountMoney = this.pay;
            foreach (var coin in this.coins)
            {
                coin.useNumber = Math.Min(amountMoney / coin.denomination, coin.ownerNumber);
                amountMoney -= coin.denomination * coin.useNumber;
            }

            sw.Stop();
            
            print();
            Console.WriteLine($"time:{sw.ElapsedMilliseconds}");
        }

        private void print()
        {
            var useCoins = this.coins.Where(x => x.useNumber > 0).Select(x => $"{x.denomination} 元 x {x.useNumber}").ToArray();
            var spendMoney = this.coins.Where(x => x.useNumber > 0).Select(x => x.denomination * x.useNumber).Sum();
            Console.WriteLine();
            Console.WriteLine($"定價:{this.pay} 可用金額:{spendMoney} 尚須:{this.pay- spendMoney}");
            Console.WriteLine($"可用硬幣: {string.Join(", ", useCoins)}");
           
        }

        public void test()
        {
            setData();

            solve1();
            Console.WriteLine();
            solve2();
        }
    }

    class Coin
    {
        /// <summary>
        /// 面額
        /// </summary>
        public int denomination { get; set; }

        /// <summary>
        /// 擁有的數量
        /// </summary>
        public int ownerNumber { get; set; }

        /// <summary>
        /// 使用的數量
        /// </summary>
        public int useNumber { get; set; }
    }
}
