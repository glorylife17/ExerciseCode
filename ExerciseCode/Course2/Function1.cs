using ExerciseCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ExerciseCode.Course2
{
    /// <summary>
    /// 費氏數列(費波那契數列)
    /// </summary>
    class Function1 : IFunction
    {
        public void solve1()
        {
            throw new NotImplementedException();
        }

        public void solve2()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 費氏數列(費波那契數列)
        /// </summary>
        /// <param name="n">位數</param>
        /// <returns></returns>
        private int Fibonacci(int n)
        {
            if (n <= 1) return 1;
            return  Fibonacci(n-1) + Fibonacci(n - 2);
        }

        /// <summary>
        /// 正整數的階乘
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private int Factorial(int n)
        {
            if (n <= 1) return 1;
            return n * Factorial(n - 1);
        }

        public void test()
        {
            Console.WriteLine("費氏數列:");
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"n:{i}  Fn={Fibonacci(i)}");
            }

            Console.WriteLine("");

            Console.WriteLine("正整數的階乘:");
            for (int i = 0; i <6; i++)
            {
                Console.WriteLine($"n:{i}  Fn={Factorial(i)}");
            }
        }
    }
}
