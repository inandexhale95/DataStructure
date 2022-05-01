using System;

namespace Graph
{
    public class Program
    {
        static void Main(string[] args)
        {
            var gr = new LinkedListGraph();
            var a = gr.AddVertex("0");
            gr.AddVertex("1");
            gr.AddVertex("2");
            gr.AddVertex("3");
            gr.AddVertex("4");
            gr.AddVertex("5");
            gr.AddVertex("6");
            gr.AddEdge("0", "1", 7);
            gr.AddEdge("0", "4", 3);
            gr.AddEdge("0", "5", 10);
            gr.AddEdge("1", "5", 6);
            gr.AddEdge("1", "2", 4);
            gr.AddEdge("1", "3", 10);
            gr.AddEdge("2", "3", 2);
            gr.AddEdge("3", "5", 9);
            gr.AddEdge("4", "1", 2);
            gr.AddEdge("4", "3",11);
            gr.AddEdge("4", "6", 5);
            gr.AddEdge("6", "3", 4);

        }
    }
}
