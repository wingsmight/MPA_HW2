using System;
using System.Collections.Generic;

namespace MPA_HW2
{
    public class Graph
    {
        List<int> nodeArray;
        List<int> edgesFrom;
        List<int> edgesTo;
        List<int> edgesWeight;

        public Graph()
        {
            nodeArray = new List<int>();
            edgesFrom = new List<int>();
            edgesTo = new List<int>();
            edgesWeight = new List<int>();
        }

        public void AddEdge(int nodeFrom, int nodeTo, int weight)
        {
            if(weight <= 0)
            {
                throw new Exception("NonPositiveWeight = " + weight);
            }

            if(!IsExistNode(nodeFrom) || !IsExistNode(nodeTo))
            {
                throw new Exception("NonExistingNode");
            }
            else
            {
                if (!IsExistEdge(nodeFrom, nodeTo))
                {
                    edgesFrom.Add(nodeFrom);
                    edgesTo.Add(nodeTo);
                    edgesWeight.Add(weight);
                }
                else
                {
                    throw new Exception("Add already existing edge");
                }
            }
        }
        public void DeleteEdge(int nodeFrom, int nodeTo)
        {
            if (IsExistEdge(nodeFrom, nodeTo))
            {
                for (int i = 0; i < edgesFrom.Count; i++)
                {
                    if (edgesFrom[i] == nodeFrom && edgesTo[i] == nodeTo)
                    {
                        edgesFrom.RemoveAt(i);
                        edgesTo.RemoveAt(i);
                        edgesWeight.RemoveAt(i);
                    }
                }
            }
            else
            {
                throw new Exception("Trying to delete non-existing edge");
            }
        }
        public void AddNode(int node)
        {
            if(!IsExistNode(node))
            {
                nodeArray.Add(node);
            }
        }
        public List<int> GetAdjacentFromNodes(int fromNode)
        {
            if(IsExistNode(fromNode))
            {
                List<int> adjacentNodes = new List<int>();

                for (int i = 0; i < edgesFrom.Capacity; i++)
                {
                    if (edgesFrom[i] == fromNode)
                    {
                        adjacentNodes.Add(edgesTo[i]);
                    }
                }

                return adjacentNodes;
            }
            else
            {
                throw new Exception("NonExistingFromNode");
            }
        }
        public List<int> GetAdjacentToNodes(int toNode)
        {
            if (IsExistNode(toNode))
            {
                List<int> adjacentNodes = new List<int>();

                for (int i = 0; i < edgesFrom.Capacity; i++)
                {
                    if (edgesTo[i] == toNode)
                    {
                        adjacentNodes.Add(edgesFrom[i]);
                    }
                }

                return adjacentNodes;
            }
            else
            {
                throw new Exception("NonExistingToNode");
            }

        }
        public bool IsExistNode(int node)
        {
            for (int i = 0; i < nodeArray.Count; i++)
            {
                if (nodeArray[i] == node)
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsExistEdge(int nodeFrom, int nodeTo)
        {
            for (int i = 0; i < edgesFrom.Count; i++)
            {
                if (edgesFrom[i] == nodeFrom && edgesTo[i] == nodeTo)
                {
                    return true;
                }
            }
            return false;
        }
        public void DeleteNode(int node)
        {
            if (IsExistNode(node))
            {
                nodeArray.Remove(node);

                for (int i = 0; i < edgesFrom.Count; i++)
                {
                    if (edgesFrom[i] == node || edgesTo[i] == node)
                    {
                        edgesFrom.RemoveAt(i);
                        edgesTo.RemoveAt(i);
                        edgesWeight.RemoveAt(i);

                        i--;
                    }
                }
            }
            else
            {
                throw new Exception("Trying to delete non-existing node");
            }
        }
        public void PrintNodeList()
        {
            if(nodeArray.Count == 0)
            {
                Console.WriteLine("Node list is empty");
            }
            else
            {
                foreach (int node in nodeArray)
                {
                    Console.WriteLine("Node :" + node + "\n");
                }
            }
        }
        public List<List<int>> ConvertToWeightMatrix()
        {
            if(NodeCount > 0)
            {
                List<List<int>> weightMatrix = new List<List<int>>();

                for (int i = 0; i < NodeCount; i++)
                {
                    weightMatrix.Add(new List<int>());

                    for (int j = 0; j < NodeCount; j++)
                    {
                        weightMatrix[i].Add(-1);
                    }
                }

                for (int i = 0; i < EdgeCount; i++)
                {
                    weightMatrix[nodeArray.IndexOf(edgesFrom[i])][nodeArray.IndexOf(edgesTo[i])] = edgesWeight[i];
                }

                return weightMatrix;
            }
            else
            {
                throw new Exception("Trying to convert empty graph");
            }
        }
        public int NodeCount
        {
            get { return nodeArray.Count; }
        }
        public int EdgeCount
        {
            get { return edgesFrom.Count; }
        }
    }
}
