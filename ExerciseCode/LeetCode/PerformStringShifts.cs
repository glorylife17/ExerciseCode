using ExerciseCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExerciseCode.LeetCode
{
    class PerformStringShifts : IFunction
    {
        /*
            Input: s = "abc", shift = [[0,1],[1,2]]
            Output: "cab"
            Explanation: 
            [0,1] means shift to left by 1. "abc" -> "bca"
            [1,2] means shift to right by 2. "bca" -> "cab"
         */

        public void solve1()
        {
            throw new NotImplementedException();
        }

        public void solve2()
        {
            var str = "abc";
            var shift = new List<List<int>>() {  new List<int> { 0, 1 }, new List<int> { 1, 2 } };

            Console.WriteLine($"{str} l>1; r>2 (暴力法) : {stringShift1(str, shift)}");
            Console.WriteLine($"{str} l>1; r>2 (算總數與空間換時間) : {stringShift2(str, shift)}");
            Console.WriteLine($"{str} l>1; r>2 (字串反轉): {stringShift3(str, shift)}");
            
        }

        private string stringShift3(string str, List<List<int>> shift)
        {
            var chars = str.ToCharArray();
            var totalMove = 0;

            for (int i = 0; i < shift.Count; i++)
            {
                var direction = shift[i][0];
                var move = shift[i][1];

                if (direction == 0)
                {
                    totalMove += move;
                }
                else
                {
                    totalMove += str.Length - move;
                }
            }

            totalMove = totalMove % str.Length;

            // 不增加空間的話
            // 字串反轉的觀察  str: abcdefg shift:3
            // abc|defg => cba|defg
            // cba|defg => cba|gfed
            // cba|gfed => defg|abc
            
            chars = reverse(chars, 0, totalMove);
            chars = reverse(chars, totalMove, str.Length);
            chars = reverse(chars, 0, str.Length);

            return string.Join("", chars);
        }

        private char[] reverse(char[] chars, int left, int right)
        {
            right--;
            while (left < right)
            {
                var tmp = chars[left];
                chars[left] = chars[right];
                chars[right] = tmp;

                left++;
                right--;
            }
            return chars;
        }

        private string stringShift2(string str, List<List<int>> shift)
        {
            var chars = str.ToCharArray();
            var totalMove = 0;

            for (int i = 0; i < shift.Count; i++)
            {
                var direction = shift[i][0];
                var move = shift[i][1];

                // 試著將迴圈變少，這兩個迴圈某個程度上意義相同
                // 向左移 1位  == 向右移 字串長度-1位
                // abc  >> 1 : bca  / abc << (3-1) : bca

                if (direction == 0)
                {
                    totalMove += move;
                }
                else
                {
                    totalMove += str.Length - move;
                }
            }

            totalMove = totalMove % str.Length;

            // 製造一個原資料的空間，做為資料的偏移交替
            //     [a,b,c,d,e,f,g]   shift:3   str.length:7
            //      0,1,2,3,4,5,6 
            // +3:  3,4,5,6,7,8,9 
            // % :  3,4,5,6,0,1,2 
            //      d,e,f,g,a,b,c
            var tmp = str.ToCharArray();

            for (int k = 0; k < chars.Length; k++)
            {
                chars[k] = tmp[(k + totalMove) % str.Length];
            }

            return string.Join("", chars);
        }

        private string stringShift1(string str, List<List<int>> shift)
        {
            var chars = str.ToCharArray();

            for (int i = 0; i < shift.Count; i++)
            {
                var direction = shift[i][0];
                var move = shift[i][1];

                if(direction ==0)
                {
                    //left
                    for (int j = 0; j < move; j++)
                    {
                        var tmp = chars[0];
                        for (int k = 0; k < chars.Length-1; k++)
                        {
                            chars[k] = chars[k + 1];
                        }
                        chars[chars.Length - 1] = tmp;
                    }
                }
                else
                {
                    //right
                    for (int j = 0; j < move; j++)
                    {
                        var tmp = chars[chars.Length - 1];
                        for (int k = chars.Length - 1; k >=1; k--)
                        {
                            chars[k] = chars[k - 1];
                        }
                        chars[0] = tmp;
                    }
                }
            }


            return string.Join("", chars);
        }

        public void test()
        {
            Console.WriteLine("LeetCode Perform String Shifts:");
            solve2();

            Console.WriteLine("");
        }
    }
}
