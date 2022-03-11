using ExerciseCode.Interfaces;
using ExerciseCode.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseCode.LeetCode
{
    class MiddleOfTheLinkedList : IFunction
    {
        public void solve1()
        {
            
        }

        public void solve2()
        {
            var node = inputNode(new int[] { 1, 2, 3, 4, 5 });
            var node1 = getMiddle1(node);
            Console.WriteLine($"Mid Link(Fun 1) : {printNodes(node1)}");

            var node2 = getMiddle2(node);
            Console.WriteLine($"Mid Link(Fun 2) : {printNodes(node2)}");



        }


        private string printNodes(ListNode node)
        {
            var str = "";
            while(node != null)
            {
                if (!string.IsNullOrWhiteSpace(str)) str += ", ";
                str += node.val;
                node = node.next;
            }

            return $"[{str}]";
        }

        private ListNode getMiddle1(ListNode node)
        {
            var cur = node;
            int count = 0;
            while(cur != null)
            {
                count++;
                cur = cur.next;
            }

            ListNode res = node;
            for (int i = 0; i < count/2; i++)
            {
                res = res.next;
            }

            return res;
        }

        private ListNode getMiddle2(ListNode node)
        {
            var fast = node;
            var slow = node;

            while(fast !=null && fast.next!= null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }


            return slow;
        }

        public void test()
        {
            Console.WriteLine("LeetCode Middle Of The Linked List:");
            solve2();

            Console.WriteLine("");
        }

        private ListNode inputNode(int[] data)
        {
            var cur = new ListNode(data[0]);
            var node = cur;

            for (int i = 1; i < data.Length; i++)
            {
                cur.next = new ListNode(data[i]);
                cur = cur.next;
            }
            return node;
        }
    }
}
