using System;

namespace Queue
{
    public class Program
    {
        public static void QueueUsingLinkedListRun()
        {
            var queue = new QueueUsingLinkedList<int>();

            for (int i = 0; i < 5; i++)
            {
                queue.Enqueue(i);
            }

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }

        static void Main(string[] args)
        {
            QueueUsingLinkedListRun();
        }
    }
}
