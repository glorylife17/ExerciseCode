using ExerciseCode.Interfaces;
using ExerciseCode.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseCode.LeetCode
{
    class ConvertSortedArrayToBinarySearchTree : IFunction
    {
        public void solve1()
        {
            
        }

        public void solve2()
        {
            var nodes = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            var dd1 = SortedArrayToBST1(nodes);
            var dd2 = SortedArrayToBST2(nodes);
        }

        static TreeNode SortedArrayToBST1(int[] nums)
        {
            if (nums.Length == 0) return null;
            if (nums.Length == 1) return new TreeNode(nums[0]);
            var n = nums.Length / 2;

            TreeNode root = new TreeNode(nums[n]);
            var l = new List<int>();
            for (int i = 0; i < n; i++)
            {
                l.Add(nums[i]);
            }
            root.left = SortedArrayToBST1(l.ToArray());

            var r = new List<int>();
            for (int i = n + 1; i < nums.Length; i++)
            {
                r.Add(nums[i]);
            }
            root.right = SortedArrayToBST1(r.ToArray());

            return root;
        }

        static TreeNode SortedArrayToBST2(int[] nums)
        {
            var root = getTreeNodes(nums, 0, nums.Length - 1);

            return root;
        }

        private static TreeNode getTreeNodes(int[] nums, int left, int right)
        {
            if (left > right) return null;

            var mid = left + (right - left) / 2;
            var node = new TreeNode(nums[mid]);
            node.left = getTreeNodes(nums, left, mid - 1);
            node.right = getTreeNodes(nums, mid + 1, right);

            return node;
        }

        public void test()
        {
            Console.WriteLine("LeetCode Convert Sorted Array To Binary Search Tree:");
            solve2();

            Console.WriteLine("");
        }
    }
}
