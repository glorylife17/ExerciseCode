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
    /// 不限制數量的背包問題
    /// 有重量與價值分別是 wi 和 vi 的 n 種物品。
    /// 請從這些物品中選擇物品，在重量的總和不超過 W 的前提下，
    /// 求出價值總和的最大值。
    /// 但是，同一種物品可以選擇好幾個。
    /// </summary>
    class Function060 : IFunction
    {
        private List<ProductModel> _products;
        private int _maxWeight;
        private int[,] _productValues;
        private List<RecoderModel> _recorder;

        private void setData(List<ProductModel> products, int weight)
        {
            _products = products;
            _maxWeight = weight;

            _productValues = new int[_products.Count + 1, _maxWeight + 1];
            _recorder = new List<RecoderModel>();

        }

        public void solve1()
        {
            Console.Write("solve1 :");
            var sw = new Stopwatch();
            sw.Start();

            _products.Insert(0, new ProductModel(0, 0));

            for (int i = 1; i < _products.Count; i++)
            {
                var p = _products[i];
                for (int j = 1; j <= _maxWeight; j++)
                {
                    if (p.Weight > j)
                    {
                        _productValues[i, j] = Math.Max(_productValues[i - 1, j], _productValues[i, j - 1]);

                        if (_productValues[i - 1, j] > _productValues[i, j - 1])
                        {
                            _recorder.Add(new RecoderModel(new PointModel(i, j), _productValues[i - 1, j], _recorder.Where(po => po.Point.x == i - 1 && po.Point.y == j).FirstOrDefault()?.Objects));
                        }
                        else
                        {
                            _recorder.Add(new RecoderModel(new PointModel(i, j), _productValues[i, j - 1], _recorder.Where(po => po.Point.x == i && po.Point.y == j - 1).FirstOrDefault()?.Objects));
                        }
                    }
                    else
                    {
                        _productValues[i, j] = Math.Max(_productValues[i - 1, j], _productValues[i, j - p.Weight] + p.Price);

                        if (_productValues[i - 1, j] > _productValues[i, j - p.Weight] + p.Price)
                        {
                            _recorder.Add(new RecoderModel(new PointModel(i, j), _productValues[i - 1, j], _recorder.Where(po => po.Point.x == i - 1 && po.Point.y == j).FirstOrDefault()?.Objects));
                        }
                        else
                        {
                            _recorder.Add(new RecoderModel(new PointModel(i, j), _productValues[i, j - p.Weight] + p.Price, _recorder.Where(po => po.Point.x == i && po.Point.y == j - p.Weight).FirstOrDefault()?.Objects + $",{i}"));
                        }
                    }
                }
            }

            var first = _recorder.OrderByDescending(x => x.Value).First();

            sw.Stop();
            var objs = first.Objects.Split(',');
            var maxObjcts = "";
            for (int i = 0; i < objs.Length; i++)
            {
                var tmpstr = objs[i].Trim();
                if (!string.IsNullOrWhiteSpace(tmpstr))
                    maxObjcts += tmpstr + ", ";
            }

            Console.WriteLine($"最大價值總和: {first.Value} \t time:{sw.ElapsedMilliseconds}  (東西為: {maxObjcts})");
            //Console.WriteLine($"time:{sw.ElapsedMilliseconds}");
        }

        public void solve2()
        {
            Array.Clear(_productValues, 0, _productValues.Length);

            _products.RemoveAt(0);
            _products.Insert(_products.Count, new ProductModel(0, 0));

            Console.Write("solve2 :");
            var sw = new Stopwatch();
            sw.Start();

            var maxvalue = 0;
            for (int i = 0; i < _products.Count-1; i++)
            {
                for (int j = 0; j <= _maxWeight; j++)
                {
                    if (j < _products[i].Weight)
                    {
                        _productValues[i + 1, j] = _productValues[i, j];
                    }
                    else
                    {
                        _productValues[i + 1, j] = Math.Max(_productValues[i, j], _productValues[i + 1, j - _products[i].Weight] + _products[i].Price);
                    }

                    maxvalue = Math.Max(maxvalue, _productValues[i + 1, j]);
                }
            }
            sw.Stop();

            Console.WriteLine($"最大價值總和: {maxvalue} \t time:{sw.ElapsedMilliseconds}");
        }

        public void test()
        {
            var products = new List<ProductModel>()
            {
                new ProductModel(3,4),
                new ProductModel(4,5),
                new ProductModel(2,3),
            };

            setData(products,7);
            solve1();
            solve2();
        }

        class RecoderModel
        {
            public RecoderModel(PointModel point, int value, string objects)
            {
                this.Point = point;
                this.Value = value;
                this.Objects = objects;
            }

            public PointModel Point { get; set; }
            public int Value { get; set; }
            public string Objects { get; set; }
        }

       
    }
}
