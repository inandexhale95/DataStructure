using System;

namespace Stack
{
    public class Program
    {
        public static void StackUsingLinkedListRun()
        {
            var stack = new StackUsingLinkedList<int>();

            for (int i = 0; i < 10; i++)
            {
                stack.Push(i);
            }

            while (!stack.IsEmpty)
            {
                Console.WriteLine(stack.Pop());
            }
        }

        static void Main(string[] args)
        {
            StackUsingLinkedListRun();
        }
    }
}
