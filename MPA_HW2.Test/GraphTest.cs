using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MPA_HW2.Test
{
    [TestClass]
    public class GraphTest
    {
        [TestMethod]
        public void AddEdge_NonPositiveWeight_Exception()
        {
            //arrange
            Graph graph = new Graph();
            graph.AddNode(0);
            graph.AddNode(1);

            string expected = "NonPositiveWeight";

            //act
            Exception exception = Assert.ThrowsException<Exception>(() => graph.AddEdge(0, 1, -5));
            string actual = exception.Message;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddEdge_AlreadyExistEdge_Exception()
        {
            //arrange
            Graph graph = new Graph();
            graph.AddNode(0);
            graph.AddNode(1);

            graph.AddEdge(0, 1, 2);

            string expected = "Add already existing edge";

            //act
            Exception exception = Assert.ThrowsException<Exception>(() => graph.AddEdge(0, 1, 4));
            string actual = exception.Message;

            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AddEdge_NonExistingNode_Exception()
        {
            //arrange
            Graph graph = new Graph();
            graph.AddNode(0);
            graph.AddNode(1);

            string expected = "NonExistingNode";

            //act
            Exception exception = Assert.ThrowsException<Exception>(() => graph.AddEdge(5, 56, 2));
            string actual = exception.Message;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddEdge_Common_Added()
        {
            //arrange
            Graph graph = new Graph();
            graph.AddNode(0);
            graph.AddNode(1);

            graph.AddEdge(0, 1, 2);

            bool expected = true;

            //act
            bool actual = graph.IsExistEdge(0, 1);

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
