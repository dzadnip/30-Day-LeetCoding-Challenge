using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;

namespace MiddleNode
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] nodes = new int[] { 1, 2, 3, 4, 5 };
            int[] nodes = new int[] { 1, 2, 3, 4, 5, 6 };

            ListNode head = new ListNode(nodes[nodes.Length - 1]);

            for (int i = nodes.Length - 2; i >= 0; i--)
            {
                ListNode newHead = new ListNode(nodes[i]);
                newHead.next = head;
                head = newHead;
            }

            //Console.WriteLine(head.val);
            //while (head.next != null)
            //{
            //    head = head.next;
            //    Console.WriteLine(head.val);
            //}


            Console.WriteLine(MiddleNode(head).val);

        }



        static ListNode MiddleNode(ListNode head)
        {

            int totalNodesCount = TotalNodeCount(head, 0);
            Console.WriteLine($"Total node count is {totalNodesCount}");

            ListNode middleNode = new ListNode(0);

            for (int i = 0; i < totalNodesCount / 2; i++)
            {
                middleNode = head.next;
                head = middleNode;
            }

            return head;
        }


        static int TotalNodeCount(ListNode head, int totalNodesCount)
        {
            totalNodesCount++;
            if (head.next != null)
            {
                totalNodesCount = TotalNodeCount(head.next, totalNodesCount);
            }
            return totalNodesCount;
        }


        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }



        public ListNode MiddleNode1(ListNode head)
        {
            if (head == null) return null;
            int size = 0;
            ListNode curr = head;
            while (curr != null)
            {
                curr = curr.next;
                size++;
            }
            int mid = size / 2;
            curr = head;
            for (int i = 0; i < mid; i++)
                curr = curr.next;
            return curr;
        }


        // I like this one
        public ListNode MiddleNode2(ListNode head)
        {
            ListNode slow = head, fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow;
        }


        public ListNode MiddleNode3(ListNode head)
        {
            ListNode jumper = head;
            while ((jumper = jumper?.next) != null)
            {
                head = head.next;
                jumper = jumper.next;
            }
            return head;
        }

        public ListNode MiddleNode4(ListNode head)
        {
            if (head == null) return null;
            if (head.next == null) return head;
            if (head.next.next == null) return head.next;
            ListNode slow = head;
            ListNode fast = head.next.next;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow.next;

        }


        public ListNode MiddleNode5(ListNode head)
        {

            var current = head;

            var counter = 0;

            while (current != null)
            {
                counter++;
                current = current.next;
            }

            var counter2 = 0;
            current = head;

            while (counter2 != counter / 2)
            {
                counter2++;
                current = current.next;
            }

            return current;
        }

    }
}
