using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MPA_HW2.Test
{
    [TestClass]
    public class GraphTest
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
    }
}
