using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace FunPrograms
	{
	public class BinarySearchTree
		{
			private ArrayList treeNodeList = new ArrayList();
			TreeNode root;
			public TreeNode BalanceBinaryTree()
			{
				
				fillInorderTreeNodeList(root,treeNodeList);
				removeChildren(treeNodeList);
				constructBalancedTree(treeNodeList);
				return root;
			}


			public void Insert(TreeNode node)
			{
				if(node ==null)
				{
					Console.WriteLine("Error");
				}
				if(root == null)
				{
					root = node;
				}
				else
				{
					insertNode(node,root);
				}
			}

			private void insertNode(TreeNode nodeToinsert, TreeNode node)
			{
				if (nodeToinsert.data < node.data)
				{
					if(node.left == null)
					node.left = nodeToinsert;
					else
					insertNode(nodeToinsert,node.left);
				}
				else if(nodeToinsert.data > node.data)
				{
					if(node.right ==null)
					node.right = nodeToinsert;
					else
					insertNode(nodeToinsert,node.right);
				}
				else
				Console.WriteLine("Error Duplicate Data");
			}

			private void constructBalancedTree(ArrayList treeNodeList)
				{
					TreeNode middleNode = (TreeNode)treeNodeList[treeNodeList.Count/2];
					Insert(middleNode);
				}

			private void removeChildren(ArrayList treeNodeList)
				{
					foreach(TreeNode node in treeNodeList)
					{
						node.left = null;
						node.right = null;
					}
				}



			private void fillInorderTreeNodeList(TreeNode n, ArrayList treeNodeList)
			{
				if (n != null)
				{
					fillInorderTreeNodeList(n.left,treeNodeList);
					treeNodeList.Add(n);
					fillInorderTreeNodeList(n.right,treeNodeList);
				}

				for(int i = 0 ; i < treeNodeList.Count ; i++)
				{
					Console.Write(" " + ((TreeNode)treeNodeList[i]).data);
				}
			}

			public void printBFSTree()
			{
				Queue _queue = new Queue();
				_queue.Enqueue(root);
				TreeNode n;
				while(!_queue.IsQueueEmpty())
				{
					n = _queue.Dequeue();
					Console.WriteLine(n.data);
					if(n.left != null)
					_queue.Enqueue(n.left);
					if (n.right != null)
					_queue.Enqueue(n.right);
				}
			}

			public void TraversInorderTree()
			{
				ArrayList list = new ArrayList();
				TreeNode current = root;
				TreeNode temp;
				while(current != null)
				{
					if(current.left == null)
					{
						list.Add(current);
						current = current.right;
					}
					else
					{
						temp = current.left;
						while(temp.right != current && temp.right != null)
						temp = temp.right;
						if(temp.right == null)
						{
							temp.right = current;
							current = current.left;
						}
						else
						{
							temp.right = null;
							list.Add(current);
							current = current.right;
						}
					}
				}

				for(int i = 0 ; i <list.Count ; i ++ )
				{
					Console.Write(" " + ((TreeNode)list[i]).data);
				}
			}

			private void printLeafNodes(TreeNode root)
			{
				
				if(root!=null)
				{
					printLeafNodes(root.left);
					if(root.left == null && root.right==null)
					{
						Console.WriteLine(root.data);
					}
					printLeafNodes(root.right);
				}
			}

			private void printLeftTopDownTree(TreeNode root)
			{
				
				if(root.left!=null)	
				{
					Console.WriteLine(root.data);
					printLeftTopDownTree(root.left);
				}
				else if(root.right!=null)
				{
					Console.WriteLine(root.data);
					printLeftTopDownTree(root.right);
				}
			}

			private void printRightUpTree(TreeNode root)
			{
				if(root.right!=null)
				{
					printRightUpTree(root.right);
					Console.WriteLine(root.data);
				}
				else if(root.left!=null)
				{
					printRightUpTree(root.left);
					Console.WriteLine(root.data);
				}
			}

			public void printTreeBoundary()
			{
				printLeftTopDownTree(root);
				printLeafNodes(root);
				printRightUpTree(root);
			}

			public TreeNode PostOrderPredecessor(TreeNode n)
			{
				
				if(n.right != null)
				return n.right;
				else if(n.left!=null)
				return n.left;
				TreeNode parent= findParent(n);
				if(parent.left == n)
				{
					parent = findParent(parent);
					return parent.right;
				}
				else if(parent.right == n)
				{
					return parent.left;
				}
				return null;
			}

			public TreeNode findParent(TreeNode n)
			{
				return findParent(root,n);
			}

			private TreeNode findParent(TreeNode root, TreeNode n)
			{
				if(root.left == n || root.right == n)
				{
					return root;
				}
				else if(n.data < root.data)
				return findParent(root.left,n);
				else
				return findParent(root.right,n);
			}
					
											
			public TreeNode CommonAncestor(TreeNode n1, TreeNode n2)
			{
				return commonAncestor(root,n1,n2);
			}

			private TreeNode commonAncestor(TreeNode root,TreeNode n1,TreeNode n2)
			{
				if(root == null)
				return null;
				if(root ==n1 || root == n2)
				{
					return root;
				}

				TreeNode left = commonAncestor(root.left,n1,n2);
				TreeNode right = commonAncestor(root.right,n1,n2);

				if(left != null && right != null)
				return root;
				else if (left!=null)
				return left;
				else
				return right;
			}

			public TreeNode FindCeiling(int data)
			{
				return FindCeiling(root,data);
			}

			private TreeNode FindCeiling(TreeNode root,int data)
			{
				if(root == null)
				return root;
				if(root.data < data)
				{
					return FindCeiling(root.right,data);
				}
				TreeNode temp = null;
				if(root.data > data)
				{
					 temp = FindCeiling(root.left,data);
				}
				if(temp == null)
				return root;
				
				return temp;
			}

			public TreeNode ReturnInorderSuccessor(TreeNode n)
			{
				TreeNode p,q;
				if(n.right != null)
				{
					n = n.right;
					while(n.left != null)
					{
						n= n.left;
					}
					return n;
				}
				else if(n.right == null)
				{
					p = findParent(n);
					if(p.left==n)
					return p;
					else if(p.right ==n)
					{
						q = findParent(p);
						while(q.left != p)
						{
							p = q;
							q = findParent(p);
						}
						return q;
					}
				}
				return null;
			}

			public void deleteTreeNode(TreeNode n)
			{
				TreeNode p; 
				if(n.right == null && n.left == null)
				{
					p = findParent(n);
					if(p.right == n)
					{
						p.right = null;
					}
					else if(p.left==n)
					{
						p.left = null;
					}
				}
				else if(n.right == null && n.left != null)
				{
					p = findParent(n);
					if(p.right == n)
					{
						p.right = n.left;
					}
					else if(p.left == n)
					{
						p.left = n.left;
					}
				}
				else if(n.right != null && n.left == null)
				{
					p = findParent(n);
					if(p.right == n)
					{
						p.right = n.right;
					}
					else if(p.left == n)
					{
						p.left = n.right;
					}
				}
				else if(n.left != null && n.right != null)
				{
					p = findParent(n);
					TreeNode k = ReturnInorderSuccessor(n);
					if(p.left == n)
					p.left = k;
					else if(p.right == n)
					p.right = k;
				}
			}	

			public void findNodesForSum(int x)
			{
				bool flag1 = true;
				bool flag2 = true;

				Stack<TreeNode> s1= new Stack<TreeNode>();
				Stack<TreeNode> s2= new Stack<TreeNode>();
				TreeNode current1 = root;
				TreeNode current2 = root;
				int val = 0,val2 = 0;
				while(true)
				{
					while(flag1)
					{
						if(current1 != null)
						{
							s1.Push(current1);	
							current1 = current1.left;
						}
						else
						{
							if(s1.Count ==0)
							{
								flag1 = false;
							}
								current1 = s1.Pop();
								val = current1.data;
								current1 = current1.right;
								flag1 = false;
						}
					}

					while(flag2)
					{
						if(current2 != null)
						{
							s2.Push(current2);
							current2 = current2.right;
						}
						else
						{
							if(s2.Count == 0)
							{
								flag2 = false;
							}

							current2 = s2.Pop();
							val2 = current2.data;
							current2 = current2.left;
							flag2 = false;
						}
					}

					if(x == (val + val2))
					Console.WriteLine("Nodes found = " + val, + val2 );

					if( x > (val + val2))
					{
						flag2 = true;
					}

					else
					flag1 = true;
				}
			}

			public void createDoublyLinkedListFromTree(TreeNode root, TreeNode prev, TreeNode head)
			{
				if(root == null)
				return;

				createDoublyLinkedListFromTree(root.left,prev,head);

				root.left = prev;
				if(prev == null)
				head = root;


				TreeNode right = root.right;
				head.left = root;
				root.right = head;

				prev = root;

				createDoublyLinkedListFromTree(root.right,prev,head);
			}

			public void FindPathBetweenNodes(TreeNode n1, TreeNode n2)
			{
				TreeNode _commonAncestor = CommonAncestor(n1,n2);
				Stack<TreeNode> _stack1 = FindPathFromAncestor(_commonAncestor,n1);
				Stack<TreeNode> _stack2 = FindPathFromAncestor(_commonAncestor,n2);
				Queue<TreeNode> _queue = new Queue<TreeNode>();

				Console.WriteLine("Path between nodes is : " );
				
				while(_stack1.Count() > 0)
				{
					Console.Write(_stack1.Pop().data + " -> " );
				}
				while (_stack2.Count() > 0)
				{
					_queue.Enqueue(_stack2.Pop());
				}
				while(_queue.Count > 0)
				{
					_stack2.Push(_queue.Dequeue());
				}
				_stack2.Pop();
				while (_stack2.Count() > 0)
				{
					Console.Write(_stack2.Pop().data + " -> ");
				}
			}

			public Stack<TreeNode> FindPathFromAncestor(TreeNode n1, TreeNode n2)
			{
				Stack<TreeNode> _stack = new Stack<TreeNode>();
				_stack.Push(n1);
				bool isLeftTreeDone = false; 
				while(!(_stack.Count() == 0) )
				{
					TreeNode n = _stack.Peek();
					if(n == n2)
					{
						return _stack;
					}
					
					if(n.left != null && !isLeftTreeDone)
					_stack.Push(n.left);

					else if(n.right != null && isLeftTreeDone)
					{
						_stack.Push(n.right);
						isLeftTreeDone = false;
					}
					else if(n.left == null && n.right == null)
					{
						TreeNode child = _stack.Pop();
						TreeNode parent = _stack.Peek();
						if(parent.right != child)
						{
							_stack.Push(parent.right);
						}
						else
						{
							_stack.Pop();
							isLeftTreeDone= true;
						}
					}
				}
				return null;	
			}
		}
	}
