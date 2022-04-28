using System;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    public class StackUsingLinkedList<T>
    {
        private class StackNode<T>
        {
            public T Data { get; set; }
            public StackNode<T> Next { get; set; }

            public StackNode(T data) : this(data, null) { }
            public StackNode(T data, StackNode<T> next)
            {
                this.Data = data;   
                this.Next = next;   
            }
        }

        private StackNode<T> top = null;

        public bool IsEmpty
        {
            get { return top == null; }
        }

        public void Push(T data)
        {
            if (top == null)
            {
                top = new StackNode<T>(data);
            }
            else
            {
                var node = new StackNode<T>(data);
                node.Next = top;
                top = node;
            }
        }

        public T Pop()
        {
            if (this.IsEmpty)
            {
                throw new ApplicationException("Stack is Empty!");
            }

            T data = top.Data;
            top = top.Next;
            return data;
        }

        public T Peek()
        {
            if (this.IsEmpty)
            {
                throw new ApplicationException("Stack is Empty!");
            }

            return top.Data;
        }
    }
}
