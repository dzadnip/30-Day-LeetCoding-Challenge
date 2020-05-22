using System;
using System.Collections.Generic;
using System.Linq;

namespace KthSmallest
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(
                3, 
                new TreeNode(
                    1, 
                    null, 
                    new TreeNode(2)
                    ), 
                new TreeNode(4)
                );
            int k = 1;
            Console.WriteLine(KthSmallest(root, k));
            Console.WriteLine(KthSmallest3(root, k));

            root = new TreeNode(
                5,
                new TreeNode(
                    3, 
                    new TreeNode(
                        2, 
                        new TreeNode(1), 
                        null
                        ), 
                    new TreeNode(4)
                    ),
                new TreeNode(6)
                );
            k = 3;
            Console.WriteLine(KthSmallest2(root, k));
            Console.WriteLine(KthSmallest4(root, k));

        }

        // Copied from discussion area
        public static int KthSmallest(TreeNode root, int k)
        {
            IEnumerable<int> traverse(TreeNode r)
            {
                if (r != null)
                {
                    foreach (var n in traverse(r.left)) yield return n;
                    yield return r.val;
                    foreach (var n in traverse(r.right)) yield return n;
                }
            }

            return traverse(root).ElementAt(k - 1);
        }

        // Runtime distribution
        static int ele = -1;
        static int i = 0;
        public static int KthSmallest2(TreeNode root, int k)
        {
            KthSmallest2Helper(root, k);
            return ele;
        }

        public static void KthSmallest2Helper(TreeNode root, int k)
        {
            if (root.left != null) KthSmallest2Helper(root.left, k);
            //Console.Write(root.val+" ");
            i++;
            if (i == k)
            {
                ele = root.val;
                return;
            }
            if (root.right != null) KthSmallest2Helper(root.right, k);
        }

        public static int KthSmallest3(TreeNode root, int k)
        {
            var nums = new int[2];
            InOrder(root, nums, k);
            return nums[1];
        }

        private static void InOrder(TreeNode root, int[] nums, int k)
        {
            if (root == null)
            {
                return;
            }

            InOrder(root.left, nums, k);
            if (++nums[0] == k)
            {
                nums[1] = root.val;
                return;
            }
            InOrder(root.right, nums, k);
        }

        //Memory Distribution
        public static int KthSmallest4(TreeNode root, int k)
        {
            var node = root;
            Stack<TreeNode> s = new Stack<TreeNode>();
            int count = 0;
            TreeNode kthNode = root;

            while (node != null || s.Count > 0)
            {
                if (node != null)
                {
                    s.Push(node);
                    node = node.left;
                    continue;
                }

                var current = s.Pop();
                count++;
                if (count == k)
                {
                    kthNode = current;
                    break;
                }

                if (current.right != null)
                {
                    node = current.right;
                }
            }

            return kthNode.val;
        }

    }
}
