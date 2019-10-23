﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPA_HW2
{
    public class GraphAlgorithm
    {
        public static void FillRandomGraph(Graph graph, int count)
        {
            if(count < 0)
            {
                throw new Exception("NegativeCount");
            }

            if (graph == null)
            {
                graph = new Graph();
            }

            for (int i = 0; i < count; i++)
            {
                graph.AddNode(i);
            }

            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    int randomWeight = random.Next(-1000, 1000000);
                    if (randomWeight <= 0)
                    {
                        randomWeight = -1;
                    }

                    graph.AddEdge(i, j, randomWeight);
                }
            }
        }
        public static int FindMinWay(Graph graph)
        {
            List<List<int>> matrix = FloydWarshallFind(graph);

            int minWay = int.MaxValue;
            foreach (List<int> line in matrix)
            {
                foreach (int way in line)
                {
                    if (way < minWay && way != -1)
                    {
                        minWay = way;
                    }
                }
            }

            return minWay;
        }
        public static List<List<int>> FloydWarshallFind(Graph graph)
        {
            if(graph == null || graph.NodeCount <= 0)
            {
                throw new Exception("EmptyGraph");
            }

            List<List<int>> matrix = graph.ConvertToWeightMatrix();
            int nodeCount = graph.NodeCount;

            for (int k = 0; k < nodeCount; ++k)
            {
                for (int i = 0; i < nodeCount; ++i)
                {
                    for (int j = 0; j < nodeCount; ++j)
                    {
                        if (matrix[i][k] != -1 && matrix[k][j] != -1 && matrix[i][k] + matrix[k][j] < matrix[i][j])
                        {
                            matrix[i][j] = matrix[i][k] + matrix[k][j];
                        }
                    }
                }
            }

            return matrix;
        }
    }
}