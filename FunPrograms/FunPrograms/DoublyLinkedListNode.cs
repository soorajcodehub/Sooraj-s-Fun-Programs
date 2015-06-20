using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunPrograms
{
	public class DoublyLinkedListNode<T>  where T: IComparable<T>
	{

		private T data;

		public T Data
		{
			get { return data; }
			set { data = value; }
		}
		public DoublyLinkedListNode(T data)
		{
			this.data = data;
		}
			
		private DoublyLinkedListNode<T> next;

		public DoublyLinkedListNode<T> Next
		{
			get { return next; }
			set { next = value; }
		}
		private DoublyLinkedListNode<T> prev;

		public DoublyLinkedListNode<T> Prev
		{
			get { return prev; }
			set { prev = value; }
		}

		public int CompareTo(T other)
		{
			return(this.data.CompareTo(other));
		}


	}
		
}
