using ExerciseCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseCode.LeetCode
{
    class MaximunSubarray : IFunction
    {
        public void solve1()
        {
         
        }

        private int getMaxNumber1(int[] arr)
        {
            var max = int.MinValue;
            for (int i = 0; i < arr.Length; i++)
            {
                var sum = 0;
                for (int k = i; k < arr.Length; k++)
                {
                    sum += arr[k];

                    if (sum > max)
                    {
                        max = sum;
                    }
                }
            }

            return max;
        }

        public void solve2()
        {
            var input = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            var num1 = getMaxNumber1(input);

            Console.WriteLine($"[{string.Join(", ", input)}]");
            Console.WriteLine($"max number(fun1) : {num1}");
        }

        public void test()
        {
            Console.WriteLine("LeetCode Maximun Subarray:");
            solve2();

            Console.WriteLine("");
        }
    }
}
