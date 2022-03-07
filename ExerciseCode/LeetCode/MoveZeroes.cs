using ExerciseCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseCode.LeetCode
{
    class MoveZeroes : IFunction
    {
        public void solve1()
        {
            
        }

        public void solve2()
        {
            var inputs1 = new int[] { 3, 0, 1, 0, 12 };
            Console.Write($"[{string.Join(", ", inputs1)}](fun1) > ");
            getMoveZero1(inputs1);
            Console.WriteLine($"[{string.Join(", ", inputs1)}] ");

            var inputs2 = new int[] { 3, 0, 1, 0, 12 };
            Console.Write($"[{string.Join(", ", inputs2)}](fun2) > ");
            getMoveZero2(inputs2);
            Console.WriteLine($"[{string.Join(", ", inputs2)}] ");


            var inputs3 = new int[] { 3, 0, 1, 0, 12 };
            Console.Write($"[{string.Join(", ", inputs3)}](fun3) > ");
            getMoveZero3(inputs3);
            Console.WriteLine($"[{string.Join(", ", inputs3)}] ");
        }

        private void getMoveZero1(int[] arr)
        {
            while(true)
            {
                var isOk = true;
                for (int i = 0; i + 1 < arr.Length; i++)
                {
                    if (arr[i] == 0 && arr[i + 1] != 0)
                    {
                        isOk = false;
                        arr[i] = arr[i + 1];
                        arr[i + 1] = 0;
                    }
                }
                if (isOk) break;
            } 
        }

        private void getMoveZero2(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                {
                    for (int j = i; j + 1 < arr.Length; j++)
                    {
                        arr[j] = arr[j + 1];
                    }
                    arr[arr.Length - 1] = 0;
                }
            }
        }

        private void getMoveZero3(int[] arr)
        {
            var j = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != 0)
                {
                    arr[j] = arr[i];
                    j++;
                }
            }

            while (j < arr.Length)
            {
                arr[j] = 0;
                j++;
            }
        }

        public void test()
        {
            Console.WriteLine("LeetCode Move Zeroes:");
            solve2();

            Console.WriteLine("");
        }
    }
}
