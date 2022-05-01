using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graph
{
    public class LinkedListGraph
    {
        public class Node
        {
            public string Key { get; set; }
            public LinkedList<Edge> EdgeList { get; set; }

            public Node(string key)
            {
                Key = key;
                EdgeList = new LinkedList<Edge>();
            }
        }

        public class Edge
        {
            public string From { get; set; }
            public string To { get; set; }
            public int Weight { get; set; }

            public Edge(string from, string to, int weight = 1)
            {
                From = from;
                To = to;
                Weight = weight;
            }
        }

        private List<Node> nodes;

        public LinkedListGraph()
        {
            nodes = new List<Node>();
        }

        public Node AddVertex(string key)
        {
            var node = new Node(key);
            nodes.Add(node);
            return node;
        }

        public void AddEdge(string from, string to, int weight = 1)
        {
            var fromVertex = nodes.Find(n => n.Key == from);

            var edge = new Edge(from, to, weight);
            fromVertex.EdgeList.AddFirst(edge);
        }

        internal void Print()
        {
            foreach (var vertex in nodes)
            {
                string from = vertex.Key;

                foreach (var edge in vertex.EdgeList)
                {
                    Console.WriteLine($"{from} -- {edge.To}");
                }
            }
        }
    }
}
