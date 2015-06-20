using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunPrograms
{
    public class OperatorTree
    {
        private TreeNode root;

        public OperatorTree(TreeNode node)
        {
            try
            {

                if (node is OperatorTreeNode)
                {
                    this.root = node;
                }
                else
                {
                    throw new Exception("Root can not be Operand");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Caught " + ex.Message);
            }
        }
        public int evaluateTree(TreeNode node)
        {
            if (node is OperandNode)
            {
                OperandNode op1 = (OperandNode)node;
                return op1.data;
            }
            else
            {
                OperatorTreeNode oper1 = (OperatorTreeNode)node;
                int leftvalue = evaluateTree(oper1.left);
                int rightvalue = evaluateTree(oper1.right);

                switch (oper1.data)
                {
                    case "+": return leftvalue + rightvalue;
                    case "-": return leftvalue - rightvalue;
                    case "*": return leftvalue * rightvalue;
                    default: return leftvalue / rightvalue;
                }
            }
        }


    }
}
