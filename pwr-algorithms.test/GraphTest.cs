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

            int result = GetMinimumOfEdges(numberOfVertex);

            Assert.AreEqual(expectedNumberOfEdges, result);
        }

        [Test]
        public void GivenNumberOfVertexThenReturnMaximumNumberOfEdges()
        {
            int numberOfVertex = 4;
            int expectedNumberOfEdges = 6;

            int result = GetMaximumOfEdges(numberOfVertex);

            Assert.AreEqual(expectedNumberOfEdges, result);
        }

        public int GetMinimumOfEdges(int numberOfVertex)
        {
            int result = numberOfVertex - 1;
            return result;
        }

        public int GetMaximumOfEdges(int numberOfVertex)
        {
            int result = (numberOfVertex * (numberOfVertex - 1)) / 2;
            return result;
        }
    }
}
