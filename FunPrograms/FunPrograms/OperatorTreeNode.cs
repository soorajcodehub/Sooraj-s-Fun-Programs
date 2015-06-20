using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunPrograms
    {
    public class OperatorTreeNode : TreeNode
        {
			public string data;
			public OperatorTreeNode(string s)
			{
				this.data = s;
			}
        }
    }
