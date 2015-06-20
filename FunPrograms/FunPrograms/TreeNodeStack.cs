using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace FunPrograms
{
	public class TreeNodeStack
	{
		public ArrayList _stack = new ArrayList();
		static int top = 0;
		public void push(TreeNode n, int level)
		{
			TreeNodeElement _element = new TreeNodeElement(n, level);
			_stack.Add(_element);
			top++;
		}
		public TreeNodeElement pop()
		{
			if (!IsStackEmpty())
			{
				top--;
				TreeNodeElement _element = (TreeNodeElement)_stack[top];
				_stack.RemoveAt(top);
				return _element;
			}
			else
				return null;
		}

		public bool IsStackEmpty()
		{
			return (top == 0);
		}
	}
}
