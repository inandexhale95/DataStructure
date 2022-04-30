using System;
using System.Collections.Generic;
using System.Text;

namespace HashTable
{
    
    public class HashTable
    {
        private class Node
        {
            public object Key { get; set; }
            public object Value { get; set; }
            public Node Next { get; set; }

            public Node(object key, object value)
            {
                Key = key;
                Value = value;
                Next = null;
            }
        }

        private Node[] buckets;
        private int size;

        public HashTable(int size = 32)
        {
            this.buckets = new Node[size];
            this.size = size;
        }

        // Key/Value 엔트리 추가
        public void Add(object key, object value)
        {
            // 해시함수를 통해 Bucket 인덱스 산출
            int index = HashFunction(key);

            if (buckets[index] == null)
            {
                buckets[index] = new Node(key, value);
            }
            else
            {
                Node node = new Node(key, value);
                node.Next = buckets[index];
                buckets[index] = node;
            }
        }

        public object Get(object key)
        {
            int index = HashFunction(key);

            Node node = buckets[index];
            while (node != null)
            {
                if (node.Key == key)
                {
                    return node.Value;
                }
                node = node.Next;
            }

            throw new ApplicationException("Not found");
        }

        public bool Contains(object key)
        {
            int index = HashFunction(key);

            Node node = buckets[index];
            while (node != null)
            {
                if (node.Key == key)
                {
                    return true;
                }
                node = node.Next;
            }

            return false;
        }

        private int HashFunction(object key)
        {
            int h = Math.Abs(key.GetHashCode());

            int hash = h & 0xff;
            hash += (h >> 8) & 0xff;
            hash += (h >> 16) & 0xff;
            hash += (h >> 24) & 0xff;

            return hash % size;
        }

        internal void DebugPrintBuckets()
        {
            for (int i = 0; i < buckets.Length; i++)
            {
                Console.Write($"{i}: ");

                Node node = buckets[i];
                while (node != null)
                {
                    Console.Write($"{node.Key} => ");
                    node = node.Next;
                }
                Console.WriteLine();
            }
        }
    }
}
