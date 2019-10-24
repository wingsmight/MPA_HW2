using System;
using System.Collections.Generic;

namespace MPA_HW2
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();

            graph.AddNode(1);
            graph.AddNode(2);
            graph.AddNode(5);
            graph.AddNode(6);

            graph.AddEdge(1, 2, 7);
            graph.AddEdge(5, 6, 17);

            int minWay = GraphAlgorithm.FindMinWay(graph);

            Console.WriteLine(minWay);
            Console.ReadKey();
        }
    }
}
