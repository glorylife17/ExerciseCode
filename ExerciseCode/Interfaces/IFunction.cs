using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseCode.Interfaces
{
    public interface IFunction
    {
        /// <summary>
        /// 自己的做法
        /// </summary>
        public void solve1();

        /// <summary>
        /// 書的做法
        /// </summary>
        public void solve2();

        /// <summary>
        /// 測試結果
        /// </summary>
        public void test();
    }
}
