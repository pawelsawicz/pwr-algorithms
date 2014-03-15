using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace pwr_algorithms.test
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void GivenVectorOfRandomNumbersThenBubbleSort()
        {
            //arrange
            int[] vectorToSort = { 4, 10, 3, 1, 1, 6, 99 };
            int[] expectedVector = { 1, 1, 3, 4, 6, 10, 99 };

            //act
            int[] result = BubbleSort(vectorToSort);



            //assert
            Assert.AreEqual(expectedVector, result);
        }

        [Test]
        public void GivenVectorOfNumbersThenSwapTwoValues()
        {
            int[] vector = { 1, 2, 3, 4, 5 };
            int[] expected = { 1, 4, 3, 2, 5 };

            vector.Swap(1, 3);

            Assert.AreEqual(expected, vector);
        }        

        [Test]
        public void GivenVectorOfRandomNumbersThenSelectionSort()
        {
            int[] vectorToSort = { 9, 2, 78, 6, 2, 30, 8, 1, 11 };
            int[] expectedVector = { 1, 2, 2, 6, 8, 9, 11, 30, 78 };

            int[] result = SelectionSort(vectorToSort);

            Assert.AreEqual(expectedVector, result);
            
        }

        private int[] SelectionSort(int[] vectorToSort)
        {
            int startIndex = 0;
            int stepsCount = vectorToSort.Length - 1;

            for (int i = 0; i < vectorToSort.Length; i++)
            {
                int lowestValueIndex = startIndex;

                for (int j = startIndex; j < vectorToSort.Length; j++)
                {  
                    if (vectorToSort[j] < vectorToSort[lowestValueIndex])
                    {
                        lowestValueIndex = j;
                    }

                    if (j == stepsCount)
                    {
                        vectorToSort.Swap(startIndex, lowestValueIndex);
                    }
                }      
  
                ++startIndex;             
            }

            return vectorToSort;

        }        

        private int[] BubbleSort(int[] vectorToSort)
        {
            int n = vectorToSort.Length;

            for (int z = 0; n > z; n--)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    if (vectorToSort[i] > vectorToSort[i + 1])
                    {
                        int a = vectorToSort[i];
                        int b = vectorToSort[i + 1];
                        vectorToSort[i] = b;
                        vectorToSort[i + 1] = a;

                    }

                }
            }

            return vectorToSort;

        }

    }

    public static class VectorHelper
    {
        public static void Swap(this int[] baseVector, int baseIndex, int swapIndex)
        {
            var tempBaseValue = baseVector[baseIndex];
            baseVector[baseIndex] = baseVector[swapIndex];
            baseVector[swapIndex] = tempBaseValue;
        }
    }
}
