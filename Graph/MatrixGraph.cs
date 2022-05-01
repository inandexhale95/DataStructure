using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    public class MatrixGraph
    {
        private int[,] matrix;
        private List<string> vertexList;
        private int size;

        public MatrixGraph(string[] vertexLabels)
        {
            this.vertexList = new List<string>(vertexLabels);
            this.size = vertexList.Count;
            this.matrix = new int[size, size];
        }

        public void AddEdge(string from, string to, int weight = 1)
        {
            int iFrom = vertexList.FindIndex(v => v == from);
            int iTo = vertexList.FindIndex(v => v == to);
            AddEdge(iFrom, iTo, weight);
        }

        public void AddEdge(int fromIndex, int toIndex, int weight = 1)
        {
            matrix[fromIndex, toIndex] = weight;
            matrix[toIndex, fromIndex] = weight;
        }

        internal void Print()
        {
            Console.Write("  ");
            for (int i = 0; i < size; i++)
            {
                Console.Write($"{vertexList[i]} ");
            }

            Console.WriteLine();

            for (int i = 0; i < size; i++)
            {
                Console.Write($"{vertexList[i]} ");
                for (int a = 0; a < size; a++)
                {
                    Console.Write($"{matrix[i, a]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
