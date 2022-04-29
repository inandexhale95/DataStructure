using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    // 연결리스트를 이용한 이진 트리
    public class BinaryTreeNode<T>
    {
        public T Data { get; set; }
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }

        public BinaryTreeNode(T data)
        {
            this.Data = data;
        }
    }
    public class BinaryTree<T>
    {
        public BinaryTreeNode<T> Root { get; private set; }

        public BinaryTree(T root)
        {
            this.Root = new BinaryTreeNode<T>(root);
        }

        public void PreorderTraversal()
        {
            PreorderTraversal(Root);
        }

        private void PreorderTraversal(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }

            Console.WriteLine($"{node.Data}");
            PreorderTraversal(node.Left);
            PreorderTraversal(node.Right);
        }

        public void InorderTraversal()
        {
            InorderTraversal(Root);
        }

        private void InorderTraversal(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }

            InorderTraversal(node.Left);
            Console.WriteLine(node.Data);
            InorderTraversal(node.Right);
        }

        public void PostorderTraversal()
        {
            PostorderTraversal(Root);
        }

        private void PostorderTraversal(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }

            PostorderTraversal(node.Left);
            PostorderTraversal(node.Right);
            Console.WriteLine(node.Data);
        }

        public void PreorderIterative()
        {
            if (Root == null)
            {
                return;
            }

            var stack = new Stack<BinaryTreeNode<T>>();

            stack.Push(Root);

            while (stack.Count > 0)
            {
                var node = stack.Pop();

                Console.WriteLine(node.Data);

                if (node.Right != null)
                {
                    stack.Push(node.Right);
                }

                if (node.Left != null)
                {
                    stack.Push(node.Left);
                }
            }
        }

        public void InorderIterative()
        {
            var stack = new Stack<BinaryTreeNode<T>>();
            var node = Root;

            while (node != null || stack.Count > 0)
            {
                // Left의 끝 노드까지 스택에 저장
                while (node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }

                node = stack.Pop();

                Console.WriteLine(node.Data);

                node = node.Right;
            }

        }

        public void PostorderIterative()
        {
            var stack = new Stack<BinaryTreeNode<T>>();
            var node = Root;

            while (node != null || stack.Count > 0)
            {
                while (node != null)
                {
                    if (node.Right != null)
                    {
                        stack.Push(node.Right);
                    }
                    stack.Push(node);
                    node = node.Left;
                }


                node = stack.Pop();

                if (node.Right != null && 0 < stack.Count && node.Right == stack.Peek())
                {
                    var right = stack.Pop();
                    stack.Push(node);
                    node = right;
                }
                else
                {
                    Console.WriteLine(node.Data);
                    node = null;
                }
            }

        }
    
        public void LevelorderTraversal()
        {
            var q = new Queue<BinaryTreeNode<T>>();

            q.Enqueue(Root);

            while (q.Count > 0)
            {
                var node = q.Dequeue();

                Console.WriteLine(node.Data);

                if (node.Left != null)
                {
                    q.Enqueue(node.Left);
                }

                if (node.Right != null)
                {
                    q.Enqueue(node.Right);
                }
            }
        }
    
        public void LevelorderNewline()
        {
            var q = new Queue<BinaryTreeNode<T>>();

            q.Enqueue(Root);
            q.Enqueue(null);        // 레벨끝을 표시하는 마크

            while (0 < q.Count)
            {
                var node = q.Dequeue();

                // 레벨의 끝에 도착했을 경우
                if (node == null)
                {
                    Console.WriteLine();

                    if (0 < q.Count)
                    {
                        q.Enqueue(null);
                    }
                    continue;
                }

                Console.Write($"{node.Data} ");

                if (node.Left != null)
                {
                    q.Enqueue(node.Left);
                }

                if (node.Right != null)
                {
                    q.Enqueue(node.Right);
                }
            }
        }
    
        // 이진 트리 깊이 구하기
        public int GetMaxDepth(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return -1;
            }

            /*
             * 트리 깊이를 (노드의 수가 아닌) 간선의 수로 계산하기 위해 node가 null일 때 -1을 반환한다.
             * 노드가 아예 없는 빈 트리의 경우는 깊이가 -1이 되고, 루트 노드 하나만 있는 경우 깊이는 0이 된다.
             */

            return 1 + Math.Max(GetMaxDepth(node.Left), GetMaxDepth(node.Right));
        }
    
        // 이진 트리 노드 수 구하기
        public int Count(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            return 1 + Count(node.Left) + Count(node.Right);
        }

        // 이진 트리에서 노드 경로 찾기
        public bool FindTreePath(BinaryTreeNode<T> root, BinaryTreeNode<T> target, List<BinaryTreeNode<T>> path)
        {
            if (root == null)
            {
                return false;
            }

            // 루트를 path에 추가
            path.Add(root);

            if (root == target)
            {
                return true;
            }
            
            // 좌우 서브트리에 재귀호출
            if (FindTreePath(root.Left, target, path) || FindTreePath(root.Right, target, path))
            {
                return true;
            }

            // 발견되지 않았으면 루트 제거
            path.RemoveAt(path.Count - 1);
            return false;
        }
    
        // 최소 공통 조상 구하기
        public BinaryTreeNode<T> LeastCommonAncestor(BinaryTreeNode<T> root, BinaryTreeNode<T> a, BinaryTreeNode<T> b)
        {
            if (root == null)
            {
                return null;
            }

            if (root == a || root == b)
            {
                return root;
            }

            var left = LeastCommonAncestor(root.Left, a, b);
            var right = LeastCommonAncestor(root.Right, a, b);

            if (left != null && right != null)
            {
                return root;
            }
            else
            {
                return (left != null) ? left : right;
            }
        }                
    }
}

