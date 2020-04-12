using System;

namespace DiameterOfBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            //            1
            //           / \
            //          2   3
            //         / \     
            //        4   5
            // Return 3, which is the length of the path [4,2,1,3] or [5,2,1,3].

            TreeNode nodeLeft = ReturnTreeNode(4, null, null);
            TreeNode nodeRight = ReturnTreeNode(5, null, null);
            TreeNode nodeRoot = ReturnTreeNode(2, nodeLeft, nodeRight);


            nodeLeft = nodeRoot;
            nodeRight = ReturnTreeNode(3, null, null);
            nodeRoot = ReturnTreeNode(1, nodeLeft, nodeRight);


            //DisplayNodeVal(nodeRoot);

            Console.WriteLine($"Longest path length is: {DiameterOfBinaryTree(nodeRoot)}");

        }

        static void DisplayNodeVal(TreeNode root)
        {
            Console.WriteLine(root.val);
            if(null != root.left)
            {
                DisplayNodeVal(root.left);
            }
            if (null != root.right)
            {
                DisplayNodeVal(root.right);
            }
        }

        static TreeNode ReturnTreeNode(int val, TreeNode left, TreeNode right)
        {
            TreeNode returnTreeNode = new TreeNode(val);
            if (null != left)
            {
                returnTreeNode.left = left;
            }
            if (null != right)
            {
                returnTreeNode.right = right;
            }
            return returnTreeNode;
        }

        static int DiameterOfBinaryTree01(TreeNode root)
        {
            int longestPath = 1;
            int leftPathLength = 0;
            int rightPathLength = 0;

            Console.WriteLine(root.left.GetType());

            if (root.left != null)
            {
                leftPathLength = DiameterOfBinaryTree01(root.left);
            }

            if (root.right != null)
            {
                rightPathLength = DiameterOfBinaryTree01(root.right);
            }

            if(leftPathLength > longestPath)
            {
                longestPath = leftPathLength;
            }

            if(rightPathLength > longestPath)
            {
                longestPath = rightPathLength;
            }

            if(leftPathLength + rightPathLength > longestPath)
            {
                longestPath = leftPathLength + rightPathLength;
            }

            return longestPath;
        }

        static int DiameterOfBinaryTree02(TreeNode root)
        {
            int longestPath = 0;
            if (root != null)
            {
                int leftLongestPath = 0;
                int rightLongestPath = 0;
                if (root.left != null)
                {
                    leftLongestPath = 1 + DiameterOfBinaryTree02(root.left);
                }

                if (root.right != null)
                {
                    rightLongestPath = 1 + DiameterOfBinaryTree02(root.right);
                }
                if (longestPath + leftLongestPath < longestPath + rightLongestPath)
                {
                    longestPath = longestPath + rightLongestPath;
                } else
                {
                    longestPath = longestPath + leftLongestPath;
                }
            }
            return longestPath;
        }


        // Code I submitted - as seen in discussion area
        private static int maxDiameter;
        public static int DiameterOfBinaryTree(TreeNode root)
        {
            MaxDepth(root);
            return maxDiameter;
        }

        private static int MaxDepth(TreeNode node)
        {
            if (node == null) return 0;
            int maxDepthOfLeftSubTree = MaxDepth(node.left);
            int maxDepthOfRightSubTree = MaxDepth(node.right);
            maxDiameter = Math.Max(maxDiameter, maxDepthOfLeftSubTree + maxDepthOfRightSubTree);
            return Math.Max(maxDepthOfLeftSubTree, maxDepthOfRightSubTree) + 1;
        }


        // Runtime Distribution

        static int max = 0;
        static int DiameterOfBinaryTree1(TreeNode root)
        {
            helper(root);
            return max;

        }

        static int helper(TreeNode root)
        {
            if (root == null) return 0;

            var left = helper(root.left);
            var right = helper(root.right);
            max = Math.Max(right + left, max);
            return Math.Max(left, right) + 1;
        }




        static int res = 0;
        static int DiameterOfBinaryTree2(TreeNode root)
        {
            depth(root);
            return res;
        }

        static int depth(TreeNode root)
        {
            if (root == null) return 0;

            var l = depth(root.left);
            var r = depth(root.right);

            var o = l + r;
            res = Math.Max(o, res);
            return Math.Max(l, r) + 1;
        }


        // This one has the best variable/method names
        private static int maxLength = 0;
        public static int DiameterOfBinaryTree3(TreeNode root)
        {
            if (root == null)
                return 0;
            var maxLengthReceived = CalculateMaxLength(root.left) + CalculateMaxLength(root.right);
            return maxLength > maxLengthReceived ? maxLength : maxLengthReceived;
        }

        private static int CalculateMaxLength(TreeNode node)
        {
            if (node == null)
                return 0;

            var leftLength = CalculateMaxLength(node.left);
            var rightLength = CalculateMaxLength(node.right);

            if ((leftLength + rightLength) > maxLength)
                maxLength = leftLength + rightLength;

            return Math.Max(leftLength, rightLength) + 1;
        }


    }

    //Definition for a binary tree node.
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

}
