using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunPrograms
{
    public static class ShortestSumOfDistances
    {
        public static Tuple<int, int> findNearestPoint(int []xCoordinates, int[]yCoordinates)
        {
            if(xCoordinates == null || yCoordinates == null)
            {
                return null;
            }

            int x = findMedian(xCoordinates);
            int y = findMedian(yCoordinates);
            return new Tuple<int, int>(x, y);
        }

        private static int findMedian(int[] coordinates)
        {
            int median = findMedian(0, coordinates.Length - 1, coordinates);
            return median;
        }

        private static int findMedian(int l, int r, int[] coordinates)
        {
            int med = (r - l) / 2 + l;
            int postion = findPartition(l, r, coordinates);
            if(postion == med)
            {
                return coordinates[postion];
            }
            if (postion < med)
                return findMedian(l, postion - 1, coordinates);
            else
                return findMedian(postion + 1, r, coordinates);
        }

        private static int findPartition(int l, int r, int[] coordinates)
        {
            int i = l;
            int x = coordinates[r];
            for(int j = l; j < r - 1; j++)
            {
                if(coordinates[j] < x)
                {
                    swap(ref coordinates, i, j);
                    i++;
                }
                swap(ref coordinates, i, j);
            }
            return i;
        }

        private static void swap(ref int[] coordinates, int i, int j)
        {
            int temp = coordinates[i];
            coordinates[i] = coordinates[j];
            coordinates[j] = temp;
        }
    }
}
