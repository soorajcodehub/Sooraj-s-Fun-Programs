using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace FunPrograms
{
	public class StringOperations 
	{
		ArrayList Strings = new ArrayList(25);
		private Heap stringLengthheap;
		public StringOperations()
		{
			stringLengthheap = new Heap();
			Strings.Add("sooraj");
			Strings.Add("aditi");
			Strings.Add("sara");
			Strings.Add("purandare");
			Strings.Add("maharashtra");
		}

		public void PrintTopThreeLengthiestStrings()
		{
			for(int i = 0 ; i < Strings.Count ; i++)
			{
				String temp = (String)Strings[i];
				stringLengthheap.PutNewStringLength(temp.Length);
			}
			stringLengthheap.PrintHeap();
		}

		public int[,] CalculateLCS(String s1, String s2)
		{
			if(s1 == null || s2 == null)
			return null;

			int n = s1.Length;
			int m = s2.Length;

			int [,] _lcsArray = new int[n+1,m+1];

			for(int i = 0 ; i <= n ; i ++)
			{
				for(int j = 0 ; j <= m ; j++)
				{
					if(i==0 || j==0)
					_lcsArray[i,j] = 0;

					else
					{
						if(Char.ToLower(s1[i-1]) == Char.ToLower(s2[j-1]))
						{
							_lcsArray[i,j] = _lcsArray[i-1,j-1] + 1;
						}
						else
						{
							_lcsArray[i,j] = Math.Max(_lcsArray[i-1,j],_lcsArray[i,j-1]);
						}
					}
				}
			}
			return _lcsArray;
		}

		public void  ReturnDiff(string s1,string s2)
		{
			int[,] _LCSArray = CalculateLCS(s1,s2);;
			printdiff(s1,s2,_LCSArray,s1.Length-1,s2.Length-1);
		}

		public void printdiff(string s1, string s2,int[,] _LCSArray,int i, int j)
		{
			if (i > 0 && j > 0 && Char.ToLower(s1[i]) == char.ToLower(s2[j]))
			{
				 printdiff(s1,s2,_LCSArray, i-1, j-1);
				 Console.WriteLine("+ " + s1[i]);
			}
			else if(j >0 && (i == 0 || _LCSArray[i,j-1] >= _LCSArray[i-1,j]))
			{
				printdiff( s1, s2, _LCSArray, i, j-1);
				Console.WriteLine(" + " + s2[j]);
			}
			else if (i > 0 && (j == 0 || _LCSArray[i,j-1] < _LCSArray[i-1,j]))
			{
				printdiff( s1, s2, _LCSArray, i-1, j);
				Console.WriteLine(" + " + s1[i]);
			}
			else
			{
				Console.WriteLine("  ");
			}
		}

		public int FindMinimumInsertionsToformPalindrome(String s1)
		{
			if(string.IsNullOrEmpty(s1))
			return 0;
			
			int n = s1.Length;
			int[,] _matrix = new int[n,n];
			int i, j; 
			for(int gap = 1 ; gap < n ; gap ++)
			{
				for(i=0, j=gap; j < n ; ++i, ++ j)
				{
					_matrix[i,j] = (s1[i] == s1[j]) ?  _matrix[i+1,j-1] : (Math.Min(_matrix[i+1,j],_matrix[i,j-1]))+1;
				}
			}

			return _matrix[0,n-1];
		}

		public bool DoesPatternMatch(String pattern,String str, int i, int j)
		{
			if(String.IsNullOrEmpty(pattern) || String.IsNullOrEmpty(str))
			return false;
			
			if(i == pattern.Length -1)
			return true;
			else if(j== str.Length -1)
			return false;
			if(pattern[i] == str[j])
			return DoesPatternMatch(pattern,str,i+1,j+1);
			if(pattern[i] != str[j] && pattern[i] == '*')
			return DoesPatternMatch(pattern,str,i+1,j+1);
			if(pattern[i] != str[j] && pattern[i-1] == '*')
			return DoesPatternMatch(pattern,str,i,j+1);
			return false;
		}

		public String ReverseSentence(String str)
		{
			if(String.IsNullOrEmpty(str))
			return null;
			ReverseString(ref str,0,str.Length-1);
			int startPosition=0,i = 0;
			while(i < str.Length-1)
			{
				if(str[i] == ' ')
				{
					ReverseString(ref str,startPosition,i-1);
					startPosition = i+1;
				}
				i++;
			}
			ReverseString(ref str,startPosition,i);
			
			return str;
		}

		public void ReverseString(ref String str,int startPosition, int endPosition)
		{
			
			char[] a = str.ToCharArray();
			char temp;
			for(int i = startPosition, j = endPosition ; i < j ;i++,j--)
			{
				temp = a[i];
				a[i] = a[j];
				a[j] = temp;
			}
			str = new string(a);
		}


	}


}
