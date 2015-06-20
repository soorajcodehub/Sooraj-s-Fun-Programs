using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace FunPrograms
{
	public class Heap
	{
		int[] _heapArray;
		private int heapsize;
		private static int count = 1;
		public Heap()
		{
			_heapArray = new int[7];
		}
		public Heap(int[] _heapArray)
		{
			this._heapArray = _heapArray;
			this.heapsize = this._heapArray.Length;
		}
		public Heap(int heapsize)
		{
			this.heapsize = heapsize;
		}
		private void MinHeapify(int i)
		{
			int l = i*2;	
			int r = i*2 + 1;
			int smallest;
			int temp;
			if(l <= heapsize && _heapArray[l] < _heapArray[i])
			{
				smallest = l;
			}
			else
			{
				smallest = i;
			}
			if(r <= heapsize && _heapArray[r] < _heapArray[smallest])
			{
				smallest = r;
			}
			if(smallest != i)
			{
				temp = _heapArray[i];
				_heapArray[i] = _heapArray[smallest];
				_heapArray[smallest] = temp;
				MinHeapify(smallest);
			}
		}

		private int parent(int i)
		{
			if(i>1)
			{
				double b = i/2;
				return (int)Math.Floor(b);
			}
			else
			return 0;
		}

		public void PutNewStringLength(int num)
		{
			if(num > _heapArray[1] && count >= heapsize)
			{
				_heapArray[1] = num;
				MinHeapify(1);

			}
			else if(count < heapsize)
			{
				count ++;
				_heapArray[count] = num;
				MinHeapify(count);
			}
				
		}

		public void PrintHeap()
		{
			for(int i=1 ;i <= heapsize; i++)
			{
				Console.WriteLine(_heapArray[i]);
			}
		}

		private void MaxHeapify(int i)
		{
			int l = i * 2;
			int r = i * 2 + 1;
			int greatest;
			int temp;
			if (l <= heapsize && _heapArray[l] == findLargerMSBNuber(_heapArray[l], _heapArray[i]))
			{
				greatest = l;
			}
			else
			{
				greatest = i;
			}
			if (r <= heapsize && _heapArray[r] == findLargerMSBNuber(_heapArray[r], _heapArray[greatest]))
			{
				greatest = r;
			}
			if (greatest != i)
			{
				temp = _heapArray[i];
				_heapArray[i] = _heapArray[greatest];
				_heapArray[greatest] = temp;
				MaxHeapify(greatest);
			}
		}

		private int findLargerMSBNuber(int num1, int num2)
		{
			Stack<int> stack = findDigits(num1);
			Stack<int> stack1 = findDigits(num2);
			int element1 , element2;
			while(stack.Count > 0 && stack1.Count > 0)
			{
				element1 = stack.Pop();
				element2 = stack1.Pop();
				if(element1 > element2)
				return num1;
				else if(element2 > element1)
				return num2;
				if(stack.Count == 0 && stack1.Count > 0)
				{
					while(stack1.Count > 0 )
					{
						element2 = stack1.Pop();
						if(element1 > element2)
						{
							return num1;
						}
						else if(element2 > element1)
						{
							return num2;
						}
					}
				}
				else if(stack.Count > 0 && stack1.Count == 0)
				{
					while(stack.Count > 0 )
					{
						element1 = stack.Pop();
						if(element1 > element2)
						{
							return num1;
						}
						else if(element2 > element1)
						{
							return num2;
						}
					}
				}
			}

			return num1;
		}
			

			
		private Stack<int> findDigits(int num)
		{
			Stack<int> stack = new Stack<int>();
			while(num > 0)
			{
				stack.Push(num % 10);
				num = num /10;
			}
			return stack;
		}

		public int[] ArrangeArrayByMSBs(int[] a)
		{
			a.CopyTo(_heapArray,1);
			heapsize = a.Length -1;
			for(int i = (_heapArray.Length-1)/2 ; i >= 1 ; i--)
			{
				MaxHeapify(i);
			}
			for(int j = _heapArray.Length -1 ; j >= 1 ; j--)
			{
				int temp = _heapArray[j];
				_heapArray[j] = _heapArray[1];
				_heapArray[1] = temp;
				heapsize = heapsize -1;
				MaxHeapify(1);
			}

			_heapArray.Reverse();
			return _heapArray;
		}

	}
}
