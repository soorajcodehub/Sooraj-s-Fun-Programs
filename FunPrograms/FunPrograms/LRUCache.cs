using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunPrograms
{
	public class LRUCache
	{
		LruCacheItem item1;
		LruCacheItem item2;
		LruCacheItem item3;
		LruCacheItem item4;
		LruCacheItem item5;
		LruCacheItem item6;
		LruCacheItem item7;
		LruCacheItem item8;
		LruCacheItem item9;
		LruCacheItem item10;
		LruCacheItem item11;
		DoublyLinkedList<LruCacheItem> _LruQueue;
		LRUDictionary<int, DoublyLinkedListNode<LruCacheItem>> _leruDict;


		public LRUCache()
		{
			 item1 = new LruCacheItem(1,"A");
			 item2 = new LruCacheItem(2, "B");
			 item3 = new LruCacheItem(3, "C");
			 item4 = new LruCacheItem(4, "D");
			item5 = new LruCacheItem(5, "E");
			 item6 = new LruCacheItem(6, "Aditi");
			 item7 = new LruCacheItem(7, "Aditi");
			 item8 = new LruCacheItem(8, "Aditi");
			 item9 = new LruCacheItem(9, "Aditi");
			 item10 = new LruCacheItem(10, "Aditi");
			 item11 = new LruCacheItem(11, "Aditi");
			 _leruDict = new LRUDictionary<int, DoublyLinkedListNode<LruCacheItem>>();
			 _LruQueue = new DoublyLinkedList<LruCacheItem>();
		}
		

		public void createLRUCahce()
		{

			_leruDict._dictionary.Add(1,_LruQueue.Add(item2));
			_leruDict._dictionary.Add(2,_LruQueue.Add(item3));
			_leruDict._dictionary.Add(3, _LruQueue.Add(item4));
			_leruDict._dictionary.Add(4, _LruQueue.Add(item5));
			_leruDict._dictionary.Add(5, _LruQueue.Add(item6));
			_leruDict._dictionary.Add(6, _LruQueue.Add(item7));
			_leruDict._dictionary.Add(7, _LruQueue.Add(item8));
			_leruDict._dictionary.Add(8, _LruQueue.Add(item9));
			_leruDict._dictionary.Add(9, _LruQueue.Add(item10));
			_leruDict._dictionary.Add(10, _LruQueue.Add(item1));

		}

		
		public LruCacheItem GetCachedItem(int pageNumber)
		{
			//lock(this)
			{
				DoublyLinkedListNode<LruCacheItem> item;
				if(_leruDict._dictionary.ContainsKey(pageNumber))
				{
					item = _leruDict._dictionary[pageNumber];
					item = _LruQueue.ReturnReferencedNode(item);
					item.Data.Data = "Old Data";
				}
				else
				{
					item = new DoublyLinkedListNode<LruCacheItem>(new LruCacheItem(pageNumber,"new data"));
					_leruDict._dictionary.Add(pageNumber,item);
					_LruQueue.AddToFront(item);
				}
				
				return item.Data;
			}
		}

	}

	public class LruCacheItem : IComparable<LruCacheItem>
	{
		int number;

		public int Number
		{
			get { return number; }
			set { number = value; }
		}
		string data;

		public string Data
		{
			get { return data; }
			set { data = value; }
		}
		public LruCacheItem(int number, string data)
		{
			this.number = number;
			this.data = data;
		}

		public int CompareTo(LruCacheItem item)
		{
			return ((this.data == item.data && item.number == this.number) ? 1 : 0 );
		}
	}
}
