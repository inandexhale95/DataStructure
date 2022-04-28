using System;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    public class StackUsingArray
    {
        private object[] arr;
        private int top;

        public bool IsEmpty
        {
            get { return top == -1; }
        }

        public StackUsingArray(int capacity = 16)
        {
            arr = new object[capacity];
            top = -1;
        }

        public void Push(object data)
        {
            if (top == arr.Length - 1)
            {
                Resize();
            }

            arr[++top] = data;
        }

        private void Resize()
        {
            int capacity = arr.Length * 2;
            var tempArray = new object[capacity];
            Array.Copy(arr, tempArray, arr.Length);
            arr = tempArray;
        }

        public object Pop()
        {
            if (this.IsEmpty)
            {
                throw new ApplicationException("Stack is Empty!");
            }

            return arr[top--];
        }

        public object Peek()
        {
            if (this.IsEmpty)
            {
                throw new ApplicationException("Stack is Empty!");
            }

            return arr[top];
        }

    }
}
