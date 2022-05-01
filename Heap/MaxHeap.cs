using System;
using System.Collections.Generic;
using System.Text;

namespace Heap
{
    public class MaxHeap
    {
        private List<int> arr = new List<int>();

        public void Add(int data)
        {
            arr.Add(data);

            int i = arr.Count - 1;

            while (i > 0)
            {
                int parent = (i - 1) / 2;

                if (arr[i] > arr[parent])
                {
                    int temp = arr[i];
                    arr[i] = arr[parent];
                    arr[parent] = temp;

                    i = parent;
                }
                else
                {
                    break;
                }
            }
        }
    
        public int Remove()
        {
            if (arr.Count == 0)
            {
                throw new ApplicationException();
            }

            int data = arr[0];

            // 마지막 요소를 처음으로 이동
            arr[0] = arr[arr.Count - 1];
            // 마지막 요소 제거
            arr.RemoveAt(arr.Count - 1);

            // 자식 노드와 크기 비교
            int i = 0;
            int last = arr.Count - 1;
            while (i < last)
            {
                // 왼쪽 자식 노드
                int child = 2 * i + 1;

                // 자식 노드의 인덱스가 끝 인덱스를 초과하지 않는지 검사
                // 왼쪽 자식 노드보다 오른쪽 자식 노드의 값이 크면 오른쪽으로 이동
                if (last < child && arr[child] < arr[child + 1])
                {
                    child++;
                }

                // 자식 노드의 인덱스가 끝 인덱스를 초과하는지 검사
                // 현재 노드의 값이 자식 노드 이상인지 검사
                if (last < child || arr[child] <= arr[i])
                {
                    break;
                }

                int temp = arr[i];
                arr[i] = arr[child];
                arr[child] = temp;

                i = child;
            }

            return data;
        }

        internal void DebugDisplayArray()
        {
            for (int i = 0; i < arr.Count; i++)
            {
                Console.WriteLine($"{arr[i]} ");
            }
        }
    }
}
