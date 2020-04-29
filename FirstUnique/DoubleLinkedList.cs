using System;
using System.Collections.Generic;
using System.Text;

namespace FirstUnique
{
    class DoubleLinkedList
    {
        public DoubleLinkedNode Head { get; set; }

        public DoubleLinkedNode LastNodeInList { get; set; }

        public DoubleLinkedList()
        {

        }

        public DoubleLinkedList (DoubleLinkedNode Node)
        {
            Head = Node;
            LastNodeInList = Head;
        }

        public DoubleLinkedList(int[] Nums)
        {
            if (Nums.Length > 0)
            {
                DoubleLinkedNode NewNode = new DoubleLinkedNode(Nums[0]);
                Head = NewNode;
                LastNodeInList = Head;
                if (Nums.Length > 1)
                {
                    for (int i = 1; i < Nums.Length; i++)
                    {
                        InsertLast(Nums[i]);
                    }
                }
            }            
            
        }

        public void InsertFirst(int Data)
        {
            DoubleLinkedNode NewNode = new DoubleLinkedNode(Data);
            if (Head == null)
            {
                Head = NewNode;
            }
            else
            {
                Head.Prev = NewNode;
                NewNode.Next = Head;
                LastNodeInList = Head;
                Head = NewNode;
            }
        }

        public void InsertLast(int Data)
        {
            DoubleLinkedNode NewNode = new DoubleLinkedNode(Data);
            if (Head == null)
            {
                Head = NewNode;
            } else
            {
                DoubleLinkedNode LastNode = GetLastNode();
                NewNode.Prev = LastNode;
                LastNode.Next = NewNode;
                LastNodeInList = NewNode;
            }
        }

        public void AddAfter(DoubleLinkedNode Node, int Data)
        {
            DoubleLinkedNode TempNode = Node.Next;
            DoubleLinkedNode NewNode = new DoubleLinkedNode(Data);
            NewNode.Next = TempNode;
            Node.Next = NewNode;
        }

        public DoubleLinkedNode GetLastNode()
        {
            DoubleLinkedNode LastNode = Head;
            while (LastNode.Next != null)
            {
                LastNode = LastNode.Next;
            }
            return LastNode;
        }

        public void DeleteNode(DoubleLinkedNode Node)
        {
            if (Node.Prev != null && Node.Next != null)
            {
                Node.Prev.Next = Node.Next;
                Node.Next.Prev = Node.Prev;
            }
            if (Node.Prev != null && Node.Next == null)
            {
                Node.Prev.Next = null;
            }
            if (Node.Prev == null && Node.Next != null)
            {
                Node.Next.Prev = null;
                Head = Node.Next;
            }
            if (Node.Prev == null && Node.Next == null)
            {
                Head = null;
            }
        }

        public void DeleteNodeKey(DoubleLinkedNode Node, int Data)
        {
            if (Node.Data == Data)
            {
                if (Node.Prev != null)
                {
                    if (Node.Next != null)
                    {
                        Node.Prev.Next = Node.Next;
                    } else
                    {
                        Node.Prev.Next = null;
                    }
                }
                if (Node.Next != null)
                {
                    if (Node.Prev != null)
                    {
                        Node.Next.Prev = Node.Prev;
                    } else
                    {
                        Node.Next.Prev = null;
                        Head = Node.Next;
                    }
                }
            }

            if (Node.Next != null)
            {
                DeleteNodeKey(Node.Next, Data);
            }
        }


        public DoubleLinkedNode FindNextNodeKey(int Data)
        {
            DoubleLinkedNode ReturnNode = Head;
            while (ReturnNode.Data != Data && ReturnNode.Next != null)
            {
                ReturnNode = ReturnNode.Next;
            }
            return ReturnNode;
        }

        public bool DoesKeyExist(int Data)
        {
            DoubleLinkedNode TempHead = Head;
            while (TempHead.Data != Data)
            {
                if (TempHead.Next != null)
                {
                    TempHead = TempHead.Next;
                } else
                {
                    return false;
                }
            }
            return true;
        }

        public void DisplayNode(DoubleLinkedNode Node, string Text)
        {
            if (Node == null)
            {
                Console.WriteLine($"{Text}: Node is empty");
            }
            else
            {
                Console.WriteLine($"{Text}: {Node.Data}");
            }
        }

        public void DisplayAllNodes(DoubleLinkedNode Node)
        {
            if (Node == null)
            {
                Console.Write("Node is empty");
            }
            else
            {
                Console.Write($"{Node.Data}");
                if (Node.Next != null)
                {
                    Console.Write($", ");
                    DisplayAllNodes(Node.Next);
                }
                else
                {
                    Console.Write("\n");
                }
            }
        }
    }
}
