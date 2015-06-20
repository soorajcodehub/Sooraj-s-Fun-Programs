using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunPrograms
	{
	public class OperandNode : TreeNode
		{
			public int data;
			public OperandNode(int s)
			{
				this.data = s;
			}
		}
	}
