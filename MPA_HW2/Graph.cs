using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        public void AddEdge(int nodeFrom, int nodeTo, int weight)
        {
            edgesFrom.Add(nodeFrom);
            edgesTo.Add(nodeTo);
            edgesWeight.Add(weight);
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
            nodeArray.Add(node);
        }
        public List<int> GetAdjacentFromNodes(int fromNode)
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
        public List<int> GetAdjacentToNodes(int toNode)
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
                for (int i = 0; i < edgesFrom.Count; i++)
                {
                    if(edgesFrom[i] == node || edgesTo[i] == node)
                    {
                        edgesFrom.RemoveAt(i);
                        edgesTo.RemoveAt(i);
                        edgesWeight.RemoveAt(i);
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
            foreach(int node in nodeArray)
            {
                Console.WriteLine("Node :" + node + "\n");
            }
        }
    }
}
