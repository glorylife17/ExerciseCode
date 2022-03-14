using ExerciseCode.Models;
using NUnit.Framework;

namespace ExerciseCode.Test
{
    public class TreeCalculate
    {
        Knowledge.TreeCalculate _method;

        [SetUp]
        public void Setup()
        {
            _method = new Knowledge.TreeCalculate();
        }

        private TreeNode _root
        {
            get
            {
                var root = new TreeNode(4);
                root.left = new TreeNode(2);
                root.right = new TreeNode(6);
                root.left.left = new TreeNode(1);
                root.left.right = new TreeNode(3);
                root.right.left = new TreeNode(5);
                root.right.right = new TreeNode(7);
                return root;

                /*
                 *                4
                 *            2       6
                 *          1   3   5   7   
                 */
            }
        }

        [Test]
        public void TreeCalculate_preTraversal_4213657()
        {
            var res = _method.preTraversal(_root);
            var expect = "4213657";

            Assert.AreEqual(expect, string.Join("",res));
        }

        [Test]
        public void TreeCalculate_inTraversal»¼°j_1234567()
        {
            var res = _method.inTraversal_Recursive(_root);
            var expect = "1234567";

            Assert.AreEqual(expect, string.Join("", res));
        }

        [Test]
        public void TreeCalculate_inTraversal­¡¥N_1234567()
        {
            var res = _method.inTraversal_Iterate(_root);
            var expect = "1234567";

            Assert.AreEqual(expect, string.Join("", res));
        }

        [Test]
        public void TreeCalculate_inTraversalMorris_1234567()
        {
            var res = _method.inTraversal_Morris(_root);
            var expect = "1234567";

            Assert.AreEqual(expect, string.Join("", res));
        }

        [Test]
        public void TreeCalculate_postTraversal_1325764()
        {
            var res = _method.postTraversal(_root);
            var expect = "1325764";

            Assert.AreEqual(expect, string.Join("", res));
        }
    }
}