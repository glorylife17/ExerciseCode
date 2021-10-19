using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseCode.Course1
{
    /// <summary>
    ///  有n支棒子，棒子i的長度是ai。
    ///  您想從這些棒子中選出三支來做出周長最長的三角形。
    ///  請求出能夠做出的最大周長。如果無法做出三角形時請輸出0。
    /// </summary>
    public class Function1
    {
        private static int stickNum;
        private static int[] sticksLength;

        public Function1()
        {

        }

        public void setData(int[] val)
        {
            stickNum = val.Length;
            sticksLength = val;
        }

        /// <summary>
        /// 自己的做法
        /// </summary>
        public void solve1()
        {
            Console.Write("solve1 : ");

            if (hasData()) return;

            var amax = new int[3];
            for (int i = 0; i < stickNum - 2; i++)
            {
                for (int j = i + 1; j < stickNum - 1; j++)
                {
                    for (int k = j + 1; k < stickNum; k++)
                    {
                        var a1 = sticksLength[i];
                        var a2 = sticksLength[j];
                        var a3 = sticksLength[k];

                        var max = getPerimeter(a1, a2, a3);
                        if (a1 + a2 > a3 && a2 + a3 > a1 && a3 + a1 > a2 && max > getPerimeter(amax))
                        {
                            amax[0] = a1; amax[1] = a2; amax[2] = a3;

                        }
                    }
                }
            }

            if (getPerimeter(amax) > 0)
            {
                Console.WriteLine($"{getPerimeter(amax)} 三角形三邊長為 : {amax[0]}, {amax[1]}, {amax[2]}");
            }
            else
            {
                Console.WriteLine($"{getPerimeter(amax)} 無法成為三角形");
            }
        }

        private bool hasData()
        {
            var res = stickNum != 0 && sticksLength != null
                && stickNum >= 3 && sticksLength.Length == stickNum;
            if (!res) Console.WriteLine("不符三角形規則");

            return !res;
        }

        private static int getPerimeter(int a1, int a2, int a3)
        {
            return a1 + a2 + a3;
        }

        private static int getPerimeter(int[] a)
        {
            return a[0] + a[1] + a[2];
        }

        /// <summary>
        /// 書的做法
        /// </summary>
        public void solve2()
        {
            Console.Write("solve2 : ");

            if (hasData()) return;

            var ans = 0;

            for (int i = 0; i < stickNum; i++)
            {
                for (int j = i + 1; j < stickNum; j++)
                {
                    for (int k = j + 1; k < stickNum; k++)
                    {
                        var len = sticksLength[i] + sticksLength[j] + sticksLength[k];
                        var ma = getMax(sticksLength[i], sticksLength[j], sticksLength[k]);

                        var rest = len - ma;
                        if (ma < rest)
                            ans = len;
                    }
                }
            }

            Console.WriteLine($"{ans}");
        }

        private int getMax(int a1, int a2, int a3)
        {
            var ans = 0;
            ans = Math.Max(a1, a2);
            ans = Math.Max(ans, a3);
            return ans;
        }

        public void test()
        {
            solve1();
            solve2();
            Console.WriteLine();

            setData(new int[5] { 2, 3, 4, 5, 10 });
            solve1();
            solve2();
            Console.WriteLine();

            setData(new int[4] { 4, 5, 10, 20 });
            solve1();
            solve2();
            Console.WriteLine();

            Console.ReadKey();
        }
       
    }
}
