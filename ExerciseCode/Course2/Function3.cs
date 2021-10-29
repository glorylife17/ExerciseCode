using System;
using System.Diagnostics;
using ExerciseCode.Interfaces;

namespace ExerciseCode.Course2
{
    public class Function3:IFunction
    {
        /// <summary>
        /// 給予N * M大小的2維陣列，有'W'和 '.' 兩種值。
        /// W為水灘、. 句點為一般地面，而W相鄰8個方向若也有其他W，則視為同1個水灘區域。
        /// 求水灘區域有多少個。
        /// </summary>
        public Function3()
        {
        }

        private int width, height;
        private string[,] lake;
        private int maxLakeNum = 0;

        private void setData()
        {
            var maxW = 12;
            var maxH = 10;

            this.width = maxW;
            this.height = maxH;

            string[] tmpData = {
                "W........WW.",
                ".WWW.....WWW",
                "....WW...WW.",
                ".........WW.",
                ".........W..",
                "..W......W..",
                ".W.W.....WW.",
                "W.W.W.....W.",
                ".W.W......W.",
                "..W.......W.",
            };

            this.lake = new string[maxH, maxW];

            for (int i = 0; i < tmpData.Length; i++)
            {
                var w = tmpData[i].ToCharArray();
                for (int j = 0; j < w.Length; j++)
                {
                    this.lake[i, j] = w[j].ToString();
                }
            }
        }

        public void solve1()
        {
            Console.Write("solve1 :");

            var sw = new Stopwatch();
            sw.Start();

            this.maxLakeNum = 0;
            for (int i = 0; i < this.height; i++)
            {
                for (int j = 0; j < this.width; j++)
                {
                    countLake(i, j);
                }
            }

            Console.WriteLine($"共有 {this.maxLakeNum} lakes \t time:{sw.ElapsedMilliseconds}");

            sw.Stop();
        }

        private void countLake(int x, int y)
        {
            var maxNum = 0;
            var hasLake = false;

            if (this.lake[x, y] == ".") return;

            for (int i = x - 1; i <= x + 1; i++)
            {
                if (i < 0 || i >= this.height) continue;
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (j < 0 || j >= this.width) continue;

                    var num = 0;
                    if (this.lake[i, j] == "W" || int.TryParse(this.lake[i, j], out num))
                    {
                        hasLake = true;
                        if (num == 0 && maxNum == 0)
                        {
                            this.maxLakeNum = this.maxLakeNum + 1;
                            maxNum = this.maxLakeNum;
                        }
                        else
                        {
                            maxNum = (maxNum != 0) ? maxNum : num;
                        }
                    }
                }
            }

            if (hasLake)
                this.lake[x, y] = maxNum.ToString();
        }

        public void solve2()
        {
            Console.Write("solve2 :");

            var sw = new Stopwatch();
            sw.Start();
            this.maxLakeNum = 0;

            for (int i = 0; i < this.height; i++)
            {
                for (int j = 0; j < this.width; j++)
                {
                    if (this.lake[i, j] == "W")
                    {
                        defCountLake(i, j);
                        this.maxLakeNum++;
                    }
                }
            }

            Console.WriteLine($"共有 {this.maxLakeNum} lakes \t time:{sw.ElapsedMilliseconds}");

        }

        private void defCountLake(int y, int x)
        {
            this.lake[y, x] = ".";

            for (int i = -1; i <= 1; i++)
            {
                var dx = x + i;
                for (int j = -1; j <= 1; j++)
                {
                    var dy = y+ j;

                    if (hasW(dx, dy))
                        defCountLake(dy, dx);
                }
            }
           
        }

        private bool hasW(int dx, int dy)
        {
            return 0 <= dx && dx < this.width &&
                   0 <= dy && dy < this.height &&
                   this.lake[dy, dx] == "W";
        }

        private void showData()
        {
            for (int i = 0; i < this.height; i++)
            {
                for (int j = 0; j < this.width; j++)
                {
                    Console.Write(this.lake[i, j]);
                }
                Console.Write("\n");
            }
        }

        public void test()
        {
            setData();
            showData();
            Console.WriteLine();

            setData();
            solve1();

            setData();
            solve2();

            Console.WriteLine();
            //showData();
        }
    }
}
