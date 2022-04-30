using System;

namespace HashTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashTable ht = new HashTable(4);

            ht.Add("James", "425-423-2323");
            ht.Add("Tom", "425-323-1336");
            ht.Add("Jane", "425-733-9853");
            ht.Add("Sam", "425-834-4357");
            ht.Add("Kate", "425-212-3757");
            ht.Add("Ted", "425-744-5557");

            ht.DebugPrintBuckets();
            Console.WriteLine();

            object val = ht.Get("Jane");
            Console.WriteLine(val);

            for (int i = 0; i < 1000; i++)
            {
                if (ht.Contains("Sam"))
                {
                    Console.WriteLine("Samuel: Found");
                }
                else
                {
                    Console.WriteLine("Samuel: Not Found");
                }
            }
            
        }
    }
}
