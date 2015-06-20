using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FunPrograms
{
    public class MultiThreader
    {
        public void MergeSortLinkedLIst(MyLinkedListNode<int> head)
        {
           MyLinkedListNode<int> a = new MyLinkedListNode<int>();
           MyLinkedListNode<int> b = new MyLinkedListNode<int>();

            if (head != null && head.next != null)
            {
                SplitLinkedList(head, ref a, ref b);
                var t1 = Task.Factory.StartNew(()=> MergeSortLinkedLIst(a));
                var t2 = Task.Factory.StartNew(()=> MergeSortLinkedLIst(b));
                Task.WaitAll(t1, t2);
                head = MergeSortedLinkedLists(a, b);
            }

        }

        private MyLinkedListNode<int> MergeSortedLinkedLists(MyLinkedListNode<int> a, MyLinkedListNode<int> b)
        {
            MyLinkedListNode<int> result = null;

            if (a == null)
                return b;

            if (b == null)
                return a;

            if(a.data > b.data )
            {
                result = b;
                result.next = MergeSortedLinkedLists(a, b.next);
            }
            else
            {
                result = a;
                result.next = MergeSortedLinkedLists(a.next, b);
            }

            return result;

        }

        private void SplitLinkedList(MyLinkedListNode<int> head, ref MyLinkedListNode<int> a, ref MyLinkedListNode<int> b)
        {
            if (head == null)
            {
                a = null;
                b = null;
            }

            if (head.next == null)
            {
                a = head;
                b = null;
            }
            else
            {
                MyLinkedListNode<int> slow = head ; MyLinkedListNode<int> fast = head;
                a = slow;
                fast = slow.next;
                while(fast != null)
                {
                    fast = fast.next;
                    if (fast != null)
                    {
                        fast = fast.next;
                        slow = slow.next;
                    }
                }

                b = slow.next;
                slow.next = null;
            }   
        }
    }
}
