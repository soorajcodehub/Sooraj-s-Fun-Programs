using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunPrograms
{
    public class Stack
    {
        int[] a;
        uint top1, top2, top3;
        uint max1, max2,max3;
        uint totalArraySize;
        public Stack(uint totalArraySize)
        {
            this.totalArraySize = totalArraySize;
            a = new int[totalArraySize];
            top1 = 0;
            max1 = totalArraySize / 3;
            top2 = max1;
            max2 = 2 * (totalArraySize / 3);
            top3 = max2;
            max3 = totalArraySize -1;
        }

        public void push(int stacknum, int num)
        {
            switch (stacknum)
            {
                case 1:
                    if (top1 == max1)
                    {
                        Console.WriteLine("Stack is full");
                        Console.ReadKey();
                    }
                    else
                    {
                        a[top1] = num;
                        top1++;
                    }
                    break;
                case 2:
                    if (top2 == max2)
                    {
                        Console.WriteLine("Stack is full");
                        Console.ReadKey();
                    }
                    else
                    {
                        a[top2] = num;
                        top2++;
                    }
                    break;
                case 3:
                    if (top3 == max2)
                    {
                        Console.WriteLine("Stack is full");
                        Console.ReadKey();
                    }
                    else
                    {
                        a[top3] = num;
                        top3++;
                    }
                    break;
                default:
                    Console.WriteLine("Wrong Stack selected");
                    break;
            }
        }

        public void printStack()
        {
            Console.WriteLine("Stack 1----  ");
            Console.WriteLine();
            for (uint i = 0; i < top1; i++)
            {
                Console.WriteLine(a[i]);
            }

            Console.WriteLine("Stack 2----  ");
            Console.WriteLine();
            for (uint i = max1; i < top2; i++)
            {
                Console.WriteLine(a[i]);
            }

            Console.WriteLine("Stack 3----  ");
            Console.WriteLine();
            for (uint i = max2; i < top3; i++)
            {
                Console.WriteLine(a[i]);
            }
        }
    }







              




    }

