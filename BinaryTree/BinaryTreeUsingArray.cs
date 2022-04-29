using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    // 배열을 이용한 이진트리
    public class BinaryTreeUsingArray
    {
        private object[] arr;

        public object Root 
        {
            get { return arr[0]; }
            set { arr[0] = value; } 
        }

        public BinaryTreeUsingArray(int capacity = 16)
        {
            arr = new object[capacity];
        }

        // 왼쪽 노드 : 2 * i + 1
        // 오른쪽 노드 : 2 * i + 2
        // 부모 노드 : (i - 1) / 2
        public void SetLeft(int parentIndex, object data)
        {
            int leftIndex = parentIndex * 2 + 1;

            // 부모 노드가 없거나 배열이 Full인 경우
            if (arr[parentIndex] == null || arr.Length <= leftIndex)
            {
                throw new ApplicationException("Error");
            }

            arr[leftIndex] = data;
        }

        public void SetRight(int parentIndex, object data)
        {
            int rightIndex = parentIndex * 2 + 2;

            if (arr[parentIndex] == null || arr.Length <= rightIndex)
            {
                throw new ApplicationException("Error");
            }
            arr[rightIndex] = data;
        }

        public object GetParent(int childIndex)
        {
            if (childIndex == 0)
            {
                return null;
            }

            int parentIndex = (childIndex - 1) / 2;
            return parentIndex;
        }

        public object GetLeft(int parentIndex)
        {
            int childIndex = (parentIndex * 2) + 1;
            return childIndex;
        }

        public object GetRight(int parentIndex)
        {
            int rightIndex = (parentIndex * 2) + 2;
            return rightIndex;
        }

        public void PrintTree()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"{arr[i] ?? "-"}");
            }
            Console.WriteLine();
        }
    }
}
