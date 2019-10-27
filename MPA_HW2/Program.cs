using System;
using System.Diagnostics;

namespace MPA_HW2
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            GraphAlgorithm.FillRandomGraph(graph, 1400);

            int minWay = GraphAlgorithm.FindMinWay(graph);

            Console.WriteLine(minWay);
            Console.ReadKey();
        }
    }
}
