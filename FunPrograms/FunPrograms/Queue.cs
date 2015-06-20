using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace FunPrograms
{
	public class Queue
	{
		public ArrayList _queue = new ArrayList(); 
		static int rear = 0;
		static int front = 0;
		public void Enqueue(TreeNode n)
		{
			_queue.Add(n);
			rear ++;
		}
		public TreeNode Dequeue()
		{
			if(!IsQueueEmpty())
			{
				TreeNode n = (TreeNode)_queue[front];
				front++;
				return n;
			}
			else
			return null;
		}
			
		public bool IsQueueEmpty()
		{
			return(front == rear);
		}
    }
}
