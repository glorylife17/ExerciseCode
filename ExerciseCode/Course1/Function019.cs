using ExerciseCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ExerciseCode.Course1
{
    /// <summary>
    /// 二分搜尋法與O(n3logn)
    /// </summary>
    class Function019 : IFunction
    {
        private int times;  //次數
        private int num;  //確認數字
        private int[] numbers;  //一堆數字

        public void setData(int maxNumber, int num)
        {
            this.times = maxNumber;
            this.num = num;
            this.numbers = new int[maxNumber];

            for (int i = 0; i < maxNumber; i++)
            {
                this.numbers[i] = i;
            }
            this.numbers= randomArray(this.numbers);
        }

        private int[] randomArray(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                var num = numbers[i];
                var idx = new Random().Next(0, numbers.Length);
                var tmp = numbers[idx];

                numbers[i] = tmp;
                numbers[idx] = num;
            }

            return numbers;
        }

        /// <summary>
        /// 書中表示一般迴圈作法
        /// </summary>
        public void solve1()
        {
            Console.Write("solve1 : ");
            var sw = new Stopwatch();
            sw.Start();

            var res = false;
            for (int a = 0; a < this.times; a++)
            {
                for (int b = 0; b < this.times; b++)
                {
                    for (int  c = 0; c < this.times; c++)
                    {
                        for (int d = 0; d < this.times; d++)
                        {
                            if(numbers[a] + numbers[b] + numbers[c] + numbers[d] ==this.num)
                            {
                                res = true;
                            }
                        }
                    }
                }
            }

            sw.Stop();
            Console.WriteLine($"res: {res} \t time:{sw.ElapsedMilliseconds}");
        }

        public void solve2()
        {
            Console.Write("solve2 : ");

            var sw = new Stopwatch();
            sw.Start();

            Array.Sort(this.numbers);

            var res = false;
            for (int a = 0; a < this.times; a++)
            {
                for (int b = 0; b < this.times; b++)
                {
                    for (int c = 0; c < this.times; c++)
                    {
                        if (searchNumber(this.num - numbers[a] - numbers[b] - numbers[c], this.numbers))
                        {
                            res = true;
                        }
                    }
                }
            }

            sw.Stop();
            Console.WriteLine($"res: {res} \t time:{sw.ElapsedMilliseconds}");
        }

        private void solve3()
        {
            Console.Write("solve3 : ");

            var sw = new Stopwatch();
            sw.Start();
            var res = false;

            var nums = new int[this.times * this.times];

            for (int c = 0; c < this.times; c++)
            {
                for (int d = 0; d < this.times; d++)
                {
                    nums[c * this.times + d] = numbers[c] + numbers[d];
                }
            }

            Array.Sort(nums);

            for (int a = 0; a < this.times; a++)
            {
                for (int b = 0; b < this.times; b++)
                {
                    if (searchNumber(this.num - numbers[a] - numbers[b], nums))
                    {
                        res = true;
                    }
                }
            }
         
            sw.Stop();
            Console.WriteLine($"res: {res} \t time:{sw.ElapsedMilliseconds}");
        }

        /// <summary>
        /// 二元樹搜尋法
        /// </summary>
        /// <param name="number">搜尋數字</param>
        /// <param name="nums">數字陣列</param>
        /// <returns></returns>
        private bool searchNumber(int number, int[] nums)
        {
            var index = 0;
            var n = this.times;
            var res = false;

            while (n - index >= 1)
            {
                var i = (index + n) / 2;
                if (nums[i] == number)
                {
                    return true;
                }
                else if (nums[i] < number)
                {
                    index = i + 1;
                }else
                {
                    n = i;
                }
            }

            return res;
        }

        public void test()
        {
            setData(200, 36);
            solve1();
            solve2();
            solve3();
        }
    }
}
