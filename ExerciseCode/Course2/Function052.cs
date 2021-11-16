using ExerciseCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ExerciseCode.Course2
{
    /// <summary>
    /// 01 背包問題
    /// 有 N 件物品和一個容量為 V 的背包。
    /// 第 i 件物品的費用是 c[i]，價值是 w[i]。
    /// 求解將哪些物品裝入背包可使價值總和最大。
    /// </summary>
    class Function052 : IFunction
    {
        private List<ProductModel> products;
        private int maxWeight;
        private int[,] productValues;

        private void setData()
        {
            products = new List<ProductModel>()
            {
                new ProductModel(2,3),
                new ProductModel(1,2),
                new ProductModel(3,4),
                new ProductModel(2,2),
            };
            
            maxWeight = 5;

            productValues = new int[products.Count+1, maxWeight + 1];
        }

        public void solve1()
        {
            Console.Write("solve1 :");
            var sw = new Stopwatch();
            sw.Start();

            //takeProducts = new List<ProductModel>();
            //takeMaxProduct(0,0);

            sw.Stop();

            Console.WriteLine($"沒有好解 \t time:{sw.ElapsedMilliseconds}");
        }

        
        private bool takeMaxProduct(int num, int totalWeight)
        {
            if (num >= products.Count || totalWeight > this.maxWeight) return false;

            if (takeMaxProduct(num + 1, totalWeight)) return true;

            if (takeMaxProduct(num + 1, totalWeight+this.products[num].Weight)) return true;

            return false;
        }

        public void solve2()
        {
            Console.Write("solve2 :");
            var sw = new Stopwatch();
            sw.Start();

            var maxValue = 0;
            for (int i = 0; i < this.products.Count; i++)
            {
                for (int w = 0; w <= this.maxWeight; w++)
                {
                    var sumValue = takeProducts(i, w);
                    productValues[i, w] = sumValue;

                    maxValue = Math.Max(maxValue, sumValue);
                }
            }
            sw.Stop();
            
            Console.WriteLine($"最大價值總和:{maxValue} \t time:{sw.ElapsedMilliseconds}");
        }

        private int takeProducts(int i, int weight)
        {
            if (i == this.products.Count) return 0;

            var res = 0;
            var p = this.products[i];

            if (weight < p.Weight)
            {
                res = takeProducts(i + 1, weight);
            }
            else
            {
                res = Math.Max(takeProducts(i + 1, weight), takeProducts(i + 1, weight - p.Weight) + p.Price);
            }

            return res;
        }


        public void solve3()
        {
            Console.Write("solve3 :");
            var sw = new Stopwatch();
            sw.Start();

            Array.Clear(productValues, 0, productValues.Length);

            var maxValue = 0;
            for (int i = 0; i < this.products.Count; i++)
            {
                for (int w = 0; w <= this.maxWeight; w++)
                {
                    var sumValue = dpTakeProduct(i, w);
                    productValues[i, w] = sumValue;

                    maxValue = Math.Max(maxValue, sumValue);
                }
            }

            sw.Stop();
            Console.WriteLine($"最大價值總和:{maxValue} \t time:{sw.ElapsedMilliseconds}");

        }


        private int dpTakeProduct(int i, int weight)
        {
            if (productValues[i, weight] > 0) { return productValues[i, weight]; }

            if (i == this.products.Count) return 0;

            var res = 0;
            var p = this.products[i];
            
            if (weight < p.Weight)
            {
                res = takeProducts(i + 1, weight);
            }
            else
            {
                res = Math.Max(takeProducts(i + 1, weight), takeProducts(i + 1, weight - p.Weight) + p.Price);
            }

            productValues[i, weight] = res;
            return res;
        }

        public void solve4()
        {
            Console.Write("solve4 :");
            var sw = new Stopwatch();
            sw.Start();

            Array.Clear(productValues, 0, productValues.Length);

            var maxValue = 0;
            for (int i = this.products.Count-1; i >=0 ; i--)
            {
                var p = this.products[i];
                for (int w = 0; w <= this.maxWeight; w++)
                {
                    if (w < p.Weight)
                    {
                        productValues[i, w] = productValues[i + 1, w];
                    }else
                    {
                        productValues[i, w] = Math.Max(productValues[i, w], productValues[i + 1, w - p.Weight] + p.Price);
                    }
                    maxValue = Math.Max(maxValue, productValues[i, w]);
                }
            }

            sw.Stop();
            Console.WriteLine($"最大價值總和:{maxValue} \t time:{sw.ElapsedMilliseconds}");
        }

        public void solve5()
        {
            Console.Write("solve5 :");
            var sw = new Stopwatch();
            sw.Start();

            Array.Clear(productValues, 0, productValues.Length);

            var maxValue = 0;
            for (int i = 0; i < this.products.Count; i++)
            {
                var p = this.products[i];
                for (int w = 0; w <= this.maxWeight; w++)
                {
                    productValues[i + 1, w] = Math.Max(productValues[i + 1, w], productValues[i, w]);
                    if (w < p.Weight && p.Weight <= this.maxWeight)
                    {
                        productValues[i + 1, w + p.Weight] = Math.Max(productValues[i + 1, w + p.Weight], productValues[i, w] + p.Price);
                    }
                    maxValue = Math.Max(maxValue, productValues[i + 1, w]);
                }
            }

            sw.Stop();
            Console.WriteLine($"最大價值總和:{maxValue} \t time:{sw.ElapsedMilliseconds}");
        }


        public void test()
        {
            setData();
            solve1();
            solve2();
            solve3();
            solve4();
            solve5();
        }

      
    }

    internal class ProductModel
    {
        public ProductModel(int weight, int price)
        {
            Weight = weight;
            Price = price;
        }

        public int Weight { get; set; }
        public int Price { get; set; }
    }
}
