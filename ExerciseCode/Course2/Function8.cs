using ExerciseCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ExerciseCode.Course2
{
    /// <summary>
    /// 直線上有N個點，點i的位置是Xi。從這N個點中選擇若幹個，給它們加上標記。
    /// 對每一個點，其距離為R以內的區域里必須有帶有標記的點
    /// (自己本身帶有標記的點，可以認為其與距離為0的地方有一個帶有標記的點)。
    /// 在滿足這個條件的情況下，希望能為盡可能少的點添加標記。請問至少要有多少點被加上標記？
    /// </summary>
    class Function8 : IFunction
    {
        private int range;
        private int[] points;

        private void setData(int[] points, int range)
        {
            Array.Sort(points);

            this.points = points;
            this.range = range;
        }

        public void solve1()
        {
            Console.Write("solve1 : ");
            var sw = new Stopwatch();
            sw.Start();

            //var RangePoint = new Dictionary<int, List<int>>();

            //for (int i = 0; i < this.points.Length; i++)
            //{
            //    var point = this.points[i];
            //    var rangePoints = this.points.Where(x => point - this.range <= x && x <= point + this.range).ToList();
            //    if (rangePoints.Max() - this.range >= rangePoints.Min())
            //    {
            //        var tmp = RangePoint.Last();
            //        if (rangePoints.Min() <= tmp.Value.Min() && tmp.Value.Max() < rangePoints.Max())
            //        {
            //            RangePoint.Remove(tmp.Key);
            //        }
            //        else if (tmp.Value.Contains(point) || rangePoints.Where(p=> tmp.Value.Contains(p)).Any())
            //        {
            //            continue;
            //        }

            //        RangePoint.Add(point, rangePoints);
            //    }
            //    else
            //    {
            //        RangePoint.Add(point, rangePoints);
            //    }
            //}

            sw.Stop();

            Console.WriteLine($"沒有好解 \t time:{sw.ElapsedMilliseconds}");
        }

        public void solve2()
        {
            Console.Write("solve2 : ");
            var sw = new Stopwatch();
            sw.Start();

            var RangePoint = new List<int>();
            int i = 0, ans = 0;
            while(i<this.points.Length)
            {
                var p1 = this.points[i++];
                while (i < this.points.Length && this.points[i] <=p1 + this.range) i++;

                var markPoint = this.points[i - 1];
                RangePoint.Add(markPoint);
                while (i < this.points.Length && this.points[i] <= markPoint + this.range) i++;

                ans++;
            }

            Console.WriteLine($"共 {RangePoint.Count()} 點被加上標記，Points:{string.Join(", ", RangePoint)} \t time:{sw.ElapsedMilliseconds}");

            sw.Stop();
        }

        public void test()
        {
            setData(new int[] { 1, 7, 15, 20, 30,31, 50 }, 10);

            solve1();
            solve2();
        }

        
    }
}
