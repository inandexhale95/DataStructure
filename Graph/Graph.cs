using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Graph
{
    public class Node<T>
    {
        public T Data { get; set; }
        // 인접하는 이웃 노드를 관리할 리스트
        public List<Node<T>> Neighbors { get; private set; }
        // 가중치
        public List<int> Weights { get; private set; }

        public Node()
        {
            Neighbors = new List<Node<T>>();
            Weights = new List<int>();
        }

        public Node(T data) : this()
        {
            this.Data = data;
        }
    }

    public class Graph<T>
    {
        private List<Node<T>> nodes;

        public Graph()
        {
            this.nodes = new List<Node<T>>();
        }

        public Node<T> AddVertex(T data)
        {
            return AddVertex(new Node<T>(data));
        }

        public Node<T> AddVertex(Node<T> node)
        {
            nodes.Add(node);
            return node;
        }

        public void AddEdge(Node<T> from, Node<T> to, int weight = 1)
        {
            from.Neighbors.Add(to);
            from.Weights.Add(weight);

            // 반대쪽도 추가해준다.
            to.Neighbors.Add(from);
            to.Weights.Add(weight);
        }

        public void DFS()
        {
            var visited = new HashSet<Node<T>>();
            var root = nodes[0];

            DFSRecursive(root, visited);
        }

        private void DFSRecursive(Node<T> node, HashSet<Node<T>> visited)
        {
            Console.Write($"{node.Data}");
            visited.Add(node);

            foreach (var adjNode in node.Neighbors)
            {
                if (!visited.Contains(adjNode))
                {
                    DFSRecursive(adjNode, visited);
                }
            }
            Console.WriteLine();
        }

        public void DFSIterative()
        {
            var visited = new HashSet<Node<T>>();
            var root = nodes[0];

            DFSUsingStack(root, visited);
        }

        private void DFSUsingStack(Node<T> node, HashSet<Node<T>> visited)
        {
            var stack = new Stack<Node<T>>();
            stack.Push(node);

            while (stack.Count > 0)
            {
                var vertex = stack.Pop();
                if (!visited.Contains(vertex))
                {
                    Console.Write($"{vertex.Data}");
                    visited.Add(vertex);
                }

                foreach (var adjNode in vertex.Neighbors)
                {
                    if (!visited.Contains(adjNode))
                    {
                        stack.Push(adjNode);
                    }
                }
            }
        }

        public void BFS()
        {
            var visited = new HashSet<Node<T>>();
            var root = nodes[0];

            BFS(root, visited);
        }

        private void BFS(Node<T> node, HashSet<Node<T>> visited)
        {
            var q = new Queue<Node<T>>();
            q.Enqueue(node);

            while (q.Count > 0)
            {
                var vertex = q.Dequeue();
                visited.Add(vertex);
                Console.Write(vertex.Data);

                foreach (var adjNode in vertex.Neighbors)
                {
                    if (!visited.Contains(adjNode))
                    {
                        q.Enqueue(adjNode);
                    }
                }
                Console.WriteLine();
            }
        }

        internal void PrintGraph()
        {
            foreach (var vertex in nodes)
            {
                foreach (var neighbor in vertex.Neighbors)
                {
                    Console.WriteLine($"{vertex.Data} --- {neighbor.Data}");
                }
            }
        }
    }
}
