using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunPrograms
{
	public class TreeNodeElement
	{
		public TreeNode node;
		public int level;

		public TreeNodeElement(TreeNode node, int level)
		{
			this.node = node;
			this.level = level;
		}
	}
}
