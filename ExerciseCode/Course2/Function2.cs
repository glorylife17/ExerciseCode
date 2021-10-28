using ExerciseCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ExerciseCode.Course2
{
    /// <summary>
    /// 給定整數a1、a2、.......an，判斷是否可以從中選出若干數，使它們的和恰好為k。
    /// </summary>
    class Function2 : IFunction
    {
        private int[] numbers;
        private int selectedNumber;

        /// <summary>
        /// 設定參數
        /// </summary>
        /// <param name="numbers">一堆給定數字</param>
        /// <param name="selectdNumber">被選定的數字</param>
        public void setData(int[] numbers, int selectdNumber)
        {
            this.numbers = numbers;
            this.selectedNumber = selectdNumber;
        }

        public void solve1()
        {
            Console.Write("solve1 :\n");
            var sw = new Stopwatch();
            sw.Start();

            addValue(0, 0);
            
            sw.Stop();
        }

        private int addValue(int num, int sum)
        {
            if (num >= this.numbers.Length) return 0;

            var ans = this.numbers[num];
            for (int i = num; i < this.numbers.Length; i++)
            {
                if (i + 1 < this.numbers.Length)
                    ans += addValue(i + 1, ans);
                Console.WriteLine($"n:[{num}] i:{i}  => {this.numbers[i]}");
            }

            return sum + ans;
         }

        public void solve2()
        {
           
        }

        public void test()
        {
            setData(new int[] { 1, 2, 4, 7 }, 13);
            solve1();
        }
    }
}
