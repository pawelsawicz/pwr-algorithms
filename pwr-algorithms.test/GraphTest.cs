using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace pwr_algorithms.test
{
    [TestFixture]
    public class GraphTest
    {
        /*
         * undirected weighted graph 
         */

        [Test]
        public void GivenNumberOfVertexThenReturnMinimumNumberOfEdges()
        {
            int numberOfVertex = 5;
            int expectedNumberOfEdges = 4;

            int result = numberOfVertex - 1;

            Assert.AreEqual(expectedNumberOfEdges, result);
        }

        [Test]
        public void GivenNumberOfVertexThenReturnMaximumNumberOfEdges()
        {
            int numberOfVertex = 4;
            int expectedNumberOfEdges = 6;

            int result = (numberOfVertex * (numberOfVertex - 1)) / 2;

            Assert.AreEqual(expectedNumberOfEdges, result);
        }
    }
}
