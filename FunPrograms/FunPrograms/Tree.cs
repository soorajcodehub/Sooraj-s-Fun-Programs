using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunPrograms
{
	class Tree
	{
		TreeNode root; 
		public Tree(TreeNode node)
		{
			root = node;
		}

		public void addNode(TreeNode node)
		{
			addNode(root,node);
		}

		private void addNode(TreeNode root,TreeNode node)
		{
			if(root == null)
			{
				root = node;
				return;
			}
			if(root.data > node.data)
			{
				addNode(root.left,node);
			}
			else if(root.data < node.data)
			{
				addNode(root.right,node);
			}
		}

	}
}
