using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunPrograms
{
	public class DoublyLinkedList<T> where T:IComparable<T>
	{
		private DoublyLinkedListNode<T> head;
		private DoublyLinkedListNode<T> tail;
		public const int MaximimNumberOfNodes = 10; 
		public int NumberOfNodes; 

		public DoublyLinkedListNode<T> Tail
		{
			get { return tail; }
			set { tail = value; }
		}

		public DoublyLinkedListNode<T> Head
		{
			get { return head; }
			set { head = value; }
		}

		private DoublyLinkedListNode<T> current;

		public DoublyLinkedListNode<T> Add(T data)
		{
			if(NumberOfNodes == MaximimNumberOfNodes)
			{
				Dequeue();
			}
			if(head == null)
			{
				tail = head = new DoublyLinkedListNode<T>(data);
				
			}
			else
			{
				tail.Next = new DoublyLinkedListNode<T>(data);
				tail.Next.Prev = tail;
				tail = tail.Next;
			}
			NumberOfNodes ++ ;
			return tail;
		}

		public void Dequeue()
		{
			if(tail == head)
			{
				head = null;
			}
			else
			{
				tail = tail.Prev;
				tail.Next = null;
			}
			NumberOfNodes --;
		}

		public DoublyLinkedListNode<T> ReturnReferencedNode(DoublyLinkedListNode<T> cachedItem)
		{
			
			if(cachedItem == head)
			return head;
			else 
			{
				head.Prev = cachedItem;
				cachedItem.Prev.Next = cachedItem.Next;
				if(cachedItem.Next != null)
				{
					cachedItem.Next.Prev = cachedItem.Prev;
				}
				cachedItem.Next = head;
				cachedItem.Prev = null;
				head = cachedItem;
				return head;
			}
		}










		public void AddToFront(DoublyLinkedListNode<T> item)
		{
			if (NumberOfNodes == MaximimNumberOfNodes)
			{
				Dequeue();
			}
			item.Next = head;
			head.Prev = item;
			head = head.Prev;
		}

		}
	}
