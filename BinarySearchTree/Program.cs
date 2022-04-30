using System;
using System.Collections.Generic;

namespace BinarySearchTree
{
    public class Program
    {
        static void PrintList(List<int> list)
        {
            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Random random = new Random();
            var bst = new BST<int>();

            bst.Add(6);
            bst.Add(7);
            bst.Add(2);
            bst.Add(1);
            bst.Add(5);
            bst.Add(3);
            bst.Add(4);

            Console.WriteLine(bst.Search(4));

            bst.Remove(2);

            PrintList(bst.ToSortedList());

        }
    }
}
