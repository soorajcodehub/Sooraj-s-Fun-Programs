using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunPrograms
{
    public class Annagrams
    {
        String str1, str2;

        public Annagrams(String str1, String str2)
        {
            this.str1 = str1;
            this.str2 = str2;
        }   

        public bool areAnagrams()
        {

            if (String.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2) || (str1.Length != str2.Length))
                return false;

            if (str1.Length == 1)
                return (str1[0] == str2[0]);

            Dictionary<char, int> charSet = new Dictionary<char, int>();
			HashSet<char> hs = new HashSet<char>();
			
            int i = 0;
            for (int j = 0; j < str1.Length; j++)
            {
                if (!charSet.ContainsKey(str1[j]))
                {
                    charSet.Add(str1[j], 1);
                }
                else
                {
                    charSet.TryGetValue(str1[j], out i);
                    charSet[str1[i]] = i + 1;
                }
            }

            for (int k = 0; k < str2.Length; k++)
            {
                if (!charSet.ContainsKey(str2[k]))
                    return false;
                else
                {
                    charSet.TryGetValue(str2[k], out i);
                    charSet[str2[k]] = i - 1;
                }
            }

            if (charSet.Values.Max() == 0)
                return true;

            else
                return false;



        }

		public int LongestCommonSubstring()
		{
			if(String.IsNullOrEmpty(str1) || String.IsNullOrEmpty(str2))
			return 0;

			try{

				int m = str1.Length;
				int n = str2.Length;

				int[,] LCS = new int[m,n];

				int max = 0;

				for(int i = 0 ; i < m ; i ++)
				{
					for(int j = 0 ; j < n ; j ++)
					{
						if(i == 0 || j==0)
						{
							LCS[i,j] = 0;
						}
						else if(str1[i-1] == str2[j-1])
						{
							LCS[i,j] = LCS[i-1,j-1] +1;
							if(max < LCS[i,j])
							max = LCS[i,j];
						}
						else
						{
							LCS[i,j] = 0;
						}
					}
				}
			return max;
			}catch(IndexOutOfRangeException ex) 
			{
				Console.Out.WriteLine(ex.Message);
				return -1;
			}
		}

	}

		public class IndexNode
		{
			public int index;
			public IndexNode next;
		}

		public class TrieNode
		{
			TrieNode [] children; 
			bool isEnd; 
			IndexNode head;

			public TrieNode()
			{
				this.isEnd = false;
				this.head = null;
				this.children = new TrieNode[26];
			}

			public void insertNode(ref TrieNode root,string buffer,int bufferIndex, int index)
			{
				if(root == null)
				root = new TrieNode();
				if(bufferIndex <= buffer.Length -1)
				insertNode(ref root.children[buffer[bufferIndex] - 'a'],buffer,bufferIndex+1,index);
				else
				{
					if(root.isEnd)
					{
						IndexNode node = (IndexNode)root.head;
						while(node.next != null)
						{
							node = node.next;
						}
						node.next = new IndexNode();
						node.next.index = index;
					}
					else
					{
						root.isEnd = true;
						root.head = new IndexNode();
						root.head.index = index;
					}
				}
			}

			public void traverseTrie(TrieNode root, string[] stringsArray)
			{
				if(root == null)
				return;

				if(root.isEnd)
				{
					IndexNode node = root.head;
					while(node.next != null)
					{
						Console.Out.WriteLine(stringsArray[node.index] + " ");
						node = node.next;
					}
				}
				else
				{
					for(int i = 0 ; i < 26 ; i ++ )
					{
						traverseTrie(root.children[i],stringsArray);
					}
				}
			}

			public  void CreateTrie(String[] stringsArray)
			{
				TrieNode root = null;
				for(int i = 0; i < stringsArray.Length ; i ++)
				{
					char[] buffer = stringsArray[i].ToCharArray();
					Array.Sort(buffer);
					insertNode(ref root,new String(buffer),0,i);

				}
				traverseTrie(root,stringsArray);
			}

			public  void FindAnagrams()
			{
				String[] stringsArray = {"cat", "act", "abcd" , "dabc" , "aaaa", "bb", "aab", "baa"};
				CreateTrie(stringsArray);
			}
    }
}
