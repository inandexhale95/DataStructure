using System;

namespace Tree
{
    public class Program
    {
        public static void TreeNodeRun()
        {
            var A = new TreeNode("A");
            var B = new TreeNode("B");
            var C = new TreeNode("C");
            var D = new TreeNode("D");

            A.Links[0] = B;
            A.Links[1] = C; 
            A.Links[2] = D;

            B.Links[0] = new TreeNode("E");
            B.Links[1] = new TreeNode("F");

            D.Links[0] = new TreeNode("G");

            // 의 자식 노드들 출력
            foreach (var node in A.Links)
            {
                Console.WriteLine(node.Data);
            }
            /*
                        A
                     /  |  \
                   B    C    D
                  / \       /
                 E   F     G
             */
        }

        public static void LCRSNodeRun()
        {
            var A = new LCRSNode("A");
            var B = new LCRSNode("B");
            var C = new LCRSNode("C");
            var D = new LCRSNode("D");
            var E = new LCRSNode("E");
            var F = new LCRSNode("F");
            var G = new LCRSNode("G");

            A.LeftChild = B;
            B.RightSibling = C;
            C.RightSibling = D;
            B.LeftChild = E;
            E.RightSibling = F;
            D.LeftChild = G;

            /*
                           A
                        /     
                      B  - C  -  D
                    /           /
                   E - F       G 
             */

            if (A.LeftChild != null)
            {
                var temp = A.LeftChild;
                Console.WriteLine(temp.Data);

                while (temp.RightSibling != null)
                {
                    temp = temp.RightSibling;
                    Console.WriteLine(temp.Data);
                }
            }
        }

        public static void LCRSTreeNodeRun()
        {
            var tree = new LCRSTree("A");
            var A = tree.Root;
            var B = tree.AddChild(A, "B");
            tree.AddChild(A, "C");
            var D = tree.AddSibling(B, "D");
            tree.AddChild(B, "E");
            tree.AddChild(B, "F");
            tree.AddChild(D, "G");

            tree.PrintIndentTree();
            tree.PrintLevelOrder();
        }

        static void Main(string[] args)
        {
            LCRSTreeNodeRun();
        }
    }
}
