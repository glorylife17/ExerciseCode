using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseCode.Models
{
    public class PointModel
    {
        public PointModel(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int x { get; set; }
        public int y { get; set; }

        public override string ToString()
        {
            return $"({this.x},{this.y})";
        }
    }
}
