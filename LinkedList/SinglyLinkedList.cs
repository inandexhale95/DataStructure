using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class SinglyLinkedListNode<T>
    {
        public T Data { get; set; }
        public SinglyLinkedListNode<T> Next { get; set; }

        public SinglyLinkedListNode(T data) : this(data, null) { }

        public SinglyLinkedListNode(T data, SinglyLinkedListNode<T> next)
        {
            this.Data = data;
            this.Next = next;
        }
    }

    public class SinglyLinkedList<T>
    {
        private SinglyLinkedListNode<T> head;
        public int Count { get; private set; }

        public void Add(SinglyLinkedListNode<T> newNode)
        {
            // 리스트가 비어있으면 head에 노드를 삽입한다.
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                var current = head;
                // 리스트의 마지막으로 이동해 새 노드를 추가한다.
                while (current != null && current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = newNode;
            }
            Count++;
        }

        public void AddAfter(SinglyLinkedListNode<T> current,
                             SinglyLinkedListNode<T> newNode)
        {
            if (head == null || current == null || newNode == null)
            {
                throw new InvalidOperationException();
            }

            newNode.Next = current.Next;
            current.Next = newNode;
            Count++;
        }

        public void Remove(SinglyLinkedListNode<T> removeNode)
        {
            if (head == null || removeNode == null)
            {
                return;
            }

            // 삭제할 노드가 첫 노드일 경우
            if (removeNode == head)
            {
                head = head.Next;
                removeNode = null;
            }
            else
            {
                var current = head;

                // 삭제할 노드의 바로 이전 노드까지 이동한다.
                while (current != null && current.Next != removeNode)
                {
                    current = current.Next;
                }

                current.Next = removeNode.Next;
                removeNode = null;
            }
            Count--;
        }

        public SinglyLinkedListNode<T> GetNode(int index)
        {
            var current = head;

            for (int i = 0; i < index && current != null; i++)
            {
                current = current.Next;
            }

            return current;
        }
    }
}
