using ExerciseCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseCode.LeetCode
{
    class BackspaceStringCompare : IFunction
    {
        public void solve1()
        {
            var isSame1 = compareString("ab#c", "ad#vv##c");
            Console.WriteLine($"LeetCode ab#c == ad#c: {isSame1}");

        }

        private bool compareString(string str1, string str2)
        {
            var word1 = breakspace(str1);
            var word2 = breakspace(str2);
            return word1 == word2;
        }

        private string breakspace(string str1)
        {
            var res = "";

            for (int i = 0; i < str1.Length; i++)
            {
                if(str1[i]!='#')
                {
                    res += str1[i];
                }
                else 
                {
                    if (res.Length > 0)
                    {
                        res = res.Remove(res.Length - 1);
                    }
                }
            }
            return res;
        }

        public void solve2()
        {
           
        }

        public void test()
        {
            Console.WriteLine("LeetCode Backspace String Compare:");
            solve1();

            Console.WriteLine("");
        }
    }
}
