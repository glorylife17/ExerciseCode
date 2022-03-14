using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseCode.Knowledge
{
    class DemailCalculate
    {
        public DemailCalculate()
        {
            Console.WriteLine("位元計算:");

            Console.WriteLine("\n邏輯 OR 運算子 | :");
            Console.WriteLine($" 0 | 0 : {0b_0 | 0b_0}");   //0
            Console.WriteLine($" 0 | 1 : {0b_0 | 0b_1}");   //1
            Console.WriteLine($" 1 | 0 : {0b_1 | 0b_0}");   //1
            Console.WriteLine($" 1 | 1 : {0b_1 | 0b_1}");   //1

            Console.WriteLine("\n邏輯互斥 OR 運算子 ^:");
            Console.WriteLine($" 0 ^ 0 : {0b_0 ^ 0b_0}");   //0
            Console.WriteLine($" 0 ^ 1 : {0b_0 ^ 0b_1}");   //1
            Console.WriteLine($" 1 ^ 0 : {0b_1 ^ 0b_0}");   //1
            Console.WriteLine($" 1 ^ 1 : {0b_1 ^ 0b_1}");   //0

            Console.WriteLine("\n邏輯 AND 運算子 &:");
            Console.WriteLine($" 0 & 0 : {0b_0 & 0b_0}");   //0
            Console.WriteLine($" 0 & 1 : {0b_0 & 0b_1}");   //1
            Console.WriteLine($" 1 & 0 : {0b_1 & 0b_0}");   //1
            Console.WriteLine($" 1 & 1 : {0b_1 & 0b_1}");   //1

            Console.WriteLine("\n位元補充運算子 ~:");
            Console.WriteLine($" ~0 : {Convert.ToString(~0b_0, toBase: 2)}");   //1
            Console.WriteLine($" ~1 : {Convert.ToString(~0b_1, toBase: 2)}");   //0


            Console.WriteLine("\n左移運算子 <<:");
            Console.WriteLine($" 0 : {Convert.ToString(0b_0 << 1, toBase: 2)}");   //0
            Console.WriteLine($" 1 : {Convert.ToString(0b_1 << 1, toBase: 2)}");   //10

            Console.WriteLine("\n右移運算子 >>:");
            Console.WriteLine($" 0 : {Convert.ToString(0b_0 >> 1, toBase: 2)}");   //0
            Console.WriteLine($" 10 : {Convert.ToString(0b_10 >> 1, toBase: 2)}");   //1


            var a1 = "110";
            var a2 = "11";


            Console.WriteLine(AddBinary1(a1,a2));
            Console.WriteLine(AddBinary2(a1,a2));
            var ddd = StringToBinaryBigInteger(a1);
 
        }

        public string AddBinary1(string a1, string a2)
        {
            var n = a1.Length > a2.Length ? a1.Length : a2.Length;

            var carry = 0;
            var res = "";

            for (var i = 0; i < n; i++)
            {
                var b1 = a1.Length > i ? a1[a1.Length - i - 1].ToString() : "0";
                var b2 = a2.Length > i ? a2[a2.Length - i - 1].ToString() : "0";

                if (b1 == b2)
                {
                    if (carry > 0)
                    {
                        res = "1" + res;
                        carry = 0;
                    }
                    else
                    {
                        res = "0" + res;
                    }

                    if (b1 == "1")
                    {
                        carry++;
                    }
                }
                else
                {
                    if (carry > 0)
                    {
                        res = "0" + res;
                    }
                    else
                    {
                        res = "1" + res;
                    }

                }
            }

            if (carry > 0)
            {
                res = "1" + res;
                carry = 0;
            }
            return res;
        }

        public string AddBinary2(string a, string b)
        {
            var res = "";
            int i = a.Length - 1;
            int j = b.Length - 1;
            int carry = 0;
            while (i >= 0 || j >= 0)
            {
                int sum = carry;

                if (i >= 0) sum += a[i--] - '0';
                if (j >= 0) sum += b[j--] - '0';

                carry = sum > 1 ? 1 : 0;

                res = $"{(sum % 2).ToString()}{res}";
            }
            if (carry != 0) res = $"{(carry % 2).ToString()}{res}";

            return res.ToString();
        }

        private Int32 StringToBinaryBigInteger(string binary)
        {
            Int32 result = 0;

            foreach (char c in binary)
            {
                result <<= 1;
                result += c == '1' ? 1 : 0;
            }

            return result;
        }
    }
}
