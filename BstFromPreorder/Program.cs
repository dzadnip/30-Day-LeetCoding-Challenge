using System;

namespace BstFromPreorder
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input: [8, 5, 1, 7, 10, 12]
            //Output: [8, 5, 10, 1, 7, null, 12]

            int[] preorder = new int[] { 8, 5, 1, 7, 10, 12 };

            TreeNode head = BstFromPreorder(preorder);
        }

        // I did not know how to do this, so used example from discussion area

        static TreeNode BstFromPreorder(int[] preorder)
        {
            if (preorder == null)
                return null;
            // root node will always be first node in preorder traversal
            TreeNode root = new TreeNode(preorder[0]);

            // If we simply just insert all nodes in array 
            // using standard way of inserting node in BST it will give us original tree.

            for (int x = 1; x < preorder.Length; x++)
                InsertInBST(root, preorder[x]);

            return root;
        }
        // standard BST insertion. 
        static void InsertInBST(TreeNode root, int val)
        {
            TreeNode current = root;
            TreeNode parent = null;
            while (current != null)
            {
                parent = current;
                current = current.val > val ? current.left : current.right;
            }

            if (parent.val > val)
                parent.left = new TreeNode(val);
            else
                parent.right = new TreeNode(val);
        }


        // interesting recursive solution
        int i = 0;
        public TreeNode BstFromPreorder2(int[] preorder, int max = int.MaxValue)
        {
            if (i >= preorder.Length || preorder[i] > max) return null;
            var val = preorder[i++];
            return new TreeNode(val) { left = BstFromPreorder2(preorder, val), right = BstFromPreorder2(preorder, max) };
        }

        // another interesting solution
        public TreeNode BstFromPreorder3(int[] preorder)
        {
            if (preorder == null || preorder.Length == 0) return null;
            return helper(preorder, 0, preorder.Length);

        }

        public TreeNode helper(int[] preorder, int rootindex, int right)
        {
            if (rootindex >= right) return null;

            int value = preorder[rootindex];
            TreeNode root = new TreeNode(value);

            int i = rootindex + 1;
            // find the left subtree of current node
            while (i <= preorder.Length - 1 && preorder[i] < value)
            {
                i++;
            }
            //do the same thing for left and right subtree.
            root.left = helper(preorder, rootindex + 1, i);
            root.right = helper(preorder, i, right);

            return root;
        }

    }
}
