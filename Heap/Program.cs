using System;

namespace Heap
{
    public class Program
    {
        static void Main(string[] args)
        {
            var heap = new MaxHeap();
            heap.Add(20);
            heap.Add(15);
            heap.Add(12);
            heap.Add(13);
            heap.Add(10);
            heap.Add(9);
            heap.Add(11);
            heap.Add(7);
            heap.Add(6);

            heap.DebugDisplayArray();

            heap.Add(17);

            heap.DebugDisplayArray();

            int max = heap.Remove();
            Console.WriteLine(max);

            heap.DebugDisplayArray();

        }
    }
}
