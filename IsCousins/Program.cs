using System;
using System.Collections.Generic;

namespace IsCousins
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input: root = [1, 2, 3, null, 4, null, 5], x = 5, y = 4
            //Output: true

            TreeNode root = new TreeNode(
                    1,
                    new TreeNode(
                        2,
                        null,
                        new TreeNode(4)
                    ),
                    new TreeNode(
                        3,
                        null,
                        new TreeNode(5)
                    )
                );
            int x = 5;
            int y = 4;
            Console.WriteLine(IsCousins2(root, x , y));



            //Input: root = [1, 2, 3, 4], x = 4, y = 3
            //Output: false

            root = new TreeNode(
                    1,
                    new TreeNode(
                        2,
                        new TreeNode(
                            4
                        ),
                        null
                    ),
                    new TreeNode (
                        3
                    )
                );
            x = 4;
            y = 3;
            Console.WriteLine(IsCousins4(root, x, y));



            //Input: root = [1, 2, 3, null, 4], x = 2, y = 3
            //Output: false

            root = new TreeNode(
                    1,
                    new TreeNode(
                        2,
                        null,
                        new TreeNode(
                            4
                        )
                    ),
                    new TreeNode(
                        3
                    )
                );
            x = 2;
            y = 3;
            Console.WriteLine(IsCousins5(root, x, y));
        }

        static bool IsCousins(TreeNode root, int x, int y)
        {
            // I'm not familiar yet with BFS and DFS solutions for traversing Binary Trees.
            // Neeeded help from the experts in Discusison Area.
            return true;
        }



        // Discussion Area

        static bool IsCousins2(TreeNode root, int x, int y)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>(new[] { root });
            while (queue.Count > 0)
            {
                for (int i = queue.Count, iX = 0, iY = 0; i > 0; i--)
                {
                    TreeNode node = queue.Dequeue();
                    if (node == null) continue;
                    if (node.val == x) iX = i;
                    if (node.val == y) iY = i;
                    if (iX > 0 && iY > 0)
                        return Math.Abs(iX - iY) > 1 || Math.Min(iX, iY) % 2 == 0;
                    queue.Enqueue(node.left);
                    queue.Enqueue(node.right);
                }
            }
            return false;
        }


        static int parentX = -1;
        static int parentY = -1;
        static int depthX = -1;
        static int depthY = -1;
        static bool IsCousins3(TreeNode root, int x, int y)
        {
            Find(root, x, y, 0);
            if (depthX == depthY && parentX != parentY)
                return true;
            return false;
        }

        static void Find(TreeNode root, int x, int y, int depth)
        {
            if (root == null)
                return;
            if (root.left != null && root.left.val == x || root.right != null && root.right.val == x)
            {
                depthX = depth + 1;
                parentX = root.val;
            }
            if (root.left != null && root.left.val == y || root.right != null && root.right.val == y)
            {
                depthY = depth + 1;
                parentY = root.val;
            }
            if (depthX > -1 && depthY > -1)
                return;
            Find(root.left, x, y, depth + 1);
            Find(root.right, x, y, depth + 1);
        }

        // Runtime Distribution
        static bool IsCousins4(TreeNode root, int x, int y)
        {
            return Level(root, x, 0) == Level(root, y, 0) && !IsSibling(root, x, y);
        }

        static int Level(TreeNode root, int target, int level)
        {
            if (root == null)
                return -1;
            if (root.val == target)
                return level;
            int l = Level(root.left, target, level + 1);
            if (l != -1)
            {
                return l;
            }
            else
            {
                return Level(root.right, target, level + 1);
            }
        }

        static bool IsSibling(TreeNode node, int a, int b)
        {
            if (node == null)
                return false;

            if ((node.left != null && node.right != null) && ((node.left.val == a && node.right.val == b)
              || (node.left.val == b && node.right.val == a)))
            {
                return true;
            }
            else
            {
                return (IsSibling(node.left, a, b) || IsSibling(node.right, a, b));
            }
        }

        // Memory Distribution
        static int d1 = 0;
        static int d2 = 0;
        static TreeNode p1 = null;
        static TreeNode p2 = null;

        static bool IsCousins5(TreeNode root, int x, int y)
        {
            if (x == y || root == null) return false;
            DFS(0, null, root, x, y);

            return (d1 == d2 && p1 != p2);

        }

        static void DFS(int depth, TreeNode parent, TreeNode root, int x, int y)
        {
            if (root == null) return;

            if (root.val == x)
            {
                d1 = depth;
                p1 = parent;
            }

            if (root.val == y)
            {
                d2 = depth;
                p2 = parent;
            }

            DFS(depth + 1, root, root.left, x, y);
            DFS(depth + 1, root, root.right, x, y);

        }
    }
}
