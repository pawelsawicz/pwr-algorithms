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

        [Test]
        public void GivenVectorOfRandomNumbersThenCountingSort()
        {
            //arrange
            int[] vector = { 2, 3, 1, 7, 2, 6, 4, 3 };
            int[] expectedVector = { 1, 2, 2, 3, 3, 4, 6, 7 };
            int maxValue = 8;
            
            //act
            int[] result = CountingSort(vector, maxValue);

            //assert
            Assert.AreEqual(expectedVector, result);

        }

        [Test]
        public void GivenVectorOfRandomNumbersThenQuickSort()
        {
            //arrange
            int[] vectorToSort = { 4, 10, 3, 1, 1, 6, 99 };
            int[] expectedVector = { 1, 1, 3, 4, 6, 10, 99 };
            int left = 0;
            int right = vectorToSort.Length - 1;

            //act
            int[] result = QuickSort(vectorToSort, left, right);



            //assert
            Assert.AreEqual(expectedVector, result);
        }

        [Test]
        public void GivenVectorOfRandomNumbersThenHeapSort()
        {
            //arrange
            int[] vectorToSort = { 4, 10, 3, 1, 1, 6, 99 };
            int[] expectedVector = { 1, 1, 3, 4, 6, 10, 99 };

            //act
            int[] result = HeapSort(vectorToSort);



            //assert
            Assert.AreEqual(expectedVector, result);
        }

        private int[] CountingSort(int[] vectorToSort, int maxValue)
        {
            int[] sortedVector = new int[vectorToSort.Length];
            int[] countVector = new int[vectorToSort.Length];

            for (int i = 0; i < vectorToSort.Length; i++)
            {
                countVector[vectorToSort[i]] += 1;
            }

            for (int i = 1; i < maxValue; i++)
            {
                countVector[i] += countVector[i - 1];
            }

            for (int i = vectorToSort.Length -1 ; i >= 0; --i)
            {
                sortedVector[--countVector[vectorToSort[i]]] = vectorToSort[i];
            }

            return sortedVector;
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

        private int[] HeapSort(int[] vectorToSort)
        {
            int i, j, k, m, x;
            int n = vectorToSort.Length;

            for (i = 0; i <= n - 1; i++)
            {
                j = i;
                k = j / 2;
                x = vectorToSort[i];

                while ((k > 0) && (vectorToSort[k] < x))
                {
                    vectorToSort[j] = vectorToSort[k];
                    j = k;
                    k = j / 2;
                }

                vectorToSort[j] = x;
            }

            for (i = n - 1; i > 1; i--)
            {
                int a = vectorToSort[1];
                int b = vectorToSort[i];
                vectorToSort[1] = b;
                vectorToSort[i] = a;
                j = 1;
                k = 2;

                while (k < i)
                {
                    if ((k + 1 < i) && (vectorToSort[k + 1] > vectorToSort[k]))
                        m = k + 1;
                    else
                        m = k;

                    if (vectorToSort[m] <= vectorToSort[j])
                        break;
                    int v = vectorToSort[j];
                    int w = vectorToSort[m];
                    vectorToSort[m] = w;
                    vectorToSort[j] = v;
                    j = m;
                    k = j + j;
                }
            }

            return vectorToSort;

        }

        private int[] QuickSort(int[] vectorToSort, int startIndex, int endIndex)
        {
            int i = startIndex;
            int j = endIndex;

            var x = vectorToSort[(startIndex + endIndex) >> 1];
            do
            {
                while (vectorToSort[i].CompareTo(x) < 0) i++;
                while (vectorToSort[j].CompareTo(x) > 0) j--;

                if (i <= j)
                {
                    vectorToSort.Swap(i, j);
                    i++; j--;
                }
            }
            while (i < j);

            if (startIndex < j) QuickSort(vectorToSort, startIndex, j);
            if (endIndex > i) QuickSort(vectorToSort, i, endIndex);

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
                        vectorToSort.Swap(i, i + 1);
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
