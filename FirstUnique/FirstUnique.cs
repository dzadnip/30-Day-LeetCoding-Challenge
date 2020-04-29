using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FirstUnique
{
    // My last minute code based on a Java example I saw on youtube.
    class FirstUnique
    {
        Dictionary<int, int> map;
        Queue<int> queue;
        public FirstUnique(int[] nums)
        {
            map = new Dictionary<int, int>();
            queue = new Queue<int>();
            foreach (int num in nums) Add(num);
        }

        public int ShowFirstUnique()
        {
            while (queue.Count > 0)
            {
                int num = queue.Peek();
                int freq = map[num];
                if (freq > 1) queue.Dequeue();
                else return num;
            }
            return -1;
        }

        public void Add(int num)
        {
            if (map.ContainsKey(num)) map[num] = map[num] + 1;
            else
            {
                map.Add(num, 1);
                queue.Enqueue(num);
            }
        }
    }

    // I was clearly over engineering this.
    // Also, tried to create my own liked list class before understanding how to solve this problem with it.
    // The solution works, but was failing out due to timeout when submitting.
    class FirstUnique2
    {
        private Dictionary<int, bool> Unique = new Dictionary<int, bool>();
        private DoubleLinkedList MyList = new DoubleLinkedList();

        public FirstUnique2(int[] nums)
        {
            MyList = new DoubleLinkedList(nums);
        }

        public int ShowFirstUnique()
        {
            DoubleLinkedNode TempNode = MyList.Head;
            Unique = new Dictionary<int, bool>();
            bool KeepRunning = true;
            while (KeepRunning) {
                if (Unique.ContainsKey(TempNode.Data))
                {
                    Unique[TempNode.Data] = false;
                } else
                {
                    Unique.Add(TempNode.Data, true);
                }

                if (TempNode.Next == null)
                {
                    KeepRunning = false;
                } else
                {
                    TempNode = TempNode.Next;
                }
            }

            foreach (KeyValuePair<int, bool> Number in Unique)
            {
                if (Number.Value == true)
                {
                    return Number.Key;
                }
            }
            return -1;            
        }

        public void Add(int value)
        {
            MyList.InsertLast(value);
        }
    }
}
