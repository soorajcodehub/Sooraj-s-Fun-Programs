using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunPrograms
{
    public class CircularLinkedList
    {
        SinglyLinkedListNode tail;
        Random r = new Random(20);
        public SinglyLinkedListNode CreateCircularSinglyLinkedList(int numberOfNodes)
        {
            int i = 1; 
            this.tail = new SinglyLinkedListNode(this.r.Next(20));
            SinglyLinkedListNode current = this.tail;
            while(i < numberOfNodes)
            { 
                current.next = new SinglyLinkedListNode(r.Next(20));
                current = current.next;
                i++;
            }
            current.next = tail;

            return this.tail;

        }

        public void printCircularLinkedList()
        {
            SinglyLinkedListNode current = this.tail;
            do
            {
                Console.Write(current.data + "-->");
                current = current.next;

            } while (current != this.tail);
            Console.Write(this.tail.data);
        }
    }
    
}
