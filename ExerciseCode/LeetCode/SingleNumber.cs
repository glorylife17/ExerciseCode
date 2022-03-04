using ExerciseCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseCode.LeetCode
{
    class SingleNumber : IFunction
    {
        public void solve1()
        {
            
        }

        private int getSingle(int[] param)
        {
            var v = param[0];
            for (int i = 1; i < param.Length; i++)
            {
                v ^= param[i];
            }
            return v;
        }

        public void solve2()
        {
            var v1 = getSingle(new int[] { 2, 2, 1 });
            Console.WriteLine($"[2, 2, 1] > 1: {1 == v1}");

            var v2 = getSingle(new int[] { 4, 2, 1, 2, 1 });
            Console.WriteLine($"[4, 2, 1, 2, 1] > 4: {4 == v2}");
        }

        public void test()
        {
            Console.WriteLine("LeetCode Single Number:");
            solve2();

            Console.WriteLine();
        }
    }
}
