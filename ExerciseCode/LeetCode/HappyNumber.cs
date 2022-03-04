using ExerciseCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseCode.LeetCode
{
    class HappyNumber : IFunction
    {
        // 19
        // 1*1 + 9*9 = 82
        // 8*8 + 2*2 = 68
        // 6*6 + 8*8 = 100
        // 1*1 + 0*0 + 0*0 = 1

        public void solve1()
        {
        }

        public void solve2()
        {
            var v1 = isHappy(19);
            Console.WriteLine($"19 happy:{v1}");

            var v2 = isHappy(20);
            Console.WriteLine($"20 happy:{v2}");
        }

        public void test()
        {
            Console.WriteLine("LeetCode Happy Number:");
            solve2();

            Console.WriteLine("");
        }

        private bool isHappy(int n)
        {
            var slow = n;
            var fast = n;

            do
            {
                slow = next_N(slow);
                fast = next_N(next_N(fast));
            } while (slow != fast);

            return slow == 1;
        }

        private int next_N(int n)
        {
            var res = 0;

            while (n != 0)
            {
                var d = n % 10;
                res += d * d;
                n = n / 10;
            }
            return res;
        }
    }
}
