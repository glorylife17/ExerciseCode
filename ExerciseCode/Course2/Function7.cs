using ExerciseCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ExerciseCode.Course2
{
    /// <summary>
    /// 給定 N 個字完的字串 S ，並建立 N 個字元的字串 T ，
    /// 然後它從 S 的開頭或尾端刪除一個字元，並將之新增至 T 尾端，
    /// 並使 T 以字典排序儘可能地小。
    /// </summary>
    class Function7 : IFunction
    {
        private string soure = "";

        private void setData()
        {
            this.soure = "ACDBCB";
        }

        public void solve1()
        {
            Console.Write("solve1");
            var sw = new Stopwatch();
            sw.Start();

            var target = "";
            var tmp = this.soure;

            while (tmp.Length > 0)
            {
                var idx = compareWord(tmp, 1);
                target += tmp.Substring(idx, 1);
                tmp = tmp.Remove(idx, 1);
            }

            sw.Stop();

            Console.WriteLine();
            Console.WriteLine($"原句子: {this.soure}\t排序後: {target}\ttime:{sw.ElapsedMilliseconds}");
        }


        private int compareWord(string content, int workNum)
        {
            if (content.Length == 1) return 0;

            var f = content.Substring(0, workNum);
            var e = string.Join("", content.Substring(content.Length - workNum, workNum).Reverse());
            var res = 0;

            if (f[workNum - 1] < e[workNum - 1])
            {
                workNum = 1;
                res = 0;
            }
            else if (f[workNum - 1] > e[workNum - 1])
            {
                workNum = 1;
                res = content.Length - workNum;
            }
            else
            {
                workNum++;
                res=compareWord(content, workNum);
            }

            return res;
        }

        public void solve2()
        {
            Console.Write("solve2");
            var sw = new Stopwatch();
            sw.Start();

            var tmp = this.soure.ToCharArray();
            var words = new List<string>();
            var iStart = 0;
            var iEnd = tmp.Length - 1;

            while (iStart <= iEnd)
            {
                var left = false;

                for (int i = 0; iStart + i <= iEnd; i++)
                {
                    if (tmp[iStart + i] < tmp[iEnd -i])
                    {
                        left = true;
                        break;
                    }
                    else if (tmp[iStart + i] > tmp[iEnd - i])
                    {
                        left = false;
                        break;
                    }
                }

                if (left) words.Add(tmp[iStart++].ToString());
                else words.Add(tmp[iEnd--].ToString());
            }

            var target = string.Join("", words);
            sw.Stop();

            Console.WriteLine();
            Console.WriteLine($"原句子: {this.soure}\t排序後: {target}\ttime:{sw.ElapsedMilliseconds}");

        }

        public void test()
        {
            setData();
            solve1();
            solve2();
        }

    }
}
