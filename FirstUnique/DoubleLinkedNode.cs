using System;
using System.Collections.Generic;
using System.Text;

namespace FirstUnique
{
    class DoubleLinkedNode
    {
        public int Data;
        public DoubleLinkedNode Prev;
        public DoubleLinkedNode Next;

        public DoubleLinkedNode(int Data)
        {
            this.Data = Data;
            this.Prev = null;
            this.Next = null;
        }
    }
}
