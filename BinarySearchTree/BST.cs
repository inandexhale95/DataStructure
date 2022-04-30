using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTree
{
    public class BST<T> where T : IComparable<T>
    {
        private class Node<P>
        {
            public P Data { get; set; }
            public Node<P> Left { get; set; }
            public Node<P> Right { get; set; }

            public Node(P data)
            {
                this.Data = data;
            }
        }

        private Node<T> root;

        /*
         * 키가 루트 혹은 서브 트리의 루트보다 작으면 왼쪽 노드로 이동
         * 크면 오른쪽 노드로 계속 이동한다.
         * 
         * 만약 이동한 노드가 null이 되면 그곳이 새 노드를 넣을 곳이 된다.
         */
        public void Add(T data)
        {
            // 루트 노드가 비어있을 경우
            if (root == null)
            {
                root = new Node<T>(data);
                return;
            }

            var node = root;
            while (node != null)
            {
                int cmp = data.CompareTo(node.Data);

                // 중복값
                if (cmp == 0)
                {
                    throw new ApplicationException("Duplicate");
                }
                // 키가 루트 노드보다 작아 왼쪽으로 이동
                else if (0 > cmp)
                {
                    if (node.Left == null)
                    {
                        node.Left = new Node<T>(data);
                        break;
                    }
                    else
                    {
                        node = node.Left;
                    }
                }
                // 키가 루트 노드보다 커 오른쪽으로 이동
                else
                {
                    if (node.Right == null)
                    {
                        node.Right = new Node<T>(data);
                        break;
                    }
                    else
                    {
                        node = node.Right;
                    }
                }
                
            }
        }
        public bool Search(T data)
        {
            var node = root;

            while (node != null)
            {
                int cmp = data.CompareTo(node.Data);

                if (cmp == 0)
                {
                    return true;
                }
                else if (0 > cmp)
                {
                    node = node.Left;
                }
                else
                {
                    node = node.Right;
                }
            }
            return false;
        }

        public bool SearchRecursive(T data)
        {
            return SearchRecursive(root, data);
        }

        private bool SearchRecursive(Node<T> node, T data)
        {
            if (node == null)
            {
                return false;
            }

            int cmp = data.CompareTo(node.Data);

            if (cmp == 0)
            {
                return true;
            }

            return (0 > cmp) ? 
                SearchRecursive(node.Left, data) : SearchRecursive(node.Right, data);
        }

        public bool Remove(T data)
        {
            var node = root;
            Node<T> prev = null;

            // 삭제할 노드 검색
            while (node != null)
            {
                int cmp = data.CompareTo(node.Data);

                if (cmp == 0)
                {
                    break;
                }
                else if (0 > cmp)
                {
                    prev = node;
                    node = node.Left;
                }
                else
                {
                    prev = node;
                    node = node.Right;
                }
            }

            if (node == null)
            {
                return false;
            }

            // 삭제 처리
            // 자식 노드가 없는 경우
            if (node.Left == null && node.Right == null)
            {
                if (prev.Left == node)
                {
                    prev.Left = null;
                }
                else
                {
                    prev.Right = null;
                }
                node = null;
            }
            // 자식 노드가 1개인 경우
            else if (node.Left == null || node.Right == null)
            {
                var child = (node.Left != null) ? node.Left : node.Right;

                if (prev.Left == node)
                {
                    prev.Left = child;
                }
                else
                {
                    prev.Right = child;
                }
                node = null;
            }
            // 자식 노드가 2개인 경우
            else
            {
                var pre = node;
                var min = node.Right;

                while (min.Left != null)
                {
                    pre = min;
                    min = min.Left;
                }

                node.Data = min.Data;

                if (pre.Left == min)
                {
                    pre.Left = min.Right;
                }
                else
                {
                    pre.Right = min.Right;
                }
            }

            return true;
        }

        public List<T> ToSortedList()
        {
            var list = new List<T>();
            Traversal(root, list);
            return list;
        }

        private void Traversal(Node<T> node, List<T> list)
        {
            if (node == null)
            {
                return;
            }

            Traversal(node.Left, list);
            list.Add(node.Data);
            Traversal(node.Right, list);
        }        
    }
}
