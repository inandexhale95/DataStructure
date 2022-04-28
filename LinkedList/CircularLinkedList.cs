using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class CircularLinkedListNode<T>
    {
        public T Data { get; set; }
        public CircularLinkedListNode<T> Next { get; set; }
        public CircularLinkedListNode<T> Prev { get; set; }

        public CircularLinkedListNode(T data) : this(data, null, null) { }

        public CircularLinkedListNode(T data, 
              CircularLinkedListNode<T> next, 
              CircularLinkedListNode<T> prev)
        {
            this.Data = data;
            this.Next = next;
            this.Prev = prev;
        }
    }

    public class CircularLinkedList<T>
    {
        private CircularLinkedListNode<T> head;
        public int Count { get; private set; }

        public void Add(CircularLinkedListNode<T> newNode)
        {
            if (head == null)
            {
                head = newNode;
                head.Next = head;
                head.Prev = head;
            }
            else
            {
                var tail = head.Prev;

                head.Prev = newNode;
                tail.Next = newNode;
                newNode.Prev = tail;
                newNode.Next = head;
            }
            Count++;
        }

        public void AddAfter(CircularLinkedListNode<T> current,
                             CircularLinkedListNode<T> newNode)
        {
            if (head == null || current == null || newNode == null)
            {
                throw new InvalidOperationException();
            }

            current.Next.Prev = newNode;
            newNode.Next = current.Next;
            current.Next = newNode;
            newNode.Prev = current;
            Count++;
        }

        public void Remove(CircularLinkedListNode<T> removeNode)
        {
            if (head == null || removeNode == null)
            {
                return;
            }

            // 삭제할 노드가 헤드 노드이고 노드가 1개면
            if (head == removeNode && head == head.Next)
            {
                head = null;
            }
            else
            {
                removeNode.Prev.Next = removeNode.Next;
                removeNode.Next.Prev = removeNode.Prev;
            }
            removeNode = null;
            Count--;
        }

        public CircularLinkedListNode<T> GetNode(int index)
        {
            if (head == null)
            {
                return null;
            }

            var current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;

                if (current == null)
                {
                    return null;
                }
            }

            return current;
        }
    }
}
