using System;

namespace LinkedList
{
    public class Program
    {
        public static void SinglyLinkedListRun()
        {
            var list = new SinglyLinkedList<int>();

            for (int i = 0; i < 5; i++)
            {
                list.Add(new SinglyLinkedListNode<int>(i));
            }

            // Index가 2인 요소를 가져온다.
            var node = list.GetNode(2);

            // Index가 2인 요소 뒤에 200 삽입
            list.AddAfter(node, new SinglyLinkedListNode<int>(200));

            // 리스트의 요소 출력
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list.GetNode(i).Data);
            }
        }

        public static void DoublyLinkedListRun()
        {
            var doublyLinkedList = new DoublyLinkedList<int>();

            for (int i = 0; i < 5; i++)
            {
                doublyLinkedList.Add(new DoublyLinkedListNode<int>(i));
            }

            var node = doublyLinkedList.GetNode(2);

            doublyLinkedList.AddAfter(node, new DoublyLinkedListNode<int>(1000));

            for (int i = 0; i < doublyLinkedList.Count; i++)
            {
                Console.WriteLine(doublyLinkedList.GetNode(i).Data);
            }

            Console.WriteLine(doublyLinkedList.Count);
        }

        public static void CircularLinkedListRun()
        {
            var circulalrLinkedList = new CircularLinkedList<int>();

            Console.WriteLine(circulalrLinkedList.Count);

            for (int i = 0; i < 5; i++)
            {
                circulalrLinkedList.Add(new CircularLinkedListNode<int>(i));
            }

            for (int i = 0; i < circulalrLinkedList.Count; i++)
            {
                Console.WriteLine(circulalrLinkedList.GetNode(i).Data);
            }

            Console.WriteLine(circulalrLinkedList.Count);
        }

        static void Main(string[] args)
        {
            CircularLinkedListRun();
            
        }
    }
}
