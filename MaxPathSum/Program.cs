using System;

namespace MaxPathSum
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(1, new TreeNode(2), new TreeNode(3));

            Console.WriteLine(MaxPathSum3(root));

            root = new TreeNode(-10, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7)));

            Console.WriteLine(MaxPathSum3(root));
        }

        public static int MaxPathSum(TreeNode root)
        {
            int max = int.MinValue;
            FindMax(root, ref max);
            return max;
        }

        public static int FindMax(TreeNode node, ref int max)
        {
            if (node == null) return 0;
            int left = Math.Max(0, FindMax(node.left, ref max));
            int right = Math.Max(0, FindMax(node.right, ref max));
            max = Math.Max(max, left + node.val + right);
            return node.val + Math.Max(left, right);
        }


        // Runtime Distribution
        public static int MaxPathSum2(TreeNode root)
        {
            if (root == null) return 0;
            int maxSum = int.MinValue;
            MaxPathSum(root, ref maxSum);
            return maxSum;
        }

        private static int MaxPathSum(TreeNode root, ref int maxSum)
        {
            if (root == null) return 0;
            int sum = root.val;
            int l = MaxPathSum(root.left, ref maxSum);
            int r = MaxPathSum(root.right, ref maxSum);
            if (l > 0) sum += l;
            if (r > 0) sum += r;
            maxSum = Math.Max(maxSum, sum);
            return Math.Max(l, r) > 0 ? Math.Max(l, r) + root.val : root.val;
        }


        // Memory Distribution
        public static int maxvalue = int.MinValue;
        public static int MaxPathSum3(TreeNode root)
        {
            MaxSum(root);

            return maxvalue;
        }

        private static int MaxSum(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            if (root.left == null && root.right == null)
            {
                maxvalue = Math.Max(maxvalue, root.val);
                return root.val;
            }

            var lSum = Math.Max(0, MaxSum(root.left));
            var rSum = Math.Max(0, MaxSum(root.right));

            maxvalue = Math.Max(maxvalue, lSum + rSum + root.val);

            return Math.Max(lSum, rSum) + root.val; ;
        }

    }
}
