using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunPrograms
{
    public class DynamicProgramming
    {
        public void GenerateSumOfSubsets(int arrayIndex, int[] array, int[] targetArray, int targetIndex, int targetSum, int sum)
        {
            if (sum == targetSum)
            {
                PrintArray(ref targetArray, targetIndex);

                //Backtrack ater finding one match. 
                if(arrayIndex + 1 < array.Length)
                GenerateSumOfSubsets(arrayIndex + 1, array, targetArray, targetIndex - 1, targetSum, sum - array[arrayIndex]);

                return;

            }
            else
            {
                for (int i = arrayIndex; i < array.Length; i++)
                {
                    targetArray[targetIndex] = array[i];
                    GenerateSumOfSubsets(i + 1, array, targetArray, targetIndex + 1, targetSum, sum + array[i]);
                }
            }
        }

        private void PrintArray(ref int[] array, int targetIndex)
        {
            for(int i = 0; i < targetIndex ; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
