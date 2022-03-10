using ExerciseCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseCode.LeetCode
{
    class CountingElements : IFunction
    {
        public void solve1()
        {
            
        }

        /// <summary>
        /// 條件 1=< array <= 1000
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        private int getCount1(int[] inputs)
        {
            var isFound = new bool[1002]; //
            for (int i = 0; i < inputs.Length; i++)
            {
                isFound[inputs[i]] = true;
            }

            var count = 0;
            for (int i = 0; i < inputs.Length; i++)
            {
                if (isFound[inputs[i] + 1])
                {
                    count++;
                }
            }

            return count;
        }

        private int getCount2(int[] inputs)
        {
            var count = 0;
            for (int i = 0; i < inputs.Length; i++)
            {
                for (int j = 0; j < inputs.Length; j++)
                {
                    if (inputs[i] + 1 == inputs[j])
                    {
                        count++;
                        break;
                    }
                }
            }
            return count;
        }

        public void solve2()
        {
            var inputs = new int[] {1,2,3 };
            var p1 = getCount1(inputs);
            Console.WriteLine($"Count (Fun1) :{p1}");

            var p2 = getCount2(inputs);
            Console.WriteLine($"Count (Fun2) :{p2}");
        }

        public void test()
        {
            Console.WriteLine("LeetCode Counting Elements:");
            solve2();

            Console.WriteLine("");
        }
    }
}
