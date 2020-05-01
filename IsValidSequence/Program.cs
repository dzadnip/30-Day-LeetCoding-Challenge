using System;

namespace IsValidSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            //root = [0, 1, 0, 0, 1, 0, null, null, 1, 0, 0]
            //arr = [0, 1, 0, 1]
            //true

            TreeNode root = new TreeNode(0, 
                new TreeNode(1, 
                    new TreeNode(0,
                        null, 
                        new TreeNode(1)
                    ), 
                    new TreeNode(1,
                        new TreeNode(0), 
                        new TreeNode(0)
                    )
                ),
                new TreeNode(0,
                    new TreeNode(0), 
                    null
                )
            );

            int[] arr = new int[] { 0, 1, 0, 1 };


            Console.WriteLine(IsValidSequence(root, arr));


            //root = [0,1,0,0,1,0,null,null,1,0,0]
            //arr =[0,1,1]
            //false

            arr = new int[] { 0, 1, 1 };

            Console.WriteLine(IsValidSequence(root, arr));

            //root = [2,9,3,null,1,null,2,null,8]
            //arr = [2,9,1,8,0]
            //false

            root = new TreeNode(2,
                new TreeNode(9,
                    null,
                    new TreeNode(1,
                        null,
                        new TreeNode(8)
                    )
                ),
                new TreeNode(3,
                    null,
                    new TreeNode(2)
                )
            );

            arr = new int[] { 2, 9, 1, 8, 0 };

            Console.WriteLine(IsValidSequence(root, arr));

        }

        public static bool IsValidSequence(TreeNode root, int[] arr)
        {
            return DoesValMatch(root, arr, 0);
        }

        public static bool DoesValMatch(TreeNode node, int[] arr, int step)
        {
            if (node.val == arr[step])
            {
                bool left = false;
                bool right = false;
                if (node.left != null && step < arr.Length -1)
                {
                    left = DoesValMatch(node.left, arr, step + 1);
                }
                if (node.right != null && step < arr.Length -1)
                {
                    right = DoesValMatch(node.right, arr, step + 1);
                }
                if (node.left == null && node.right == null)
                {
                    if (step == arr.Length - 1)
                    {
                        left = true;
                        right = true;
                    }
                }
                if (left == true || right == true)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
