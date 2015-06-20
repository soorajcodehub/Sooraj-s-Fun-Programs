using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace FunPrograms
	{
	public class ArrayOperations
	{
		int[] _array ;
		int _numOfItems;
		Heap heap;
		public ArrayOperations(int n)
		{
			heap = new Heap();
			this._numOfItems = n;
			_array = new int[_numOfItems];
		}

		public void FillArray()
		{
			//Random r = new Random(4);
			//int upper = 100000;
			//for (int i = 0; i < _numOfItems; i++)
			//{
			//    _array[i] = r.Next(upper);
			//}
			_array[0] = 0;
			_array[1] = 0;
			_array[2] = 0;
			_array[3] = 0;
			_array[4] = 0;
			_array[5] = 0;
			_array[6] = 0;
			_array[7] = 0;
			_array[8] = 0;

		}

		public void ConcatenateArray()
		{
			_array = heap.ArrangeArrayByMSBs(_array);
			PrintArray(_array);
		}

		public void PrintArray(Array a)
		{
			for(int i =0 ; i < a.Length ; i++)
			{
				Console.Write(" "+ _array[i]);
			}
			Console.WriteLine(" ");
		}

		public void PrintArray()
		{
			for (int i = 0; i < _numOfItems; i++)
			{
				Console.Write(" " + _array[i]);
			}
			Console.WriteLine(" ");
		}

		private void quickSort(int[] _array,int low, int high)
		{
			int pivot = partition(_array,low,high);
			if(low < pivot -1)
			quickSort(_array, low, pivot - 1);
			if ( pivot < _numOfItems-1)
			quickSort(_array, pivot, _numOfItems - 1);
		}

		private int partition(int[] _array,int low,int high)
		{
			int index = (low + (high -low) )/2; 
			int temp;
			while(low <= high)
			{
				while(_array[low] < _array[index])
				{
					low ++; 
				}

				while(_array[high] > _array[index])
				{
					high--;
				}

				if(low<= high)
				{
					temp = _array[low];
					_array[low++] = _array[high];
					_array[high--] = temp;
				}

			}
			
			return low;
		}

		public void Sort()
		{
			quickSort(_array,0,_numOfItems-1);
		}

		public void RotateArray(int n)
		{
			for(int k = 0 ; k < n ;k++)
			{
				int temp = _array[0];
				for(int i =0 ;i < _numOfItems-1; i++)
				{
					
					_array[i] = _array[i+1];
				}
				_array[_numOfItems -1] = temp;
			}
		}

		public int FindMinimum(int low, int high)
		{
			int mid = (low + high) / 2;
			if(low <= mid-1)
			{
				if(_array[low] > _array[mid-1])
				return(FindMinimum(low,mid -1));
			}
			if(mid <= high)
			{
				if(_array[mid] > _array[high])
				return(FindMinimum(mid+1,high));
			}
			return _array[mid];
		}

		public void GeenratePermutations()
		{
			int _leveOfRecursion = 0;
			ArrayList _permutations = new ArrayList();
			
			generatePermutations(_leveOfRecursion,_permutations);
			foreach(Array a in _permutations)
			{
				PrintArray(a);
				Console.ReadKey();
			}
		}

		private void generatePermutations(int _leveOfRecursion, ArrayList _permutations)
		{
			int temp;
			if(_leveOfRecursion == _numOfItems)
			{
				PrintArray(_array);
			}
			else
			{
				for(int j = _leveOfRecursion ; j < _numOfItems ;j ++ )
				{
					temp = _array[_leveOfRecursion];
					_array[_leveOfRecursion] = _array[j];
					_array[j] = temp;
					generatePermutations(_leveOfRecursion+1,_permutations);
					temp = _array[_leveOfRecursion];
					_array[_leveOfRecursion] = _array[j];
					_array[j] = temp;
				}
			}

		}

		public bool ExistsZeroArray()
		{
			int sum = 0;
			Dictionary<int,int> sumInts = new Dictionary<int,int>();
			int val;
			bool flag = false;
			for(int i = 1 ; i < _array.Length ; i++)
			{
				sum += _array[i];
				if(!sumInts.ContainsKey(sum))
				{
					sumInts.Add(sum,i);
				}
				else
				{
					flag = true;	
					sumInts.TryGetValue(sum, out val);
					Console.WriteLine(" Zero Subarray exisits from "+ val  + " to " + i);
					sumInts.Remove(sum);
					sumInts.Add(sum,i);
				}
			}
			return flag;
		}
				
		public bool existsArrayWithSpeceficSum(int sum)
		{
			int subsum = _array[0]; 
			int start = 0;
			bool flag = false;
			for(int i = 1 ; i <= _array.Length; i++)
			{
				while(subsum > sum && start < i-1)
				{
					subsum -= _array[start];	
					start ++;
				}

				if(subsum == sum)
				{
					flag = true;
					Console.WriteLine(" Max Subarray exisits from "+ start + " to " + i);
				}

				if(i<_array.Length)
				subsum = subsum + _array[i];
			}
			return flag;
		}

		public int maximumSubArray()
		{
			int maxSoFar = _array[0];
			int maxSum = _array[0];
			int startIndex = 0;
			int endIndex = 0; 
			for(int i=1 ;i < _array.Length ; i++)
			{
				maxSum += _array[i];
				if(maxSum < _array[i])
				{
					maxSum = _array[i];
					startIndex = i;
				}
				
				if(maxSoFar < maxSum)
				{
					endIndex = i; 
					maxSoFar = maxSum;
				}
			}

			Console.WriteLine("from index -> " +startIndex + " to " +endIndex);
			return maxSoFar;
		}
		

		public void SortArray()
		{
			int[] tempArray = new int[_array.Count()];
			MergeSort(tempArray,0,tempArray.Count() -1);
		}
		public void MergeSort(int[] tempArray , int low , int high)
		{
			if(low > high)
			return;
			int mid = (high - low + low) / 2;
			MergeSort(tempArray,low, mid-1);
			MergeSort(tempArray,mid,high);
			mergearray(tempArray,low,mid,high);
		}

		private void mergearray(int[] tempArray,int low, int mid, int high)
		{
			int leftEnd = mid -1;
			int leftStart = low;
			int rightEnd = high;
			int rightStart = mid;
			int tempStart = leftStart;
			while(leftStart < leftEnd && rightStart < rightEnd)
			{
				if(_array[leftStart] <= _array[rightStart])
				{
					tempArray[tempStart++] = _array[leftStart ++ ];
				}
				else
				{
					tempArray[tempStart++] = _array[rightStart ++];
				}
			}
			while(leftStart < leftEnd)
			{
				tempArray[tempStart++] = _array[leftStart++];
			}
			while(rightStart<rightEnd)
			{
				tempArray[tempStart++] = _array[rightStart++];
			}
			for(int i = 0 ; i < _numOfItems ; i ++, rightEnd --)
			{
				_array[rightEnd] = tempArray[rightEnd];
			}
		

		}


		//public void ConcatenateArray()
		//{	
		//    Dictionary<int,ArrayList> dict = new Dictionary<int,ArrayList>();
		//    int d, e;
		//    Boolean flag = false;
		//    for(int i = 0 ; i < _array.Count(); i ++ )
		//    {
		//        Stack<int> stack = findDigits(_array[i]);
		//        ArrayList a = new ArrayList();
		//        if(dict[stack.Peek()] == null)
		//        {
		//            a.Add(_array[i]);
		//            dict[stack.Peek()] = a;
		//        }
		//        else
		//        {
		//            ArrayList b = new ArrayList();
		//            a = dict[stack.Peek()];
		//            for(int j = 0 ; j < a.Count ; j ++)
		//            {
		//                int num = (int)a[j];
		//                Stack<int> stack1 = findDigits(num);
		//                while(stack.Count > 0 && stack1.Count > 0)
		//                {
		//                    d = stack.Pop();
		//                    e = stack1.Pop();
		//                    if( d > e )
		//                    {
		//                        b.Add(_array[i]); 
		//                        break;
		//                    }
		//                    else if(d < e)
		//                    {
		//                        b.Add(num);
		//                        break;
		//                    }
		//                    if(stack.Count == 0 && stack1.Count != 0)
		//                    {
		//                        while(stack1.Count > 0)
		//                        {
		//                            e = stack1.Pop();
		//                            if(d > e)
		//                            {
		//                                b.Add(_array[i]);
		//                                flag = true;
		//                                break;
		//                            }
		//                            else if( d < e)
		//                            {
		//                                b.Add(num);
		//                                flag = true;																				
		//                                break;
		//                            }

		//                            if(stack1.Count == 0)
		//                            {
		//                                b.Add(num);
		//                                b.Add(_array[i]);
		//                            }
		//                        }
		//                    }
		//                    if(stack1.Count == 0 && stack.Count != 0)
		//                    {
		//                        while(stack.Count > 0)
		//                        {
		//                            d = stack.Pop();
		//                            if(d > e)
		//                            {
		//                                flag = true;
		//                                b.Add(_array[i]);
		//                                break;
		//                            }
		//                            else if( d < e)
		//                            {
		//                                flag = true;
		//                                b.Add(num);
		//                                break;
		//                            }

		//                            if(stack.Count == 0)
		//                            {
		//                                b.Add(num);
		//                                b.Add(_array[i]);
		//                            }
		//                        }
		//                    }
		//                    if(flag)
		//                    break;
		//                }

		public void SortByFrequency()
		{
			Dictionary<int,int> frequenceyCount = new Dictionary<int,int>();
			int i = 0;
			int count; 
			while(i < _array.Length)
			{
				if(frequenceyCount.ContainsKey(_array[i]))
				{
					count = frequenceyCount[_array[i]];
					frequenceyCount[_array[i]] = count + 1;
				}
				else
				{
					frequenceyCount.Add(_array[i],1);
				}
				i++;
			}

			int[] temparray = new int[frequenceyCount.Values.Count]; 
			int j = 0;
			foreach (int value in frequenceyCount.Values)
			{
				temparray[j] = value;
				j ++ ;
			}

			int[] _arrayForCountSort = new int[_array.Length];
			int k;
			for ( k= 0; k < temparray.Length; k++) _arrayForCountSort[temparray[k]]++;
			int index = 0;
			for (k = 0; k < _arrayForCountSort.Length; k++)
			{
				while (_arrayForCountSort[k] > 0)
				{
					temparray[index] = k;
					index++;
					_arrayForCountSort[k]--;
				}
			}

			j =0;
			for (k = temparray.Length - 1; k >= 0; k--)
			{
				foreach(KeyValuePair<int,int> pair in frequenceyCount)
				{
					if(pair.Value == temparray[k])
					{
						while (temparray[k] > 0)
						{
							_array[j] = pair.Key;
							temparray[k]--;
							j++;
						}
						frequenceyCount.Remove(pair.Key);
						break;
					}
				}
			}
				
		}
		

		public void swap(int a, int b)
		{
			int temp = _array[a];
			_array[a] = _array[b];
			_array[b] = temp;
		}

		public void RearrangePositivesAndNegatives()
		{

			int n,p ;
			n = p = 0;
			while(n < _array.Length && p < _array.Length)
			{
				if (_array[n] > 0)
				{
					while (n < _array.Length && _array[n] > 0)
					{
						n++;
					}
					if (p + 1 != n && n < _array.Length)
					swap(p+1,n);
					p = p+1;
					n = p;
				}
				else if (p < _array.Length && _array[p] < 0)
				{
					while (_array[p] < 0)
					{
						p++;
					}
					if (n + 1 != p && (p < _array.Length))
					swap(n+1,p);
					n = n+1;
					p = n;
				}
			}
		}


		private int BinarySearch(int[] sequences, int low, int high, int key)
		{
			try
			{
				int mid;
				while(low<high)
				{
					mid = (low + high) / 2; 
					if(sequences[mid] >= key)
					{
						high = mid;
					}
					else
					{	
						low = mid + 1;
					}
				}
				return high;
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
				return high;
			}
		}

				
		public int IncreasingSubSequence()
		{
			int errorCode = -1;
			if(_array == null || _array.Length == 0)
			{
				return errorCode;
			}
			try
			{
				int len =1;
				int[] sequences =  new int[_array.Length];
				sequences[0] = _array[0];
				for(int i = 1; i <_array.Length ; i++)
				{
					if(_array[i] < sequences[0])
					{
						sequences[0] = _array[i];
					}
					else if(_array[i] > sequences[len -1])
					{
						sequences[len] = _array[i];
						len ++; 
					}
					else
					{
						sequences[BinarySearch(sequences,-1,len-1,_array[i])] = _array[i];
					}
				}
				
				return len;
			}
			catch(IndexOutOfRangeException ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine(ex.StackTrace);
				return errorCode;
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
				return errorCode;
			}
		}
				

		public long GetBytelandianCoins(int n)
		{
			return getBytelandianCoins(n,_array);
		}

		private int getBytelandianCoins(int n, int[] h)
		{
			try{
			if(n == 0)
			{
				return 0;
			}
			
			int r =  h[n];
			if(r == 0)
			{
				r = Math.Max(n,(getBytelandianCoins(n/2,h) + getBytelandianCoins(n/3,h) + getBytelandianCoins(n/4,h)));
				h[n] = r;
			}

			return r;
			}
			catch(StackOverflowException ex)
			{
				Console.WriteLine(ex.Message);
				return 0;
			}
			catch(IndexOutOfRangeException ex)
			{
                Console.WriteLine(ex.Message);
				return 0;
			}
				
		}
					
        public bool ParkCarsInCorrectSpots(int[] parkingSpots, int[] cars)
        {
            if (parkingSpots == null || cars == null)
                return false;

            int emptyCarSpot = -1; 
            int count = 0 ;

            while(emptyCarSpot != 0 && count < cars.Count() -1)
            {
                emptyCarSpot = findEmptyCarSpot(parkingSpots);
                if(emptyCarSpot == -1)
                {
                    return false;
                }

                emptyCarSpot = moveToEmptyCarSpot(emptyCarSpot, cars);
                count++;
            }
            return true;
        }

        private int moveToEmptyCarSpot(int emptyCarSpot, int[] cars)
        {
            for (int i = 0; i < cars.Length; i++)
            {
                if (i == emptyCarSpot)
                {
                    return cars[i];
                }
            }

            return -1;
        }

        private int findEmptyCarSpot(int[] parkingSpots)
        {
            for (int i = 0; i < parkingSpots.Length; i ++ )
            {
                if(parkingSpots[i] == 0 )
                {
                    return i;
                }
            }
            return -1;
        }

        public static int LongestZigZagSequence(int [] array)
        {
            int arrayLength = array.Length;
            int[] subsequences = new int[arrayLength];
            subsequences[0] = 1;
            subsequences[1] = 2;
            int diff = array[1] - array[0];
            for(int i = 2; i < array.Length; i++)
            {
                if((array[i] - array[i-1] > 0 && diff < 0) || (array[i] - array[i-1] < 0 && diff > 0))
                {
                    subsequences[i] = subsequences[i - 1] + 1;
                    diff = array[i] - array[i - 1];
                }
                else
                {
                    subsequences[i] = subsequences[i - 1];
                }
            }
            return subsequences[arrayLength-1];
        }
	}
}

