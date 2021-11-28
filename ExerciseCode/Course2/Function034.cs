using ExerciseCode.Interfaces;
using ExerciseCode.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ExerciseCode.Course2
{
    /// <summary>
    /// 迷宮的最短路徑之BFS算法
    /// 給定一個大小為N*M的迷宮，由通道('.')和墻壁('#')組成，
    /// 其中通道S表示起點，通道G表示終點，
    /// 每一步移動可以達到上下左右中不是墻壁的位置。
    /// 試求出起點到終點的最小步數。
    /// （本題假定迷宮是有解的）(N,M<=100)
    /// </summary>
    class Function034 : IFunction
    {
        private int width, height;
        private string[,] maze;
        private PointModel startPoint;
        private PointModel endPoint;
        private int maxStep;
        private int INF = 100000000;
        private int[,] distances;
        private Queue<PointModel> que;
        private int[] ax = new int[] { 0, -1, 0, 1 };
        private int[] ay = new int[] { -1, 0, 1, 0 };
        private void setData()
        {
            string[] tmpData = {
                "#S######.#",
                "......#..#",
                ".#.##.##.#",
                ".#........",
                "##.##.####",
                "....#....#",
                ".#######.#",
                "....#.....",
                ".####.###.",
                "....#...G#",
            };

            this.width = tmpData.Any() ? tmpData[0].ToCharArray().Length : 0;
            this.height = tmpData.Length;

            this.maze = new string[this.width, this.height];

            for (int i = 0; i < tmpData.Length; i++)
            {
                var w = tmpData[i].ToCharArray();
                for (int j = 0; j < w.Length; j++)
                {
                    this.maze[i, j] = w[j].ToString();
                }
            }
        }

        public void solve1()
        {
            Console.Write("solve1 :");

            var sw = new Stopwatch();
            sw.Start();

            this.maxStep = 0;
            searchEndPoint(this.startPoint.x, this.startPoint.y, 0);

            sw.Stop();

            Console.WriteLine($"共需要 {this.maxStep} 步到終點! \t time:{sw.ElapsedMilliseconds}");

        }

        private bool searchEndPoint(int x, int y, int step)
        {
            step++;

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (Math.Abs(i) == Math.Abs(j)) continue;

                    var dx = x + i;
                    var dy = y + j;

                    if (dx < 0 || dx >= this.width) continue;
                    if (dy < 0 || dy >= this.height) continue;

                    if (this.maze[dy, dx] == ".")
                    {

                        this.maze[dy, dx] = $"{step.ToString("00")}";

                        searchEndPoint(dx, dy, step);
                    }
                    else if (this.maze[dy, dx] == "G")
                    {
                        this.maxStep = step;
                    }
                }
            }

            return false;
        }

        private PointModel findPoint(string point)
        {
            for (int i = 0; i < this.height; i++)
            {
                for (int j = 0; j < this.width; j++)
                {
                    if (this.maze[i, j] == point)
                        return new PointModel(j, i);
                }
            }

            return new PointModel(0, 0);
        }

        public void solve2()
        {
            Console.Write("solve2 :");

            var sw = new Stopwatch();
            sw.Start();

            var step = getMatrixSetp();

            sw.Stop();

            Console.WriteLine($"共需要 {step} 步到終點! \t time:{sw.ElapsedMilliseconds}");
        }

        private int getMatrixSetp()
        {
            que = new Queue<PointModel>();
            distances = new int[this.height, this.width];

            for (int i = 0; i < this.height; i++)
            {
                for (int j = 0; j < this.width; j++)
                {
                    distances[i, j] = INF;
                }
            }
            que.Enqueue(startPoint);
            distances[startPoint.y, startPoint.x] = 0;

            while (que.Count() > 0)
            {
                var p = que.Dequeue();
                if (this.maze[p.y, p.x] == "G") break;

                for (int i = 0; i < 4; i++)
                {
                    var dx = ax[i] + p.x;
                    var dy = ay[i] + p.y;

                    if (0 <= dx && dx < this.width && 0 <= dy && dy < this.height
                        && this.maze[dy, dx] != "#" && this.distances[dy, dx] == INF)
                    {
                        que.Enqueue(new PointModel(dx, dy));
                        distances[dy, dx] = distances[p.y, p.x] + 1;
                    }
                }
            }

            return distances[endPoint.y, endPoint.x];
        }

        private void showData()
        {
            for (int i = 0; i < this.height; i++)
            {
                for (int j = 0; j < this.width; j++)
                {
                    if (int.TryParse(this.maze[i, j], out int val))
                    {
                        Console.Write($" {val.ToString("00")}");
                    }
                    else
                    {
                        Console.Write($" {this.maze[i, j]} ");
                    }
                }
                Console.Write("\n");
            }
        }

        public void test()
        {
            setData();
            showData();
            Console.WriteLine();

            startPoint = findPoint("S");
            Console.WriteLine($"起點位置:{startPoint.ToString()}");
            endPoint = findPoint("G");
            Console.WriteLine($"終點位置:{endPoint.ToString()}");

            Console.WriteLine();


            setData();
            solve1();
            solve2();

            Console.WriteLine();
            //showData();
        }
    }
}
