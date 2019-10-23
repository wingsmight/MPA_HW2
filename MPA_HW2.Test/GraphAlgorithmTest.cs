using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MPA_HW2.Test
{
    [TestClass]
    public class GraphAlgorithmTest
    {
        [TestMethod]
        public void FloydWarshall_Empty_Exception()
        {
            //arrange
            Graph graph = new Graph();

            //assert
            var ex = Assert.ThrowsException<Exception>(() => GraphAlgorithm.FloydWarshallFind(graph));
            Assert.AreEqual(ex.Message, "EmptyGraph");
        }

        [TestMethod]
        public void FindMinWay_Empty_Exception()
        {
            //arrange
            Graph graph = new Graph();

            //assert
            var ex = Assert.ThrowsException<Exception>(() => GraphAlgorithm.FindMinWay(graph));
            Assert.AreEqual(ex.Message, "EmptyGraph");
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
    }
}
