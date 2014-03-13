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

        

        private int[] BubbleSort(int[] vectorToSort)
        {
            int n = vectorToSort.Length;

            for (int z = 0; n > z; n-- )
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


}
