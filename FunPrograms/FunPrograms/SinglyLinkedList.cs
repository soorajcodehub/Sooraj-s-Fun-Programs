using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace FunPrograms
{
    
    public class SinglyLinkedListNode
    {
        public int data;
        public SinglyLinkedListNode next;
		public SinglyLinkedListNode prev;
        


        public SinglyLinkedListNode(int data)
        {
            this.data = data;
        }
    }


    public class SinglyLinkedList
    {

        public SinglyLinkedListNode head; 

        public void AddNodes(int data)
        {

            SinglyLinkedListNode node;
            if (head == null)
            {
                head = new SinglyLinkedListNode(data);
            }
            else
            {
                node = head;
                while (node.next != null)
                {
                    node = node.next;
                }
				
                node.next = new SinglyLinkedListNode(data);
				node.next.prev = node;
            }
            
        }

  

        //public static void deleteNode(int data)
        //{
        //    SinglyLinkedListNode node = head;
        //    SinglyLinkedListNode temp;

        //    if (head.data == data)
        //    {
        //        temp = head;
        //        head = head.next;
        //        temp = null;
        //        return;
        //    }

        //    while(node != null)
        //    {

        //        if (node.data == data)
        //        {
        //            node.data = node.next.data;
        //            node.next = node.next.next;
        //            temp = node.next;
        //            temp = null;
        //            break;
        //        }
        //            node = node.next;
                
        //    }

        //}

        public void printLinkedList()
        {
            SinglyLinkedListNode node = head;
            while(node != null)
            {
                Console.Write(node.data);
                if(!(node.next==null))
                {
                    Console.Write(" " + "--->");
                }
                node =node.next;
            }

        }

        public static void removeDuplicates(SinglyLinkedListNode head)
        {
            SinglyLinkedListNode previous = head;
            SinglyLinkedListNode current = head.next;
            SinglyLinkedListNode runner = previous;

            while (current != null)
            {
                runner = head;
                while (runner != current)
                {
                    if (runner.data == current.data)
                    {
                        SinglyLinkedListNode temp = current.next;
                        previous.next = temp;
                        current = temp;
                        break;
                    }
                    runner = runner.next;

                }
                if (runner == current)
                {
                    previous = current;
                    current = current.next;
                }
            }
        }

        public static SinglyLinkedListNode ReturnNthToLastNode(int n, SinglyLinkedListNode head)
        {
            SinglyLinkedListNode runner = head;
            for (int i = 0; i < n; i++)
            {
                runner = runner.next;
            }

            SinglyLinkedListNode current = head;
            while (runner.next != null)
            {
                runner = runner.next;
                current = current.next;
            }

            return current;
        }

        public static void DeleteMiddleNode(SinglyLinkedListNode node)
        {
            if (node == null || node.next == null)
            {
                return;
            }
            else
            {
                SinglyLinkedListNode temp = node.next;
                node.data = temp.data;
                node.next = temp.next;
            }
        }

        //public static SinglyLinkedListNode ReturnCircularBegeinNode()
        //{
        //    SinglyLinkedListNode n1 = head;
        //    SinglyLinkedListNode n2 = head;
        //    while (n2.next != null)
        //    {
        //        n1 = n1.next;
        //        n2 = n2.next.next;
        //        if (n1 == n2)
        //            break;
        //    }
        //    if (n2.next == null)
        //        return null;

        //    n1 = head;
        //    while (n1 != n2)
        //    {
        //        n1 = n1.next;
        //        n2 = n2.next;
        //    }

        //    return n1;
        //}

        public static SinglyLinkedListNode AddLinkedLists(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
        {
            SinglyLinkedListNode current1 = head1;
            SinglyLinkedListNode current2 = head2;
            int carry = 0, sum = 0;
            SinglyLinkedListNode head3 = new SinglyLinkedListNode(0);
            SinglyLinkedListNode current3 = head3;
            while (current1 != null && current2 != null)
            {
                sum = current1.data + current2.data + carry;
                carry = sum / 10;
                sum = sum % 10;
                current3.data = sum;
                current1 = current1.next;
                current2 = current2.next;
                if (!(current1 == null && current2 == null))
                {
                    current3.next = new SinglyLinkedListNode(0);
                    current3 = current3.next;
                }
            }
            if (current1 == null)
            {
                while (current2 != null)
                {
                    sum = current2.data + carry;
                    carry = sum / 10;
                    sum = sum % 10;
                    current3.data = sum;
                    current3.data = current2.data + carry;
                    current2 = current2.next;
                    if (!(current2 == null))
                    {
                        current3.next = new SinglyLinkedListNode(0);
                        current3 = current3.next;
                    }
                }
            }

            if (current2 == null)
            {
                while (current1 != null)
                {
                    sum = current1.data + carry;
                    carry = sum / 10;
                    sum = sum % 10;
                    current3.data = sum;
                    current1 = current1.next;
                    if (!(current1 == null))
                    {
                        current3.next = new SinglyLinkedListNode(0);
                        current3 = current3.next;
                    }
                }
            }

            if (current1 == null && current2 == null && carry > 0)
            {
                current3.next = new SinglyLinkedListNode(carry);
            }

            return head3;
        }

		public ArrayList RandomSampling(int m)
		{
			
			ArrayList randomSample = new ArrayList(m);
			SinglyLinkedListNode current = head;
			int pos = 0;
			Random r = new Random();
			int k = 0;
			while(current != null)
			{	
				pos = k++;
				if(pos < m)
				{
					randomSample.Add(current);
				}
				else
				{
					pos = r.Next(k);
					if(pos< m)
					{
						randomSample.RemoveAt(pos);
						randomSample.Insert(pos,current);
					}
				}

				current = current.next;
			}
			return randomSample;
		}

		public void ScrambleList()
		{
			SinglyLinkedListNode prev;
			SinglyLinkedListNode current = head;
			SinglyLinkedListNode currentFront = current.next;
			current.next = currentFront.next;
			currentFront.next =current;
			head = currentFront;
			prev = current;
			current = current.next;
			currentFront = current.next;
			while(currentFront !=null)
			{
				current.next = currentFront.next;
				currentFront.next = current;
				prev.next = currentFront;
				prev = current;
				current = current.next;
				if(current != null)
				currentFront = current.next;
				else break;
				
			}
			printLinkedList();
		}

		public bool IsPalindrome()
		{
			SinglyLinkedListNode node = isPalindrome(head, head);
			if(node == null)
			return false;
			return true;
		}

		private SinglyLinkedListNode isPalindrome(SinglyLinkedListNode left, SinglyLinkedListNode right)
		{
			
			if(right == null)
			return left;

			left = isPalindrome(left,right.next);

			if(left != null)
			{
				if(left.data == right.data)
				{
					if(left.next != null)
					{
						return left.next;
					}
					return left;
				}
			}

			return null;
		}
			

			public SinglyLinkedListNode convertDoublyLinkedListToTree(SinglyLinkedListNode head,int numberOfNodes)
			{
				if(numberOfNodes < 0)
				return null;

				SinglyLinkedListNode left = convertDoublyLinkedListToTree(head,numberOfNodes/2);

				SinglyLinkedListNode root = head;

				head.prev = left;

				head = head.next;


				root.next = convertDoublyLinkedListToTree(head,numberOfNodes - numberOfNodes/2 - 1);
				 return root;
			}




            

                    


    }
}
