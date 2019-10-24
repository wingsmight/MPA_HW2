using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MPA_HW2.Test
{
    [TestClass]
    public class GraphAlgorithmTest
    {
        [TestMethod]
        public void FindMinWay_Empty_Exception()
        {
            //arrange
            Graph graph = new Graph();

            string expected = "EmptyGraph";

            //act
            Exception exception = Assert.ThrowsException<Exception>(() => GraphAlgorithm.FindMinWay(graph));
            string actual = exception.Message;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindMinWay_Common_3Returned()
        {
            //arrange
            Graph graph = new Graph();

            graph.AddNode(1);
            graph.AddNode(2);
            graph.AddNode(3);
            graph.AddNode(4);
            graph.AddNode(5);

            graph.AddEdge(1, 3, 3);
            graph.AddEdge(1, 2, 7);
            graph.AddEdge(1, 4, 5);

            graph.AddEdge(2, 4, 4);
            graph.AddEdge(2, 5, 8);

            graph.AddEdge(3, 1, 3);

            graph.AddEdge(4, 1, 5);
            graph.AddEdge(4, 5, 6);

            graph.AddEdge(5, 2, 8);

            //act
            int expected = GraphAlgorithm.FindMinWay(graph);
            int actual = 3;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindMinWay_1Edge_EdgeWeightReturned()
        {
            //arrange
            Graph graph = new Graph();

            graph.AddNode(1);
            graph.AddNode(2);

            graph.AddEdge(1, 2, 7);

            //act
            int expected = GraphAlgorithm.FindMinWay(graph);
            int actual = 7;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindMinWay_2NonConnectedEdges_LessEdgeWeightReturned()
        {
            //arrange
            Graph graph = new Graph();

            graph.AddNode(1);
            graph.AddNode(2);
            graph.AddNode(5);
            graph.AddNode(6);

            graph.AddEdge(1, 2, 7);
            graph.AddEdge(5, 6, 17);

            //act
            int expected = GraphAlgorithm.FindMinWay(graph);
            int actual = 7;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindMinWay_NonEdged_Exception()
        {
            //arrange
            Graph graph = new Graph();

            graph.AddNode(1);
            graph.AddNode(2);
            graph.AddNode(3);
            graph.AddNode(4);
            graph.AddNode(5);

            string expected = "NonEdgedGraph";

            //act
            Exception exception = Assert.ThrowsException<Exception>(() => GraphAlgorithm.FindMinWay(graph));
            string actual = exception.Message;

            //assert

            Assert.AreEqual(expected, actual);
        }
    }
}
