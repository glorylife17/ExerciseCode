using ExerciseCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ExerciseCode.Course1
{
    /// <summary>
    /// n只螞蟻以每秒1cm的速度在長為Lcm的竿子上爬行。當螞蟻爬到竿子的端點時就會掉落。
    /// 由於竿子太細，兩隻螞蟻相遇時，它們不能交錯通過，只能各自反向爬回去。
    /// 對於每隻螞蟻，我們知道它距離竿子左端的距離xi，但不知道它當前的朝向。
    /// 請計算所有螞蟻落下竿子所需的最短時間和最長時間
    /// </summary>
    class Function2: IFunction
    {
        private int ants;  //n隻螞蟻
        private int stickLength;  //竿子長度(Lcm)
        private int[] antsLocation;  //螞蟻位置
        private enum Direction { Left,Right};

        public Function2()
        {

        }

        /// <summary>
        /// 設定參數
        /// </summary>
        /// <param name="locations">螞蟻位置</param>
        /// <param name="stickLength">竿子長度</param>
        public void setData(int[] locations, int stickLength )
        {
            this.ants = locations.Length;
            this.antsLocation = locations;
            this.stickLength = stickLength;
        }

        public void solve1()
        {
            Console.Write("solve1 : ");
            var sw = new Stopwatch();
            sw.Start();

            var midStick = this.stickLength / 2;

            //最短時間
            var antsMinDirectionTime = new List<AntModel>();
                        
            for (int i = 0; i < this.ants; i++)
            {
                var location = this.antsLocation[i];


                if (location < midStick)
                {
                    //趨近左側
                    antsMinDirectionTime.Add(new AntModel
                    {
                        location = location,
                        direction = Direction.Left,
                        times = location
                    });
                }
                else
                {
                    //趨近右側
                    antsMinDirectionTime.Add(new AntModel
                    {
                        location = location,
                        direction = Direction.Right,
                        times = this.stickLength - location
                    });
                }
            }

            var minTime = antsMinDirectionTime.Select(x => x.times).Max();
            var minDirections = antsMinDirectionTime.Select(x => x.direction).ToArray();


            //最長時間
            var antsMaxDirectionTime = new List<AntModel>();
            for (int i = 0; i < this.ants; i++)
            {
                var location = this.antsLocation[i];
                if (location < midStick)
                {
                    //趨近左側
                    antsMaxDirectionTime.Add(new AntModel
                    {
                        location = location,
                        direction = Direction.Right,
                        times = this.stickLength - location
                    });
                }
                else
                {
                    //趨近右側
                    antsMaxDirectionTime.Add(new AntModel
                    {
                        location = location,
                        direction = Direction.Left,
                        times = location
                    });
                }
            }

            var maxTime = antsMaxDirectionTime.Select(x => x.times).Max();
            var maxDirections = antsMaxDirectionTime.Select(x => x.direction).ToArray();

            sw.Stop();

            Console.WriteLine($"min : {minTime} \t max : {maxTime} ({string.Join(", ", maxDirections)}) \t time:{sw.ElapsedMilliseconds}");
        }

        public void solve2()
        {
            Console.Write("solve2 : ");

            var sw = new Stopwatch();
            sw.Start();

            //計算最短時間
            var minT = 0;
            for (int i = 0; i < this.ants; i++)
            {
                var location = this.antsLocation[i];
                minT = Math.Max(minT, Math.Min(location, stickLength - location));
            }

            //計算最長時間
            var maxT = 0;
            for (int i = 0; i < this.ants; i++)
            {
                var location = this.antsLocation[i];
                maxT = Math.Max(maxT, Math.Max(location, stickLength - location));
            }

            sw.Stop();
            Console.WriteLine($"min : {minT} \t max : {maxT} \t time:{sw.ElapsedMilliseconds}");

        }

        public void test()
        {
            setData(new int[3] { 2, 6, 7 }, 10);
            solve1();
            solve2();
            Console.WriteLine();

            Console.ReadKey();
        }

        class AntModel
        {
            public int location { get; set; }
            public Direction direction { get; set; }
            public int times { get; set; }
        }
    }

   
}
