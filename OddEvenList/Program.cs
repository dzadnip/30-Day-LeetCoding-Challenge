using System;
using System.Collections.Generic;

namespace OddEvenList
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] list = new int[] { 1, 2, 3, 4, 5 };

            ListNode head = new ListNode(list[list.Length -1], null);

            for (int i = list.Length - 1; i > 0; i--)
            {
                ListNode tempHead = head;
                head = new ListNode(i, tempHead);
            }

            DisplayListNode(head, "Input: ");
            // expected 1,3,5,2,4
            DisplayListNode(OddEvenList(head), "Output: ");

            Console.WriteLine();

            list = new int[] { 2, 1, 3, 5, 6, 4, 7 };

            head = new ListNode(list[list.Length - 1], null);

            for (int i = list.Length - 1; i > 0; i--)
            {
                ListNode tempHead = head;
                head = new ListNode(i, tempHead);
            }

            DisplayListNode(head, "Input: ");
            // 2,3,6,7,1,5,4
            DisplayListNode(OddEvenList2(head), "Output: ");

            Console.WriteLine();

            list = new int[] { 1, 2, 3, 4, 5 };

            head = new ListNode(list[list.Length - 1], null);

            for (int i = list.Length - 1; i > 0; i--)
            {
                ListNode tempHead = head;
                head = new ListNode(i, tempHead);
            }

            DisplayListNode(head, "Input: ");
            // expected 1,3,5,2,4
            DisplayListNode(OddEvenList3(head), "Output: ");

            Console.WriteLine();

            list = new int[] { 2, 1, 3, 5, 6, 4, 7 };

            head = new ListNode(list[list.Length - 1], null);

            for (int i = list.Length - 1; i > 0; i--)
            {
                ListNode tempHead = head;
                head = new ListNode(i, tempHead);
            }

            DisplayListNode(head, "Input: ");
            // 2,3,6,7,1,5,4
            DisplayListNode(OddEvenList4(head), "Output: ");
        }

        public static void DisplayListNode(ListNode head, string note)
        {
            Console.Write(note);
            while (head.next != null)
            {
                Console.Write($"{head.val}, ");
                head = head.next;
            }
            Console.Write(head.val);
            Console.WriteLine();

        }

        // Copied from discussion area
        public static ListNode OddEvenList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            var odd = head;
            var even = head.next;
            var evenHead = head.next;
            while (true)
            {
                odd.next = even.next;
                if (odd.next == null)
                    break;
                odd = odd.next;
                even.next = odd.next;
                even = even.next;
                if (even == null)
                    break;
            }
            odd.next = evenHead;
            return head;
        }

        public static ListNode OddEvenList2(ListNode head)
        {
            if (head == null)
                return head;

            var headEven = OddEvenList2(head, head.next);
            var headOdd = head;
            while (head.next != null)
            {
                head = head.next;
            }
            head.next = headEven;
            return headOdd;
        }

        private static ListNode OddEvenList2(ListNode node, ListNode nextNode)
        {
            if (nextNode == null)
            {
                return nextNode;
            }
            node.next = OddEvenList2(nextNode, nextNode.next);
            return nextNode;
        }

        // Runtime Distribution
        public static ListNode OddEvenList3(ListNode head)
        {

            if (head == null) return null;

            ListNode odd = head;
            ListNode even = head.next;
            ListNode evenhead = even;

            while (even != null && even.next != null)
            {
                odd.next = even.next;
                odd = even.next;
                even.next = odd.next;
                even = odd.next;
            }

            odd.next = evenhead;

            return head;
        }

        // Memory Distribution

        public static ListNode OddEvenList4(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            var odd = head;
            var rslt = head;
            var even = head.next;
            var temp = even;
            head = even.next;
            while (head != null)
            {
                odd.next = head;
                head = head != null ? head.next : null;
                even.next = head;
                head = head != null ? head.next : null;
                odd = odd.next == null ? odd : odd.next;
                even = even.next;
            }
            odd.next = temp;
            return rslt;
        }
    }
}
