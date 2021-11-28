using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseCode.Models
{
    public class ProductModel
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
