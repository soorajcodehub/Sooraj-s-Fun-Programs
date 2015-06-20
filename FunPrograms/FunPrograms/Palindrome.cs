using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace FunPrograms
{
	class Palindrome
	{
		String str;
		public Palindrome(String str)
		{
			this.str = str;
		}

		public void findPalindromes()
		{
			ArrayList palindromeList = new ArrayList();
			char[] strArray= str.ToCharArray();
			int k=0,j=0,p=0,q=0,n=0,i=0;
			while(n<str.Length && q < str.Length)
			{
				k = j+1;
				if(strArray[i] == strArray[k])
				{
					String pal = new String(strArray,i,k -i +1);
					palindromeList.Add(pal);
					p = i-1;
					q = k+1;
					while(p >= 0 && q < str.Length && strArray[p] == strArray[q])
					{
						String pal1 = new String(strArray,p,q - p +1);
						palindromeList.Add(pal1);
						p --;
						q++;
					}
					i = j = q; 
				}
				else if(i +2 == k)
				{
					i = i+1;
				}
				else
				{
					j = j +1;
				}
				n= n + 1;
			}

			foreach(String s in palindromeList)
			{
				Console.WriteLine(s+" ");
			}

			Console.ReadKey();
		}


					


			
			
	}
}
