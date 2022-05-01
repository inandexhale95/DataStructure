using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    
    public class HashTableGraph
    {
        private class Node
        {
            public string Key { get; set; }
            public int Weight { get; set; }

            public Node(string key, int weight = 1)
            {
                Key = key;
                Weight = weight;
            }
        }

        private Dictionary<string, List<Node>> nodes;

        public HashTableGraph()
        {
            nodes = new Dictionary<string, List<Node>>();
        }

        public void AddVertex(string key)
        {
            // 해당 정점 Key가 있는지 체크
            if (!nodes.ContainsKey(key))
            {
                var edgeList = new List<Node>();
                nodes.Add(key, edgeList);
            }
        }

        public void AddEdge(string from, string to, int weight = 1)
        {
            var edgeList = nodes[from];
            if (edgeList == null)
            {
                throw new ApplicationException("Not Found");
            }
            edgeList.Add(new Node(to, weight));
        }

        internal void PrintGraph()
        {
            foreach (KeyValuePair<string, List<Node>> kv in nodes)
            {
                string from = kv.Key;
                foreach (var edge in kv.Value)
                {
                    Console.WriteLine($"{from} -- {edge.Key}");
                }
            }
        }
    }
}
