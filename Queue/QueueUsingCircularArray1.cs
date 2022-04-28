using System;
using System.Collections.Generic;
using System.Text;

namespace Queue
{
    public class QueueUsingCircularArray1
    {
        private object[] arr;
        private int front;
        private int rear;

        public QueueUsingCircularArray1(int queueSize = 16)
        {
            arr = new object[queueSize];
            front = -1;
            rear = -1;
        }

        public void Enqueue(object data)
        {
            // 큐가 가득 차 있는지 확인한다.
            if ((rear + 1) % arr.Length == front)
            {
                throw new ApplicationException("Queue is Full");
            }
            else
            {
                // 비어있는 경우
                if (front == -1)
                {
                    front++;
                }

                rear = (rear + 1) % arr.Length;
                arr[rear] = data;
            }
        }

        public object Dequeue()
        {
            if (front == -1 && rear == -1)
            {
                throw new ApplicationException("Queue is Empty");
            }
            else
            {
                object data = arr[front];

                if (front == rear)
                {
                    front = -1;
                    rear = -1;
                }
                else
                {
                    front = (front + 1) % arr.Length;
                }
                return data;
            }
        }
    }
}
