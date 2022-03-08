using ExerciseCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseCode.LeetCode
{
    class Decimal10To7 : IFunction
    {
        public void solve1()
        {
            throw new NotImplementedException();
        }

        public void solve2()
        {
            Console.WriteLine(getDecimal7(100));
            Console.WriteLine(getDecimal7(-7));
        }

        private string getDecimal7(int value)
        {
            var n = "";
            var decimalVal = 7;
            var decimalWord = "";

            if (value < 0)
            {
                value = -1 * value;
                n = "-";
            }

            while (value > 0)
            {
                var mod = value % decimalVal;
                decimalWord = mod.ToString() + decimalWord;
                value = value / decimalVal;
            }
           

            return $"{n}{decimalWord}";
        }

        public void test()
        {
            Console.WriteLine("LeetCode Decimal 10 To 7:");
            solve2();

            Console.WriteLine("");
        }
    }
}
