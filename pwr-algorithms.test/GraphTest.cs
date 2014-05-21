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

        [Test]
        public void GivenNumberOfVertexAndEdgesThenGenerateUndirectedGraph()
        {
            int numberOfVertex = 3;
            int numberOfEgdes = 3;
            int[,] expectedEgdes = { { 0, 1, 1 }, { 1, 0, 1 }, { 1, 1, 0 } };

            var result = GenerateUndirectGraph(numberOfVertex, numberOfEgdes);

            Assert.AreEqual(expectedEgdes, result);

        }

        [Test]
        public void GivenNumberOfVertexAndEdgesThenValidateAndReturnTrue()
        {
            int numberOfVertex = 3;
            int numberOfEdges = 3;
            bool expectedValue = true;

            var result = ValidateVertexAndEdges(numberOfVertex, numberOfEdges);

            Assert.AreEqual(expectedValue, result);
        }

        [Test]
        public void GivenNumberOfVertexAndEdgesThenValidateAndReturnFalse()
        {
            int numberOfVertex = 4;
            int numberOfEdges = 10;
            bool expectedValue = false;

            var result = ValidateVertexAndEdges(numberOfVertex, numberOfEdges);

            Assert.AreEqual(expectedValue, result);
        }

        public bool ValidateVertexAndEdges(int numberOfVertex, int numberOfEdges)
        {
            int minimum = GetMinimumOfEdges(numberOfVertex);
            int maximum = GetMaximumOfEdges(numberOfVertex);

            if (numberOfEdges >= minimum && numberOfEdges <= maximum)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int[,] GenerateUndirectGraph(int numberOfVertex, int numberOfEdges)
        {
            int[,] result = new int[numberOfVertex, numberOfVertex];

            if (ValidateVertexAndEdges(numberOfVertex, numberOfEdges))
            {
                for (int i = 0; i < numberOfEdges; i++)
                {
                    int yRandom = new Random().Next(1, numberOfVertex);
                    int xRandom = new Random().Next(0, yRandom);

                    while (result[yRandom, xRandom] == 1)
                    {
                        yRandom = new Random().Next(1, numberOfVertex);
                        xRandom = new Random().Next(0, yRandom);
                    }

                    result[yRandom, xRandom] = 1;
                }

                for (int i = 0; i < result.GetLength(0); i++)
                {
                    for (int j = 0; j < result.GetLength(1); j++)
                    {
                        if (result[i, j] == 1)
                        {
                            result[j, i] = 1;
                        }
                    }
                }

                return result;
            }
            else
            {
                throw new NotImplementedException();
            }

            
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
