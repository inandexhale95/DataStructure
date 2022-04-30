using System;
using System.Collections.Generic;

namespace BinaryTree
{
    public class Program
    {
        public static void BinaryTreeUsingArrayRun()
        {
            var tree = new BinaryTreeUsingArray(7);
            tree.Root = "A";
            tree.SetLeft(0, "B");
            tree.SetRight(0, "C");
            tree.SetLeft(1, "D");
            tree.SetLeft(2, "F");

            tree.PrintTree();
        }

        public static void BinaryTreeRun()
        {
            var tree = new BinaryTree<char>('A');

            tree.Root.Left = new BinaryTreeNode<char>('B');
            tree.Root.Right = new BinaryTreeNode<char>('C');
            tree.Root.Left.Left = new BinaryTreeNode<char>('D');
            tree.Root.Left.Right = new BinaryTreeNode<char>('E');
            tree.Root.Right.Left = new BinaryTreeNode<char>('F');

            // tree.PreorderTraversal();
            // tree.InorderTraversal();
            // tree.PostorderTraversal();
            // tree.PreorderIterative();
            // tree.InorderIterative();
            // tree.PostorderIterative();
            // tree.LevelorderTraversal();
            //tree.LevelorderNewline();

            // Console.WriteLine(tree.GetMaxDepth(tree.Root));
            // Console.WriteLine(tree.Count(tree.Root));

            void FindTreePath()
            {
                var path = new List<BinaryTreeNode<char>>();
                var target = tree.Root.Right.Left;
                bool found = tree.FindTreePath(tree.Root, target, path);

                if (found)
                {
                    foreach (var node in path)
                    {
                        Console.WriteLine(node.Data);
                    }
                }
            }
            // FindTreePath();

            void LeastCommonAncestor()
            {
                var a = tree.Root.Left.Left;
                var b = tree.Root.Right.Left;
                var result = tree.LeastCommonAncestor(tree.Root, a, b);

                Console.WriteLine(result.Data);
            }
            // LeastCommonAncestor();
        }

        /*
                        A
                    /       \
                  B           C
                /   \        /        
              D       E     F

         */


        static void Main(string[] args)
        {
            BinaryTreeRun();
        }
    }
}
