using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class DoublyLinkedListNode<T>
    {
        public T Data { get; set; }
        public DoublyLinkedListNode<T> Next { get; set; }
        public DoublyLinkedListNode<T> Prev { get; set; }

        public DoublyLinkedListNode(T data) : this(data, null, null) { }

        public DoublyLinkedListNode(T data, 
              DoublyLinkedListNode<T> next, 
              DoublyLinkedListNode<T> prev)
        {
            this.Data = data;
            this.Next = next;
            this.Prev = prev;
        }
    }

    public class DoubleLinkedListNode<T> { }

    public class DoublyLinkedList<T>
    {
        private DoublyLinkedListNode<T> head;
        private DoublyLinkedListNode<T> tail;
        public int Count { get; private set; }

        public void Add(DoublyLinkedListNode<T> newNode)
        {
            if (head == null)
            {
                head = newNode;
            }
            else if (tail == null)
            {
                tail = newNode;

                head.Next = tail;
                tail.Prev = head;
            }
            else
            {
                var current = tail;

                current.Next = newNode;
                newNode.Prev = current;

                tail = newNode;
            }
            Count++;
        }

        public void AddAfter(DoublyLinkedListNode<T> current, 
                             DoublyLinkedListNode<T> newNode)
        {
            if (head == null || current == null || newNode == null)
            {
                throw new InvalidOperationException();
            }

            newNode.Next = current.Next;
            newNode.Prev = current;

            current.Next = newNode;
            newNode.Next.Prev = newNode;
        }

        public void Remove(DoublyLinkedListNode<T> removeNode)
        {
            if (head == null || removeNode == null)
            {
                return;
            }

            if (removeNode == head)
            {
                head = head.Next;
                if (head != null)
                {
                    head.Prev = null;
                }
            }
            else
            {
                removeNode.Prev.Next = removeNode.Next;
                if (removeNode.Next != null)
                {
                    removeNode.Next.Prev = removeNode.Prev;
                }
            }
            removeNode = null;
        }

        public DoublyLinkedListNode<T> GetNode(int index)
        {
            if (head == null)
            {
                throw new InvalidOperationException();
            }

            var current = head;
            for (int i = 0; i < index && current != null; i++)
            {
                current = current.Next;
            }

            return current;
        }
    }
}
