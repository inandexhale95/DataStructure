using System;
using System.Collections.Generic;
using System.Text;

namespace Queue
{
    public class QueueUsingCircularArray2
    {
        private object[] arr;
        private int front = 0;
        private int rear = 0;
        public int Count { get; private set; } = 0;

        public QueueUsingCircularArray2(int queueSize = 16)
        {
            arr = new object[queueSize];
        }

        public void Enqueue(object data)
        {
            if (Count == arr.Length)
            {
                throw new ApplicationException("Queue is Full");
            }

            arr[rear] = data;
            rear = (rear + 1) % arr.Length;
            Count++;
        }

        public object Dequeue()
        {
            if (Count == 0)
            {
                throw new ApplicationException("Queue is Empty");
            }

            object data = arr[front];
            front = (front + 1) % arr.Length;
            Count--;

            return data;
        }
    }
}
