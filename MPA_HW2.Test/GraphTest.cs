using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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

            string expected = "NonPositiveWeight = -5";

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

        [TestMethod]
        public void DeleteEdge_NonExistingNode_Exseption()
        {
            //arrange
            Graph graph = new Graph();
            graph.AddNode(0);
            graph.AddNode(1);

            string expected = "Trying to delete non-existing edge";

            //act
            Exception exception = Assert.ThrowsException<Exception>(() => graph.DeleteEdge(5, 56));
            string actual = exception.Message;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteEdge_Common_Deleted()
        {
            //arrange
            Graph graph = new Graph();
            graph.AddNode(0);
            graph.AddNode(1);
            graph.AddNode(2);

            graph.AddEdge(0, 1, 2);
            graph.AddEdge(0, 2, 20);

            int expected = 1;

            //act
            graph.DeleteEdge(0, 2);
            int actual = graph.EdgeCount;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddNode_Common_Added()
        {
            //arrange
            Graph graph = new Graph();

            int expected = 1;

            //act
            graph.AddNode(0);
            int actual = graph.NodeCount;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddNode_AlreadyExistingNode_Nothing()
        {
            //arrange
            Graph graph = new Graph();
            graph.AddNode(0);

            int expected = 1;

            //act
            graph.AddNode(0);
            int actual = graph.NodeCount;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsExistNode_ExistingNode_True()
        {
            //arrange
            Graph graph = new Graph();
            graph.AddNode(0);

            bool expected = true;

            //act
            bool actual = graph.IsExistNode(0);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsExistNode_NoneExistingNode_False()
        {
            //arrange
            Graph graph = new Graph();
            graph.AddNode(0);

            bool expected = false;

            //act
            bool actual = graph.IsExistNode(1);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsExistEdge_ExistingEdge_True()
        {
            //arrange
            Graph graph = new Graph();
            graph.AddNode(0);
            graph.AddNode(1);

            graph.AddEdge(0, 1, 10);

            bool expected = true;

            //act
            bool actual = graph.IsExistEdge(0, 1);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsExistEdge_NoneExistingEdge_False()
        {
            //arrange
            Graph graph = new Graph();
            graph.AddNode(0);
            graph.AddNode(1);

            graph.AddEdge(0, 1, 10);

            bool expected = false;

            //act
            bool actual = graph.IsExistEdge(1, 0);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteNode_NonExistingNode_Exseption()
        {
            //arrange
            Graph graph = new Graph();
            graph.AddNode(0);
            graph.AddNode(1);

            string expected = "Trying to delete non-existing node";

            //act
            Exception exception = Assert.ThrowsException<Exception>(() => graph.DeleteNode(5));
            string actual = exception.Message;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteNode_ExistingNode_False()
        {
            //arrange
            Graph graph = new Graph();
            graph.AddNode(0);
            graph.AddNode(1);

            int expected = 1;

            //act
            graph.DeleteNode(1);
            int actual = graph.NodeCount;

            //assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void ConvertToWeightMatrix_EmptyGraph_Exseption()
        {
            //arrange
            Graph graph = new Graph();

            string expected = "Trying to convert empty graph";

            //act
            Exception exception = Assert.ThrowsException<Exception>(() => graph.ConvertToWeightMatrix());
            string actual = exception.Message;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertToWeightMatrix_Common_Converted()
        {
            //arrange
            Graph graph = new Graph();
            graph.AddNode(0);
            graph.AddNode(1);
            graph.AddNode(2);
            graph.AddNode(3);

            graph.AddEdge(0, 1, 10);
            graph.AddEdge(0, 2, 15);
            graph.AddEdge(0, 3, 25);
            graph.AddEdge(1, 2, 30);
            graph.AddEdge(2, 1, 35);

            List<List<int>> expected = new List<List<int>>();
            expected.Add(new List<int>(new int[] {
                -1,
                10,
                15,
                25
            }));
            expected.Add(new List<int>(new int[] {
                -1,
                -1,
                30,
                -1
            }));
            expected.Add(new List<int>(new int[] {
                -1,
                35,
                -1,
                -1
            }));
            expected.Add(new List<int>(new int[] {
                -1,
                -1,
                -1,
                -1
            }));


            //act
            List<List<int>> actual = graph.ConvertToWeightMatrix();

            //assert
            for (int i = 0; i < expected.Count; i++)
            {
                CollectionAssert.AreEqual(expected[i], actual[i]);
            }
        }
    }
}
