using System;
using System.Net.Http.Headers;

namespace FirstUnique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 7, 7, 7, 7, 7, 7, 7 };
            FirstUnique firstUnique = new FirstUnique(nums);
            Console.WriteLine(firstUnique.ShowFirstUnique());
            firstUnique.Add(7);
            firstUnique.Add(3);
            firstUnique.Add(3);
            firstUnique.Add(7);
            firstUnique.Add(17);
            Console.WriteLine(firstUnique.ShowFirstUnique());

            //TestDoubleLinkedList();
        }

        static void TestDoubleLinkedList()
        {
            DoubleLinkedList MyList = new DoubleLinkedList();

            MyList.DisplayNode(MyList.Head, "Head");

            MyList.InsertFirst(2);
            MyList.InsertFirst(1);
            MyList.InsertLast(3);
            MyList.InsertLast(4);
            MyList.InsertFirst(5);
            MyList.InsertLast(5);
            MyList.InsertLast(5);
            MyList.InsertFirst(0);
            MyList.InsertLast(6);
            MyList.InsertLast(7);
            MyList.InsertLast(8);
            MyList.InsertLast(9);


            MyList.DisplayNode(MyList.Head, "Head");

            MyList.DisplayNode(MyList.Head.Next, "Next");

            MyList.DisplayNode(MyList.Head.Prev, "Prev");

            MyList.DisplayNode(MyList.GetLastNode(), "Last Node");

            MyList.DisplayAllNodes(MyList.Head);

            MyList.DeleteNode(MyList.Head.Next);

            MyList.DisplayAllNodes(MyList.Head);

            MyList.DeleteNode(MyList.GetLastNode());

            MyList.DisplayAllNodes(MyList.Head);

            MyList.DeleteNode(MyList.GetLastNode().Prev);

            MyList.DisplayAllNodes(MyList.Head);

            MyList.DeleteNode(MyList.Head);

            MyList.DisplayAllNodes(MyList.Head);

            MyList.DeleteNodeKey(MyList.Head, 5);

            MyList.DisplayAllNodes(MyList.Head);

            MyList.DeleteNodeKey(MyList.Head, 1);

            MyList.DisplayAllNodes(MyList.Head);

            MyList.DeleteNodeKey(MyList.Head, 8);

            MyList.DisplayAllNodes(MyList.Head);

            MyList.AddAfter(MyList.FindNextNodeKey(3), 9);

            MyList.DisplayAllNodes(MyList.Head);

            Console.WriteLine($"Does 5 exist: {MyList.DoesKeyExist(5)}");

            Console.WriteLine($"Does 9 exist: {MyList.DoesKeyExist(9)}");
        }


    }
}
