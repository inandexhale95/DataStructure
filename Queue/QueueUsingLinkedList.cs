using System;
using System.Collections.Generic;
using System.Text;

namespace Queue
{
    public class QueueNode<T>
    {
        public T Data { get; set; }
        public QueueNode<T> Next { get; set; }

        public QueueNode(T data) : this(data, null) { }

        public QueueNode(T data, QueueNode<T> next)
        {
            this.Data = data;
            this.Next = null;
        }
    }

    public class QueueUsingLinkedList<T>
    {
        private QueueNode<T> head = null;
        private QueueNode<T> tail = null;

        public void Enqueue(T data)
        {
            if (head == null)
            {
                head = new QueueNode<T>(data);
                // tail 노드가 head 노드를 기리키고 있어 원형처럼 표현된다.
                tail = head;
            }
            else
            {
                tail.Next = new QueueNode<T>(data);
                tail = tail.Next;
            }
        }

        public T Dequeue()
        {
            if (head == null)
            {
                throw new ApplicationException("Queue is Empty");
            }

            T data = head.Data;

            if (head == tail)
            {
                head = null;
                tail = null;
            }
            else
            {
                head = head.Next;
            }

            return data;
        }
    }
}
