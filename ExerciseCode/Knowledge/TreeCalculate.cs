using ExerciseCode.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseCode.Knowledge
{
    public class TreeCalculate
    {
        public TreeCalculate()
        {

        }

        /// <summary>
        /// 前序走訪
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int[] preTraversal(TreeNode root)
        {
            if (root == null) return new int[0];

            var res = new List<int>();
            addPreNode(root, res);

            return res.ToArray();
        }

        private void addPreNode(TreeNode root, List<int> res)
        {
            if (root == null) return;

            res.Add(root.val);
            addPreNode(root.left, res);
            addPreNode(root.right, res);
        }



        /// <summary>
        /// 中序走訪(遞迴)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int[] inTraversal_Recursive(TreeNode root)
        {
            if (root == null) return new int[0];

            var res = new List<int>();
            addInNode_Recursive(root, res);

            return res.ToArray();
        }

        private void addInNode_Recursive(TreeNode root, List<int> res)
        {
            if (root == null) return;

            addInNode_Recursive(root.left, res);
            res.Add(root.val);
            addInNode_Recursive(root.right, res);
        }

        /// <summary>
        /// 中序走訪(迭代)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int[] inTraversal_Iterate(TreeNode root)
        {
            if (root == null) return new int[0];

            var res = new List<int>();
            var stack = new Stack<TreeNode>();

            while (root != null || stack.Count != 0)
            {
                if (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
                else
                {
                    var node = stack.Pop();
                    res.Add(node.val);
                    root = node.right;
                }
            }

            return res.ToArray();
        }

        /// <summary>
        /// 中序走訪(Morris)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int[] inTraversal_Morris(TreeNode root)
        {
            if (root == null) return new int[0];

            var res = new List<int>();

            while (root != null)
            {
                if (root.left != null)
                {
                    var pre = root.left;

                    while (pre.right != null)
                    {
                        pre = pre.right;
                    }

                    pre.right = root;

                    var tmp = root;
                    root = root.left;

                    tmp.left = null;
                }
                else
                {
                    res.Add(root.val);
                    root = root.right;
                }
            }

            return res.ToArray();
        }


        /// <summary>
        /// 後續走訪
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int[] postTraversal(TreeNode root)
        {
            if (root == null) return new int[0];

            var res = new List<int>();
            addPostNode(root, res);

            return res.ToArray();
        }

        private void addPostNode(TreeNode root, List<int> res)
        {
            if (root == null) return;

            addPostNode(root.left, res);
            addPostNode(root.right, res);
            res.Add(root.val);
        }

    }
}
