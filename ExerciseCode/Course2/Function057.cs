using ExerciseCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ExerciseCode.Course2
{
    /// <summary>
    /// 最長共同子序列問題 
    /// 讀入兩個字串 s1, s2。
    /// dp[i][j]：s1 的前 i 個字元（s1[0] ~s1[i-1]），與s2 的前 j 個字元（s2[0] ~s2[j-1]），
    /// 共同子序列的長度。
    /// </summary>
    class Function057 : IFunction
    {
        private char[] _str1;
        private char[] _str2;

        private void setData(string str1, string str2)
        {
            this._str1 = str1.ToCharArray();
            this._str2 = str2.ToCharArray();
        }

        public void solve1()
        {
            Console.Write("solve1 : ");

            var sw = new Stopwatch();
            sw.Start();

            var score = new int[_str1.Length + 1, _str2.Length + 1];
            var str1 = getArray(_str1);
            var str2 = getArray(_str2);

            var maxLength = 0;
            for (int i = 1; i < str1.Length; i++)
            {
                for (int j = 1; j < str2.Length; j++)
                {
                    if (str1[i] == str2[j])
                    {
                        score[i, j] = score[i - 1, j - 1] + 1;
                        maxLength = Math.Max(maxLength, score[i, j]);
                    }
                    else
                    {
                        score[i, j] = Math.Max(score[i, j - 1], score[i - 1, j]);
                    }
                }
            }

            sw.Stop();

            var index = maxLength;
            var cstr = "";
            for (int i = str1.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < str2.Length; j++)
                {
                    if (score[i, j] == index && index != 0)
                    {
                        index = score[i, j] - 1;
                        cstr = str2[j] + cstr;
                    }
                }
            }

            Console.WriteLine($"最長公共子序列:{cstr}  長度為:{maxLength} \t time:{sw.ElapsedMilliseconds}");

        }

        private char[] getArray(char[] str1)
        {
            var res = new char[str1.Length + 1];
            str1.CopyTo(res, 1);
            return res;
        }

        public void solve2()
        {
            Console.Write("solve2: ");

            var sw = new Stopwatch();
            sw.Start();

            var score = new int[_str1.Length + 1, _str2.Length + 1];
            var str1 = getArray(_str1);
            var str2 = getArray(_str2);

            var maxLength = 0;
            for (int i = 0; i < str1.Length - 1; i++)
            {
                for (int j = 0; j < str2.Length - 1; j++)
                {
                    if (str1[i + 1] == str2[j + 1])
                    {
                        score[i + 1, j + 1] = score[i, j] + 1;
                        maxLength = Math.Max(maxLength, score[i + 1, j + 1]);
                    }
                    else
                    {
                        score[i + 1, j + 1] = Math.Max(score[i + 1, j], score[i, j + 1]);
                    }
                }
            }

            sw.Stop();

            var index = maxLength;
            var cstr = "";
            for (int i = str1.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < str2.Length; j++)
                {
                    if (score[i, j] == index && index != 0)
                    {
                        index = score[i, j] - 1;
                        cstr = str2[j] + cstr;
                    }
                }
            }

            Console.WriteLine($"最長公共子序列:{cstr}  長度為:{maxLength} \t time:{sw.ElapsedMilliseconds}");
        }

        public void test()
        {
            //setData("bdcaba", "abcbdab");
            //setData("abcbdab", "bdcaba");
            setData("abcd", "becd");
            solve1();
            solve2();
        }
    }
}
