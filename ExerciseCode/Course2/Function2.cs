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
            Console.Write("solve1 :");
            var sw = new Stopwatch();
            sw.Start();

           
            
            sw.Stop();
        }

        /// <summary>
        /// DepthFirstSearch 深度優先搜尋
        /// </summary>
        /// <param name="num"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        private bool search(int num, int sum)
        {
            if (num == this.numbers.Length) return sum == this.selectedNumber;

            if (search(num + 1, sum)) return true;

            if (search(num + 1, sum + this.numbers[num])) return true ;

            return false;
         }

        public void solve2()
        {
            Console.Write("solve2 :");
            var sw = new Stopwatch();
            sw.Start();

            if (search(0, 0))
                Console.WriteLine($"{this.selectedNumber} 的和，[有]在此矩陣中 \t time:{sw.ElapsedMilliseconds}");
            else
                Console.WriteLine($"{this.selectedNumber} 的和，[不]在此矩陣中 \t time:{sw.ElapsedMilliseconds}");

            sw.Stop();
        }

        public void test()
        {
            setData(new int[] { 1, 2, 4, 7 }, 13);
            solve1();
            solve2();
        }
    }
}
