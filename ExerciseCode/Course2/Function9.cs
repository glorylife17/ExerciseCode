using ExerciseCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ExerciseCode.Course2
{
    /// <summary>
    /// 給予一大塊木板，要切成N小塊的子木板，每個子木板有各自的Li (i = 1 ... N)長度，
    /// 每次切一刀成兩半時，需花費的成本是被切之前的長度。求切割最小的花費成本。
    /// 比如範例輸入N = 3，要的子木板長度各為8、5、8，而切第一刀之前(分成13 + 8)的長度是21，
    /// 切第二刀之前的長度是13(分成8 + 5)，所以最小的成本是21 + 13 = 34。
    /// </summary>
    class Function9 : IFunction
    {
        private int[] blocks;

        private void setData(int[] blocks)
        {
            this.blocks = blocks;    
        }

        public void solve1()
        {
            Console.Write("solve1 : ");
            var sw = new Stopwatch();
            sw.Start();

            var arr = new int[this.blocks.Length];
            this.blocks.CopyTo(arr,0);

            var res = calCount(arr);

            sw.Stop();

            Console.WriteLine($"最低成本是: {res} \t time:{sw.ElapsedMilliseconds}");
        }

        private int calCount(int[] arr)
        {
            Array.Sort(arr);
            var tmp = new int[(int)Math.Ceiling(arr.Length / 2.0)];
            var res = 0;
            for (int i = 0; i < arr.Length / 2; i++)
            {
                tmp[i] = arr[i * 2] + arr[i * 2 + 1];
                res += tmp[i];
            }

            if (arr.Length % 2 == 1) tmp[arr.Length / 2] = arr[arr.Length - 1];
            if (tmp.Length > 1)
                res += calCount(tmp);

            return res;
        }

        public void solve2()
        {
            Console.Write("solve2 : ");
            var sw = new Stopwatch();
            sw.Start();

            var res = 0;
            var n = this.blocks.Length;

            while (n > 1)
            {
                var mi1 = 0;
                var mi2 = 1;

                if (this.blocks[mi1] > this.blocks[mi2]) swap(ref mi1,ref  mi2);

                for (int i = 2; i < n; i++)
                {
                    if(this.blocks[i] < this.blocks[mi1])
                    {
                        mi2 = mi1;
                        mi1 = i;
                    }else if (this.blocks[i] < this.blocks[mi2])
                    {
                        mi2 = i;
                    }
                }

                var t = this.blocks[mi1] + this.blocks[mi2];
                res += t;

                if(mi1 == n-1) swap(ref mi1, ref mi2);
                this.blocks[mi1] = t;
                this.blocks[mi2] = this.blocks[n - 1];
                n--;
            }

            sw.Stop();

            Console.WriteLine($"最低成本是: {res} \t time:{sw.ElapsedMilliseconds}");

        }

        private void swap<T>(ref T mi1, ref T mi2)
        {
            var tmp = mi1;
            mi1 = mi2;
            mi2 = tmp;
        }

        public void test()
        {
            //setData(new int[] { 8,5,8});
            setData(new int[] { 1, 2, 3, 4, 5 });
            solve1();
            solve2();
        }

    }
}
