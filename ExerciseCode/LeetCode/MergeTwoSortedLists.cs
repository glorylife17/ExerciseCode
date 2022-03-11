using ExerciseCode.Interfaces;
using ExerciseCode.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseCode.LeetCode
{
    class MergeTwoSortedLists : IFunction
    {
        public void solve1()
        {
           
        }

        private ListNode getNode(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;

            if (l1.val <= l2.val)
            {
                l1.next = getNode(l1.next, l2);
                return l1;
            }
            else
            {
                l2.next = getNode(l1, l2.next);
                return l2;
            }
        }

        public void solve2()
        {
            var l1 = new ListNode(1, new ListNode(2, new ListNode(3)));
            var l2 = new ListNode(1, new ListNode(3, new ListNode(4)));
            var cur = getNode(l1, l2);

            var arr = new List<int>();
            while (cur != null)
            {
                arr.Add(cur.val);
                cur = cur.next;
            }

            Console.WriteLine($"[{string.Join(",", arr)}]");
        }

        public void test()
        {
            Console.WriteLine("LeetCode Happy Number:");
            solve2();

            Console.WriteLine("");
        }
    }
}
